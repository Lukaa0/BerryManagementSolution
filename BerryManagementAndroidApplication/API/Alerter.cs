using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BerryManagementAndroidApplication.API
{
    public static class Alerter
    {
        public static void ErrorAlert(Context context, string message)
        {
            AlertDialog.Builder builder;
            builder = new AlertDialog.Builder(context, Resource.Style.BM_AlertDialogStyle);
            builder.SetTitle("შეცდომა!!!");
            builder.SetMessage(message);
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", delegate
            {
                builder.Dispose();
            });
            Dialog dialog = builder.Create();
            Sounder.ErrorSound(context);
            dialog.Show();
        }

        public static async Task ErrorAlertAsync(Context context, string message)
        {
            ErrorAlert(context, message);
        }

        public static void NotificationAlert(Context context, string message)
        {
            AlertDialog.Builder builder;
            builder = new AlertDialog.Builder(context);
            builder.SetTitle("შეტყობინება!!!");
            builder.SetMessage(message);
            builder.SetCancelable(false);
            builder.SetPositiveButton("OK", delegate
            {
                builder.Dispose();
            });
            Dialog dialog = builder.Create();
            Sounder.ErrorSound(context);
            dialog.Show();
        }

        public static async Task NotificationAlertAsync(Context context, string message)
        {
            NotificationAlert(context, message);
        }
    }
}