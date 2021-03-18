using BerryManagementWindowsService.Data.Operation.XClasses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BerryManagementWindowsService.Data.Operation
{
    public static class Insert
    {
        public static bool InsertContainerWeight(ContainerWeight containerWeight, ref String errorMessage) 
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    InsertContainerWeightWithOuterContext(context, containerWeight, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void InsertSale(SaleContainer saleContainer, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        SaleContainer firstContainer = SelectQ.GetSaleContainer(context, saleContainer.Company_Id, false, ref errorMessage).
                            Where(sc => sc.Id == sc.Identifier).FirstOrDefault();
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return;
                        }
                        try
                        {
                            if (firstContainer != null)
                            {
                                saleContainer.Identifier = firstContainer.Identifier;
                            }
                            else
                            {
                                saleContainer.Identifier = saleContainer.Id;
                            }
                            Sale sale = new Sale()
                            {
                                Sale_Company_Id = saleContainer.Company_Id,
                                Sale_Container_BarCode = saleContainer.ContainerBarCode,
                                Sale_DateTime = saleContainer.Time,
                                Sale_Id = saleContainer.Id,
                                Sale_Identifier = saleContainer.Identifier,
                                Sale_IsComplite = false,
                                Sale_User_PersonPost_Id = saleContainer.PersonPostId
                            };
                            context.Sales.Add(sale);
                            ContainerLocation containerLocation = context.ContainerLocations.Where(c =>
                                c.ContainerLocation_Out_ContainerMoveInOut_Id == null &&
                                c.ContainerLocation_Container_BarCode == saleContainer.ContainerBarCode).First();
                            containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = saleContainer.Id;
                            containerLocation.ContainerLocation_Out_DateTime = saleContainer.Time;
                            containerLocation.ContainerLocation_Out_User_PersonPost_Id = saleContainer.PersonPostId;
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  InsertPaletSale()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  InsertPaletSale()\n" + ex.Message;
                }
            }
        }

        public static void InsertContainerWeightWithOuterContext(BerryManagementEntities context, ContainerWeight containerWeight,
            ref String errorMessage)
        {
            try
            {                
                    context.ContainerWeights.Add(containerWeight);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeightWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeightWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static bool InsertContainerPack(ContainerPack containerPack, long userPointId,ref String errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        try
                        {
                            ContainerLocation parentContainerlocation=null;
                            List<ContainerLocation> check = context.ContainerLocations.Where(c => c.ContainerLocation_Container_BarCode == containerPack.ContainerPack_Parent_Container_BarCode && c.ContainerLocation_Point_Id == userPointId && c.ContainerLocation_Out_ContainerMoveInOut_Id == null).ToList();
                            //პალეტის შემოწმება თუ უკვე არის ჩაწერილი Location-ში
                            if (check.Count == 0)
                            {
                                //პალეტის ჩაწერა Location-ში
                                parentContainerlocation = new ContainerLocation()
                                {
                                    ContainerLocation_Container_BarCode = containerPack.ContainerPack_Parent_Container_BarCode,
                                    ContainerLocation_Point_Id = userPointId,
                                    ContainerLocation_In_Id = containerPack.ContainerPack_Id,
                                    ContainerLocation_In_User_PersonPost_Id = containerPack.ContainerPack_User_PersonPost_Id,
                                    ContainerLocation_In_DateTime = DateTime.Now
                                };
                                context.ContainerLocations.Add(parentContainerlocation);
                            }
                            //Guid ების შექმნა
                            Guid guid = check.Count == 0 ? parentContainerlocation.ContainerLocation_In_Id : check.FirstOrDefault().ContainerLocation_In_Id;
                            Guid newguid = check.Count == 0 ? parentContainerlocation.ContainerLocation_In_Id : Guid.NewGuid();

                            ContainerLocation containerLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null && c.ContainerLocation_Container_BarCode == containerPack.ContainerPack_Container_BarCode).FirstOrDefault();
                            //ყუთის location ის Out
                            containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = newguid;
                            containerLocation.ContainerLocation_Out_DateTime = DateTime.Now;
                            containerLocation.ContainerLocation_Out_User_PersonPost_Id = containerPack.ContainerPack_User_PersonPost_Id;
                           
                            //ყუთის ConatinerPacKs
                            containerPack.ContainerPack_Id = newguid;
                            containerPack.ContainerPack_Parent_ContainerLocation_In_Id = guid;

                            
                            context.ContainerPacks.Add(containerPack);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                           
                            result = true;
                        }
                        catch (Exception ex)
                        {
                            dbContextTransaction.Rollback();
                            if (System.String.IsNullOrEmpty(errorMessage))
                            {
                                errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPack()\n" + ex.Message;
                            }
                            else
                            {
                                errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPack()\n" + ex.Message;
                            }
                        }


                        //InsertContainerPackWithOuterContext(context, containerPack, ref errorMessage);
                        //if (string.IsNullOrEmpty(errorMessage))
                        //{
                        //    context.SaveChanges();
                        //    result = true;
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPack()\n" + ex.Message;
                }
            }

            return result;
        }

        public static void InsertContainerPackWithOuterContext(BerryManagementEntities context, ContainerPack containerPack, ref String errorMessage)
        {
            try
            {
                context.ContainerPacks.Add(containerPack);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPackWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerPackWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static bool InsertProductPack(ProductPack productPack, ref String errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    InsertProductPackWithOuterContext(context, productPack, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductPack()\n" + ex.Message;
                }
            }

            return result;
        }

        public static void InsertProductPackWithOuterContext(BerryManagementEntities context, ProductPack productPack, ref String errorMessage)
        {
            try
            {
                context.ProductPacks.Add(productPack);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductPackWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductPackWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static bool InsertProductQuality(ProductQuality productQuality, ref String errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    InsertProductQualityWithOuterContext(context, productQuality, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductQuality()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void InsertProductQualityWithOuterContext(BerryManagementEntities context, ProductQuality productQuality, ref String errorMessage)
        {
            try
            {
                context.ProductQualities.Add(productQuality);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductQualityWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductQualityWithOuterContext()\n" + ex.Message;
                }
            }
        }

        public static bool InsertProductReceive(ProductReceive productReceive, ref String errorMessage)
        {

            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.ProductReceives.Add(productReceive);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertTakeRow(TakeRow takeRow, ref String errorMessage)
        {
            long result = -1;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.TakeRows.Add(takeRow);
                    context.SaveChanges();
                    result = takeRow.TakeRow_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
                }
            }
            return result;
        }
        
        public static bool InsertHarvesterRowDistribution(HarvesterRowDistribution harvDist, ref String errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.HarvesterRowDistributions.Add(harvDist);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
            }

            return result;
        }

        public static bool HarvesterContainerDistribution(HarvesterContainerDistribution harvDist, ref String errorMessage)
        {
            bool result = false;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.HarvesterContainerDistributions.Add(harvDist);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
            }

            return result;
        }

        public static bool InsertContainerMove(ContainerMove containerMove, bool? direction,ref String errorMessage)
        {
            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (direction.Value)
                    {
                        using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                containerMove.ContainerMove_Out_ContainerMoveInOut_Id = null;
                                containerMove.ContainerMove_Out_DateTime = null;
                                containerMove.ContainerMove_Out_User_PersonPost_Id = null;
                                containerMove.ContainerMove_Out_User_Point_Id = null;

                                context.ContainerMoves.Add(containerMove);

                                var containerLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null && c.ContainerLocation_Point_Id == containerMove.ContainerMove_In_User_Point_Id && c.ContainerLocation_Container_BarCode==containerMove.ContainerMove_Container_BarCode).FirstOrDefault();

                                containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = containerMove.ContainerMove_In_ContainerMoveInOut_Id;
                                containerLocation.ContainerLocation_Out_DateTime = DateTime.Now;
                                containerLocation.ContainerLocation_Out_User_PersonPost_Id = containerMove.ContainerMove_In_User_PersonPost_Id;

                                var containerLocationModel = new ContainerLocation()
                                {
                                    ContainerLocation_Container_BarCode = containerMove.ContainerMove_Container_BarCode,
                                    ContainerLocation_Point_Id = containerMove.ContainerMove_Car_Point_Id,
                                    ContainerLocation_In_Id = containerMove.ContainerMove_In_ContainerMoveInOut_Id,
                                    ContainerLocation_In_User_PersonPost_Id = containerMove.ContainerMove_In_User_PersonPost_Id,
                                    ContainerLocation_In_DateTime = DateTime.Now
                                };
                                context.ContainerLocations.Add(containerLocationModel);

                                context.SaveChanges();
                                dbContextTransaction.Commit();
                                result = true;
                            }
                            catch (Exception)
                            {

                                dbContextTransaction.Rollback();
                            }
                           
                        }

                    }
                    else
                    {
                        ContainerMove containerMovee = SelectQ.GetContainerMove(context, containerMove.ContainerMove_Id, null, null, null, null, false, ref errorMessage).FirstOrDefault();
                        if (containerMovee != null)
                        {
                            containerMovee.ContainerMove_Id = containerMove.ContainerMove_Id;
                            containerMovee.ContainerMove_TransportWaybill_Id = containerMove.ContainerMove_TransportWaybill_Id;
                            containerMovee.ContainerMove_Container_BarCode = containerMove.ContainerMove_Container_BarCode;
                            containerMovee.ContainerMove_Car_Point_Id = containerMove.ContainerMove_Car_Point_Id; ;
                            containerMovee.ContainerMove_In_ContainerMoveInOut_Id = containerMove.ContainerMove_In_ContainerMoveInOut_Id;
                            containerMovee.ContainerMove_In_User_PersonPost_Id = containerMove.ContainerMove_In_User_PersonPost_Id;
                            containerMovee.ContainerMove_In_User_Point_Id = containerMove.ContainerMove_In_User_Point_Id;
                            containerMovee.ContainerMove_In_DateTime = containerMove.ContainerMove_In_DateTime;
                            containerMovee.ContainerMove_Out_ContainerMoveInOut_Id = containerMove.ContainerMove_Out_ContainerMoveInOut_Id;
                            containerMovee.ContainerMove_Out_User_PersonPost_Id = containerMove.ContainerMove_Out_User_PersonPost_Id;
                            containerMovee.ContainerMove_Out_User_Point_Id = containerMove.ContainerMove_Out_User_Point_Id;
                            containerMovee.ContainerMove_Out_DateTime = containerMove.ContainerMove_Out_DateTime;
                            context.SaveChanges();
                            result = true;
                        }
                        else
                        {
                            errorMessage = "შეცდომა: UpdateTakeRowWithOuterContext()\nშესაცვლელი ჩანაწერი არ მოიძებნა";
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
            }

            return result;
        }

        public static bool InsertContainerMoveWithOuterContext(BerryManagementEntities context,ContainerMove containerMove, ref String errorMessage)
        {
            bool result = false;

            try
            {
                
                    context.ContainerMoves.Add(containerMove);
                    context.SaveChanges();
                    result = true;
                
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
                }
            }

            return result;
        }

        public static bool InsertNewContainerInLocation(BerryManagementEntities context, ContainerLocation containerLocation, ref String errorMessage)
        {
            bool result = false;

            try
            {
                context.ContainerLocations.Add(containerLocation);
                result = true;

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNewContainerInLocation()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNewContainerInLocation()\n" + ex.Message;
                }
            }

            return result;
        }

        public static long InsertTransaction( ref string errorMessage, params object []entities) 
        {
            long result = 0;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < entities.Length; i++)
                        {
                            var model = entities[i];

                            context.Set(model.GetType()).Add(model);
                            context.SaveChanges();
                        }
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentTemplate()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentTemplate()\n" + ex.Message;
                        }
                    }
                }
            }
            return result;
        }

        public static bool InsertPalleteWeight(BerryManagementEntities context, Guid guid,string pal_barcode,long user_Id,ref string errorMessage)
        {
            bool result = false;

            try
            {

                    var wqe = SelectQ.GetPalleteWeight(context,pal_barcode,ref errorMessage).ToList().FirstOrDefault();

                    var palletWeight = context.OperationSettings.Where(c => c.OperationSetting_Key.Equals("PaletWeight")).ToList().First();

                    ContainerWeight obj = new ContainerWeight();
                    obj.ContainerWeight_Container_BarCode = pal_barcode;
                    obj.ContainerWeight_DateTime = DateTime.Now;
                    obj.ContainerWeight_Net = wqe.Pallete_Net_weight;
                    obj.ContainerWeight_User_PersonPost_Id = user_Id;
                    obj.ContainerWeight_Gross = wqe.Pallete_Gross_weight + decimal.Parse(palletWeight.OperationSetting_Value);
                    obj.ContainerWeight_Id = guid;

                    context.ContainerWeights.Add(obj);
                    //context.SaveChanges();
                    result = true;

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNewContainerInLocation()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNewContainerInLocation()\n" + ex.Message;
                }
            }

            return result;
        }

        public static long InsertProductOwnerWithOuterContext(BerryManagementEntities context, ProductOwner productOwner,
            ref String errorMessage)
        {
            long result = 0;
            try
            {
                ProductOwner productOwnerT = SelectQ.GetProductOwners(context, productOwner.ProductOwner_Id, productOwner.ProductOwner_Product_Id,
                    productOwner.ProductOwner_CompanyId, productOwner.ProductOwner_Status, ref errorMessage).FirstOrDefault();
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                if (productOwnerT == null)
                {
                    context.ProductOwners.Add(productOwner);
                }
                else
                {
                    productOwner.ProductOwner_Id = productOwnerT.ProductOwner_Id;
                    Update.UpdateProductOwnerWithOuterContext(context, productOwner, ref errorMessage);
                }
                context.SaveChanges();
                result = productOwner.ProductOwner_Id;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductOwnerWithOuterContext()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductOwnerWithOuterContext()\n" + ex.Message;
                }
            }
            return result;
        }

        //public static bool InsertContainerInOut(XClasses.ContainerMoveInOut containerInOut, ref String errorMessage)
        //{

        //    bool result = false;

        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            context.ContainerMoveInOuts.Add(containerInOut);
        //            context.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}
        //public static bool InsertHarvesterRowDistributionInOut(HarvesterRowDistributionInOut harvesterInOut, ref String errorMessage)
        //{

        //    bool result = false;

        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            context.HarvesterRowDistributionInOuts.Add(harvesterInOut);
        //            context.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertProductReceive()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        //public static bool InsertTakeRowInOut(TakeRowInOut takeRowInOut, ref String errorMessage)
        //{
        //    bool result = false;

        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            context.TakeRowInOuts.Add(takeRowInOut);
        //            context.SaveChanges();
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainerWeights()\n" + ex.Message;
        //        }
        //    }

        //    return result;
        //}
    }
}
