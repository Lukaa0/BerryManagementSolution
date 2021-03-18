using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class ContainerInOut
    {
        public string Id { get; set; }
        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public string TransportBarCode { get; set; }
        public System.DateTime Date { get; set; }
        public long PersonPostId { get; set; }
        public long Point_Id { get; set; }
        public bool IsComplete { get; set; }
    }
}
