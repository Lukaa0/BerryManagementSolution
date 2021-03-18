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

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    public class ContainersForPalette
    {
        [PrimaryKey]
        public int Id { get; set; }

        public string Barcode { get; set; }

        public ContainersForPalette()
        {
                
        }

        public ContainersForPalette(string barcode)
        {
            Barcode = barcode;
        }
    }

}