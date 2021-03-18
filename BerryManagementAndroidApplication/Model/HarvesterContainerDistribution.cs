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
    [Table ("HarvesterContainerDistribution")]
    class HarvesterContainerDistribution
    {
        [PrimaryKey , AutoIncrement]
        public int HarvesterContainerDistribution_id { get; set; }
        public string HarvesterContainerDistribution_HarvesterBarCode { get; set; }
        public string HarvesterContainerDistribution_ContainerBarCode { get; set; }
        public DateTime HarvesterContainerDistribution_DateTime { get; set; }
    }
}