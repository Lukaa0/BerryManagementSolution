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
using Android.Views.Animations;
using Android.Widget;
using BerryManagementAndroidApplication.Adapters;
using BerryManagementAndroidApplication.API;
using BerryManagementAndroidApplication.Fragments;
using BerryManagementAndroidApplication.Model.LocalDataModels;
using BerryManagementAndroidApplication.OperationService;

namespace BerryManagementAndroidApplication.Model
{
    public class RowsFragment : Fragment
    {
        //private RecyclerView _recyclerView;
        //private ProgressBar _progressBar;
        //private List<HarvesterRowViewModel> _items;
        //private RowsAndHarvestersRecylcerViewAdapter _rowAdapter;
        //private SQLiteClient<HarvesterRowDistributionInOut> db;
        //BM_Operation_Service _operationService;
        //public override async void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    Activity.Title = "რიგები და მკრეფავები";
        //    _operationService = ServiceClient.Instance.OperationService;
        //    db = new SQLiteClient<HarvesterRowDistributionInOut>();
        //   await db.CreateTableAsync();
        //    // Create your fragment here
        //}

        //public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        //{
        //    base.OnCreateView(inflater, container, savedInstanceState);
        //    View view = inflater.Inflate(Resource.Layout.rows_main, container, false);
        //    _recyclerView = view.FindViewById<RecyclerView>(Resource.Id.row_main_recyclerview);
        //    _progressBar = view.FindViewById<ProgressBar>(Resource.Id.row_main_progressbar);
        //    return view;
        //}
        //public override void OnViewCreated(View view, Bundle savedInstanceState)
        //{
        //    base.OnViewCreated(view, savedInstanceState);
        //    string message = string.Empty;
        //    _operationService.GetJoinedHarvestersAsync(message);
        //    _operationService.GetJoinedHarvestersCompleted += async (sender, e) =>
        //    {
        //        if (e.Error != null)
        //        {
        //            var harvDist = await db.selectItems();
        //            _items = new List<HarvesterRowViewModel>();
        //            foreach (var item in harvDist)
        //            {
        //                _items.Add(new HarvesterRowViewModel()
        //                {
        //                    Date = item.HarvesterRowDistributionInOut_DateTime,
        //                    HarvesterBarCode = item.HarvesterRowDistributionInOut_HarvesterBarCode,
        //                    Id = item.HarvesterRowDistributionInOut_Id,
        //                    PersonId = item.HarvesterRowDistributionInOut_Harvester_PersonPost_Id,
        //                    RowBarCode = item.HarvesterRowDistributionInOut_Row_BarCode,

        //                });
        //            }

        //            _rowAdapter = new RowsAndHarvestersRecylcerViewAdapter(_items);
        //            SetupRecyclerView();
        //            _progressBar.Visibility = ViewStates.Gone;
        //        }
        //        else
        //        {
        //            _items = e.Result.ToList();
        //            _rowAdapter = new RowsAndHarvestersRecylcerViewAdapter(_items);
        //            SetupRecyclerView();
        //            _progressBar.Visibility = ViewStates.Gone;
        //        }
        //    };
        //}

        

        
        //private void SetupRecyclerView()
        //{
        //    LinearLayoutManager layoutManager = new LinearLayoutManager(Context);
        //    _recyclerView.SetLayoutManager(layoutManager);
        //    _recyclerView.NestedScrollingEnabled = false;
        //    _recyclerView.SetAdapter(_rowAdapter);
        //}
    }
}