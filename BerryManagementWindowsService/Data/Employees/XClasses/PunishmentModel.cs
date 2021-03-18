using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees.XClasses
{
    public class PunishmentModel
    {
        public System.Guid Punishment_Id { get; set; }
        public long Punishment_PunishmentType_Id { get; set; }
        public long Punishment_PersonPost_Id { get; set; }
        public string Punishment_Harvester_FullName { get; set; }
        public System.DateTime Punishment_DateTime { get; set; }
        public long Punishment_User_PersonPost_Id { get; set; }
        public string Punishment_User_FullName { get; set; }
        public string PunishmentType_Name { get; set; }
        public string Punishment_Description { get; set; }
        public bool IsComplete { get; set; }
        public string Error { get; set; }

        public long? Post_Id { get; set; }
        public string Post_Name { get; set; }
    }
}
