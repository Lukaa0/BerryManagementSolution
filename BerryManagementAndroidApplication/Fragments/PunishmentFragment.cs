using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Media;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.SecurityService;

namespace BerryManagementAndroidApplication.Fragments
{
    public class PunishmentFragment : Fragment
    {
        private Spinner _spinnerPunishmentType;
        private PunishmentRecyclerView _recyclerAdapter;
        private Spinner _spinnerHarvCont;
        private Spinner _spinnerPerson;
        private RecyclerView _recyclerView;
        private EditText _editText;
        private Button _confirmBtn;
        private ArrayAdapter<string> _punishmentSpinnerAdapter;
        private Dictionary<string, string> harvesterMap;
        private bool isContainer;

        private BM_Library_Service libraryService = new BM_Library_Service()
        {
            Url = GlobalVariables.LibraryServiceUrl
        };

        private BM_Employee_Service employeeService = new BM_Employee_Service()
        {
            Url = GlobalVariables.EmployeeServiceIrl
        };
        private ArrayAdapter<string> _harvContSpinnerAdapter;
        private ArrayAdapter<string> _contPersonSpinnerAdapter;
        private List<PunishmentModel> _punishmentModel;
        private List<ContainerModel> _containerModel;
        private List<tf_PunishmentTypes_Result> _punishmentTypes;
        private PunishmentModel _punishmentListItem;
        private List<PersonPostModelLocal> persons;
        private bool _isContainerPerson;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            isContainer = Arguments.GetBoolean("isContainer");
            _isContainerPerson = Arguments.GetBoolean("isContainerPerson");

            libraryService.GetPunishmentTypesCompleted -= LibraryService_GetPunishmentTypesCompleted;
            libraryService.GetPunishmentTypesCompleted += LibraryService_GetPunishmentTypesCompleted;
            libraryService.GetContainersByProductPackCompleted -= LibraryService_GetContainersByProductPackCompleted;
            libraryService.GetContainersByProductPackCompleted += LibraryService_GetContainersByProductPackCompleted;
            employeeService.GetHarvesterByHRDForPunishmentCompleted -= EmployeeService_GetHarvesterByHRDForPunishmentCompleted;
            employeeService.GetHarvesterByHRDForPunishmentCompleted += EmployeeService_GetHarvesterByHRDForPunishmentCompleted;

            employeeService.GetPersonPostsForPunishmentCompleted -= employeeService_GetPersonPostsForPunishmentCompleted;
            employeeService.GetPersonPostsForPunishmentCompleted += employeeService_GetPersonPostsForPunishmentCompleted;
            employeeService.GetPunishmentCompleted -= EmployeeService_GetPunishmentCompleted;
            employeeService.GetPunishmentCompleted += EmployeeService_GetPunishmentCompleted;
            
            employeeService.InsertPunishmentForAndroidCompleted -= EmployeeService_InsertPunishmentForAndroidCompleted;
            employeeService.InsertPunishmentForAndroidCompleted += EmployeeService_InsertPunishmentForAndroidCompleted;
            Activity.Title = "საყვედური";

        }

