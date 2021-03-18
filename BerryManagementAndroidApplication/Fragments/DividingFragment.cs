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

namespace BerryManagementAndroidApplication.Fragments
{
    class DividingFragment:Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
          
            var view = inflater.Inflate(Resource.Layout.dividing_Fragment, null);
            ListView mainList = view.FindViewById<ListView>(Resource.Id.mainlistview);

            string[] items = new string[] {
            "Xamarin",
            "Android",
            "IOS",
            "Windows",
            "Xamarin-Native",
            "Xamarin-Forms"
            };
            ArrayAdapter<String> adapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, items);
            mainList.Adapter = adapter;

            mainList.ItemLongClick += (s, e) => {
                var t = items[e.Position];
                Android.Widget.Toast.MakeText(Context, t, Android.Widget.ToastLength.Long).Show();
                Bundle args = new Bundle();
                args.PutString("param", t);
                Fragment fragment = new DividingListFragment();
                fragment.Arguments = args;
                FragmentTransaction ft = this.FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.content_frame, fragment);
                ft.AddToBackStack(null);
                ft.Commit();
            };


            return view;
        }
    }
}