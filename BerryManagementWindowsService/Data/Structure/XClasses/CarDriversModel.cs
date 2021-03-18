  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class CarDriversModel
    {
        public long CarDriver_Id { get; set; }
        public long CarDriver_Car_Id { get; set; }
        public string CarDriver_Car_Number { get; set; }
        public string CarDriver_Car_Model { get; set; }
        public long CarDriver_Person_Id { get; set; }
        public string CarDriver_Person_Name { get; set; }
        public string CarDriver_Person_Identity { get; set; }
        public long? CarDriver_PersonPost_Id { get; set; }
        public System.DateTime CarDriver_StartDate { get; set; }
        public System.DateTime? CarDriver_EndDate { get; set; }
        public bool CarDriver_IsResident { get; set; }
    }
}
