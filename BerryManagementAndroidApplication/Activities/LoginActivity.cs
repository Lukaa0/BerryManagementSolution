using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.Service;
using Matcha.BackgroundService;

namespace BerryManagementAndroidApplication.Activities
{
    [Activity(Label = "LoginActivity", NoHistory = true)]
    public class LoginActivity : Activity
    {
        private EditText _passwordTxt;
        private EditText _nameTxt;
        private Button _loginBtn;

        private BM_Security_Service securityClient = new BM_Security_Service()
        {
            Url = GlobalVariables.SecurityServiceUrl
        };

        private BM_Employee_Service employeeClient = new BM_Employee_Service()
        {
            Url = GlobalVariables.EmployeeServiceIrl
        };

        private UserModel user;
        private UserPermissions userPermissions;
        private ProgressDialog progressDialog;
        private string _generatedCode;
        private static Intent alarmIntent;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.login_layout);
            securityClient.AutorizeUserCompleted -= SecurityClient_AutorizeUserCompleted;
            securityClient.AutorizeUserCompleted += SecurityClient_AutorizeUserCompleted;
            securityClient.GetUserPermissionsCompleted -= SecurityClient_GetUserPermissionsCompleted;
            securityClient.GetUserPermissionsCompleted += SecurityClient_GetUserPermissionsCompleted;
            employeeClient.GetPersonPostsIdByPersonIdCompleted -= EmployeeClient_GetPersonPostsIdByPersonIdCompleted;
            employeeClient.GetPersonPostsIdByPersonIdCompleted += EmployeeClient_GetPersonPostsIdByPersonIdCompleted;

            _passwordTxt = FindViewById<EditText>(Resource.Id.input_password);
            _nameTxt = FindViewById<EditText>(Resource.Id.input_name);
            _loginBtn = FindViewById<Button>(Resource.Id.btn_login);
            _loginBtn.Click += _loginBtn_Click;
            
            

        }

        private void EmployeeClient_GetPersonPostsIdByPersonIdCompleted(object sender,
            GetPersonPostsIdByPersonIdCompletedEventArgs e)
        {

            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage) && user != null)
            {
                //user.User_PersonPost_ID = e.Result.FirstOrDefault().PersonPost_Id;
                securityClient.GetUserPermissionsAsync(user.User_Person_ID, true, e.errorMessage);
            }
            else if (e.Error is WebException)
            {

                Toast.MakeText(this, "კავშირი შეუძლებელია, სცადეთ ახლიდან ", ToastLength.Long).Show();
                progressDialog.Dismiss();
            }
            else
            {
                Toast.MakeText(this, "არასწორი მონაცემები, სცადეთ ახლიდან", ToastLength.Long).Show();
                progressDialog.Dismiss();
            }
        }

        private void _loginBtn_Click(object sender, EventArgs e)
        {

            string message = string.Empty;
            _generatedCode = Security.GetSecurityCode(_passwordTxt.Text);
            progressDialog = new ProgressDialog(this);
            progressDialog.SetTitle("იტვირთება");
            progressDialog.Show();
            securityClient.AutorizeUserAsync(_generatedCode, null, _nameTxt.Text, message);
        }

        private async void SecurityClient_GetUserPermissionsCompleted(object sender,
            GetUserPermissionsCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage))
            {
                userPermissions = e.Result;
                List<UserPermissionsModel> permissions = new List<UserPermissionsModel>();
                foreach (var item in userPermissions.UserPermisions)
                {
                    permissions.Add(new UserPermissionsModel()
                    {
                        PermissionId = item
                    });
                }

                await LocalDbService<UserPermissionsModel>.Instance.InsertAllAsnyc(permissions);
                await LocalDbService<UserModel>.Instance.insertUpdateDataAsync(user, false);
                progressDialog.Dismiss();
                StartActivity(typeof(MainActivity));
            }
        }
    

    private  void SecurityClient_AutorizeUserCompleted(object sender, AutorizeUserCompletedEventArgs e)
        {
            if (e.Error == null && string.IsNullOrEmpty(e.errorMessage)&&e.Result!=null)
            {
                user = e.Result.FirstOrDefault();
                if (user == null)
                {
                    Toast.MakeText(this, "არასწორი მონაცემები, სცადეთ ახლიდან", ToastLength.Long).Show();
                    progressDialog.Dismiss();
                    return;
                }
                employeeClient.GetPersonPostsIdByPersonIdAsync(user.User_Person_ID, true, e.errorMessage);
            }
            else if (e.Error is WebException)
            {

                Toast.MakeText(this, "კავშირი შეუძლებელია, სცადეთ ახლიდან", ToastLength.Long).Show();
                progressDialog.Dismiss();
            }
            else
            {
                Toast.MakeText(this, "არასწორი მონაცემები, სცადეთ ახლიდან", ToastLength.Long).Show();
                progressDialog.Dismiss();
            }
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
       
        

    }
}