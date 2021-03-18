using System;
using BerryManagementAndroidApplication.OperationService;
using SQLite;

namespace BerryManagementAndroidApplication.Model.LocalDataModels
{
    [Table("ProductReceiveLocal")]
    public  class ProductReceiveLocal
    {

        [PrimaryKey]
        public string Id { get; set; }
        public string ContainerBarCode { get; set; }

        public DateTime Date { get; set; }
        public string HarvesterBarCode { get; set; }

        public bool IsComplete { get; set; }

        public long ProductQualityId { get; set; }
        
        public long UserId { get; set; }

        public ProductReceiveLocal()
        {
            
        }
        //public ProductReceiveLocal(ProductQuality product)
        //{
        //    Id = product.ProductReceive_Id;
        //    ContainerBarCode = product.ProductReceive_ContainerBarCode;
        //    Date = product.ProductReceive_DateTime;
        //    HarvesterBarCode = product.ProductReceive_HarvesterBarCode;
        //    IsComplete = product.ProductReceive_ProcessIsComplite;
        //    ProductQualityId = product.ProductReceive_ProductQuality_Id;
        //    UserId = product.ProductReceive_User_PersonPost_Id;
        //}
        
    }
}