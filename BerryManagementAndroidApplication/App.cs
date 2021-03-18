using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.EmployeeService;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.ProduceService;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.Service;
using BerryManagementAndroidApplication.StructureService;
using Evernote.AndroidJob;
using Matcha.BackgroundService.Droid;
using Container = BerryManagementAndroidApplication.StructureService.Container;

namespace BerryManagementAndroidApplication
{
    [Application]
    public class App :Application
    {
        public App(IntPtr javaReference, Android.Runtime.JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
        public override  async void OnCreate()
        {
            base.OnCreate();
            await LocalDbService<UserModel>.Instance.CreateTableAsync();
            await LocalDbService<HarvesterRowDistributionInOut>.Instance.CreateTableAsync();
            await LocalDbService<RowModel>.Instance.CreateTableAsync();
            await LocalDbService<tf_PunishmentTypes_Result>.Instance.CreateTableAsync();
            await LocalDbService<TakeRowInOut>.Instance.CreateTableAsync();
            await LocalDbService<EmployeeService.PersonPostModel>.Instance.CreateTableAsync();
            await LocalDbService<LibraryService.ContainerModel>.Instance.CreateTableAsync();
            await LocalDbService<PunishmentModel>.Instance.CreateTableAsync();
            await LocalDbService<PersonPostModelLocal>.Instance.CreateTableAsync();
            await LocalDbService<HarvesterRowDistributionRowModel>.Instance.CreateTableAsync();
            await LocalDbService<LocationAuthorizationState>.Instance.CreateTableAsync();
            await LocalDbService<Container>.Instance.CreateTableAsync();
            await LocalDbService<ProductModel>.Instance.CreateTableAsync();
            await LocalDbService<ContainerMoveInOut>.Instance.CreateTableAsync();
            await LocalDbService<SaleContainerModel>.Instance.CreateTableAsync();
            await LocalDbService<PointsModel>.Instance.CreateTableAsync();
            await LocalDbService<UserPermissionsModel>.Instance.CreateTableAsync();





        }

    }
}