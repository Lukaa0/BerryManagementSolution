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
    class ContainerPackRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ContainerPackRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<ContainerPackRecyclerViewAdapterClickEventArgs> ItemLongClick;

        public List<ContainerPackModel> items { get; set; }
        public List<string> containerCodes{ get; set; }
        private bool isBaseList;


        public ContainerPackRecyclerViewAdapter(List<ContainerPackModel> data)
        {
            items = data.OrderBy(x=>x.Time).ToList();
            this.isBaseList = true;
        }
        public ContainerPackRecyclerViewAdapter(List<string> data)
        {
            containerCodes = data;
            this.isBaseList = false;
        }
        

        public void Add(ContainerPackModel data)
        {
            items.Insert(0,data);
            
            NotifyItemInserted(0);
        }
        public void Add(string data)
        {
            containerCodes.Insert(0, data);

            NotifyItemInserted(0);
        }

        public ContainerPackModel GetItem(int position)
        {
                return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new ContainerPackRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {

            var holder = viewHolder as ContainerPackRecyclerViewAdapterViewHolder;
            if (isBaseList)
            {
                var item = items[position];

                if (!item.IsComplete)
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
                if (!string.IsNullOrEmpty(item.Error))
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FF4500"));
                holder.Time.Text = item.Time.ToString();
                holder.ContainerCode.Text = item.ContainerBarCode;
                holder.LocationCode.Text = item.Parent_ContainerBarCode;
                holder.UserName.Text = item.Pack_User_FullName;
            }
           
            else
            {
                var item = containerCodes[position];
                holder.ContainerCode.Text = item;
            }


        }

        public override int ItemCount => isBaseList ? items.Count : containerCodes.Count;

        void OnClick(ContainerPackRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ContainerPackRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        public void DeleteContainer(ContainerPackModel deleteContainer)
        {
            int index = items.FindIndex(x=>x.Id==deleteContainer.Id);
            items.Remove(deleteContainer);
            NotifyItemRemoved(index);
        }
    }

    public class ContainerPackRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView ContainerCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView UserName { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public ContainerPackRecyclerViewAdapterViewHolder(View itemView, Action<ContainerPackRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<ContainerPackRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            ContainerCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            UserName = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new ContainerPackRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new ContainerPackRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class ContainerPackRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}