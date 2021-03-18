using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using BerryManagementWindowsService.Data.Operation.XClasses;

namespace BerryManagementWindowsService.Data.Operation
{
    public static class Fixator
    {
        #region TakeRowInOut

        public static void FixTakeRowInOut(XClasses.TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            try
            {
                if (takeRowInOut.RowId == null)
                {
                    takeRowInOut.RowId = Structure.SelectL.GetRows(null, takeRowInOut.RowBarCode, ref errorMessage).FirstOrDefault().Row_Id;
                }

                if (takeRowInOut.Direction)
                {
                    if (!TakeRowInIsExists(takeRowInOut, ref errorMessage))
                    {
                        CreateTakeRowByTakeRowInOut(takeRowInOut, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემი უკვე არსებობს ";
                        return;
                    }
                }
                else
                {
                    if (TakeRowOutIsExists(takeRowInOut, ref errorMessage))
                    {
                        XClasses.HarvesterRowDistributionInOut harvesterRowDistributionInOut =
                            MakeHarvesterRowDistributionInOutBytakeRowInOut(takeRowInOut);
                        CloseTakeRowByTakeRowInOut(takeRowInOut, harvesterRowDistributionInOut, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემები ვერ მოიძებნა";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: FixContainerInOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: FixContainerInOut()\n" +
                                   ex.Message;
                }
            }
        }

        private static void CreateTakeRowByTakeRowInOut(XClasses.TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            TakeRow takeRow = GetInsertedTakeRow(takeRowInOut, ref errorMessage);
            Insert.InsertTakeRow(takeRow, ref errorMessage);
        }

        private static void CloseTakeRowByTakeRowInOut(XClasses.TakeRowInOut takeRowInOut,
            XClasses.HarvesterRowDistributionInOut harvesterRowDistributionInOut, ref string errorMessage)
        {
            TakeRow takeRow = GetUpdatedTakeRow(takeRowInOut, ref errorMessage);
            List<HarvesterRowDistribution> harvesterRowDistributions = GetUpdatedHarvesterRowDistributions(
                harvesterRowDistributionInOut, ref errorMessage);
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    Update.UpdateTakeRowWithOuterContext(context, takeRow, ref errorMessage);
                    foreach (HarvesterRowDistribution harvesterRowDistribution in harvesterRowDistributions)
                    {
                        Update.UpdateHarvesterRowDistributionWithOuterContext(context, harvesterRowDistribution,
                            ref errorMessage);
                    }

                    try
                    {
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        else
                        {
                            dbContextTransaction.Rollback();
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateTakeRow()\n" +
                                           ex.Message;
                        }
                    }
                }

            }
        }

        private static TakeRow GetInsertedTakeRow(XClasses.TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            TakeRow result = null;
            result = new TakeRow()
            {
                TakeRow_Brigade_Id = takeRowInOut.BrigadeId,
                TakeRow_In_DateTime = takeRowInOut.Time,
                TakeRow_In_TakeRowInOut_Id = takeRowInOut.Id,
                TakeRow_In_TUser_PersonPost_Id = takeRowInOut.PersonPostId,
                TakeRow_Row_Id = (long) takeRowInOut.RowId

            };
            return result;
        }

        private static TakeRow GetUpdatedTakeRow(XClasses.TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            TakeRow result = null;
            result = SelectL.GetTakeRows(null, takeRowInOut.RowId, null, null, null, true, ref errorMessage)
                .FirstOrDefault();
            result.TakeRow_Out_DateTime = takeRowInOut.Time;
            result.TakeRow_Out_TakeRowInOut_Id = takeRowInOut.Id;
            result.TakeRow_Out_User_PersonPost_Id = takeRowInOut.PersonPostId;
            return result;
        }

        private static bool TakeRowInIsExists(TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            bool result = true;
            int i = 0;
            i = i + SelectL.GetTakeRows(null, null, null, takeRowInOut.Id, null, false, ref errorMessage).Count();
            i = i + SelectL.GetTakeRows(null, takeRowInOut.RowId, null, null, null, true, ref errorMessage).Count();
            result = i > 0 ? true : false;
            return result;
        }

        private static bool TakeRowOutIsExists(TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            bool result = true;
            int i = SelectL.GetTakeRows(null, null, null, null, takeRowInOut.Id, true, ref errorMessage).Count();
            if (i > 0)
            {
                result = false;
            }
            else
            {
                i = SelectL.GetTakeRows(null, takeRowInOut.RowId, null, null, null, true, ref errorMessage).Count();
                if (i == 0)
                {
                    result = true;
                }
            }

            return result;
        }

        private static XClasses.HarvesterRowDistributionInOut MakeHarvesterRowDistributionInOutBytakeRowInOut(
            XClasses.TakeRowInOut takeRowInOut)
        {
            XClasses.HarvesterRowDistributionInOut result = null;
            result = new XClasses.HarvesterRowDistributionInOut()
            {
                Direction = false,
                HarvesterBarCode = null,
                HarvesterPersonPostId = null,
                Id = takeRowInOut.Id,
                IsComplete = false,
                RowBarCode = takeRowInOut.RowBarCode,
                RowId = takeRowInOut.RowId,
                Time = takeRowInOut.Time,
                UserPersonPostId = takeRowInOut.PersonPostId
            };
            return result;
        }

        #endregion TakeRowInOut

        #region HarvesterRowDistributionInOut

        public static void FixHarvesterRowDistributionInOut(XClasses.HarvesterRowDistributionInOut harvesterRowInOut,
            ref string errorMessage)
        {
            try
            {
                if (harvesterRowInOut.HarvesterPersonPostId == null)
                {
                    harvesterRowInOut.HarvesterPersonPostId =
                        Employees.SelectL.GetPersonPostByBarcode(harvesterRowInOut.HarvesterBarCode, ref errorMessage).FirstOrDefault().PersonPost_Id;
                }
                if (harvesterRowInOut.RowBarCode == null)
                {
                    harvesterRowInOut.RowId = SelectL.GetHarvesterRowDistribution(null, null, harvesterRowInOut.HarvesterPersonPostId, null, null, true, ref errorMessage).FirstOrDefault().HarvesterRowDistribution_Row_Id;
                }else if (harvesterRowInOut.RowId == null)  
                {
                    harvesterRowInOut.RowId = Structure.SelectL.GetRows(null, harvesterRowInOut.RowBarCode, ref errorMessage)
                        .FirstOrDefault().Row_Id;
                }

               
                if (harvesterRowInOut.Direction)
                {
                    if (HarvesterRowDistributionInExists(harvesterRowInOut.HarvesterPersonPostId.Value,
                            ref errorMessage) == 0)
                    {
                        CreateHarvesterDistributionByHarvDistInOut(harvesterRowInOut, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემი უკვე არსებობს ";
                        return;
                    }
                }
                else
                {
                    if (HarvesterRowDistributionOutExists(harvesterRowInOut.HarvesterPersonPostId.Value,
                            ref errorMessage) > 0)
                    {
                        CloseHarvesterRowDistribution(harvesterRowInOut, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემები ვერ მოიძებნა";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: FixHarvesterRowDistributionInOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: FixHarvesterRowDistributionInOut()\n" +
                                   ex.Message;
                }
            }
        }

        private static void CreateHarvesterDistributionByHarvDistInOut(
            XClasses.HarvesterRowDistributionInOut harvesterDistInOut,
            ref string errorMessage)
        {
            HarvesterRowDistribution harvDist =
                GetInsertedHarvesterRowDistribution(harvesterDistInOut, ref errorMessage);
            Insert.InsertHarvesterRowDistribution(harvDist, ref errorMessage);
        }

        private static void CloseHarvesterRowDistribution(XClasses.HarvesterRowDistributionInOut harvesterDistInOut,
            ref string errorMessage)
        {

            var harvesterRowDistributions = SelectL.GetHarvesterRowDistribution(null, harvesterDistInOut.RowId, null,
                null, null, true, ref errorMessage);
            HarvesterRowDistribution harvesterRowDistribution =
                ConstructHarvesterRowDistribution(harvesterDistInOut, ref errorMessage);

            if (harvesterRowDistributions.Count == 1)
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                    {
                        var takeRows = SelectL.GetTakeRows(null, harvesterDistInOut.RowId, null, null, null, true,
                            ref errorMessage);
                        foreach (var item in takeRows)
                        {
                            item.TakeRow_Out_DateTime = DateTime.Now;
                            item.TakeRow_Out_TakeRowInOut_Id = Guid.NewGuid();
                            item.TakeRow_Out_User_PersonPost_Id = harvesterDistInOut.UserPersonPostId;
                            Update.UpdateTakeRowWithOuterContext(context, item, ref errorMessage);
                        }

                        Update.UpdateHarvesterRowDistributionWithOuterContext(context, harvesterRowDistribution,
                            ref errorMessage);
                        if (!String.IsNullOrEmpty(errorMessage))
                            dbContextTransaction.Rollback();
                        else
                        {
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                    }


                }
            }
            else
            {
                Update.UpdateHarvesterRowDistribution(harvesterRowDistribution, ref errorMessage);
            }
        }

        private static HarvesterRowDistribution ConstructHarvesterRowDistribution(
            HarvesterRowDistributionInOut harvesterDistInOut, ref string errorMessage)
        {
            HarvesterRowDistribution harvesterRowDistribution =
                SelectL.GetHarvesterRowDistribution(null, harvesterDistInOut.RowId,harvesterDistInOut.HarvesterPersonPostId.Value,null,null,true,
                    ref errorMessage).FirstOrDefault();
            harvesterRowDistribution.HarvesterRowDistribution_Out_DateTime = DateTime.Now;
            harvesterRowDistribution.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id = Guid.NewGuid();
            harvesterRowDistribution.HarvesterRowDistribution_Out_User_PersonPost_Id =
                harvesterDistInOut.UserPersonPostId;
            return harvesterRowDistribution;
        }

        private static HarvesterRowDistribution GetInsertedHarvesterRowDistribution(
            XClasses.HarvesterRowDistributionInOut harvesterDistInOut,
            ref string errorMessage)
        {
            HarvesterRowDistribution harvDist = new HarvesterRowDistribution()
            {
                HarvesterRowDistribution_Harvester_PersonPost_Id = (long)harvesterDistInOut.HarvesterPersonPostId,
                HarvesterRowDistribution_In_DateTime = harvesterDistInOut.Time,
                HarvesterRowDistribution_In_HarvesterRowDistributionInOut_Id = harvesterDistInOut.Id,
                HarvesterRowDistribution_In_User_PersonPost_Id = harvesterDistInOut.UserPersonPostId,
                HarvesterRowDistribution_Row_Id = harvesterDistInOut.RowId.Value,
            };
            return harvDist;
        }



        private static List<HarvesterRowDistribution> GetUpdatedHarvesterRowDistributions(
            XClasses.HarvesterRowDistributionInOut harvesterDistInOut,
            ref string errorMessage)
        {
            List<HarvesterRowDistribution> result = null;
            if (harvesterDistInOut.HarvesterPersonPostId != null || harvesterDistInOut.HarvesterBarCode != null ||
                harvesterDistInOut.RowId != null || harvesterDistInOut.RowBarCode != null)
            {
                if (harvesterDistInOut.HarvesterPersonPostId == null && harvesterDistInOut.HarvesterBarCode != null)
                {
                    harvesterDistInOut.HarvesterPersonPostId = Employees.SelectL.GetPersonPostData(null, null, null,
                        harvesterDistInOut.HarvesterBarCode, ref errorMessage).FirstOrDefault().PersonPost_Id;
                }

                if (harvesterDistInOut.RowId == null && harvesterDistInOut.RowBarCode != null)
                {
                    harvesterDistInOut.RowId = Structure.SelectL.GetRows(null, harvesterDistInOut.RowBarCode,
                        ref errorMessage).FirstOrDefault().Row_Id;
                }

                result = SelectL.GetHarvesterRowDistribution(null, harvesterDistInOut.RowId,
                    harvesterDistInOut.HarvesterPersonPostId, null, null, true, ref errorMessage);
                foreach (HarvesterRowDistribution harvesterRowDistribution in result)
                {
                    harvesterRowDistribution.HarvesterRowDistribution_Out_DateTime = harvesterDistInOut.Time;
                    harvesterRowDistribution.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id =
                        harvesterDistInOut.Id;
                    harvesterRowDistribution.HarvesterRowDistribution_Out_User_PersonPost_Id =
                        harvesterDistInOut.UserPersonPostId;
                }
            }
            else
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage =
                        "ასეთი პარამეტრებით კრეფის პროცესში მყოფი რიგის პოვნა შეუძლებელია: GetUpdatedHarvesterRowDistributions()";
                }
                else
                {
                    errorMessage = errorMessage +
                                   "\nასეთი პარამეტრებით კრეფის პროცესში მყოფი რიგის პოვნა შეუძლებელია: GetUpdatedHarvesterRowDistributions()";
                }
            }

            return result;
        }

        private static int HarvesterRowDistributionInExists(long personPostId, ref string errorMessage)
        {
            return SelectL.GetHarvesterRowDistribution(null, null, personPostId, null, null, true, ref errorMessage)
                .Count;
        }

        private static int HarvesterRowDistributionOutExists(long personPostId, ref string errorMessage)
        {
            return SelectL.GetHarvesterRowDistribution(null, null, personPostId, null, null, true, ref errorMessage)
                .Count();
        }

        #endregion

        #region SaleContainer

        public static int FixSaleContainer(SaleContainer saleContainer, bool isComplite, long? companyId, ref string errorMessage)
        {
                if (isComplite)
                {
                    Update.FixSale((long)companyId, ref errorMessage);
                }
                else
                {
                    Insert.InsertSale(saleContainer, ref errorMessage);
                }
            return Update.GetSaleCount(ref errorMessage);
        }
               
        #endregion SaleContainer

        #region ContainerMoveInOuts

        public static int FixContainerMoveInOut(ContainerMove containerMoveInOut, bool direction, ref string errorMessage)
        {
            int result = 0;
            try
            {
                //if (containerMoveInOut.Point_Car_Id == null)
                //{
                //    containerMoveInOut.Point_Car_Id = SelectL
                //        .GetPointById(null, containerMoveInOut.PointBarcode, ref errorMessage).FirstOrDefault()
                //        .Point_Car_Id;
                //}
                if (direction)
                {
                    int countIn = ContainerMoveInExists(containerMoveInOut, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    if (countIn == 0)
                    {
                        CreateContainerMove(containerMoveInOut, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                    }
                    else
                    {
                        errorMessage = "მონაცემი უკვე არსებობს";
                        return result;
                    }
                    result = SelectL.GetCountForContainerMove( containerMoveInOut.ContainerMove_TransportWaybill_Id, direction, ref errorMessage);
                }
                else
                {
                    int countOut = ContainerMoveOutExists(containerMoveInOut, ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return result;
                    }
                    if (countOut > 0)
                    {
                        CloseContainerMove(containerMoveInOut, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                    }
                    else
                    {
                        errorMessage = "მონაცემები ვერ მოიძებნა";
                        return result;
                    }
                    result = SelectL.GetCountForContainerMove(containerMoveInOut.ContainerMove_TransportWaybill_Id, direction, ref errorMessage);
                    if (result == 0)
                    {
                        Data.TransportWaybill transportWaybill = RS.SelectL.GetTransportWaybills(containerMoveInOut.ContainerMove_TransportWaybill_Id,
                            null, null, null, null, null, false, null, false, null, false, null, false, ref errorMessage).FirstOrDefault();
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                        transportWaybill.TransportWaybill_End_DateTime = DateTime.Now;
                        RS.Update.UpdateTransportWaybill(transportWaybill, ref errorMessage);
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            return result;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: FixContainerMoveInOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: FixContainerMoveInOut()\n" +
                                   ex.Message;
                }
            }
            return result;
        }

        private static void CreateContainerMove(ContainerMove containerMoveInOut, ref string errorMessage)
        {
            ContainerMove container = new ContainerMove()
            {
                ContainerMove_Car_Point_Id = containerMoveInOut.ContainerMove_Car_Point_Id,
                ContainerMove_Container_BarCode = containerMoveInOut.ContainerMove_Container_BarCode,
                ContainerMove_In_ContainerMoveInOut_Id = containerMoveInOut.ContainerMove_In_ContainerMoveInOut_Id,
                ContainerMove_In_DateTime = containerMoveInOut.ContainerMove_In_DateTime,
                ContainerMove_In_User_PersonPost_Id = containerMoveInOut.ContainerMove_In_User_PersonPost_Id,
                ContainerMove_In_User_Point_Id = containerMoveInOut.ContainerMove_In_User_Point_Id,
                ContainerMove_TransportWaybill_Id= containerMoveInOut.ContainerMove_TransportWaybill_Id

            };
            Insert.InsertContainerMove(container, true, ref errorMessage);
            //using (BerryManagementEntities context = new BerryManagementEntities())
            //{
            //    using (DbContextTransaction transaction = context.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            CreateContainerMoveWithOuterContext(context, container, ref errorMessage);
            //            Update.UpdateContainerLocationWithOuterContext(context, containerMoveInOut, ref errorMessage);
            //            ContainerLocation containerLocation = new ContainerLocation()
            //            {
            //                ContainerLocation_Container_BarCode = containerMoveInOut.ContainerMove_Container_BarCode,
            //                ContainerLocation_In_DateTime = containerMoveInOut.ContainerMove_In_DateTime,
            //                ContainerLocation_In_Id = containerMoveInOut.ContainerMove_In_ContainerMoveInOut_Id,
            //                ContainerLocation_In_User_PersonPost_Id = containerMoveInOut.ContainerMove_In_User_PersonPost_Id,
            //                ContainerLocation_Point_Id = containerMoveInOut.ContainerMove_Out_User_Point_Id.Value
            //            };
            //            context.ContainerLocations.Add(containerLocation);
            //            if (string.IsNullOrEmpty(errorMessage))
            //            {
            //                context.SaveChanges();
            //                transaction.Commit();
            //            }

            //        }
            //        catch (Exception ex)
            //        {
            //            errorMessage = "დაფიქსირდა შეცდომა : CreateContainerMove";
            //            transaction.Rollback();
            //        }

            //    }
                    
            //}

        }

        private static void CreateContainerMoveWithOuterContext(BerryManagementEntities context, ContainerMove containerMoveInOut, ref string errorMessage)
        {
            ContainerMove container = new ContainerMove()
            {
                ContainerMove_Car_Point_Id = containerMoveInOut.ContainerMove_Car_Point_Id,
                ContainerMove_Container_BarCode = containerMoveInOut.ContainerMove_Container_BarCode,
                ContainerMove_In_ContainerMoveInOut_Id = containerMoveInOut.ContainerMove_In_ContainerMoveInOut_Id,
                ContainerMove_In_DateTime = containerMoveInOut.ContainerMove_In_DateTime,
                ContainerMove_In_User_PersonPost_Id = containerMoveInOut.ContainerMove_In_User_PersonPost_Id,
                ContainerMove_In_User_Point_Id = containerMoveInOut.ContainerMove_In_User_Point_Id

            };
            Insert.InsertContainerMoveWithOuterContext(context, container, ref errorMessage);
        }

        private static void CloseContainerMove(ContainerMove containerMoveInOut, ref string errorMessage)
        {

            var hd = SelectL
                .GetContainerMove(null, null, null, containerMoveInOut.ContainerMove_Container_BarCode, null, true, ref errorMessage)
                .FirstOrDefault();
            hd.ContainerMove_Out_DateTime = containerMoveInOut.ContainerMove_Out_DateTime;
            hd.ContainerMove_Out_ContainerMoveInOut_Id = containerMoveInOut.ContainerMove_Out_ContainerMoveInOut_Id;
            hd.ContainerMove_Out_User_PersonPost_Id = containerMoveInOut.ContainerMove_Out_User_PersonPost_Id;
            hd.ContainerMove_Out_User_Point_Id = containerMoveInOut.ContainerMove_Out_User_Point_Id;
            hd.ContainerMove_Car_Point_Id = containerMoveInOut.ContainerMove_Car_Point_Id;
            Update.UpdateContainerMove(hd, ref errorMessage);
        }

        private static int ContainerMoveInExists(ContainerMove containerMove, ref string errorMessage)
        {
            int result = -1;
            result = SelectL.GetContainerMove(null, null, containerMove.ContainerMove_TransportWaybill_Id,
                containerMove.ContainerMove_Container_BarCode, null, true, ref errorMessage).Count;
            return result;
        }

        private static int ContainerMoveOutExists(ContainerMove containerMove, ref string errorMessage)
        {
            int result = -1;
            result = SelectL.GetContainerMove(null, null, containerMove.ContainerMove_TransportWaybill_Id,
                containerMove.ContainerMove_Container_BarCode, null, true, ref errorMessage).Count;
            return result;
        }


        #endregion

        #region HarvesterContainerDistributionInOut

        public static void FixHarvesterContainerDistribution(XClasses.HarvesterContainerDistributionInOut harvesterContainer, ref string errorMessage)
        {
            try
            {
                if (harvesterContainer.CarId == null)
                {
                    harvesterContainer.CarId = SelectL
                        .GetPointById(harvesterContainer.PointId, null, ref errorMessage).FirstOrDefault()
                        .Point_Car_Id;
                }
                if (harvesterContainer.HarvesterPersonPostId== null)
                {
                    harvesterContainer.HarvesterPersonPostId = Employees.SelectL
                        .GetPersonPostByBarcode(harvesterContainer.HarvesterBarCode, ref errorMessage).FirstOrDefault()
                        .PersonPost_Id;
                }
                if (harvesterContainer.Direction)
                {
                    if (HarvesterContainerInExists(harvesterContainer.ContaierBarcode, ref errorMessage) == 0)
                    {
                        CreateHarvesterContainerDistribution(harvesterContainer, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემი უკვე არსებობს ";
                        return;
                    }
                }
                else
                {
                    if (HarvesterContainerOutExists(harvesterContainer.ContaierBarcode, ref errorMessage) > 0)
                    {
                        CloseHarvesterContainerDistribution(harvesterContainer, ref errorMessage);
                    }
                    else
                    {
                        errorMessage = "მონაცემები ვერ მოიძებნა";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: FixHarvesterContainerDistribution()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: FixHarvesterContainerDistribution()\n" + ex.Message;
                }
            }
        }

        private static void CreateHarvesterContainerDistribution(XClasses.HarvesterContainerDistributionInOut harvesterContainer, ref string errorMessage)
        {
            HarvesterContainerDistribution harvCont = new HarvesterContainerDistribution()
            {
                HarvesterContainerDistribution_IN_DateTime = harvesterContainer.Time,
                HarvesterContainerDistribution_In_HarvesterContainerDistributionInOut_Id = harvesterContainer.Id,
                HarvesterContainerDistribution_In_User_PersonPost_Id = harvesterContainer.UserPersonPostId,
                HarvesterContainerDistribution_Container_BarCode = harvesterContainer.ContaierBarcode,
                HarvesterContainerDistribution_Harvester_PersonPost_Id = harvesterContainer.HarvesterPersonPostId.Value,


            };
            Insert.HarvesterContainerDistribution(harvCont, ref errorMessage);
        }

        private static void CloseHarvesterContainerDistribution(XClasses.HarvesterContainerDistributionInOut harvesterContainerDistribution, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {

                    var hd = SelectL.GetHarvesterContainerDistributions(null, harvesterContainerDistribution.ContaierBarcode, null, null, null, true, ref errorMessage).FirstOrDefault();
                    hd.HarvesterContainerDistribution_Out_DateTime = harvesterContainerDistribution.Time;
                    hd.HarvesterContainerDistribution_Out_HarvesterContainerDistributionInOut_Id = Guid.NewGuid();
                    hd.HarvesterContainerDistribution_Out_User_PersonPost_Id = harvesterContainerDistribution.UserPersonPostId;
                    Update.UpdateHarvesterContainerDistribution(context, hd, ref errorMessage);
                    ContainerMoveInOut container = new ContainerMoveInOut
                    {
                        ContainerBarCode = hd.HarvesterContainerDistribution_Container_BarCode,
                        Direction = true,
                        ContainerMoveInOut_Id = Guid.NewGuid(),
                        IsComplete = true,
                        PersonPostId = harvesterContainerDistribution.UserPersonPostId,
                        Point_Id = harvesterContainerDistribution.PointId,
                        Point_Car_Id = harvesterContainerDistribution.CarId.Value,
                        Time = harvesterContainerDistribution.Time

                    };
                    //if (ContainerMoveInExists(container.ContainerBarCode, ref errorMessage) == 0)
                        //CreateContainerMoveWithOuterContext(context, container, ref errorMessage);
                    if (string.IsNullOrEmpty(errorMessage))
                    {
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    else
                        dbContextTransaction.Rollback();


                }
            }
        }

        private static int HarvesterContainerInExists(string barcode, ref string errorMessage)
        {

            return SelectL.GetHarvesterContainerDistributions(null, barcode, null, null, null, false, ref errorMessage).Count;
        }

        private static int HarvesterContainerOutExists(string barcode, ref string errorMessage)
        {
            return SelectL.GetHarvesterContainerDistributions(null, barcode, null, null, null, true, ref errorMessage).Count();
        }

        #endregion

        #region EmployeePunishment

        public static void FixPunishment(PunishmentIn punishmentIn,  ref string errorMessage)
        {
            if ((punishmentIn.HardvesterPostId == null) && (punishmentIn.HardvesterBarcode == null) && (punishmentIn.ContainerBarcode == null))
            {
                errorMessage = "არ არის განსაზღვრული ვის ეკუთვნის საყვედური!";
                return;
            }
            if ((punishmentIn.PunishmentTypeId == null) && (punishmentIn.QualityTypeId == null))
            {
                errorMessage = "საყვედურის სახე არ არის განსაზღვრული!";
                return;
            }
            if ((punishmentIn.PunishmentTypeId == null) && (punishmentIn.QualityTypeId != null))
            {
                punishmentIn.PunishmentTypeId = punishmentIn.QualityTypeId;
            }
            if ((punishmentIn.HardvesterPostId == null) && ((punishmentIn.HardvesterBarcode != null) || (punishmentIn.ContainerBarcode != null)))
            {
                punishmentIn.HardvesterPostId = GetHarvesterPostId(punishmentIn, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return; 
                }
            }
            Punishment punishment = GetPunishment(punishmentIn);
            Employees.Insert.InsertPunishment(punishment, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
        }

        private static long GetHarvesterPostId(PunishmentIn punishmentIn, ref string errorMessage)
        {
            long result = 0;
            try
            {
                if (punishmentIn.HardvesterBarcode != null)
                {
                    result = Employees.SelectL.GetPersonPostByBarcode(punishmentIn.HardvesterBarcode, ref errorMessage).FirstOrDefault().PersonPost_Id;
                }
                else
                {
                    Guid productId = SelectL.GetProductPacks(null, null, punishmentIn.ContainerBarcode, null, null, true, ref errorMessage).First().ProductPack_Product_Id;
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception(errorMessage);
                    }
                    result = Produce.SelectL.GetProducts(productId, null, false, null, null, null, ref errorMessage).First().Product_Harvester_PersonPost_Id;
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception(errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: GetHarvesterPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: GetHarvesterPostId()\n" +
                                   ex.Message;
                }
            }
            return result;
        }

        private static Punishment GetPunishment(PunishmentIn punishmentIn)
        {
            Punishment punishment = null;
            punishment = new Punishment()
            {
                Punishment_DateTime = punishmentIn.Time,
                Punishment_Id = punishmentIn.Id,
                Punishment_PersonPost_Id = punishmentIn.UserPersonPostId,
                Punishment_PunishmentType_Id = (int)punishmentIn.PunishmentTypeId,
                Punishment_User_PersonPost_Id = punishmentIn.UserPersonPostId
            };
            return punishment;
        }

        #endregion EmployeePunishment

        #region ProductRePack

        public static void FixPackaging(ProductRepackAndWeight Container, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    Guid guid;
                    guid = Guid.NewGuid();
                    long packingPointId = int.Parse(Operation.SelectQ.GetOperationSettings(context, "PackingPointId", ref errorMessage).First().OperationSetting_Value);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        return;
                    }
                    ContainerLocation ContainerLocation = new ContainerLocation();
                    ContainerLocation.ContainerLocation_Container_BarCode = Container.ContainerBarCode;
                    ContainerLocation.ContainerLocation_Point_Id = packingPointId;
                    ContainerLocation.ContainerLocation_In_Id = guid;
                    ContainerLocation.ContainerLocation_In_User_PersonPost_Id = Container.UserPersonPostId;
                    ContainerLocation.ContainerLocation_In_DateTime = DateTime.Now;

                    Insert.InsertNewContainerInLocation(context, ContainerLocation, ref errorMessage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }

                    decimal DefaultContainerWeightCF = GetDefaultContainerWeightCF(ref errorMessage);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }

                    ContainerWeight ContainerWeight = new ContainerWeight();
                    ContainerWeight.ContainerWeight_Id = (Guid)Container.ProductId;
                    ContainerWeight.ContainerWeight_Net = (decimal)Container.Net;
                    ContainerWeight.ContainerWeight_Gross = (decimal)Container.Net + DefaultContainerWeightCF;

                    Update.UpdateConainerWight(context, ContainerWeight, ref errorMessage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }



                    ContainerLocation ContainerLocationUpdate = new ContainerLocation();
                    ContainerLocationUpdate.ContainerLocation_Container_BarCode = Container.OldContainerBarCode;
                    ContainerLocationUpdate.ContainerLocation_Out_ContainerMoveInOut_Id = guid;
                    ContainerLocationUpdate.ContainerLocation_Out_DateTime = DateTime.Now;
                    ContainerLocationUpdate.ContainerLocation_Out_User_PersonPost_Id = Container.UserPersonPostId;

                    Update.UpdateOldContainerLocation(context, ContainerLocationUpdate, ref errorMessage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }
                    try
                    {
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "FixPackaging()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nFixPackaging()\n" + ex.Message;
                        }
                    }
                }
            }
        }

        public static ProductRepackAndWeight FixProductRepackAndWeight(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            ProductRepackAndWeight result = null;
            decimal DefaultContainerWeightCS = GetDefaultContainerWeightCS(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            productRepackAndWeight.Net = productRepackAndWeight.Gross - DefaultContainerWeightCS;
            ProductPack oldProductPack = GetOldProductPack(productRepackAndWeight, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            productRepackAndWeight.HarvestDate = oldProductPack.ProductPack_In_DateTime;
            oldProductPack.ProductPack_Out_DateTime = productRepackAndWeight.Time;
            oldProductPack.ProductPack_Out_ProductPackInOut_Id = productRepackAndWeight.Id;
            oldProductPack.ProductPack_Out_User_PersonPost_Id = productRepackAndWeight.UserPersonPostId;
            productRepackAndWeight.ProductId = oldProductPack.ProductPack_Product_Id;
            Breed breed = GetBreed(oldProductPack, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            productRepackAndWeight.BreedName = breed.Breed_Name;
            ProductPack newProductPack = GetNewProductPack(productRepackAndWeight, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            productRepackAndWeight.ContainerBarCode = newProductPack.ProductPack_Container_BarCode;
            ContainerWeight containerWeight = GetContainerNewWeights(productRepackAndWeight);
            ProductRepackAndWeight(oldProductPack, newProductPack, containerWeight, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }


            //decimal DefaultContainerWeightCT = GetDefaultContainerWeightCF(ref errorMessage);
            //if (!string.IsNullOrEmpty(errorMessage))
            //{
            //    return result;
            //}
            //productRepackAndWeight.
            //new
            FixPackaging(productRepackAndWeight, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }

            productRepackAndWeight.IsComplite = true;
            result = productRepackAndWeight;
            return result;
        }

        private static decimal GetDefaultContainerWeightCS(ref string errorMessage)
        {
            decimal result = 0;
            try
            {
                string s = SelectL.GetOperationSettings("ContainerWeightCS", ref errorMessage).FirstOrDefault().OperationSetting_Value;
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("ყუთის წონის წაკითხვა ვერ მოხერხდა!");
                }
                result = decimal.Parse(s);
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetDefaultContainerWeightCS()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetDefaultContainerWeightCS()\n" + ex.Message;
                }
            }
            return result;
        }

        private static ProductPack GetOldProductPack(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            ProductPack result = null;
            try
            {
                result = SelectL.GetProductPacks(null, null, productRepackAndWeight.OldContainerBarCode, 
                    null, null, true, ref errorMessage).FirstOrDefault();
                if (result == null)
                {
                    throw new Exception("ყუთი " + productRepackAndWeight.OldContainerBarCode + " დასაფასოებელ ყუთებს შორის არ მოიძებნა:");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetOldProductPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetOldProductPack()\n" + ex.Message;
                }
            }
            return result;
        }

        private static Breed GetBreed(ProductPack oldProductPack, ref string errorMessage)
        {
            Breed result = null;
            string errorMessageProduct = null;
            string errorMessageBreed = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = (from p in Produce.SelectQ.GetProducts(context, oldProductPack.ProductPack_Product_Id,
                        null, false, null, null, null, ref errorMessageProduct)
                            join b in Library.SelectQ.GetBreeds(context, null, null, ref errorMessageBreed)
                            on p.Product_Breed_Id equals b.Breed_Id
                            select b).FirstOrDefault();
                    if (!(string.IsNullOrEmpty(errorMessageProduct) || string.IsNullOrEmpty(errorMessageBreed)) ||
                        result == null)
                    {
                        throw new Exception("პროდუქტის ჯიში ვერ მოიძებნა!");
                    }
                }                    
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetBreed()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetBreed()\n" + ex.Message;
                }
            }
            return result;
        }

        private static ProductPack GetNewProductPack(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            string barcode = string.Empty;
            string error = string.Empty;
            Product product = SelectL.GetContainerQuality((Guid)productRepackAndWeight.ProductId,ref error).FirstOrDefault();
            if (!string.IsNullOrEmpty(error))
            {
                errorMessage = errorMessage + error;
            }

            if(product.product_IsGood == false)
            {
                barcode = Library.XClass.ContainerBarCodeGenerator.CreateContainer("CL", ref errorMessage);
            }
            else
            {
                barcode = Library.XClass.ContainerBarCodeGenerator.CreateContainer("CS", ref errorMessage);
            }

            ProductPack result = null;
            result = new ProductPack()
            {
                ProductPack_Product_Id = (Guid)productRepackAndWeight.ProductId,
                ProductPack_Container_BarCode = barcode,
                ProductPack_In_DateTime = productRepackAndWeight.Time,
                ProductPack_In_ProductPackInOut_Id = productRepackAndWeight.Id,
                ProductPack_In_User_PersonPost_Id = productRepackAndWeight.UserPersonPostId
            };
            return result;
        }

        private static ContainerWeight GetContainerNewWeights(ProductRepackAndWeight productRepackAndWeight)
        {
            ContainerWeight result = null;
            result = new ContainerWeight()
            {
                ContainerWeight_Container_BarCode = productRepackAndWeight.ContainerBarCode,
                ContainerWeight_DateTime = productRepackAndWeight.Time,
                ContainerWeight_Gross = productRepackAndWeight.Gross,
                ContainerWeight_Id = productRepackAndWeight.Id,
                ContainerWeight_Net = (decimal)productRepackAndWeight.Net,
                ContainerWeight_User_PersonPost_Id = productRepackAndWeight.UserPersonPostId
            };
            return result;
        }

        //private static ProductQuality GetProductNewQuality(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        //{
        //    ProductQuality result = null;
        //    ProductQuality lastQuality = SelectL.GetProductQualities(null, productRepackAndWeight.ProductId, ref errorMessage).
        //        OrderByDescending(pq => pq.ProductQuality_DateTime).FirstOrDefault();
        //    if ((lastQuality != null) && (lastQuality.ProductQuality_Quality_Id != productRepackAndWeight.QualityId))
        //    {
        //        result = new ProductQuality()
        //        {
        //            ProductQuality_DateTime = productRepackAndWeight.Time,
        //            ProductQuality_Id = productRepackAndWeight.Id,
        //            ProductQuality_Product_Id = (Guid)productRepackAndWeight.ProductId,
        //            ProductQuality_User_PersonPost_Id = productRepackAndWeight.UserPersonPostId
        //        };
        //    }
        //    return result;
        //}

        private static void ProductRepackAndWeight(ProductPack oldProductPack, ProductPack newProductPack, ContainerWeight containerWeight,
            /*ProductQuality productQuality,*/ ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                {
                    Update.UpdateProductPackWithOuterContext(context, oldProductPack, ref errorMessage);
                    if(!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }
                    Insert.InsertProductPackWithOuterContext(context, newProductPack, ref errorMessage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }
                    Insert.InsertContainerWeightWithOuterContext(context, containerWeight, ref errorMessage);
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        dbContextTransaction.Rollback();
                        return;
                    }
                    try
                    {
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ProductRepackAndWeight()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nProductRepackAndWeight()\n" + ex.Message;
                        }
                    }
                }
            }
        }

