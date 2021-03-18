using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Transitions;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Model;

namespace BerryManagementAndroidApplication.Fragments
{
    public class StartPageFragment : Fragment
    {
        
        private View view;

        public override  void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
           
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            base.OnCreateView(inflater, container, savedInstanceState);
            view =  inflater.Inflate(Resource.Layout.start_page_layout, container, false);

           
            return view;

        }
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            var activity = (MainActivity)Activity;
            activity.SetTitle();
        }



        private void FindViews()
        {

        }
    }
}