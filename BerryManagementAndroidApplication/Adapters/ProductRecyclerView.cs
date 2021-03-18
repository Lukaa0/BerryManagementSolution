using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.ProduceService;

namespace BerryManagementAndroidApplication.Adapters
{
    public class ProductRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ProductRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<ProductRecyclerViewAdapterClickEventArgs> ItemLongClick;
         List<ProductModel> items;
        

        public ProductRecyclerViewAdapter(List<ProductModel> data)
        {
            items = data;
            
        }

        public void Add(ProductModel product)
        {
            items.Insert(0,product);
            NotifyItemInserted(0);
        }

        public ProductModel GetItem(int position)
        {
            
            return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);
            
            var vh = new ProductRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            var holder = viewHolder as ProductRecyclerViewAdapterViewHolder;
            holder.Time.Text = item.Product_DateTime.ToString();
            holder.HarvesterCode.Text = item.Product_Harvester_FullName;
            holder.ContainerCode.Text = item.Product_User_FullName;


        }

        public override int ItemCount => items.Count;

        void OnClick(ProductRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ProductRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class ProductRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView ContainerCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView HarvesterCode { get; set; }
        public TextView Time { get; set; }



        public ProductRecyclerViewAdapterViewHolder(View itemView, Action<ProductRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<ProductRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            ContainerCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            HarvesterCode = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);

            itemView.Click += (sender, e) => clickListener(new ProductRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new ProductRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class ProductRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}