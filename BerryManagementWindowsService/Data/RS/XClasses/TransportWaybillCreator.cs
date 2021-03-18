using BerryManagementWindowsService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public static class TransportWaybillCreator
    {
        public static WaybillContainer CreateInsideTransportWaybill(TransportWaybill transportWaybill, List<string> containers,
            long TransporterCompanyId, string startAddress, List<XClasses.RS_ProductModel> products, ref string errorMessage)
        {
            WaybillContainer result = new WaybillContainer();
            result.IsTransportWaybill = true;
            result.TransportWaybillId_DB = transportWaybill.TransportWaybill_Id;
            result.Waybill.ID = 0;
            result.Waybill.TYPE = 1;
            result.Waybill.STATUS = 1;
            result.Waybill.TRANS_ID = "1";
            result.Waybill.START_ADDRESS = startAddress;
            result.Waybill.COMMENT = Classes.GlobalParams.TransportWaybillCommentPrefix + transportWaybill.TransportWaybill_Id.ToString();
            result.Waybill.FULL_AMOUNT = 0;
            StaticMethods.GetOwnerCompanyInfo(TransporterCompanyId, ref result, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            FillCarData(transportWaybill, ref result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.Waybill.END_ADDRESS = StaticMethods.GetPointAddress((long)transportWaybill.TransportWaybill_Destination_Point_Id,
                ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            StaticMethods.FillProductGoods(products, null, 0, ref result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            FillContainersGoods(containers, 0, ref result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.XWaybill = Classes.Serializers.ObjectToXElement<RS.XClasses.WaybillContainer.WAYBILL>(
                   result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            return result;
        }

        public static WaybillContainer CreateSendbackTransportWaybill(TransportWaybill transportWaybill, int containersCount,
            long TransporterCompanyId, string startAddress, string destinationAddress, ref string errorMessage)
        {
            WaybillContainer result = new WaybillContainer();
            result.IsTransportWaybill = true;
            result.TransportWaybillId_DB = transportWaybill.TransportWaybill_Id;
            result.Waybill.ID = 0;
            result.Waybill.TYPE = 1;
            result.Waybill.STATUS = 1;
            result.Waybill.TRANS_ID = "1";
            result.Waybill.START_ADDRESS = startAddress;
            result.Waybill.END_ADDRESS = destinationAddress;
            result.Waybill.COMMENT = Classes.GlobalParams.SendBacktWaybillCommentPrefix + transportWaybill.TransportWaybill_Id.ToString();
            result.Waybill.FULL_AMOUNT = 0;
            StaticMethods.GetOwnerCompanyInfo(TransporterCompanyId, ref result, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            FillCarData(transportWaybill, ref result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            FillContainersGoods(null, containersCount, ref result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.XWaybill = Classes.Serializers.ObjectToXElement<RS.XClasses.WaybillContainer.WAYBILL>(
                   result.Waybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            return result;
        }

        private static void FillCarData(TransportWaybill transportWaybill, ref WaybillContainer.WAYBILL waybill, ref string errorMessage)
        {
            try
            {
                Structure.XClasses.CarDriversModel carDriversModel;
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    carDriversModel = Structure.SelectQ.GetCarDrivers(context, null, ref errorMessage).Where(cd =>
                    cd.CarDriver_Car_Id == transportWaybill.TransportWaybill_Car_Id && cd.CarDriver_StartDate <= DateTime.Now &&
                    (cd.CarDriver_EndDate == null || cd.CarDriver_EndDate >= DateTime.Now)).First();
                }
                if (carDriversModel != null)
                {
                    waybill.CAR_NUMBER = carDriversModel.CarDriver_Car_Number;
                    waybill.DRIVER_NAME = carDriversModel.CarDriver_Person_Name;
                    waybill.DRIVER_TIN = carDriversModel.CarDriver_Person_Identity;
                    waybill.CHEK_DRIVER_TIN = Convert.ToInt32(carDriversModel.CarDriver_IsResident).ToString();
                    waybill.CHEK_DRIVER_TIN = "1";
                }
                else
                {
                    throw new Exception("არ მოიძებნა ინფორმაცია ავტომობილის და მძღოლის შესახებ!");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  FillCarData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  FillCarData()\n" + ex.Message;
                }
            }
        }

        private static void FillProductGoods(List<XClasses.RS_ProductModel> products, ref WaybillContainer.WAYBILL waybill, ref string errorMessage)
        {
            try
            {
                List<XClasses.RS_ProductModel> productS = (from p in products
                                                           group p by p.Product_Breed_Name into gr
                                                           select new XClasses.RS_ProductModel()
                                                           {
                                                               Product_Breed_Name = gr.Key,
                                                               Product_WeightsSum = gr.Sum(g => g.Product_WeightsSum)
                                                           }).ToList();
                foreach (XClasses.RS_ProductModel p in productS)
                {
                    WaybillContainer.WAYBILL.GOODS productGoods = new WaybillContainer.WAYBILL.GOODS()
                    {
                        ID = 0,
                        W_NAME = "ლურჯი მოცვი (" + p.Product_Breed_Name + ")",
                        UNIT_ID = 2,
                        UNIT_TXT = "",
                        QUANTITY = p.Product_WeightsSum,
                        PRICE = 0m,
                        STATUS = 1,
                        AMOUNT = 0m,
                        BAR_CODE = "",
                        A_ID = 0,
                        VAT_TYPE = 1
                    };
                    waybill.GOODS_LIST.Add(productGoods);
                };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  FillGoods()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  FillGoods()\n" + ex.Message;
                }
            }
        }

        private static void FillContainersGoods(List<string> containers, int containerCount, ref WaybillContainer.WAYBILL waybill, ref string errorMessage)
        {
            try
            {
                int boxCount = containerCount == 0 ? containers.Count() : containerCount;
                WaybillContainer.WAYBILL.GOODS BoxesGoods = new WaybillContainer.WAYBILL.GOODS()
                {
                    ID = 0,
                    W_NAME = "ყუთი",
                    UNIT_ID = 1,
                    UNIT_TXT = "",
                    QUANTITY = boxCount,
                    PRICE = 0m,
                    STATUS = 1,
                    AMOUNT = 0m,
                    BAR_CODE = "",
                    A_ID = 0,
                    VAT_TYPE = 1
                };
                waybill.GOODS_LIST.Add(BoxesGoods);
                if (containerCount > 0)
                {
                    return;
                }
                int punetCount = boxCount * StaticMethods.GetPunetCountInBox(ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("პუნეტების რაოდენობის განსაზღვრა ვერ მოხერხდა!");
                }
                WaybillContainer.WAYBILL.GOODS punetGoods = new WaybillContainer.WAYBILL.GOODS()
                {
                    ID = 0,
                    W_NAME = "პუნეტი",
                    UNIT_ID = 1,
                    UNIT_TXT = "",
                    QUANTITY = punetCount,
                    PRICE = 0m,
                    STATUS = 1,
                    AMOUNT = 0m,
                    BAR_CODE = "",
                    A_ID = 0,
                    VAT_TYPE = 1
                };
                waybill.GOODS_LIST.Add(punetGoods);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  FillContainersGoods()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  FillContainersGoods()\n" + ex.Message;
                }
            }
        }

        public static TransportWaybillDetail CreateTransportWaybillDetail(BerryManagementEntities context, WaybillContainer waybillContainer, ref string errorMessage)
        {
            TransportWaybillDetail result = new TransportWaybillDetail()
            {
                TransportWaybillDetail_TransportWaybill_Id = waybillContainer.TransportWaybillId_DB,
                TransportWaybillDetail_State = 0,
                TransportWaybillDetail_WaybillStatus = -1,
                TransportWaybillDetail_Waybill = waybillContainer.XWaybill.ToString()
            };
            if(waybillContainer.Waybill.COMMENT.Contains(GlobalParams.SendBacktWaybillCommentPrefix))
            {
                result.TransportWaybillDetail_State = -1;
            }
            return result;
        }
    }
}
