using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public class WaybillProxyMethods
    {
        public static bool ChekServiceUser(string userName, string password, out int unicueId, out int userId, ref string errorMessage)
        {
            unicueId = 0;
            userId = 0;
            bool result = false;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient = new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.chek_service_user(userName, password, out unicueId, out userId);
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return result;
        }
                                 
        public static XElement UploadWaybill(string su, string sp, XElement waybill, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
                    new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.save_waybill(su, sp, waybill);
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "ზედნადების ატვირთვა ვერ მოხერხდა: SaveWayBill()" +
                        "()\n" + ex.Message;
            }
            return result;
        }

        public static XElement GetWaybill(string su, string sp, int waybill_id, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
                    new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybill(su, sp, waybill_id);
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "ზედნადების ჩამოტვირთვა ვერ მოხერხდა: GetWaybill()" +
                        "()\n" + ex.Message;
            }
            return result;
        }

        public static XElement GetWaybills(string su, string sp, string comment, ref string errorMessage)
        {
            XElement result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
                    new WayBillServiceReference.WayBillsSoapClient();
                result = waybillsSoapClient.get_waybills(su, sp, null, null, null, null, null, null, null, null, null,
                    null, null, null, null, null, null, null, comment);
            }
            catch (Exception ex)
            {
                errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
                        "ზედნადების ჩამოტვირთვა ვერ მოხერხდა: GetWaybill()" +
                        "()\n" + ex.Message;
            }
            return result;
        }

        public static string GetErrorText(string su, string sp, string errorCode)
        {
            string result = null;
            try
            {
                WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
                    new WayBillServiceReference.WayBillsSoapClient();
                XElement errors = waybillsSoapClient.get_error_codes(su, sp);
                result = errors.Elements("ERROR_CODE").Where(el => el.Element("ID")?.Value.ToString() == errorCode).
                    Select(t => t.Element("TEXT")?.Value.ToString()).First();
            }
            catch (Exception ex)
            {
                result = errorCode;
            }
            return result;
        }

        //public static int SaveWaybill_Tamplate(string su, string sp, string v_name, XElement waybill, ref string errorMessage)
        //{
        //    int result = 0;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.save_waybill_tamplate(su, sp, v_name, waybill);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SaveWaybill_Tamplate()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static int SaveWaybill_Transporter(string su, string sp, int waybill_id, string car_number, 
        //    string driver_tin, int chek_driver_tin, string driver_name, int trans_id, string trans_txt, 
        //    string reception_info, string receiver_info, ref string errorMessage)
        //{
        //    int result = 0;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.save_waybill_transporter(su, sp, waybill_id, car_number, driver_tin, chek_driver_tin,
        //            driver_name, trans_id, trans_txt, reception_info, receiver_info);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SaveWaybill_Transporter()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}


        //public static string SendWaybill(string su, string sp, int waybill_id, ref string errorMessage)
        //{
        //    string result = null;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.send_waybill(su, sp, waybill_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SendWaybill()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static string SendWaybill_vd(string su, string sp, DateTime begin_date, int waybill_id, ref string errorMessage)
        //{
        //    string result = null;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.send_waybil_vd(su, sp, begin_date, waybill_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SendWaybill_vd()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static int SendWaybill_transporter(string su, string sp, int waybill_id, DateTime begin_date,
        //    out string waybill_number, ref string errorMessage)
        //{
        //    int result = 0;
        //    waybill_number = null;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.send_waybill_transporter(su, sp, waybill_id, begin_date, out waybill_number);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: SendWaybill_transporter()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static int CloseWaybill(string su, string sp, int waybill_id, ref string errorMessage)
        //{
        //    int result = 0;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.close_waybill(su, sp, waybill_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: CloseWaybill()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static int CloseWaybill_vd(string su, string sp, DateTime delivery_date, int waybill_id, ref string errorMessage)
        //{
        //    int result = 0;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.close_waybill_vd(su, sp, delivery_date, waybill_id);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: CloseWaybill_vd()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}

        //public static int CloseWaybill_transporter(string su, string sp, int waybill_id, string reception_info,
        //    string receiver_info, DateTime delivery_date, ref string errorMessage)
        //{
        //    int result = 0;
        //    try
        //    {
        //        WayBillServiceReference.WayBillsSoapClient waybillsSoapClient =
        //            new WayBillServiceReference.WayBillsSoapClient();
        //        result = waybillsSoapClient.close_waybill_transporter(su, sp, waybill_id, reception_info, receiver_info, delivery_date);
        //    }
        //    catch (Exception ex)
        //    {
        //        errorMessage = (System.String.IsNullOrEmpty(errorMessage) ? "" : (errorMessage + "\n")) +
        //                "ჩანაწერის დაფიქსირება ვერ მოხერხდა: CloseWaybill_transporter()" +
        //                "()\n" + ex.Message;
        //    }
        //    return result;
        //}
    }
}
