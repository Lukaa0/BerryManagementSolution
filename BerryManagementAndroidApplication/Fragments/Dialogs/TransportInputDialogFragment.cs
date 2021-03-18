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
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.RsService;
using BerryManagementAndroidApplication.StructureService;
using Java.Lang;

namespace BerryManagementAndroidApplication.Fragments.Dialogs
{
    public class TransportInputDialogFragment : DialogFragment
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
        private List<PointsModel> _cars;
        private bool _direction;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            try
            {
                _direction = Arguments.GetBoolean("direction");
                structureService.GetCarsPointModelCompleted -= StructureService_GetCarsPointModelCompleted;
                structureService.GetCarsPointModelCompleted += StructureService_GetCarsPointModelCompleted;

                structureService.GetCarsPointModelForContainerMoveCompleted -= StructureService_GetCarsPointModelForContainerMoveCompleted;
                structureService.GetCarsPointModelForContainerMoveCompleted += StructureService_GetCarsPointModelForContainerMoveCompleted;
                rsService.InsertTransportWaybillCompanyMoveCompleted -= RsService_InsertTransportWaybillCompanyMoveCompleted;
                rsService.InsertTransportWaybillCompanyMoveCompleted += RsService_InsertTransportWaybillCompanyMoveCompleted;
                callback = (IOnDialogDone)TargetFragment;
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException("Calling Fragment must implement OnAddFriendListener");
            }
        }

        private  void RsService_InsertTransportWaybillCompanyMoveCompleted(object sender, InsertTransportWaybillCompanyMoveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                var result = e.Result;
                callback.OnDone(result);
                this.Dismiss();
            }

            else if (e.Error is WebException)
            {
                Toast.MakeText(Activity, "ამ ოპერაციის განსახორცილებლად, აუცილებელია ინტერნეტთან კავშირი",
                    ToastLength.Long);
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {
                

                Toast.MakeText(Activity, e.errorMessage,
                    ToastLength.Long);
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
                player.Start();
                return;
            }
            var barcode = _cars.Find(x => x.Point_Name==_transportSpinner.SelectedItem.ToString()).Point_BarCode;
            rsService.InsertTransportWaybillCompanyMoveAsync(barcode,_direction,true, string.Empty);
        }

        private async Task InsertTransport()
        {
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitializeSpinners();
            if (_direction)
            {
                structureService.GetCarsPointModelForContainerMoveAsync(_direction, true, string.Empty);
            }
            else if (_direction == false)
            {
                structureService.GetCarsPointModelForContainerMoveAsync(_direction, true, string.Empty);
            }
            else
            {
                structureService.GetCarsPointModelAsync(string.Empty);
            }
            

        }
        private void InitializeSpinners()
        {
            _transportSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _transportSpinnerAdapter.Add("აირჩიეთ ტრანსპორტი");
            _transportSpinner.Adapter = _transportSpinnerAdapter;
        }

        private void _edittext_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
        {
            //string text = (sender as EditText).Text;
            //if (_edittext.Text.Length >= 14)
            //{
            //    var value = _cars.Find(x => x.Point_BarCode == text)?.Point_Name;
            //    if (value == null)
            //    {
            //        Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();
            //        return;
            //    }

            //    var position = _transportSpinnerAdapter.GetPosition(value);
            //    if (position > 0)
            //    {
            //        _transportSpinner.SetSelection(position);
            //    }
            //    else
            //        Toast.MakeText(Activity, "ტრანსპორტი ვერ მოიძებნა", ToastLength.Long).Show();

            //    text = string.Empty;
            //}


            string text = (sender as EditText).Text;
            string name = string.Empty;
            try
            {

                if (InputValidationUtility.BarcodeLenghtChecker(text))
                {
                    var prefix = InputValidationUtility.BarCodeChecker(text);
                    switch (prefix)
                    {
                        case "LC":
                            var value = _cars.Find(x => x.Point_BarCode == text);
                            if (value != null)
                            {
                                name = value.Point_Name;
                                var position = _transportSpinnerAdapter.GetPosition(name);
                                if (position > 0)
                                    _transportSpinner.SetSelection(position);
                                _edittext.Text = string.Empty;
                            }
                            else
                            {
                                _edittext.Text = string.Empty;
                            }
                            break;

                        default:
                            throw new InvalidCodeException();
                    }

                }
                else
                {
                    
                }
            }

            catch (InvalidCodeException ecx)
            {
                Alerter.ErrorAlert(Context, ecx.Message);
                //Toast.MakeText(Context, ecx.Message, ToastLength.Short).Show();
                //var player = MediaPlayer.Create(Activity, Resource.Raw.error_sound);
                //player.Start();
                _edittext.Text = string.Empty;
            }

        }
        //სპინერის შევსება
        private async void StructureService_GetCarsPointModelCompleted(object sender, GetCarsPointModelCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _cars = e.Result.ToList();
                await LocalDbService<PointsModel>.Instance.DeleteAll();
                await LocalDbService<PointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
               // Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                    //ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
               // Toast.MakeText(Activity, e.errorMessage,
               //    ToastLength.Long);
            }
        }
        private async void StructureService_GetCarsPointModelForContainerMoveCompleted(object sender, GetCarsPointModelForContainerMoveCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _cars = e.Result.ToList();
                await LocalDbService<PointsModel>.Instance.DeleteAll();
                await LocalDbService<PointsModel>.Instance.InsertAllAsnyc(_cars);
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
            }

            else if (e.Error is WebException)
            {
                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");
            }
            else if (string.IsNullOrEmpty(e.errorMessage))
            {

                _cars = (await LocalDbService<PointsModel>.Instance.selectItems());
                _transportSpinnerAdapter.AddAll(_cars.Select(x => x.Point_Name).ToList());
                Alerter.ErrorAlertAsync(Context, e.errorMessage);
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long);
            }
        }
    }

    public partial interface IOnDialogDone
    {
        Task OnDone(TransportWaybill transport);

    }
}