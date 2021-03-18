//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
//using BerryManagementAndroidApplication.Model;
//using BerryManagementAndroidApplication.OperationService;
//using SQLite;
//using ZXing.Mobile;
//using Environment = Android.OS.Environment;

//namespace BerryManagementAndroidApplication.Fragments
//{
//    class ProductReceiveFragment : Fragment
//    {
//        private string _ContainerTextViewDefaultText = "კონტაინერის კოდი - ";
//        private string _HarvesterTextViewDefaultText = "მკრეფავის კოდი - ";
//        private string _PointerBarCode = GlobalVariables.PointBarCode;
//        private ProductReceiveListAdapter _ProductRecreiveadaptere;

//        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
//        {
//            base.OnCreateView(inflater, container, savedInstanceState);
//            var view = inflater.Inflate(Resource.Layout.ScannPoint_Fragment, null);
//            string dbPath = Path.Combine(
//               System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "BerryManagement_D.db");
//            var db = new SQLiteConnection(dbPath);


//            if (!string.IsNullOrEmpty(_PointerBarCode))
//            {

//                db.CreateTable<ProductQuality>();
//                if (db.Table<ProductQuality>().Count() == 0)
//                {
//                    ProductQuality productquealit1 = new ProductQuality()
//                    {
//                        ProductQuality_Quality = "ხარისხიანი"

//                    };
//                    ProductQuality productquealit2 = new ProductQuality()
//                    {
//                        ProductQuality_Quality = "უხარისხო"

//                    };
//                    db.Insert(productquealit1);
//                    db.Insert(productquealit2);
//                }

//                view = inflater.Inflate(Resource.Layout.productReceive_Fragment, null);
//                Button ScannContainerORHarvesterReceivingButton = view.FindViewById<Button>(Resource.Id.ScannContainerORHarvesterReceivingButton);
//                EditText ReceiverEditText = view.FindViewById<EditText>(Resource.Id.ReceiverEditText);
//                TextView ContainerReceivingEditText = view.FindViewById<TextView>(Resource.Id.ContainerReceivingTextView);
//                TextView HarvesterReceivingEditText = view.FindViewById<TextView>(Resource.Id.HarvesterReceivingTextView);
//                Button SaveProductReceiveInButton = view.FindViewById<Button>(Resource.Id.SaveProductReceiveInButton);
//                Spinner QualitySpinner = view.FindViewById<Spinner>(Resource.Id.QualitySpinner);
//                ListView ProductReceiveListView = view.FindViewById<ListView>(Resource.Id.ProductReceiveListView);
//                TextView PointName = view.FindViewById<TextView>(Resource.Id.PointName);
//                Button RemovePointbutton = view.FindViewById<Button>(Resource.Id.RemovePointbutton);
//                string ContainerCode = string.Empty;
//                String HarvesterCode = string.Empty;
//                db.CreateTable<ProductReceive>();
//                List<ProductReceive> tablee;
//                tablee = db.Table<ProductReceive>().ToList<ProductReceive>();

//                _ProductRecreiveadaptere = new ProductReceiveListAdapter(Context, tablee);
//                ProductReceiveListView.Adapter = _ProductRecreiveadaptere;



//                PointName.Text = _PointerBarCode;
//                db.CreateTable<ProductQuality>();

//                List<ProductQuality> ProductQualitytable = db.Table<ProductQuality>().ToList<ProductQuality>();
//                List<string> ProductQualityValue = new List<string>();
//                foreach (var item in ProductQualitytable)
//                {
//                    ProductQualityValue.Add(item.ProductQuality_Quality);
//                }
//                var Qualityadapter = new ArrayAdapter<string>(Context, Android.Resource.Layout.SimpleSpinnerItem, ProductQualityValue);
//                QualitySpinner.Adapter = Qualityadapter;



//                RemovePointbutton.Click += delegate (object sender, EventArgs e)
//                {
//                    GlobalVariables.PointBarCode = null;
//                    Fragment fragment = new ProductReceiveFragment();
//                    FragmentTransaction ft = this.FragmentManager.BeginTransaction();
//                    ft.Replace(Resource.Id.content_frame, fragment);
//                    ft.Commit();

//                };



//                ReceiverEditText.AfterTextChanged += (sender, args) =>
//                {
//                    string text = (sender as EditText).Text;
//                    if (!string.IsNullOrEmpty(text))
//                    {
//                        if (text.Length == 14)
//                        {
//                            if (text.Substring(0, 3) == "CF-")
//                            {
//                                ContainerCode = text;
//                                ContainerReceivingEditText.Text = _ContainerTextViewDefaultText + text;
//                                (sender as EditText).Text = string.Empty;
//                            }
//                            else
//                            {
//                                if (text.Substring(0, 3) == "PH-")
//                                {
//                                    HarvesterCode = text;
//                                    HarvesterReceivingEditText.Text = _HarvesterTextViewDefaultText + text;
//                                    (sender as EditText).Text = string.Empty;
//                                }
//                                else
//                                {
//                                    Android.Widget.Toast.MakeText(Context, "არაკორექტული კოდი", Android.Widget.ToastLength.Long).Show();
//                                }
//                            }
//                        }
//                    }
//                };



