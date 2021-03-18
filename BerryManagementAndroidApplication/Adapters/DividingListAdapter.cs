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

namespace BerryManagementAndroidApplication
{
    class DividingListAdapter : BaseAdapter<ListItems>
    {
        private List<ListItems> mItems;
        private Context mContexct;
        public DividingListAdapter(Context context,List<ListItems> items)
        {
            mItems = items;
            mContexct = context;
        }

        public override ListItems this[int position]
        {
            get { return mItems[position]; }
        }

        public override int Count {
            get { return mItems.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(mContexct).Inflate(Resource.Layout.row, null, false);
            }
            TextView txt = row.FindViewById<TextView>(Resource.Id.textView);
            txt.Text = mItems[position].name;
            Button button = row.FindViewById<Button>(Resource.Id.button);
            button.Text = mItems[position].button;
            return row;
        }
    }
}