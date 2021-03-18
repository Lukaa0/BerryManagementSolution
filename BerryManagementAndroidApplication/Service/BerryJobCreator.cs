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
using Evernote.AndroidJob;

namespace BerryManagementAndroidApplication.Service
{
    public class BerryJobCreator : Java.Lang.Object, IJobCreator
    {
        
        public Job Create(string tag)
        {
            switch (tag)
            {
                case BerrySyncJob.TAG:
                {
                    return new BerrySyncJob();
                }
                default:
                    return null;
            }
        }

    
    }


}