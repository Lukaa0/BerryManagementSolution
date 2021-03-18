using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses.ReportModel
{
    public class RecPunishmentCountModel
    {
        public long? Recomendator_PersonPost_Id { get; set; }
        public string Recomendator_Punishment_Name { get; set; }
        public long Recomendator_Punishment_Count { get; set; }
    }
}
