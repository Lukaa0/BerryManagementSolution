using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model;

namespace BerryManagementAndroidApplication.Adapters
{
    public class LocationRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<LocationRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<LocationRecyclerViewAdapterClickEventArgs> ItemLongClick;
        List<Point> items;

        public LocationRecyclerViewAdapter(List<Point> data)
        {
            items = data;
        }

        public Point GetItem(int position)
        {
            return items[position];
        }
        

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

           var id = Resource.Layout.locations_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new LocationRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            var holder = viewHolder as LocationRecyclerViewAdapterViewHolder;
            holder.Title.Text = item.Point_Name;

        }

        public override int ItemCount => items.Count;

        void OnClick(LocationRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(LocationRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class LocationRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView Title{ get; set; }



        public LocationRecyclerViewAdapterViewHolder(View itemView, Action<LocationRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<LocationRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            Title = itemView.FindViewById<TextView>(Resource.Id.location_item_title);
            itemView.Click += (sender, e) => 
            clickListener(new LocationRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => 
            longClickListener(new LocationRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class LocationRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}