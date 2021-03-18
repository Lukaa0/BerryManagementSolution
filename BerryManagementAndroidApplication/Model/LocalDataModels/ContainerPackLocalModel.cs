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
using BerryManagementAndroidApplication.OperationService;
using BerryManagementAndroidApplication.StructureService;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
   public class ContainerPackLocalModel
    {
        private ContainerPackModel item;
        private OperationService.ProductPack item1;
        private StructureService.ProductPack item2;

        public ContainerPackLocalModel(string item)
        {
            Barcode = item;
            //TypeId =  item.Substring(2).ToString();
        }

        public ContainerPackLocalModel(ContainerPack container)
        {
            Barcode = container.ContainerPack_Container_BarCode;
            TypeId = container.ContainerPack_Container_BarCode.Take(2).ToString();
            
        }

        public ContainerPackLocalModel(ContainerPackModel item)
        {
            Barcode = item.ContainerBarCode;
            TypeId = item.ContainerBarCode.Take(2).ToString();

        }

        public ContainerPackLocalModel(OperationService.ProductPack item1)
        {
            Barcode = item1.ProductPack_Container_BarCode;
            TypeId = item1.ProductPack_Container_BarCode.Take(2).ToString();
        }

        public ContainerPackLocalModel(StructureService.ProductPack item2)
        {
            this.item2 = item2;
        }

        public string Barcode { get;  set; }
        public string TypeId { get;  set; }
        public bool Direction { get; set; }
    }
}