using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses.ReportModel
{
    public class GeneralReportModel
    {
        public string CompanyName { get; set; }
        public string BreedName { get; set; }
        public decimal Sum { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
