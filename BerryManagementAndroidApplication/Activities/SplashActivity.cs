using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Support.V7.App;
using Android.Widget;
using BerryManagementAndroidApplication;
using BerryManagementAndroidApplication.Activities;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.SecurityService;
using BerryManagementAndroidApplication.Service;
using Java.Lang;
using Permission = Android.Content.PM.Permission;

[Activity(Theme = "@style/MyTheme.Splash", MainLauncher = true, NoHistory = true)]
public class SplashActivity : AppCompatActivity
{
    static readonly string TAG = "X:" + typeof(SplashActivity).Name;

    public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
    {
        base.OnCreate(savedInstanceState, persistentState);
    }

    // Launches the startup task
    protected override void OnResume()
    {
        base.OnResume();
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != (int)Android.Content.PM.Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.WriteExternalStorage }, 0);
        }

        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.ReadExternalStorage) != (int)Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage }, 0);
        }
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.RequestInstallPackages) != (int)Permission.Granted)
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.RequestInstallPackages }, 0);
        }
        



    }
    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
        if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) ==
            (int)Android.Content.PM.Permission.Granted)
        {

            //SetAlarmForBackgroundServices(this);

            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
           
        }
        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);

    }
    //private bool isMyServiceRunning(Class<?> serviceClass)
    //{
    //    ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
    //    foreach (ActivityManager.RunningServiceInfo service in manager.GetRunningServices(Integer.MaxValue)) ;
    //    {
    //        if (serviceClass.getName().equals(service.service.getClassName()))
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    // Simulates background work that happens behind the splash screen
    public static void SetAlarmForBackgroundServices(Context context)
    {
        Intent alarmIntent = new Intent(context.ApplicationContext, typeof(AlarmReceiver));
        var broadcast =
            PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, PendingIntentFlags.NoCreate);
        if (broadcast == null)
        {
            var pendingIntent = PendingIntent.GetBroadcast(context.ApplicationContext, 0, alarmIntent, 0);
            var alarmManager = (AlarmManager) context.GetSystemService(Context.AlarmService);
            alarmManager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, SystemClock.ElapsedRealtime(), 15000,
                pendingIntent);
        }
    }

    async void SimulateStartup()
    {
        var item = await LocalDbService<UserModel>.Instance.GetFirst();
        if (item != null)
        {
            StartActivity(typeof(MainActivity));
        }
        else
        {
            StartActivity(typeof(LoginActivity));
        }
    }
}