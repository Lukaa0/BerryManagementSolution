using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses.Pallete
{
    public class PalleteModel
    {
        public System.Guid ContainerWeight_Id { get; set; }
        public string ContainerWeight_Container_BarCode { get; set; }
        public decimal ContainerWeight_Net { get; set; }
        public decimal ContainerWeight_Gross { get; set; }
        public System.DateTime ContainerWeight_DateTime { get; set; }
        public long ContainerWeight_User_PersonPost_Id { get; set; }

        public DateTime? ContainerWeight_Start_DateTime { get; set; }
        public DateTime? ContainerWeight_End_DateTime { get; set; }
        public long Container_Count { get; set; }
    }
}
