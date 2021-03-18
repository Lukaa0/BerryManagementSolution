using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Android.App;
using Android.Media;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.Widget;
using Android.Util;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.OperationService;
using Newtonsoft.Json;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.ProduceService;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.StructureService;
using PersonPostModel = BerryManagementAndroidApplication.EmployeeService.PersonPostModel;
using Container = BerryManagementAndroidApplication.StructureService.Container;

namespace BerryManagementAndroidApplication.Fragments
{
    public class ProductFragment : Fragment
    {
        private RecyclerView recyclerView;
        
        private EditText codeEditText;
        private Spinner _containerSpinner;
        private Spinner _harvesterSpinner;
        private Button _confirmBtn;
        private ProgressBar progressBar;
        private RelativeLayout mainContainer;
        private ProductRecyclerViewAdapter productAdapter;

        private BM_Produce_Service produceService = new BM_Produce_Service()
        {
            Url = GlobalVariables.ProduceServiceUrl
        };
        private ProgressDialog progressDialog;
        private BM_Operation_Service operationService = new BM_Operation_Service()
        {
            Url = GlobalVariables.OperationServiceUrl
        };

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private BM_Employee_Service employeeService = new BM_Employee_Service()
        {
            Url = GlobalVariables.EmployeeServiceIrl
        };
        private ProductReceive product;
        private ProductModel productModel;
        private ArrayAdapter<string> _harvesterSpinnerAdapter;
        private ArrayAdapter<string> _containerSpinnerAdapter;
        private List<Container> _containers;
        private List<PersonPostModelLocal> persons;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Activity.Title = "ნაყოფის მიღება";
            progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");
            operationService.FixProductReceiveCompleted -= OperationService_FixProductReceiveCompleted;
            operationService.FixProductReceiveCompleted += OperationService_FixProductReceiveCompleted;
            employeeService.GetHarvesterByHRDForPunishmentCompleted -= EmployeeService_GetHarvesterByHarvesterRowDistributionForPunishmentCompleted;
            employeeService.GetHarvesterByHRDForPunishmentCompleted += EmployeeService_GetHarvesterByHarvesterRowDistributionForPunishmentCompleted;
            structureService.GetContainerForProductRecieveCompleted -= StructureService_GetContainerForProductRecieveCompleted;
            structureService.GetContainerForProductRecieveCompleted += StructureService_GetContainerForProductRecieveCompleted;
            produceService.GetProductModelCompleted -= ProduceService_GetProductModelCompleted;
            produceService.GetProductModelCompleted += ProduceService_GetProductModelCompleted;
        }

        private async void ProduceService_GetProductModelCompleted(object sender, GetProductModelCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {

                productAdapter = new ProductRecyclerViewAdapter(/*e.Result.ToList()*/new List<ProductModel>());
                SetupRecyclerView();
            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ჩაიტვირთა ლოკალური მონაცები ინტერნეტის არ ქონის გამო", ToastLength.Long)
                //    .Show();
                await Alerter.ErrorAlertAsync(Context, "ჩაიტვირთა ლოკალური მონაცები ინტერნეტის არ ქონის გამო");
                var items = await LocalDbService<ProductModel>.Instance.selectItems();
                productAdapter = new ProductRecyclerViewAdapter(/*items*/new List<ProductModel>());
                SetupRecyclerView();
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage + " სცადეთ ახლიდან",
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage + " სცადეთ ახლიდან");
                var items = await LocalDbService<ProductModel>.Instance.selectItems();
                productAdapter = new ProductRecyclerViewAdapter(/*items*/new List<ProductModel>());
                SetupRecyclerView();
            }

