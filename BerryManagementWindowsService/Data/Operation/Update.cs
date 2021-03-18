using BerryManagementWindowsService.Data.Operation.XClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation
{
    public static class Update
    {
        public static void UpdateTakeRow(TakeRow takeRow, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateTakeRowWithOuterContext(context, takeRow, ref errorMessage);
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
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }
        public static int GetSaleCount(ref string errorMessage)
        {
            int count = 0;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                    try
                    {
                         count = context.Sales.Where(x=>x.Sale_IsComplite==false).Count();
                     
                    }
                    catch (Exception ex)
                    {
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  FixSale()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  FixSale()\n" +
                                           ex.Message;
                        }

                    }
                
            }
            return count;

        }
        public static void FixSale(long companyId, ref String errorMessage)
        {

            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        List<Sale> sales = context.Sales.Where(c => c.Sale_Company_Id == companyId && c.Sale_IsComplite == false).ToList();
                        if (sales.Count != 0)
                        {
                            for (int i = 0; i < sales.Count; i++)
                            {
                                sales[i].Sale_IsComplite = true;
                            }
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        else
                        {
                            errorMessage = "მონაცემები ვერ მოიძებნა";
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  FixSale()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  FixSale()\n" +
                                           ex.Message;
                        }

                    }
                }
            }
        }

        public static void UpdateSale(long pointId, long companyId,long userId, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            List<Sale> sale = context.Sales.Where(c => /*c.Sale_Point_Id == carpointId &&*/ c.Sale_IsComplite == false).ToList();
                            //List < ContainerLocation > containerLocations= context.ContainerLocations.Where(c => c.ContainerLocation_Point_Id == carpointId && c.ContainerLocation_Out_ContainerMoveInOut_Id == null).ToList();
                            if(sale.Count != 0)
                            {
                                Point carPoint = context.Points.Where(c => c.Point_Id == companyId && c.Point_IsActive == true).FirstOrDefault();
                                List<CompanyCar> companyCars = context.CompanyCars.Where(c => c.CompanyCar_Car_Id == carPoint.Point_Car_Id && (c.CompanyCar_EndDate == null || c.CompanyCar_EndDate > DateTime.Now)).ToList();
                                //foreach (Sale saleContainer in sale)
                                //{
                                //    saleContainer.Sale_IsComplite = true;
                                //    List<ProductPack> productPack = context.ProductPacks.Where(c => c.ProductPack_Container_BarCode == saleContainer.Sale_Container_BarCode).ToList();
                                    
                                //    ProductOwner productOwner = new ProductOwner()
                                //    {
                                //        ProductOwner_Product_Id = productPack.FirstOrDefault().ProductPack_Product_Id,
                                //        ProductOwner_CompanyId = companyCars.FirstOrDefault().CompanyCar_Company_Id,
                                //        ProductOwner_User_PersonPost_Id = userId,
                                //        ProducOwnert_DateTime = DateTime.Now,
                                //        ProductOwner_Status = 3

                                //    };
                                //    context.ProductOwners.Add(productOwner);
                                //}
                                
                                
                                //for (int i = 0; i < sale.Count; i++)
                                //{
                                //    sale[i].Sale_IsComplite = true;
                                //    //containerLocations[i].ContainerLocation_Out_ContainerMoveInOut_Id = sale[i].Sale_Id;
                                //    //containerLocations[i].ContainerLocation_Out_DateTime = DateTime.Now;
                                //    //containerLocations[i].ContainerLocation_Out_User_PersonPost_Id = userId;
                                //}
                                dbContextTransaction.Commit();
                                context.SaveChanges();
                            }
                            else
                            {
                                errorMessage = "მონაცემები ვერ მოიძებნა";
                            }
                           
                        }
                        catch (Exception ex)
                        {

                            dbContextTransaction.Rollback();
                            if (System.String.IsNullOrEmpty(errorMessage))
                            {
                                errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateSale()\n" + ex.Message;
                            }
                            else
                            {
                                errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateSale()\n" +
                                               ex.Message;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateTakeRowWithOuterContext(BerryManagementEntities context, TakeRow takeRow, ref String errorMessage)
        {
            try
            {
                TakeRow takeRowT = SelectQ.GetTakeRows(context, takeRow.TakeRow_Id, null, null, null, null, false, ref errorMessage).FirstOrDefault();
                if (takeRowT != null)
                {
                    takeRowT.TakeRow_Brigade_Id = takeRow.TakeRow_Brigade_Id;
                    takeRowT.TakeRow_Row_Id = takeRow.TakeRow_Row_Id;
                    takeRowT.TakeRow_In_DateTime = takeRow.TakeRow_In_DateTime;
                    takeRowT.TakeRow_In_TakeRowInOut_Id = takeRow.TakeRow_In_TakeRowInOut_Id;
                    takeRowT.TakeRow_In_TUser_PersonPost_Id = takeRow.TakeRow_In_TUser_PersonPost_Id;
                    takeRowT.TakeRow_Out_DateTime = takeRow.TakeRow_Out_DateTime;
                    takeRowT.TakeRow_Out_TakeRowInOut_Id = takeRow.TakeRow_Out_TakeRowInOut_Id;
                    takeRowT.TakeRow_Out_User_PersonPost_Id = takeRow.TakeRow_Out_User_PersonPost_Id;
                }
                else
                {
                    errorMessage = "შეცდომა: UpdateTakeRowWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateContainerLocationWithOuterContext(BerryManagementEntities context, ContainerMove containerMove, ref String errorMessage)
        {
            try
            {
                ContainerMove containerMoveT = SelectQ.GetContainerMove(context,null,null,containerMove.ContainerMove_Container_BarCode,null,null,true, ref errorMessage).FirstOrDefault();
                if (containerMoveT != null)
                {
                    containerMoveT.ContainerMove_Out_ContainerMoveInOut_Id = containerMove.ContainerMove_Out_ContainerMoveInOut_Id;
                    containerMoveT.ContainerMove_Out_User_PersonPost_Id = containerMove.ContainerMove_Out_User_PersonPost_Id;
                    containerMoveT.ContainerMove_Out_DateTime = containerMove.ContainerMove_Out_DateTime;
                   
                }
                else
                {
                    errorMessage = "შეცდომა: UpdateTakeRowWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateContainerLocationWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateContainerLocationWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static void UpdateTakeRowWith(TakeRow takeRow, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    TakeRow takeRowT = SelectQ.GetTakeRows(context, takeRow.TakeRow_Id, null, null, null, null, false, ref errorMessage).FirstOrDefault();
                    if (takeRowT != null)
                    {
                        takeRowT.TakeRow_Brigade_Id = takeRow.TakeRow_Brigade_Id;
                        takeRowT.TakeRow_Row_Id = takeRow.TakeRow_Row_Id;
                        takeRowT.TakeRow_In_DateTime = takeRow.TakeRow_In_DateTime;
                        takeRowT.TakeRow_In_TakeRowInOut_Id = takeRow.TakeRow_In_TakeRowInOut_Id;
                        takeRowT.TakeRow_In_TUser_PersonPost_Id = takeRow.TakeRow_In_TUser_PersonPost_Id;
                        takeRowT.TakeRow_Out_DateTime = takeRow.TakeRow_Out_DateTime;
                        takeRowT.TakeRow_Out_TakeRowInOut_Id = takeRow.TakeRow_Out_TakeRowInOut_Id;
                        takeRowT.TakeRow_Out_User_PersonPost_Id = takeRow.TakeRow_Out_User_PersonPost_Id;
                        context.SaveChanges();
                    }
                    else
                    {
                        errorMessage = "შეცდომა: UpdateTakeRowWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                    }
                

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateHarvesterRowDistribution(HarvesterRowDistribution harvDist, ref String errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                UpdateHarvesterRowDistributionWithOuterContext(context, harvDist, ref errorMessage);
                context.SaveChanges();
            }
        }

        public static void UpdateHarvesterRowDistributionWithOuterContext(BerryManagementEntities context, HarvesterRowDistribution harvDist, ref String errorMessage)
        {
            try
            {

                var harv = SelectQ.GetHarvesterRowDistributions(context, harvDist.HarvesterRowDistribution_Id, null, 
                    null, null, null, false, ref errorMessage).FirstOrDefault();
                if (harv != null)
                {
                    harv.HarvesterRowDistribution_Harvester_PersonPost_Id =
                        harvDist.HarvesterRowDistribution_Harvester_PersonPost_Id;
                    harv.HarvesterRowDistribution_In_DateTime = harvDist.HarvesterRowDistribution_In_DateTime;
                    harv.HarvesterRowDistribution_In_HarvesterRowDistributionInOut_Id =
                        harvDist.HarvesterRowDistribution_In_HarvesterRowDistributionInOut_Id;
                    harv.HarvesterRowDistribution_In_User_PersonPost_Id = harvDist.HarvesterRowDistribution_In_User_PersonPost_Id;
                    harv.HarvesterRowDistribution_Row_Id = harvDist.HarvesterRowDistribution_Row_Id;
                    harv.HarvesterRowDistribution_Out_DateTime = harvDist.HarvesterRowDistribution_Out_DateTime;
                    harv.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id =
                        harvDist.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id;
                    harv.HarvesterRowDistribution_Out_User_PersonPost_Id =
                        harvDist.HarvesterRowDistribution_Out_User_PersonPost_Id;
                }
                else
                {
                    errorMessage = "შეცდომა: UpdateHarvesterRowDistributionWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void ClosePalet(BerryManagementEntities context, string paletBarCode, long userPersonPostId, ref string errorMessage)
        {
                //using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                //{
                    try
                    {
                        List<ContainerPack> containerPackList = context.ContainerPacks.Where(c => c.ContainerPack_Parent_Container_BarCode == paletBarCode).ToList();
                        if (containerPackList.Count != 0)
                        {
                            foreach (ContainerPack containerPack in containerPackList)
                            {
                                containerPack.ContainerPack_IsComplite = true;
                                
                            }
                            Insert.InsertPalleteWeight(context, containerPackList.FirstOrDefault().ContainerPack_Parent_ContainerLocation_In_Id, paletBarCode, (long)userPersonPostId, ref errorMessage);

                }
                        else
                        {
                            //dbContextTransaction.Rollback();
                            throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                            
                        }
                        
                            //dbContextTransaction.Commit();
                       

                    }
                    catch (Exception ex)
                    {
                        //dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  ClosePalet()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  ClosePalet()\n" + ex.Message;
                        }
                    }
                //}
            
        }

        public static void UpdateContainerPack(BerryManagementEntities context ,string paletBarCode , long userPersonPostID,ref string errorMessage)
        {
            
               
                    try
                    {

                        List<ContainerPack> containerPackList = context.ContainerPacks.Where(c => c.ContainerPack_Parent_Container_BarCode == paletBarCode).ToList();
                        ContainerLocation parentLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Container_BarCode == paletBarCode).FirstOrDefault();
                        if (parentLocation == null)
                        {
                            throw new Exception("containerWeights == null");
                        }
                        else
                        {
                            context.ContainerLocations.Remove(parentLocation);
                        }
                  
                      
                    

                        if (containerPackList.Count != 0)
                            {
                            foreach (ContainerPack containerPack in containerPackList)
                            {
                                ContainerLocation containerLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == containerPack.ContainerPack_Id).FirstOrDefault();
                                containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = null;
                                containerLocation.ContainerLocation_Out_DateTime = null;
                                containerLocation.ContainerLocation_Out_User_PersonPost_Id = null;
                                context.ContainerPacks.Remove(containerPack);

                            }
                           
                            //context.ContainerPacks.RemoveRange(containerPackList);
                            
                            ContainerWeight containerWeights = context.ContainerWeights.Where(c => c.ContainerWeight_Container_BarCode == paletBarCode).FirstOrDefault();

                            if (containerWeights == null)
                            {
                                throw new Exception("containerWeights == null");
                            }
                            else
                            {
                                context.ContainerWeights.Remove(containerWeights);
                            }
                        
                            
                            

                            }

                            else
                            {
                              
                                throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                            }

                              
                              
                       

                    }

                    catch (Exception ex)
                    {

                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateContainerPack()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateContainerPack()\n" + ex.Message;
                        }
                    }
                }
            
        
        public static void UpdateContainerMove(ContainerMove containerMove, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            ContainerMove containerMoveT = SelectQ.GetContainerMove(context, containerMove.ContainerMove_Id, null, null,
                                                    null, null, false, ref errorMessage).FirstOrDefault();
                            if (containerMoveT != null)
                            {
                                containerMoveT.ContainerMove_Car_Point_Id = containerMove.ContainerMove_Car_Point_Id;
                                containerMoveT.ContainerMove_Container_BarCode = containerMove.ContainerMove_Container_BarCode;
                                containerMoveT.ContainerMove_In_ContainerMoveInOut_Id = containerMove.ContainerMove_In_ContainerMoveInOut_Id;
                                containerMoveT.ContainerMove_In_DateTime = containerMove.ContainerMove_In_DateTime;
                                containerMoveT.ContainerMove_In_User_PersonPost_Id = containerMove.ContainerMove_In_User_PersonPost_Id;
                                containerMoveT.ContainerMove_In_User_Point_Id = containerMove.ContainerMove_In_User_Point_Id;
                                containerMoveT.ContainerMove_Out_ContainerMoveInOut_Id = containerMove.ContainerMove_Out_ContainerMoveInOut_Id;
                                containerMoveT.ContainerMove_Out_DateTime = containerMove.ContainerMove_Out_DateTime;
                                containerMoveT.ContainerMove_Out_User_PersonPost_Id = containerMove.ContainerMove_Out_User_PersonPost_Id;
                                containerMoveT.ContainerMove_Out_User_Point_Id = containerMove.ContainerMove_Out_User_Point_Id;

                                var containerLocation = context.ContainerLocations.Where(c => 
                                c.ContainerLocation_Out_ContainerMoveInOut_Id == null && 
                                c.ContainerLocation_Point_Id == containerMove.ContainerMove_Car_Point_Id &&
                                c.ContainerLocation_Container_BarCode == containerMove.ContainerMove_Container_BarCode).FirstOrDefault();

                                containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = containerMove.ContainerMove_Out_ContainerMoveInOut_Id;
                                containerLocation.ContainerLocation_Out_DateTime = DateTime.Now;
                                containerLocation.ContainerLocation_Out_User_PersonPost_Id = containerMove.ContainerMove_Out_User_PersonPost_Id;

                                var containerLocationModel = new ContainerLocation()
                                {
                                    ContainerLocation_Container_BarCode = containerMove.ContainerMove_Container_BarCode,
                                    ContainerLocation_Point_Id = (long)containerMove.ContainerMove_Out_User_Point_Id,
                                    ContainerLocation_In_Id = (System.Guid)containerMove.ContainerMove_Out_ContainerMoveInOut_Id,
                                    ContainerLocation_In_User_PersonPost_Id = (long)containerMove.ContainerMove_Out_User_PersonPost_Id,
                                    ContainerLocation_In_DateTime = DateTime.Now
                                };
                                context.ContainerLocations.Add(containerLocationModel);
                                context.SaveChanges();
                                dbContextTransaction.Commit();
                            }
                            else
                            {
                                dbContextTransaction.Rollback();
                                throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                                
                            }
                        }
                        catch (Exception)
                        {
                            dbContextTransaction.Rollback();
                            throw;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateHarvesterContainerDistribution(BerryManagementEntities context,HarvesterContainerDistribution harvesterCont, ref String errorMessage)
        {
            try
            {
                
                    HarvesterContainerDistribution hd = SelectQ.GetHarvesterContainerDistributions(context,
                        harvesterCont.HarvesterContainerDistribution_Id, null, null, null, null, false,
                        ref errorMessage).FirstOrDefault();
                    if (hd != null)
                    {
                        hd.HarvesterContainerDistribution_Container_BarCode =
                            harvesterCont.HarvesterContainerDistribution_Container_BarCode;
                        hd.HarvesterContainerDistribution_Harvester_PersonPost_Id =
                            harvesterCont.HarvesterContainerDistribution_Harvester_PersonPost_Id;
                        hd.HarvesterContainerDistribution_IN_DateTime =
                            harvesterCont.HarvesterContainerDistribution_IN_DateTime;
                        hd.HarvesterContainerDistribution_In_HarvesterContainerDistributionInOut_Id = harvesterCont
                            .HarvesterContainerDistribution_In_HarvesterContainerDistributionInOut_Id;
                        hd.HarvesterContainerDistribution_In_User_PersonPost_Id =
                            harvesterCont.HarvesterContainerDistribution_In_User_PersonPost_Id;
                        hd.HarvesterContainerDistribution_Out_DateTime =
                            harvesterCont.HarvesterContainerDistribution_Out_DateTime;
                        hd.HarvesterContainerDistribution_Out_HarvesterContainerDistributionInOut_Id = harvesterCont
                            .HarvesterContainerDistribution_Out_HarvesterContainerDistributionInOut_Id;
                        hd.HarvesterContainerDistribution_Out_User_PersonPost_Id =
                            harvesterCont.HarvesterContainerDistribution_Out_User_PersonPost_Id;
                        
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateProductPack(ProductPack productPack, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    UpdateProductPackWithOuterContext(context, productPack, ref errorMessage);
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
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductPack()\n" + ex.Message;
                }
            }
        }

        public static void UpdateProductPackWithOuterContext(BerryManagementEntities context, ProductPack productPack, ref String errorMessage)
        {
            try
            {
                ProductPack productPackT = SelectQ.GetProductPacks(context, productPack.ProductPack_Id, null, null, null,null, false, ref errorMessage).FirstOrDefault();
                if (productPackT != null)
                {
                    productPackT.ProductPack_Container_BarCode = productPack.ProductPack_Container_BarCode;
                    productPackT.ProductPack_Id = productPack.ProductPack_Id;
                    productPackT.ProductPack_In_DateTime = productPack.ProductPack_In_DateTime;
                    productPackT.ProductPack_In_ProductPackInOut_Id = productPack.ProductPack_In_ProductPackInOut_Id;
                    productPackT.ProductPack_In_User_PersonPost_Id = productPack.ProductPack_In_User_PersonPost_Id;
                    productPackT.ProductPack_Out_DateTime = productPack.ProductPack_Out_DateTime;
                    productPackT.ProductPack_Out_ProductPackInOut_Id = productPack.ProductPack_Out_ProductPackInOut_Id;
                    productPackT.ProductPack_Out_User_PersonPost_Id = productPack.ProductPack_Out_User_PersonPost_Id;
                    productPackT.ProductPack_Product_Id = productPack.ProductPack_Product_Id;
                }
                else
                {
                    errorMessage = "შეცდომა: UpdateProductPackWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductPackWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateProductPackWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static void UpdateOperationSetting(OperationSetting operationSetting, ref String errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    OperationSetting operationSettingT = SelectQ.GetOperationSettings(context, 
                        operationSetting.OperationSetting_Key, ref errorMessage).FirstOrDefault();
                    if (operationSettingT != null)
                    {
                        operationSettingT.OperationSetting_Value = operationSetting.OperationSetting_Value;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                }
            }
        }

        public static void UpdateConainerWight(BerryManagementEntities context, ContainerWeight ContainerWeightObj, ref string errorMessage)
        {
            try
            {

                    ContainerWeight CheckExist = context.ContainerWeights.Where(e => e.ContainerWeight_Id == ContainerWeightObj.ContainerWeight_Id).FirstOrDefault();

                    if (CheckExist != null)
                    {
                        CheckExist.ContainerWeight_Net = ContainerWeightObj.ContainerWeight_Net;
                        CheckExist.ContainerWeight_Gross = ContainerWeightObj.ContainerWeight_Gross;

                    }
                    else
                    {
                        errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateConainerWight() ";
                    }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის განახლება ვერ განახლდა: UpdateConainerWight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateConainerWight()\n" + ex.Message;
                }
            }
        }

        public static void UpdateOldContainerLocation(BerryManagementEntities context, ContainerLocation ContainerLocationObj, ref string errorMessage)
        {
            try
            {
                string BarCode = ContainerLocationObj.ContainerLocation_Container_BarCode.ToString();
                ContainerLocation CheckExist = SelectQ.CheckContainerLocationForPackaging(BarCode, context, ref errorMessage).FirstOrDefault();

                if (CheckExist != null)
                {
                    CheckExist.ContainerLocation_Out_ContainerMoveInOut_Id = ContainerLocationObj.ContainerLocation_Out_ContainerMoveInOut_Id;
                    CheckExist.ContainerLocation_Out_DateTime = ContainerLocationObj.ContainerLocation_Out_DateTime;
                    CheckExist.ContainerLocation_Out_User_PersonPost_Id = ContainerLocationObj.ContainerLocation_Out_User_PersonPost_Id;
                   // context.SaveChanges();
                }
                else
                {
                    errorMessage = "ჩანაწერის ვერ მოიძებნა UpdateOldContainerLocation() ";
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის განახლება ვერ განახლდა: UpdateOldContainerLocation()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n ჩანაწერის განახლება ვერ მოხერხდა: UpdateOldContainerLocation()\n" + ex.Message;
                }
            }
        }
               
        public static void UpdateProductOwnerWithOuterContext(BerryManagementEntities context, ProductOwner productOwner,
            ref String errorMessage)
        {
            try
            {
                ProductOwner productOwnerT = SelectQ.GetProductOwners(context, productOwner.ProductOwner_Id, null,
                    null, null, ref errorMessage).FirstOrDefault();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return;
                }
                productOwnerT.ProducOwnert_DateTime = productOwner.ProducOwnert_DateTime;
                productOwnerT.ProductOwner_CompanyId = productOwner.ProductOwner_CompanyId;
                productOwnerT.ProductOwner_Product_Id = productOwner.ProductOwner_Product_Id;
                productOwnerT.ProductOwner_Status = productOwner.ProductOwner_Status;
                productOwnerT.ProductOwner_User_PersonPost_Id = productOwner.ProductOwner_User_PersonPost_Id;
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateProductOwnerWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: UpdateProductOwnerWithOuterContext()\n" + ex.Message;
                }
            }
        }

    }
}
