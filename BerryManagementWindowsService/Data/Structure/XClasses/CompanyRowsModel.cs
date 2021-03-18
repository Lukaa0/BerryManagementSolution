using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure.XClasses
{
    public partial class CompanyRowsModel
    {
        public long CompanyRow_Id { get; set; }
        public long CompanyRow_Company_Id { get; set; }
        public string CompanyRow_Company_Name { get; set; }
        public long CompanyRow_Row_Id { get; set; }
        public System.DateTime CompanyRow_StartDate { get; set; }
        public System.DateTime? CompanyRow_EndDate { get; set; }
        public int CompanyRow_Sector_Number { get; set; }
        public int CompanyRow_Row_Number { get; set; }
        public string CompanyRow_Row_Subrow_Number { get; set; }
        public string CompanyRow_Row_Barkode { get; set; }
    }
}
