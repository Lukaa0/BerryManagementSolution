using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Arch.Lifecycle;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;

namespace BerryManagementAndroidApplication.API
{
    public class ApplicationUpdateManager
    {
        private OperationService.BM_Operation_Service OperationService = new OperationService.BM_Operation_Service()
        {
            Url = GlobalVariables.OperationServiceUrl
        };



        public Activity Context { get; set; }
        //private string path = Path.Combine(
        //    Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,
        //        Android.OS.Environment.DirectoryDownloads), "BerryApp.apk");
        private string path = Path.Combine(Application.Context.FilesDir.Path, "BerryApp.apk");
        private ProgressDialog progressDialog;

        public ApplicationUpdateManager(Activity context)
        {
            OperationService.DownloadNewVersionCompleted += OperationService_DownloadNewVersionCompleted;
            Context = context;
        }

        private async void OperationService_DownloadNewVersionCompleted(object sender, OperationService.DownloadNewVersionCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && e.Result.Length > 0)
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }

                    using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                    {
                        await fs.WriteAsync(e.Result, 0, e.Result.Length);
                    }
                    InstallApp();
                }
            }
            catch (Exception ex)
            {
                API.Alerter.ErrorAlert(Context, ex.InnerException.ToString());
            }

            // if (e.Result == null || e.Result.Length < 1)
            //{
            //    progressDialog.Dismiss();
            //    Toast.MakeText(Context, "განახლება არ არის საჭირო", ToastLength.Long).Show();
            //    return;
            //}

            //var bytes = e.Result;
            //using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite))
            //{
            //    await fs.WriteAsync(bytes, 0, bytes.Length);
            //}

            //InstallApp();
        }

        public void GetCurrentVersion()
        {
            progressDialog = new ProgressDialog(Context);
            progressDialog.SetTitle("გთხოვთ მოიცადოთ");
            progressDialog.Show();
            OperationService.DownloadNewVersionAsync();
        }


        private void InstallApp()
        {
            Java.IO.File file = new Java.IO.File(path);
            var fileToInstall = file;

            fileToInstall.SetReadable(true);
            progressDialog.Dismiss();
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.N)
            {
                Android.Net.Uri apkUri = FileProvider.GetUriForFile(Context, Application.Context.PackageName + ".fileprovider", fileToInstall);
                Intent intent = new Intent(Intent.ActionInstallPackage);
                intent.SetData(apkUri);
                intent.SetFlags(ActivityFlags.GrantReadUriPermission);
                Context.StartActivity(intent);
            }
            else
            {
                Uri apkUri = Uri.FromFile(fileToInstall);
                Intent intent = new Intent(Intent.ActionView);
                intent.SetDataAndType(apkUri, "application/vnd.android.package-archive");
                intent.SetFlags(ActivityFlags.NewTask);
                Context.StartActivity(intent);
            }
        }

    }
}