        #endregion ProductRePack

        #region ProductQuality
        public static void FixProductQuality(string containerBarcode, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var productPack = context.ProductPacks.Where(c => c.ProductPack_Container_BarCode == containerBarcode && c.ProductPack_Out_ProductPackInOut_Id == null).FirstOrDefault();
                    Product product = context.Products.Where(y => y.Product_Id == productPack.ProductPack_Product_Id).FirstOrDefault();

                    product.product_IsGood = false;
                    context.SaveChanges();
                }
               
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "FixProductQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nFixProductQuality()\n" + ex.Message;
                }
            }
        }
        #endregion

        #region ProductRecieves
        public static void FixProductReceives(ProductReceive productReceive,
        ref string errorMessage)
        {
            try
            {
                

                if (ProductReceiveExists(productReceive.ProductReceive_ContainerBarCode, ref errorMessage) == 0)
                {
                    CreateProductReceive(productReceive, ref errorMessage);
                }
                    else
                    {
                        errorMessage = "მონაცემი უკვე არსებობს";
                        return;
                    }
                }
            
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: FixProductReceives()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: FixProductReceives()\n" +
                                   ex.Message;
                }
            }
        }

        private static void CreateProductReceive(ProductReceive productReceive, ref string errorMessage)
        {
            long? harvesterId = Employees.SelectL
                .GetPersonPostByBarcode(productReceive.ProductReceive_HarvesterBarCode, ref errorMessage)
                .FirstOrDefault()
                ?.PersonPost_Id;
            long? rowId = SelectL
                .GetHarvesterRowDistribution(null, null, harvesterId, null, null, true, ref errorMessage)
                .FirstOrDefault()
                ?.HarvesterRowDistribution_Row_Id;
            if (harvesterId == null)
            {
                errorMessage = "მკრეფავი ვერ მოიძებნა";
                return;
            }

            if (rowId == null)
            {
                errorMessage = "რიგი ვერ მოიძებნა";
                return;
            }
            long? breedId = Structure.SelectL.GetRowBreeds(null, rowId, null, ref errorMessage).FirstOrDefault()?.RowBreed_Breed_Id;
            if (breedId == null)
            {
                errorMessage = "ჯიში ვერ მოიძებნა";
                return;
            }


            long? companyId = Employees.SelectL.GetCompanyRow(rowId.Value, ref errorMessage).FirstOrDefault()?.CompanyRow_Company_Id;
            if (companyId== null)
            {
                errorMessage = "კომპანია ვერ მოიძებნა";
                return;
            }
            decimal net = Fixator.GetDefaultNet(ref errorMessage);
            decimal weight = Fixator.GetDefaultContainerWeightCF(ref errorMessage);
            
            
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Product product = new Product()
                        {
                            Product_DateTime = productReceive.ProductReceive_DateTime,
                            Product_Harvester_PersonPost_Id = harvesterId.Value,
                            Product_Id = productReceive.ProductReceive_Product_Id,
                            Product_ParentProduct_Id = null,
                            Product_Row_Id = rowId.Value,
                            Product_Breed_Id = breedId.Value,
                            Product_User_PersonPost_Id = productReceive.ProductReceive_User_PersonPost_Id,
                            product_IsGood = true
                        };
                        //ProductQuality productQuality = new ProductQuality()
                        //{
                        //    ProductQuality_DateTime = productReceive.ProductReceive_DateTime,
                        //    ProductQuality_Id = Guid.NewGuid(),
                        //    ProductQuality_Product_Id = productReceive.ProductReceive_Product_Id,
                        //    ProductQuality_Quality_Id = productReceive.QualityId,
                        //    ProductQuality_User_PersonPost_Id = productReceive.ProductReceive_User_PersonPost_Id
                        //};
                        ProductOwner productOwner = new ProductOwner()
                        {
                            ProducOwnert_DateTime = productReceive.ProductReceive_DateTime,
                            ProductOwner_CompanyId = companyId.Value,
                            ProductOwner_Product_Id = productReceive.ProductReceive_Product_Id,
                            ProductOwner_User_PersonPost_Id=productReceive.ProductReceive_User_PersonPost_Id,
                            ProductOwner_Status = 1
                        };
                        ProductPack productPack = new ProductPack()
                        {
                            ProductPack_Container_BarCode = productReceive.ProductReceive_ContainerBarCode,
                            ProductPack_In_DateTime = productReceive.ProductReceive_DateTime,
                            ProductPack_In_ProductPackInOut_Id = productReceive.ProductReceive_Product_Id,
                            ProductPack_In_User_PersonPost_Id = productReceive.ProductReceive_User_PersonPost_Id,
                            ProductPack_Product_Id = productReceive.ProductReceive_Product_Id
                        };
                        ContainerWeight containerWeight = new ContainerWeight()
                        {
                            ContainerWeight_Container_BarCode = productReceive.ProductReceive_ContainerBarCode,
                            ContainerWeight_DateTime = productReceive.ProductReceive_DateTime,
                            ContainerWeight_Gross = net + weight,
                            ContainerWeight_Id = productReceive.ProductReceive_Product_Id,
                            ContainerWeight_Net = net,
                            ContainerWeight_User_PersonPost_Id = productReceive.ProductReceive_User_PersonPost_Id
                        };
                        ContainerLocation containerLocation = new ContainerLocation()
                        {
                            ContainerLocation_Container_BarCode = productReceive.ProductReceive_ContainerBarCode,
                             ContainerLocation_In_DateTime = productReceive.ProductReceive_DateTime,
                             ContainerLocation_In_Id = productReceive.ProductReceive_Product_Id,
                             ContainerLocation_In_User_PersonPost_Id = productReceive.ProductReceive_User_PersonPost_Id,
                             ContainerLocation_Point_Id = productReceive.ProductReceive_User_Point_Id
                        };

                        context.Products.Add(product);
                        context.ProductReceives.Add(productReceive);
                        context.ProductPacks.Add(productPack);
                        context.ProductOwners.Add(productOwner);
                        context.ContainerWeights.Add(containerWeight);
                        context.ContainerLocations.Add(containerLocation);
                       // context.ProductQualities.Add(productQuality);
                    //ignore
                        if (string.IsNullOrEmpty(errorMessage))
                        {
                            context.SaveChanges();
                            transaction.Commit();
                        }

                    }
                    catch (Exception ex)
                    {
                        errorMessage = "დაფიქსირდა შეცდომა : CreateProductReceive";
                        transaction.Rollback();
                    }
                }
            }

        }

        

       

        private static int ProductReceiveExists(string barcode, ref string errorMessage)
        {
            // return SelectL.GetProductReceives(barcode, ref errorMessage).Count();
            return SelectL.GetProductPacks(null, null, barcode, null, null, true, ref errorMessage).Count();
        }

        #endregion

        #region CreateTransportWaybill

        public static string CreateTransportWaybill(long carId, long startPointId, long destinationPointId, long personPostId, ref string errorMessage)
        {
            int productOwnerStatus = 1;
            string result = null;
            List<RS.XClasses.WaybillContainer> waybillContainers = null;
            TransportWaybill transportWaybill = GetCurrentTransportWaybill(carId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            if (transportWaybill == null)
            {
                transportWaybill = GetCurrentTransportWaybill(carId, startPointId, destinationPointId, ref errorMessage);                
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
            }
            try
            {
                if (transportWaybill.TransportWaybill_Destination_Point_Id == null &&
                    transportWaybill.TransportWaybill_Start_Point_Id == null)
                {
                    transportWaybill.TransportWaybill_Start_Point_Id = startPointId;
                    transportWaybill.TransportWaybill_Destination_Point_Id = destinationPointId;
                }
                waybillContainers = RS.XClasses.WaybillPackageCreator.CreateWaybillPackage(transportWaybill, personPostId, productOwnerStatus, false, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                RS.XClasses.WaybillPackageUploader.UploadWaybillPackage(transportWaybill.TransportWaybill_Id, false, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                result = "ზედნადები ატვირთულია";
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "CreateTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n CreateTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        private static TransportWaybill GetCurrentTransportWaybill(long carId, long startPointId, long destinationPointId, ref string errorMessage)
        {
            TransportWaybill result = null;
            try
            {
                result = RS.SelectL.GetTransportWaybills(null, null, null, carId, null, startPointId, true, destinationPointId, true, null, true, null, true,
                    ref errorMessage).First();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetCurrentTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetCurrentTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        private static TransportWaybill GetCurrentTransportWaybill(long carId, ref string errorMessage)
        {
            TransportWaybill result = null;
            try
            {
                result = RS.SelectL.GetTransportWaybills(null, null, null, carId, null, null, true, null, true, null, true, null, true,
                    ref errorMessage).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetCurrentTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetCurrentTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        #endregion CreateTransportWaybill

        #region CorrectWaybill

        public static void CorrectWaybill(long transportWaybillId, ref string errorMessage)
        {
            int productOwnerStatus = 1;
            TransportWaybill transportWaybill = GetTransportWaybill(transportWaybillId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return ;
            }
            List<RS.XClasses.WaybillContainer> waybillContainers = 
                RS.XClasses.WaybillCorrectPackageCreator.CreateWaybillPackage(transportWaybill, productOwnerStatus, true, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return ;
            }
            RS.XClasses.WaybillPackageUploader.UploadWaybillPackage(transportWaybillId, true, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return;
            }
        }

        private static TransportWaybill GetTransportWaybill(long transportWaybillId, ref string errorMessage)
        {
            TransportWaybill result = null;
            try
            {
                result = RS.SelectL.GetTransportWaybills(transportWaybillId, null, null, null, null, null, false, null, false, null, false, null, false,
                    ref errorMessage).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetTransportWaybills()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetTransportWaybills()\n" + ex.Message;
                }
            }
            return result;
        }

        #endregion CorrectWaybill

        #region CloseTransportWaybill

        public static string CloseTransportWaybill(long carId, long destinationPointId, ref string errorMessage)
        {
            string result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    TransportWaybill transportWaybill = context.TransportWaybills.Where(c => c.TransportWaybill_Car_Id == carId).FirstOrDefault();
                    if(transportWaybill != null)
                    {
                        transportWaybill.TransportWaybill_End_DateTime = DateTime.Now;
                    }
                }
               
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "CloseTransportWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nCloseTransportWaybill()\n" + ex.Message;
                }
            }
            return result;
        }

        #endregion CloseTransportWaybill

        #region ContainerPack
        public static void FixContainerPack(ContainerPack containerPack , bool insert, string paletbarCode, bool closePalet,long? userPointId,long? userPersonPostId, ref string errorMessage)
        {
            try
            {
                if (closePalet)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        using (DbContextTransaction transaction = context.Database.BeginTransaction())
                        {
                            try
                            {


                                Update.ClosePalet(context, paletbarCode, userPersonPostId.Value, ref errorMessage);
                                //ContainerLocation containerLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null && c.ContainerLocation_Container_BarCode == paletbarCode).FirstOrDefault();
                                //containerLocation.ContainerLocation_Out_ContainerMoveInOut_Id = Guid.NewGuid();
                                //containerLocation.ContainerLocation_Out_DateTime = DateTime.Now;
                                //containerLocation.ContainerLocation_Out_User_PersonPost_Id = userPersonPostId;




                                if (string.IsNullOrEmpty(errorMessage))
                                {
                                    context.SaveChanges();
                                    transaction.Commit();
                                }
                                else
                                {
                                    transaction.Rollback();
                                }
                            }
                            catch (Exception ex)
                            {
                                errorMessage = "დაფიქსირდა შეცდომა : FixContainerPack";
                                transaction.Rollback();
                            }


                        }
                    }

                }
                else
                {
                    if (insert)
                    {
                        Insert.InsertContainerPack(containerPack, userPointId.Value, ref errorMessage);
                    }
                    else
                    {
                        using (BerryManagementEntities context = new BerryManagementEntities())
                        {
                            using (DbContextTransaction transaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    Update.UpdateContainerPack(context, paletbarCode, userPersonPostId.Value, ref errorMessage);

                                    if (string.IsNullOrEmpty(errorMessage))
                                    {
                                        context.SaveChanges();
                                        transaction.Commit();
                                    }
                                    else
                                    {
                                        transaction.Rollback();
                                    }
                                }
                                catch (Exception ex)
                                {
                                    errorMessage = "დაფიქსირდა შეცდომა : FixContainerPack";
                                    transaction.Rollback();
                                }

                            }

                        }
                    }



                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "FixContainerPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nFixContainerPack()\n" + ex.Message;
                }
            }
        }


        #endregion

        #region ContainerSendBack

        public static string FixContainerSendBack(int containerCount, long carId, long startPointId, long destinationPointId, ref string errorMessage)
        {
            string result = null;
            long waybillId = 
                RS.XClasses.WaybillPackageCreator.CreateSendBackWaybillPackage(containerCount, carId, startPointId, destinationPointId, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            RS.XClasses.WaybillPackageUploader.UploadWaybillPackage(waybillId, false, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            Data.TransportWaybill transportWaybill = RS.SelectL.GetTransportWaybills(waybillId,
                           null, null, null, null, null, false, null, false, null, false, null, false, ref errorMessage).FirstOrDefault();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            transportWaybill.TransportWaybill_End_DateTime = DateTime.Now;
            RS.Update.UpdateTransportWaybill(transportWaybill, ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                return result;
            }
            result = "ზედნადები ატვირთულია";
            return result;
        }

        #endregion

        private static Product GetProductByContainerBarcode(string containerBarcode, ref string errorMessage)
        {
            Product result = null;
            try
            {
                result = Produce.SelectL.GetProducts(null, null, false, null, null, null, ref errorMessage).FirstOrDefault();
                // result = decimal.Parse(s);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetProductByContainerBarcode()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetProductByContainerBarcode()\n" + ex.Message;
                }
            }
            return result;
        }

        private static decimal GetDefaultContainerWeightCF(ref string errorMessage)
        {
            decimal result = 0;
            try
            {
                string s = SelectL.GetOperationSettings("ContainerWeightCF", ref errorMessage).FirstOrDefault().OperationSetting_Value;
                result = decimal.Parse(s);
            }
            catch (Exception ex)
            {
                if (String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetDefaultContainerWeightCF()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetDefaultContainerWeightCF()\n" + ex.Message;
                }
            }
            return result;
        }

        private static decimal GetDefaultNet(ref string errorMessage)
        {
            decimal result = 0;
            try
            {
                string s = SelectL.GetOperationSettings("ProductWeightCF", ref errorMessage).FirstOrDefault().OperationSetting_Value;
                result = decimal.Parse(s);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetDefaultNet()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetDefaultNet()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}