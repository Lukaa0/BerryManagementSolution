using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class CompanyCarModel
    {
        public long CompanyCar_Id { get; set; }
        public long CompanyCar_Company_Id { get; set; }
        public string CompanyCar_Company_Name { get; set; }
        public long CompanyCar_Car_Id { get; set; }
        public string CompanyCar_Car_Number { get; set; }
        public string CompanyCar_Car_Model { get; set; }
        public System.DateTime CompanyCar_StartDate { get; set; }
        public Nullable<System.DateTime> CompanyCar_EndDate { get; set; }
    }
}
