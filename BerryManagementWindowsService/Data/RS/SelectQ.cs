using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS
{
    public static class SelectQ
    {
        //TransportWayBill ის წამოღება
        public static IQueryable<Data.TransportWaybill> GetTransportWaybills(BerryManagementEntities context, long? id, 
            int? typeId, long? carPointId, long? carId, long? companyId,  
            long? startPointId, bool startPointIdFiltered, long? destinationPointId, bool destinationPointIdFiltered,
             long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            IQueryable<Data.TransportWaybill> result = null;
            try
            {
                result = context.TransportWaybills;

                if (id != null)
                {
                    result = result.Where(r => r.TransportWaybill_Id == id);
                }
                if (typeId != null)
                {
                    result = result.Where(r => r.TransportWaybill_Type_Id == typeId);
                }
                if (carPointId != null)
                {
                    result = result.Where(r => r.TransportWaybill_Car_Point_Id == carPointId);
                }
                if (carId != null)
                {
                    result = result.Where(r => r.TransportWaybill_Car_Id == carId);
                }
                if (companyId != null)
                {
                    result = result.Where(r => r.TransportWaybill_Company_Id == companyId);
                }
                if (rSIdFiltered)
                {
                    result = result.Where(r => r.TransportWaybill_RS_Id == rSId);
                }
                if (rSNumberFiltered)
                {
                    result = result.Where(r => r.TransportWaybill_RS_Number == rSNumber);
                }
                if (startPointIdFiltered)
                {
                    result = result.Where(r => r.TransportWaybill_Start_Point_Id == startPointId);
                }
                if (destinationPointIdFiltered)
                {
                    result = result.Where(r => r.TransportWaybill_Destination_Point_Id == destinationPointId);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWaybills()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWaybills()\n" + ex.Message;
                }
            }
            return result;

        }


        public static IQueryable<string> GetTransportWaybillContainers(BerryManagementEntities context, long CompanyId, ref string errorMessage)
        {
            IQueryable<string> result = null;
            try
            {
                result = from owner in context.ProductOwners
                         join prod in context.ProductPacks on owner.ProductOwner_Product_Id equals prod.ProductPack_Product_Id
                         where owner.ProductOwner_CompanyId == CompanyId
                         select prod.ProductPack_Container_BarCode;

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWaybillContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWaybillContainers()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.RS.Model.TransportWaybillModel> GetTransportWaybillModel(BerryManagementEntities context,DateTime? StartDay, DateTime? EndDay, ref string errorMessage)
        {
            IQueryable<Data.RS.Model.TransportWaybillModel> result = null;
            try
            {
                result = from wayBill in context.TransportWaybills
                         join car in context.Cars on wayBill.TransportWaybill_Car_Id equals car.Car_Id
                         join companye in context.Companyes on wayBill.TransportWaybill_Company_Id equals companye.Company_Id
                         join detail in context.TransportWaybillDetails on wayBill.TransportWaybill_Id equals detail.TransportWaybillDetail_TransportWaybill_Id
                         where ((wayBill.TransportWaybill_Start_DateTime == null) && (wayBill.TransportWaybill_End_DateTime == null)) || 
                            ((wayBill.TransportWaybill_Start_DateTime >= StartDay) && 
                            ((wayBill.TransportWaybill_Start_DateTime == null) || (wayBill.TransportWaybill_Start_DateTime <= EndDay)))
                         select new Data.RS.Model.TransportWaybillModel()
                         {
                             TransportWaybill_Id = wayBill.TransportWaybill_Id,
                             TransportWaybill_RS_Id = wayBill.TransportWaybill_RS_Id,
                             TransportWaybill_RS_Number = wayBill.TransportWaybill_RS_Number,
                             TransportWaybill_End_DateTime = wayBill.TransportWaybill_End_DateTime,
                             TransportWaybill_CarNumber = car.Car_Number,
                             TransportWaybill_Car_Id = wayBill.TransportWaybill_Car_Id,
                             TransportWaybill_Car_Point_Id = wayBill.TransportWaybill_Car_Point_Id,
                             TransportWaybill_Company_Id = wayBill.TransportWaybill_Company_Id,
                             TransportWaybill_Company_Name = companye.Company_Name,
                             TransportWaybill_Destination_Point_Id = wayBill.TransportWaybill_Destination_Point_Id,
                             TransportWaybill_Start_DateTime = wayBill.TransportWaybill_Start_DateTime,
                             TransportWaybill_Start_Point_Id = wayBill.TransportWaybill_Start_Point_Id,
                             TransportWaybill_Type_Id = wayBill.TransportWaybill_Type_Id,
                             TransportWaybillDetail_State = detail.TransportWaybillDetail_State
                         };

            }catch(Exception ex)
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


        public static IQueryable<Data.RS.Model.NonTransportWaybillModel> GetNonTransportWaybillModel(BerryManagementEntities context, long? transportWaibylId, ref string errorMessage)
        {
            IQueryable<Data.RS.Model.NonTransportWaybillModel> result = null;
            try
            {
                result = from NonwayBill in context.NonTransportWaybills
                         join companyeB in context.Companyes on NonwayBill.NonTransportWaybill_CompanyBuyer_Id equals companyeB.Company_Id
                         join companyeS in context.Companyes on NonwayBill.NonTransportWaybill_CompanySeler_Id equals companyeS.Company_Id
                         join detail in context.NonTransportWaybillDetails on NonwayBill.NonTransportWaybill_Id equals  detail.NonTransportWaybillDetail_NonTransportWaybill_Id
                         where (transportWaibylId == null || NonwayBill.NonTransportWaybill_TransportWaybill_Id == transportWaibylId)
                         select new Data.RS.Model.NonTransportWaybillModel()
                         {
                             NonTransportWaybill_Id = NonwayBill.NonTransportWaybill_Id,
                             NonTransportWaybill_RS_Id = NonwayBill.NonTransportWaybill_RS_Id,
                             NonTransportWaybill_RS_Number = NonwayBill.NonTransportWaybill_RS_Number,
                             NonTransportWaybill_End_DateTime = NonwayBill.NonTransportWaybill_End_DateTime,
                             NonTransportWaybill_CompanySeler_Id = NonwayBill.NonTransportWaybill_CompanySeler_Id,
                             NonTransportWaybill__CompanyBuyer_Name = companyeB.Company_Name,
                             NonTransportWaybill_Start_DateTime = NonwayBill.NonTransportWaybill_Start_DateTime,
                             NonTransportWaybill_Type_Id = NonwayBill.NonTransportWaybill_Type_Id,
                             NonTransportWaybill_CompanyBuyer_Id = NonwayBill.NonTransportWaybill_CompanyBuyer_Id,
                             NonTransportWaybill_TransportWaybill_Id = NonwayBill.NonTransportWaybill_TransportWaybill_Id,
                             NonTransportWaybill__CompanySeler_Name = companyeS.Company_Name,
                             NonTransportWaybillDetail_State = detail.NonTransportWaybillDetail_State,
                         };

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


        //TransportWayBillModel ის წამოღება
        //public static IQueryable<XClasses.TransportWaybillModel> GetTransportWayBillModels(BerryManagementEntities context, long? id, int? typeId, long? carPointId,
        //    long? companyId, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //{
        //    IQueryable<XClasses.TransportWaybillModel> result = null;
        //    try
        //    {
        //        result = from transportWaybill in SelectQ.GetTransportWaybills(context, id, typeId, carPointId, companyId, rSId, rSIdFiltered, rSNumber, rSNumberFiltered, ref errorMessage)
        //                 join carPoint in context.Points on transportWaybill.TransportWaybill_Car_Point_Id equals carPoint.Point_Id
        //                 join company in context.Companyes on transportWaybill.TransportWaybill_Company_Id equals company.Company_Id
        //                 select new XClasses.TransportWaybillModel
        //                 {
        //                     TransportWaybill_Id = transportWaybill.TransportWaybill_Id,
        //                     TransportWaybill_Type_Id = transportWaybill.TransportWaybill_Type_Id,
        //                     TransportWaybill_Car_Point_Id = transportWaybill.TransportWaybill_Car_Point_Id,
        //                      TransportWaybill_Car_point_Name = carPoint.Point_Name,
        //                     TransportWaybill_RS_Id = transportWaybill.TransportWaybill_RS_Id,
        //                     TransportWaybill_RS_Number = transportWaybill.TransportWaybill_RS_Number,
        //                     TransportWaybill_Start_DateTime = transportWaybill.TransportWaybill_Start_DateTime,
        //                     TransportWaybill_End_DateTime = transportWaybill.TransportWaybill_End_DateTime,
        //                     TransportWaybill_Company_Id = transportWaybill.TransportWaybill_Company_Id,
        //                     TransportWaybill_Company_Name = company.Company_Name
        //                 };

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

        //TransportWaybillDetail ის წამოღება

        public static IQueryable<Data.TransportWaybillDetail> GetTransportWaybillDetails(BerryManagementEntities context, long? transportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            IQueryable<Data.TransportWaybillDetail> result = null;
            try
            {
                result = context.TransportWaybillDetails;

                if (transportWaybillId != null)
                {
                    result = result.Where(r => r.TransportWaybillDetail_TransportWaybill_Id == transportWaybillId);
                }
                if (waybillStatus != null)
                {
                    result = result.Where(r => r.TransportWaybillDetail_WaybillStatus == waybillStatus);
                }
                if (state != null)
                {
                    result = result.Where(r => r.TransportWaybillDetail_State == state);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTransportWaybillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTransportWaybillDetails()\n" + ex.Message;
                }
            }
            return result;

        }

        //NonTransportWayBill ის წამოღება
        public static IQueryable<Data.NonTransportWaybill> GetNonTransportWaybills(BerryManagementEntities context, long? id, int? typeId, long? transportWaybillId,
            long? companySelerId, long? companyBuyer_Id, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            IQueryable<Data.NonTransportWaybill> result = null;
            try
            {
                result = context.NonTransportWaybills;

                if (id != null)
                {
                    result = result.Where(r => r.NonTransportWaybill_Id == id);
                }
                if (typeId != null)
                {
                    result = result.Where(r => r.NonTransportWaybill_Type_Id == typeId);
                }
                if (transportWaybillId != null)
                {
                    result = result.Where(r => r.NonTransportWaybill_TransportWaybill_Id == transportWaybillId);
                }
                if (companySelerId != null)
                {
                    result = result.Where(r => r.NonTransportWaybill_CompanySeler_Id == companySelerId);
                }
                if (companyBuyer_Id != null)
                {
                    result = result.Where(r => r.NonTransportWaybill_CompanyBuyer_Id == companyBuyer_Id);
                }
                if (rSIdFiltered)
                {
                    result = result.Where(r => r.NonTransportWaybill_RS_Id == rSId);
                }
                if (rSNumberFiltered)
                {
                    result = result.Where(r => r.NonTransportWaybill_RS_Number == rSNumber);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWaybills()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWaybills()\n" + ex.Message;
                }
            }
            return result;

        }

        //NonTransportWayBillModel ის წამოღება
        //public static IQueryable<XClasses.NonTransportWaybillModel> GetNonTransportWayBillModels(BerryManagementEntities context, long? id, int? typeId, long? transportWaybillId,
        //    long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //{
        //    IQueryable<XClasses.NonTransportWaybillModel> result = null;
        //    try
        //    {
        //        result = from nonTransportWaybill in SelectQ.GetNonTransportWaybills(context, id, typeId,transportWaybillId, rSId, rSIdFiltered, rSNumber, rSNumberFiltered, ref errorMessage)
        //                 join companySeler in context.Companyes on nonTransportWaybill.NonTransportWaybill_CompanySeler_Id equals companySeler.Company_Id
        //                 join companybuyer in context.Companyes on nonTransportWaybill.NonTransportWaybill_CompanyBuyer_Id equals companybuyer.Company_Id
        //                 select new XClasses.NonTransportWaybillModel
        //                 {
        //                     NonTransportWaybill_Id = nonTransportWaybill.NonTransportWaybill_Id,
        //                     NonTransportWaybill_Type_Id = nonTransportWaybill.NonTransportWaybill_Type_Id,
        //                     NonTransportWaybill_CompanySeler_Id = nonTransportWaybill.NonTransportWaybill_CompanySeler_Id,
        //                     NonTransportWaybill_CompanySeler_Name = companySeler.Company_Name,
        //                     NonTransportWaybill_RS_Id = nonTransportWaybill.NonTransportWaybill_RS_Id,
        //                     NonTransportWaybill_RS_Number = nonTransportWaybill.NonTransportWaybill_RS_Number,
        //                     NonTransportWaybill_Start_DateTime = nonTransportWaybill.NonTransportWaybill_Start_DateTime,
        //                     NonTransportWaybill_End_DateTime = nonTransportWaybill.NonTransportWaybill_End_DateTime,
        //                     NonTransportWaybill_CompanyBuyer_Id = nonTransportWaybill.NonTransportWaybill_CompanyBuyer_Id,
        //                     NonTransportWaybill_CompanyBuyer_Name = companybuyer.Company_Name
        //                 };

        //    }
        //    catch (Exception ex)
        //    {

        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetNonTransportWayBillModels()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWayBillModels()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        //NonTransportWaybillDetail ის წამოღება

        public static IQueryable<Data.NonTransportWaybillDetail> GetNonTransportWaybillDetails(BerryManagementEntities context, long? nonTransportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            IQueryable<Data.NonTransportWaybillDetail> result = null;
            try
            {
                result = context.NonTransportWaybillDetails;

                if (nonTransportWaybillId != null)
                {
                    result = result.Where(r => r.NonTransportWaybillDetail_NonTransportWaybill_Id == nonTransportWaybillId);
                }
                if (waybillStatus != null)
                {
                    result = result.Where(r => r.NonTransportWaybillDetail_WaybillStatus == waybillStatus);
                }
                if (state != null)
                {
                    result = result.Where(r => r.NonTransportWaybillDetail_State == state);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetNonTransportWaybillDetails()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetNonTransportWaybillDetails()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Product> GetRS_ProductsByContainers(BerryManagementEntities context, List<string> containers,
            ref string errorMessage)
        {
            IQueryable<Data.Product> result = null;
            try
            {
                result = from p in context.Products
                     where (from pp in context.ProductPacks.Where(pp => pp.ProductPack_Out_ProductPackInOut_Id == null &&
                        containers.Contains(pp.ProductPack_Container_BarCode)) select pp.ProductPack_Product_Id).Contains(p.Product_Id)
                     select p;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetRS_ProductsByContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetRS_ProductsByContainers()\n" + ex.Message;
                }
            }
            return result;
        }

        private class ProductPackGroup
        {
            public DateTime ProductPack_In_DateTime { set; get; }
            public string ProductPack_Container_BarCode { set; get; }
        }

        public static IQueryable<XClasses.RS_ProductModel> GetRS_ProductModelByContainers(BerryManagementEntities context, List<string> containers,
            int productOwnerStatus, DateTime? maxDateTime, ref string errorMessage)
        {
            IQueryable<XClasses.RS_ProductModel> result = null;
            IQueryable<ProductPack> productPacks = null;
            try
            {
                if (maxDateTime == null)
                {
                    productPacks = from pp in context.ProductPacks.Where(pp => pp.ProductPack_Out_ProductPackInOut_Id == null &&
                        containers.Contains(pp.ProductPack_Container_BarCode))
                                   select pp;
                }
                else
                {
                    IQueryable<ProductPackGroup> productPacksGroup = from ppg in context.ProductPacks.Where(p => p.ProductPack_In_DateTime < maxDateTime &&
                                       containers.Contains(p.ProductPack_Container_BarCode))
                                                                     group ppg by ppg.ProductPack_Container_BarCode into ppGroup
                                                                     select new ProductPackGroup()
                                                                     {
                                                                         ProductPack_In_DateTime = ppGroup.Max(x => x.ProductPack_In_DateTime),
                                                                         ProductPack_Container_BarCode = ppGroup.Key
                                                                     };
                    productPacks = from pp in context.ProductPacks
                                   join ppg in productPacksGroup
                                    on pp.ProductPack_In_DateTime equals ppg.ProductPack_In_DateTime
                                   where pp.ProductPack_Container_BarCode == ppg.ProductPack_Container_BarCode
                                   select pp;
                }
               result = (from pp in productPacks
                         join p in context.Products
                            on pp.ProductPack_Product_Id equals p.Product_Id
                         join b in context.Breeds
                             on p.Product_Breed_Id equals b.Breed_Id
                         join o in context.ProductOwners.Where(po => po.ProductOwner_Status == productOwnerStatus)
                             on p.Product_Id equals o.ProductOwner_Product_Id
                         join w in context.ContainerWeights
                             on pp.ProductPack_In_ProductPackInOut_Id equals w.ContainerWeight_Id
                         select new
                         {
                             p.Product_Id,
                             b.Breed_Name,
                             o.ProductOwner_CompanyId,
                             w.ContainerWeight_Net
                         }).
                         GroupBy(pgr => new
                         {
                             pgr.Breed_Name,
                             pgr.ProductOwner_CompanyId

                         }).
                         Select(gr => new XClasses.RS_ProductModel()
                         {
                             Product_Breed_Name = gr.Key.Breed_Name,
                             Product_Ovner_Id = gr.Key.ProductOwner_CompanyId,
                             Product_ContainerCount = gr.Count(),
                             Product_WeightsSum = gr.Sum(g => g.ContainerWeight_Net)
                         });
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetGroupedRS_ProductModelByContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetGroupedRS_ProductModelByContainers()\n" + ex.Message;
                }
            }
            return result;
        }

    }
}
