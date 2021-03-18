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
    public class ProductQualityFragment : Fragment
    {
        private Button _confirmButton;
        private Button scanBtn;
        private RecyclerView _recyclerView;

        
        
        private EditText codeEditText;
        private bool _direction;
        private string rowText;
        private List<ContainerMoveInOut> _items = new List<ContainerMoveInOut>();
        private PalleteAndContainerRecyclerViewAdapter _adapter;
        private ContainerMoveInOut containerQualityModel;
        private ProgressDialog progressDialog;
        private Spinner _spinner;
        private BM_Operation_Service operationClient=new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };
        private BM_Structure_Service structureClient = new BM_Structure_Service()
        {
            Url=GlobalVariables.StructureServiceUrl
        };
        private List<Container> _takeRows = new List<Container>();
        private List<Container> takeRowsInOuts = new List<Container>();
        private ArrayAdapter<string> adapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);

            
                Activity.Title = "ხარისხის მინიჭება";

             progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");


            operationClient.FixProductQualityCompleted -= OperationService_FixProductQualityCompleted;
            operationClient.FixProductQualityCompleted += OperationService_FixProductQualityCompleted;

            operationClient.GetContainerForQualityCompleted -= StructureClient_GetContainerForQualityCompleted;
            operationClient.GetContainerForQualityCompleted += StructureClient_GetContainerForQualityCompleted;

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.productQuality_layout, container, false);
            _confirmButton = view.FindViewById<Button>(Resource.Id.quality_confirm_btn);
            scanBtn = view.FindViewById<Button>(Resource.Id.quality_scan_btn);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.quality_recyler);
            codeEditText = view.FindViewById<EditText>(Resource.Id.quality_editText);
            _spinner = view.FindViewById<Spinner>(Resource.Id.spinner_container);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            _confirmButton.Click += _confirmButton_Click;
            _confirmButton.Text = "დადასტურება";
            _adapter = new PalleteAndContainerRecyclerViewAdapter(_items);
            SetupRecyclerView();
            return view;
        }

        private async void StructureClient_GetContainerForQualityCompleted(object sender, GetContainerForQualityCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                adapter.AddAll(e.Result.Select(x => x.ProductPack_Container_BarCode).ToList());
               

            }
            else if (e.Error is WebException)
            {
                
              
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
                _spinner.Adapter = adapter;
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "სცადეთ ახლიდან " + e.errorMessage,
                //    ToastLength.Long).Show();
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlertAsync(Context, "სცადეთ ახლიდან " + e.errorMessage);

            }
        }

        

       

        

      

       

        //private async void OperationClient_GetTakeRowsInByPersonPostIDCompleted(object sender, GetTakeRowsInByPersonPostIDCompletedEventArgs e)
        //{
        //    if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
        //    {
        //        await OnSuccess(e.Result);
        //    }
        //    else if (e.Error is WebException)
        //    {
        //        var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
        //        player.Start();
        //        await OnWebException();
        //    }
        //    else if (!string.IsNullOrEmpty(e.errorMessage))
        //    {
        //        var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
        //        player.Start();
        //        OnError(e.errorMessage);
        //    }
        //}

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            base.OnOptionsItemSelected(item);
            switch (item.ItemId)
            {
                case Resource.Id.refresh_toolbar:
                {
                    //RefreshData();
                    break;
                }

            }

            return true;
        }

        //private void RefreshData()
        //{
        //    string message = "მონაცემები წარმატებით განახლდა";
        //    var service = ServiceClient.Instance.OperationService;
            
        //    service.GetTakeRowInOutsAsync(message);
        //    service.GetTakeRowInOutsCompleted += OperatioService_GetTakeRowInOutsCompleted;

        //}

       

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
                        case "CT":
                            var position = adapter.GetPosition(text);
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
            _spinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            adapter = new ArrayAdapter<string>(Activity, Resource.Layout.support_simple_spinner_dropdown_item);
            adapter.Add("აირჩიეთ ყუთი");
            _spinner.Adapter = adapter;
            string message = string.Empty;
            operationClient.GetContainerForQualityAsync( message);
            
        }

        

        private async Task Ready(string containerQuality)
        {
            string message = string.Empty;
            
             containerQualityModel = new ContainerMoveInOut()
            {
                
                ContainerBarCode=containerQuality,
                
            };
            
           operationClient.FixProductQualityAsync(containerQuality, message);
            

            progressDialog.Show();
            
            
        }

        private async void OperationService_FixProductQualityCompleted(object sender, FixProductQualityCompletedEventArgs e)
        {
            if (e.Error == null&& string.IsNullOrEmpty(e.errorMessage))
            {
                containerQualityModel.IsComplete = true;
                containerQualityModel.Error = null;
                Toast.MakeText(Activity, "ჩანაწერი წარმატებით ჩაიწერა", ToastLength.Long).Show();
                
                _adapter.Add(containerQualityModel);
               

            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
                //    .Show();
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlertAsync(Context, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო");
                containerQualityModel.IsComplete = false;
                
               
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "სცადეთ ახლიდან "+e.errorMessage,
                //    ToastLength.Long).Show();
                containerQualityModel.IsComplete = true;
                containerQualityModel.Error = e.errorMessage;
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlertAsync(Context, "სცადეთ ახლიდან " + e.errorMessage);


            }
            progressDialog.Dismiss();
        }

        
        
        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Activity, 1);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_adapter);
        }
    }
} 