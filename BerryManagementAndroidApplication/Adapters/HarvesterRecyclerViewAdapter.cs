using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.EmployeeService;

namespace BerryManagementAndroidApplication.Adapters
{
    class HarvesterRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<HarvesterRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<HarvesterRecyclerViewAdapterClickEventArgs> ItemLongClick;
        List<PersonPostModel> items;

        public HarvesterRecyclerViewAdapter(List<PersonPostModel> data)
        {
            items = data;
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
           var id = Resource.Layout.harvester_item_layout;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new HarvesterRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as HarvesterRecyclerViewAdapterViewHolder;
            holder.Barcode.Text = item.PersonPost_EmployeeBarCode;
            holder.StartDate.Text = item.PersonPost_StartDate.ToString();
            holder.EndDate.Text = item.PersonPost_EndDate.ToString();

        }

        public override int ItemCount => items.Count;

        void OnClick(HarvesterRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(HarvesterRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class HarvesterRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Barcode { get; set; }
        public TextView StartDate { get; set; }
        public TextView EndDate { get; set; }
        public HarvesterRecyclerViewAdapterViewHolder(View itemView, Action<HarvesterRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<HarvesterRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            Barcode = itemView.FindViewById<TextView>(Resource.Id.harvester_barcode);
            StartDate = itemView.FindViewById<TextView>(Resource.Id.harvester_start_date);
            EndDate = itemView.FindViewById<TextView>(Resource.Id.harvester_end_date);
            itemView.Click += (sender, e) => clickListener(new HarvesterRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new HarvesterRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class HarvesterRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}