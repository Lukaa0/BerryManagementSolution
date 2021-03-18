using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
using System.Linq;

namespace BerryManagementAndroidApplication.Adapters
{
    class HarvesterContainerDistributionRecyclerViewAdapter : RecyclerView.Adapter 
    {
        public event EventHandler<HarvesterDistributionRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<HarvesterDistributionRecyclerViewAdapterClickEventArgs> ItemLongClick;
        List<HarvesterContainerDistributionInOut> items;


        public HarvesterContainerDistributionRecyclerViewAdapter(List<HarvesterContainerDistributionInOut> data)
        {
            items = data.OrderBy(x => x.Time).ToList();
        }

        public void Add(HarvesterContainerDistributionInOut data)
        {
            items.Insert(0, data);

            NotifyItemInserted(0);
        }

        public HarvesterContainerDistributionInOut GetItem(int position)
        {

            return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new HarvesterDistributionRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            var holder = viewHolder as HarvesterDistributionRecyclerViewAdapterViewHolder;
            if (!item.IsComplite)
                holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FF4500"));
            holder.Time.Text = item.Time.ToString();
            holder.ContainerCode.Text = item.HarvesterBarCode;
            holder.LocationCode.Text = item.HarvesterPersonPostId.ToString();


        }

        public override int ItemCount => items.Count;

        void OnClick(HarvesterDistributionRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(HarvesterDistributionRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class HarvesterDistributionRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView ContainerCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView TransportCode { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public HarvesterDistributionRecyclerViewAdapterViewHolder(View itemView, Action<HarvesterDistributionRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<HarvesterDistributionRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            ContainerCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            TransportCode = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new HarvesterDistributionRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new HarvesterDistributionRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class HarvesterDistributionRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}