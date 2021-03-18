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
    class CarOpenCloseRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<CarOpenCloseRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<CarOpenCloseRecyclerViewAdapterClickEventArgs> ItemLongClick;
        public List<ContainerMoveInOut> items { get; set; }
        public List<string> containerCodes { get; set; }
        private bool isBaseList;


        public CarOpenCloseRecyclerViewAdapter(List<ContainerMoveInOut> data)
        {
            items = data.OrderBy(x => x.Time).ToList();
            //this.isBaseList = true;
        }
        public CarOpenCloseRecyclerViewAdapter(List<string> data)
        {
            containerCodes = data;
            //this.isBaseList = false;
        }

        public void Add(ContainerMoveInOut data)
        {
            items.Insert(0, data);

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

            var id = Resource.Layout.car_open_close_list_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new CarOpenCloseRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];
            var holder = viewHolder as CarOpenCloseRecyclerViewAdapterViewHolder;
            //if (isBaseList)
            //{
           
            //if (!item.IsComplete)
            //    holder.car.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
            //else if (!string.IsNullOrEmpty(item.Error))
            //    holder.Container.SetCardBackgroundColor(Color.Red);
          
            //    if (!item.IsComplete)
            //        holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
            //    if (!string.IsNullOrEmpty(item.Error))
            //        holder.CardView.SetCardBackgroundColor(Color.ParseColor("#FF4500"));

            //    holder.Time.Text = item.Time.ToString();
            //    holder.CarBarCode.Text = item.ContainerBarCode;
               //}
            //else
            //{
            //    var item = containerCodes[position];
            //    holder.CarBarCode.Text = item;
            //}


        }

        //public override int ItemCount => isBaseList ? items.Count : containerCodes.Count;
        public override int ItemCount => items.Count;

        void OnClick(CarOpenCloseRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(CarOpenCloseRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

        public void Delete(ContainerMoveInOut deleteContainer)
        {
            int index = items.FindIndex(x => x.ContainerMoveInOut_Id == deleteContainer.ContainerMoveInOut_Id);
            items.Remove(deleteContainer);
            NotifyItemRemoved(index);
        }
    }

    public class CarOpenCloseRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView CarBarCode { get; set; }
        public TextView UserName { get; set; }
        public TextView Time { get; set; }
        public CardView CardView { get; set; }



        public CarOpenCloseRecyclerViewAdapterViewHolder(View itemView, Action<CarOpenCloseRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<CarOpenCloseRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            CarBarCode = itemView.FindViewById<TextView>(Resource.Id.container_title);
            //LocationCode = itemView.FindViewById<TextView>(Resource.Id.location_title);
            //TransportCode = itemView.FindViewById<TextView>(Resource.Id.harvester_title);
            //Time = itemView.FindViewById<TextView>(Resource.Id.current_time);
            CardView = itemView.FindViewById<CardView>(Resource.Id.container_cardview);

            itemView.Click += (sender, e) => clickListener(new CarOpenCloseRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new CarOpenCloseRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class CarOpenCloseRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}