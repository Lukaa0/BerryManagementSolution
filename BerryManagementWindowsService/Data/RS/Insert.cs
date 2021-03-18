using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS
{
    public static class Insert
    {
        public static long InsertTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = InsertTransportWaybillWithOuterContext(context, transportWaybill, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertTransportWaybillWithOuterContext(BerryManagementEntities context, TransportWaybill transportWaybill, ref string errorMessage)
        {
            long result = 0;
            try
            {
                TransportWaybill transportWaybillT = SelectL.GetTransportWaybills(null, transportWaybill.TransportWaybill_Type_Id,
                    transportWaybill.TransportWaybill_Car_Point_Id, transportWaybill.TransportWaybill_Car_Id, 
                    transportWaybill.TransportWaybill_Company_Id, null, true, null, true, null, true, null, true,
                    ref errorMessage).FirstOrDefault();
                if (transportWaybillT != null)
                {
                    result = transportWaybillT.TransportWaybill_Id;
                }
                else
                {
                    context.TransportWaybills.Add(transportWaybill);
                    context.SaveChanges();
                    result = transportWaybill.TransportWaybill_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertTransportWaybillWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertTransportWaybillWithOuterContext()\n" + ex.Message;
                }
            }
            return result;
        }

        public static Data.TransportWaybill InsertTransportWaybillCompanyMove(string barCode, bool direction, ref string errorMessage)
        {
            Data.TransportWaybill result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    TransportWaybill checkTransport = null;

                    Point Allpoint = context.Points.Where(c => c.Point_BarCode == barCode).FirstOrDefault();
                    if (direction)
                    {
                        checkTransport = context.TransportWaybills.Where(c =>
                                            c.TransportWaybill_Start_Point_Id == null &&
                                            c.TransportWaybill_Destination_Point_Id == null &&
                                            c.TransportWaybill_Car_Point_Id == Allpoint.Point_Id &&
                                            c.TransportWaybill_Car_Id == Allpoint.Point_Car_Id).FirstOrDefault();
                    }
                    else
                    {
                        checkTransport = context.TransportWaybills.Where(c =>
                                           c.TransportWaybill_Start_Point_Id != null &&
                                           c.TransportWaybill_Destination_Point_Id != null &&
                                           c.TransportWaybill_Car_Point_Id == Allpoint.Point_Id &&
                                           c.TransportWaybill_Car_Id == Allpoint.Point_Car_Id &&
                                           c.TransportWaybill_RS_Id != null &&
                                           c.TransportWaybill_End_DateTime == null).FirstOrDefault();
                    }

                        if (checkTransport != null)
                        {
                            result = checkTransport;
                        }
                        else
                        {
                            TransportWaybill transportWaybill = new TransportWaybill();
                            Point points = context.Points.Where(c => c.Point_BarCode == barCode).FirstOrDefault();
                            transportWaybill.TransportWaybill_Car_Id = points.Point_Car_Id.Value;
                            transportWaybill.TransportWaybill_Car_Point_Id = points.Point_Id;
                            OperationSetting Company = context.OperationSettings.Where(c => c.OperationSetting_Key == "DefaultTransporterCompany").FirstOrDefault();
                            OperationSetting type = context.OperationSettings.Where(c => c.OperationSetting_Key == "DefaultTransportWaybillTypeId").FirstOrDefault();
                            transportWaybill.TransportWaybill_Type_Id = Int32.Parse(type.OperationSetting_Value);
                            transportWaybill.TransportWaybill_Company_Id = Int32.Parse(Company.OperationSetting_Value);
                            context.TransportWaybills.Add(transportWaybill);
                            context.SaveChanges();
                            result = transportWaybill;
                        }
                    }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertTransportWaybillCompanyMove()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertTransportWaybillCompanyMove()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertTransportWaybillDetail(TransportWaybillDetail transportWaybillDetail, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = InsertTransportWaybillDetailWithOuterContext(context, transportWaybillDetail, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertTransportWaybillDetail()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertTransportWaybillDetail()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertTransportWaybillDetailWithOuterContext(BerryManagementEntities context, 
            TransportWaybillDetail transportWaybillDetail, ref string errorMessage)
        {
            long result = 0;
            try
            {
                TransportWaybillDetail waybillDetail = SelectL.GetTransportWaybillDetails(transportWaybillDetail.TransportWaybillDetail_TransportWaybill_Id,
                    null, null, ref errorMessage).FirstOrDefault();
                if (waybillDetail != null)
                {
                    Update.UpdateTransportWaybillDetail(transportWaybillDetail, ref errorMessage);
                }
                else
                {
                    context.TransportWaybillDetails.Add(transportWaybillDetail);
                }
                context.SaveChanges();
                result = transportWaybillDetail.TransportWaybillDetail_TransportWaybill_Id;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = InsertNonTransportWaybillWithOuterContext(context, nonTransportWaybill, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                       return result;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "NonInsertTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nNonInsertTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertNonTransportWaybillWithOuterContext(BerryManagementEntities context, NonTransportWaybill nonTransportWaybill, 
            ref string errorMessage)
        {
            long result = 0;
            try
            {
                NonTransportWaybill nonTransportWaybillT = SelectL.GetNonTransportWaybills(null, nonTransportWaybill.NonTransportWaybill_Type_Id,
                    nonTransportWaybill.NonTransportWaybill_TransportWaybill_Id, nonTransportWaybill.NonTransportWaybill_CompanySeler_Id,
                    nonTransportWaybill.NonTransportWaybill_CompanyBuyer_Id, null, false, null, false, ref errorMessage).FirstOrDefault();
                if (nonTransportWaybillT != null)
                {
                    nonTransportWaybill.NonTransportWaybill_Id = nonTransportWaybillT.NonTransportWaybill_Id;
                    Update.UpdateNonTransportWaybill(nonTransportWaybill, ref errorMessage);
                }
                else
                {
                    context.NonTransportWaybills.Add(nonTransportWaybill);
                }
                    context.SaveChanges();
                    result = nonTransportWaybill.NonTransportWaybill_Id;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertNonTransportWaybillWithOuterContext()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertNonTransportWaybillDetail(NonTransportWaybillDetail nonTransportWaybillDetail, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = InsertNonTransportWaybillDetailWithOuterContext(context, nonTransportWaybillDetail, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                         return result;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertNonTransportWaybillDetail()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertNonTransportWaybillDetail()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertNonTransportWaybillDetailWithOuterContext(BerryManagementEntities context,
            NonTransportWaybillDetail nonTransportWaybillDetail, ref string errorMessage)
        {
            long result = 0;
            try
            {
                NonTransportWaybillDetail WaybillDetail = SelectL.GetNonTransportWaybillDetails(
                    nonTransportWaybillDetail.NonTransportWaybillDetail_NonTransportWaybill_Id, null, null, ref errorMessage).FirstOrDefault();
                if (WaybillDetail != null)
                {
                    Update.UpdateNonTransportWaybillDetail(nonTransportWaybillDetail, ref errorMessage);
                }
                else
                {
                    context.NonTransportWaybillDetails.Add(nonTransportWaybillDetail);
                }
                context.SaveChanges();
                result = nonTransportWaybillDetail.NonTransportWaybillDetail_NonTransportWaybill_Id;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "InsertNonTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertNonTransportWaybillDetailWithOuterContext()\n" + ex.Message;
                }
            }
            return result;
        }

        
    }
}
