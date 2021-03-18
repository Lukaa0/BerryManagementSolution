using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Exceptions;
using BerryManagementAndroidApplication.Model;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
namespace BerryManagementAndroidApplication.Adapters
{
    public class HarvesterRowDistributionRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<HarvesterRowRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<HarvesterRowRecyclerViewAdapterClickEventArgs> ItemLongClick;
        private List<HarvesterRowDistributionInOut> items;


        public HarvesterRowDistributionRecyclerViewAdapter(List<HarvesterRowDistributionInOut> data)
        {
            items = data.OrderBy(x => x.Time).ToList();
        }

        public void Add(HarvesterRowDistributionInOut data)
        {
            items.Insert(0, data);

            NotifyItemInserted(0);
        }

        public HarvesterRowDistributionInOut GetItem(int position)
        {

            return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new HarvesterRowRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            var holder = viewHolder as HarvesterRowRecyclerViewAdapterViewHolder;
            if (!item.IsComplete)
                holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
            else if (!string.IsNullOrEmpty(item.Error))
                holder.CardView.SetCardBackgroundColor(Color.Red);
            holder.Time.Text = item.Time.ToString();
            holder.HarvesterCode.Text = item.HarvesterBarCode;
            holder.LocationCode.Text = item.HarvesterPersonPostId.ToString();
            holder.HarvesterCode.Text = item.HarvesterBarCode;


        }

        public override int ItemCount => items.Count;

        void OnClick(HarvesterRowRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(HarvesterRowRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class HarvesterRowRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView HarvesterCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView TransportCode { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public HarvesterRowRecyclerViewAdapterViewHolder(View itemView, Action<HarvesterRowRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<HarvesterRowRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            HarvesterCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            TransportCode = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new HarvesterRowRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new HarvesterRowRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class HarvesterRowRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}