            progressBar.Visibility = ViewStates.Gone;
            mainContainer.Visibility = ViewStates.Visible;
        }

        private async void EmployeeService_GetHarvesterByHarvesterRowDistributionForPunishmentCompleted(object sender, GetHarvesterByHRDForPunishmentCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                var _personPostModel = e.Result.ToList();
                persons = new List<PersonPostModelLocal>();
                foreach (var item in _personPostModel)
                {
                    persons.Add(new PersonPostModelLocal(item)
                    {
                        ContentType = "ProductReceive"
                    });
                }
                await LocalDbService<PersonPostModelLocal>.Instance.DeleteByContentType("ProductReceive");
                await LocalDbService<PersonPostModelLocal>.Instance.InsertAllAsnyc(persons);
                _harvesterSpinnerAdapter.AddAll(persons.Select(x => x.Barcode).ToList());
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems()).Where(x=>x.ContentType=="ProductReceive").ToList();
                _harvesterSpinnerAdapter.AddAll(persons.Select(x => x.Barcode).ToList());


            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage);
                _containers = await LocalDbService<Container>.Instance.selectItems();
                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems()).Where(x => x.ContentType == "ProductReceive").ToList();
                _harvesterSpinnerAdapter.AddAll(persons.Select(x => x.Barcode).ToList());

            }
        }

        private async void StructureService_GetContainerForProductRecieveCompleted(object sender, GetContainerForProductRecieveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _containers = e.Result.ToList();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Container_BarCode).ToList());
                await LocalDbService<Container>.Instance.DeleteAll();
                await LocalDbService<Container>.Instance.InsertAllAsnyc(e.Result);
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
                _containers = await LocalDbService<Container>.Instance.selectItems();
                var items = _containers.Select(x => x.Container_BarCode).ToList();
                _containerSpinnerAdapter.AddAll(items);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage);
                _containers = await LocalDbService<Container>.Instance.selectItems();
                var items = _containers.Select(x => x.Container_BarCode).ToList();
                _containerSpinnerAdapter.AddAll(items);
            }
        }

        private async void OperationService_FixProductReceiveCompleted(object sender, FixProductReceiveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                productModel.Product_IsComplete = true;
                productModel.Product_Error = null;
                await Alerter.NotificationAlertAsync(Context, "პროდუქტი მიღებულია!");
                AddItem(productModel);
                _containerSpinnerAdapter.Remove(_containerSpinner.SelectedItem);
            }
            else if (e.Error is WebException)
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();
                //Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
                //    .Show();
                await Alerter.ErrorAlertAsync(Context, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო");
                productModel.Product_IsComplete = false;
                await LocalDbService<ProductModel>.Instance.InsertOrReplaceAsync(productModel);

                //AddItem(productModel);
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();
                productModel.Product_IsComplete = true;
                productModel.Product_Error = e.errorMessage;
                await LocalDbService<ProductModel>.Instance.InsertOrReplaceAsync(productModel);

                //Toast.MakeText(Activity, e.errorMessage+" სცადეთ ახლიდან",
                //    ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage + " სცადეთ ახლიდან");
                //AddItem(productModel);
            }
            Activity.RunOnUiThread(() => progressDialog.Dismiss());
            _containerSpinner.SetSelection(0);
            _harvesterSpinner.SetSelection(0);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.product_main_layout, container, false);
            recyclerView = view.FindViewById<RecyclerView>(Resource.Id.product_recycler_view);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.product_main_progressbar);
            mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.product_receive_header_container);
            codeEditText = view.FindViewById<EditText>(Resource.Id.scan_edittext);
            _containerSpinner = view.FindViewById<Spinner>(Resource.Id.product_container_spinner);
            _harvesterSpinner = view.FindViewById<Spinner>(Resource.Id.product_harveter_spinner);
            _confirmBtn = view.FindViewById<Button>(Resource.Id.product_confirm_btn);
            _confirmBtn.Click += _confirmBtn_Click;
            codeEditText.RequestFocus();
            codeEditText.ShowSoftInputOnFocus = false;
            _confirmBtn.Text = "დადასტურება";
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
           
            return view;
        }

        private async void _confirmBtn_Click(object sender, EventArgs e)
        {
            if (!(_harvesterSpinner.SelectedItemPosition > 0 && _containerSpinner.SelectedItemPosition > 0))
            {
                //Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");
                return;
            }

            await Ready( _containerSpinner.SelectedItem.ToString(), _harvesterSpinner.SelectedItem.ToString());
            _harvesterSpinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            string text = (sender as EditText).Text;
            try
            {

                if (InputValidationUtility.BarcodeLenghtChecker(text))
                {
                    var prefix = InputValidationUtility.BarCodeChecker(text);
                    switch (prefix)
                    {
                        case "CT":
                            var position = _containerSpinnerAdapter.GetPosition(text);
                            if (position > 0)
                                _containerSpinner.SetSelection(position);
                            codeEditText.Text = string.Empty;
                            break;
                        case "PH":
                            var personPost = persons.Find(x => x.Barcode == text);
                            var positionH = personPost != null ? _harvesterSpinnerAdapter.GetPosition(personPost.Barcode) : 0;
                            
                            if (positionH > 0)
                                _harvesterSpinner.SetSelection(positionH);
                            codeEditText.Text = string.Empty;
                            break;
                        default:
                            throw new InvalidCodeException();
                    }

                }
            }

            catch (InvalidCodeException ecx)
            {
                //Toast.MakeText(Context, ecx.Message, ToastLength.Short).Show()
                    Alerter.ErrorAlert(Context, ecx.Message);
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                codeEditText.Text = string.Empty;
            }

        }

        

        

        private async Task Ready(string containerCode,string harvesterCode)
        {
            var user =  (await LocalDbService<UserModel>.Instance.GetFirst());
            var pointId = (await LocalDbService<LocationAuthorizationState>.Instance.GetFirst()).PointID;
            Guid productGuid = Guid.NewGuid();
             product = new ProductReceive()
            {
                ProductReceive_ContainerBarCode = containerCode,
                ProductReceive_DateTime = DateTime.Now,
                ProductReceive_DateTimeSpecified = true,
                ProductReceive_Product_Id = productGuid.ToString(),
                ProductReceive_User_Point_Id=pointId,
                ProductReceive_User_Point_IdSpecified=true,
                ProductReceive_ProcessIsCompliteSpecified = true,
                ProductReceive_User_PersonPost_IdSpecified = true,
                ProductReceive_Id = productGuid.ToString(),
                ProductReceive_HarvesterBarCode = harvesterCode,
                ProductReceive_ProcessIsComplite = false,
                ProductReceive_User_PersonPost_Id = user.User_PersonPost_ID,
                
            };
            productModel = new ProductModel()
            {
                Product_Harvester_FullName = _harvesterSpinner.SelectedItem.ToString(),
                Product_User_FullName = user.User_Person_FirstName + " " + user.User_Person_LastName,
                Product_DateTime = DateTime.Now
            };
            string msg = string.Empty;
            operationService.FixProductReceiveAsync(product, msg);
            progressDialog.Show();
            
        }

        public void AddItem(ProductModel product)
        {
            productAdapter.Add(product);
        }
        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            var errorMessage = string.Empty;
            List<ProductReceive> productsLocal = new List<ProductReceive>();


            InitializeSpinners();
            await CallForSpinnerPopulation();
            produceService.GetProductModelAsync(string.Empty);

        }

        private async Task CallForSpinnerPopulation()
        {

            structureService.GetContainerForProductRecieveAsync(string.Empty);
            employeeService.GetHarvesterByHRDForPunishmentAsync(string.Empty);

        }

        private void InitializeSpinners()
        {
            _harvesterSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _harvesterSpinnerAdapter.Add("აირჩიეთ მკრეფავი");
            _containerSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _containerSpinnerAdapter.Add("აირჩიეთ ყუთი");

            _harvesterSpinner.Adapter = _harvesterSpinnerAdapter;
            _containerSpinner.Adapter = _containerSpinnerAdapter;
        }




        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Context, 1);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(productAdapter);
        }
    }
}