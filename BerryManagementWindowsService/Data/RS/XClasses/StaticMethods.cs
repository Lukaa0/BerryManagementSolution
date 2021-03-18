using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public class StaticMethods
    {
        public static string GetPointAddress(long pointId, ref string errorMessage)
        {
            string result = null;
            try
            {
                result = Structure.SelectL.GetPoint(pointId, ref errorMessage).First().Point_Address;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  FillPointAddress()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  FillPointAddress()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long GetDefaultTransporterCompanyId(string key, ref string errorMessage)
        {
            long result = 0;
            try
            {
                string companyIdS = Operation.SelectL.GetOperationSettings(key, ref errorMessage).First().OperationSetting_Value;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("ცნობარში არაკორექტულადაა ინფორმაცია კომპანიის შესახებ!");
                }
                result = long.Parse(companyIdS);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetDefaultTransporterCompanyId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetDefaultTransporterCompanyId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void GetOwnerCompanyInfo(long companyId, ref WaybillContainer waybilContainer, ref string errorMessage)
        {
            try
            {
                Structure.XClasses.CompanyeModel companyeModel;
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    companyeModel = Structure.SelectQ.GetCompany(context, companyId, null, ref errorMessage).First();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception("კომპანია არ მოიძებნა!");
                    }
                }
                waybilContainer.UserName = companyeModel.Company_RS_UserId;
                waybilContainer.Password = companyeModel.Company_RS_Password;
                int userId = 0;
                int unicueId = 0;
                bool error = WaybillProxyMethods.ChekServiceUser(waybilContainer.UserName, waybilContainer.Password,
                    out unicueId, out userId, ref errorMessage);
                if (!error || !string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("RS-ის პარამეტრების მიღება ვერ მოხერხდა");
                }
                waybilContainer.Waybill.SELER_UN_ID = unicueId;
                waybilContainer.Waybill.S_USER_ID = userId;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetOwnerCompanyInfo()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetOwnerCompanyInfo()\n" + ex.Message;
                }
            }
        }

        public static void GetOwnerCompanyInfo(long companyId, out string userName, out string password, ref string errorMessage)
        {
            userName = "";
            password = "";
            try
            {
                Structure.XClasses.CompanyeModel companyeModel;
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    companyeModel = Structure.SelectQ.GetCompany(context, companyId, null, ref errorMessage).First();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception("კომპანია არ მოიძებნა!");
                    }
                }
                userName = companyeModel.Company_RS_UserId;
                password = companyeModel.Company_RS_Password;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetOwnerCompanyInfo()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetOwnerCompanyInfo()\n" + ex.Message;
                }
            }
        }

        public static void GetBuyerCompanyInfo(long companyId, out string buyerTin, out string buyerName, out string chackBuyerTin,
            ref string errorMessage)
        {
            buyerTin = null;
            chackBuyerTin = "-1";
            buyerName = null;
            try
            {
                Structure.XClasses.CompanyeModel companyeModel;
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    companyeModel = Structure.SelectQ.GetCompany(context, companyId, null, ref errorMessage).First();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception("კომპანია არ მოიძებნა!");
                    }
                }
                buyerTin = companyeModel.Company_Identity;
                chackBuyerTin = "1";
                buyerName = companyeModel.Company_Name;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetBuyerCompanyInfo()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetBuyerCompanyInfo()\n" + ex.Message;
                }
            }
        }

        public static List<string> GetMovedContainers(long waybillId, bool IsOut, ref string errorMessage)
        {
            List<string> result = null;
            try
            {
                result = Operation.SelectL.GetContainerMove(null, null, waybillId, null, null, IsOut, ref errorMessage).
                    Select(r => r.ContainerMove_Container_BarCode).ToList();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("მონაცემების წაკითხვა ვერ მოხერხდა!");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetMovedContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetMovedContainers()\n" + ex.Message;
                }
            }
            return result;
        }

        public static int GetPunetCountInBox(ref string errorMessage)
        {
            int result = 0;
            try
            {
                result = int.Parse(Operation.SelectL.GetOperationSettings("PunetCountInBox", ref errorMessage).First().OperationSetting_Value);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("ცნობარში არაკორექტულადაა ინფორმაცია ყუთში პუნეტების რაოდენობის შესახებ!");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPunetCountInBox()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPunetCountInBox()\n" + ex.Message;
                }
            }
            return result;
        }

        public static decimal GetDefaultProductPrice(ref string errorMessage)
        {
            decimal result = 0;
            try
            {
                result = decimal.Parse(Operation.SelectL.GetOperationSettings("DefaultProductPrice", ref errorMessage).First().OperationSetting_Value);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("ცნობარში არაკორექტულადაა ინფორმაცია პროდუქტის ფასის შესახებ!");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPunetCountInBox()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPunetCountInBox()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void FillProductGoods(List<XClasses.RS_ProductModel> products, long? companyId, decimal price,
            ref WaybillContainer.WAYBILL waybill, ref string errorMessage)
        {
            try
            {
                List<XClasses.RS_ProductModel> productS = (from p in products.Where(r => companyId == null ||
                                                                r.Product_Ovner_Id == companyId)
                                                           group p by p.Product_Breed_Name into gr
                                                           select new XClasses.RS_ProductModel()
                                                           {
                                                               Product_Breed_Name = gr.Key,
                                                               Product_WeightsSum = gr.Sum(g => g.Product_WeightsSum)
                                                           }).ToList();
                decimal fullAmount = 0m;
                foreach (XClasses.RS_ProductModel p in productS)
                {
                    decimal amount = p.Product_WeightsSum * price;
                    fullAmount = fullAmount + amount;
                    WaybillContainer.WAYBILL.GOODS productGoods = new WaybillContainer.WAYBILL.GOODS()
                    {
                        ID = 0,
                        W_NAME = "ლურჯი მოცვი (" + p.Product_Breed_Name + ")",
                        UNIT_ID = 2,
                        UNIT_TXT = "",
                        QUANTITY = p.Product_WeightsSum,
                        PRICE = price,
                        STATUS = 1,
                        AMOUNT = amount,
                        BAR_CODE = "",
                        A_ID = 0,
                        VAT_TYPE = 1
                    };
                    waybill.GOODS_LIST.Add(productGoods);
                };
                waybill.FULL_AMOUNT = fullAmount;
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

        
    }
}
