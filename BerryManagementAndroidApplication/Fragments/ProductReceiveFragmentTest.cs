using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Square.Picasso;

namespace BerryManagementAndroidApplication.Fragments
{
    public class ProductReceiveFragmentTest : Fragment
    {
        private TextView manualCode;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }
        

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.recieve_product_layout, container, false);
            manualCode = view.FindViewById<TextView>(Resource.Id.enter_code_manually_txt);
            
            
            return view;

        }
        

    }
}