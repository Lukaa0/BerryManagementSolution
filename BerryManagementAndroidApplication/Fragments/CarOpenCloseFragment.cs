using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using BerryManagementAndroidApplication.Adapters;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.StructureService;
using BerryManagementAndroidApplication.OperationService;
using Java.Lang;
using BerryManagementAndroidApplication.API;
using System.Net;
using System.Threading.Tasks;
using Android.Media;
using BerryManagementAndroidApplication.Model;
using Android.Graphics;
using BerryManagementAndroidApplication.SecurityService;

namespace BerryManagementAndroidApplication.Fragments
{
    public class CarOpenCloseFragment : Fragment
    {

        private Button _confirmButton;
        private Button scanBtn;
        private RecyclerView _recyclerView;
        private EditText _edittext;
        private TextView _resulttext;
        private Spinner _transportSpinner;
        private ArrayAdapter<string> _transportSpinnerAdapter;
        private NumberPicker _NumberPicker;

        
        private EditText codeEditText;
        private bool _direction;
        private string rowText;
        private List<PointsModel> _items = new List<PointsModel>();
        private CarOpenCloseRecyclerViewAdapter _adapter;
        private TakeRowInOut rowInOut;
        private ProgressDialog progressDialog;
        private Spinner _spinner;
        private List<PointsModel> _cars;
        private LinearLayout _NumberPickerLayout;
       
        private long _pointID;
        private bool _IsSendBack;
        private BM_Operation_Service operationClient = new BM_Operation_Service()
        {
            Url = GlobalVariables.OperationServiceUrl
        };
        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private BM_Structure_Service structureClient = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private List<TakeRow> _takeRows = new List<TakeRow>();
        private List<TakeRowInOut> takeRowsInOuts = new List<TakeRowInOut>();
        private ArrayAdapter<string> adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetHasOptionsMenu(true);

            _pointID = Arguments.GetLong("PointID");
            _IsSendBack = Arguments.GetBoolean("IsSendBack");
            _direction = Arguments.GetBoolean("direction");
            if (_IsSendBack)
            {

                Activity.Title = "ყუთის დაბრუნება";

            }
            else
            {
                if (_direction)
                    Activity.Title = "ზედნადების ატვირთვა";
                else
                    Activity.Title = "ტრანს. დასრულება";
            }
            progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");
            base.OnCreate(savedInstanceState);


            try
            {
               
                structureService.GetPointsForWaybillCompleted -= StructureService_GetPointsForWaybillCompleted;
                structureService.GetPointsForWaybillCompleted += StructureService_GetPointsForWaybillCompleted;

                structureService.GetPointsForSendBackCompleted -= StructureService_GetPointsForSendBackCompleted;
                structureService.GetPointsForSendBackCompleted += StructureService_GetPointsForSendBackCompleted;
                structureService.GetPointsForWaybillInCompleted -= StructureService_GetPointsForWaybillInCompleted;
                structureService.GetPointsForWaybillInCompleted += StructureService_GetPointsForWaybillInCompleted;
                operationClient.CreateTransportWaybillCompleted -= OperationClient_CreateTransportWaybillCompleted;
                operationClient.CreateTransportWaybillCompleted += OperationClient_CreateTransportWaybillCompleted;
                operationClient.CloseTransportWaybillCompleted -= OperationClient_CloseTransportWaybillCompleted;
                operationClient.CloseTransportWaybillCompleted += OperationClient_CloseTransportWaybillCompleted;
                operationClient.FixContainerSendBackCompleted -= OperationClient_FixContainerSendBackCompleted;
                operationClient.FixContainerSendBackCompleted += OperationClient_FixContainerSendBackCompleted;

                
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException("Calling Fragment must implement OnAddFriendListener");
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view = null;
            if (_IsSendBack)
            {
                 view = inflater.Inflate(Resource.Layout.car_open_close_layout, container, false);
                _edittext = view.FindViewById<EditText>(Resource.Id.carOpenClose_editText);
                _transportSpinner = view.FindViewById<Spinner>(Resource.Id.spinner_carOpenClose_type);
                _confirmButton = view.FindViewById<Button>(Resource.Id.carOpenClose_confirm_btn);
                _resulttext = view.FindViewById<TextView>(Resource.Id.carOpenClose_TextView);
                _NumberPicker = view.FindViewById<NumberPicker>(Resource.Id.numberPicker);
                _NumberPicker.MinValue = 0;
                _NumberPicker.MaxValue = 1000;
               


            }
            else
            {
                 view = inflater.Inflate(Resource.Layout.transport_input_dialog, container, false);
                _edittext = view.FindViewById<EditText>(Resource.Id.dialog_transport_code_edittext);
                _transportSpinner = view.FindViewById<Spinner>(Resource.Id.transport_dialog_spinner);
                _confirmButton = view.FindViewById<Button>(Resource.Id.transport_confirm_btn);
                _resulttext = view.FindViewById<TextView>(Resource.Id.carOpenClose_TextView);
            }


            _resulttext.Text = "";
            _confirmButton.Text = "დადასტურება";
            _confirmButton.Click += _confirmButton_ClickAsync;
            _edittext.RequestFocus();
            _edittext.ShowSoftInputOnFocus = false;
            _edittext.AfterTextChanged += _edittext_AfterTextChanged;

            

            return view;


        }
        private async void OperationClient_CreateTransportWaybillCompleted(object sender, CreateTransportWaybillCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "ჩანაწერი ჩაიწერა", ToastLength.Long).Show();
                Alerter.NotificationAlertAsync(Context, "ზედნადები აიტვირთა!!!");
                _resulttext.SetTextColor(Color.Green);
                //_resulttext.Text = "ჩანაწერი ჩაიწერა";
                _transportSpinnerAdapter.Remove(_transportSpinner.SelectedItem);


            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

