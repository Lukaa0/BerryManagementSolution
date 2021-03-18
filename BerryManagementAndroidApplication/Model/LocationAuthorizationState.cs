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
    [Table("LocationAuthorizationState")]
    public class LocationAuthorizationState
    {
        [Column("IsAuthorized")]
        public bool IsAuthorized{ get; set; }
        [Column("PointID")]
        public long PointID { get; set; }
        [Column("PointTitle")]
        public string PointTitle { get; set; }

        public LocationAuthorizationState(bool isAuthorized)
        {
            IsAuthorized = isAuthorized;
        }

        public LocationAuthorizationState()
        {
                
        }
    }
}