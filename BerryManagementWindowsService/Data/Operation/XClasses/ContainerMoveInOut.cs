using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation.XClasses
{
    public class ContainerMoveInOut
    {
        public long Id { get; set; }
        public string Error { get; set; }
        public Guid ContainerMoveInOut_Id { set; get; }
        public bool Direction { get; set; }
        public string ContainerBarCode { get; set; }
        public System.DateTime Time { get; set; }
        public long PersonPostId { get; set; }
        public long? Point_Id { get; set; }
        public bool IsComplete { get; set; }
        public long? Point_Car_Id { get; set; }
        public string PointBarcode { get; set; }

        public string ContainerMoveInOut_Car_Number { get; set; }
        public string ContainerMoveInOut_Car_Model { get; set; }

        public string ContainerMoveInOut_User_Point_Name { get; set; }
        public string ContainerMoveInOut_User_Point_BarCode { get; set; }

        
        public string ContainerMoveInOut_User_FullName { get; set; }

      
        public long ContainerMoveInOut_TransportWaybill_Id { get; set; }
       
       
        
        
       
        

    }
}
