using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace rstest
{
    public class Waybill
    {
        [DataContract]
        public class WAYBILL
        {
            public int ID { set; get; }
            public int TYPE { set; get; }
            public string BUYER_TIN { set; get; }
            public string CHEK_BUYER_TIN { set; get; }
            public string BUYER_NAME { set; get; }
            public string START_ADDRESS { set; get; }
            public string END_ADDRESS { set; get; }
            public string DRIVER_TIN { set; get; }
            public string CHEK_DRIVER_TIN { set; get; }
            public string DRIVER_NAME { set; get; }
            public string TRANSPORT_COAST { set; get; }
            public string RECEPTION_INFO { set; get; }
            public string RECEIVER_INFO { set; get; }
            public string DELIVERY_DATE { set; get; }
            public int STATUS { set; get; }
            public int SELER_UN_ID { set; get; }
            public string PAR_ID { set; get; }
            public decimal FULL_AMOUNT { set; get; }
            public string CAR_NUMBER { set; get; }
            public string WAYBILL_NUMBER { set; get; }
            public int S_USER_ID { set; get; }
            public string BEGIN_DATE { set; get; }
            public string TRAN_COST_PAYER { set; get; }
            public string TRANS_ID { set; get; }
            public string TRANS_TXT { set; get; }
            public string COMMENT { set; get; }
            public string CATEGORY { set; get; }
            public List<GOODS> GOODS_LIST { set; get; }

            public class GOODS
            {
                public long ID { set; get; }
                public string W_NAME { set; get; }
                public int UNIT_ID { set; get; }
                public string UNIT_TXT { set; get; }
                public decimal QUANTITY { set; get; }
                public decimal PRICE { set; get; }
                public int STATUS { set; get; }
                public decimal AMOUNT { set; get; }
                public string BAR_CODE { set; get; }
                public int A_ID { set; get; }
                public int VAT_TYPE { set; get; }
                public decimal? QUANTITY_EXT { set; get; }
            }

            public class SUB_WAYBILLS
            {

            }
        }

        public class RESULT
        {
            public int ID { set; get; }
            public int STATUS { set; get; }
            public string WAYBILL_NUMBER { set; get; }
            public List<GOODS> GOODS_LIST { set; get; }

            public class GOODS
            {
                public string ERROR { set; get; }
                public long ID { set; get; }
                public string W_NAME { set; get; }
                public int UNIT_ID { set; get; }
                public string UNIT_TXT { set; get; }
                public decimal QUANTITY { set; get; }
                public decimal PRICE { set; get; }
                public decimal AMOUNT { set; get; }
                public string BAR_CODE { set; get; }
                public int A_ID { set; get; }
                public int STATUS { set; get; }
            }
        }

        public class WAYBILL_LIST
        {
            public List<WAYBILL> WAYBILLS { set; get; }
        }
        
       
    }
}

