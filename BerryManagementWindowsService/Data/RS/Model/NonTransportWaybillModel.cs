using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS.Model
{
    public class NonTransportWaybillModel
    {
        public long NonTransportWaybill_Id { get; set; }
        public int NonTransportWaybill_Type_Id { get; set; }
        public long NonTransportWaybill_TransportWaybill_Id { get; set; }
        public long NonTransportWaybill_CompanySeler_Id { get; set; }
        public long NonTransportWaybill_CompanyBuyer_Id { get; set; }
        public Nullable<long> NonTransportWaybill_RS_Id { get; set; }
        public string NonTransportWaybill_RS_Number { get; set; }
        public Nullable<System.DateTime> NonTransportWaybill_Start_DateTime { get; set; }
        public Nullable<System.DateTime> NonTransportWaybill_End_DateTime { get; set; }

        public string NonTransportWaybill__CompanySeler_Name { get; set; }
        public string NonTransportWaybill__CompanyBuyer_Name { get; set; }

        public long NonTransportWaybillDetail_State { get; set; }
    }
}
