using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Produce.XClasses
{
    public class ProductModel
    {
        public System.Guid Product_Id { get; set; }
        public Nullable<System.Guid> Product_ParentProduct_Id { get; set; }
        public long Product_Row_Id { get; set; }
        public string Product_Row_Barkode { get; set; }
        public long Product_Harvester_PersonPost_Id { get; set; }
        public string Product_Harvester_FullName { get; set; }
        public string Product_Harvester_Barkode { get; set; }
        public long Product_User_PersonPost_Id { get; set; }
        public string Product_User_Barkode { get; set; }
        public string Product_User_FullName { get; set; }
        public System.DateTime Product_DateTime { get; set; }
        public long Product_Breed_Id { get; set; }
        public string Product_Breed_Name { get; set; }
        public string Product_Error { get; set; }
        public bool Product_IsComplete { get; set; }
    }
}