                //await Sounder.ErrorSoundAsync(App.Context);
                _resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "ინტერნეტთან კავშირი შეუძლებელია";
            }
            else
            {
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
                //await Sounder.ErrorSoundAsync(App.Context);
                _resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "დაფიქსირდა შეცდომა";
            }
            _confirmButton.Enabled = true;
            _confirmButton.SetBackgroundColor(Color.Green);

            _transportSpinner.SetSelection(0);
        }

        private async void OperationClient_FixContainerSendBackCompleted(object sender, FixContainerSendBackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "ჩანაწერი ჩაიწერა", ToastLength.Long).Show();
                Alerter.NotificationAlertAsync(App.Context, "ზედნადები აიტვირთა!!!");
                //_resulttext.SetTextColor(Color.Green);
                //_resulttext.Text = "ჩანაწერი ჩაიწერა";
               


            }
            else if (e.Error is WebException)
            {
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
                //await Sounder.ErrorSoundAsync(App.Context);
                //_resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "ინტერნეტთან კავშირი შეუძლებელია";
            }
            else
            {
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                //await Sounder.ErrorSoundAsync(App.Context);
                //_resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "დაფიქსირდა შეცდომა";
            }
            _confirmButton.Enabled = true;
            _confirmButton.SetBackgroundColor(Color.Green);

            _transportSpinner.SetSelection(0);
        }

        private async void OperationClient_CloseTransportWaybillCompleted(object sender, CloseTransportWaybillCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                Alerter.NotificationAlertAsync(App.Context, "ზედნადები დახურულია!!!");
               // Toast.MakeText(Activity, "ჩანაწერი ჩაიწერა", ToastLength.Long).Show();
                //_resulttext.SetTextColor(Color.Green);
                //_resulttext.Text = "ჩანაწერი ჩაიწერა";

            }
            else if (e.Error is WebException)
            {
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
                //await Sounder.ErrorSoundAsync(App.Context);
                //_resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "ინტერნეტთან კავშირი შეუძლებელია";
            }
            else
            {
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                //await Sounder.ErrorSoundAsync(App.Context);
                //_resulttext.SetTextColor(Color.Red);
                //_resulttext.Text = "დაფიქსირდა შეცდომა";
            }
            _confirmButton.Enabled = true;
            _confirmButton.SetBackgroundColor(Color.Green);

            _transportSpinner.SetSelection(0);
        }

        private void InitializeSpinners()
        {
            _transportSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _transportSpinnerAdapter.Add("აირჩიეთ ტრანსპორტი");
            _transportSpinner.Adapter = _transportSpinnerAdapter;
        }

        private void _edittext_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            var text = (sender as EditText).Text;
            if (_edittext.Text.Length >= 14)
            {
                var value = _cars.Find(x => x.Point_BarCode == text).Point_Name;
                if (value == null)
                {
                    Alerter.ErrorAlert(Context, "ტრანსპორტი ვერ მოიძებნა");
                    //Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
                    return;
                }

                var position = _transportSpinnerAdapter.GetPosition(value);
                if (position > 0)
                {
                    _transportSpinner.SetSelection(position);
                }
                else
                    Alerter.ErrorAlert(Context, "ტრანსპორტი ვერ მოიძებნა");
                    //Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
            }
            _edittext.RequestFocus();
            _edittext.ShowSoftInputOnFocus = false;

        }
        //სპინერის შევსება
        private async void StructureService_GetPointsForWaybillCompleted(object sender, GetPointsForWaybillCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _cars = e.Result.ToList();
                await LocalDbService<PointsModel>.Instance.DeleteAll();
                await LocalDbService<PointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());

                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }

        private async void StructureService_GetPointsForSendBackCompleted(object sender, GetPointsForSendBackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _cars = e.Result.ToList();
                await LocalDbService<PointsModel>.Instance.DeleteAll();
                await LocalDbService<PointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());

                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }
        private async void StructureService_GetPointsForWaybillInCompleted(object sender, GetPointsForWaybillInCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _cars = e.Result.ToList();
                await LocalDbService<PointsModel>.Instance.DeleteAll();
                await LocalDbService<PointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());

                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }
        



        private void OnError(string errorMessage)
        {
            //Toast.MakeText(Activity, errorMessage,
            //                    ToastLength.Long).Show();
            Alerter.ErrorAlert(Context, errorMessage);
        }

       

        private async void _confirmButton_ClickAsync(object sender, EventArgs e)
        {
            if (_IsSendBack)
            {
                if (_NumberPicker.Value == 0)
                {
                    Alerter.ErrorAlertAsync(Context, "ყუთების რაოდენობა არ არის შეყვანილი");
                    //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                    //Toast.MakeText(Activity, "ყუთების რაოდენობა არ არის შეყვანილი", ToastLength.Long).Show();
                    //player.Start();
                    return;
                }
            }
            if (_transportSpinner.SelectedItemPosition < 1)
            {
                Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                //player.Start();
                return;
            }
            var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();


            var car = _cars.Find(x => x.Point_Name == _transportSpinner.SelectedItem.ToString());

            if (car != null)
            {
                var carId = car.Point_Car_Id;
                if (_IsSendBack)
                {
                    operationClient.FixContainerSendBackAsync(_NumberPicker.Value, true, carId.Value, true, location.PointID, true, _pointID, true, string.Empty);
                    _confirmButton.Enabled = false;
                    _confirmButton.SetBackgroundColor(Color.Gray);
                }
                else
                {
                    if (_pointID != 0)
                    {
                        var user = await LocalDbService<UserModel>.Instance.GetFirst();
                        operationClient.CreateTransportWaybillAsync(carId.Value, true, location.PointID, true, _pointID, true,user.User_PersonPost_ID,true, string.Empty);
                        _confirmButton.Enabled = false;
                        _confirmButton.SetBackgroundColor(Color.Gray);

                    }
                    else
                    {
                        operationClient.CloseTransportWaybillAsync(carId.Value, true, _pointID, true, string.Empty);
                        _confirmButton.Enabled = false;
                        _confirmButton.SetBackgroundColor(Color.Gray);

                    }
                }
            }

            _edittext.RequestFocus();
            _edittext.ShowSoftInputOnFocus = false;

        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
          
            InitializeSpinners();
            if (_direction && !_IsSendBack && _pointID != 0)
            {
                structureService.GetPointsForWaybillInAsync(string.Empty);
            }
            else
            {
                if (_pointID == 0)
                {
                    structureService.GetPointsForWaybillAsync(false, true, null, true, string.Empty);
                }
                else
                {
                    structureService.GetPointsForSendBackAsync(string.Empty);
                }
            }



        }

        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Activity, 1);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_adapter);
        }
    }
}