using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses.Pallete
{
    public class ContainerModel
    {
        public System.Guid ContainerPack_Id { get; set; }
        public string ContainerPack_Container_BarCode { get; set; }
        public string ContainerPack_Parent_Container_BarCode { get; set; }
        public System.DateTime ContainerPack_DateTime { get; set; }
        public long ContainerPack_User_PersonPost_Id { get; set; }
        public bool ContainerPack_IsComplite { get; set; }
        public System.Guid ContainerPack_Parent_ContainerLocation_In_Id { get; set; }

        public string BreedName { get; set; }
        public decimal? ContainerPack_NetWeight { get; set; }
        public decimal? ContainerPack_GrossWeight { get; set; }

    }
}
