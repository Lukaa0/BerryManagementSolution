using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.Fragments.Dialogs;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.RsService;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.StructureService;

namespace BerryManagementAndroidApplication.Fragments
{
    public class SaleContainerFragment : Fragment, IOnCompanySelectionCompleted, IOnDialogItemClick
    {
        private RecyclerView _recylcerContainerMoves;
        private EditText codeEditText;
        private Spinner _containerSpinner;
        private Button _allConfirmBtn;
        private Button _tempConfirmBtn;
        private RecyclerView _tempRecyclerView;
        private ProgressBar progressBar;
        private RelativeLayout mainContainer;
        private SaleRecyclerViewAdapter _saleAdapter;
        private bool _direction;
        private ProgressDialog progressDialog;
        private RedItemDialog _redItemDialog;
        private SaleContainer container;
        private BM_Operation_Service operationService;

        private LocationAuthorizationState location;
        


        public long pointId;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private ArrayAdapter<string> _containerSpinnerAdapter;
        private List<SaleContainerModel> _containers;
        private SaleRecyclerViewAdapter _tempRecyclerAdapter;
        private CompanyeModel _company;
        private List<SaleContainer> containerSaleMainListItem;
        private string title;
        private bool _isSelling;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            _direction = Arguments.GetBoolean("direction");
            if (_direction)
                title = "გაყიდვა";
            else
                title = "გაყიდვა";

            Activity.Title = title;
            progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");

            operationService = new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };

