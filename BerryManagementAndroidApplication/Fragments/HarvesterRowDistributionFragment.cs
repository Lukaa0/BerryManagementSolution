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
using Android.Text;
using Android.Views;
using Android.Widget;
using Android.Media;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.StructureService;

namespace BerryManagementAndroidApplication.Fragments
{
    public class HarvesterRowDistributionFragment : Fragment,AdapterView.IOnItemSelectedListener
    {
        private EditText _scanCode;
        private Button _scanButton;
        private bool _direction;
        private BM_Operation_Service operationService;
        private HarvesterRowDistributionInOut harvDist;
        private ProgressDialog progressDialog;
        private ProgressBar progressBar;
        private Spinner _rowSpinner;
        private Spinner _harvesterSpinner;
        private Button _confirmBtn;
        private RecyclerView recylcerView;
        private HarvesterRowDistributionRecyclerViewAdapter _adapter;
        private ArrayAdapter<string> _harvesterSpinnerAdapter;
        private ArrayAdapter<string> _rowSpinnerAdapter;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private BM_Employee_Service employeeService = new BM_Employee_Service()
        {
            Url = GlobalVariables.EmployeeServiceIrl
        };
        private List<HarvesterRowDistributionRowModel> _harvRows;
        private List<PersonPostModelLocal> _personPostModel;

        public override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            _direction = Arguments.GetBoolean("direction");
            if (_direction)
                Activity.Title = "მიბმა რიგზე";
            else
                Activity.Title = "მოხსნა რიგიდან";
                
            operationService = new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };
            
            operationService.FixHarvesterRowDistributionInOutCompleted -=
                OperationServiceFixHarvesterRowDistributionInOutCompleted;
            operationService.FixHarvesterRowDistributionInOutCompleted += OperationServiceFixHarvesterRowDistributionInOutCompleted;
            operationService.GetHarvesterRowDistributionInOutsCompleted -= OperationService_GetHarvesterRowDistributionInOutsCompleted;
            operationService.GetHarvesterRowDistributionInOutsCompleted += OperationService_GetHarvesterRowDistributionInOutsCompleted;
            structureService.GetRowsByHarvesterRowInDistributionCompleted -= StructureService_getRowsByHarvesterRowInDistributionCompleted;

