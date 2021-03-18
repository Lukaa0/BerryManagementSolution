using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses.ReportModel
{
    public class ReportModel
    {

        public long PersonPost_Id { get; set; }
        public string PersonPost_EmployeeBarCode { get; set; }
        public string PersonPost_Person_FullName { get; set; }
        public long PersonPost_Post_Id { get; set; }
        public string PersonPost_Post_Name { get; set; }
        public long? PersonPost_Brigade_Id { get; set; }
        public string PersonPost_Brigade_Name { get; set; }
        public long Punishment_Count { get; set; }
        public int Punishment_Name_First { get; set; }
        public int Punishment_Name_Second { get; set; }
        public long Recomendator_PersonPost_Id { get; set; }
        public long Recomendator_Punishment_Count { get; set; }
        public int Punishment_Given_First { get; set; }
        public int Punishment_Given_Second { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight_Average { get; set; }
        public decimal GrossWeight_Average { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Date
        {
            get
            {
                return ((DateTime)StartDate).ToString(@"dd MMM yyyy") + " - " + ((DateTime)EndDate.Value).ToString(@"dd MMM yyyy");
            }
        }
    }
}
