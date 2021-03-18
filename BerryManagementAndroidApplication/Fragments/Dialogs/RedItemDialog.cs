using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace BerryManagementAndroidApplication.Fragments.Dialogs
{
    public class RedItemDialog : DialogFragment
    {
        private Button _retryBtn;
        private Button _deleteBtn;

        private int position;
        private IOnDialogItemClick callback;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            try
            {
                position = Arguments.GetInt("position");
                callback = (IOnDialogItemClick)TargetFragment;
            }
            catch (ClassCastException e)
            {
                throw new ClassCastException("Calling Fragment must implement OnAddFriendListener");
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            View view = inflater.Inflate(Resource.Layout.red_click_dialog_layout, container, false);
            _retryBtn = view.FindViewById<Button>(Resource.Id.dialog_send_again_btn);
            _retryBtn.Click += _retryBtn_Click;
            _deleteBtn= view.FindViewById<Button>(Resource.Id.dialog_delete_btn);
            return view;

        }

        private void _retryBtn_Click(object sender, EventArgs e)
        {
            callback.OnRetry(position);
        }

       
    }

    public interface IOnDialogItemClick
    {
        void OnRetry(int position);
        void OnDelete(int position);

    }
}