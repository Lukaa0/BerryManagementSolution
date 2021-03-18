using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class PunishmentIn
    {
        public System.Guid Id { get; set; }
        public long? HardvesterPostId { get; set; }
        public string HardvesterBarcode { get; set; }
        public string ContainerBarcode { get; set; }
        public long? PunishmentTypeId { get; set; }
        public string PunishmentTypeName { get; set; }
        public long? QualityTypeId { get; set; }
        public string QualityTypeName { get; set; }
        public System.DateTime Time { get; set; }
        public long UserPersonPostId { get; set; }
        public bool IsComplite { set; get; }
    }
}
