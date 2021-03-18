using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Widget;
using BerryManagementAndroidApplication.OperationService;
using Matcha.BackgroundService;

namespace BerryManagementAndroidApplication.Service
{
    public class PeriodicWebCall : IPeriodicTask
    {
        public Context Context { get; set; }
        public string message = string.Empty;
        public BM_Operation_Service OperationService { get; set; }
        public PeriodicWebCall(int seconds, Context context)
        {
            Interval = TimeSpan.FromSeconds(seconds);
            this.Context = context;
            OperationService = new BM_Operation_Service()
            {
                Url = GlobalVariables.OperationServiceUrl
            };
        }

        public TimeSpan Interval { get; set; }

        public async Task<bool> StartJob()
        {
            await Task.Run(() =>{
                Console.WriteLine("Not sure if this gonna work");
                
            });
            return true;

        }
    }
}