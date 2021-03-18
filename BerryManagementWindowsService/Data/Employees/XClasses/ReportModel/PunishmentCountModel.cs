using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses.ReportModel
{
    public class PunishmentCountModel
    {
        public long? PersonPost_Id { get; set; }
        public string Punishment_Name { get; set; }
        public long Punishment_Count { get; set; }
    }
}
