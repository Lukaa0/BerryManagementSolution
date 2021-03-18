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
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.RsService;
using BerryManagementAndroidApplication.StructureService;
using Java.Lang;

namespace BerryManagementAndroidApplication.Fragments.Dialogs
{
    public class TransportPaletInputDialogFragment : DialogFragment
    {
        private EditText _edittext;
        private Spinner _transportSpinner;
        private Button _confirmButton;
        private IOnDialogDone callback;
        private ArrayAdapter<string> _transportSpinnerAdapter;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };

        private BM_RS_Service rsService = new BM_RS_Service()
        {
            Url = GlobalVariables.RsServiceUrl
        };
        private List<string> _palet;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                structureService.GetPaletForContainerPackCompleted -= StructureService_GetPaletForContainerPackCompleted;
                structureService.GetPaletForContainerPackCompleted += StructureService_GetPaletForContainerPackCompleted;
                callback = (IOnDialogDone)TargetFragment;
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException("Calling Fragment must implement OnAddFriendListener");
            }
        }

       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view =  inflater.Inflate(Resource.Layout.transport_input_dialog, container, false);
            _edittext = view.FindViewById<EditText>(Resource.Id.dialog_transport_code_edittext);
            _transportSpinner = view.FindViewById<Spinner>(Resource.Id.transport_dialog_spinner);
            _confirmButton = view.FindViewById<Button>(Resource.Id.transport_confirm_btn);
            _confirmButton.Text = "დადასტურება";
            _confirmButton.Click += _confirmButton_Click;
            _edittext.AfterTextChanged += _edittext_AfterTextChanged;
            return view;

        }

        private void _confirmButton_Click(object sender, EventArgs e)
        {
            if (_transportSpinner.SelectedItemPosition < 1)
            {
                var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                Alerter.ErrorAlert(Context, "პალეტი არ არის არჩეული");
                player.Start();
                return;
            }
            var car = _palet.Find(x => x == _transportSpinner.SelectedItem.ToString());
            if (car == null)
            {
                //Toast.MakeText(Activity, "პალეტი ვერ მოიძებნა", ToastLength.Long).Show();
                Alerter.ErrorAlert(Context, "პალეტი ვერ მოიძებნა");
                return;
            }
            
            callback.OnDone(car);
            this.Dismiss();
        }

        private async Task InsertTransport()
        {
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitializeSpinners();
            structureService.GetPaletForContainerPackAsync(true,true,string.Empty);

        }
        private void InitializeSpinners()
        {
            _transportSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _transportSpinnerAdapter.Add("აირჩიეთ პალეტი");
            _transportSpinner.Adapter = _transportSpinnerAdapter;
        }

        private void _edittext_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            var text = (sender as EditText).Text;
            if (_edittext.Text.Length >= 14)
            {
                if (_palet != null)
                {
                    var valuee = _palet.Find(x => x == text);
                    if (valuee == null)
                    {
                        //Toast.MakeText(Activity, "პალეტი ვერ მოიძებნა", ToastLength.Long).Show();
                        Alerter.ErrorAlert(Context, "პალეტი ვერ მოიძებნა");
                        return;
                    }
                    var value = valuee;
                    var position = _transportSpinnerAdapter.GetPosition(value);
                    if (position > 0)
                    {
                        _transportSpinner.SetSelection(position);
                    }
                    else
                        //Toast.MakeText(Activity, "პალეტი ვერ მოიძებნა", ToastLength.Long).Show();
                        Alerter.ErrorAlert(Context, "პალეტი ვერ მოიძებნა");
                }
            }

        }
        //სპინერის შევსება
        private async void StructureService_GetPaletForContainerPackCompleted(object sender, GetPaletForContainerPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _palet = e.Result.ToList();
                //await LocalDbService<String>.Instance.DeleteAll();
                //await LocalDbService<Container>.Instance.InsertAllAsnyc(_palet);
                _transportSpinnerAdapter.AddAll(_palet.Select(x => x).ToList());
            }

            else if (e.Error is WebException)
            {
                //_palet = (await LocalDbService<SalePointsModel>.Instance.selectItems());
                //_transportSpinnerAdapter.AddAll(_palet.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია",
                    //ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                //_palet = (await LocalDbService<SalePointsModel>.Instance.selectItems());
                //_transportSpinnerAdapter.AddAll(_palet.Select(x => x.Point_Name).ToList());

                //Toast.MakeText(Activity, e.errorMessage,
                    //ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
            }
        }
    }

    public partial interface IOnDialogDone
    {
        Task OnDone(string palet);
    }
}