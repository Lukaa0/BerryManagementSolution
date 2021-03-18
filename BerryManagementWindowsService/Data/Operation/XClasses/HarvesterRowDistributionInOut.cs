using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class HarvesterRowDistributionInOut
    {
        public Guid Id { get; set; }
        public bool Direction{ get; set; }
        public long? RowId { get; set; }
        public string RowBarCode { get; set; }
        public string HarvesterBarCode { get; set; }
        public string HarvesterName { get; set; }
        public long? HarvesterPersonPostId { get; set; }
        public DateTime Time { get; set; }
        public long UserPersonPostId { get; set; }
        public string UserName { get; set; }
        public bool IsComplete { get; set; }
        public string Error { get; set; }
    }
}
