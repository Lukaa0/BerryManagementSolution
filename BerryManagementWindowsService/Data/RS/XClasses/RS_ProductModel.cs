using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public class RS_ProductModel
    {
        public string Product_Breed_Name { get; set; }
        public long Product_Ovner_Id { get; set; }
        public decimal Product_WeightsSum { set; get; }
        public int Product_ContainerCount { set; get; }
    }
}
