using System;
using System.Collections.Generic;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.LibraryService;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication.Adapters
{
    //public class RowsAndHarvestersRecylcerViewAdapter : RecyclerView.Adapter
    //{
    //    public event EventHandler<RowsAndHarvestersRecylcerViewAdapterClickEventArgs> ItemClick;
    //    public event EventHandler<RowsAndHarvestersRecylcerViewAdapterClickEventArgs> ItemLongClick;
    //    List<HarvesterRowViewModel> _items;


    //    public RowsAndHarvestersRecylcerViewAdapter(List<HarvesterRowViewModel> data)
    //    {
    //        _items = data;

    //    }

    //    public void UpdateItems(List<HarvesterRowViewModel> items)
    //    {
    //        _items = items;
    //        NotifyDataSetChanged();
    //    }


    //    public void Add(HarvesterRowViewModel row)
    //    {
    //        _items.Add(row);
    //        NotifyItemInserted(_items.Count - 1);
    //    }

    //    public HarvesterRowViewModel GetItem(int position)
    //    {

    //        return _items[position];
    //    }


    //    // Create new views (invoked by the layout manager)
    //    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    //    {

    //        var id = Resource.Layout.row_item;
    //        var itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

    //        var vh = new RowsAndHarvestersRecylcerViewAdapterViewHolder(itemView, OnClick, OnLongClick);
    //        return vh;
    //    }

    //    public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
    //    {
    //        var item = _items[position];

    //        var holder = viewHolder as RowsAndHarvestersRecylcerViewAdapterViewHolder;
    //        holder.Time.Text = item.Date.ToString();
    //        holder.RowBarCode.Text = item.RowBarCode;
    //        holder.BrigadeId.Text = item.FirstName;
    //        holder.Lastname.Text = item.LastName;


    //    }

    //    public override int ItemCount => _items.Count;

    //    void OnClick(RowsAndHarvestersRecylcerViewAdapterClickEventArgs args) => ItemClick?.Invoke(this, args);
    //    void OnLongClick(RowsAndHarvestersRecylcerViewAdapterClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    //}

    //public class RowsAndHarvestersRecylcerViewAdapterViewHolder : RecyclerView.ViewHolder
    //{
    //    public TextView BrigadeId { get; set; }
    //    public TextView RowBarCode { get; set; }
    //    public TextView Time { get; set; }
    //    public TextView Lastname { get; set; }



    //    public RowsAndHarvestersRecylcerViewAdapterViewHolder(View itemView, Action<RowsAndHarvestersRecylcerViewAdapterClickEventArgs> clickListener,
    //                        Action<RowsAndHarvestersRecylcerViewAdapterClickEventArgs> longClickListener) : base(itemView)
    //    {
    //        BrigadeId = itemView.FindViewById<TextView>(Resource.Id.row_brigade_id);
    //        RowBarCode = itemView.FindViewById<TextView>(Resource.Id.row_barcode);
    //        Time = itemView.FindViewById<TextView>(Resource.Id.row_date);
    //        Lastname = itemView.FindViewById<TextView>(Resource.Id.lastname);

    //        itemView.Click += (sender, e) => clickListener(new RowsAndHarvestersRecylcerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
    //        itemView.LongClick += (sender, e) => longClickListener(new RowsAndHarvestersRecylcerViewAdapterClickEventArgs { View = itemView, Position = AdapterPosition });
    //    }
    //}

    //public class RowsAndHarvestersRecylcerViewAdapterClickEventArgs : EventArgs
    //{
    //    public View View { get; set; }
    //    public int Position { get; set; }
    //}
}