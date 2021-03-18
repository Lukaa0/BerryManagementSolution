using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model;

namespace BerryManagementAndroidApplication.Fragments
{
    public class LocationFragment : Fragment
    {
        private RecyclerView recyclerView;
        private LocationRecyclerViewAdapter locationAdapter;
        private BM_Library_Service libraryClient;
        private bool _direction;
        private bool _IsSendBack;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _direction = Arguments.GetBoolean("direction");
            _IsSendBack = Arguments.GetBoolean("IsSendBack");
            libraryClient = new BM_Library_Service()
            {
                Url = GlobalVariables.LibraryServiceUrl
            };
            Activity.Title = "ლოკაცია";
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view =  inflater.Inflate(Resource.Layout.location_main_layout, container, false);
            FindViews(view);
            return view;
        }
        public async override  void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            string message = string.Empty;
            libraryClient.GetAllPointsCompleted += (sender, e) =>
            {

                if (e.Error != null)
                    //Toast.MakeText(Activity, "დაფიქსირდა შეცდომა, გთხოვთ მოიცადოთ.", ToastLength.Long).Show();
                     Alerter.ErrorAlertAsync(Context, "დაფიქსირდა შეცდომა");
                else
                {
                    var locations = e.Result;
                    locationAdapter = new LocationRecyclerViewAdapter(locations.ToList());
                    SetupRecyclerView();
                    locationAdapter.ItemClick += LocationAdapter_ItemClick;
                }

            };
            if (_direction)
            {
                LocationAuthorizationState location = new LocationAuthorizationState();
                    location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
                    libraryClient.GetAllPointsAsync(location.PointID, true, message);
            }
            else
            {
                libraryClient.GetAllPointsAsync(null,true, message);
            }
            
            
        }

        private async void LocationAdapter_ItemClick(object sender, LocationRecyclerViewAdapterClickEventArgs e)
        {
            
            var item = locationAdapter.GetItem(e.Position);
           
            if (_direction)
            {
                var fragment = new CarOpenCloseFragment();
                Bundle data = new Bundle();
                data.PutLong("PointID", item.Point_Id);
                data.PutBoolean("IsSendBack", _IsSendBack);
                data.PutBoolean("direction", true);
                fragment.Arguments = data;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.Commit();
            }
            else{
                await LocalDbService<LocationAuthorizationState>.Instance.DeleteAll();
                var state = new LocationAuthorizationState()
                {
                    IsAuthorized = true,
                    PointID = item.Point_Id,
                    PointTitle = item.Point_Name
                };
                await LocalDbService<LocationAuthorizationState>.Instance.InsertOrUpdateState(state);
                StartActivity(new Intent().SetClass(Activity, typeof(MainActivity)));
            }
           
        }

        private void FindViews(View view)
        {
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.location_recycler_view);
            
        }

        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Activity, 1);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(locationAdapter);
        }
    }
}