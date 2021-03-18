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
    public class ContainerPackFragment : Fragment,IOnDialogDone,IOnDialogItemClick{ 
     private RecyclerView _recylcerContainerMoves;
    private EditText codeEditText;
        private Spinner _containerSpinner;
        private Button _confirmBtn;
        private Button _allConfirmBtn;
        private Button _tempConfirmBtn;
        private RecyclerView _tempRecyclerView;
        private ProgressBar progressBar;
        private RelativeLayout mainContainer;
        private ContainerPackRecyclerViewAdapter _containerPackAdapter;
        private bool _direction;
        private ProgressDialog progressDialog;
        private RedItemDialog _redItemDialog;
        private ContainerPackModel container;
        private BM_Operation_Service operationService;

        public long pointId;

        public string paletBarCode;
        public LocationAuthorizationState location;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };
        private ArrayAdapter<string> _containerSpinnerAdapter;
        private List<ContainerPackLocalModel> _containers;
        private ContainerPackRecyclerViewAdapter _tempRecyclerAdapter;
        private SalePointsModel _saleCarPoint;
        private List<ContainerPackModel> containerPackMainListItem;
        private string title;



        public override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        _direction = Arguments.GetBoolean("container-direction");
        if (_direction)
            title = "პალეტის შექმნა";
        else
        title = "პალეტის შექმნა";

            Activity.Title = title;
            progressDialog = new ProgressDialog(Activity);
        progressDialog.SetTitle("გთხოვთ მოიცადოთ");

        operationService = new BM_Operation_Service()
        {
            Url=GlobalVariables.OperationServiceUrl
        };
        
        operationService.FixContainerPackCompleted -= OperationService_FixContainerPackCompleted;
        operationService.FixContainerPackCompleted += OperationService_FixContainerPackCompleted;
        //operationService.InsertContainerMoveCompleted += OperationService_InsertContainerMoveCompleted;
        //operationService.InsertContainerMoveCompleted += OperationService_InsertContainerMoveCompleted;
        operationService.GetContainerPackModelCompleted -= OperationService_GetContainerPackModelCompleted;
        operationService.GetContainerPackModelCompleted += OperationService_GetContainerPackModelCompleted;

        operationService.GetContainerPackByPaletteCompleted -= OperationService_GetContainerPackByPaletteCompleted;
        operationService.GetContainerPackByPaletteCompleted += OperationService_GetContainerPackByPaletteCompleted;

        structureService.GetContainersForContainerPackCompleted -= StructureService_GetContainersForContainerPackCompleted;
        structureService.GetContainersForContainerPackCompleted += StructureService_GetContainersForContainerPackCompleted;


        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.containerpack_main_layout, container, false);
            _recylcerContainerMoves = view.FindViewById<RecyclerView>(Resource.Id.containerinout_recycler_view);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.sale_main_progressbar);
            mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.sale_receive_header_container);
            codeEditText = view.FindViewById<EditText>(Resource.Id.sale_scan_edittext);
            _containerSpinner = view.FindViewById<Spinner>(Resource.Id.sale_spinner);
            _confirmBtn = view.FindViewById<Button>(Resource.Id.sale_operation_confirm);
            _allConfirmBtn = view.FindViewById<Button>(Resource.Id.sale_allOperation_confirm);
            _tempConfirmBtn = view.FindViewById<Button>(Resource.Id.sale_spinner_confirm);
            _tempRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.sale_temp_recylcer);
            _confirmBtn.Text = "დადასტურება";
            _allConfirmBtn.Text = Activity.Title;
            _tempConfirmBtn.Text = "დამატება";
            _confirmBtn.Visibility = ViewStates.Gone;
            _tempRecyclerView.Visibility = ViewStates.Gone;
            
            _tempConfirmBtn.Click += _tempConfirmBtn_Click;
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            //_confirmBtn.Click += _confirmBtn_Click;
            _allConfirmBtn.Click += _allConfirmBtn_Click;

            TransportPaletInputDialogFragment fragment = new TransportPaletInputDialogFragment();
            
            fragment.SetTargetFragment(this, 0);
            fragment.Show(FragmentManager, "dialogtransport");
            codeEditText.RequestFocus();
            codeEditText.ShowSoftInputOnFocus = false;
            return view;
        }

        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            progressBar.Visibility = ViewStates.Gone;
            mainContainer.Visibility = ViewStates.Visible;
            _tempRecyclerAdapter = new ContainerPackRecyclerViewAdapter(new List<string>());
            SetupRecyclerView(_tempRecyclerView, _tempRecyclerAdapter);
            //_tempRecyclerAdapter.ItemClick += _tempRecyclerAdapter_ItemClick;
            InitializeSpinner();
        }

        public void OnDelete(int position)
        {
            var deleteContainer = _containerPackAdapter.GetItem(position);
            _containerPackAdapter.DeleteContainer(deleteContainer);
        }

       
        //private void OperationService_InsertContainerMoveCompleted(object sender, InsertContainerMoveCompletedEventArgs e)
        //{
        //    if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
        //    {
        //        Toast.MakeText(Activity,"ჩანაწერი ჩაიწერა",ToastLength.Long).Show();
        //        _containerPackAdapter.items.Clear();
        //        _containerPackAdapter.items.AddRange(containerPackMainListItem);
        //        _containerPackAdapter.NotifyDataSetChanged();
        //    }
        //    else if(e.Error is WebException)
        //        Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
        //    else
        //        Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();


        //}

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
                //_containerPackAdapter = new ContainerPackRecyclerViewAdapter(e.Result.ToList());
                //SetupRecyclerView(_recylcerContainerMoves,_containerPackAdapter);
            }
            else if (e.Error is WebException)
            {
                //var items =  await LocalDbService<ContainerPackLocalModel>.Instance.selectItems();
                // var container = new List<ContainerPackModel>();
                // foreach (var item in items)
                // {

                //     container.Add(new ContainerPackModel(item)
                //     {
                //         Direction = _direction
                //     });

                // }
                // _containerPackAdapter = new ContainerPackRecyclerViewAdapter(container);
                // SetupRecyclerView(_recylcerContainerMoves, _containerPackAdapter);
                //Toast.MakeText(Activity, "მონაცემები ჩამოიტვირთა ლოკალურად", ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, "მონაცემები ჩამოიტვირთა ლოკალურად");

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
                //SetupRecyclerView(_recylcerContainerMoves, _containerPackAdapter);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }

        //სპინერის შევსება
        private async void StructureService_GetContainersForContainerPackCompleted(object sender, GetContainersForContainerPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _containers = new List<ContainerPackLocalModel>();
                foreach (var item in e.Result)
                {
                    _containers.Add(new ContainerPackLocalModel(item)
                    {
                        Barcode = item.ProductPack_Container_BarCode,
                        Direction = _direction
                    });
                }
                //await LocalDbService<ContainerPackLocalModel>.Instance.DeleteByDirection(_direction);
                //await LocalDbService<ContainerPackLocalModel>.Instance.InsertAllAsnyc(_containers);
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია", ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
                //_containers = await LocalDbService<ContainerPackLocalModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //_containers = await LocalDbService<ContainerPackLocalModel>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
        }


        private void SetupRecyclerView(RecyclerView recyclerView, RecyclerView.Adapter adapter)
        {
            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
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

        private void SaleAdapter_ItemClick(object sender, ContainerPackRecyclerViewAdapterClickEventArgs e)
        {
            var position = e.Position;
            Bundle data = new Bundle();
            data.PutInt("position", position);
            _redItemDialog = new RedItemDialog();
            _redItemDialog.Arguments = data;
            _redItemDialog.SetTargetFragment(this, 0);
            _redItemDialog.Show(FragmentManager, "reditemdiaog");

        }

        private void _tempConfirmBtn_Click(object sender, EventArgs e)
        {
            if (_containerSpinner.SelectedItemPosition < 1)
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();

                return;
            }

            var containerBarcode = _containerSpinner.SelectedItem.ToString();
            //_containerSpinnerAdapter.Remove(containerBarcode);
            //_tempRecyclerAdapter.Add(containerBarcode);
            //Activity.Title = _tempRecyclerAdapter.containerCodes.Count + "| " + title ;
            ContainerPack(containerBarcode);
            _containerSpinner.SetSelection(0);
            codeEditText.Focusable = true;
            codeEditText.RequestFocus();
            codeEditText.Text = string.Empty;
        }

        public void AddItem(ContainerPackModel container)
        {
            _containerPackAdapter.Add(container);
        }

        //private void _tempRecyclerAdapter_ItemClick(object sender, ContainerPackRecyclerViewAdapterClickEventArgs e)
        //{
        //    string barcode = _tempRecyclerAdapter.containerCodes.ElementAt(e.Position);
        //    _tempRecyclerAdapter.containerCodes.RemoveAt(e.Position);
            
        //    _containerSpinnerAdapter.Add(barcode);
        //    Activity.Title = _tempRecyclerAdapter.containerCodes.Count + "| " + title;
        //    _tempRecyclerAdapter.NotifyItemRemoved(e.Position);
        //}

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

        /// ///////////////////// //////

        private async void _allConfirmBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
                var user = await LocalDbService<UserModel>.Instance.GetFirst();
                containerPackMainListItem = new List<ContainerPackModel>();
                List<Task> tasks = new List<Task>();
                var containerpack = new ContainerPack();
                string error = string.Empty;
                operationService.FixContainerPackAsync(containerpack, false, true, paletBarCode, true, true, location.PointID, true, user.User_PersonPost_ID, true, error);
                _containerSpinner.SetSelection(0);
                codeEditText.Focusable = true;
                codeEditText.RequestFocus();
                codeEditText.Text = string.Empty;
                //string error = string.Empty;
                //operationService.FixContainerPack(containerpack, false, true, paletBarCode, true, true, location.PointID, true, user.User_PersonPost_ID, true,ref error);
                if (string.IsNullOrEmpty(error))
                {
                    await Alerter.NotificationAlertAsync(Context, "პალეტის ფორმირება წარმატებით დასრულდა!");
                }
                else
                {
                    await Alerter.ErrorAlertAsync(Context, error);
                }
            }
            catch (Exception ex)
            {
                await Alerter.ErrorAlertAsync(Context, ex.Message);
            }
        }

        private async void ContainerPack(string containerBarCode)
        {
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            containerPackMainListItem = new List<ContainerPackModel>();
            var containerPack = new ContainerPack()
            {
                ContainerPack_Container_BarCode = containerBarCode,
                ContainerPack_Parent_Container_BarCode = paletBarCode,
                ContainerPack_DateTime = DateTime.Now,
                ContainerPack_User_PersonPost_Id = user.User_PersonPost_ID,
                ContainerPack_IsComplite = false,

                ContainerPack_User_PersonPost_IdSpecified = true,
                ContainerPack_Id = Guid.NewGuid().ToString(),
                ContainerPack_Parent_ContainerLocation_In_Id = Guid.NewGuid().ToString(),
                ContainerPack_DateTimeSpecified = true,
                ContainerPack_IsCompliteSpecified = true
                };
                var containerPackModel = new ContainerPackModel()
                {
                    ContainerBarCode = containerPack.ContainerPack_Container_BarCode,
                    Parent_ContainerBarCode = containerPack.ContainerPack_Parent_Container_BarCode,
                    Direction = _direction,
                    PersonPostId = containerPack.ContainerPack_User_PersonPost_Id
                };
                containerPackMainListItem.Add(containerPackModel);
                string error = string.Empty;
                operationService.FixContainerPackAsync(containerPack, true, true, null, false, true, location.PointID, true, user.User_PersonPost_ID, true, error);
                _containerSpinnerAdapter.Remove(containerBarCode);
                _containerSpinner.SetSelection(0);
                codeEditText.Focusable = true;
                codeEditText.RequestFocus();
                codeEditText.Text = string.Empty;
        }
        //private async void _confirmBtn_Click(object sender, EventArgs e)
        //{
            //var items = _tempRecyclerAdapter.containerCodes;
            //var user = await LocalDbService<UserModel>.Instance.GetFirst();
            
            //containerPackMainListItem = new List<ContainerPackModel>();
            //List<Task> tasks = new List<Task>();
             
            
            //    foreach (var item in items)
            //{

            //    var containerPack = new ContainerPack()
            //    {
            //        ContainerPack_Container_BarCode = item,
            //        ContainerPack_Parent_Container_BarCode = paletBarCode,
            //        ContainerPack_DateTime = DateTime.Now,
            //        ContainerPack_User_PersonPost_Id = user.User_PersonPost_ID,
            //        ContainerPack_IsComplite = false,
            //        ContainerPack_UnpackIsComplite = false,
            //        ContainerPack_DateTimeSpecified = true,
            //        ContainerPack_IsCompliteSpecified = true,
            //        ContainerPack_UnpackDateTimeSpecified = true,
            //        ContainerPack_UnpackIsCompliteSpecified = true,
            //        ContainerPack_UnpackUser_PersonPost_IdSpecified = true,
            //        ContainerPack_User_PersonPost_IdSpecified = true,
            //        ContainerPack_Id = Guid.NewGuid().ToString()
                    
                       
            //        };
            //        var containerPackModel = new ContainerPackModel()
            //        {
            //            ContainerBarCode= containerPack.ContainerPack_Container_BarCode,
            //            Parent_ContainerBarCode= containerPack.ContainerPack_Parent_Container_BarCode,
            //            Direction=_direction,
            //            PersonPostId=containerPack.ContainerPack_User_PersonPost_Id
            //        };
            //        containerPackMainListItem.Add(containerPackModel);
            //    string error = string.Empty;
            //    //operationService.FixContainerPack(containerPack, true,true,null,false,true,location.PointID,true,user.User_PersonPost_ID,true,ref error);

            //    operationService.FixContainerPackAsync(containerPack, true, true, null, false, true, location.PointID, true, user.User_PersonPost_ID, true, error);
            //    _containerSpinner.SetSelection(0);
            //    codeEditText.Focusable = true;
            //    codeEditText.RequestFocus();
            //    codeEditText.Text = string.Empty;
            //}


        //}

        private async void OperationService_FixContainerPackCompleted(object sender, FixContainerPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                //container.IsComplete = true;
                string errorMessage = null;
                long result = 0;
                bool res = true;
                operationService.GetContainerPackByPalette(paletBarCode, ref errorMessage, out result, out res);
                Activity.Title = result + "| " + title;
                //Alerter.NotificationAlertAsync(Context, "პალეტის დაკომპლექტება წარმატებით დასრულდა!");
                Toast.MakeText(Activity, "ყუთი წარმატებით დაემატა პალეტს", ToastLength.Long).Show();
                //_containerPackAdapter.items.Clear();

                //_containerPackAdapter.items.AddRange(containerPackMainListItem);
                //_containerPackAdapter.NotifyDataSetChanged();

                //AddItem(container);
                //string errorMessage = null;
                //int result = 0;
                //bool res = true;
                //operationService.GetCountForContainerMove(_transportWayBill.TransportWaybill_Id, true, _direction, true, ref errorMessage, out result, out res);
                //Activity.Title = result + "| " + title;
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
                await Alerter.ErrorAlertAsync(Context, "დაიფქსირდა შეცდომა, სცადეთ ახლიდან");
                //AddItem(container);
            }
                //Activity.RunOnUiThread(() => progressDialog.Dismiss());
            
        }

        public async void  OnRetry(int position)
        {
            var retryContainer = _containerPackAdapter.GetItem(position);
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            string msg = string.Empty;
            var location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
            var containerPack = new ContainerPack()
            {
                ContainerPack_Container_BarCode = retryContainer.ContainerBarCode,
                ContainerPack_Parent_Container_BarCode = paletBarCode,
                ContainerPack_DateTime = DateTime.Now,
                ContainerPack_User_PersonPost_Id = user.User_PersonPost_ID,
                ContainerPack_IsComplite = false,
                //ContainerPack_UnpackIsComplite = false,
            };
            operationService.FixContainerPackCompleted -= OperationService_FixContainerPackCompleted;
            operationService.FixContainerPackCompleted += OperationService_FixContainerPackCompleted;
            operationService.FixContainerPackAsync(containerPack, true, true, null, false, true, location.PointID, true, user.User_PersonPost_ID, true, string.Empty);

        }

        public async Task OnDone(string palet)
        {
            location = await LocalDbService<LocationAuthorizationState>.Instance.GetFirst();
            paletBarCode = palet;
            structureService.GetContainersForContainerPackAsync(string.Empty);
            operationService.GetContainerPackByPaletteAsync(paletBarCode, string.Empty);

        }

        public Task OnDone(SalePointsModel carpointID)
        {
            throw new NotImplementedException();
        }

        private async void OperationService_GetContainerPackByPaletteCompleted(object sender, GetContainerPackByPaletteCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                Activity.Title = e.GetContainerPackByPaletteResult + "| " + title;
            }
            else if (e.Error is WebException)
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();
                //Toast.MakeText(Activity, "ინტერნეტის პრობლემა", ToastLength.Long).Show()
                await Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                await Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }

        public Task OnDone(CompanyeModel palet)
        {
            throw new NotImplementedException();
        }
    }
}