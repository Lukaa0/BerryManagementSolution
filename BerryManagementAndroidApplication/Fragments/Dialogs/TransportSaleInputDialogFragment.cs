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
    public class TransportSaleInputDialogFragment : DialogFragment
    {
        private EditText _edittext;
        private Spinner _transportSpinner;
        private Button _confirmButton;
        private IOnCompanySelectionCompleted callback;
        private ArrayAdapter<string> _transportSpinnerAdapter;

        private BM_Structure_Service structureService = new BM_Structure_Service()
        {
            Url = GlobalVariables.StructureServiceUrl
        };

        private BM_RS_Service rsService = new BM_RS_Service()
        {
            Url = GlobalVariables.RsServiceUrl
        };
        private List<CompanyeModel> _companies;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                structureService.GetCompanyCompleted -= StructureService_GetCompanyCompleted;
                structureService.GetCompanyCompleted += StructureService_GetCompanyCompleted; 
                callback = (IOnCompanySelectionCompleted)TargetFragment;
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException("Calling Fragment must implement OnAddFriendListener");
            }
        }

        private void StructureService_GetCompanyCompleted(object sender, GetCompanyCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _companies = e.Result.ToList();
                //await LocalDbService<SalePointsModel>.Instance.DeleteAll();
                //await LocalDbService<SalePointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_companies.Select(x => x.Company_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                //_cars = (await LocalDbService<SalePointsModel>.Instance.selectItems());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //ToastLength.Long);
                Alerter.ErrorAlert(Context, "ინტერნეტთან კავშირი შეუძლებელია");
            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {

                //_cars = (await LocalDbService<SalePointsModel>.Instance.selectItems());

                //Toast.MakeText(Activity, e.errorMessage,
                //ToastLength.Long);
                Alerter.ErrorAlert(Context, e.errorMessage);
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
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                Alerter.ErrorAlert(Context, "მონაცემი არ არის არჩეული");
                return;
               
            }
            var car = _companies.Find(x => x.Company_Name == _transportSpinner.SelectedItem.ToString());
            if (car == null)
            {
                //Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
                Alerter.ErrorAlert(Context, "კომპანია ვერ მოიძებნა");
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
            structureService.GetCompanyAsync(null,true,-1,true,string.Empty);

        }
        private void InitializeSpinners()
        {
            _transportSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _transportSpinnerAdapter.Add("აირჩიეთ კომპანია");
            _transportSpinner.Adapter = _transportSpinnerAdapter;
        }

        private void _edittext_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            var text = (sender as EditText).Text;
            if (_edittext.Text.Length >= 14)
            {
                if (_companies != null)
                {
                    var valuee = _companies.Find(x => x.Company_Name == text);
                    if (valuee == null)
                    {
                        //Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
                        Alerter.ErrorAlert(Context, "კომპანია ვერ მოიძებნა");
                        _edittext.Text = string.Empty;
                        return;
                    }
                    var value = valuee.Company_Name;
                    var position = _transportSpinnerAdapter.GetPosition(value);
                    if (position > 0)
                    {
                        _transportSpinner.SetSelection(position);
                    }
                    else
                        //Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
                        Alerter.ErrorAlert(Context, "კოპანია ვერ მოიძებნა");

                    _edittext.Text = string.Empty;
                }

            }

        }
        //სპინერის შევსება
       
    }

    public partial interface IOnCompanySelectionCompleted
    {
        Task OnDone(CompanyeModel companyModel);
    }
}