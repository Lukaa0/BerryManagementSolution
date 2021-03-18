using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public static class WaybillPackageUploader
    {
        public static void UploadWaybillPackage(long transportWaybillId, bool isCorrected, ref string errorMessage)
        {
            List<NonTransportWaybill> nonTransportWaybills = 
                RS.SelectL.GetNonTransportWaybills(null, null, transportWaybillId, null, null, null, false, null, false, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            foreach(NonTransportWaybill nonTransportWaybill in nonTransportWaybills)
            {
                ChackNonTransportWaybill(nonTransportWaybill, isCorrected, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return;
                }
            }
            TransportWaybill transportWaybill =
                RS.SelectL.GetTransportWaybills(transportWaybillId, null, null, null, null, null, false, null, false,
                 null, false, null, false, ref errorMessage).FirstOrDefault();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            if (transportWaybill == null)
            {
                errorMessage = "ზედნადები არ მოიძებნა!";
                return;
            }
            ChackTransportWaybill(transportWaybill, isCorrected, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
        }

        private static void ChackNonTransportWaybill(NonTransportWaybill waybill, bool isCorrected, ref string errorMessage)
        {
            try
            {
                NonTransportWaybillDetail waybillDetail =
                    SelectL.GetNonTransportWaybillDetails(waybill.NonTransportWaybill_Id, null, null, ref errorMessage).FirstOrDefault();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return;
                }
                if (waybillDetail == null)
                {
                    errorMessage = "ზედნადები არ მოიძებნა!";
                    return;
                }
                if ((waybillDetail.NonTransportWaybillDetail_WaybillStatus != 0) || (isCorrected))
                {
                    string userName = "";
                    string password = "";
                    StaticMethods.GetOwnerCompanyInfo(waybill.NonTransportWaybill_CompanySeler_Id, out userName, out password, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return;
                    }
                    int waybillId = UploadNonTransportWaybill(waybill, waybillDetail, userName, password, isCorrected, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return;
                    }
                    if (waybillId > 0)
                    {
                        SaveNonTransportWaybillResult(waybillId, waybill, waybillDetail, userName, password, isCorrected, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  ChackNonTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  ChackNonTransportWaybill()\n" + ex.Message;
                }
            }
        }

        private static int UploadNonTransportWaybill(NonTransportWaybill waybill, NonTransportWaybillDetail waybillDetail,
            string userName, string password, bool isCorrected, ref string errorMessage)
        {
            int result = 0;
            try
            {
                WaybillContainer.RESULT uploadResult = null;
                XElement xWaybill = XElement.Parse(waybillDetail.NonTransportWaybillDetail_Waybill);
                WaybillContainer.WAYBILL nonTransportWaybill = Classes.Serializers.XElementToObject<WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                XElement xWaybills = WaybillProxyMethods.GetWaybills(userName, password, nonTransportWaybill.COMMENT, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                List<XElement> xElements = isCorrected ? new List<XElement>() : (from wt in xWaybills.Elements("WAYBILL") select wt).ToList();
                switch (xElements.Count)
                {
                    case 0:
                        {
                            XElement xResult = WaybillProxyMethods.UploadWaybill(userName, password, xWaybill, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return result;
                            }
                            uploadResult = Classes.Serializers.XElementToObject<WaybillContainer.RESULT>(xResult, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return result;
                            }
                            if (uploadResult.STATUS == 0)
                            {
                                result = uploadResult.ID;
                            }
                            else
                            {
                                waybillDetail.NonTransportWaybillDetail_Error = WaybillProxyMethods.GetErrorText(userName, password, uploadResult.STATUS.ToString());
                                errorMessage = waybillDetail.NonTransportWaybillDetail_Error;
                                waybillDetail.NonTransportWaybillDetail_WaybillStatus = uploadResult.STATUS;
                                Data.RS.Update.UpdateNonTransportWaybillDetail(waybillDetail, ref errorMessage);
                                return result;
                            }
                        }
                        break;
                    default:
                        result = int.Parse(xElements.First().Element("ID")?.Value.ToString());
                        break;
                }               
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  UploadNonTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  UploadNonTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        private static void SaveNonTransportWaybillResult(int waybillId, NonTransportWaybill waybill, NonTransportWaybillDetail waybillDetail,
            string userName, string password, bool isCorrected, ref string errorMessage)
        {
            XElement xWaybill = WaybillProxyMethods.GetWaybill(userName, password, waybillId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            WaybillContainer.WAYBILL waybillRS = Classes.Serializers.XElementToObject<WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            waybillDetail.NonTransportWaybillDetail_DateTime = isCorrected ? waybillDetail.NonTransportWaybillDetail_DateTime : DateTime.Now;
            waybillDetail.NonTransportWaybillDetail_Error = null;
            waybillDetail.NonTransportWaybillDetail_Waybill = xWaybill.ToString();
            waybillDetail.NonTransportWaybillDetail_WaybillStatus = waybillRS.STATUS;
            waybillDetail.NonTransportWaybillDetail_State = waybillDetail.NonTransportWaybillDetail_State + 1;
            waybill.NonTransportWaybill_RS_Id = waybillRS.ID;
            waybill.NonTransportWaybill_RS_Number = waybillRS.WAYBILL_NUMBER;

            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Data.RS.Update.UpdateNonTransportWaybillDetailWithOuterContext(context, waybillDetail, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            dbContextTransaction.Rollback();
                        }
                        Data.RS.Update.UpdateNonTransportWaybillWithOuterContext(context, waybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            dbContextTransaction.Rollback();
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  SaveNonTransportWaybillResult()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  SaveNonTransportWaybillResult()\n" + ex.Message;
                        }
                    }
                }
            }
        }

        private static void ChackTransportWaybill(TransportWaybill waybill, bool isCorrected, ref string errorMessage)
        {
            try
            {
                TransportWaybillDetail waybillDetail =
                   SelectL.GetTransportWaybillDetails(waybill.TransportWaybill_Id, null, null, ref errorMessage).FirstOrDefault();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return;
                }
                if (waybillDetail == null)
                {
                    errorMessage = "ზედნადები არ მოიძებნა!";
                    return;
                }
                if ((waybillDetail.TransportWaybillDetail_WaybillStatus != 0) || (isCorrected))
                {
                    string userName = "";
                    string password = "";
                    StaticMethods.GetOwnerCompanyInfo(waybill.TransportWaybill_Company_Id, out userName, out password, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return;
                    }
                    int waybillId = UploadTransportWaybill(waybill, waybillDetail, userName, password, isCorrected, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return;
                    }
                    if (waybillId > 0)
                    {
                        SaveTransportWaybillResult(waybillId, waybill, waybillDetail, userName, password, isCorrected, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  ChackTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  ChackTransportWaybill()\n" + ex.Message;
                }
            }
        }

        private static int UploadTransportWaybill(TransportWaybill waybill, TransportWaybillDetail waybillDetail,
            string userName, string password, bool isCorrected, ref string errorMessage)
        {
            int result = 0;
            try
            {
                WaybillContainer.RESULT uploadResult = null;
                XElement xWaybill = XElement.Parse(waybillDetail.TransportWaybillDetail_Waybill);
                WaybillContainer.WAYBILL transportWaybill = Classes.Serializers.XElementToObject<WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                XElement xWaybills = WaybillProxyMethods.GetWaybills(userName, password, transportWaybill.COMMENT, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                List<XElement> xElements = isCorrected ? new List<XElement>() : (from wt in xWaybills.Elements("WAYBILL") select wt).ToList();
                switch (xElements.Count)
                {
                    case 0:
                        {
                            XElement xResult = WaybillProxyMethods.UploadWaybill(userName, password, xWaybill, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return result;
                            }
                            uploadResult = Classes.Serializers.XElementToObject<WaybillContainer.RESULT>(xResult, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return result;
                            }
                            if (uploadResult.STATUS == 0)
                            {
                                result = uploadResult.ID;
                            }
                            else
                            {
                                waybillDetail.TransportWaybillDetail_Error = WaybillProxyMethods.GetErrorText(userName, password, uploadResult.STATUS.ToString());
                                errorMessage = waybillDetail.TransportWaybillDetail_Error;
                                waybillDetail.TransportWaybillDetail_WaybillStatus = uploadResult.STATUS;
                                Data.RS.Update.UpdateTransportWaybillDetail(waybillDetail, ref errorMessage);
                                return result;
                            }
                        }
                        break;
                    default:
                        result = int.Parse(xElements.First().Element("ID")?.Value.ToString());
                        break;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  UploadTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  UploadTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        private static void SaveTransportWaybillResult(int waybillId, TransportWaybill waybill, TransportWaybillDetail waybillDetail,
            string userName, string password, bool isCorrected, ref string errorMessage)
        {
            XElement xWaybill = WaybillProxyMethods.GetWaybill(userName, password, waybillId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            WaybillContainer.WAYBILL waybillRS = Classes.Serializers.XElementToObject<WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
            waybillDetail.TransportWaybillDetail_DateTime = isCorrected ? waybillDetail.TransportWaybillDetail_DateTime : DateTime.Now;
            waybillDetail.TransportWaybillDetail_Error = null;
            waybillDetail.TransportWaybillDetail_Waybill = xWaybill.ToString();
            waybillDetail.TransportWaybillDetail_WaybillStatus = waybillRS.STATUS;
            waybillDetail.TransportWaybillDetail_State = waybillDetail.TransportWaybillDetail_State + 1;
            waybill.TransportWaybill_RS_Id = waybillRS.ID;
            waybill.TransportWaybill_RS_Number = waybillRS.WAYBILL_NUMBER;

            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Data.RS.Update.UpdateTransportWaybillDetailWithOuterContext(context, waybillDetail, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            dbContextTransaction.Rollback();
                        }
                        Data.RS.Update.UpdateTransportWaybillWithOuterContext(context, waybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            dbContextTransaction.Rollback();
                        }
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  SaveTransportWaybillResult()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  SaveTransportWaybillResult()\n" + ex.Message;
                        }
                    }
                }
            }
        }


    }
}
