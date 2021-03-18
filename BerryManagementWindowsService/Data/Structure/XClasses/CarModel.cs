using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public class CarModel
    {
        public long Car_Id { get; set; }
        public string Car_Number { get; set; }
        public string Car_Model { get; set; }
        public int Car_SideType_Id { get; set; }

        public string Car_SideType_Name { get; set; }
    }
}
