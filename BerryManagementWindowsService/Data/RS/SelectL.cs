using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BerryManagementWindowsService.Data.RS
{
    public static class SelectL
    {
        public static List<Data.TransportWaybill> GetTransportWaybills(long? id,
            int? typeId, long? carPointId, long? carId, long? companyId,
            long? startPointId, bool startPointIdFiltered, long? destinationPointId, bool destinationPointIdFiltered,
             long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            List<Data.TransportWaybill> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTransportWaybills(context, id, typeId, carPointId, carId, companyId, 
                        startPointId, startPointIdFiltered, destinationPointId, destinationPointIdFiltered, rSId, rSIdFiltered,
                        rSNumber, rSNumberFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWayBills()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWayBills()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.RS.Model.TransportWaybillModel> GetTransportWaybillModel(DateTime? StartDay, DateTime? EndDay, ref string errorMessage)
        {
            List<Data.RS.Model.TransportWaybillModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTransportWaybillModel(context,StartDay, EndDay, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWaybillModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWaybillModel()\n" + ex.Message;
                }
            }
            return result;
        }

        //public static List<XClasses.TransportWaybillModel> GetTransportWayBillModels( long? id, int? typeId, long? carPointId,
        //    long? companyId, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //{
        //    List<XClasses.TransportWaybillModel> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetTransportWayBillModels(context, id, typeId, carPointId, companyId, rSId, rSIdFiltered,
        //                rSNumber, rSNumberFiltered, ref errorMessage);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetTransportWayBillModels()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetTransportWayBillModels()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

            public static List<Data.TransportWaybillDetail> GetTransportWaybillDetails(long? transportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            List<Data.TransportWaybillDetail> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTransportWaybillDetails(context, transportWaybillId, waybillStatus,
                        state, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillGoods(TransportWaybill transportWaybill, long personPostId,
            int productOwnerStatus, bool isCheck, ref string errorMessage)
        {
            List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = Data.RS.XClasses.WaybillPackageCreator.CreateWaybillPackage(transportWaybill, personPostId,
                        productOwnerStatus, isCheck, ref errorMessage);

                    if (selectText.Count != 0)
                    {
                        Data.RS.XClasses.WaybillContainer.WAYBILL product = null;
                        XElement xWaybill = XElement.Parse(selectText.FirstOrDefault().XWaybill.ToString());
                        product = Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        result = product.GOODS_LIST;
                    }

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
            }
            return result;
        }



        public static List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillDetailsProduct(long? transportWaybillId,ref string errorMessage)
        {
            List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = GetTransportWaybillDetails(transportWaybillId, 1,
                        null, ref errorMessage);

                    if(selectText.Count != 0)
                    {
                        Data.RS.XClasses.WaybillContainer.WAYBILL product = null;
                        XElement xWaybill = XElement.Parse(selectText.FirstOrDefault().TransportWaybillDetail_Waybill);
                        product = Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        result = product.GOODS_LIST;
                    }
                    
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWayBillDetails()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetNonTransportWaybillDetailsProduct(long? NonTransportWaybillId, ref string errorMessage)
        {
            List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = GetNonTransportWaybillDetails(NonTransportWaybillId, 1,
                        null, ref errorMessage);

                    if (selectText.Count != 0)
                    {
                        Data.RS.XClasses.WaybillContainer.WAYBILL product = null;
                        XElement xWaybill = XElement.Parse(selectText.FirstOrDefault().NonTransportWaybillDetail_Waybill);
                        product = Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        result = product.GOODS_LIST;
                    }

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWaybillDetailsProduct()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWaybillDetailsProduct()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.NonTransportWaybill> GetNonTransportWaybills(long? id, int? typeId, long? transportWaybillId,
            long? companySelerId, long? companyBuyer_Id, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            List<Data.NonTransportWaybill> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetNonTransportWaybills(context, id, typeId, transportWaybillId, companySelerId, companyBuyer_Id, rSId, rSIdFiltered,
                        rSNumber, rSNumberFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWayBill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWayBill()\n" + ex.Message;
                }
            }
            return result;
        }

        //    public static List<XClasses.NonTransportWaybillModel> GetNonTransportWayBillModels(long? id, int? typeId, long? transportWaybillId,
        //        long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //    {
        //        List<XClasses.NonTransportWaybillModel> result = null;
        //        try
        //        {
        //            using (BerryManagementEntities context = new BerryManagementEntities())
        //            {
        //                var selectText = SelectQ.GetNonTransportWayBillModels(context, id, typeId, transportWaybillId, rSId, rSIdFiltered,
        //                    rSNumber, rSNumberFiltered, ref errorMessage);
        //                result = selectText.ToList();
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //            if (System.String.IsNullOrEmpty(errorMessage))
        //            {
        //                errorMessage = "მეთოდი: GetNonTransportWayBillModels()\n" + ex.Message;
        //            }
        //            else
        //            {
        //                errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWayBillModels()\n" + ex.Message;
        //            }
        //        }
        //        return result;

        //}


        public static List<Data.RS.Model.NonTransportWaybillModel> GetNonTransportWaybillModel(long? transportWaibylId, ref string errorMessage)
        {
            List<Data.RS.Model.NonTransportWaybillModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetNonTransportWaybillModel(context, transportWaibylId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWaybillModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWaybillModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.NonTransportWaybillDetail> GetNonTransportWaybillDetails(long? nonTransportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            List<Data.NonTransportWaybillDetail> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetNonTransportWaybillDetails(context, nonTransportWaybillId, waybillStatus,
                        state, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWayBillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWayBillDetails()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.RS_ProductModel> GetTransportWaybillWeight(long CompanyId, int productOwnerStatus,
             DateTime? maxDateTime, ref string errorMessage)
        {
            List<XClasses.RS_ProductModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTransportWaybillContainers(context, CompanyId, ref errorMessage).ToList();
                    if(selectText.Count != 0)
                        result = GetRS_ProductModelByContainers(selectText, productOwnerStatus, maxDateTime, ref errorMessage);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWaybillWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWaybillWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.RS_ProductModel> GetRS_ProductModelByContainers(List<string> containers, int productOwnerStatus,
             DateTime? maxDateTime, ref string errorMessage)
        {
            List<XClasses.RS_ProductModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRS_ProductModelByContainers(context, containers, productOwnerStatus, maxDateTime, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWayBillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWayBillDetails()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
