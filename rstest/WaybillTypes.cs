using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rstest
{
    public class WaybillTypes
    {
        public List<WAYBILL_TYPE> WAYBILL_TYPES { set; get; }

        public class WAYBILL_TYPE
        {
            public int ID { set; get; }
            public string NAME { set; get; }
        }
    }
}
