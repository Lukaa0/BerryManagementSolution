using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class TakeRows_Harvesters
    {
        public long BrigadeId { set; get; }
        public string BrigadeName { get; set; }
        public string RowBarCode { get; set; }
        public string HarvesterName { get; set; }
        public string HarvesterBarCode { get; set; }
    }
}
