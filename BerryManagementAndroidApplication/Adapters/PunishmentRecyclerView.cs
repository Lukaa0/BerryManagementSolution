using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using BerryManagementAndroidApplication.EmployeeService;

namespace BerryManagementAndroidApplication.Adapters
{
    class PunishmentRecyclerView : RecyclerView.Adapter
    {
        public event EventHandler<PunishmentRecyclerViewClickEventArgs> ItemClick;
        public event EventHandler<PunishmentRecyclerViewClickEventArgs> ItemLongClick;
        List<PunishmentModel> items;

        public PunishmentRecyclerView(List<PunishmentModel> data)
        {
            items = data;
        }

        public void Add(PunishmentModel model)
        {
            items.Insert(0, model);
            NotifyItemInserted(0);
        }

        // Create new views (invoked by the layout manager)
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {

            //Setup your layout here
            View itemView = null;
            var id = Resource.Layout.punishment_list_item;
            itemView = LayoutInflater.From(parent.Context).Inflate(id, parent, false);

            var vh = new PunishmentRecyclerViewViewHolder(itemView, OnClick, OnLongClick);
            return vh;
        }

        // Replace the contents of a view (invoked by the layout manager)
        public override void OnBindViewHolder(RecyclerView.ViewHolder viewHolder, int position)
        {
            var item = items[position];

            // Replace the contents of the view with that element
            var holder = viewHolder as PunishmentRecyclerViewViewHolder;
            holder.Date.Text = item.Punishment_DateTime.ToString();
            holder.HarvesterFullName.Text = item.Punishment_Harvester_FullName;
            holder.PunishmentName.Text = item.PunishmentType_Name;
            holder.UserName.Text = item.Punishment_User_FullName;
            if (!item.IsComplete)
                holder.Container.SetCardBackgroundColor(Color.ParseColor("#FFFF66"));
            if (!string.IsNullOrEmpty(item.Error))
                holder.Container.SetCardBackgroundColor(Color.ParseColor("#FF4500"));

        }

        public override int ItemCount => items.Count;

        void OnClick(PunishmentRecyclerViewClickEventArgs args) => ItemClick?.Invoke(this, args);
        void OnLongClick(PunishmentRecyclerViewClickEventArgs args) => ItemLongClick?.Invoke(this, args);

    }

    public class PunishmentRecyclerViewViewHolder : RecyclerView.ViewHolder
    {
        public TextView PunishmentName { get; set; }
        public TextView HarvesterFullName { get; set; }
        public TextView UserName { get; set; }
        public TextView Date { get; set; }
        public CardView Container { get; set; }


        public PunishmentRecyclerViewViewHolder(View itemView, Action<PunishmentRecyclerViewClickEventArgs> clickListener,
                            Action<PunishmentRecyclerViewClickEventArgs> longClickListener) : base(itemView)
        {
            PunishmentName = itemView.FindViewById<TextView>(Resource.Id.punishment_name);
            HarvesterFullName = itemView.FindViewById<TextView>(Resource.Id.punishment_harvester_name);
            UserName = itemView.FindViewById<TextView>(Resource.Id.punishment_user);
            Date = itemView.FindViewById<TextView>(Resource.Id.punishment_time);
            Container = itemView.FindViewById<CardView>(Resource.Id.punishment_container);

            itemView.Click += (sender, e) => clickListener(new PunishmentRecyclerViewClickEventArgs { View = itemView, Position = AdapterPosition });
            itemView.LongClick += (sender, e) => longClickListener(new PunishmentRecyclerViewClickEventArgs { View = itemView, Position = AdapterPosition });
        }
    }

    public class PunishmentRecyclerViewClickEventArgs : EventArgs
    {
        public View View { get; set; }
        public int Position { get; set; }
    }
}