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
    class PalleteAndContainerRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<ContainerInOutRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<ContainerInOutRecyclerViewAdapterClickEventArgs> ItemLongClick;

        public List<ContainerMoveInOut> items { get; set; }
        public List<string> containerCodes{ get; set; }
        private bool isBaseList;


        public PalleteAndContainerRecyclerViewAdapter(List<ContainerMoveInOut> data)
        {
            items = data.OrderBy(x=>x.Time).ToList();
            this.isBaseList = true;
        }
        public PalleteAndContainerRecyclerViewAdapter(List<string> data)
        {
            containerCodes = data;
            this.isBaseList = false;
        }
        

        public void Add(ContainerMoveInOut data)
        {
            items.Insert(0,data);
            
            NotifyItemInserted(0);
        }
        public void Add(string data)
        {
            containerCodes.Insert(0, data);

            NotifyItemInserted(0);
        }

        public ContainerMoveInOut GetItem(int position)
        {
                return items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.product_item_layout;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new ContainerInOutRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {

            var holder = viewHolder as ContainerInOutRecyclerViewAdapterViewHolder;
            if (isBaseList)
            {
                var item = items[position];

                if (!item.IsComplete)
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
                if (!string.IsNullOrEmpty(item.Error))
                    holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FF4500"));
                holder.Time.Text = item.Time.ToString();
                holder.ContainerCode.Text = item.ContainerBarCode;
                holder.LocationCode.Text = item.ContainerMoveInOut_User_Point_Name;
                holder.TransportCode.Text = item.ContainerMoveInOut_Car_Model;
            }
           
            else
            {
                var item = containerCodes[position];
                holder.ContainerCode.Text = item;
            }


        }

        public override int ItemCount => isBaseList ? items.Count : containerCodes.Count;

        void OnClick(ContainerInOutRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(ContainerInOutRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        public void DeleteContainer(ContainerMoveInOut deleteContainer)
        {
            int index = items.FindIndex(x=>x.ContainerMoveInOut_Id==deleteContainer.ContainerMoveInOut_Id);
            items.Remove(deleteContainer);
            NotifyItemRemoved(index);
        }
    }

    public class ContainerInOutRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView ContainerCode { get; set; }
        public TextView LocationCode { get; set; }
        public TextView TransportCode { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public ContainerInOutRecyclerViewAdapterViewHolder(View itemView, Action<ContainerInOutRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<ContainerInOutRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            ContainerCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            TransportCode = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new ContainerInOutRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new ContainerInOutRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class ContainerInOutRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}