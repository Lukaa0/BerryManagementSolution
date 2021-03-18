using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Activities;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Fragments;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.Service;
using Java.Interop;
using ZXing;
using ZXing.Mobile;
using ActionBar = Android.Support.V7.App.ActionBar;
using AlertDialog = Android.App.AlertDialog;
using Permission = Android.Content.PM.Permission;

namespace BerryManagementAndroidApplication
{
    
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar")]
    public class MainActivity : AppCompatActivity, NavigationView.IOnNavigationItemSelectedListener
    {
        MobileBarcodeScanner scanner;
        private string msg;
        private DrawerLayout drawer;
        private bool doubleBackToExitPressedOnce;
        private NavigationView navigationView;

        private OperationService.BM_Operation_Service operationService = new OperationService.BM_Operation_Service()
        {
            Url = GlobalVariables.OperationServiceUrl
        };

        private ProgressDialog pdialog;
        private LocationAuthorizationState authState;
        private UserModel user;

        public string Msg { get => msg; set => msg = value; }
        
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            operationService.GetLatestVersionCompleted += OperationService_GetLatestVersionCompleted;
            await LocalDbService<LocationAuthorizationState>.Instance.CreateTableAsync();
             authState = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
             user = await LocalDbService<UserModel>.Instance.GetFirst();
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            MobileBarcodeScanner.Initialize(Application);
            AllTask.MainWindow = this.Window;
            string message = string.Empty;
             drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this, drawer, toolbar, Resource.String.navigation_drawer_open, Resource.String.navigation_drawer_close);
            drawer.AddDrawerListener(toggle);
            toggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            var headerLayout = navigationView.GetHeaderView(0);
            navigationView.SetNavigationItemSelectedListener(this);
            if (authState == null || authState.IsAuthorized == false)
            {
                var fragment = new LocationFragment();
                Bundle data = new Bundle();
                data.PutBoolean("direction", false);
                data.PutBoolean("IsSendBack", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.CommitAllowingStateLoss();
            }
            else
            {
                FillUserInfo(authState, user, headerLayout);
                var fragment = new StartPageFragment();
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.AddToBackStack(null);
                ft.CommitAllowingStateLoss();
            }

            await ShowHideMenuItems();



        }

        private void OperationService_GetLatestVersionCompleted(object sender, OperationService.GetLatestVersionCompletedEventArgs e)
        {
            if (GetAppVersion() != e.Result)
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("დადასტურება");
                alert.SetMessage("ახალი ვერსია ნაპოვნია, გსურთ ჩამოტვირთვა?");
                alert.SetPositiveButton("დიახ", async (senderAlert, args) =>
                {

                    ApplicationUpdateManager updateManager = new ApplicationUpdateManager(this);
                    updateManager.GetCurrentVersion();
                    pdialog.Dismiss();
                });

                alert.SetNegativeButton("არა", (senderAlert, args) => { pdialog.Dismiss(); });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
            else
            {
                Toast.MakeText(this, "განახლება არ არის საჭირო", ToastLength.Long).Show();
                pdialog.Dismiss();
            }
        }

