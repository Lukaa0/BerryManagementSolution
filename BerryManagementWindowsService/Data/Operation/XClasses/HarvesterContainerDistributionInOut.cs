using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class HarvesterContainerDistributionInOut
    {
        
            public Guid Id { get; set; }
            public bool Direction { get; set; }
            public string ContaierBarcode { get; set; }
            public string HarvesterBarCode { get; set; }
            public string HarvesterName { get; set; }
            public long? HarvesterPersonPostId { get; set; }
            public long? CarId{ get; set; }
            public long? PointId { get; set; }
            public DateTime Time { get; set; }
            public long UserPersonPostId { get; set; }
            public bool IsComplite { get; set; }
        
    }
}
