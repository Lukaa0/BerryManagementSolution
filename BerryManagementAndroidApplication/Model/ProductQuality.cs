using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace BerryManagementAndroidApplication.Model
{
    [Table ("ProductQuality")]
    class ProductQuality
    {
        [PrimaryKey , AutoIncrement]
        public int ProductQuality_Id { get; set; }
        public string ProductQuality_Quality { get; set; }
    }
}