using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public class PaletteFragment : Fragment, IOnDialogItemClick,AdapterView.IOnItemSelectedListener
    {
        private RecyclerView _recyclerPalet;
        private EditText codeEditText;
        private Spinner _containerSpinner;
        private Button _confirmBtn;
        private RecyclerView _tempRecyclerView;
        private ProgressBar progressBar;
        private RelativeLayout mainContainer;

        private BM_Operation_Service operationService = new BM_Operation_Service()
        {
            Url = GlobalVariables.OperationServiceUrl
        };
        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
           Url=GlobalVariables.StructureServiceUrl
        };
        private PalleteAndContainerRecyclerViewAdapter _palleteAndContainerAdapter;
        private ProgressDialog progressDialog;
        private RedItemDialog _redItemDialog;
        private ArrayAdapter<string> _containerSpinnerAdapter;
        private PalleteAndContainerRecyclerViewAdapter _tempRecyclerAdapter;
        private string title;
        private List<ContainersForPalette> _containers;
        private List<PaletteModel> _palettes;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            title = "პალეტის შექმნა";
            Activity.Title = title;
            progressDialog = new ProgressDialog(Activity);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");
            structureService.GetContainersForContainerPackCompleted -= StructureService_GetContainersForContainerPackCompleted;

            structureService.GetContainersForContainerPackCompleted += StructureService_GetContainersForContainerPackCompleted;
            structureService.GetPaletForContainerPackCompleted -= StructureService_GetPaletForContainerPackCompleted;
            structureService.GetPaletForContainerPackCompleted += StructureService_GetPaletForContainerPackCompleted;


        }
        //მთავარი ლისთის შევსება
        private async void StructureService_GetPaletForContainerPackCompleted(object sender, GetPaletForContainerPackCompletedEventArgs e)
        {

            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _palettes = new List<PaletteModel>();
                foreach (var item in e.Result)
                {
                    _palettes.Add(new PaletteModel(item));
                }
                await LocalDbService<PaletteModel>.Instance.DeleteAll();
                await LocalDbService<PaletteModel>.Instance.InsertAllAsnyc(_palettes);
                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(e.Result.ToList());
                SetupRecyclerView(_recyclerPalet, _palleteAndContainerAdapter);
            }
            else if (e.Error is WebException)
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();

                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(items);
                SetupRecyclerView(_recyclerPalet, _palleteAndContainerAdapter);
                //Toast.MakeText(Activity, "მონაცემები ჩამოიტვირთა ლოკალურად", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                var items = await LocalDbService<ContainerMoveInOut>.Instance.selectItems();

                _palleteAndContainerAdapter = new PalleteAndContainerRecyclerViewAdapter(items);
                SetupRecyclerView(_recyclerPalet, _palleteAndContainerAdapter);
                //Toast.MakeText(Activity, e.errorMessage, ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

            }
        }
        //სპინერის შევსება
        private async void StructureService_GetContainersForContainerPackCompleted(object sender,
            GetContainersForContainerPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {


                _containers = new List<ContainersForPalette>();
                //foreach (var item in e.Result)
                //{
                //    _containers.Add(new ContainersForPalette(item));
                //}

                await LocalDbService<ContainersForPalette>.Instance.DeleteAll();
                await LocalDbService<ContainersForPalette>.Instance.InsertAllAsnyc(_containers);
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
            else if (e.Error is WebException)
            {
                _containers = await LocalDbService<ContainersForPalette>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {

                _containers = await LocalDbService<ContainersForPalette>.Instance.selectItems();
                _containerSpinnerAdapter.AddAll(_containers.Select(x => x.Barcode).ToList());
            }
        
    }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.palette_main_layout, container, false);
            _recyclerPalet = view.FindViewById<RecyclerView>(Resource.Id.palette_recycler_view);
            progressBar = view.FindViewById<ProgressBar>(Resource.Id.palette_main_progressbar);
            mainContainer = view.FindViewById<RelativeLayout>(Resource.Id.palette_receive_header_container);
            codeEditText = view.FindViewById<EditText>(Resource.Id.palette_scan_edittext);
            codeEditText.RequestFocus();
            codeEditText.ShowSoftInputOnFocus=false;
            _containerSpinner = view.FindViewById<Spinner>(Resource.Id.palette_spinner);
            _confirmBtn = view.FindViewById<Button>(Resource.Id.palette_operation_confirm);
            _confirmBtn.Text = Activity.Title;
            _tempRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.palette_temp_recylcer);
            codeEditText.AfterTextChanged += CodeEditText_AfterTextChanged;
            _confirmBtn.Click += _confirmBtn_Click;
            return view;
        }

       
        private void _confirmBtn_Click(object sender, EventArgs e)
        {

        }

          
        

       
        private void CodeEditText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            string text = (sender as EditText).Text;
            try
            {

                if (InputValidationUtility.BarcodeLenghtChecker(text))
                {
                    var position = _containerSpinnerAdapter.GetPosition(text);
                    if (position < 1)
                        return;

                    _containerSpinner.SetSelection(position, true);
                    codeEditText.Text = string.Empty;
                }

            }

            catch (InvalidCodeException ecx)
            {
                //Toast.MakeText(Activity, ecx.Message, ToastLength.Short).Show();
                Alerter.ErrorAlert(Context, ecx.Message);
            }

        }






        

        
        public void AddItem(ContainerMoveInOut container)
        {
            _palleteAndContainerAdapter.Add(container);
        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            progressBar.Visibility = ViewStates.Gone;
            mainContainer.Visibility = ViewStates.Visible;
            _tempRecyclerAdapter = new PalleteAndContainerRecyclerViewAdapter(new List<string>());
            SetupRecyclerView(_tempRecyclerView, _tempRecyclerAdapter);
            _tempRecyclerAdapter.ItemClick += _tempRecyclerAdapter_ItemClick;
            structureService.GetPaletForContainerPackAsync(true, true, string.Empty);
            structureService.GetContainersForContainerPackAsync(string.Empty);
            InitializeSpinner();
            // dialog.GetButton((int)DialogButtonType.Positive).Click += ContainerInOutFragment_Click;

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
            _containerSpinnerAdapter.Add("აირჩიეთ პალეტი");
            _containerSpinner.Adapter = _containerSpinnerAdapter;
            _containerSpinner.OnItemSelectedListener = this;
        }
      








        private void SetupRecyclerView(RecyclerView recyclerView, RecyclerView.Adapter adapter)
        {
            LinearLayoutManager layoutManager = new LinearLayoutManager(Activity);
            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);
        }

        public void OnRetry(int position)
        {
            var retryContainer = _palleteAndContainerAdapter.GetItem(position);
            string msg = string.Empty;

        }

        public void OnDelete(int position)
        {
            var deleteContainer = _palleteAndContainerAdapter.GetItem(position);
            _palleteAndContainerAdapter.DeleteContainer(deleteContainer);

        }

        public void OnItemSelected(AdapterView parent, View view, int position, long id)
        {
            if (position < 1)
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                player.Start();

                return;
            }
            var containerBarcode = _containerSpinner.SelectedItem.ToString();
            _tempRecyclerAdapter.Add(containerBarcode);
            _containerSpinner.SetSelection(0);
        }

        public void OnNothingSelected(AdapterView parent)
        {
        }
    }
}