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
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication
{
    //class ProductReceiveListAdapter : BaseAdapter<ProductReceive>
    //{
    //    private List<ProductReceive> mItems;
    //    private Context mContexct;
    //    public ProductReceiveListAdapter(Context context,List<ProductReceive> items)
    //    {
    //        mItems = items;
    //        mContexct = context;
    //    }

    //    public override ProductReceive this[int position]
    //    {
    //        get { return mItems[position]; }
    //    }


    //    public override int Count {
    //        get { return mItems.Count; }
    //    }

    //    public override long GetItemId(int position)
    //    {
    //        return position;
    //    }

    //    public override View GetView(int position, View convertView, ViewGroup parent)
    //    {
    //        View row = convertView;
    //        if (row == null)
    //        {
    //            row = LayoutInflater.From(mContexct).Inflate(Resource.Layout.ProductReceiveRow, null, false);
    //        }
    //        TextView Container = row.FindViewById<TextView>(Resource.Id.ContainerCode);
    //        Container.Text = mItems[position].ProductReceive_ContainerBarCode;
    //        TextView Harvester = row.FindViewById<TextView>(Resource.Id.HarvesterCode);
    //        Harvester.Text = mItems[position].ProductReceive_HarvesterBarCode;
    //        TextView Point = row.FindViewById<TextView>(Resource.Id.PointCode);
    //        TextView Quality = row.FindViewById<TextView>(Resource.Id.QualityID);
    //        Quality.Text = mItems[position].ProductReceive_ProductQuality_Id.ToString();
    //        TextView Date = row.FindViewById<TextView>(Resource.Id.ReceiveDate);
    //        Date.Text = mItems[position].ProductReceive_DateTime.ToString();
    //        return row;
    //    }
    //}
}