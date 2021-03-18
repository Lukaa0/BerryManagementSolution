using Android.Widget;
using Evernote.AndroidJob;

namespace BerryManagementAndroidApplication.Service
{
    public class BerrySyncJob: Job
    {
        public const  string TAG = "berry_job";

        protected override Result OnRunJob(Params @params)
        {
            Toast.MakeText(Context, "Done", ToastLength.Long).Show();
            return Result.Success;
        }
        
        public static void ScheduleJob()
        {
            new JobRequest.Builder(TAG)
                .SetRequiresDeviceIdle(false)
                .SetRequiredNetworkType(JobRequest.NetworkType.Connected)
                .SetPeriodic(300000, 300000)
                .SetUpdateCurrent(true)
                .Build()
                .Schedule();
        }
    }
}