using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace rstest
{
    public class savewaybill
    {
        string user = "405117172:405117172";
       string pass = "01009007381";
      //   string user = "ua_test:206322102";
       // string pass = "1234567";
        //string user = "infinati:12345678910";
        //string pass = "1234567";
        public XElement SaveWaybill(XElement waybill, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
                    new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.save_waybill(user, pass, waybill);
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SaveWayBill()" +
                        "()\n" + ex.Message;
            }
            return result;
        }

        public WayBillServiceReference.save_waybillRequest get_save_WaybillRequest()
        {
            WayBillServiceReference.save_waybillRequest result = new WayBillServiceReference.save_waybillRequest();
            result.Body = new WayBillServiceReference.save_waybillRequestBody();
            result.Body.su = user;
            result.Body.sp = pass;
            result.Body.waybill = createxelement();
            return result;
        }

        public XElement createxelement()
        {
            XElement result = XElement.Parse(@"<WAYBILL>
<SUB_WAYBILLS></SUB_WAYBILLS>
<GOODS_LIST>
<GOODS>
<ID>0</ID>
<W_NAME>წამალი #001</W_NAME>
<UNIT_ID>1</UNIT_ID>
<UNIT_TXT>წამალი</UNIT_TXT>
<QUANTITY>5</QUANTITY>
<PRICE>4</PRICE>
<STATUS>1</STATUS>
<AMOUNT>20</AMOUNT>
<BAR_CODE>psp101</BAR_CODE>
<A_ID>0</A_ID>
<VAT_TYPE>1</VAT_TYPE>
<QUANTITY_EXT>5</QUANTITY_EXT>
<WOOD_LABEL>asd</WOOD_LABEL>
<W_ID>1</W_ID>
</GOODS>
</GOODS_LIST>
              <ID>0</ID>
               <TYPE>2</TYPE>
               <BUYER_TIN>123654789</BUYER_TIN>
               <CHEK_BUYER_TIN>0</CHEK_BUYER_TIN>
               <BUYER_NAME>გიორგი გიორგაძე</BUYER_NAME>
                  <START_ADDRESS>თბილისი, საბურთალოს ქუჩა</START_ADDRESS>
                     <END_ADDRESS>თბილისი, გულუას ქუჩა</END_ADDRESS>
                        <DRIVER_TIN>25456854</DRIVER_TIN>
                        <CHEK_DRIVER_TIN>0</CHEK_DRIVER_TIN>
                        <DRIVER_NAME>ირაკლი</DRIVER_NAME>
                        <TRANSPORT_COAST>0</TRANSPORT_COAST>
                        <RECEPTION_INFO></RECEPTION_INFO>
                        <RECEIVER_INFO></RECEIVER_INFO>
                        <DELIVERY_DATE></DELIVERY_DATE>
                        <STATUS>0</STATUS>
                        <SELER_UN_ID></SELER_UN_ID>
                        <PAR_ID></PAR_ID>
                        <FULL_AMOUNT>20</FULL_AMOUNT>
                        <CAR_NUMBER></CAR_NUMBER>
                        <WAYBILL_NUMBER></WAYBILL_NUMBER>
                        <S_USER_ID>20350</S_USER_ID>
                        <BEGIN_DATE>2019-04-24T12:15:21</BEGIN_DATE>
                                <TRAN_COST_PAYER>1</TRAN_COST_PAYER>
                                <TRANS_ID>1</TRANS_ID>
                                <TRANS_TXT>სატვირთო მანქანა</TRANS_TXT>
                                   <COMMENT></COMMENT>                                   
                                      </WAYBILL>");
            return result;
        }

        public XElement geterrorcode(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_error_codes(user, pass);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public XElement get_trans_types(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_trans_types(user, pass);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public XElement get_waybill_types(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybill_types(user, pass);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public bool chek_service_user(out int un_id, out int s_user_id, ref string errorMessage)
        {
            un_id = 0;
            s_user_id = 0;
            bool result = false;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.chek_service_user(user, pass, out un_id, out s_user_id);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }
        
        public XElement get_waybills(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybills(user, pass, null, null, null, null, null, null, null, null, null, 
                    null, null, null, "0449664958", null, null, null, null);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public XElement get_waybill(int id, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybill(user, pass, id);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public XElement get_waybill_units(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybill_units(user, pass);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }

        public XElement get_waybill_unitws(ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
               // result = waybillsSoapClient.get_wat(user, pass);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }
    }
}