            operationService.FixSaleContainerCompleted -= OperationService_FixSaleContainerCompleted;
            operationService.FixSaleContainerCompleted += OperationService_FixSaleContainerCompleted;
            operationService.GetContainerPackCountByCarIdCompleted += OperationService_GetContainerPackCountByCarIdCompleted;
            operationService.GetContainerPackCountByCarIdCompleted += OperationService_GetContainerPackCountByCarIdCompleted;
            structureService.GetContainersForContainerMoveCompleted -= StructureService_GetContainersForContainerMoveCompleted;
            structureService.GetContainersForContainerMoveCompleted += StructureService_GetContainersForContainerMoveCompleted;


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.sale_main_layout, container, false);
            _recylcerContainerMoves = view.FindViewById<RecyclerView>(Resource.Id.containerinout_recycler_view);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.sale_main_progressbar);
            mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.sale_receive_header_container);
            codeEditText = view.FindViewById<EditText>(Resource.Id.sale_scan_edittext);
            _containerSpinner = view.FindViewById<Spinner>(Resource.Id.sale_spinner);
            _allConfirmBtn = view.FindViewById<Button>(Resource.Id.sale_operation_confirm);
            _tempConfirmBtn = view.FindViewById<Button>(Resource.Id.sale_spinner_confirm);
            _tempRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.sale_temp_recylcer);
            _allConfirmBtn.Text = Activity.Title;
            _tempConfirmBtn.Text = "დამატება";
            _tempConfirmBtn.Click += _tempConfirmBtn_Click;
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            _allConfirmBtn.Click += _allConfirmBtn_Click;

            TransportSaleInputDialogFragment fragment = new TransportSaleInputDialogFragment();

            fragment.SetTargetFragment(this, 0);
            fragment.Show(FragmentManager, "dialogtransport");
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            return view;
        }

     

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            progressBar.Visibility = ViewStates.Gone;
            mainContainer.Visibility = ViewStates.Visible;
            _tempRecyclerAdapter = new SaleRecyclerViewAdapter(new List<string>());
            InitializeSpinner();
        }

        public void OnDelete(int position)
        {


        }


      

        //სპინერის შევსება
        private async void StructureService_GetContainersForContainerMoveCompleted(object sender, GetContainersForContainerMoveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {

                _containers = new List<SaleContainerModel>();
                foreach (var item in e.Result)
                {
                    _containers.Add(new SaleContainerModel(item)
                    {
                        Direction = _direction
                    }); ;
                }
                //await LocalDbService<SaleContainerModel>.Instance.DeleteByDirection(_direction);
                //await LocalDbService<SaleContainerModel>.Instance.InsertAllAsnyc(_containers);
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());



            }
            else if (e.Error is WebException)
            {
                //_containers = await LocalDbService<SaleContainerModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());

                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი არ არის", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {

                //_containers = await LocalDbService<SaleContainerModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());

                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }


        

        public async Task OnDone(TransportWaybill transport)
        {

        }

        private void InitializeSpinner()
        {
            _containerSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _containerSpinnerAdapter.Add("აირჩიეთ ყუთი");
            _containerSpinner.Adapter = _containerSpinnerAdapter;
        }

        private void SaleAdapter_ItemClick(object sender, SaleRecyclerViewAdapterClickEventArgs e)
        {
            var position = e.Position;
            Bundle data = new Bundle();
            data.PutInt("position", position);
            _redItemDialog = new RedItemDialog();
            _redItemDialog.Arguments = data;
            _redItemDialog.SetTargetFragment(this, 0);
            _redItemDialog.Show(FragmentManager, "reditemdiaog");

        }

        private async void _tempConfirmBtn_Click(object sender, EventArgs e)
        {
            _isSelling = false;
            if (_containerSpinner.SelectedItemPosition < 1)
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();

                return;
            }
            progressDialog.Show();
            var containerBarcode = _containerSpinner.SelectedItem.ToString();
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            containerSaleMainListItem = new List<SaleContainer>();

            if (_containerSpinner.SelectedItemPosition > 0)
            {
                var containerSale = new SaleContainer()
                {
                    Direction = _direction,
                    ContainerBarCode = containerBarcode,
                    Id = Guid.NewGuid().ToString(),
                    Time = DateTime.Now,
                    PersonPostId = user.User_PersonPost_ID,
                    CompanyName = _company.Company_Name,
                    Company_Id = _company.Company_Id,
                    Company_IdSpecified = true,
                    IsComplete = false,
                    DirectionSpecified = true,
                    IsCompleteSpecified = true,
                    PersonPostIdSpecified = true,
                    TimeSpecified = true
                };


                //operationService.FixSaleContainer(containerSale, _direction, true, false, true, null, true,ref error);   

                string error = string.Empty;
                operationService.FixSaleContainerAsync(containerSale, false, true, null, true, error);

                codeEditText.Focusable = true;
                codeEditText.RequestFocus();
                codeEditText.Text = string.Empty;
            }
            else
            {
                //Toast.MakeText(Activity, "აირჩიეთ ყუთი", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "აირჩიეთ ყუთი");

            }
            _containerSpinnerAdapter.Remove(containerBarcode);

            _containerSpinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        public void AddItem(SaleContainer container)
        {
            _saleAdapter.Add(container);
        }

        

        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            string text = (sender as EditText).Text;
            try
            {

                if (InputValidationUtility.BarcodeLenghtChecker(text))
                {
                    var prefix = InputValidationUtility.BarCodeChecker(text);
                    int position;
                    switch (prefix)
                    {
                        case "CS":
                            position = _containerSpinnerAdapter.GetPosition(text);
                            if (position < 1)
                                return;

                            _containerSpinner.SetSelection(position, true);
                            _tempConfirmBtn.PerformClick();
                            codeEditText.Text = string.Empty;
                            break;
                        case "CL":
                            position = _containerSpinnerAdapter.GetPosition(text);
                            if (position < 1)
                                return;

                            _containerSpinner.SetSelection(position, true);
                            _tempConfirmBtn.PerformClick();
                            codeEditText.Text = string.Empty;
                            break;
                        case "CB":
                            position = _containerSpinnerAdapter.GetPosition(text);
                            if (position < 1)
                                return;

                            _containerSpinner.SetSelection(position, true);
                            _tempConfirmBtn.PerformClick();
                            codeEditText.Text = string.Empty;
                            break;
                        default:
                            throw new InvalidCodeException();
                    }

                }

            }

            catch (InvalidCodeException ecx)
            {
                //Toast.MakeText(Activity, ecx.Message, ToastLength.Short).Show();
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlert(Context, ecx.Message);

                codeEditText.Text = string.Empty;
            }
            codeEditText.Focusable=true;
            codeEditText.RequestFocus();
        }

        /// ///////////////////// //////

        private async void _allConfirmBtn_Click(object sender, EventArgs e)
        {

            _isSelling = true;

            progressDialog.Show();
            operationService.FixSaleContainerAsync(null, true, true, _company.Company_Id, true, string.Empty);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
            _containerSpinner.SetSelection(0);

        }

        private async void SaleConatiner()
        {
            var item = _containerSpinner.SelectedItem.ToString();
           
        }
        //private async void _confirmBtn_Click(object sender, EventArgs e)
        //{
        //    var items = _tempRecyclerAdapter.containerCodes;
        //    var user = await LocalDbService<UserModel>.Instance.GetFirst();
        //    //var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
        //    containerSaleMainListItem = new List<SaleContainer>();
        //    List<Task> tasks = new List<Task>();
        //    if (items.Count > 0)
        //    {
        //        SaleContainer[] saleContainerList = new SaleContainer[items.Count];
        //        int count = 0;
        //        foreach (var item in items)
        //        {

        //            var containerSale = new SaleContainer()
        //            {

        //                Direction = _direction,
        //                ContainerBarCode = item,
        //                Time = DateTime.Now,
        //                PersonPostId = user.User_PersonPost_ID,
        //                Point_Id = _saleCarPoint.Point_Id,
        //                IsComplete = false,
        //                DirectionSpecified = true,
        //                IsCompleteSpecified = true,
        //                PersonPostIdSpecified = true,
        //                Point_Car_IdSpecified = true,
        //                Point_IdSpecified = true,
        //                TimeSpecified = true

        //            };
        //            saleContainerList[count] = containerSale;
        //            count = count + 1;
        //            container = new SaleContainer()
        //            {
        //                ContainerBarCode = containerSale.ContainerBarCode,


        //            };
        //            containerSaleMainListItem.Add(new SaleContainer()
        //            {
        //                ContainerBarCode = containerSale.ContainerBarCode,
        //                Time = containerSale.Time
        //            });


        //            //operationService.FixSaleContainer(containerSale, _direction, true, false, true, null, true,ref error);   
        //        }
        //        string error = string.Empty;
        //        operationService.FixSaleContainerAsync(saleContainerList, _direction, true, false, true, null, true, null, true, user.User_PersonPost_ID, true, error);

        //        codeEditText.Focusable = true;
        //        codeEditText.RequestFocus();
        //        codeEditText.Text = string.Empty;
        //        _containerSpinner.SetSelection(0);
        //    }
        //    else
        //    {
        //        Toast.MakeText(Activity, "აირჩიეთ ყუთი", ToastLength.Long).Show();
        //    }
        //}

        private async void OperationService_FixSaleContainerCompleted(object sender, FixSaleContainerCompletedEventArgs e)
        {
            progressDialog.Dismiss();
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //container.IsComplete = true;
                Activity.Title = e.FixSaleContainerResult + "| " + title;

                if (_isSelling)
                {
                    await Alerter.NotificationAlertAsync(Context, "ჩანაწერი წარმატებით ჩაიწერა");

                    var fragment = new StartPageFragment();

                    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                    ft.Replace(Resource.Id.content_frame, fragment);
                    ft.Commit();
                }
                else
                    Toast.MakeText(Context, "ჩანაწერი წარმატებით ჩაიწერა", ToastLength.Long).Show();
                //_tempRecyclerAdapter.items.Clear();

                //_saleAdapter.items.Clear();
                //_saleAdapter.items.AddRange(containerSaleMainListItem);
                //_saleAdapter.NotifyDataSetChanged();

                //AddItem(container);

            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)

                //    .Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

                //container.IsComplete = false;
                //AddItem(container);
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //container.Error = e.errorMessage;
                //Toast.MakeText(Activity, "დაიფქსირდა შეცდომა, სცადეთ ახლიდან : ContainerMoveInOutFragment",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "დაიფქსირდა შეცდომა, სცადეთ ახლიდან : ContainerMoveInOutFragment");

                //AddItem(container);
            }
            //Activity.RunOnUiThread(() => progressDialog.Dismiss());
        }

        public async void OnRetry(int position)
        {
            //var retryContainer = _saleAdapter.GetItem(position);
            //var user = await LocalDbService<UserModel>.Instance.GetFirst();
            //string msg = string.Empty;
            //var containerSale = new SaleContainer()
            //{
            //    Id = Guid.NewGuid().ToString(),
            //    Direction = _direction,
            //    ContainerBarCode = retryContainer.ContainerBarCode,
            //    Time = DateTime.Now,
            //    PersonPostId = user.User_PersonPost_ID,
            //    Point_Id = _saleCarPoint.Point_Id,
            //    IsComplete = false
            //};
            //operationService.FixSaleContainerCompleted -= OperationService_FixSaleContainerCompleted;
            //operationService.FixSaleContainerCompleted += OperationService_FixSaleContainerCompleted;
            //operationService.FixSaleContainerAsync(containerSale, _direction, true, false, true, null, true,user.User_PersonPost_ID,true, string.Empty);
            //codeEditText.Focusable = true;
            //codeEditText.RequestFocus();
            //codeEditText.Text = string.Empty;

        }

        public Task OnDone(string palet)
        {
            throw new NotImplementedException();
        }

        private async void OperationService_GetContainerPackCountByCarIdCompleted(object sender, GetContainerPackCountByCarIdCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                Activity.Title = e.GetContainerPackCountByCarIdResult + "| " + title;
            }
            else if (e.Error is WebException)
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();


                //Toast.MakeText(Activity, "ინტერნეტის პრობლემა", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");


            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }

        public async Task OnDone(CompanyeModel companyModel)
        {
            _company = companyModel;
            //location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();

            pointId = (await LocalDbService<LocationAuthorizationState>.Instance.GetFirst()).PointID;
            structureService.GetContainersForContainerMoveAsync(_direction, true, pointId, true, string.Empty);
            //operationService.GetSaleContainerAsync(_direction, true, pointId, true, string.Empty);        }
        }
    }
}