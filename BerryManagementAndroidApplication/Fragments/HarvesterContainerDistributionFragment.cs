//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Support.V7.Widget;
//using Android.Views;
//using Android.Widget;
//using BerryManagementAndroidApplication.Adapters;
//using BerryManagementAndroidApplication.API;
//using BerryManagementAndroidApplication.Exceptions;
//using BerryManagementAndroidApplication.Model;
//using BerryManagementAndroidApplication.Model.LocalDataModels;
//using BerryManagementAndroidApplication.OperationService;

//namespace BerryManagementAndroidApplication.Fragments
//{
//    public class HarvesterContinerDistributionFragment : Fragment
//    {
//        private EditText _scanCode;
//        private TextView _harvesterCode;
//        SQLiteClient<HarvesterContainerDistributionInOut> db;
//        private ProgressDialog progressDialog;
//        private TextView _containerCode;
//        HarvesterContainerDistributionRecyclerViewAdapter _adapter;
//        private bool _direction;
//        private RecyclerView recyclerView;
//        private RelativeLayout mainContainer;
//        private ProgressBar progressBar;
//        private HarvesterContainerDistributionInOut harvDist;
//        private BM_Operation_Service containerClient;

//        public override async void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            _direction = Arguments.GetBoolean("direction");
//            if (_direction)
//                Activity.Title = "კონტეინერის მიღება";
//            else
//                Activity.Title = "კონტეინერის გაცემა";
//            db = new SQLiteClient<HarvesterContainerDistributionInOut>();

//            progressDialog = new ProgressDialog(Activity);
//            progressDialog.SetTitle("გთხოვთ მოიცადოთ");
//            containerClient = new BM_Operation_Service()
//            {
//                Url = GlobalVariables.OperationServiceUrl
//            };
//            containerClient.FixHarvesterContainerDistributionCompleted -=
//                OperationService_FixHarvesterContainerDistributionCompleted;
//            containerClient.FixHarvesterContainerDistributionCompleted +=
//                OperationService_FixHarvesterContainerDistributionCompleted;
//            await db.CreateTableAsync();
//        }
//        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//        {
//            base.OnCreateView(inflater, container, savedInstanceState);

//            View view = inflater.Inflate(Resource.Layout.harvester_row_dist_inout_layout, container, false);
//            _scanCode = view.FindViewById<EditText>(Resource.Id.harvdist_scan_edittext);
//            _harvesterCode = view.FindViewById<TextView>(Resource.Id.harvdist_harvester_code_holder_txt);
//            _containerCode = view.FindViewById<TextView>(Resource.Id.harvdist_row_code_holder_txt);
//            var containerItxt = view.FindViewById<TextView>(Resource.Id.harvdist_row_holder_txt);
//            containerItxt.Text = "კონტეინერი";
//            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.harvdist_recyclerview);
//            mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.product_receive_header_container);
//            mainContainer.Visibility = ViewStates.Gone;
//            progressBar = view.FindViewById<ProgressBar>(Resource.Id.harvdist_progressBar);


//            _scanCode.AfterTextChanged += CodeEditText_AfterTextChanged;
//            _containerCode.AfterTextChanged += async delegate
//            {
//                if (IsFilled())
//                    await Ready();
//            };
//            _harvesterCode.AfterTextChanged += async delegate
//            {
//                if (IsFilled())
//                    await Ready();
//            };

//            return view;
//        }
//        public override async void OnViewCreated(View view, Bundle savedInstanceState)
//        {
//            base.OnViewCreated(view, savedInstanceState);
//            List<HarvesterContainerDistributionInOut> harvDistLocal = new List<HarvesterContainerDistributionInOut>();
//            await db.CreateTableAsync();
//            harvDistLocal = (await db.selectItems()).Where(x => x.Direction == _direction).OrderByDescending(x => x.Time).ToList();

//            progressBar.Visibility = ViewStates.Gone;
//            mainContainer.Visibility = ViewStates.Visible;
//            _adapter = new HarvesterContainerDistributionRecyclerViewAdapter(harvDistLocal);
//            SetupRecyclerView();


//        }
//        private async Task Ready()
//        {
//            string message = string.Empty;
//            bool f1 = false, f2;
//            harvDist = new HarvesterContainerDistributionInOut()
//            {
//                Time = DateTime.Now,
//                TimeSpecified = true,
//                Direction = _direction,
//                DirectionSpecified = true,
//                HarvesterBarCode = _harvesterCode.Text,
//                HarvesterPersonPostId = null,
//                HarvesterPersonPostIdSpecified = true,
//                Id = Guid.NewGuid().ToString(),
//                IsComplite = false,
//                IsCompliteSpecified = true,
//                UserPersonPostId = 1,
//                CarId=null,
//                CarIdSpecified=true,
//                ContaierBarcode=_containerCode.Text,
//                PointId=4,//დასამატებელია
//                PointIdSpecified=true,
//                UserPersonPostIdSpecified=true



//            };
//            containerClient.FixHarvesterContainerDistributionAsync(harvDist, message);
//            progressDialog.Show();
//            _harvesterCode.Text = string.Empty;
//            _containerCode.Text = string.Empty;



//        }

//        private async void OperationService_FixHarvesterContainerDistributionCompleted(object sender, FixHarvesterContainerDistributionCompletedEventArgs e)
//        {

//            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
//            {
//                harvDist.IsComplite = true;

//                await db.insertUpdateDataAsync(harvDist, false);
//                Toast.MakeText(Activity, "ჩანაწერი წარმატებით ჩაიწერა", ToastLength.Long).Show();

//                _adapter.Add(harvDist);
//            }
//            else if (e.Error is WebException)
//            {
//                Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
//                    .Show();
//                await db.insertUpdateDataAsync(harvDist, false);
//                _adapter.Add(harvDist);
//            }
//            else if (!string.IsNullOrEmpty(e.errorMessage))
//            {
//                Toast.MakeText(Activity, e.errorMessage+ "სცადეთ ახლიდან : HarvesterContDist",
//                    ToastLength.Long).Show();
//            }

//            progressDialog.Dismiss();
        

//    }

//    private bool IsFilled()
//        {
//            if (_harvesterCode.Text.Length >= 10 && _containerCode.Text.Length >= 10)
//                return true;
//            return false;
//        }
//        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
//        {
//            var text = (sender as EditText).Text;
//            try
//            {
//                if (text.StartsWith("CT-"))
//                    InputValidationUtility.ValidateInput(text, "CT");
//                else if (text.StartsWith("PH-"))
//                    InputValidationUtility.ValidateInput(text, "PH");


//            }
//            catch (InvalidCodeException ecx)
//            {
//                Toast.MakeText(Activity, ecx.Message, ToastLength.Short).Show();
//            }

//        }
//        private void SetupRecyclerView()
//        {
//            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
//            recyclerView.SetLayoutManager(layoutManager);
//            recyclerView.NestedScrollingEnabled = false;
//            recyclerView.SetAdapter(_adapter);
//        }

//    }
//}