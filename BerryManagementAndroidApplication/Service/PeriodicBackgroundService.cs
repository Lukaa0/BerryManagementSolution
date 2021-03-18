
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication.Service
{
    [Service]
    class PeriodicBackgroundService : Android.App.Service
    {
        private const string Tag = "[PeriodicBackgroundService]";

        private bool _isRunning;
        private Context _context;
        private Task _task;
        private BM_Operation_Service operationService;
        private string _message;

        #region overrides

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnCreate()
        {
            _context = this;
            operationService = new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };
            _isRunning = false;
            _task = new Task(DoWork);
            
        }

        public override void OnDestroy()
        {
            _isRunning = false;

            //if (_task != null && _task.Status == TaskStatus.RanToCompletion)
            //{
            //    _task.Dispose();
            //}
            Intent broadcastIntent = new Intent(this, typeof(BootBroadcast));
            SendBroadcast(broadcastIntent);

        }

    public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
             if (!_isRunning&&_task.Status!=TaskStatus.Running)
            {
                _isRunning = true;
                _task = new Task(DoWork);
                _task.Start();
            }

            return StartCommandResult.Sticky;
        }
        public override void OnTaskRemoved(Intent rootIntent)
        {
            base.OnTaskRemoved(rootIntent);

            Intent broadcastIntent = new Intent(this, typeof(BootBroadcast));
            SendBroadcast(broadcastIntent);
        }
        #endregion

        private async void DoWork()
        {
            try
            {
                string message = string.Empty;
                var takerows =
                    (await LocalDbService<TakeRowInOut>.Instance.selectItems()).Where(x => x.IsComplete == false);
                foreach (var item in takerows)
                {

                    operationService.FixTakeRowInOut(item, ref message);
                }

            }
            catch (Exception e)
            {
                Log.WriteLine(LogPriority.Error, Tag, e.ToString());
            }

            _isRunning = false;
        }
    }

}