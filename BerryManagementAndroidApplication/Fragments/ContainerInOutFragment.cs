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
    public class ContainerInOutFragment : Fragment,IOnDialogDone,IOnDialogItemClick{ 
     private RecyclerView _recylcerContainerMoves;
    private EditText codeEditText;
        private Spinner _containerSpinner;
        private Button _confirmBtn;
        private Button _tempConfirmBtn;
        private RecyclerView _tempRecyclerView;
        private ProgressBar progressBar;
        private RelativeLayout mainContainer;
        private PalleteAndContainerRecyclerViewAdapter _palleteAndContainerAdapter;
        private bool _direction;
        private ProgressDialog progressDialog;
        private RedItemDialog _redItemDialog;
        private ContainerMoveInOut container;
        private BM_Operation_Service operationService;

        public long pointId;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private ArrayAdapter<string> _containerSpinnerAdapter;
        private List<ContainerInOutContainerModel> _containers;
        private PalleteAndContainerRecyclerViewAdapter _tempRecyclerAdapter;
        private TransportWaybill _transportWayBill;
        private List<ContainerMoveInOut> containerMoveInOutMainListItem;
        private string title;
        private bool isOnRetry;

        public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        _direction = Arguments.GetBoolean("container-direction");
        if (_direction)
            title = "დატვირთვა";
        else
        title = "ჩამოტვირთვა";

            Activity.Title = title;
            progressDialog = new ProgressDialog(Activity);
        progressDialog.SetTitle("გთხოვთ მოიცადოთ");

            operationService = new BM_Operation_Service()
            {
                Url=GlobalVariables.OperationServiceUrl
            };
        
        operationService.FixContainerMoveCompleted -= OperationService_FixContainerMoveCompleted;
        operationService.FixContainerMoveCompleted += OperationService_FixContainerMoveCompleted;
        operationService.InsertContainerMoveCompleted += OperationService_InsertContainerMoveCompleted;
            operationService.InsertContainerMoveCompleted += OperationService_InsertContainerMoveCompleted;
        operationService.GetContainerMoveInOutCompleted -= OperationService_GetContainerMoveInOutCompleted;
            operationService.GetContainerMoveInOutCompleted += OperationService_GetContainerMoveInOutCompleted;
        structureService.GetContainersForContainerLocationsCompleted -= StructureService_GetContainersForContainerLocationsCompleted;
        structureService.GetContainersForContainerLocationsCompleted += StructureService_GetContainersForContainerLocationsCompleted;
            operationService.GetCountForContainerMoveCompleted -= OperationService_GetCountForContainerMoveCompleted;
            operationService.GetCountForContainerMoveCompleted += OperationService_GetCountForContainerMoveCompleted;

        }

        private void OperationService_InsertContainerMoveCompleted(object sender, InsertContainerMoveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                Toast.MakeText(Activity,"ჩანაწერი ჩაიწერა",ToastLength.Long).Show();
                
                _palleteAndContainerAdapter.items.Clear();
                _palleteAndContainerAdapter.items.AddRange(containerMoveInOutMainListItem);
                _palleteAndContainerAdapter.NotifyDataSetChanged();
            }
            else if(e.Error is WebException)
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
                Alerter.ErrorAlert(Context, "ინტერნეტთან კავშირი შეუძლებელია");
            else
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlert(Context, e.errorMessage);


        }

        private async void OperationService_GetCountForContainerMoveCompleted(object sender, GetCountForContainerMoveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                Activity.Title = e.GetCountForContainerMoveResult + "| " + title;
            }
            else if (e.Error is WebException)
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();

               
                //Toast.MakeText(Activity, "ინტერნეტის პრობლემა", ToastLength.Long).Show()
                     Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }
        //მთავარი ლისთის შევსება
        private async void OperationService_GetContainerMoveInOutCompleted(object sender, GetContainerMoveInOutCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(/*e.Result.ToList()*/ new List<ContainerMoveInOut> ());
                SetupRecyclerView(_recylcerContainerMoves,_palleteAndContainerAdapter);
            }
            else if (e.Error is WebException)
            {
               var items =  await LocalDbService<ContainerMoveInOut>.Instance.selectItems();

                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(/*items*/new List<ContainerMoveInOut>());
                SetupRecyclerView(_recylcerContainerMoves, _palleteAndContainerAdapter);
                //Toast.MakeText(Activity, "მონაცემები ჩამოიტვირთა ლოკალურად",ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();

                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(/*items*/ new List<ContainerMoveInOut>());
                SetupRecyclerView(_recylcerContainerMoves, _palleteAndContainerAdapter);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }

        //სპინერის შევსება
        private async void StructureService_GetContainersForContainerLocationsCompleted(object sender, GetContainersForContainerLocationsCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {

                _containers = new List<ContainerInOutContainerModel>();
                if(e.Result.Count() != 0)
                {
                    foreach (var item in e.Result)
                    {
                        _containers.Add(new ContainerInOutContainerModel(item)
                        {
                            Direction = _direction
                        }); ;
                    }
              
                    
                    
                    
                    //_containers.AddRange(new ContainerInOutContainerModel(e.Result));
                    //await LocalDbService<ContainerInOutContainerModel>.Instance.DeleteByDirection(_direction);
                    //await LocalDbService<ContainerInOutContainerModel>.Instance.InsertAllAsnyc(_containers);
                    _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
                }
                
            }
            else if (e.Error is WebException)
            {
                _containers = await LocalDbService<ContainerInOutContainerModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {

                _containers = await LocalDbService<ContainerInOutContainerModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    {
        base.OnCreateView(inflater, container, savedInstanceState);
        View view = inflater.Inflate(Resource.Layout.containerinout_main_layout, container, false);
        _recylcerContainerMoves = view.FindViewById<RecyclerView>(Resource.Id.containerinout_recycler_view);
        progressBar = view.FindViewById<ProgressBar>(Resource.Id.containerinout_main_progressbar);
        mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.containerinout_receive_header_container);
        codeEditText = view.FindViewById<EditText>(Resource.Id.containerinout_scan_edittext);
        _containerSpinner = view.FindViewById<Spinner>(Resource.Id.containerinout_spinner);
        _confirmBtn = view.FindViewById<Button>(Resource.Id.containerinout_operation_confirm);
        _tempConfirmBtn = view.FindViewById<Button>(Resource.Id.containerinout_spinner_confirm);
           

            _confirmBtn.Text = Activity.Title;
        _tempConfirmBtn.Text = "დამატება";
        _tempRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.containerinout_temp_recylcer);
            _confirmBtn.Visibility = ViewStates.Gone;
            _tempConfirmBtn.Click += _tempConfirmBtn_Click;
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
        TransportInputDialogFragment fragment = new TransportInputDialogFragment();
            Bundle data = new Bundle();
            data.PutBoolean("direction", _direction);
            fragment.Arguments = data;
            //_confirmBtn.Click += _confirmBtn_Click;
            fragment.SetTargetFragment(this, 0);
        fragment.Show(FragmentManager,"dialogtransport");
            codeEditText.RequestFocus();
            codeEditText.ShowSoftInputOnFocus = false;
            return view;
    }
        public async void ContainerMove(string ContainerBarCode)
        {
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            containerMoveInOutMainListItem = new List<ContainerMoveInOut>();

            var containerMove = new ContainerMove()
            {
                ContainerMove_Car_Point_Id = _transportWayBill.TransportWaybill_Car_Point_Id,
                ContainerMove_Car_Point_IdSpecified = true,
                ContainerMove_Container_BarCode = ContainerBarCode,
                ContainerMove_IdSpecified = true,
                ContainerMove_In_ContainerMoveInOut_Id = Guid.NewGuid().ToString(),
                ContainerMove_In_DateTime = DateTime.Now,
                ContainerMove_In_DateTimeSpecified = true,
                ContainerMove_In_User_PersonPost_Id = user.User_PersonPost_ID,
                ContainerMove_In_User_PersonPost_IdSpecified = true,
                ContainerMove_In_User_Point_Id = pointId,
                ContainerMove_In_User_Point_IdSpecified = true,
                ContainerMove_Out_ContainerMoveInOut_Id = Guid.NewGuid().ToString(),
                ContainerMove_Out_DateTime = DateTime.Now,
                ContainerMove_Out_DateTimeSpecified = true,
                ContainerMove_Out_User_PersonPost_Id = user.User_PersonPost_ID,
                ContainerMove_Out_User_PersonPost_IdSpecified = true,
                ContainerMove_Out_User_Point_Id = pointId,
                ContainerMove_Out_User_Point_IdSpecified = true,
                ContainerMove_TransportWaybill_Id = _transportWayBill.TransportWaybill_Id,
                ContainerMove_TransportWaybill_IdSpecified = true


            };
            container = new ContainerMoveInOut()
            {
                ContainerBarCode = containerMove.ContainerMove_Container_BarCode,
                Id = containerMove.ContainerMove_Id,
                Time = containerMove.ContainerMove_In_DateTime

            };
            //containerMoveInOutMainListItem.Add(container);
            operationService.FixContainerMoveAsync(containerMove, _direction, true, string.Empty);
        }

        //private async void _confirmBtn_Click(object sender, EventArgs e)
        //{
        //    var items = _tempRecyclerAdapter.containerCodes;
        //    var user = await LocalDbService<UserModel>.Instance.GetFirst();
        //    //var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
        //    containerMoveInOutMainListItem = new List<ContainerMoveInOut>();

        //    {
        //        foreach (var item in items)
        //    {

        //            var containerMove = new ContainerMove ()
        //            {
        //                ContainerMove_Car_Point_Id = _transportWayBill.TransportWaybill_Car_Point_Id,
        //                ContainerMove_Car_Point_IdSpecified = true,
        //                ContainerMove_Container_BarCode = item,
        //                ContainerMove_IdSpecified=true,
        //                ContainerMove_In_ContainerMoveInOut_Id=Guid.NewGuid().ToString(),
        //                ContainerMove_In_DateTime=DateTime.Now,
        //                ContainerMove_In_DateTimeSpecified=true,
        //                ContainerMove_In_User_PersonPost_Id=user.User_PersonPost_ID,
        //                ContainerMove_In_User_PersonPost_IdSpecified=true,
        //                ContainerMove_In_User_Point_Id= pointId,
        //                ContainerMove_In_User_Point_IdSpecified=true,
        //                ContainerMove_Out_ContainerMoveInOut_Id=Guid.NewGuid().ToString(),
        //                ContainerMove_Out_DateTime=DateTime.Now,
        //                ContainerMove_Out_DateTimeSpecified=true,
        //                ContainerMove_Out_User_PersonPost_Id=user.User_PersonPost_ID,
        //                ContainerMove_Out_User_PersonPost_IdSpecified=true,
        //                ContainerMove_Out_User_Point_Id= pointId,
        //                ContainerMove_Out_User_Point_IdSpecified=true,
        //                ContainerMove_TransportWaybill_Id= _transportWayBill.TransportWaybill_Id,
        //                ContainerMove_TransportWaybill_IdSpecified=true


        //            };
        //            container = new ContainerMoveInOut()
        //            {
        //                ContainerBarCode = containerMove.ContainerMove_Container_BarCode,
        //                Id = containerMove.ContainerMove_Id,
        //                Time=containerMove.ContainerMove_In_DateTime

        //            };
        //        containerMoveInOutMainListItem.Add(container);
        //        operationService.FixContainerMoveAsync(containerMove,_direction,true, string.Empty);
        //    }

        //    }
        //}

        private  void _tempConfirmBtn_Click(object sender, EventArgs e)
        {
            if (_containerSpinner.SelectedItemPosition < 1)
            {
                Alerter.ErrorAlert(Context, "მონაცემები არ არის შეყვალინი");

                return;
            }
            var containerBarcode = _containerSpinner.SelectedItem.ToString();
            _tempRecyclerAdapter.Add(containerBarcode);
            _containerSpinnerAdapter.Remove(containerBarcode);
            //Activity.Title = _tempRecyclerAdapter.containerCodes.Count + "| " + title;
            ContainerMove(containerBarcode);
            _containerSpinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        private  void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
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

    }

   


        

        private async void OperationService_FixContainerMoveCompleted(object sender, FixContainerMoveCompletedEventArgs e)
        {

            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                container.IsComplete = true;
                container.Error = null;
                if (isOnRetry)
                {
                    await LocalDbService<ContainerMoveInOut>.Instance.DeleteAsync(container);
                    _palleteAndContainerAdapter.items.RemoveAll(x => x.ContainerBarCode == container.ContainerBarCode);
                    _palleteAndContainerAdapter.NotifyDataSetChanged();
                }
                else
                {
                    _palleteAndContainerAdapter.items.Clear();
                    _palleteAndContainerAdapter.items.AddRange(containerMoveInOutMainListItem);
                    _palleteAndContainerAdapter.NotifyDataSetChanged();

                    AddItem(container);
                }
                string errorMessage = null;
                int result = 0;
                bool res = true;
                operationService.GetCountForContainerMove(_transportWayBill.TransportWaybill_Id, true, _direction, true, ref errorMessage, out result, out res);
                Activity.Title = result + "| " + title;
                if(!_direction && result == 0)
                {
                    //Toast.MakeText(Activity, "ბოლო ჩანაწერი", ToastLength.Long).Show();
                    Alerter.NotificationAlert(Context, "ჩამოტვირთვა წარმატებით დასრულდა.");
                }

                Toast.MakeText(Activity, "ოპერაცია წარმატებით შესრულდა", ToastLength.Long).Show();
                isOnRetry = false;
            }
            else if (e.Error is WebException)
            {
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                //Toast.MakeText(Activity, "მონაცემი შეინახა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long)
                    //.Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
                container.IsComplete = false;
                await LocalDbService<ContainerMoveInOut>.Instance.InsertOrReplaceAsync(container);
                if(!isOnRetry)
                    //AddItem(container);
                isOnRetry = false;
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //container.Error = e.errorMessage;
                //Context context = App.Context;
                // await Alerter.ErrorAlertAsync(App.Context, e.errorMessage);
                //Toast.MakeText(Activity, "დაიფქსირდა შეცდომა, სცადეთ ახლიდან : ContainerMoveInOutFragment ("+ e.errorMessage+")",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "დაიფქსირდა შეცდომა, სცადეთ ახლიდან : ContainerMoveInOutFragment (" + e.errorMessage + ")");
                await LocalDbService<ContainerMoveInOut>.Instance.InsertOrReplaceAsync(container);
                if (!isOnRetry)
                    //AddItem(container);
                isOnRetry = false;
            }
                Activity.RunOnUiThread(() => progressDialog.Dismiss());   
        }

        public void AddItem(ContainerMoveInOut container)
    {
        _palleteAndContainerAdapter.Add(container);
    }
    public override async void OnViewCreated(View view, Bundle savedInstanceState)
    {
        base.OnViewCreated(view, savedInstanceState);
        progressBar.Visibility = ViewStates.Gone;
        mainContainer.Visibility = ViewStates.Visible;
        _tempRecyclerAdapter = new PalleteAndContainerRecyclerViewAdapter(new List<string>());
        //SetupRecyclerView(_tempRecyclerView, _tempRecyclerAdapter);
        //    _tempRecyclerAdapter.ItemClick += _tempRecyclerAdapter_ItemClick;
        InitializeSpinner();
       
           
        var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
        //structureService.GetContainersForContainerLocationsAsync(_transportWayBill.TransportWaybill_Car_Point_Id, true,_direction,true, "CT", string.Empty);

    }

        private void _tempRecyclerAdapter_ItemClick(object sender, ContainerInOutRecyclerViewAdapterClickEventArgs e)
        {
            _tempRecyclerAdapter.containerCodes.RemoveAt(e.Position);
            _tempRecyclerAdapter.NotifyItemRemoved(e.Position);
        }

        private void InitializeSpinner()
        {
            _containerSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _containerSpinnerAdapter.Add("აირჩიეთ ყუთი");
            _containerSpinner.Adapter = _containerSpinnerAdapter;
        }
        private void ContainerInOutAdapter_ItemClick(object sender, ContainerInOutRecyclerViewAdapterClickEventArgs e)
        {
            var position = e.Position;
            Bundle data = new Bundle();
            data.PutInt("position", position);
            _redItemDialog = new RedItemDialog();
            _redItemDialog.Arguments = data;
            _redItemDialog.SetTargetFragment(this, 0);
            _redItemDialog.Show(FragmentManager,"reditemdiaog");

        }

        

        
        



    private void SetupRecyclerView(RecyclerView recyclerView,RecyclerView.Adapter adapter)
    {
        LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
        recyclerView.SetLayoutManager(layoutManager);
        recyclerView.SetAdapter(adapter);
    }

        public async Task OnDone(TransportWaybill transport)
        {
            
            _transportWayBill = transport;
            pointId = (await LocalDbService<LocationAuthorizationState>.Instance.GetFirst()).PointID;
            if (_direction) {
                structureService.GetContainersForContainerLocationsAsync(pointId, true, _direction, true, "CT", string.Empty);
                operationService.GetContainerMoveInOutAsync(_direction, true, pointId, true, string.Empty);
            }
            else
            {
                structureService.GetContainersForContainerLocationsAsync(_transportWayBill.TransportWaybill_Car_Point_Id, true, _direction, true, "CT", string.Empty);
                operationService.GetContainerMoveInOutAsync(_direction, true, _transportWayBill.TransportWaybill_Car_Point_Id, true, string.Empty);
            }
            operationService.GetCountForContainerMoveAsync(_transportWayBill.TransportWaybill_Id, true, _direction, true, string.Empty);

        }

        public void OnRetry(int position)
        {
            var retryContainer = _palleteAndContainerAdapter.GetItem(position);
            string msg = string.Empty;
            var containerMove = new ContainerMove()
            {
                ContainerMove_Car_Point_Id = retryContainer.Point_Car_Id.Value,
                ContainerMove_Car_Point_IdSpecified = true,
                ContainerMove_Container_BarCode = retryContainer.ContainerBarCode,
                ContainerMove_IdSpecified = true,
                ContainerMove_In_ContainerMoveInOut_Id = retryContainer.ContainerMoveInOut_Id,
                ContainerMove_In_DateTime = retryContainer.Time,
                ContainerMove_In_DateTimeSpecified = true,
                ContainerMove_In_User_PersonPost_Id = retryContainer.PersonPostId,
                ContainerMove_In_User_PersonPost_IdSpecified = true,
                ContainerMove_In_User_Point_Id = retryContainer.Point_Id.Value,
                ContainerMove_In_User_Point_IdSpecified = true,
                ContainerMove_Out_ContainerMoveInOut_Id = Guid.NewGuid().ToString(),
                ContainerMove_Out_DateTime = DateTime.Now,
                ContainerMove_Out_DateTimeSpecified = true,
                ContainerMove_Out_User_PersonPost_Id = retryContainer.PersonPostId,
                ContainerMove_Out_User_PersonPost_IdSpecified = true,
                ContainerMove_Out_User_Point_Id = retryContainer.Point_Id,
                ContainerMove_Out_User_Point_IdSpecified = true,
                ContainerMove_TransportWaybill_Id = retryContainer.ContainerMoveInOut_TransportWaybill_Id,
                ContainerMove_TransportWaybill_IdSpecified = true

            };
            container = new ContainerMoveInOut()
            {
                ContainerBarCode = containerMove.ContainerMove_Container_BarCode,
                Id = containerMove.ContainerMove_Id,
                Time = containerMove.ContainerMove_In_DateTime

            };
            isOnRetry = true;
            operationService.FixContainerMoveCompleted -= OperationService_FixContainerMoveCompleted;
            operationService.FixContainerMoveCompleted += OperationService_FixContainerMoveCompleted;
            operationService.FixContainerMoveAsync(containerMove, _direction,true, msg);

        }

        public void OnDelete(int position)
        {
            var deleteContainer = _palleteAndContainerAdapter.GetItem(position);
            _palleteAndContainerAdapter.DeleteContainer(deleteContainer);

        }

        public Task OnDone(SalePointsModel carpointID)
        {
            throw new NotImplementedException();
        }

        public Task OnDone(string palet)
        {
            throw new NotImplementedException();
        }

        public Task OnDone(CompanyeModel palet)
        {
            throw new NotImplementedException();
        }
    }
}