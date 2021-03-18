using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    class WaybillCorrectPackageCreator
    {
        public static List<WaybillContainer> CreateWaybillPackage(TransportWaybill transportWaybill, int productOwnerStatus, 
            bool isCheck, ref string errorMessage)
        {
            List<WaybillContainer> result = new List<WaybillContainer>();
            List<string> containers = StaticMethods.GetMovedContainers(transportWaybill.TransportWaybill_Id, !isCheck, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            List<XClasses.RS_ProductModel> products = SelectL.GetRS_ProductModelByContainers(containers, productOwnerStatus, 
                transportWaybill.TransportWaybill_End_DateTime, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            ////სატრანსპორტო ზედნადების გენერაცია
            WaybillContainer transportWaybillContainer = TransportWaybillCreator.CreateInsideTransportWaybill(transportWaybill,
                containers, transportWaybill.TransportWaybill_Company_Id, "", products, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.Add(transportWaybillContainer);
            //რეალიზაციის ზედნადების გენერაცია
            List<WaybillContainer> BuyWaybillContainers = NonTransportWaybillCreator.CreateNonTransportWaybills(transportWaybill,
                transportWaybill.TransportWaybill_Company_Id, "", products, true, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.AddRange(BuyWaybillContainers);
            UpdateWaybillPackage(transportWaybill, result, ref errorMessage);
            return result;
        }

        private static void UpdateWaybillPackage(TransportWaybill transportWaybill, List<WaybillContainer> waybillContainers, ref string errorMessage)
        {
            foreach (RS.XClasses.WaybillContainer waybillContainer in waybillContainers)
            {
                if (waybillContainer.IsTransportWaybill)
                {
                    try
                    {
                        TransportWaybillDetail transportWaybillDetail = SelectL.GetTransportWaybillDetails(transportWaybill.TransportWaybill_Id,
                            null, null, ref errorMessage).First();
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        XElement xWaybill = XElement.Parse(transportWaybillDetail.TransportWaybillDetail_Waybill);
                        Data.RS.XClasses.WaybillContainer.WAYBILL changedWaybill =
                            Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        foreach (WaybillContainer.WAYBILL.GOODS changedGoods in changedWaybill.GOODS_LIST)
                        {
                            WaybillContainer.WAYBILL.GOODS newGoods = waybillContainer.Waybill.GOODS_LIST.Where(g => g.W_NAME == changedGoods.W_NAME).First();
                            changedGoods.QUANTITY = newGoods.QUANTITY;
                        }
                        xWaybill = Classes.Serializers.ObjectToXElement<Data.RS.XClasses.WaybillContainer.WAYBILL>(changedWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        transportWaybillDetail.TransportWaybillDetail_Waybill = xWaybill.ToString();
                        using (BerryManagementEntities context = new BerryManagementEntities())
                        {
                            Update.UpdateTransportWaybillDetail(transportWaybillDetail, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = "სატრანსპორტო ზედნადებში რაოდენობის კორექტირება ვერ მოხერხდა!";
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = s + "\nმეთოდი: UpdateWaybillPackage()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\n" + s + "\nმეთოდი: UpdateWaybillPackage()\n" + ex.Message;
                        }
                    }
                }
                else
                {
                    try
                    {
                        NonTransportWaybillDetail nonTransportWaybillDetail = SelectL.GetNonTransportWaybillDetails(waybillContainer.NonTransportWaybillId_DB,
                            null, null, ref errorMessage).First();
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        XElement xWaybill = XElement.Parse(nonTransportWaybillDetail.NonTransportWaybillDetail_Waybill);
                        Data.RS.XClasses.WaybillContainer.WAYBILL changedWaybill =
                            Classes.Serializers.XElementToObject<Data.RS.XClasses.WaybillContainer.WAYBILL>(xWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        decimal fullAmount = 0;
                        foreach (WaybillContainer.WAYBILL.GOODS changedGoods in changedWaybill.GOODS_LIST)
                        {
                            WaybillContainer.WAYBILL.GOODS newGoods = waybillContainer.Waybill.GOODS_LIST.Where(g => g.W_NAME == changedGoods.W_NAME).First();
                            changedGoods.QUANTITY = newGoods.QUANTITY;
                            changedGoods.AMOUNT = changedGoods.PRICE * changedGoods.QUANTITY;
                            fullAmount = fullAmount + changedGoods.AMOUNT;
                        }
                        changedWaybill.FULL_AMOUNT = fullAmount;
                        xWaybill = Classes.Serializers.ObjectToXElement<Data.RS.XClasses.WaybillContainer.WAYBILL>(changedWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        nonTransportWaybillDetail.NonTransportWaybillDetail_Waybill = xWaybill.ToString();
                        using (BerryManagementEntities context = new BerryManagementEntities())
                        {
                            Update.UpdateNonTransportWaybillDetail(nonTransportWaybillDetail, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = "სატრანსპორტო ზედნადებში რაოდენობის კორექტირება ვერ მოხერხდა!";
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = s + "\nმეთოდი: UpdateWaybillPackage()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\n" + s + "\nმეთოდი: UpdateWaybillPackage()\n" + ex.Message;
                        }
                    }
                }
            }
            //using (BerryManagementEntities context = new BerryManagementEntities())
            //{
            //    using (DbContextTransaction transaction = context.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            foreach (RS.XClasses.WaybillContainer waybillContainer in waybillContainers)
            //            {
            //                if (waybillContainer.IsTransportWaybill)
            //                {
            //                    Update.UpdateTransportWaybillWithOuterContext(context, transportWaybill, ref errorMessage);
            //                    if (!string.IsNullOrEmpty(errorMessage))
            //                    {
            //                        transaction.Rollback();
            //                        return;
            //                    }
            //                    TransportWaybillDetail transportWaybillDetail = TransportWaybillCreator.CreateTransportWaybillDetail(context,
            //                        waybillContainer, ref errorMessage);
            //                    if (!string.IsNullOrEmpty(errorMessage))
            //                    {
            //                        transaction.Rollback();
            //                        return;
            //                    }
            //                    Insert.InsertTransportWaybillDetail(transportWaybillDetail, ref errorMessage);
            //                    if (!string.IsNullOrEmpty(errorMessage))
            //                    {
            //                        transaction.Rollback();
            //                        return;
            //                    }
            //                }
            //                else
            //                {
            //                    NonTransportWaybillDetail nonTransportWaybillDetail = NonTransportWaybillCreator.CreateNonTransportWaybillDetail(context,
            //                        waybillContainer, ref errorMessage);
            //                    if (!string.IsNullOrEmpty(errorMessage))
            //                    {
            //                        transaction.Rollback();
            //                        return;
            //                    }
            //                    Insert.InsertNonTransportWaybillDetail(nonTransportWaybillDetail, ref errorMessage);
            //                    if (!string.IsNullOrEmpty(errorMessage))
            //                    {
            //                        transaction.Rollback();
            //                        return;
            //                    }
            //                }
            //            }
            //            context.SaveChanges();
            //            transaction.Commit();
            //        }
            //        catch (Exception ex)
            //        {
            //            transaction.Rollback();
            //            if (System.String.IsNullOrEmpty(errorMessage))
            //            {
            //                errorMessage = "InsertWaybillPackage()\n" + ex.Message;
            //            }
            //            else
            //            {
            //                errorMessage = errorMessage + "\nInsertWaybillPackage()\n" + ex.Message;
            //            }
            //        }
            //    }

                //}
        }
    }
}
