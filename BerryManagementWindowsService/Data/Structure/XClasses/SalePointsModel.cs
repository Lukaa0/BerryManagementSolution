using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class SalePointsModel
    {
        public long Point_Id { get; set; }
        public string Point_Name { get; set; }
        public bool Point_IsActive { get; set; }
        public string Point_PointType_Id { get; set; }
        public string Point_BarCode { get; set; }
        public long? Point_Car_Id { get; set; }
        public string Point_Address { get; set; }
        public string Point_Description { get; set; }

        public string Point_Car_Number { get; set; }
        public string Point_Car_Model { get; set; }

        public string Point_PointType_Name { get; set; }
        public bool? Point_PointType_IsActive { get; set; }

        public bool Point_IsComplete { get; set; }
        public string Point_Error { get; set; }

    }
}