            structureService.GetRowsByHarvesterRowInDistributionCompleted += StructureService_getRowsByHarvesterRowInDistributionCompleted;
            employeeService.GetHarvByHarvRowDistrOutsCompleted -= EmployeeService_GetHarvesterByHarvesterRowInDistributionCompleted;
            employeeService.GetHarvByHarvRowDistrOutsCompleted += EmployeeService_GetHarvesterByHarvesterRowInDistributionCompleted;
            progressDialog = new ProgressDialog(Activity);
            //progressDialog.SetTitle("გთხოვთ მოიცადოთ");


        }

        private async void EmployeeService_GetHarvesterByHarvesterRowInDistributionCompleted(object sender, GetHarvByHarvRowDistrOutsCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _personPostModel = new List<PersonPostModelLocal>();
                foreach (var i in e.Result)
                {
                    _personPostModel.Add(new PersonPostModelLocal(i)
                    {
                        ContentType="HarvesterRowDistribution"
                    });
                    
                }
                await LocalDbService<PersonPostModelLocal>.Instance.DeleteByDirection(_direction,"HarvesterRowDistribution");
                await LocalDbService<PersonPostModelLocal>.Instance.InsertAllAsnyc(_personPostModel);
                _harvesterSpinnerAdapter.AddAll(_personPostModel.Select(x => x.Barcode).ToList());
            }
            else if (e.Error is WebException)
            {
                _personPostModel = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems()).Where(x =>
                    x.Direction = _direction && x.ContentType == "HarvesterRowDistribution").ToList();
                _harvesterSpinnerAdapter.AddAll(_personPostModel.Select(x => x.FullName).ToList());
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                _personPostModel = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems()).Where(x =>
                    x.Direction = _direction && x.ContentType == "HarvesterRowDistribution").ToList(); _harvesterSpinnerAdapter.AddAll(_personPostModel.Select(x => x.FullName).ToList());
            }
        }

        private async void OperationService_GetHarvesterRowDistributionInOutsCompleted(object sender, GetHarvesterRowDistributionInOutsCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                var harvDistModel = e.Result.ToList();
                
                _adapter = new HarvesterRowDistributionRecyclerViewAdapter(harvDistModel);
                SetupRecyclerView();
            }
            else if (e.Error is WebException)
            {
                var harvDistModel = await LocalDbService<HarvesterRowDistributionInOut>.Instance.selectItems();
                _adapter = new HarvesterRowDistributionRecyclerViewAdapter(harvDistModel);
                SetupRecyclerView();
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                var harvDistModel = await LocalDbService<HarvesterRowDistributionInOut>.Instance.selectItems();
                _adapter = new HarvesterRowDistributionRecyclerViewAdapter(harvDistModel);
                SetupRecyclerView();
            }
            progressBar.Visibility = ViewStates.Gone;

        }

      
        private async void StructureService_getRowsByHarvesterRowInDistributionCompleted(object sender, GetRowsByHarvesterRowInDistributionCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                 _harvRows = new List<HarvesterRowDistributionRowModel>();
                foreach (var i in e.Result)
                {
                    _harvRows.Add(new HarvesterRowDistributionRowModel(i));
                }
                await LocalDbService<HarvesterRowDistributionRowModel>.Instance.DeleteByDirection(_direction);
                await LocalDbService<HarvesterRowDistributionRowModel>.Instance.InsertAllAsnyc(_harvRows);
                _rowSpinnerAdapter.AddAll(_harvRows.Select(x => x.Barcode).ToList());
            }
            else if (e.Error is WebException)
            {
                _harvRows = await LocalDbService<HarvesterRowDistributionRowModel>.Instance.selectItems();
                _rowSpinnerAdapter.AddAll(_harvRows.Select(x => x.Barcode).ToList());
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                _harvRows = await LocalDbService<HarvesterRowDistributionRowModel>.Instance.selectItems();
                _rowSpinnerAdapter.AddAll(_harvRows.Select(x => x.Barcode).ToList());
            }
        }

        private async void OperationServiceFixHarvesterRowDistributionInOutCompleted(object sender, FixHarvesterRowDistributionInOutCompletedEventArgs e)
        {
            
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                harvDist.IsComplete = true;
                harvDist.Error = null;
                Toast.MakeText(Activity, "ჩანაწერი წარმატებით ჩაიწერა", ToastLength.Long)
                    .Show();
                _adapter.Add(harvDist);
                _harvesterSpinnerAdapter.Remove(_harvesterSpinner.SelectedItem.ToString());
                _harvesterSpinner.Adapter = _harvesterSpinnerAdapter;


            }
            else if (e.Error is WebException)
            {
                Alerter.ErrorAlertAsync(App.Context, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო");
               // Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
                //    .Show();
                harvDist.IsComplete = false;
                await LocalDbService<HarvesterRowDistributionInOut>.Instance.InsertOrReplaceAsync(harvDist);
                _adapter.Add(harvDist);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                Alerter.ErrorAlertAsync(App.Context, e.errorMessage + " სცადეთ ახლიდან");
               // Toast.MakeText(Activity, e.errorMessage + " სცადეთ ახლიდან",
                  //  ToastLength.Long).Show();
                harvDist.Error = e.errorMessage;
                harvDist.IsComplete = true;
                await LocalDbService<HarvesterRowDistributionInOut>.Instance.InsertOrReplaceAsync(harvDist);
                _adapter.Add(harvDist);
            }
            SetupRecyclerView();
            _harvesterSpinner.SetSelection(0);
            _rowSpinner.SetSelection(0);
            progressDialog.Dismiss();
        }
        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            _harvesterSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _harvesterSpinnerAdapter.Add("აირჩიეთ მკრეფავი");
            _rowSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _rowSpinnerAdapter.Add("აირჩიეთ რიგი");
            _harvesterSpinner.Adapter = _harvesterSpinnerAdapter;
            _rowSpinner.Adapter = _rowSpinnerAdapter;
           
            _adapter = new HarvesterRowDistributionRecyclerViewAdapter(new List<HarvesterRowDistributionInOut>());
            PopulateSpinner();
            progressBar.Visibility = ViewStates.Gone;
            //_rowSpinner.OnItemSelectedListener = this;
            //operationService.GetHarvesterRowDistributionInOutsAsync(_direction, true, string.Empty);

        }

        public async void PopulateSpinner()
        {
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            employeeService.GetHarvByHarvRowDistrOutsAsync(_direction, true, user.User_Brigade_ID, true, string.Empty);
            structureService.GetRowsByHarvesterRowInDistributionAsync(user.User_Brigade_ID,true,string.Empty);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
             base.OnCreateView(inflater, container, savedInstanceState);
            //ელემენტების ინიიციალიზაცია
            View view = inflater.Inflate(Resource.Layout.harvester_row_dist_inout_layout,container,false);
            _scanCode = view.FindViewById<EditText>(Resource.Id.harvdist_scan_edittext);
            _scanButton = view.FindViewById<Button>(Resource.Id.harvdist_scan_code_btn);
            recylcerView = view.FindViewById<RecyclerView>(Resource.Id.harvdist_recyclerview);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.harvdist_progressBar);
            _rowSpinner = view.FindViewById<Spinner>(Resource.Id.harvDist_row_spinner);
            _harvesterSpinner = view.FindViewById<Spinner>(Resource.Id.harvDist_harvester_spinner);
            _confirmBtn = view.FindViewById<Button>(Resource.Id.harvester_row_confirm_button);
            _confirmBtn.Click += _confirmBtn_Click;
            _scanCode.AfterTextChanged += CodeEditText_AfterTextChanged; 

            _scanCode.RequestFocus();
            _scanCode.ShowSoftInputOnFocus = false;
            
            _confirmBtn.Text = "დადასტურება";

            if (!_direction)
            {
                _rowSpinner.Visibility = ViewStates.Gone;
            }
            _scanButton.Click += async delegate
            {
                AllTask scan = new AllTask();
                
                var scannResult = await scan.ScannBarCodeAsync(view);
                _scanCode.Text = scan.HandleScanResult(scannResult);
            };
            return view;
        }

        private async void _confirmBtn_Click(object sender, EventArgs e)
        {
            if (!(_harvesterSpinner.SelectedItemPosition > 0))
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");
               // Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                return;
            }
            if (_direction)
            {
                if (!(_rowSpinner.SelectedItemPosition > 0))
                {
                    //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                   // player.Start();
                    Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");
                  //  Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                    return;
                }
            }
            string  rowSpinnerItem = null;
            if (_rowSpinner.Visibility != ViewStates.Gone)
            {
                rowSpinnerItem = _rowSpinner.SelectedItem.ToString();
            }
            await Ready(_harvesterSpinner.SelectedItem.ToString(), rowSpinnerItem);
           
            _scanCode.RequestFocus();
            _scanCode.ShowSoftInputOnFocus = false;
            _scanCode.Text = string.Empty;
        }

        private async Task Ready(string harvesterBarcode,string rowBarcode)
        {
            string message = string.Empty;
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            harvDist = new HarvesterRowDistributionInOut()
                    {
                        Time = DateTime.Now,
                        Direction = _direction,
                        DirectionSpecified = true,
                        RowIdSpecified=true,
                        RowId=null,
                        TimeSpecified=true,
                        UserPersonPostIdSpecified=true,
                        Id = Guid.NewGuid().ToString(),
                        HarvesterBarCode = harvesterBarcode,
                        HarvesterPersonPostId =null,
                        HarvesterPersonPostIdSpecified = true,
                        IsComplete = false,
                        IsCompleteSpecified = true,
                        RowBarCode = rowBarcode,
                        UserPersonPostId = user.User_PersonPost_ID
                    };
            operationService.FixHarvesterRowDistributionInOutAsync(harvDist, message);
            progressDialog.Show();
        }

        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            var text = (sender as EditText).Text;
            try
            {
                if (InputValidationUtility.BarcodeLenghtChecker(text)){
                    var prefix = InputValidationUtility.BarCodeChecker(text);
                    switch (prefix)
                    {
                        case "LR":
                            var position = _rowSpinnerAdapter.GetPosition(text);
                            if (position > 0)
                                _rowSpinner.SetSelection(position);
                            _scanCode.Text = string.Empty;
                            break;
                        case "PH":
                            var personPost = _personPostModel.Find(x => x.Barcode == text);
                            var positionH = personPost != null ?_harvesterSpinnerAdapter.GetPosition(personPost.Barcode) : 0;
                            if (positionH > 0)
                                _harvesterSpinner.SetSelection(positionH);
                            _scanCode.Text = string.Empty;
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
                _scanCode.Text = string.Empty;
            }

        }
        private void SetupRecyclerView()
        { 
            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
            recylcerView.SetLayoutManager(layoutManager);
            recylcerView.SetAdapter(_adapter);
        }

        public async void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            //if (!_direction && position > 0) 
            //{
            //    var selectedItem = _rowSpinnerAdapter.GetItem(position);
            //    var rowId = _harvRows.Find(x => x.Barcode == selectedItem).RowId;
            //    employeeService.GetHarvByHarvRowDistrOutsAsync(_direction,true,rowId, true, string.Empty);
            //}
        }

        public void OnNothingSelected(AdapterView parent)
        {
        }
    }
}