        private async void EmployeeService_InsertPunishmentForAndroidCompleted(object sender, InsertPunishmentForAndroidCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.ErrorMessage))
            {
                _punishmentListItem.Error = null;
                _punishmentListItem.IsComplete = true;
                _recyclerAdapter.Add(_punishmentListItem);
                Alerter.NotificationAlert(Context,"ჩანაწერი წარმატებით ჩაიწერა");
            }

           else if (e.Error is WebException)
            {
                _punishmentListItem.IsComplete = false;
                await LocalDbService<PunishmentModel>.Instance.InsertOrReplaceAsync(_punishmentListItem);
                _recyclerAdapter.Add(_punishmentListItem);
                //Toast.MakeText(Activity, "ჩანაწერი ჩაიწერა ლოკალურად ინტერნეტის არ ქონის გამო", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ჩანაწერი ჩაიწერა ლოკალურად ინტერნეტის არ ქონის გამო");

            }

            else if (!string.IsNullOrEmpty(e.ErrorMessage))
            {
                _punishmentListItem.Error = e.ErrorMessage;
                _punishmentListItem.IsComplete = true;
                await LocalDbService<PunishmentModel>.Instance.InsertOrReplaceAsync(_punishmentListItem);
                _recyclerAdapter.Add(_punishmentListItem);
                //Toast.MakeText(Activity, e.ErrorMessage+" სცადეთ ახლიდან", ToastLength.Long);
                Alerter.ErrorAlertAsync(Context, e.ErrorMessage + " სცადეთ ახლიდან");


            }
        }

        private async void EmployeeService_GetPunishmentCompleted(object sender, GetPunishmentCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _punishmentModel = e.Result.ToList();
                
                _recyclerAdapter = new PunishmentRecyclerView(_punishmentModel);
                SetupRecyclerView(_recyclerAdapter);
            }

            else if (e.Error is WebException)
            {

                _punishmentModel = (await LocalDbService<PunishmentModel>.Instance.selectItems());
                _recyclerAdapter = new PunishmentRecyclerView(_punishmentModel);
                SetupRecyclerView(_recyclerAdapter);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

                _punishmentModel = (await LocalDbService<PunishmentModel>.Instance.selectItems());
                _recyclerAdapter = new PunishmentRecyclerView(_punishmentModel);
                SetupRecyclerView(_recyclerAdapter);
            }
        }

        private async void LibraryService_GetContainersByProductPackCompleted(object sender, GetContainersByProductPackCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _containerModel = e.Result.ToList();
                _harvContSpinnerAdapter.AddAll(e.Result.Select(x => x.Container_BarCode).ToList());
                await LocalDbService<ContainerModel>.Instance.DeleteAll();
                await LocalDbService<ContainerModel>.Instance.InsertAllAsnyc(e.Result);
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");

                _containerModel = (await LocalDbService<ContainerModel>.Instance.selectItems());
                _harvContSpinnerAdapter.AddAll(_containerModel.Select(x=>x.Container_BarCode).ToList());

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

                _containerModel = (await LocalDbService<ContainerModel>.Instance.selectItems());
                var items = _containerModel.Select(x => x.Container_BarCode).ToList();
                _harvContSpinnerAdapter.AddAll(items);
            }
        }

        private async void EmployeeService_GetHarvesterByHRDForPunishmentCompleted(object sender, GetHarvesterByHRDForPunishmentCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                var _personPostModel = e.Result.ToList();
                persons = new List<PersonPostModelLocal>();
                foreach (var item in _personPostModel)
                {
                    persons.Add(new PersonPostModelLocal(item)
                    {
                        ContentType = "Punishment"
                    });
                }
                _harvContSpinnerAdapter.AddAll(_personPostModel.Select(x => x.PersonPost_Person_FullName).ToList());
                await LocalDbService<PersonPostModelLocal>.Instance.DeleteByContentType("Punishment");
                await LocalDbService<PersonPostModelLocal>.Instance.InsertAllAsnyc(persons);
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");

                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems());
                var items = persons.Where(x => x.ContentType == "Punishment").ToList().Select(x => x.FullName).ToList();
                _harvContSpinnerAdapter.AddAll(items);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems());
                var items = persons.Where(x => x.ContentType == "Punishment").ToList().Select(x => x.FullName).ToList();
                _harvContSpinnerAdapter.AddAll(items);
            }
        }

        private async void employeeService_GetPersonPostsForPunishmentCompleted(object sender, GetPersonPostsForPunishmentCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                var _personPostModel = e.Result.ToList();
                persons = new List<PersonPostModelLocal>();
                foreach (var item in _personPostModel)
                {
                    persons.Add(new PersonPostModelLocal(item)
                    {
                        ContentType="Punishment"
                    });
                }
                _contPersonSpinnerAdapter.AddAll(_personPostModel.Select(x => x.PersonPost_EmployeeBarCode).ToList());
                await LocalDbService<PersonPostModelLocal>.Instance.DeleteByContentType("Punishment");
                await LocalDbService<PersonPostModelLocal>.Instance.InsertAllAsnyc(persons);
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");

                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems());
                   var items = persons.Where(x => x.ContentType == "Punishment").ToList().Select(x => x.Barcode).ToList();
                _contPersonSpinnerAdapter.AddAll(items);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

                persons = (await LocalDbService<PersonPostModelLocal>.Instance.selectItems());
                var items = persons.Where(x => x.ContentType == "Punishment").ToList().Select(x => x.Barcode).ToList();
                _contPersonSpinnerAdapter.AddAll(items);
            }
        }

        private async void LibraryService_GetPunishmentTypesCompleted(object sender, GetPunishmentTypesCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                _punishmentTypes = e.Result.ToList();
                _punishmentSpinnerAdapter.AddAll(e.Result.Select(x => x.PunishmentType_Name).ToList());
                await LocalDbService<tf_PunishmentTypes_Result>.Instance.DeleteAll();
                await LocalDbService<tf_PunishmentTypes_Result>.Instance.InsertAllAsnyc(e.Result);
            }

            else if (e.Error is WebException)
            {
                //Toast.MakeText(Activity, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები",
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინტერნეტთან კავშირი შეუძლებელია, იტვირთება ლოკალური მონაცემები");

                _punishmentTypes = await LocalDbService<tf_PunishmentTypes_Result>.Instance.selectItems();
                    var items = _punishmentTypes.Select(x => x.PunishmentType_Name).ToList();
                _punishmentSpinnerAdapter.AddAll(items);

            }
            else if (!string.IsNullOrEmpty(e.errorMessage))
            {
                //Toast.MakeText(Activity, e.errorMessage,
                //    ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, e.errorMessage);

                _punishmentTypes = e.Result.ToList();
                _punishmentTypes = await LocalDbService<tf_PunishmentTypes_Result>.Instance.selectItems();
                var items = _punishmentTypes.Select(x => x.PunishmentType_Name).ToList();
                _punishmentSpinnerAdapter.AddAll(items);
            }

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view =  inflater.Inflate(Resource.Layout.punishment_layout, container, false);
            _spinnerPunishmentType = view.FindViewById<Spinner>(Resource.Id.spinner_punishment_type);
            _spinnerHarvCont = view.FindViewById<Spinner>(Resource.Id.spinner_contorharv);
            _spinnerPerson = view.FindViewById<Spinner>(Resource.Id.spinner_person);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.punishment_recyler);
            _editText = view.FindViewById<EditText>(Resource.Id.punishment_editText);
            _confirmBtn = view.FindViewById<Button>(Resource.Id.punishment_confirm_btn);
            if (!_isContainerPerson)
            {
                _spinnerPerson.Visibility = ViewStates.Gone;
            }
            _confirmBtn.Text = "დადასტურება";
            _editText.RequestFocus();
            _editText.ShowSoftInputOnFocus = false;
            _confirmBtn.Click += _confirmBtn_Click;
            _editText.AfterTextChanged += _editText_AfterTextChanged;
            return view;


        }

        private async void _confirmBtn_Click(object sender, EventArgs e)
        {
            if (!(_spinnerHarvCont.SelectedItemPosition > 0 && _spinnerPunishmentType.SelectedItemPosition > 0))
            {
                //Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");

                return;
            }
            Punishment punishment = new Punishment();
            var punishmentName = _spinnerPunishmentType.SelectedItem.ToString();
            _spinnerPunishmentType.SetSelection(0);
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            
            var harvOrCont = _spinnerHarvCont.SelectedItem.ToString();
            _spinnerHarvCont.SetSelection(0);
            ContainerModel containerModel = new ContainerModel();
            PersonPostModelLocal personPost = null;
            long personPostId = 0;
            long contanerPersonPostId = 0;
            if (_isContainerPerson)
            {
                if (!(_spinnerPerson.SelectedItemPosition > 0))
                {
                    //Toast.MakeText(Activity, "ინფორმაცია არ არის შეყვანილი", ToastLength.Long).Show();
                    Alerter.ErrorAlertAsync(Context, "ინფორმაცია არ არის შეყვანილი");

                    return;
                }
                var person = _spinnerPerson.SelectedItem.ToString();
                long punishmentTypeId = _punishmentTypes.Find(x => x.PunishmentType_Name == punishmentName).PunishmentType_Id.Value;
               
                personPost = persons.Find(x => x.Barcode == person);
                contanerPersonPostId = personPost.PersonPostId;
                containerModel = _containerModel.Find(x => x.Container_BarCode == harvOrCont);
                personPostId = containerModel.Container_PersonPost_Id;
                _punishmentListItem = new PunishmentModel()
                {
                    PunishmentType_Name = punishmentName,
                    Punishment_DateTime = DateTime.Now,
                    Punishment_User_FullName = user.User_Person_FirstName + " " + user.User_Person_LastName,

                };
               
                 _punishmentListItem.Punishment_Harvester_FullName = containerModel.Container_Harvester_FullName;

                punishment = new Punishment()
                {
                    Punishment_DateTime = DateTime.Now,
                    Punishment_DateTimeSpecified = true,
                    Punishment_Id = Guid.NewGuid().ToString(),
                    Punishment_PersonPost_Id = personPostId,
                    Punishment_PersonPost_IdSpecified = true,
                    Punishment_PunishmentType_Id = punishmentTypeId,
                    Punishment_PunishmentType_IdSpecified = true,
                    Punishment_User_PersonPost_Id = user.User_PersonPost_ID,
                    Punishment_User_PersonPost_IdSpecified = true,
                    Punishment_RecomenderUser_PersonPost_Id = personPost.PersonPostId,
                    Punishment_RecomenderUser_PersonPost_IdSpecified = true

                };

            }
            else
            {
                
                long punishmentTypeId = _punishmentTypes.Find(x => x.PunishmentType_Name == punishmentName).PunishmentType_Id.Value;
                if (!isContainer)
                {
                    personPost = persons.Find(x => x.FullName == harvOrCont);
                    personPostId = personPost.PersonPostId;
                }
                else
                {
                    containerModel = _containerModel.Find(x => x.Container_BarCode == harvOrCont);
                    personPostId = containerModel.Container_PersonPost_Id;
                }


                _punishmentListItem = new PunishmentModel()
                {
                    PunishmentType_Name = punishmentName,
                    Punishment_DateTime = DateTime.Now,
                    Punishment_User_FullName = user.User_Person_FirstName + " " + user.User_Person_LastName,

                };
                if (!isContainer)
                {
                    _punishmentListItem.Punishment_Harvester_FullName = personPost.FullName;
                }
                else
                {
                    _punishmentListItem.Punishment_Harvester_FullName = containerModel.Container_Harvester_FullName;
                }
                punishment = new Punishment()
                {
                    Punishment_DateTime = DateTime.Now,
                    Punishment_DateTimeSpecified = true,
                    Punishment_Id = Guid.NewGuid().ToString(),
                    Punishment_PersonPost_Id = personPostId,
                    Punishment_PersonPost_IdSpecified = true,
                    Punishment_PunishmentType_Id = punishmentTypeId,
                    Punishment_PunishmentType_IdSpecified = true,
                    Punishment_User_PersonPost_Id = user.User_PersonPost_ID,
                    Punishment_User_PersonPost_IdSpecified = true,
                    


                };
            }

            employeeService.InsertPunishmentForAndroidAsync(punishment,containerModel.Container_BarCode, string.Empty);
            _editText.Focusable = true;
            _editText.RequestFocus();
            _editText.Text = string.Empty;

        }

        private void _editText_AfterTextChanged(object sender, Android.Text.AfterTextChangedEventArgs e)
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
                    int position;
                    switch (isContainer)
                    {
                        case true:
                            switch (prefix)
                            {
                                case "CT":
                                    position = _harvContSpinnerAdapter.GetPosition(text);
                                    if (position > 0)
                                        _spinnerHarvCont.SetSelection(position);
                                    _editText.Text = string.Empty;
                                    break;
                                case "PK":
                                    position = _contPersonSpinnerAdapter.GetPosition(text);
                                    if (position > 0)
                                        _spinnerPerson.SetSelection(position);
                                    _editText.Text = string.Empty;
                                    break;
                                default:
                                    throw new InvalidCodeException();
                            }
                            break;
                        case false:
                            switch (prefix)
                            {
                                case "PH":
                                    var personPost = persons.Find(x => x.Barcode == text);
                                    position = personPost != null ? _harvContSpinnerAdapter.GetPosition(personPost.FullName) : 0;
                                    
                                    if (position > 0)
                                        _spinnerHarvCont.SetSelection(position);
                                    _editText.Text = string.Empty;
                                    break;
                                default:
                                    throw new InvalidCodeException();
                            }
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
                _editText.Text = string.Empty;
            }
        }

        public async override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            string message = string.Empty;
            _punishmentSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _punishmentSpinnerAdapter.Add("აირჩიეთ საყვედური");
            _harvContSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            _contPersonSpinnerAdapter = new ArrayAdapter<string>(Activity,
                Resource.Layout.support_simple_spinner_dropdown_item);
            if (_isContainerPerson)
            {
                _contPersonSpinnerAdapter.Add("აირჩიეთ კონტროლიორი");
                _spinnerPerson.Adapter = _contPersonSpinnerAdapter;
            }
            if (isContainer)
                _harvContSpinnerAdapter.Add("აირჩიეთ ყუთი");

            else
                _harvContSpinnerAdapter.Add("აირჩიეთ მკრეფავი");
          
           
            _spinnerPunishmentType.Adapter = _punishmentSpinnerAdapter;
            _spinnerHarvCont.Adapter = _harvContSpinnerAdapter;
            libraryService.GetPunishmentTypesAsync(null, true, null, message);
            if (_isContainerPerson)
            {
                employeeService.GetPersonPostsForPunishmentAsync(message);
            }
            if (!isContainer)
                employeeService.GetHarvesterByHRDForPunishmentAsync(message);
            else
                libraryService.GetContainersByProductPackAsync(message);
            var user = await LocalDbService<UserModel>.Instance.GetFirst();
            employeeService.GetPunishmentAsync(null,true,user.User_Person_ID,true, message);


        }
        private void SetupRecyclerView(RecyclerView.Adapter adapter)
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Activity, 1);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(adapter);
        }
    }
}