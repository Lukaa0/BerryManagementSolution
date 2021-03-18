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
using Android.Views.Animations;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.StructureService;

namespace BerryManagementAndroidApplication.Fragments
{
    public class PaletContainerPackFragment : Fragment
    {
        private Button _confirmButton;
        private Button scanBtn;
        private RecyclerView _recyclerView;

        private UserModel user;
        private LocationAuthorizationState location;


        private EditText codeEditText;
        private bool _direction;
        private string rowText;
        private List<TakeRowInOut> _items = new List<TakeRowInOut>();
        private TakeRowRecyclerViewAdapter _adapter;
        private TakeRowInOut rowInOut;
        private ProgressDialog progressDialog;
        private Spinner _spinner;
        private ContainerPackModel container;
        private ArrayAdapter<string> _transportSpinnerAdapter;
        private List<ContainerPackLocalModel> _containers;
        private ContainerPackRecyclerViewAdapter _tempRecyclerAdapter;
        private List<ContainerPackModel> containerPackMainListItem;
        private ContainerPackRecyclerViewAdapter _containerPackAdapter;
        private BM_Operation_Service operationClient=new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };
        private BM_Structure_Service structureClient = new BM_Structure_Service()
        {
            Url=GlobalVariables.StructureServiceUrl
        };
        private List<TakeRow> _takeRows = new List<TakeRow>();
        private List<TakeRowInOut> takeRowsInOuts = new List<TakeRowInOut>();
        private ArrayAdapter<string> adapter;
        private List<Container> _palet;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);

            _direction = Arguments.GetBoolean("direction");
            if (_direction) 
                Activity.Title = "";
            else
                Activity.Title = "პალეტის დაშლა";

             progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");


            operationClient.FixContainerPackCompleted -= OperationService_FixContainerPackCompleted;
            operationClient.FixContainerPackCompleted += OperationService_FixContainerPackCompleted;
            operationClient.GetContainerPackModelCompleted -= OperationService_GetContainerPackModelCompleted;
            operationClient.GetContainerPackModelCompleted += OperationService_GetContainerPackModelCompleted;
            structureClient.GetPaletForContainerPackCompleted -= StructureService_GetPaletForContainerPackCompleted;
            structureClient.GetPaletForContainerPackCompleted += StructureService_GetPaletForContainerPackCompleted;


        }

      
       

       
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view =  inflater.Inflate(Resource.Layout.takerowInOut_layout, container, false);
            _confirmButton = view.FindViewById<Button>(Resource.Id.row_confirm_btn);
             scanBtn = view.FindViewById<Button>(Resource.Id.row_scan_code_btn);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.row_check_in_recycler);
            codeEditText = view.FindViewById<EditText>(Resource.Id.row_scan_edittext);
            _spinner = view.FindViewById<Spinner>(Resource.Id.takerow_spinner);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            _confirmButton.Click += _confirmButton_Click;
            _confirmButton.Text ="დადასტურება";
            _adapter = new TakeRowRecyclerViewAdapter(_items);
            _tempRecyclerAdapter = new ContainerPackRecyclerViewAdapter(new List<ContainerPackModel>());
            SetupRecyclerView(_recyclerView, _tempRecyclerAdapter);
            return view;
        }

        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            //SHESACVLELIA 14 ZEC
            var text = (sender as EditText).Text;
            //if (string.IsNullOrEmpty(text))
            //{
            //    Toast.MakeText(Activity, "დაასკანერეთ რიგი", ToastLength.Long).Show();
            //    codeEditText.Text = string.Empty;
            //    return;
            //}
            try
            {
                if (InputValidationUtility.BarcodeLenghtChecker(text))
                {
                    var prefix = InputValidationUtility.BarCodeChecker(text);
                    switch (prefix)
                    {
                        case "CB":
                            var position = _transportSpinnerAdapter.GetPosition(text);
                            if (position >= 0)
                                _spinner.SetSelection(position);
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
        }

        private async void _confirmButton_Click(object sender, EventArgs e)
        {
            if (_spinner.SelectedItemPosition < 1)
            {
                //Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");
                return;
            }
            var text = _spinner.SelectedItem.ToString();
            await Ready(text);
            _transportSpinnerAdapter.Remove(text);
            _spinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            user = await LocalDbService<UserModel>.Instance.GetFirst();
            location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
            // _items = (await db.selectItems()).Where(x => x.Direction == _direction).OrderByDescending(x=>x.Time).ToList();
            adapter = new ArrayAdapter<string>(Activity, Resource.Layout.support_simple_spinner_dropdown_item);
            adapter.Add("აირჩიეთ პალეტი");
            _spinner.Adapter = adapter;
            string message = string.Empty;
            //structureClient.GetPaletForContainerPackAsync(false, true, string.Empty);
            InitializeSpinner();



            


            string error = string.Empty;
            structureClient.GetPaletForContainerPackAsync(false, true, error);


        }

        

        private async Task Ready(string paletbarcode)
        {
            string message = string.Empty;

            var containerpack = new ContainerPack();

            operationClient.FixContainerPackAsync(containerpack, false, true, paletbarcode, false, true, location.PointID, true, user.User_PersonPost_ID, true, message);

            //operationClient.FixContainerPack(containerpack, false, true, paletbarcode, false, true, location.PointID, true, user.User_PersonPost_ID, true,ref message);


            //progressDialog.Show();


        }

        private void InitializeSpinner()
        {
            _transportSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _transportSpinnerAdapter.Add("აირჩიეთ პალეტი");
            _spinner.Adapter = _transportSpinnerAdapter;
        }

        private async void StructureService_GetPaletForContainerPackCompleted(object sender, GetPaletForContainerPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //_palet = e.Result.ToList();
                ////await LocalDbService<String>.Instance.DeleteAll();
                ////await LocalDbService<Container>.Instance.InsertAllAsnyc(_palet);
                //_transportSpinnerAdapter.AddAll(_palet);


                _containers = new List<ContainerPackLocalModel>();
                foreach (var item in e.Result)
                {

                    _containers.Add(new ContainerPackLocalModel(item)
                    {
                        Direction = _direction
                    });

                }
                //await LocalDbService<ContainerPackLocalModel>.Instance.DeleteByDirection(_direction);
                //await LocalDbService<ContainerPackLocalModel>.Instance.InsertAllAsnyc(_containers);
                _transportSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            } 

            else if (e.Error is WebException)
            {
                //_palet = (await LocalDbService<SalePointsModel>.Instance.selectItems());
                //_transportSpinnerAdapter.AddAll(_palet.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია",
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                //_palet = (await LocalDbService<SalePointsModel>.Instance.selectItems());
                //_transportSpinnerAdapter.AddAll(_palet.Select(x => x.Point_Name).ToList());

                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }

        //მთავარი ლისთის შევსება
        private async void OperationService_GetContainerPackModelCompleted(object sender, GetContainerPackModelCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //await LocalDbService<ContainerPackLocalModel>.Instance.DeleteByDirection(_direction);
                //_containers = new List<ContainerPackLocalModel>();
                //foreach (var item in e.Result)
                //{

                //    _containers.Add(new ContainerPackLocalModel(item)
                //    {
                //        Direction = _direction
                //    });

                //}
                //await LocalDbService<ContainerPackLocalModel>.Instance.InsertAllAsnyc(_containers);
                _containerPackAdapter = new ContainerPackRecyclerViewAdapter(e.Result.ToList());
                SetupRecyclerView(_recyclerView, _containerPackAdapter);
            }
            else if (e.Error is WebException)
            {
                //var items = await LocalDbService<ContainerPackLocalModel>.Instance.selectItems();
                //var container = new List<ContainerPackModel>();
                //foreach (var item in items)
                //{

                //    container.Add(new ContainerPackModel(item)
                //    {
                //        Direction = _direction
                //    });

                //}
                //_containerPackAdapter = new ContainerPackRecyclerViewAdapter(container);
                //SetupRecyclerView(_recyclerView, _containerPackAdapter);
                //Toast.MakeText(Activity, "მონაცემები ჩამოიტვირთა ლოკალურად", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //var items = await LocalDbService<ContainerPackLocalModel>.Instance.selectItems();

                //var container = new List<ContainerPackModel>();
                //foreach (var item in items)
                //{

                //    container.Add(new ContainerPackModel(item)
                //    {
                //        Direction = _direction
                //    });

                //}
                //_containerPackAdapter = new ContainerPackRecyclerViewAdapter(container);
                //SetupRecyclerView(_recyclerView, _containerPackAdapter);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }

        private async void OperationService_FixContainerPackCompleted(object sender, FixContainerPackCompletedEventArgs e)
        {

            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //container.IsComplete = true;
                Toast.MakeText(Activity, "ჩანაწერი წარმატებით ჩაიწერა", ToastLength.Long).Show();
                //_containerPackAdapter.items.Clear();

                //_containerPackAdapter.items.AddRange(containerPackMainListItem);
                //_containerPackAdapter.NotifyDataSetChanged();

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

        public void AddItem(ContainerPackModel container)
        {
            _containerPackAdapter.Add(container);
        }


        private void SetupRecyclerView(RecyclerView recyclerView, RecyclerView.Adapter adapter)
        {
            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
        }
      
    }
} 