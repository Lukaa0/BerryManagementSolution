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
using BerryManagementAndroidApplication.Model;

namespace BerryManagementAndroidApplication
{
    class HarvesteContainerDistributionListAdapter : BaseAdapter<HarvesterContainerDistribution>
    {
        private List<HarvesterContainerDistribution> mItems;
        private Context mContexct;
        public HarvesteContainerDistributionListAdapter(Context context,List<HarvesterContainerDistribution> items)
        {
            mItems = items;
            mContexct = context;
        }

        public override HarvesterContainerDistribution this[int position]
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
                row = LayoutInflater.From(mContexct).Inflate(Resource.Layout.HarvesterContainerDistributionRow, null, false);
            }
            TextView Container = row.FindViewById<TextView>(Resource.Id.ContainerCode);
            Container.Text = mItems[position].HarvesterContainerDistribution_ContainerBarCode;
            TextView Harvester = row.FindViewById<TextView>(Resource.Id.HarvesterCode);
            Harvester.Text = mItems[position].HarvesterContainerDistribution_HarvesterBarCode;
            TextView Date = row.FindViewById<TextView>(Resource.Id.DistributionDate);
            Date.Text = mItems[position].HarvesterContainerDistribution_DateTime.ToString();
            return row;
        }
    }
}