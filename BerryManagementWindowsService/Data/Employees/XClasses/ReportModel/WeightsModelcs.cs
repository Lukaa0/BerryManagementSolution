using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses.ReportModel
{
    public class WeightsModelcs
    {
        public long Harvester_PersonPost_Id { get; set; }
        public long Reciever_PersonPost_Id { get; set; }
        public decimal NetWeight { get; set; }
        public decimal GrossWeight { get; set; }
        public decimal NetWeight_Average { get; set; }
        public decimal GrossWeight_Average { get; set; }
    }
}
