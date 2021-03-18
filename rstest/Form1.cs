using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace rstest
{
    public partial class Form1 : Form
    {
        #region
        public Form1()
        {
            InitializeComponent();
        }

        savewaybill saveway = new savewaybill();
        private void button1_Click(object sender, EventArgs e)
        {
            XElement xelement = saveway.createxelement();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var v = saveway.get_save_WaybillRequest();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.get_save_WaybillRequest();
           // var v1 = saveway.SaveWaybill(v.Body.su, v.Body.sp, v.Body.waybill, ref errorMessage);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.geterrorcode(ref errorMessage);
            //var v1 = (from er in v.Elements("ERROR_CODE") where er.Element("ID").ToString() == "-101" select er.Element("TEXT").ToString()).FirstOrDefault();
            var v2 = v.Elements("ERROR_CODE").Where(el => el.Element("ID")?.Value.ToString() == "-101").
                Select(t => t.Element("TEXT")?.Value.ToString()).FirstOrDefault();
            var v3 = (from el in v.Elements("ERROR_CODE")
                      where (string)el.Element("ID") == "-101"
                      select el).ToList();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.get_trans_types(ref errorMessage);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.get_waybill_types(ref errorMessage);
            WaybillTypes waybillTypes = new WaybillTypes();
            waybillTypes.WAYBILL_TYPES = (from wt in v.Elements("WAYBILL_TYPE")
                                          select StaticMethods.XElementToObject<WaybillTypes.WAYBILL_TYPE>(wt, ref errorMessage)).ToList();
         }

        private void button7_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            int un_id = 0;
            int s_user_id = 0;
            var v = saveway.chek_service_user(out un_id, out s_user_id, ref errorMessage);
        }

        Waybill.RESULT _RESULT;
        private void button8_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            string source = @"<WAYBILL>
  <SUB_WAYBILLS></SUB_WAYBILLS>
  <GOODS_LIST>
    <GOODS>
      <ID>2666988066</ID>
      <W_NAME>ლურჯი მოცვი (O'Neal)</W_NAME>
      <UNIT_ID>2</UNIT_ID>
      <QUANTITY>83.248</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
    <GOODS>
      <ID>2666988067</ID>
      <W_NAME>ყუთი</W_NAME>
      <UNIT_ID>1</UNIT_ID>
      <QUANTITY>16</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
    <GOODS>
      <ID>2666988068</ID>
      <W_NAME>პუნეტი</W_NAME>
      <UNIT_ID>1</UNIT_ID>
      <QUANTITY>160</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
  </GOODS_LIST>
  <WOOD_DOCS_LIST></WOOD_DOCS_LIST>
  <ID>479586421</ID>
  <TYPE>1</TYPE>
  <CREATE_DATE>2019-05-30T12:55:14</CREATE_DATE>
  <BUYER_TIN>405117172</BUYER_TIN>
  <CHEK_BUYER_TIN>1</CHEK_BUYER_TIN>
  <BUYER_NAME>შპს ლურჯი ველი</BUYER_NAME>
  <START_ADDRESS>ოზურგეთი. დაბა ლაითური</START_ADDRESS>
  <END_ADDRESS>ოზურგეთი. სოფელი ნატანები</END_ADDRESS>
  <DRIVER_TIN>01026001573</DRIVER_TIN>
  <CHEK_DRIVER_TIN>1</CHEK_DRIVER_TIN>
  <DRIVER_NAME>ლევანი ლებანიძე</DRIVER_NAME>
  <TRANSPORT_COAST>0</TRANSPORT_COAST>
  <RECEPTION_INFO></RECEPTION_INFO>
  <RECEIVER_INFO></RECEIVER_INFO>
  <DELIVERY_DATE>2019-06-01T18:14:00</DELIVERY_DATE>
  <STATUS>2</STATUS>
  <SELER_UN_ID>2511517</SELER_UN_ID>
  <ACTIVATE_DATE>2019-05-30T12:55:14</ACTIVATE_DATE>
  <PAR_ID></PAR_ID>
  <FULL_AMOUNT>0</FULL_AMOUNT>
  <FULL_AMOUNT_TXT>ნული ლარი და ნული თეთრი</FULL_AMOUNT_TXT>
  <CAR_NUMBER>KK837DD</CAR_NUMBER>
  <WAYBILL_NUMBER>0454422051</WAYBILL_NUMBER>
  <CLOSE_DATE>2019-06-01T18:15:00</CLOSE_DATE>
  <S_USER_ID>292249</S_USER_ID>
  <BEGIN_DATE>2019-05-30T12:55:14</BEGIN_DATE>
  <TRAN_COST_PAYER>1</TRAN_COST_PAYER>
  <TRANS_ID>1</TRANS_ID>
  <TRANS_TXT></TRANS_TXT>
  <COMMENT>TW-1</COMMENT>
  <IS_CONFIRMED>1</IS_CONFIRMED>
  <INVOICE_ID></INVOICE_ID>
  <CONFIRMATION_DATE>01-JUN-19</CONFIRMATION_DATE>
  <SELLER_TIN>405117172</SELLER_TIN>
  <SELLER_NAME>შპს ლურჯი ველი</SELLER_NAME>
  <WOOD_LABELS></WOOD_LABELS>
  <CATEGORY>0</CATEGORY>
  <ORIGIN_TYPE>0</ORIGIN_TYPE>
  <ORIGIN_TEXT></ORIGIN_TEXT>
  <BUYER_S_USER_ID>0</BUYER_S_USER_ID>
  <TOTAL_QUANTITY>259.248</TOTAL_QUANTITY>
  <TRANSPORTER_TIN></TRANSPORTER_TIN>
  <CUST_STATUS>0</CUST_STATUS>
  <CUST_NAME></CUST_NAME>
</WAYBILL>";
            System.Xml.Linq.XElement xElement = XElement.Parse(source);
           // var v = StaticMethods.XElementToObject<Waybill.WaybillChacker.WAYBILL>(xElement, ref errorMessage);
            var v1 = StaticMethods.XElementToObject<Waybill.WAYBILL>(xElement, ref errorMessage);
            xElement.Name = "RESULT";
            xElement = XElement.Parse(xElement.ToString());
            var v2 = StaticMethods.XElementToObject<Waybill.RESULT>(xElement, ref errorMessage);
        }

        XElement _XElement;
        private void button9_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            _XElement = StaticMethods.ObjectToXElement<Waybill.RESULT>(_RESULT, ref errorMessage);
        }

        Waybill.RESULT _RESULT1;
        private void button10_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            _RESULT1 = StaticMethods.XElementToObject<Waybill.RESULT>(_XElement, ref errorMessage);
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            WaybillTypes.WAYBILL_TYPE wAYBILL_TYPE = new WaybillTypes.WAYBILL_TYPE();
            wAYBILL_TYPE.ID = 1;
            WaybillTypes waybillTypes = new WaybillTypes();
            waybillTypes.WAYBILL_TYPES = new List<WaybillTypes.WAYBILL_TYPE>();
            waybillTypes.WAYBILL_TYPES.Add(wAYBILL_TYPE);
            _XElement = StaticMethods.ObjectToXElement<WaybillTypes>(waybillTypes, ref errorMessage);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.get_waybills(ref errorMessage);
            List<Waybill.WAYBILL> list = (from wt in v.Elements("WAYBILL")
                                          select StaticMethods.XElementToObject<Waybill.WAYBILL>(wt, ref errorMessage)).ToList();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            int id = 479586421;
            string errorMessage = null;
            var v = saveway.get_waybill(id, ref errorMessage);
            string v1 = v.ToString();
            //var v2 = StaticMethods.XElementToObject<Waybill.WaybillChacker.WAYBILL>(v, ref errorMessage);
            var kv2 = StaticMethods.XElementToObject<Waybill.WAYBILL>(v, ref errorMessage);
            var t = StaticMethods.ObjectToXElement<Waybill.WAYBILL>(kv2, ref errorMessage);
            v.Name = "RESULT";
            var kv3 = StaticMethods.XElementToObject<Waybill.RESULT>(v, ref errorMessage);
        }
        #endregion



        Waybill.WAYBILL _WAYBILL;
        XElement _WAYBILLXElement;
        //შიდა გადაზიდვა
        private void button13_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            Waybill.WAYBILL.GOODS gOODS = new Waybill.WAYBILL.GOODS()
            {
                ID = 0,
                W_NAME = "prod 1",
                UNIT_ID = 2,
                UNIT_TXT = "",
                QUANTITY = 3.25m,
                PRICE = 1.5m,
                STATUS = 1,
                AMOUNT = 4.875m,
                BAR_CODE = "1",
                A_ID = 0,
                VAT_TYPE = 1,
                QUANTITY_EXT = 3.25m
            };



            this._WAYBILL = new Waybill.WAYBILL()
            {
                ID = 0,//----------------
                TYPE = 1,//------------
                BUYER_TIN = null,//
                CHEK_BUYER_TIN = null,//
                //BUYER_NAME = null,//
                //START_ADDRESS = "tbilisi 123",//--------------
                //END_ADDRESS = "tbilisi 1231",//---------------
                //DRIVER_TIN = "*",//-------------------
                //CHEK_DRIVER_TIN = 0 ,//----------------
                //DRIVER_NAME = "diver driverovich",//------------------
                //TRANSPORT_COAST = null,//
                //RECEPTION_INFO = null,//
                //RECEIVER_INFO = null,//
                //DELIVERY_DATE = null,//
                //STATUS = 1,//-------------------
                //SELER_UN_ID = 731937,//--------------
                //PAR_ID = null, //
                //FULL_AMOUNT = 4.875m,
                //CAR_NUMBER = "GT123GT",//----------------
                //WAYBILL_NUMBER = null, //
                //S_USER_ID = 142689,//-------------------
                //BEGIN_DATE = null,//
                //TRAN_COST_PAYER = null, //
                //TRANS_ID = 1,//----------------------
                TRANS_TXT = null,//
                COMMENT = "komment 1",//----------------
                CATEGORY = null,//
                GOODS_LIST = new List<Waybill.WAYBILL.GOODS>() { gOODS }
                
            };

            _WAYBILLXElement = StaticMethods.ObjectToXElement<Waybill.WAYBILL>(_WAYBILL, ref errorMessage);
           // Waybill.WAYBILL waybil = StaticMethods.XElementToObject<Waybill.WAYBILL>(_WAYBILLXElement, ref errorMessage);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.SaveWaybill(this._WAYBILLXElement, ref errorMessage);
        }

        //ტრანსპორტირების გარეშე
        private void button18_Click(object sender, EventArgs e)
        {

            string errorMessage = null;
            Waybill.WAYBILL.GOODS gOODS = new Waybill.WAYBILL.GOODS()
            {
                ID = 626019738,
                W_NAME = "prod 1",
                UNIT_ID = 2,
                UNIT_TXT = "",
                QUANTITY = 5m,
                PRICE = 2m,
                STATUS = 1,
                AMOUNT = 10m,
                BAR_CODE = "",
                A_ID = 0,
                VAT_TYPE = 1,
                QUANTITY_EXT = 3m
            };



            this._WAYBILL = new Waybill.WAYBILL()
            {
                ID = 472279055,//
                TYPE = 3,//
                //BUYER_TIN = "12345678910",//
                //CHEK_BUYER_TIN = 1,//
                //BUYER_NAME = "მყიდველი მყიდველაძე",//
                //START_ADDRESS = "tbilisi 123",//
                //END_ADDRESS = null,
                //DRIVER_TIN = null,
                //CHEK_DRIVER_TIN = null,
                //DRIVER_NAME = null,
                //TRANSPORT_COAST = null,
                //RECEPTION_INFO = null,
                //RECEIVER_INFO = null,
                //DELIVERY_DATE = null,
                //STATUS = 2,//
                //SELER_UN_ID = 731937,
                //PAR_ID = null,
                //FULL_AMOUNT = 10m,
                //CAR_NUMBER = null,
                //WAYBILL_NUMBER = null,
                //S_USER_ID = 142689,
                //BEGIN_DATE = null,
                TRAN_COST_PAYER = null,
                TRANS_ID = null,
                TRANS_TXT = null,
                COMMENT = null,
                CATEGORY = null,
                GOODS_LIST = new List<Waybill.WAYBILL.GOODS>() { gOODS }

            };

            _WAYBILLXElement = StaticMethods.ObjectToXElement<Waybill.WAYBILL>(_WAYBILL, ref errorMessage);
            Waybill.WAYBILL waybil = StaticMethods.XElementToObject<Waybill.WAYBILL>(_WAYBILLXElement, ref errorMessage);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.SaveWaybill(this._WAYBILLXElement, ref errorMessage);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            var v = saveway.get_waybill_units(ref errorMessage);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            string source = @"<WAYBILL>
  <SUB_WAYBILLS></SUB_WAYBILLS>
  <GOODS_LIST>
    <GOODS>
      <ID>2666988066</ID>
      <W_NAME>ლურჯი მოცვი (O'Neal)</W_NAME>
      <UNIT_ID>2</UNIT_ID>
      <QUANTITY>83.248</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
    <GOODS>
      <ID>2666988067</ID>
      <W_NAME>ყუთი</W_NAME>
      <UNIT_ID>1</UNIT_ID>
      <QUANTITY>16</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
    <GOODS>
      <ID>2666988068</ID>
      <W_NAME>პუნეტი</W_NAME>
      <UNIT_ID>1</UNIT_ID>
      <QUANTITY>160</QUANTITY>
      <PRICE>0</PRICE>
      <AMOUNT>0</AMOUNT>
      <BAR_CODE></BAR_CODE>
      <A_ID>0</A_ID>
      <VAT_TYPE>1</VAT_TYPE>
      <STATUS>1</STATUS>
    </GOODS>
  </GOODS_LIST>
  <WOOD_DOCS_LIST></WOOD_DOCS_LIST>
  <ID>479586421</ID>
  <TYPE>1</TYPE>
  <CREATE_DATE>2019-05-30T12:55:14</CREATE_DATE>
  <BUYER_TIN>405117172</BUYER_TIN>
  <CHEK_BUYER_TIN>1</CHEK_BUYER_TIN>
  <BUYER_NAME>შპს ლურჯი ველი</BUYER_NAME>
  <START_ADDRESS>ოზურგეთი. დაბა ლაითური</START_ADDRESS>
  <END_ADDRESS>ოზურგეთი. სოფელი ნატანები</END_ADDRESS>
  <DRIVER_TIN>01026001573</DRIVER_TIN>
  <CHEK_DRIVER_TIN>1</CHEK_DRIVER_TIN>
  <DRIVER_NAME>ლევანი ლებანიძე</DRIVER_NAME>
  <TRANSPORT_COAST>0</TRANSPORT_COAST>
  <RECEPTION_INFO></RECEPTION_INFO>
  <RECEIVER_INFO></RECEIVER_INFO>
  <DELIVERY_DATE>2019-06-01T18:14:00</DELIVERY_DATE>
  <STATUS>2</STATUS>
  <SELER_UN_ID>2511517</SELER_UN_ID>
  <ACTIVATE_DATE>2019-05-30T12:55:14</ACTIVATE_DATE>
  <PAR_ID></PAR_ID>
  <FULL_AMOUNT>0</FULL_AMOUNT>
  <FULL_AMOUNT_TXT>ნული ლარი და ნული თეთრი</FULL_AMOUNT_TXT>
  <CAR_NUMBER>KK837DD</CAR_NUMBER>
  <WAYBILL_NUMBER>0454422051</WAYBILL_NUMBER>
  <CLOSE_DATE>2019-06-01T18:15:00</CLOSE_DATE>
  <S_USER_ID>292249</S_USER_ID>
  <BEGIN_DATE>2019-05-30T12:55:14</BEGIN_DATE>
  <TRAN_COST_PAYER>1</TRAN_COST_PAYER>
  <TRANS_ID>1</TRANS_ID>
  <TRANS_TXT></TRANS_TXT>
  <COMMENT>TW-1</COMMENT>
  <IS_CONFIRMED>1</IS_CONFIRMED>
  <INVOICE_ID></INVOICE_ID>
  <CONFIRMATION_DATE>01-JUN-19</CONFIRMATION_DATE>
  <SELLER_TIN>405117172</SELLER_TIN>
  <SELLER_NAME>შპს ლურჯი ველი</SELLER_NAME>
  <WOOD_LABELS></WOOD_LABELS>
  <CATEGORY>0</CATEGORY>
  <ORIGIN_TYPE>0</ORIGIN_TYPE>
  <ORIGIN_TEXT></ORIGIN_TEXT>
  <BUYER_S_USER_ID>0</BUYER_S_USER_ID>
  <TOTAL_QUANTITY>259.248</TOTAL_QUANTITY>
  <TRANSPORTER_TIN></TRANSPORTER_TIN>
  <CUST_STATUS>0</CUST_STATUS>
  <CUST_NAME></CUST_NAME>
</WAYBILL>";
            System.Xml.Linq.XElement xElement = XElement.Parse(source);
            var v = saveway.SaveWaybill(xElement, ref errorMessage);
        }
    }
}
