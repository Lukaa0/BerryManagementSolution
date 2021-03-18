using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public static class NonTransportWaybillCreator
    {
        public static List<WaybillContainer> CreateNonTransportWaybills(TransportWaybill transportWaybill,
            long buyerCompanyId, string startAddress, List<XClasses.RS_ProductModel> products, bool isCorrect, ref string errorMessage)
        {
            List<WaybillContainer> result = new List<WaybillContainer>();
            string buyerTin;
            string buyerName;
            string chackBuyerTin;
            StaticMethods.GetBuyerCompanyInfo(buyerCompanyId, out buyerTin, out buyerName, out chackBuyerTin, ref errorMessage);
            chackBuyerTin = "1";
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            decimal price = StaticMethods.GetDefaultProductPrice(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            IEnumerable<long> companyIds = products.Select(p => p.Product_Ovner_Id).Distinct();
            foreach (long companyId in companyIds)
            {
                if (companyId != buyerCompanyId)
                {
                    WaybillContainer waybillContainer = new WaybillContainer();
                    long waybillId = CreateNonTransportWaybillRecord(transportWaybill.TransportWaybill_Id, companyId, buyerCompanyId, 3,
                        isCorrect, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    waybillContainer.TransportWaybillId_DB = transportWaybill.TransportWaybill_Id;
                    waybillContainer.NonTransportWaybillId_DB = waybillId;
                    if (isCorrect)
                    {
                        NonTransportWaybillDetail nonTransportWaybillDetail = SelectL.GetNonTransportWaybillDetails(waybillId,
                               null, null, ref errorMessage).First();
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                        XElement xWaybill = XElement.Parse(nonTransportWaybillDetail.NonTransportWaybillDetail_Waybill);
                        waybillContainer.Waybill = 
                            Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                        waybillContainer.Waybill.GOODS_LIST = new List<WaybillContainer.WAYBILL.GOODS>();
                    }
                    else
                    {
                        waybillContainer.Waybill.ID = 0;
                        waybillContainer.Waybill.TYPE = 3;
                        waybillContainer.Waybill.STATUS = 1;
                        waybillContainer.Waybill.START_ADDRESS = startAddress;
                        waybillContainer.Waybill.BUYER_NAME = buyerName;
                        waybillContainer.Waybill.BUYER_TIN = buyerTin;
                        waybillContainer.Waybill.CHEK_BUYER_TIN = chackBuyerTin;
                        waybillContainer.Waybill.COMMENT = Classes.GlobalParams.NonTransportWaybillCommentPrefix + waybillId;
                    }
                    StaticMethods.GetOwnerCompanyInfo(companyId, ref waybillContainer, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    StaticMethods.FillProductGoods(products, companyId, price, ref waybillContainer.Waybill, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    waybillContainer.XWaybill = Classes.Serializers.ObjectToXElement<RS.XClasses.WaybillContainer.WAYBILL>(
                           waybillContainer.Waybill, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    result.Add(waybillContainer);
                }
            }
            return result;
        }

        private static long CreateNonTransportWaybillRecord(long transportWaybillId, long companySeler_Id, long companyBuyer_Id, int waybillType,
            bool isCorrect,
            ref string errorMessage)
        {
            long result = 0;
            if (isCorrect)
            {
                result = SelectL.GetNonTransportWaybills(null, waybillType, transportWaybillId, companySeler_Id, companyBuyer_Id,
                    null, false, null, false, ref errorMessage).First().NonTransportWaybill_Id;
            }
            else
            {
                Data.NonTransportWaybill nonTransportWaybill = new NonTransportWaybill()
                {
                    NonTransportWaybill_CompanyBuyer_Id = companyBuyer_Id,
                    NonTransportWaybill_CompanySeler_Id = companySeler_Id,
                    NonTransportWaybill_Type_Id = waybillType,
                    NonTransportWaybill_TransportWaybill_Id = transportWaybillId,
                    NonTransportWaybill_Start_DateTime = DateTime.Now,
                    NonTransportWaybill_End_DateTime = DateTime.Now
                };
                result = RS.Insert.InsertNonTransportWaybill(nonTransportWaybill, ref errorMessage);
            }
            return result;
        }

        public static NonTransportWaybillDetail CreateNonTransportWaybillDetail(BerryManagementEntities context, WaybillContainer waybillContainer, ref string errorMessage)
        {
            NonTransportWaybillDetail result = new NonTransportWaybillDetail()
            {
                NonTransportWaybillDetail_NonTransportWaybill_Id = waybillContainer.NonTransportWaybillId_DB,
                NonTransportWaybillDetail_State = 1,
                NonTransportWaybillDetail_WaybillStatus = -1,
                NonTransportWaybillDetail_Waybill = waybillContainer.XWaybill.ToString() 
            };      
            return result;
        }
    }
}
