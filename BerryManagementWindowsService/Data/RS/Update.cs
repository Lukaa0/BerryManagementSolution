using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS
{
    public static class Update
    {
        public static void UpdateTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateTransportWaybillWithOuterContext(context, transportWaybill, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybill()\n" + ex.Message;
                }
            }
        }

        public static void UpdateTransportWaybillWithOuterContext(BerryManagementEntities context, TransportWaybill transportWaybill, 
            ref String errorMessage)
        {
            try
            {
                TransportWaybill transportWaybillT = SelectQ.GetTransportWaybills(context, transportWaybill.TransportWaybill_Id,
                    null, null, null, null, null, false, null, false, null, false, null, false, ref errorMessage).FirstOrDefault();
                if (transportWaybillT != null)
                {
                    transportWaybillT.TransportWaybill_Type_Id = transportWaybill.TransportWaybill_Type_Id;
                    transportWaybillT.TransportWaybill_Car_Point_Id = transportWaybill.TransportWaybill_Car_Point_Id;
                    transportWaybillT.TransportWaybill_Company_Id = transportWaybill.TransportWaybill_Company_Id;
                    transportWaybillT.TransportWaybill_RS_Id = transportWaybill.TransportWaybill_RS_Id;
                    transportWaybillT.TransportWaybill_RS_Number = transportWaybill.TransportWaybill_RS_Number;
                    transportWaybillT.TransportWaybill_Start_DateTime = transportWaybill.TransportWaybill_Start_DateTime;
                    transportWaybillT.TransportWaybill_End_DateTime = transportWaybill.TransportWaybill_End_DateTime;
                    transportWaybillT.TransportWaybill_Destination_Point_Id = transportWaybill.TransportWaybill_Destination_Point_Id;
                    transportWaybillT.TransportWaybill_Start_Point_Id = transportWaybill.TransportWaybill_Start_Point_Id;
                    context.SaveChanges();
                }
                else
                {
                    errorMessage = "შესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static void UpdateTransportWaybillDetail(TransportWaybillDetail transportWaybillDetail, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateTransportWaybillDetailWithOuterContext(context, transportWaybillDetail, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillDetail()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillDetail()\n" + ex.Message;
                }
            }
        }

        public static void UpdateTransportWaybillDetailWithOuterContext(BerryManagementEntities context, TransportWaybillDetail transportWaybillDetail,
            ref String errorMessage)
        {
            try
            {
                TransportWaybillDetail transportWaybillDetailT = SelectQ.GetTransportWaybillDetails(context,
                    transportWaybillDetail.TransportWaybillDetail_TransportWaybill_Id, null, null, ref errorMessage).FirstOrDefault();
                if (transportWaybillDetailT != null)
                {
                    transportWaybillDetailT.TransportWaybillDetail_DateTime = transportWaybillDetail.TransportWaybillDetail_DateTime;
                    transportWaybillDetailT.TransportWaybillDetail_Error = transportWaybillDetail.TransportWaybillDetail_Error;
                    transportWaybillDetailT.TransportWaybillDetail_Waybill = transportWaybillDetail.TransportWaybillDetail_Waybill;
                    transportWaybillDetailT.TransportWaybillDetail_WaybillStatus = transportWaybillDetail.TransportWaybillDetail_WaybillStatus;
                    transportWaybillDetailT.TransportWaybillDetail_State = transportWaybillDetail.TransportWaybillDetail_State;
                }
                else
                {
                    errorMessage = "შესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static void UpdateNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateNonTransportWaybillWithOuterContext(context, nonTransportWaybill, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybill()\n" + ex.Message;
                }
            }
        }

        public static void UpdateNonTransportWaybillWithOuterContext(BerryManagementEntities context, NonTransportWaybill nonTransportWaybill,
            ref String errorMessage)
        {
            try
            {
                NonTransportWaybill nonTransportWaybillT = SelectQ.GetNonTransportWaybills(context, nonTransportWaybill.NonTransportWaybill_Id,
                    null, null, null, null, null, false, null, false, ref errorMessage).FirstOrDefault();
                if (nonTransportWaybillT != null)
                {
                    nonTransportWaybillT.NonTransportWaybill_Type_Id = nonTransportWaybill.NonTransportWaybill_Type_Id;
                    nonTransportWaybillT.NonTransportWaybill_TransportWaybill_Id = nonTransportWaybill.NonTransportWaybill_TransportWaybill_Id;
                    nonTransportWaybillT.NonTransportWaybill_CompanySeler_Id = nonTransportWaybill.NonTransportWaybill_CompanySeler_Id;
                    nonTransportWaybillT.NonTransportWaybill_CompanyBuyer_Id = nonTransportWaybill.NonTransportWaybill_CompanyBuyer_Id;
                    nonTransportWaybillT.NonTransportWaybill_RS_Id = nonTransportWaybill.NonTransportWaybill_RS_Id;
                    nonTransportWaybillT.NonTransportWaybill_RS_Number = nonTransportWaybill.NonTransportWaybill_RS_Number;
                    nonTransportWaybillT.NonTransportWaybill_Start_DateTime = nonTransportWaybill.NonTransportWaybill_Start_DateTime;
                    nonTransportWaybillT.NonTransportWaybill_End_DateTime = nonTransportWaybill.NonTransportWaybill_End_DateTime;
                }
                else
                {
                    errorMessage = "შესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static void UpdateNonTransportWaybillDetail(NonTransportWaybillDetail nonTransportWaybillDetail, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateNonTransportWaybillDetailWithOuterContext(context, nonTransportWaybillDetail, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybill()\n" + ex.Message;
                }
            }
        }

        public static void UpdateNonTransportWaybillDetailWithOuterContext(BerryManagementEntities context, NonTransportWaybillDetail nonTransportWaybillDetail,
            ref String errorMessage)
        {
            try
            {
                NonTransportWaybillDetail nonTransportWaybillDetailT = SelectQ.GetNonTransportWaybillDetails(context, 
                    nonTransportWaybillDetail.NonTransportWaybillDetail_NonTransportWaybill_Id, null, null, ref errorMessage).FirstOrDefault();
                if (nonTransportWaybillDetailT != null)
                {
                    nonTransportWaybillDetailT.NonTransportWaybillDetail_DateTime = nonTransportWaybillDetail.NonTransportWaybillDetail_DateTime;
                    nonTransportWaybillDetailT.NonTransportWaybillDetail_Error = nonTransportWaybillDetail.NonTransportWaybillDetail_Error;
                    nonTransportWaybillDetailT.NonTransportWaybillDetail_Waybill = nonTransportWaybillDetail.NonTransportWaybillDetail_Waybill;
                    nonTransportWaybillDetailT.NonTransportWaybillDetail_WaybillStatus = nonTransportWaybillDetail.NonTransportWaybillDetail_WaybillStatus;
                    nonTransportWaybillDetailT.NonTransportWaybillDetail_State = nonTransportWaybillDetail.NonTransportWaybillDetail_State;
                }
                else
                {
                    errorMessage = "შესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
            }
        }
    }
}
