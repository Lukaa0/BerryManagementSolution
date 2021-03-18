using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class ContainerLocationModel
    {
        public long ContainerLocationId { set; get; }
        public string ContainerBarCode { set; get; }
        public long PointId { set; get; }
        public string PointName { set; get; }
        public DateTime PointStartDaeTime { set; get; }
    }
}
