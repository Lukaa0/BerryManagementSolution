using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library.XClass
{
    public class ContainerModel
    {
        public string Container_BarCode { get; set; }
        public string Container_ContainerType_Id { get; set; }
        public bool Container_IsActive { get; set; }
        public long Container_PersonPost_Id { get; set; }
        public string Container_Harvester_FullName { get; set; }
    }
}
