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
using static Android.App.ActionBar;

namespace BerryManagementAndroidApplication.Fragments
{
    class DividingListFragment:Fragment

    {
        private List<ListItems> mItems;
        DividingListAdapter adaptere;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
          
            var view = inflater.Inflate(Resource.Layout.dividingList_Fragment, null);

            if (Arguments != null)
            {
                String Text = Arguments.GetString("param");
                TextView FieldText = view.FindViewById<TextView>(Resource.Id.RowName);
                FieldText.Text = Text;


            }

            ListView mainList = view.FindViewById<ListView>(Resource.Id.AllPersonlistview);
            ListView SelectedList = view.FindViewById<ListView>(Resource.Id.SelectedPersonlistview);
            mainList.FastScrollEnabled = true;
            SelectedList.FastScrollEnabled = true;
            string[] items = new string[] {
            "ha",
            "hu",
            "me",
            "shen",
            };
            ArrayAdapter<String> adapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleListItem1, items);
            mainList.Adapter = adapter;
            List<Object> liste = new List<Object>();
            mItems = new List<ListItems>();
            mItems.Add(new ListItems() { name = "hahahah", button = "2" });
            mItems.Add(new ListItems() { name = "heee", button = "3" });
            mItems.Add(new ListItems() { name = "huuuuu", button = "4" });
            adaptere = new DividingListAdapter(Context, mItems);
            SelectedList.Adapter = adaptere;
            mainList.ItemLongClick += (s, e) =>
            {
               
                var t = items[e.Position];
                Android.Widget.Toast.MakeText(Context, t, Android.Widget.ToastLength.Long).Show();
                mItems.Add(new ListItems() { name = t, button = "remove" });
                adaptere.NotifyDataSetChanged();
               
            };
            
            return view;
        }


    }
}