//                ScannContainerORHarvesterReceivingButton.Click += async delegate (object sender, EventArgs e)
//                {
//                    AllTask scan = new AllTask();
//                    var result = await scan.ScannBarCodeAsync(view);

//                    ReceiverEditText.Text = scan.HandleScanResult(result);

//                };



//                SaveProductReceiveInButton.Click += delegate
//                {

//                    try
//                    {
//                        var index = QualitySpinner.SelectedItemPosition;
//                        var Quality = ProductQualitytable[index].ProductQuality_Id;
//                        if (string.IsNullOrEmpty(ContainerCode) || string.IsNullOrEmpty(HarvesterCode))
//                        {
//                            Android.Widget.Toast.MakeText(Context, "დაასკანერეთ კოდი", Android.Widget.ToastLength.Long).Show();
//                        }
//                        else
//                        {


//                            db.CreateTable<ProductReceive>();
//                            ProductReceive model = new ProductReceive()
//                            {
//                                ProductReceive_HarvesterBarCode = HarvesterCode,
//                                ProductReceive_ContainerBarCode = ContainerCode,
//                                ProductReceive_DateTime = DateTime.Now,
//                                ProductReceive_ProductQuality_Id = Quality


//                            };
//                            db.Insert(model);
//                            Android.Widget.Toast.MakeText(Context, "წარმატებით შეინახა", Android.Widget.ToastLength.Long).Show();
//                            tablee = db.Table<ProductReceive>().ToList<ProductReceive>();

//                            _ProductRecreiveadaptere = new ProductReceiveListAdapter(Context, tablee);
//                            ProductReceiveListView.Adapter = _ProductRecreiveadaptere;

//                            ContainerReceivingEditText.Text = _ContainerTextViewDefaultText;
//                            HarvesterReceivingEditText.Text = _HarvesterTextViewDefaultText;

//                        }
//                    }
//                    catch (Exception)
//                    {

//                        throw;
//                    }

//                };

//            }
//            else
//            {
//                Button PointscannButton = view.FindViewById<Button>(Resource.Id.ScannPointButton);
//                EditText PointBarCodeEditText = view.FindViewById<EditText>(Resource.Id.PointBarCodeEditText);
//                TextView PointBarCodeTextView = view.FindViewById<TextView>(Resource.Id.PointBarCodeTextView);
//                Button savePointBarCodeInButton = view.FindViewById<Button>(Resource.Id.SavePointBarCodeButton);
//                string PointCode = string.Empty;
//                PointscannButton.Click += async delegate (object sender, EventArgs e)
//                {
//                    AllTask scan = new AllTask();
//                    var result = await scan.ScannBarCodeAsync(view);
//                    PointBarCodeEditText.Text = scan.HandleScanResult(result);


//                };
//                PointBarCodeEditText.AfterTextChanged += (sender, args) =>
//                {
//                    string text = (sender as EditText).Text;
//                    if (!string.IsNullOrEmpty(text))
//                    {
//                        if (text.Length == 14)
//                        {
//                            if (text.Substring(0, 3) == "LI-")
//                            {
//                                PointCode = text;
//                                PointBarCodeTextView.Text = "ადგილის კოდი - " + PointCode;
//                            }
//                            else
//                            {

//                                Android.Widget.Toast.MakeText(Context, "არაკორექტული კოდი", Android.Widget.ToastLength.Long).Show();
//                            }
//                        }
//                    }
//                };
//                savePointBarCodeInButton.Click += delegate
//                {
//                    try
//                    {
//                        if (!string.IsNullOrEmpty(PointCode))
//                        {
//                            GlobalVariables.PointBarCode = PointCode;
//                            Android.Widget.Toast.MakeText(Context, "წარმატებით შეინახა", Android.Widget.ToastLength.Long).Show();
//                            Fragment fragment = new ProductReceiveFragment();
//                            FragmentTransaction ft = this.FragmentManager.BeginTransaction();
//                            ft.Replace(Resource.Id.content_frame, fragment);
//                            ft.Commit();
//                        }
//                        else
//                        {
//                            Android.Widget.Toast.MakeText(Context, "დაასკანერეთ კოდი", Android.Widget.ToastLength.Long).Show();
//                        }

//                    }
//                    catch (Exception)
//                    {

//                        throw;
//                    }

//                };

//            }
//            return view;
//        }

//    }
//}