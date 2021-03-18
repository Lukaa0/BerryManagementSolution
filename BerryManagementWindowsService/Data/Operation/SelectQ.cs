using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation
{
    public static class SelectQ
    {
        public static IQueryable<Data.HarvesterRowDistribution> GetHarvesterRowDistributions(BerryManagementEntities context, long? id, 
            long? Row_Id, long? Harvester_PersonPost_Id, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            IQueryable<Data.HarvesterRowDistribution> result = null;
            try
            {
                result = context.HarvesterRowDistributions;
                if (id != null)
                {
                    result = result.Where(tr => tr.HarvesterRowDistribution_Id == id);
                }                
                if (Row_Id != null)
                {
                    result = result.Where(tr => tr.HarvesterRowDistribution_Row_Id == Row_Id);
                }
                if (Harvester_PersonPost_Id != null)
                {
                    result = result.Where(tr => tr.HarvesterRowDistribution_Harvester_PersonPost_Id == Harvester_PersonPost_Id);
                }
                if (inId != null)
                {
                    result = result.Where(tr =>
                        tr.HarvesterRowDistribution_In_HarvesterRowDistributionInOut_Id == inId);
                }
                if (outIdFiltered)
                {
                    result = result.Where(tr =>
                        tr.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == outId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetHarvesterRowDistributions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetHarvesterRowDistributions()\n" + ex.Message;
                }
            }

            return result;
        }

        public static IQueryable<Data.HarvesterRowDistribution> CheckHarvesterInRowPersonPost(BerryManagementEntities context, long personpostID, ref string errorMessage)
        {
            IQueryable<Data.HarvesterRowDistribution> result = null;

            try
            {
                result = SelectQ.GetHarvesterRowDistributions(context, null, null, personpostID, null, null, false, ref errorMessage).Where(c => (c.HarvesterRowDistribution_Out_User_PersonPost_Id != null));

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckHarvesterInRowPersonPost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckHarvesterInRowPersonPost()\n" + ex.Message;
                }
            }
            return result;

        }

        public static IQueryable<Data.TakeRow> CheckTakeRows(BerryManagementEntities context, long brgID, ref string errorMessage)
        {
            IQueryable<Data.TakeRow> result = null;

            try
            {
                result = SelectQ.GetTakeRows(context, null, null, brgID, null, null, false, ref errorMessage).Where(c => (c.TakeRow_Out_User_PersonPost_Id != null));

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckTakeRows()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckTakeRows()\n" + ex.Message;
                }
            }
            return result;

        }

        public static IQueryable<OperationSetting> GetOperationSettings(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<OperationSetting> result = null;
            try
            {
                result = context.OperationSettings.Where(x=>x.OperationSetting_Key=="LastVersion_Android");

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }

            return result;
        }

        internal static IQueryable<Data.Point> GetPointById(BerryManagementEntities context, long? id,string barcode, ref string errorMessage)
        {
            IQueryable<Data.Point> result = null;
            try
            {
                result = context.Points;
                if(id!=null)
                    result = result.Where(x => x.Point_Id == id);
                if(!string.IsNullOrEmpty(barcode))
                    result = result.Where(x => x.Point_BarCode == barcode);


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }

            return result;
        }

        public static IQueryable<Data.HarvesterContainerDistribution> GetHarvesterContainerDistributions(BerryManagementEntities context, long? id,
            string containerBarcode, long? Harvester_PersonPost_Id, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            IQueryable<Data.HarvesterContainerDistribution> result = null;
            try
            {
                result = context.HarvesterContainerDistributions;
                if (id != null)
                {
                    result = result.Where(tr => tr.HarvesterContainerDistribution_Id == id);
                }
                if (!string.IsNullOrEmpty(containerBarcode))
                {
                    result = result.Where(tr => tr.HarvesterContainerDistribution_Container_BarCode == containerBarcode);
                }
                if (Harvester_PersonPost_Id != null)
                {
                    result = result.Where(tr =>
                        tr.HarvesterContainerDistribution_Harvester_PersonPost_Id == Harvester_PersonPost_Id);
                }
                if (inId != null)
                {
                    result = result.Where(tr =>
                        tr.HarvesterContainerDistribution_In_HarvesterContainerDistributionInOut_Id == inId);
                }
                if (outIdFiltered)
                {
                    result = result.Where(tr =>
                        tr.HarvesterContainerDistribution_Out_HarvesterContainerDistributionInOut_Id == outId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }

            return result;
        }

        public static IQueryable<Data.Operation.XClasses.Pallete.ContainerModel> GetContainerModelByPalette(BerryManagementEntities context,
        string containerBarcode, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.Pallete.ContainerModel> result = null;
            try
            {
                result = from pack in context.ContainerPacks
                            join weight in context.ContainerWeights on pack.ContainerPack_Container_BarCode equals weight.ContainerWeight_Container_BarCode
                            join productPack in context.ProductPacks on pack.ContainerPack_Container_BarCode equals productPack.ProductPack_Container_BarCode
                            join product in context.Products on productPack.ProductPack_Product_Id equals product.Product_Id
                            join rowBreed in context.RowBreeds on product.Product_Row_Id equals rowBreed.RowBreed_Row_Id
                            join breed in context.Breeds on rowBreed.RowBreed_Breed_Id equals breed.Breed_Id
                            where pack.ContainerPack_Parent_Container_BarCode.Equals(containerBarcode)
                            select new Data.Operation.XClasses.Pallete.ContainerModel()
                            {
                                BreedName = breed.Breed_Name,
                                ContainerPack_Container_BarCode = pack.ContainerPack_Container_BarCode,
                                ContainerPack_DateTime = pack.ContainerPack_DateTime,
                                ContainerPack_GrossWeight = weight.ContainerWeight_Gross,
                                ContainerPack_Id = pack.ContainerPack_Id,
                                ContainerPack_IsComplite = pack.ContainerPack_IsComplite,
                                ContainerPack_NetWeight = weight.ContainerWeight_Net,
                                ContainerPack_Parent_ContainerLocation_In_Id = pack.ContainerPack_Parent_ContainerLocation_In_Id,
                                ContainerPack_Parent_Container_BarCode = pack.ContainerPack_Parent_Container_BarCode,
                                ContainerPack_User_PersonPost_Id = pack.ContainerPack_User_PersonPost_Id,
                            };

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerModelByPalette()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerModelByPalette()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.ContainerPack> GetContainerPackByPalette(BerryManagementEntities context,
            string containerBarcode, ref string errorMessage)
        {
            IQueryable<Data.ContainerPack> result = null;
            try
            {
                result = context.ContainerPacks.Where(c => c.ContainerPack_Parent_Container_BarCode == containerBarcode);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerPackByPalette()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerPackByPalette()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Sale> GetContainerPackByCarId(BerryManagementEntities context, long carId, ref string errorMessage)
        {
            IQueryable<Data.Sale> result = null;
            try
            {
                result = context.Sales.Where(c => /*c.Sale_Point_Id == carId &&*/ c.Sale_IsComplite == false);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerPackByCarId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerPackByCarId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<HarvesterRowDistribution> GetHarvRowDistribByPersonPostId(BerryManagementEntities context,long personPostId, ref string errorMessage)
        {
            IQueryable<HarvesterRowDistribution> result=null;
            try
            {
                 result = context.HarvesterRowDistributions.Where(x =>
                    x.HarvesterRowDistribution_Harvester_PersonPost_Id == personPostId);
            }
            catch (Exception ex)
            {
                errorMessage = "ვერ მოიძებნა მონაცემი GetHarvRowDistribByPersonPostId";
            }

            return result;
        }

        public static IQueryable<Data.ContainerMove> GetContainerMove(BerryManagementEntities context, long? id, long? transportWaybillId, 
            string containerBarCode,Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
            {
                IQueryable<Data.ContainerMove> result = null;
            try
            {
                result = context.ContainerMoves;

                if (id != null)
                {
                    result = result.Where(tr => tr.ContainerMove_Id == id);
                }
                if (inId != null)
                {
                    result = result.Where(tr => tr.ContainerMove_In_ContainerMoveInOut_Id == inId);
                }
                if (transportWaybillId != null)
                {
                    result = result.Where(tr => tr.ContainerMove_TransportWaybill_Id == transportWaybillId);
                }
                if (!string.IsNullOrEmpty(containerBarCode))
                {
                    result = result.Where(tr => tr.ContainerMove_Container_BarCode == containerBarCode);
                }
                if (outIdFiltered)
                {
                    result = result.Where(tr => tr.ContainerMove_Out_ContainerMoveInOut_Id == outId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }
                return result;
            }

        public static IQueryable<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModel(BerryManagementEntities context,
            long? brigadeId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                result = from takeRows in context.TakeRows
                         join rows in context.Rows on takeRows.TakeRow_Row_Id equals rows.Row_Id
                         join brigade in context.Brigades on takeRows.TakeRow_Brigade_Id equals brigade.Brigade_Id
                         where takeRows.TakeRow_Brigade_Id == brigadeId && takeRows.TakeRow_Out_TakeRowInOut_Id == outId
                         select new Data.Operation.XClasses.TakeRowModel
                         {
                             TakeRow_Brigade_Id = takeRows.TakeRow_Brigade_Id,
                             Brigade_Name = brigade.Brigade_Name,
                             Row_Barcode = rows.Row_Barkode,
                             TakeRow_Id = takeRows.TakeRow_Id,
                             TakeRow_In_DateTime = takeRows.TakeRow_In_DateTime,
                             TakeRow_In_TakeRowInOut_Id = takeRows.TakeRow_In_TakeRowInOut_Id,
                             TakeRow_In_TUser_PersonPost_Id = takeRows.TakeRow_In_TUser_PersonPost_Id,
                             TakeRow_Out_DateTime = takeRows.TakeRow_Out_DateTime,
                             TakeRow_Out_TakeRowInOut_Id = takeRows.TakeRow_Out_TakeRowInOut_Id,
                             TakeRow_Out_User_PersonPost_Id = takeRows.TakeRow_Out_User_PersonPost_Id,
                             TakeRow_Row_Id = takeRows.TakeRow_Row_Id
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRowsModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRowsModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Operation.XClasses.TakeRowModel> GetClosedTakeRowsModel(BerryManagementEntities context,
            DateTime? closedTime, DateTime? closedTimeTwo, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                result = from takeRows in context.TakeRows
                         join rows in context.Rows on takeRows.TakeRow_Row_Id equals rows.Row_Id
                         join brigade in context.Brigades on takeRows.TakeRow_Brigade_Id equals brigade.Brigade_Id
                         where takeRows.TakeRow_Out_DateTime != null
                         && (closedTime == null || takeRows.TakeRow_Out_DateTime >= closedTime && takeRows.TakeRow_Out_DateTime <= closedTimeTwo)
                         select new Data.Operation.XClasses.TakeRowModel
                         {
                             TakeRow_Brigade_Id = takeRows.TakeRow_Brigade_Id,
                             Brigade_Name = brigade.Brigade_Name,
                             Row_Barcode = rows.Row_Barkode,
                             TakeRow_Id = takeRows.TakeRow_Id,
                             TakeRow_In_DateTime = takeRows.TakeRow_In_DateTime,
                             TakeRow_In_TakeRowInOut_Id = takeRows.TakeRow_In_TakeRowInOut_Id,
                             TakeRow_In_TUser_PersonPost_Id = takeRows.TakeRow_In_TUser_PersonPost_Id,
                             TakeRow_Out_DateTime = takeRows.TakeRow_Out_DateTime,
                             TakeRow_Out_TakeRowInOut_Id = takeRows.TakeRow_Out_TakeRowInOut_Id,
                             TakeRow_Out_User_PersonPost_Id = takeRows.TakeRow_Out_User_PersonPost_Id,
                             TakeRow_Row_Id = takeRows.TakeRow_Row_Id
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetClosedTakeRowsModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetClosedTakeRowsModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.TakeRow> GetTakeRows(BerryManagementEntities context, long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            IQueryable<Data.TakeRow> result = null;
            try
            {
                result = context.TakeRows;
                if (id != null)
                {
                    result = result.Where(tr => tr.TakeRow_Id == id);
                }
                if (rowId != null)
                {
                    result = result.Where(tr => tr.TakeRow_Row_Id == rowId);
                }
                if (brigadeId != null)
                {
                    result = result.Where(tr => tr.TakeRow_Brigade_Id == brigadeId);
                }
                if (inId != null)
                {
                    result = result.Where(tr => tr.TakeRow_In_TakeRowInOut_Id == inId);
                }
                if (outIdFiltered)
                {
                    result = result.Where(tr => tr.TakeRow_Out_TakeRowInOut_Id == outId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.TakeRow> GetTakeRowForBrigade(BerryManagementEntities context, long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage){
            IQueryable<Data.TakeRow> result = null;
            try
            {
                result = SelectQ.GetTakeRows(context, id, rowId, brigadeId, inId, outId, true, ref errorMessage).Where(c => brigadeId == null);
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.OperationSetting> GetOperationSettings(BerryManagementEntities context, string key, ref string errorMessage)
        {
            IQueryable<Data.OperationSetting> result = null;

            try
            {
                result = context.OperationSettings.Where(os => key == null || os.OperationSetting_Key == key);
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckHarvesterInRowPersonPost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckHarvesterInRowPersonPost()\n" + ex.Message;
                }
            }
            return result;

        }

        #region AndroidApp

        public static IQueryable<XClasses.ContainerMoveInOut> GetContainerMoveInOut(BerryManagementEntities context, bool direction, long  carPointID,ref string errorMessage)
        {
            IQueryable<XClasses.ContainerMoveInOut> result = null;
            try
            {
                if (direction)
                {
                    result = from containerMove in context.ContainerMoves.Where(c => c.ContainerMove_Out_ContainerMoveInOut_Id == null && c.ContainerMove_Car_Point_Id== carPointID)
                             join Carpoint in context.Points on containerMove.ContainerMove_Car_Point_Id equals Carpoint.Point_Id
                             join car in context.Cars on Carpoint.Point_Car_Id equals car.Car_Id
                             join UserPersonPost in context.PersonPosts on containerMove.ContainerMove_In_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join user in context.Persons on UserPersonPost.PersonPost_Person_Id equals user.Person_Id
                             join UserPoint in context.Points on containerMove.ContainerMove_In_User_Point_Id equals UserPoint.Point_Id
                             select new XClasses.ContainerMoveInOut
                             {
                                 Id = containerMove.ContainerMove_Id,
                                 ContainerMoveInOut_Id = containerMove.ContainerMove_In_ContainerMoveInOut_Id,
                                 ContainerBarCode = containerMove.ContainerMove_Container_BarCode,
                                 Point_Car_Id = car.Car_Id,
                                 PointBarcode = Carpoint.Point_BarCode,
                                 ContainerMoveInOut_Car_Number = car.Car_Number,
                                 ContainerMoveInOut_Car_Model = car.Car_Model,
                                 PersonPostId = containerMove.ContainerMove_In_User_PersonPost_Id,
                                 Point_Id = containerMove.ContainerMove_In_User_Point_Id,
                                 ContainerMoveInOut_User_Point_Name = UserPoint.Point_Name,
                                 ContainerMoveInOut_User_Point_BarCode = UserPoint.Point_BarCode,
                                 ContainerMoveInOut_User_FullName = user.Person_FirstName + " " + user.Person_LastName,
                                 Time = containerMove.ContainerMove_In_DateTime,
                                 ContainerMoveInOut_TransportWaybill_Id = containerMove.ContainerMove_TransportWaybill_Id,
                                 Error = null,
                                 IsComplete = true,
                                 Direction = direction,



                             };

}
                else
                {
                    result = from containerMove in context.ContainerMoves.Where(c => c.ContainerMove_Out_ContainerMoveInOut_Id != null && c.ContainerMove_Car_Point_Id == carPointID)
                             join Carpoint in context.Points on containerMove.ContainerMove_Car_Point_Id equals Carpoint.Point_Id
                             join car in context.Cars on Carpoint.Point_Car_Id equals car.Car_Id
                             join UserPersonPost in context.PersonPosts on containerMove.ContainerMove_Out_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join user in context.Persons on UserPersonPost.PersonPost_Person_Id equals user.Person_Id
                             join UserPoint in context.Points on containerMove.ContainerMove_Out_User_Point_Id equals UserPoint.Point_Id
                             select new XClasses.ContainerMoveInOut
                             {
                                 Id = containerMove.ContainerMove_Id,
                                 ContainerMoveInOut_Id = containerMove.ContainerMove_Out_ContainerMoveInOut_Id.Value,
                                 ContainerBarCode = containerMove.ContainerMove_Container_BarCode,
                                 Point_Car_Id = car.Car_Id,
                                 PointBarcode = Carpoint.Point_BarCode,
                                 ContainerMoveInOut_Car_Number = car.Car_Number,
                                 ContainerMoveInOut_Car_Model = car.Car_Model,
                                 PersonPostId = containerMove.ContainerMove_Out_User_PersonPost_Id.Value,
                                 Point_Id = containerMove.ContainerMove_Out_User_Point_Id,
                                 ContainerMoveInOut_User_Point_Name = UserPoint.Point_Name,
                                 ContainerMoveInOut_User_Point_BarCode = UserPoint.Point_BarCode,
                                 ContainerMoveInOut_User_FullName = user.Person_FirstName + " " + user.Person_LastName,
                                 Time = containerMove.ContainerMove_In_DateTime,
                                 ContainerMoveInOut_TransportWaybill_Id = containerMove.ContainerMove_TransportWaybill_Id,
                                 Error = null,
                                 IsComplete = true,
                                 Direction = direction,



                             };

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerMoveInOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerMoveInOut()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.SaleContainer> GetSaleContainer(BerryManagementEntities context, long buyerId, bool isComplite, ref string errorMessage)
        {
            IQueryable<XClasses.SaleContainer> result = null;
            try
            {
                result = from sale in context.Sales.Where(c => c.Sale_IsComplite == isComplite && c.Sale_Company_Id == buyerId)
                         join company in context.Companyes on sale.Sale_Company_Id equals company.Company_Id
                         join UserPersonPost in context.PersonPosts on sale.Sale_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                         join user in context.Persons on UserPersonPost.PersonPost_Person_Id equals user.Person_Id
                         join container in context.Containers on sale.Sale_Container_BarCode equals container.Container_BarCode
                         select new XClasses.SaleContainer
                         {
                             Id = sale.Sale_Id,
                             ContainerBarCode = sale.Sale_Container_BarCode,
                             Time = sale.Sale_DateTime,
                             IsComplete = sale.Sale_IsComplite,
                             CompanyName = company.Company_Name,
                             Company_Id = company.Company_Id,
                             Identifier = sale.Sale_Identifier,
                             SaleUserFullName = user.Person_FirstName + " " + user.Person_LastName,
                             Error = null,
                             PersonPostId = sale.Sale_User_PersonPost_Id
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPreSaleContainer()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPreSaleContainer()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.ContainerPackModel> GetContainerPackModel(BerryManagementEntities context, bool direction, string parentContainerBarCode, ref string errorMessage)
        {
            IQueryable<XClasses.ContainerPackModel> result = null;
            try
            {
                if (direction)
                {
                    result = from containerPack in context.ContainerPacks.Where(c => c.ContainerPack_IsComplite == false && c.ContainerPack_Parent_Container_BarCode == parentContainerBarCode)
                             join UserPersonPost in context.PersonPosts on containerPack.ContainerPack_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join user in context.Persons on UserPersonPost.PersonPost_Person_Id equals user.Person_Id
                             join container in context.Containers on containerPack.ContainerPack_Container_BarCode equals container.Container_BarCode
                             select new XClasses.ContainerPackModel
                             {
                                 Id = containerPack.ContainerPack_Id,
                                 ContainerBarCode = containerPack.ContainerPack_Container_BarCode,
                                 Parent_ContainerBarCode = containerPack.ContainerPack_Parent_Container_BarCode,
                                 PersonPostId = containerPack.ContainerPack_User_PersonPost_Id,

                                 Pack_User_FullName = user.Person_FirstName + " " + user.Person_LastName,
                                 Time = containerPack.ContainerPack_DateTime,
                                 Error = null,
                                 IsComplete = true,
                                 Direction = direction,
                                 UnpackIsComplete=containerPack.ContainerPack_IsComplite
                             };

                }
                else
                {
                    result = from containerPack in context.ContainerPacks.Where(c => c.ContainerPack_IsComplite == false && c.ContainerPack_Parent_Container_BarCode == parentContainerBarCode)
                             join UserPersonPost in context.PersonPosts on containerPack.ContainerPack_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join user in context.Persons on UserPersonPost.PersonPost_Person_Id equals user.Person_Id
                             join container in context.Containers on containerPack.ContainerPack_Container_BarCode equals container.Container_BarCode
                             select new XClasses.ContainerPackModel
                             {
                                 Id = containerPack.ContainerPack_Id,
                                 ContainerBarCode = containerPack.ContainerPack_Container_BarCode,
                                 Parent_ContainerBarCode = containerPack.ContainerPack_Parent_Container_BarCode,
                                // PersonPostId = containerPack.ContainerPack_UnpackUser_PersonPost_Id.Value,

                                 Pack_User_FullName = user.Person_FirstName + " " + user.Person_LastName,
                                // Time = containerPack.ContainerPack_UnpackDateTime.Value,
                                 Error = null,
                                 IsComplete = true,
                                 Direction = direction,
                                // UnpackIsComplete = containerPack.ContainerPack_UnpackIsComplite
                             };


                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerPackModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerPackModel()\n" + ex.Message;
                }
            }
            return result;
        }
        #endregion

        public static IQueryable<Data.TakeRow> GetTakeRowsByBrigadeId(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.TakeRow> result = null;
            try
            {
                result = context.TakeRows.Where(tr=>tr.TakeRow_Brigade_Id==null && tr.TakeRow_Out_DateTime == null);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<ProductPack> GetContainerForQuality(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<ProductPack> result = null;
            try
            {
                result = context.ProductPacks.Where(x =>x.ProductPack_Out_DateTime == null);

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerForQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerForQuality()\n" + ex.Message;
                }
            }
            return result;

        }

        public static IQueryable<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModelByBrigadeId(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.TakeRowModel> result = null;
            long? asd = null;
            try
            {
                result = from takeRows in SelectQ.GetTakeRowsByBrigadeId(context,ref errorMessage)
                         join rows in context.Rows on takeRows.TakeRow_Row_Id equals rows.Row_Id
                         select new Data.Operation.XClasses.TakeRowModel
                         {
                             TakeRow_Brigade_Id = takeRows.TakeRow_Brigade_Id,
                             Row_Barcode = rows.Row_Barkode,
                             TakeRow_Id = takeRows.TakeRow_Id,
                             TakeRow_In_DateTime = takeRows.TakeRow_In_DateTime,
                             TakeRow_In_TakeRowInOut_Id = takeRows.TakeRow_In_TakeRowInOut_Id,
                             TakeRow_In_TUser_PersonPost_Id = takeRows.TakeRow_In_TUser_PersonPost_Id,
                             TakeRow_Out_DateTime = takeRows.TakeRow_Out_DateTime,
                             TakeRow_Out_TakeRowInOut_Id = takeRows.TakeRow_Out_TakeRowInOut_Id,
                             TakeRow_Out_User_PersonPost_Id = takeRows.TakeRow_Out_User_PersonPost_Id,
                             TakeRow_Row_Id = takeRows.TakeRow_Row_Id
                         };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Product> GetContainerQuality(BerryManagementEntities context,Guid Id, ref string errorMessage)
        {
            IQueryable<Product> result = null;
            try
            {
                result = context.Products.Where(c => c.Product_Id == Id);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerQuality()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Operation.XClasses.TakeRowModel> GetRowsWithBrigade(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                result = from takeRows in context.TakeRows
                         join rows in context.Rows on takeRows.TakeRow_Row_Id equals rows.Row_Id
                         join brigade in context.Brigades on takeRows.TakeRow_Brigade_Id equals brigade.Brigade_Id
                         where takeRows.TakeRow_Brigade_Id != null && takeRows.TakeRow_Out_TakeRowInOut_Id == null
                         select new Data.Operation.XClasses.TakeRowModel
                         {
                             TakeRow_Brigade_Id = takeRows.TakeRow_Brigade_Id,
                             Brigade_Name = brigade.Brigade_Name,
                             Row_Barcode = rows.Row_Barkode,
                             TakeRow_Id = takeRows.TakeRow_Id,
                             TakeRow_In_DateTime = takeRows.TakeRow_In_DateTime,
                             TakeRow_In_TakeRowInOut_Id = takeRows.TakeRow_In_TakeRowInOut_Id,
                             TakeRow_In_TUser_PersonPost_Id = takeRows.TakeRow_In_TUser_PersonPost_Id,
                             TakeRow_Out_DateTime = takeRows.TakeRow_Out_DateTime,
                             TakeRow_Out_TakeRowInOut_Id = takeRows.TakeRow_Out_TakeRowInOut_Id,
                             TakeRow_Out_User_PersonPost_Id = takeRows.TakeRow_Out_User_PersonPost_Id,
                             TakeRow_Row_Id = takeRows.TakeRow_Row_Id
                         };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts (BerryManagementEntities context, bool direction, ref string errorMessage)
        {
            IQueryable<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                if (direction)
                {
                    result = from harvesterRowDistributions in context.HarvesterRowDistributions.Where(c => c.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null)
                             join row in context.Rows on harvesterRowDistributions.HarvesterRowDistribution_Row_Id equals row.Row_Id
                             join HarvesterPersonPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id equals HarvesterPersonPost.PersonPost_Id
                             join Harvester in context.Persons on HarvesterPersonPost.PersonPost_Person_Id equals Harvester.Person_Id
                             join UserPersonPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_In_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join User in context.Persons on UserPersonPost.PersonPost_Person_Id equals User.Person_Id
                             select new XClasses.HarvesterRowDistributionInOut
                             {

                                 RowId = harvesterRowDistributions.HarvesterRowDistribution_Row_Id,
                                 RowBarCode = row.Row_Barkode,
                                 HarvesterPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id,
                                 HarvesterBarCode = HarvesterPersonPost.PersonPost_EmployeeBarCode,
                                 HarvesterName = Harvester.Person_FirstName + " " + Harvester.Person_LastName,
                                 UserPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_In_User_PersonPost_Id,
                                 UserName = User.Person_FirstName + " " + User.Person_LastName,
                                 Time = harvesterRowDistributions.HarvesterRowDistribution_In_DateTime,
                                 IsComplete = true,
                                 Direction = direction,



                             };
                }
                else
                {
                    result = from harvesterRowDistributions in context.HarvesterRowDistributions.Where(c => c.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id != null)
                             join row in context.Rows on harvesterRowDistributions.HarvesterRowDistribution_Row_Id equals row.Row_Id
                             join HarvesterPersonPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id equals HarvesterPersonPost.PersonPost_Id
                             join Harvester in context.Persons on HarvesterPersonPost.PersonPost_Person_Id equals Harvester.Person_Id
                             join UserPersonPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_Out_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                             join User in context.Persons on UserPersonPost.PersonPost_Person_Id equals User.Person_Id
                             select new XClasses.HarvesterRowDistributionInOut
                             {

                                 RowId = harvesterRowDistributions.HarvesterRowDistribution_Row_Id,
                                 RowBarCode = row.Row_Barkode,
                                 HarvesterPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id,
                                 HarvesterBarCode = HarvesterPersonPost.PersonPost_EmployeeBarCode,
                                 HarvesterName = Harvester.Person_FirstName + " " + Harvester.Person_LastName,
                                 UserPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Out_User_PersonPost_Id.Value,
                                 UserName = User.Person_FirstName + " " + User.Person_LastName,
                                 Time = harvesterRowDistributions.HarvesterRowDistribution_Out_DateTime.Value,
                                 IsComplete = true,
                                 Direction = direction,



                             };
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.TakeRowInOut> GetTakeRowsInByPersonPostID(BerryManagementEntities context, long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            IQueryable<XClasses.TakeRowInOut> result = null;
            try
            {
                result = from takeRow in SelectQ.GetTakeRows(context, id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage).Where(tr => tr.TakeRow_In_TUser_PersonPost_Id == userPersonPostId)
                         join rows in context.Rows on takeRow.TakeRow_Row_Id equals rows.Row_Id
                         select new XClasses.TakeRowInOut
                         {
                             BrigadeId = takeRow.TakeRow_Brigade_Id,
                             Time = takeRow.TakeRow_In_DateTime,
                             Direction = true,
                             IsComplete = true,
                             RowId = takeRow.TakeRow_Row_Id,
                             RowBarCode = rows.Row_Barkode,
                             PersonPostId = takeRow.TakeRow_In_TUser_PersonPost_Id
                         };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsByPersonPostID()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsByPersonPostID()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.TakeRowInOut> GetTakeRowsOutByPersonPostID(BerryManagementEntities context, long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            IQueryable<XClasses.TakeRowInOut> result = null;
            try
            {
                result = from takeRow in SelectQ.GetTakeRows(context, id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage).Where(tr => tr.TakeRow_Out_User_PersonPost_Id == userPersonPostId && tr.TakeRow_Out_TakeRowInOut_Id != null)
                         join rows in context.Rows on takeRow.TakeRow_Row_Id equals rows.Row_Id
                         select new XClasses.TakeRowInOut
                         {
                             BrigadeId = takeRow.TakeRow_Brigade_Id,
                             Time = takeRow.TakeRow_Out_DateTime.Value,
                             Direction = false,
                             IsComplete = true,
                             RowId = takeRow.TakeRow_Row_Id,
                             RowBarCode = rows.Row_Barkode,
                             PersonPostId = takeRow.TakeRow_Out_User_PersonPost_Id.Value
                             
                         };

                             
                              
       
                        
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsOutByPersonPostID()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsOutByPersonPostID()\n" + ex.Message;
                }
            }
            return result;
        }
       
        public static IQueryable<Data.ProductPack> GetProductPacks(BerryManagementEntities context, long? id, Guid? productId,
            string containerBarcode, Guid? inId, Guid? outId, bool outIdIsFiltered, ref string errorMessage)
        {
            IQueryable<Data.ProductPack> result = null;
            try
            {
                result = context.ProductPacks;
                if (id != null)
                {
                    result = result.Where(pp => pp.ProductPack_Id == id);
                }
                if (productId != null)
                {
                    result = result.Where(pp => pp.ProductPack_Product_Id == productId);
                }
                if (containerBarcode != null)
                {
                    result = result.Where(pp => pp.ProductPack_Container_BarCode == containerBarcode);
                }
                if (inId != null)
                {
                    result = result.Where(pp => pp.ProductPack_In_ProductPackInOut_Id == inId);
                }
                if (outIdIsFiltered)
                {
                    result = result.Where(pp => pp.ProductPack_Out_ProductPackInOut_Id == outId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetProductPacks()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetProductPacks()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.ProductQuality> GetProductQualities(BerryManagementEntities context, Guid? id, Guid? productId, ref string errorMessage)
        {
            IQueryable<Data.ProductQuality> result = null;
            try
            {
                result = context.ProductQualities;
                if (id != null)
                {
                    result = result.Where(pq => pq.ProductQuality_Id == id);
                }
                if (productId != null)
                {
                    result = result.Where(pq => pq.ProductQuality_Product_Id == productId);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetProductPacks()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetProductPacks()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.ProductOwner> GetProductOwners(BerryManagementEntities context, long? id, Guid? productId,
            long? companyId, int? status,  ref string errorMessage)
        {
            IQueryable<Data.ProductOwner> result = null;
            try
            {
                result = context.ProductOwners;
                if (id != null)
                {
                    result = result.Where(po => po.ProductOwner_Id == id);
                }
                if (productId != null)
                {
                    result = result.Where(po => po.ProductOwner_Product_Id == productId);
                }
                if (companyId != null)
                {
                    result = result.Where(po => po.ProductOwner_CompanyId == companyId);
                }
                if (status != null)
                {
                    result = result.Where(po => po.ProductOwner_Status == status);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetProductOwners()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetProductOwners()\n" + ex.Message;
                }
            }
            return result;
        }

        //public static IQueryable<Data.HarvesterContainerDistribution> GetHarvesterContainerDistributions(BerryManagementEntities context,
        //    long? HarvesterContainerDistribution_Harvester_Person_Id)
        //{
        //    IQueryable<Data.HarvesterContainerDistribution> result = null;
        //    result = context.HarvesterContainerDistributions;
        //    if (HarvesterContainerDistribution_Harvester_Person_Id != null &&
        //        HarvesterContainerDistribution_Harvester_Person_Id > 0)
        //    {
        //        result = result.Where(r => r.HarvesterContainerDistribution_Harvester_Person_Id == HarvesterContainerDistribution_Harvester_Person_Id);
        //    }
        //    return result;
        //}

        public static IQueryable<Data.ContainerWeight> GetContainerWeights(BerryManagementEntities context)
        {
            IQueryable<Data.ContainerWeight> result = context.ContainerWeights;

            return result;
        }

        public static IQueryable<Data.Operation.XClasses.Pallete.BoxCountModel> GetContainerCountInPallete(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.Pallete.BoxCountModel> result = null;
            try
            {
                var query = from pack in context.ContainerPacks
                            group pack by pack.ContainerPack_Parent_Container_BarCode into g
                            select new Data.Operation.XClasses.Pallete.BoxCountModel
                            {
                                Palete_BarCode = g.Key,
                                Container_Count = g.Select(o => o.ContainerPack_Container_BarCode).Count(),
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerCountInPallete()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerCountInPallete()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Operation.XClasses.Pallete.PalleteModel> GetContainerWeightsByChars(BerryManagementEntities context,string barcodeType,DateTime? start,DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.Pallete.PalleteModel> result = null;
            try
            {
                var query = context.ContainerWeights.Where(c => c.ContainerWeight_Container_BarCode.Substring(0, 2).Equals(barcodeType));
                result = from res in query
                         join count in GetContainerCountInPallete(context, ref errorMessage) on res.ContainerWeight_Container_BarCode equals count.Palete_BarCode into gj
                         from x in gj.DefaultIfEmpty()
                            where ((start == null && end == null) || (res.ContainerWeight_DateTime >= start && res.ContainerWeight_DateTime <= end))
                            select new BerryManagementWindowsService.Data.Operation.XClasses.Pallete.PalleteModel()
                            {
                                ContainerWeight_Container_BarCode = res.ContainerWeight_Container_BarCode,
                                ContainerWeight_End_DateTime = end,
                                ContainerWeight_Gross = res.ContainerWeight_Gross,
                                ContainerWeight_Id = res.ContainerWeight_Id,
                                ContainerWeight_Net = res.ContainerWeight_Net,
                                ContainerWeight_Start_DateTime = start,
                                ContainerWeight_User_PersonPost_Id = res.ContainerWeight_User_PersonPost_Id,
                                Container_Count = (x == null ? 0 : x.Container_Count),
                                ContainerWeight_DateTime = res.ContainerWeight_DateTime,
                            };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerWeightsByChars()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerWeightsByChars()\n" + ex.Message;
                }
            }

            return result;
        }

        public static IQueryable<Data.TakeRow> GetTakeRowsInAll(BerryManagementEntities context)
        {
            IQueryable<Data.TakeRow> result = context.TakeRows.Where(x=>x.TakeRow_Out_TakeRowInOut_Id==null);

            return result;
        }

        public static IQueryable<Data.TakeRow> GetTakeRowsOutAll(BerryManagementEntities context)
        {
            IQueryable<Data.TakeRow> result = context.TakeRows.Where(x => x.TakeRow_Out_TakeRowInOut_Id != null);

            return result;
        }

        public static IQueryable<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionIn(BerryManagementEntities context,long userPersonPostId, ref string errorMessage)
        {
            IQueryable<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                result = from harvesterRowDistributions in context.HarvesterRowDistributions.Where(c=> c.HarvesterRowDistribution_In_User_PersonPost_Id==userPersonPostId && c.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id==null)
                         join rows in context.Rows on harvesterRowDistributions.HarvesterRowDistribution_Row_Id equals rows.Row_Id
                         join personPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id equals personPost.PersonPost_Id
                         join person in context.Persons on personPost.PersonPost_Person_Id equals person.Person_Id
                         select new XClasses.HarvesterRowDistributionInOut
                         {
                             Direction = true,
                             RowId = harvesterRowDistributions.HarvesterRowDistribution_Row_Id,
                             RowBarCode = rows.Row_Barkode,
                             HarvesterPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id,
                             HarvesterBarCode = personPost.PersonPost_EmployeeBarCode,
                             HarvesterName = person.Person_FirstName + "" + person.Person_LastName,
                             Time = harvesterRowDistributions.HarvesterRowDistribution_In_DateTime,
                             UserPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_In_User_PersonPost_Id,
                             IsComplete = true
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterRowDistributionIn()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterRowDistributionIn()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionOut(BerryManagementEntities context, long userPersonPostId, ref string errorMessage)
        {
            IQueryable<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                result = from harvesterRowDistributions in context.HarvesterRowDistributions.Where(c=>c.HarvesterRowDistribution_Out_User_PersonPost_Id == userPersonPostId && c.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id!=null)
                         join rows in context.Rows on harvesterRowDistributions.HarvesterRowDistribution_Row_Id equals rows.Row_Id
                         join personPost in context.PersonPosts on harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id equals personPost.PersonPost_Id
                         join person in context.Persons on personPost.PersonPost_Person_Id equals person.Person_Id
                         select new XClasses.HarvesterRowDistributionInOut
                         {
                             Direction = false,
                             RowId = harvesterRowDistributions.HarvesterRowDistribution_Row_Id,
                             RowBarCode = rows.Row_Barkode,
                             HarvesterPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Harvester_PersonPost_Id,
                             HarvesterBarCode = personPost.PersonPost_EmployeeBarCode,
                             HarvesterName = person.Person_FirstName + "" + person.Person_LastName,
                             Time = harvesterRowDistributions.HarvesterRowDistribution_Out_DateTime.Value,
                             UserPersonPostId = harvesterRowDistributions.HarvesterRowDistribution_Out_User_PersonPost_Id.Value,
                             IsComplete = true
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterRowDistributionOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterRowDistributionOut()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<ProductReceive> GetProductReceives(string  containerBarCode, BerryManagementEntities context)
        {
            return context.ProductReceives.Where(x => x.ProductReceive_ContainerBarCode == containerBarCode);
            
        }

        public static IQueryable<Data.ProductReceive> GetAllProducts(BerryManagementEntities context)
        {
            IQueryable<Data.ProductReceive> result = context.ProductReceives;

            return result;
        }

        public static IQueryable<ContainerLocation> CheckContainerLocationForPackaging (string containerBarCode, BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<ContainerLocation> result = null;
            try
            {
                long packingPointId = int.Parse(Operation.SelectQ.GetOperationSettings(context, "PackingPointId", ref errorMessage).First().OperationSetting_Value);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    return result;
                }
                result = context.ContainerLocations.Where(x => x.ContainerLocation_Container_BarCode == containerBarCode && 
                x.ContainerLocation_Point_Id == packingPointId && x.ContainerLocation_Out_DateTime == null);

            }
            catch(Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckContainerLocationForPackaging()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckContainerLocationForPackaging()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Operation.XClasses.ContainerWeightModel> GetWeightsForReport(BerryManagementEntities context, long PersonPostId,DateTime Time, DateTime Timeplusone, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.ContainerWeightModel> result = null;
            try
            {

                result = from container in context.ContainerWeights
                         join product in context.Products on container.ContainerWeight_Id equals product.Product_Id
                         where product.Product_Harvester_PersonPost_Id == PersonPostId
                         && (product.Product_DateTime >= Time && product.Product_DateTime <= Timeplusone)

                         select new Data.Operation.XClasses.ContainerWeightModel
                         {
                             ContainerWeight_Container_BarCode = container.ContainerWeight_Container_BarCode,
                             ContainerWeight_DateTime = container.ContainerWeight_DateTime,
                             ContainerWeight_Id = product.Product_Id,
                             ContainerWeight_User_PersonPost_Id = container.ContainerWeight_User_PersonPost_Id,
                             ContainerWeight_Gross = container.ContainerWeight_Gross,
                             ContainerWeight_Net = container.ContainerWeight_Net
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetWeightsForReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetWeightsForReport()\n" + ex.Message;
                }
            }
            return result;
        }

        //public static IQueryable<Data.ContainerMoveInOut> GetContainerMoveInOuts(BerryManagementEntities context)
        //{
        //    IQueryable<Data.ContainerMoveInOut> result = context.ContainerMoveInOuts;

        //    return result;
        //}

        public static IQueryable<Data.tf_ProductQualityes_Result> GetTf_ProductQualityes(BerryManagementEntities context)
        {
            IQueryable<Data.tf_ProductQualityes_Result> result = context.tf_ProductQualityes();

            return result;
        }

        //public static IQueryable<Data.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts(BerryManagementEntities context)
        //{
        //    IQueryable<Data.HarvesterRowDistributionInOut> result = context.HarvesterRowDistributionInOuts;

        //    return result;
        //}

        //public static IQueryable<Classes.HarvesterRowViewModel> GetJoinedHarvesters(BerryManagementEntities context,
        //    ref string errorMessage)
        //{
        //    IQueryable<Classes.HarvesterRowViewModel> result = null;
        //    try
        //    {
        //        result = from cx in context.HarvesterRowDistributionInOuts
        //            join pp in context.PersonPosts on cx.HarvesterRowDistributionInOut_Harvester_PersonPost_Id equals pp
        //                .PersonPost_Id
        //            join p in context.Persons on pp.PersonPost_Person_Id equals p.Person_Id
        //            select new Classes.HarvesterRowViewModel
        //            {
        //                Id = Guid.NewGuid().ToString(),
        //                Date = cx.HarvesterRowDistributionInOut_DateTime,
        //                FirstName = p.Person_FirstName,
        //                LastName = p.Person_LastName,
        //                HarvesterBarCode = cx.HarvesterRowDistributionInOut_HarvesterBarCode,
        //                RowBarCode = cx.HarvesterRowDistributionInOut_HarvesterBarCode,
        //                PersonId = pp.PersonPost_Id
        //            };



        //    }
        //    catch (Exception ex)
        //    {

        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetPersonDocuments()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetPersonDocuments()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}
        //public static IQueryable<Classes.HarvesterRowViewModel> GetPersonPostByRowBarcode(BerryManagementEntities context,
        //    ref string errorMessage)
        //{
        //    IQueryable<Classes.HarvesterRowViewModel> result = null;
        //    try
        //    {
        //        result = from cx in context.HarvesterRowDistributionInOuts
        //                 join pp in context.PersonPosts on cx.HarvesterRowDistributionInOut_Harvester_PersonPost_Id equals pp
        //                     .PersonPost_Id
        //                 join p in context.Persons on pp.PersonPost_Person_Id equals p.Person_Id
        //                 select new Classes.HarvesterRowViewModel
        //                 {
        //                     Id = Guid.NewGuid().ToString(),
        //                     Date = cx.HarvesterRowDistributionInOut_DateTime,
        //                     FirstName = p.Person_FirstName,
        //                     LastName = p.Person_LastName,
        //                     HarvesterBarCode = cx.HarvesterRowDistributionInOut_HarvesterBarCode,
        //                     RowBarCode = cx.HarvesterRowDistributionInOut_HarvesterBarCode,
        //                     PersonId = pp.PersonPost_Id
        //                 };



        //    }
        //    catch (Exception ex)
        //    {

        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetPersonDocuments()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetPersonDocuments()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        public static IQueryable<Data.Operation.XClasses.PalleteWeight> GetPalleteWeight(BerryManagementEntities context, string pal_barcode, ref string errorMessage)
        {
            IQueryable<Data.Operation.XClasses.PalleteWeight> result = null;
            try
            {
                var query = from pack in context.ContainerPacks
                            join weight in context.ContainerWeights on pack.ContainerPack_Container_BarCode equals weight.ContainerWeight_Container_BarCode
                            where (pack.ContainerPack_Parent_Container_BarCode == pal_barcode)
                            group weight by pack.ContainerPack_Parent_Container_BarCode into g
                            select new Data.Operation.XClasses.PalleteWeight
                            {
                                Pallete_BarCode = g.Key,
                                Pallete_Gross_weight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                Pallete_Net_weight = g.Select(o => o.ContainerWeight_Net).Sum(),
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(BerryManagementEntities context, List<string> containers,
             ref string errorMessage)
        {
            IQueryable<Data.RS.XClasses.RS_ProductModel> result = null;
            try
            {
                result = (from pp in context.ProductPacks.Where(pp => pp.ProductPack_Out_ProductPackInOut_Id == null &&
                     containers.Contains(pp.ProductPack_Container_BarCode))
                          join p in context.Products
                             on pp.ProductPack_Product_Id equals p.Product_Id
                          join b in context.Breeds
                              on p.Product_Breed_Id equals b.Breed_Id
                          join o in context.ProductOwners
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
                          Select(gr => new Data.RS.XClasses.RS_ProductModel()
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

        public static IQueryable<XClasses.TakeRows_Harvesters> GetTakeRows_Harvesters(BerryManagementEntities context,
            long? brigadeId, ref string errorMessage)
        {
            IQueryable<XClasses.TakeRows_Harvesters> result = null;
            try
            {
                var rows = from b in context.Brigades.Where(d => brigadeId == null || d.Brigade_Id == brigadeId)
                           join tr in context.TakeRows.Where(t => t.TakeRow_Out_TakeRowInOut_Id == null)
                               on b.Brigade_Id equals tr.TakeRow_Brigade_Id
                           join r in context.Rows
                               on tr.TakeRow_Row_Id equals r.Row_Id
                           select new
                           {
                               b.Brigade_Id,
                               b.Brigade_Name,
                               r.Row_Barkode,
                               r.Row_Id
                           };
                var harvesters = from hrd in context.HarvesterRowDistributions.Where(h =>
                    h.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null)
                                 join pp in context.PersonPosts
                                     on hrd.HarvesterRowDistribution_Harvester_PersonPost_Id equals pp.PersonPost_Id
                                 join p in context.Persons
                                     on pp.PersonPost_Person_Id equals p.Person_Id
                                 select new
                                 {
                                     hrd.HarvesterRowDistribution_Row_Id,
                                     pp.PersonPost_EmployeeBarCode,
                                     p.Person_FirstName,
                                     p.Person_LastName
                                 };
                result = from r in rows
                         join h in harvesters
                            on r.Row_Id equals h.HarvesterRowDistribution_Row_Id into lj
                            from res in lj.DefaultIfEmpty()
                         select new XClasses.TakeRows_Harvesters()
                         {
                             BrigadeId = r.Brigade_Id,
                             BrigadeName = r.Brigade_Name,
                             HarvesterBarCode = res.PersonPost_EmployeeBarCode,
                             HarvesterName = res.Person_FirstName + " " + res.Person_LastName,
                             RowBarCode = r.Row_Barkode
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRows_Harvesters()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRows_Harvesters()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.ContainerLocationModel> GetContainersLocationss(BerryManagementEntities context,
            long? PointId, ref string errorMessage)
        {
            IQueryable<XClasses.ContainerLocationModel> result = null;
            try
            {
                result = from p in context.Points.Where(p => PointId == null || p.Point_Id == PointId)
                           join cl in context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null)
                               on p.Point_Id equals cl.ContainerLocation_Point_Id
                           select new XClasses.ContainerLocationModel()
                           {
                               ContainerBarCode = cl.ContainerLocation_Container_BarCode,
                               ContainerLocationId = cl.ContainerLocation_Id,
                               PointId = p.Point_Id,
                               PointName = p.Point_Name,
                               PointStartDaeTime = cl.ContainerLocation_In_DateTime
                           };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainersLocationss()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainersLocationss()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
