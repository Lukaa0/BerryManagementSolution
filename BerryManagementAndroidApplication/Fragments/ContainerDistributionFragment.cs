using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using BerryManagementAndroidApplication.Model;
using SQLite;
using ZXing.Mobile;
using Environment = Android.OS.Environment;

namespace BerryManagementAndroidApplication.Fragments
{
    class ContainerDistribution : Fragment
    {
        private string _ContainerTextViewDefaultText = "ყუთის კოდი - ";
        private string _HarvesterTextViewDefaultText = "მკრეფავის კოდი - ";
        private HarvesteContainerDistributionListAdapter _HarvesterContainerAdapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.containerDistribution_Fragment, null);
            Button scannButton = view.FindViewById<Button>(Resource.Id.ScannContainerORHarvesterButton);
            EditText receiveEDitText = view.FindViewById<EditText>(Resource.Id.ReceiverEditText);
            TextView containerTextView = view.FindViewById<TextView>(Resource.Id.ContainerTextView);
            TextView harvesterTextView = view.FindViewById<TextView>(Resource.Id.HarvesterTextView);
            Button saveHarvesterContainerDistributionInButton = view.FindViewById<Button>(Resource.Id.SaveHarvesterContainerDistributionInButton);
            ListView harvesterContainerDistributionInListView = view.FindViewById<ListView>(Resource.Id.HarvesterContainerDistributionInListView);
            string ContainerCode = string.Empty;
            String HarvesterCode = string.Empty;
            string dbPath = Path.Combine(
            System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BerryManagement_D.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<HarvesterContainerDistribution>();
            List<HarvesterContainerDistribution> table = db.Table<HarvesterContainerDistribution>().ToList<HarvesterContainerDistribution>();

            receiveEDitText.AfterTextChanged += (sender, args) =>
            {
                string text = (sender as EditText).Text;
                if (!string.IsNullOrEmpty(text))
                {
                    if (text.Length == 14)
                    {
                        string prefix = text.Substring(0, 3);
                        switch (prefix)
                        {
                            case "CF-":
                                {
                                    ContainerCode = text;
                                    containerTextView.Text = this._ContainerTextViewDefaultText + text;
                                    (sender as EditText).Text = string.Empty;
                                }
                                break;
                            case "PH-":
                                if (text.Substring(0, 3) == "PH-")
                                {
                                    HarvesterCode = text;
                                    harvesterTextView.Text = this._HarvesterTextViewDefaultText + text;
                                    (sender as EditText).Text = string.Empty;
                                }
                                break;
                            default:
                                Android.Widget.Toast.MakeText(Context, "არაკორექტული კოდი", Android.Widget.ToastLength.Long).Show();
                                break;
                        }
                    }
                }
            };

            this._HarvesterContainerAdapter = new HarvesteContainerDistributionListAdapter(Context, table);
            harvesterContainerDistributionInListView.Adapter = this._HarvesterContainerAdapter;
            scannButton.Click += async delegate (object sender, EventArgs e)
            {
                AllTask scan = new AllTask();
                var scannResult = await scan.ScannBarCodeAsync(view);
                receiveEDitText.Text = scan.HandleScanResult(scannResult);
            };
            saveHarvesterContainerDistributionInButton.Click += delegate
            {
                try
                {
                    if (string.IsNullOrEmpty(ContainerCode) || string.IsNullOrEmpty(HarvesterCode))
                    {
                        Android.Widget.Toast.MakeText(Context, "დაასკანერეთ კოდი", Android.Widget.ToastLength.Long).Show();
                        return;
                    }
                    db.CreateTable<HarvesterContainerDistribution>();
                    HarvesterContainerDistribution model = new HarvesterContainerDistribution()
                    {
                        HarvesterContainerDistribution_HarvesterBarCode = HarvesterCode,
                        HarvesterContainerDistribution_ContainerBarCode = ContainerCode,
                        HarvesterContainerDistribution_DateTime = DateTime.Now

                    };
                    db.Insert(model);
                    Android.Widget.Toast.MakeText(Context, "წარმატებით შეინახა", Android.Widget.ToastLength.Long).Show();
                    List<HarvesterContainerDistribution> tablee = db.Table<HarvesterContainerDistribution>().ToList<HarvesterContainerDistribution>();

                    this._HarvesterContainerAdapter = new HarvesteContainerDistributionListAdapter(Context, tablee);
                    harvesterContainerDistributionInListView.Adapter = this._HarvesterContainerAdapter;

                    containerTextView.Text = this._ContainerTextViewDefaultText;
                    harvesterTextView.Text = this._HarvesterTextViewDefaultText;
                }
                catch (Exception)
                {
                    throw;
                }
            };
            return view;
        }
    }
}