        public string GetAppVersion()
        {
            var info = ApplicationContext.PackageManager.GetPackageInfo(ApplicationContext.PackageName, 0);
            return info.VersionName;
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            Intent alarmIntent = new Intent(this.ApplicationContext, typeof(AlarmReceiver));

            StopService(alarmIntent);


        }
        public void SetTitle()
        {
            this.Title = $"{user.User_Person_FirstName}|| {authState.PointTitle}";
        }
        private void FillUserInfo(LocationAuthorizationState authState, UserModel user, View headerLayout)
        {
            this.Title = $"{user.User_Person_FirstName}|| {authState.PointTitle}";

            headerLayout.FindViewById<TextView>(Resource.Id.nav_username).Text = user.User_Person_FirstName;
            headerLayout.FindViewById<TextView>(Resource.Id.nav_point_name).Text = authState.PointTitle;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {

            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        }
        public override void OnBackPressed()
        {
            if (drawer.IsDrawerOpen(GravityCompat.Start))
            {
                drawer.CloseDrawer(GravityCompat.Start);
            }
            else
            {

                if (doubleBackToExitPressedOnce)
                {
                    base.OnBackPressed();
                    Java.Lang.JavaSystem.Exit(0);
                    return;
                }


                this.doubleBackToExitPressedOnce = true;
                Toast.MakeText(this, "დააჭირეთ კიდევ ერთხელ გასასვლელად", ToastLength.Short).Show();

                new Handler().PostDelayed(() => { doubleBackToExitPressedOnce = false; }, 2000);
            }

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);

            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private async Task ShowHideMenuItems()
        {
            var permissions =
                (await LocalDbService<UserPermissionsModel>.Instance.selectItems()).Select(x => x.PermissionId).ToList();
            navigationView.Menu.FindItem(Resource.Id.nt_rows).SetVisible(permissions.Contains(2));
            navigationView.Menu.FindItem(Resource.Id.nav_dividing).SetVisible(permissions.Contains(4));
            navigationView.Menu.FindItem(Resource.Id.nav_takeRowOut).SetVisible(permissions.Contains(5));
            navigationView.Menu.FindItem(Resource.Id.nt_harvesters).SetVisible(permissions.Contains(6));
            navigationView.Menu.FindItem(Resource.Id.nav_rowDistribution).SetVisible(permissions.Contains(7));
            navigationView.Menu.FindItem(Resource.Id.nav_rowDistributionOut).SetVisible(permissions.Contains(8));
            navigationView.Menu.FindItem(Resource.Id.nav_receiving).SetVisible(permissions.Contains(9));
            navigationView.Menu.FindItem(Resource.Id.nt_containers).SetVisible(permissions.Contains(10));
            navigationView.Menu.FindItem(Resource.Id.container_movein).SetVisible(permissions.Contains(11));
            navigationView.Menu.FindItem(Resource.Id.container_moveout).SetVisible(permissions.Contains(12));
            navigationView.Menu.FindItem(Resource.Id.car_movein).SetVisible(permissions.Contains(32));
            navigationView.Menu.FindItem(Resource.Id.nt_punishments).SetVisible(permissions.Contains(15));
            navigationView.Menu.FindItem(Resource.Id.nav_punishment_container).SetVisible(permissions.Contains(38));
            navigationView.Menu.FindItem(Resource.Id.nav_punishment_harvester).SetVisible(permissions.Contains(37));
            navigationView.Menu.FindItem(Resource.Id.nav_punishment_container_person).SetVisible(permissions.Contains(39));
           
          
            navigationView.Menu.FindItem(Resource.Id.nav_create_palet).SetVisible(permissions.Contains(36));
            navigationView.Menu.FindItem(Resource.Id.nav_close_palet).SetVisible(permissions.Contains(36));

            navigationView.Menu.FindItem(Resource.Id.nav_container_quality).SetVisible(permissions.Contains(42));

            navigationView.Menu.FindItem(Resource.Id.container_sendBack).SetVisible(permissions.Contains(41));

            navigationView.Menu.FindItem(Resource.Id.nt_sale).SetVisible(permissions.Contains(34));
            navigationView.Menu.FindItem(Resource.Id.nav_sale_container).SetVisible(permissions.Contains(35));
            navigationView.Menu.FindItem(Resource.Id.nav_sale_palet).SetVisible(permissions.Contains(40));
        }
        
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.nav_dividing)
            {
                var fragment = new TakeRowFragment();
                var bundle = new Bundle();

                bundle.PutBoolean("direction", true);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.container_moveout)
            {
              var  fragment = new ContainerInOutFragment();
                
                Bundle data = new Bundle();
                data.PutBoolean("container-direction", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();

            }
            else if (id == Resource.Id.nav_update)
            {
                pdialog = new ProgressDialog(this);
                pdialog.SetTitle("იტვირთება");
                pdialog.Show();
                operationService.GetLatestVersionAsync(string.Empty);

            }
            //else if (id == Resource.Id.nav_rows_and_harvesters)
            //{
            //    var fragment = new RowsFragment();
            //    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
            //    ft.Replace(Resource.Id.content_frame, fragment);
            //    ft.Commit();
            //}
            else if (id == Resource.Id.nav_takeRowOut)
            {
              var  fragment = new TakeRowFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", false);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_rowDistribution)
            {
             var   fragment = new HarvesterRowDistributionFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", true);
                
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }

            else if (id == Resource.Id.nav_rowDistributionOut)
            {
                var fragment = new HarvesterRowDistributionFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", false);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_sale_palet)
            {
                var fragment = new SaleContainerFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", true);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_container_quality)
            {
                var fragment = new ProductQualityFragment();
               
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_sale_container)
            {
                var fragment = new SaleContainerFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", false);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_create_palet)
            {
                var fragment = new ContainerPackFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", true);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_close_palet)
            {
                var fragment = new PaletContainerPackFragment();
                var bundle = new Bundle();
                bundle.PutBoolean("direction", false);
                fragment.Arguments = bundle;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_help)
            {
                var fragment = new HelpFragment();
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            //else if (id == Resource.Id.nav_containerDistribution)
            //{
            //    var fragment = new HarvesterContinerDistributionFragment();
            //    var bundle = new Bundle();
            //    bundle.PutBoolean("direction", true);
            //    fragment.Arguments = bundle;
            //    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
            //    ft.Replace(Resource.Id.content_frame, fragment);
            //    ft.Commit();
            //}
            //else if (id == Resource.Id.nav_containerDistributionOut)
            //{
            //    var fragment = new HarvesterContinerDistributionFragment();
            //    var bundle = new Bundle();
            //    bundle.PutBoolean("direction", false);
            //    fragment.Arguments = bundle;
            //    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
            //    ft.Replace(Resource.Id.content_frame, fragment);
            //    ft.Commit();
            //}
            else if (id == Resource.Id.nav_logout)
            {
                Task.Run(async () =>
                {
                    await LocalDbService<UserModel>.Instance.DeleteAll();
                    await LocalDbService<UserPermissionsModel>.Instance.DeleteAll();
                    await LocalDbService<LocationAuthorizationState>.Instance.DeleteAll();
                });
                    

                StartActivity(typeof(LoginActivity));

            }
            else if (id == Resource.Id.nav_receiving)
            {
               var fragment = new ProductFragment();
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.container_movein)
            {
                var fragment = new ContainerInOutFragment();
                Bundle data = new Bundle();
                data.PutBoolean("container-direction", true);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.car_movein)
            {
                var fragment = new LocationFragment();
                Bundle data = new Bundle();

                data.PutBoolean("direction", true);
                data.PutBoolean("IsSendBack", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.container_sendBack)
            {
                var fragment = new LocationFragment();
                Bundle data = new Bundle();
                data.PutBoolean("direction", true);
                data.PutBoolean("IsSendBack", true);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            //else if (id == Resource.Id.car_moveout)
            //{
            //    var fragment = new CarOpenCloseFragment();
            //    Bundle data = new Bundle();
            //    data.PutBoolean("direction", false);
            //    fragment.Arguments = data;
            //    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
            //    ft.Replace(Resource.Id.content_frame, fragment);
            //    ft.Commit();
            //}
            else if (id == Resource.Id.nav_punishment_harvester)
            {
                var fragment = new PunishmentFragment();
                Bundle data = new Bundle();
                data.PutBoolean("isContainer", false);
                data.PutBoolean("isContainerPerson", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_punishment_container)
            {
                var fragment = new PunishmentFragment();
                Bundle data = new Bundle();
                data.PutBoolean("isContainer", true);
                data.PutBoolean("isContainerPerson", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_punishment_container_person)
            {
                var fragment = new PunishmentFragment();
                Bundle data = new Bundle();
                data.PutBoolean("isContainer", true);
                data.PutBoolean("isContainerPerson", true);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else if (id == Resource.Id.nav_loc_change)
            {
                var fragment = new LocationFragment();
                Bundle data = new Bundle();
                data.PutBoolean("direction", false);
                data.PutBoolean("IsSendBack", false);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }


            //}
            //else if (id == Resource.Id.nav_slideshow)
            //{

            //}
            //else if (id == Resource.Id.nav_manage)
            //{

            //}
            //else if (id == Resource.Id.nav_share)
            //{

            //}
            //else if (id == Resource.Id.nav_send)
            //{

            //}

            DrawerLayout drawer = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            drawer.CloseDrawer(GravityCompat.Start);
            return true;
        }




        //Scaner
        //[Export("ScannBarCode")]
        //public async void  ScannBarCodeAsync(View v)
        //{
        //    scanner = new MobileBarcodeScanner();
        //    ExecuteTask("cannotSleep");
        //    //Tell our scanner to use the default overlay
        //    scanner.UseCustomOverlay = false;

        //    //We can customize the top and bottom text of the default overlay
        //    scanner.TopText = "Hold the camera up to the barcode\nAbout 6 inches away";
        //    scanner.BottomText = "Wait for the barcode to automatically scan!";

        //    //Start scanning
        //    var result = await scanner.Scan();

        //    HandleScanResult(result);
        //    ExecuteTask("canSleep");

        //}
        //public void HandleScanResult(ZXing.Result result)
        //{
        //    if (result != null && !string.IsNullOrEmpty(result.Text))
        //        this.msg = result.Text;
        //    else
        //        this.msg = "Scanning Canceled!";
        //}

        //public void ExecuteTask(string task)
        //{
        //    switch (task)
        //    {
        //        case "cannotSleep":
        //            this.Window.AddFlags(WindowManagerFlags.KeepScreenOn);
        //            break;

        //        case "canSleep":
        //            this.Window.ClearFlags(WindowManagerFlags.KeepScreenOn);
        //            break;
        //    }
        //}

    }
}

