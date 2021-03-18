using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses
{
    public partial class PersonPostModel
    {
        public long PersonPost_Id { get; set; }
        public string PersonPost_EmployeeBarCode { get; set; }
        public long PersonPost_BalanceSheetType_Id { get; set; }
        public string PersonPost_BalanceSheetType_Name { get; set; }
        public long PersonPost_EmployeeType_Id { get; set; }
        public string PersonPost_EmployeeType_Name { get; set; }
        public long PersonPost_Person_Id { get; set; }
        public string PersonPost_Person_FullName { get; set; }
        public long PersonPost_Post_Id { get; set; }
        public string PersonPost_Post_Name { get; set; }
        public string PersonPost_Post_BarCodePrefix { get; set; }
        public long? PersonPost_Brigade_Id { get; set; }
        public string PersonPost_Brigade_Name { get; set; }
        public DateTime PersonPost_StartDate { get; set; }
        public DateTime? PersonPost_EndDate { get; set; }
        public string PersonPost_DismissalOrder { get; set; }
        public string PersonPost_Description { get; set; }
        public bool PersonPost_Direction { get; set; }
        
    }
}
