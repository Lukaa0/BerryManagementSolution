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
    public class TakeRowFragment : Fragment
    {
        private Button _confirmButton;
        private Button scanBtn;
        private RecyclerView _recyclerView;

        
        
        private EditText codeEditText;
        private bool _direction;
        private string rowText;
        private List<TakeRowInOut> _items = new List<TakeRowInOut>();
        private TakeRowRecyclerViewAdapter _adapter;
        private TakeRowInOut rowInOut;
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
        private List<TakeRow> _takeRows = new List<TakeRow>();
        private List<TakeRowInOut> takeRowsInOuts = new List<TakeRowInOut>();
        private ArrayAdapter<string> adapter;
        View view;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);

            _direction = Arguments.GetBoolean("direction");
            if (_direction) 
                Activity.Title = "დასაკრეფად გამოცხადება";
            else
                Activity.Title = "დაკრეფილად გამოცხადება";

             progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");


            operationClient.FixTakeRowInOutCompleted -= OperationService_FixTakeRowInOutCompleted;

            operationClient.FixTakeRowInOutCompleted += OperationService_FixTakeRowInOutCompleted;
            operationClient.GetTakeRowsInByPersonPostIDCompleted -= OperationClient_GetTakeRowsInByPersonPostIDCompleted;
            operationClient.GetTakeRowsInByPersonPostIDCompleted += OperationClient_GetTakeRowsInByPersonPostIDCompleted;
            operationClient.GetTakeRowsOutByPersonPostIDCompleted -= OperationClient_GetTakeRowsOutByPersonPostIDCompleted;
            operationClient.GetTakeRowsOutByPersonPostIDCompleted += OperationClient_GetTakeRowsOutByPersonPostIDCompleted;
            structureClient.GetTakeRowInRowCompleted -= StructureClient_GetTakeRowInRowCompleted;

            structureClient.GetTakeRowInRowCompleted += StructureClient_GetTakeRowInRowCompleted;


        }

        private async void StructureClient_GetTakeRowInRowCompleted(object sender, GetTakeRowInRowCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                adapter.Clear();
                adapter.Add("აირჩიეთ რიგი");
                adapter.AddAll(e.Result.Select(x => x.Row_Barkode).ToList());
                await LocalDbService<RowModel>.Instance.DeleteByDirection(_direction);
                await LocalDbService<RowModel>.Instance.InsertAllAsnyc(e.Result);

            }
            else if (e.Error is WebException)
            {
                var items = (await LocalDbService<RowModel>.Instance.selectItems()).Where(x => x.direction == _direction)
                    .Select(x => x.Row_Barkode).ToList();
                adapter = new ArrayAdapter<string>(Activity,
                    Resource.Layout.support_simple_spinner_dropdown_item,items);
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlertAsync(Context, "კავშირის პრობლემა");
                _spinner.Adapter = adapter;
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "სცადეთ ახლიდან " + e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "სცადეთ ახლიდან ");
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                var items = (await LocalDbService<RowModel>.Instance.selectItems()).Where(x => x.direction == _direction)
                    .Select(x => x.Row_Barkode).ToList();
                ArrayAdapter<string> adapter = new ArrayAdapter<string>(Activity,
                    Resource.Layout.support_simple_spinner_dropdown_item, items);
                _spinner.Adapter = adapter;
            }
        }

        private async void OperationClient_GetTakeRowsOutByPersonPostIDCompleted(object sender, GetTakeRowsOutByPersonPostIDCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                await OnSuccess(e.Result);
            }
            else if (e.Error is WebException)
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                await OnWebException();
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                OnError(e.errorMessage);
            }
        }

       

        private void OnError(string errorMessage)
        {
            //Toast.MakeText(Activity, errorMessage,
            //                    ToastLength.Long).Show();
            Alerter.ErrorAlertAsync(Context, errorMessage);
        }

        private async Task OnWebException()
        {
            //Toast.MakeText(Activity, "კავშირი მიუწვდომელია, იტვირთება ბოლო შეტანილი მონაცემები", ToastLength.Long)
            //    .Show();
            Alerter.ErrorAlertAsync(Context, "კავშირი მიუწვდომელია, იტვირთება ბოლო შეტანილი მონაცემები");

            _items = (await LocalDbService<TakeRowInOut>.Instance.selectItems()).Where(x => x.Direction == _direction).ToList();
            
            _adapter.UpdateItems(_items);
        }

        private async Task OnSuccess(TakeRowInOut[] e)
        {
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            _adapter.UpdateItems(e.ToList());
            structureClient.GetTakeRowInRowAsync(_direction, true,user.User_Brigade_ID,true, string.Empty);
        }

        private async void OperationClient_GetTakeRowsInByPersonPostIDCompleted(object sender, GetTakeRowsInByPersonPostIDCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                await OnSuccess(e.Result);
            }
            else if (e.Error is WebException)
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();

                await OnWebException();
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                OnError(e.errorMessage);
            }
        }

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

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            view =  inflater.Inflate(Resource.Layout.takerowInOut_layout, container, false);
            _confirmButton = view.FindViewById<Button>(Resource.Id.row_confirm_btn);
             scanBtn = view.FindViewById<Button>(Resource.Id.row_scan_code_btn);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.row_check_in_recycler);
            codeEditText = view.FindViewById<EditText>(Resource.Id.row_scan_edittext);
            _spinner = view.FindViewById<Spinner>(Resource.Id.takerow_spinner);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            _confirmButton.Click += _confirmButton_Click;
            _confirmButton.Text = "დადასტურება";
            _adapter = new TakeRowRecyclerViewAdapter(_items);
            SetupRecyclerView();
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
                        case "LR":
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
                Alerter.ErrorAlert(Context, ecx.Message);

                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                codeEditText.Text = string.Empty;
            }
        }

        private async void _confirmButton_Click(object sender, EventArgs e)
        {
            if (_spinner.SelectedItemPosition < 1)
            {
                var message = "ინფორმაცია არ არის შეყვანილი";
                //Toast.MakeText(Activity, message, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, message);
                return;
            }
            var text = _spinner.SelectedItem.ToString();
            await Ready(text);
           
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            
            // _items = (await db.selectItems()).Where(x => x.Direction == _direction).OrderByDescending(x=>x.Time).ToList();
            adapter = new ArrayAdapter<string>(Activity, Resource.Layout.support_simple_spinner_dropdown_item);
            adapter.Add("აირჩიეთ რიგი");
            _spinner.Adapter = adapter;
            PopulateSpinner();
        }

        public async void PopulateSpinner()
        {
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            string message = string.Empty;
            structureClient.GetTakeRowInRowAsync(_direction,true,user.User_Brigade_ID ,true, message);
            //if (_direction)
            //    operationClient.GetTakeRowsInByPersonPostIDAsync(null, true, null, true, null, true, null, null, true,
            //        true, user.User_PersonPost_ID, true, message);
            //else
            //    operationClient.GetTakeRowsOutByPersonPostIDAsync(null, true, null, true, null, true, null, null, false,
            //        true, user.User_PersonPost_ID, true, message);
        }

        private async Task Ready(string rowBarcode)
        {
            string message = string.Empty;
            var personPostId = (await LocalDbService<UserModel>.Instance.GetFirst()).User_PersonPost_ID;
             rowInOut = new TakeRowInOut()
            {
                
                Time = DateTime.Now,
                BrigadeId = null,//დასამატებელია
                Direction = _direction,
                Id = Guid.NewGuid().ToString(),
                IsComplete = false,
                RowBarCode = rowBarcode,
                PersonPostId = personPostId,
                BrigadeIdSpecified=true,
                DirectionSpecified=true,
                IsCompleteSpecified=true,
                PersonPostIdSpecified=true,
                RowId=null,
                RowIdSpecified=true,
                TimeSpecified=true
                


            };
            
                operationClient.FixTakeRowInOutAsync(rowInOut, message);
            

            progressDialog.Show();
            
            
        }

        private async void OperationService_FixTakeRowInOutCompleted(object sender, FixTakeRowInOutCompletedEventArgs e)
        {
            if (e.Error == null&& string.IsNullOrEmpty(e.errorMessage))
            {
                rowInOut.IsComplete = true;
                rowInOut.Error = null;
                Alerter.NotificationAlert(Context,"ჩანაწერი წარმატებით ჩაიწერა");
                //Alerter.ErrorAlertAsync(Context, "ჩანაწერი წარმატებით ჩაიწერა");
                _adapter.Add(rowInOut);
                string obj = _spinner.SelectedItem.ToString();
                adapter.Remove(obj);
                _spinner.Adapter = adapter;



            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
                //    .Show();
                Alerter.ErrorAlertAsync(Context, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო");
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                rowInOut.IsComplete = false;
                
                await LocalDbService<TakeRowInOut>.Instance.InsertOrReplaceAsync(rowInOut);
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, "სცადეთ ახლიდან "+e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "სცადეთ ახლიდან ");
                rowInOut.IsComplete = true;
                rowInOut.Error = e.errorMessage;
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();

                await LocalDbService<TakeRowInOut>.Instance.InsertOrReplaceAsync(rowInOut);
            }
            progressDialog.Dismiss();
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
            _spinner.SetSelection(0);

        }

        
        
        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Activity, 1);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_adapter);
        }
    }
} 