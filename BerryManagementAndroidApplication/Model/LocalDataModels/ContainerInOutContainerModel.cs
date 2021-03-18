using System;
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
using BerryManagementAndroidApplication.StructureService;
using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    [Table("ContainerInOutContainerModel")]
    public class ContainerInOutContainerModel
    {
        public ContainerInOutContainerModel()
        {
                
        }

        public ContainerInOutContainerModel(Container container)
        {
            Barcode = container.Container_BarCode;
            TypeId = container.Container_ContainerType_Id;
            
        }

        public string Barcode { get;  set; }
        public string TypeId { get;  set; }
        public bool Direction { get; set; }
    }
}