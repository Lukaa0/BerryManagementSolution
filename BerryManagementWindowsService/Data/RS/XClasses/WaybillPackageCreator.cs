using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BerryManagementWindowsService.Data.RS.XClasses
{
    public class WaybillPackageCreator
    {
        public static List<WaybillContainer> CreateWaybillPackage(TransportWaybill transportWaybill, long personPostId,
            int productOwnerStatus, bool isCheck, ref string errorMessage)
        {
            transportWaybill.TransportWaybill_Start_DateTime = DateTime.Now;
            List<WaybillContainer> result = new List<WaybillContainer>();
            List<string> containers = StaticMethods.GetMovedContainers(transportWaybill.TransportWaybill_Id, !isCheck, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            string startAddress = StaticMethods.GetPointAddress((long)transportWaybill.TransportWaybill_Start_Point_Id,
                ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            long transporterCompanyId = StaticMethods.GetDefaultTransporterCompanyId("DefaultTransporterCompany", ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }

            List<XClasses.RS_ProductModel> products = SelectL.GetRS_ProductModelByContainers(containers, productOwnerStatus, null, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            //სატრანსპორტო ზედნადების გენერაცია
            WaybillContainer transportWaybillContainer = TransportWaybillCreator.CreateInsideTransportWaybill(transportWaybill,
                containers, transporterCompanyId, startAddress, products, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.Add(transportWaybillContainer);
            //რეალიზაციის ზედნადების გენერაცია
            List<WaybillContainer> BuyWaybillContainers = NonTransportWaybillCreator.CreateNonTransportWaybills(transportWaybill,
                transporterCompanyId, startAddress, products, false, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result.AddRange(BuyWaybillContainers);
            if (!isCheck)
            {
                InsertWaybillPackage(transportWaybill, result, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                ChangeOwnerByWaybill(containers, transportWaybill, personPostId, productOwnerStatus + 1, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
            }
            return result;
        }

        public static long CreateSendBackWaybillPackage(int containerCount, long carId, long startPointId,
            long destinationPointId, ref string errorMessage)
        {
            long result = 0;
            long carPointId = Structure.SelectL.GetPoint(null, ref errorMessage).Where(p => p.Point_Car_Id == carId).FirstOrDefault().Point_Id;
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            long transporterCompanyId = StaticMethods.GetDefaultTransporterCompanyId("DefaultTransporterCompany", ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            TransportWaybill transportWaybill = new TransportWaybill()
            {
                TransportWaybill_Start_DateTime = DateTime.Now,
                TransportWaybill_Car_Id = carId,
                TransportWaybill_Car_Point_Id = carPointId,
                TransportWaybill_Company_Id = transporterCompanyId,
                TransportWaybill_Destination_Point_Id = destinationPointId,
                TransportWaybill_Start_Point_Id = startPointId,
                TransportWaybill_Type_Id = 1
            };
            transportWaybill.TransportWaybill_Id = RS.Insert.InsertTransportWaybill(transportWaybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            string startAddress = StaticMethods.GetPointAddress((long)transportWaybill.TransportWaybill_Start_Point_Id,
                ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            string destinationAddress = StaticMethods.GetPointAddress((long)transportWaybill.TransportWaybill_Destination_Point_Id,
                ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            //სატრანსპორტო ზედნადების გენერაცია
            WaybillContainer transportWaybillContainer = TransportWaybillCreator.CreateSendbackTransportWaybill(transportWaybill, containerCount,
                transporterCompanyId, startAddress, destinationAddress, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            List<WaybillContainer> twl = new List<WaybillContainer>() { transportWaybillContainer };
            InsertWaybillPackage(transportWaybill, twl, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result = transportWaybill.TransportWaybill_Id;
            return result;
        }

        private static void InsertWaybillPackage(TransportWaybill transportWaybill, List<WaybillContainer> waybillContainers, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (RS.XClasses.WaybillContainer waybillContainer in waybillContainers)
                        {
                            if (waybillContainer.IsTransportWaybill)
                            {
                                Update.UpdateTransportWaybillWithOuterContext(context, transportWaybill, ref errorMessage);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    transaction.Rollback();
                                    return;
                                }
                                TransportWaybillDetail transportWaybillDetail = TransportWaybillCreator.CreateTransportWaybillDetail(context,
                                    waybillContainer, ref errorMessage);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    transaction.Rollback();
                                    return;
                                }
                                Insert.InsertTransportWaybillDetail(transportWaybillDetail, ref errorMessage);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    transaction.Rollback();
                                    return;
                                }
                            }
                            else
                            {
                                NonTransportWaybillDetail nonTransportWaybillDetail = NonTransportWaybillCreator.CreateNonTransportWaybillDetail(context,
                                    waybillContainer, ref errorMessage);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    transaction.Rollback();
                                    return;
                                }
                                Insert.InsertNonTransportWaybillDetail(nonTransportWaybillDetail, ref errorMessage);
                                if (!string.IsNullOrEmpty(errorMessage))
                                {
                                    transaction.Rollback();
                                    return;
                                }
                            }
                        }
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "InsertWaybillPackage()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nInsertWaybillPackage()\n" + ex.Message;
                        }
                    }
                }

            }
        }

        private static void ChangeOwnerByWaybill(List<string> containers, TransportWaybill transportWaybill, long personPostId,
            int productOwnerStatus, ref string errorMessage)
        {
            DateTime dateTime = DateTime.Now;
            long companyId = transportWaybill.TransportWaybill_Company_Id;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        IQueryable<Data.Product> products = SelectQ.GetRS_ProductsByContainers(context, containers, ref errorMessage);
                        foreach (Data.Product product in products)
                        {
                            Data.ProductOwner productOwner = new ProductOwner()
                            {
                                ProducOwnert_DateTime = dateTime,
                                ProductOwner_CompanyId = transportWaybill.TransportWaybill_Company_Id,
                                ProductOwner_Product_Id = product.Product_Id,
                                ProductOwner_Status = productOwnerStatus,
                                ProductOwner_User_PersonPost_Id = personPostId
                            };
                            Operation.Insert.InsertProductOwnerWithOuterContext(context, productOwner, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                return;
                            }
                            context.SaveChanges();                            
                        }                        
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ChangeOwnerByWaybill()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nChangeOwnerByWaybill()\n" + ex.Message;
                        }
                    }
                }

            }
        }
    }
}
