using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS.Model
{
    public class TransportWaybillModel
    {
        public long TransportWaybill_Id { get; set; }
        public int TransportWaybill_Type_Id { get; set; }
        public long TransportWaybill_Car_Point_Id { get; set; }
        public long TransportWaybill_Car_Id { get; set; }
        public long TransportWaybill_Company_Id { get; set; }
        public Nullable<long> TransportWaybill_Start_Point_Id { get; set; }
        public Nullable<long> TransportWaybill_Destination_Point_Id { get; set; }
        public Nullable<long> TransportWaybill_RS_Id { get; set; }
        public string TransportWaybill_RS_Number { get; set; }
        public Nullable<System.DateTime> TransportWaybill_Start_DateTime { get; set; }
        public Nullable<System.DateTime> TransportWaybill_End_DateTime { get; set; }

        public string TransportWaybill_CarNumber { get; set; }
        public string TransportWaybill_Company_Name { get; set; }

        public long TransportWaybillDetail_State { get; set; }
    }
}
