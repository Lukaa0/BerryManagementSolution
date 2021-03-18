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
    class SaleRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<SaleRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<SaleRecyclerViewAdapterClickEventArgs> ItemLongClick;

        public List<SaleContainer> items { get; set; }
        public List<string> containerCodes{ get; set; }
        private bool isBaseList;


        public SaleRecyclerViewAdapter(List<SaleContainer> data)
        {
            items = data.OrderBy(x=>x.Time).ToList();
            this.isBaseList = true;
        }
        public SaleRecyclerViewAdapter(List<string> data)
        {
            containerCodes = data;
            this.isBaseList = false;
        }
        

        public void Add(SaleContainer data)
        {
            items.Insert(0,data);
            
            NotifyItemInserted(0);
        }
        public void Add(string data)
        {
            containerCodes.Insert(0, data);

            NotifyItemInserted(0);
        }

        public SaleContainer GetItem(int position)
        {
                return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new SaleRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {

            var holder = viewHolder as SaleRecyclerViewAdapterViewHolder;
            if (isBaseList)
            {
                var item = items[position];

                if (!item.IsComplete)
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
                if (!string.IsNullOrEmpty(item.Error))
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FF4500"));
                holder.Time.Text = item.Time.ToString();
                holder.ContainerCode.Text = item.ContainerBarCode;
                
            }
           
            else
            {
                var item = containerCodes[position];
                holder.ContainerCode.Text = item;
            }


        }

        public override int ItemCount => isBaseList ? items.Count : containerCodes.Count;

        void OnClick(SaleRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(SaleRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        public void DeleteContainer(SaleContainer deleteContainer)
        {
            int index = items.FindIndex(x=>x.Id==deleteContainer.Id);
            items.Remove(deleteContainer);
            NotifyItemRemoved(index);
        }
    }

    public class SaleRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView ContainerCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView UserName { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public SaleRecyclerViewAdapterViewHolder(View itemView, Action<SaleRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<SaleRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            ContainerCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            UserName = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new SaleRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new SaleRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class SaleRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}