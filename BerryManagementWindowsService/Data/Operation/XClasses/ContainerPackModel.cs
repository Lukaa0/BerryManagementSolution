using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class ContainerPackModel
    {
        public Guid Id { get; set; }
        public string Error { get; set; }

        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public string Parent_ContainerBarCode { get; set; }
        public System.DateTime Time { get; set; }
        public long PersonPostId { get; set; }
        public bool IsComplete { get; set; }

        public string Pack_User_FullName { get; set; }
        public bool UnpackIsComplete { get; set; }


    }
}
