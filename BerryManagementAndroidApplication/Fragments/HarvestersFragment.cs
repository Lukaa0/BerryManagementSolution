using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;

namespace BerryManagementAndroidApplication.Fragments
{
    public class HarvestersFragment : Fragment
    {
        private RecyclerView _recyclerView;
        private ProgressBar _progressBar;
        private HarvesterRecyclerViewAdapter _harvesterAdapter;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            View view = inflater.Inflate(Resource.Layout.rows_main, container, false);
            _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.row_main_recyclerview);
            _progressBar = view.FindViewById<ProgressBar>(Resource.Id.row_main_progressbar);
            return view;
        }
        public override async void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            string message = string.Empty;
            var harvesters = (await Task.Run(() => new EmployeeService.BM_Employee_Service().GetPersonPostsByBrigadeId(1,true,ref message))).ToList();
            _harvesterAdapter = new HarvesterRecyclerViewAdapter(harvesters);
            SetupRecyclerView();
            _progressBar.Visibility = ViewStates.Gone;
        }
        private void SetupRecyclerView()
        {
            GridLayoutManager layoutManager = new GridLayoutManager(Context, 2);
            _recyclerView.SetLayoutManager(layoutManager);
            _recyclerView.SetAdapter(_harvesterAdapter);
        }
    }
}