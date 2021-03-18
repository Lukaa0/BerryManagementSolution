using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication.Adapters
{
    public class TakeRowRecyclerViewAdapter : RecyclerView.Adapter
    {
        public event EventHandler<RowRecyclerViewAdapterClickEventArgs> ItemClick;
        public event EventHandler<RowRecyclerViewAdapterClickEventArgs> ItemLongClick;
        List<TakeRowInOut> _items;


        public TakeRowRecyclerViewAdapter(List<TakeRowInOut> data)
        {
            _items = data;

        }

        public void UpdateItems(List<TakeRowInOut> items)
        {
            _items = items;
            NotifyDataSetChanged();
        }

        
        public void Add(TakeRowInOut row)
        {
            _items.Insert(0,row);
            NotifyItemInserted(0);
        }

        public TakeRowInOut GetItem(int position)
        {

            return _items[position];
        }


        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            var id = Resource.Layout.row_item;
            var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new RowRecyclerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = _items[position];

            var holder = viewHolder as RowRecyclerViewAdapterViewHolder;
            if (!item.IsComplete)
                holder.Container.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
            else if (!string.IsNullOrEmpty(item.Error))
                holder.Container.SetCardBackgroundColor(Color.Red);
            holder.Time.Text = item.Time.ToString();
            holder.RowBarCode.Text = item.RowBarCode;


        }

        public override int ItemCount => _items.Count;

        void OnClick(RowRecyclerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(RowRecyclerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class RowRecyclerViewAdapterViewHolder : RecyclerView.ViewHolder
    {
        public TextView BrigadeId { get; set; }
        public TextView RowBarCode { get; set; }
        public TextView Time { get; set; }
        public CardView Container { get; set; }



        public RowRecyclerViewAdapterViewHolder(View itemView, Action<RowRecyclerViewAdapterClickEventArgs> clickListener,
                            Action<RowRecyclerViewAdapterClickEventArgs> longClickListener) : base(itemView)
        {
            BrigadeId = itemView.FindViewById<TextView>(Resource.Id.row_brigade_id);
            RowBarCode = itemView.FindViewById<TextView>(Resource.Id.row_barcode);
            Time = itemView.FindViewById<TextView>(Resource.Id.row_date);
            Container = itemView.FindViewById<CardView>(Resource.Id.takerow_item_container);
            itemView.Click += (sender, e) => clickListener(new RowRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new RowRecyclerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class RowRecyclerViewAdapterClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}