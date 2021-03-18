using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure
{
    public static class SelectQ
    {


        public static IQueryable<Data.Row> GetRows(BerryManagementEntities context, long? rowId, 
            string rowBarcode, ref string errorMessage)
        {
            IQueryable<Data.Row> result = null;
            try
            {
                result = context.Rows;
                if (rowId != null)
                {
                    result = result.Where(r => r.Row_Id == rowId);
                }
                if (rowBarcode != null)
                {
                    result = result.Where(r => r.Row_Barkode == rowBarcode);
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPosts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.RowWithDateModel> GetRowsWithDate(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<XClasses.RowWithDateModel> result = null;
            try
            {
                result = from row in context.Rows
                         join rowBreed in context.RowBreeds on row.Row_Id equals rowBreed.RowBreed_Row_Id
                         select new XClasses.RowWithDateModel
                         {
                             Row_Id = row.Row_Id,
                             Row_Barkode = row.Row_Barkode,
                             Row_Number = row.Row_Number,
                             Row_Subrow_Number = row.Row_Subrow_Number,
                             Sector_Number = row.Sector_Number,
                             RowBreed_EndDate = rowBreed.RowBreed_EndDate,
                             RowBreed_StartDate = rowBreed.RowBreed_StartDate
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRowsWithDate()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRowsWithDate()\n" + ex.Message;
                }
            }
            return result;
        }


            public static IQueryable<XClasses.RowModel> GetRowsByHarvesterRowInDistribution(BerryManagementEntities context, long? brigadeId, ref string errorMessage)
        {
            IQueryable<XClasses.RowModel> result = null;
            try
            {
                result = from row in context.Rows
                         join birgadeRow in Data.Operation.SelectQ.GetTakeRows(context, null, null,brigadeId, null, null, true, ref errorMessage).Where(c=>c.TakeRow_Brigade_Id !=null) on row.Row_Id equals birgadeRow.TakeRow_Row_Id
                         select new XClasses.RowModel
                         {
                             Row_Id = row.Row_Id,
                             Row_Barkode =row.Row_Barkode,
                             Row_Number=row.Row_Number,
                             Row_Subrow_Number=row.Row_Subrow_Number,
                             Sector_Number=row.Sector_Number,
                             direction=true
                             
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: getRowsByHarvesterRowInDistribution()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: getRowsByHarvesterRowInDistribution()\n" + ex.Message;
                }
            }
            return result;

        }

        #region AndroidApp

       

        //კონტაინერის წამოღება გადაზიდვისთვის
        public static IQueryable<Data.Container> GetContainersForContainerMove(BerryManagementEntities context,bool direction,long? pointId, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                //var containerMove = context.ContainerMoves.Where(c => c.ContainerMove_Out_ContainerMoveInOut_Id == null && c.ContainerMove_Car_Point_Id==pointId).Select(y => y.ContainerMove_Container_BarCode);
                var ContainerLocations = context.ContainerLocations.Where(c => c.ContainerLocation_Point_Id == pointId && c.ContainerLocation_Out_ContainerMoveInOut_Id == null).Select(y => y.ContainerLocation_Container_BarCode);
                var list = ContainerLocations.ToList();
                var ContainerPack = context.ContainerPacks.Where(c => c.ContainerPack_IsComplite == true).Select(y => y.ContainerPack_Parent_Container_BarCode);
                var testPack = ContainerPack.ToList();
                var btestPack = context.ContainerPacks.ToList();
                if (direction)
                {
                    result = context.Containers.Where(c => ContainerLocations.Contains(c.Container_BarCode) && ContainerPack.Contains(c.Container_BarCode) && c.Container_ContainerType_Id == "CB");
                }
                else
                {
                    var saleList = context.Sales.Select(c => c.Sale_Container_BarCode);
                    var bsaleTest = context.Sales.ToList();
                    var saleTest = saleList.ToList();
                    result = context.Containers.Where(c => ContainerLocations.Contains(c.Container_BarCode)  && (c.Container_ContainerType_Id == "CS" || c.Container_ContainerType_Id == "CL"));
                    var testResult = result.ToList();
                    var btestResult = context.Containers.ToList();

                }

               
               
                   
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersForContainerMove()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainersForContainerMove()\n" + ex.Message;
                }
            }
            return result;
        }

        //კონტაინერის წამოღება გადაზიდვისთვის
        public static IQueryable<Data.Container> GetContainersForContainerLocations(BerryManagementEntities context, long? pointId, bool direction, string prefix, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                if (direction)
                {
                    //var containerMove = context.ContainerMoves.Where(c => c.ContainerMove_Out_ContainerMoveInOut_Id == null && c.ContainerMove_Car_Point_Id == pointId).Select(y => y.ContainerMove_Container_BarCode);
                    var ContainerLocations = context.ContainerLocations.Where(c => c.ContainerLocation_Point_Id == pointId && c.ContainerLocation_Out_ContainerMoveInOut_Id == null).Select(y => y.ContainerLocation_Container_BarCode);
                    result = context.Containers.Where(c => ContainerLocations.Contains(c.Container_BarCode) && c.Container_ContainerType_Id == prefix);
                }
                else
                {
                    var containerMove = context.ContainerMoves.Where(c => c.ContainerMove_Out_ContainerMoveInOut_Id == null && c.ContainerMove_Car_Point_Id == pointId).Select(y => y.ContainerMove_Container_BarCode);
                    result = context.Containers.Where(c => containerMove.Contains(c.Container_BarCode) && c.Container_ContainerType_Id == prefix);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersForContainerLocations()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainersForContainerLocations()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Container> GetContainersForSale(BerryManagementEntities context, long? pointId, bool direction, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                var ContainerLocations = context.ContainerLocations.Where(c => c.ContainerLocation_Point_Id == pointId && c.ContainerLocation_Out_ContainerMoveInOut_Id == null).Select(y => y.ContainerLocation_Container_BarCode);
                if (direction)
                {
                   
                    result = context.Containers.Where(c =>ContainerLocations.Contains(c.Container_BarCode) && c.Container_ContainerType_Id=="CS");
                }
                else
                {
                    result = context.Containers.Where(c => ContainerLocations.Contains(c.Container_BarCode) && c.Container_ContainerType_Id == "CB");
                }
                
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersForSale()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainersForSale()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.ProductPack> GetContainersForContainerPack(BerryManagementEntities context,ref string errorMessage)
        {
            IQueryable<Data.ProductPack> result = null;
            try
            {
               
                var containerPack = context.ContainerPacks.Select(y => y.ContainerPack_Container_BarCode);
                var containerLocation = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null && c.ContainerLocation_Container_BarCode.Contains("CS-")).Select(y => y.ContainerLocation_Container_BarCode);
                result = context.ProductPacks.Where(c => containerLocation.Contains(c.ProductPack_Container_BarCode) && !containerPack.Contains(c.ProductPack_Container_BarCode));


                var container1 = context.Containers.Where(c => c.Container_ContainerType_Id == "CS").Select(y => y.Container_BarCode).ToList();
                var containerPack1 = context.ContainerPacks.Select(y => y.ContainerPack_Container_BarCode).ToList();

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersForContainerPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainersForContainerPack()\n" + ex.Message;
                }
            }
            return result;
        }
        //კონტეინერი პროდუქტების მიღების სპინერისთის
        public static IQueryable<Data.Container> GetContainerForProductRecieve(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                var ContainerMove = context.ProductPacks.Where(x => x.ProductPack_Out_ProductPackInOut_Id == null).Select(x => x.ProductPack_Container_BarCode);
                result = context.Containers.Where(c => c.Container_ContainerType_Id == "CT" && !ContainerMove.Contains(c.Container_BarCode));
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerForProductRecive()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerForProductRecive()\n" + ex.Message;
                }
            }
            return result;
        }
       
        public static IQueryable<XClasses.PointsModel> GetCarsPointModel(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PointsModel> result = null;
            try
            {

                    var entryPoint = (from points in context.Points.Where(c => c.Point_IsActive == true && c.Point_PointType_Id == "LC")
                                      join car in context.Cars on points.Point_Car_Id equals car.Car_Id
                                      join pointType in context.tf_PointTypes() on points.Point_PointType_Id equals pointType.PointType_Id
                                      select new Data.Structure.XClasses.PointsModel
                                      {
                                          Point_Id = points.Point_Id,
                                          Point_PointType_Id = points.Point_PointType_Id,
                                          Point_Car_Id = car.Car_Id,
                                          Point_Address = points.Point_Address,
                                          Point_BarCode = points.Point_BarCode,
                                          Point_Car_Model = car.Car_Model,
                                          Point_Car_Number = car.Car_Number,
                                          Point_Description = points.Point_Description,
                                          Point_IsActive = points.Point_IsActive,
                                          Point_Name = points.Point_Name,
                                          Point_PointType_IsActive = pointType.PointType_IsActive,
                                          Point_PointType_Name = pointType.PointType_Name,
                                          Point_Error = null,
                                          Point_IsComplete = true
                                      });


                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPoint()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.SalePointsModel> GetCarsPointModelForSale(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.SalePointsModel> result = null;
            try
            {
                var entryPoint = (from points in context.Points.Where(c => c.Point_IsActive == true && c.Point_PointType_Id == "LA")
                                  join car in context.Cars on points.Point_Car_Id equals car.Car_Id
                                  join pointType in context.tf_PointTypes() on points.Point_PointType_Id equals pointType.PointType_Id
                                  select new Data.Structure.XClasses.SalePointsModel
                                  {
                                      Point_Id = points.Point_Id,
                                      Point_PointType_Id = points.Point_PointType_Id,
                                      Point_Car_Id = points.Point_Car_Id,
                                      Point_Address = points.Point_Address,
                                      Point_BarCode = points.Point_BarCode,
                                      Point_Car_Model = car.Car_Model,
                                      Point_Car_Number = car.Car_Number,
                                      Point_Description = points.Point_Description,
                                      Point_IsActive = points.Point_IsActive,
                                      Point_Name = points.Point_Name,
                                      Point_PointType_IsActive = pointType.PointType_IsActive,
                                      Point_PointType_Name = pointType.PointType_Name,
                                      Point_Error = null,
                                      Point_IsComplete = true
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPoint()\n" + ex.Message;
                }
            }
            return result;
        }

        //პალეტების წამოღება
        public static IQueryable<string>  GetPaletForContainerPack(BerryManagementEntities context, bool direction, ref string errorMessage)
        {
            IQueryable<string> result = null;
            try
            {
                var containerPack = context.ContainerPacks.Where(c => c.ContainerPack_IsComplite == true).Select(y => y.ContainerPack_Parent_Container_BarCode);
                var containerLocation = context.ContainerLocations.Select(y => y.ContainerLocation_Container_BarCode);
                if (direction)
                {

                    result = context.Containers.Where(c => c.Container_ContainerType_Id == "CB" && !containerPack.Contains(c.Container_BarCode)
                    /*&& !containerLocation.Contains(c.Container_BarCode)*/
                    ).Select(y=>y.Container_BarCode);

                }
                else
                {
                    var location = context.ContainerLocations.Where(c => c.ContainerLocation_Out_ContainerMoveInOut_Id == null).Select(y => y.ContainerLocation_Container_BarCode);
                    result = context.Containers.Where(c => c.Container_ContainerType_Id == "CB" && containerPack.Contains(c.Container_BarCode) && location.Contains(c.Container_BarCode)).Select(y => y.Container_BarCode);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPaletForContainerPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPaletForContainerPack()\n" + ex.Message;
                }
            }
            return result;
        }
   
        public static IQueryable<XClasses.PointsModel> GetCarsPointModelForContainerMove(BerryManagementEntities context, bool direction,ref string errorMessage)
        {
            IQueryable<XClasses.PointsModel> result = null;
            IQueryable<long> car;
            IQueryable<long> point;
            try
            {
                if (direction)
                {
                    var transportWayBill = context.TransportWaybills.Where(c => c.TransportWaybill_End_DateTime == null && c.TransportWaybill_RS_Id != null );
                     car = transportWayBill.Select(y => y.TransportWaybill_Car_Id).Distinct();
                     point = transportWayBill.Select(y => y.TransportWaybill_Car_Point_Id).Distinct();
                    var carl = transportWayBill.Select(y => y.TransportWaybill_Car_Id).ToList();
                    var pointl = transportWayBill.Select(y => y.TransportWaybill_Car_Point_Id).ToList();
                    var list = SelectQ.GetCarsPointModel(context, ref errorMessage).ToList();
                    result = SelectQ.GetCarsPointModel(context, ref errorMessage).Where(c => !car.Contains(c.Point_Car_Id.Value) && !point.Contains(c.Point_Id));
                }
                else
                {
                    var transportWayBill = context.TransportWaybills.Where(c => c.TransportWaybill_End_DateTime == null && c.TransportWaybill_RS_Id != null);
                    car = transportWayBill.Select(y => y.TransportWaybill_Car_Id);
                    point = transportWayBill.Select(y => y.TransportWaybill_Car_Point_Id);
                    result = SelectQ.GetCarsPointModel(context, ref errorMessage).Where(c => car.Contains(c.Point_Car_Id.Value) && point.Contains(c.Point_Id));
                }
                
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCarsPointModelForContainerMove()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCarsPointModelForContainerMove()\n" + ex.Message;
                }
            }
            return result;
        }
            #endregion
            public static IQueryable<Data.Row> GetBrigadeRowDistribution(BerryManagementEntities context, long? brigadeID,ref string errorMessage)
        {
            IQueryable<Data.Row> result = null;

            try
            {
                //List<Data.TakeRow> rows = Data.Operation.SelectQ.GetTakeRows(context, null, null, null, null, null, false, ref errorMessage).ToList();

                result = from row in context.Rows
                         join birgadeRow in Data.Operation.SelectQ.GetTakeRows(context,null,null,brigadeID,null,null,false, ref errorMessage) on row.Row_Id equals birgadeRow.TakeRow_Row_Id
                         select row;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: getBrigadeRowDistribution()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: getBrigadeRowDistribution()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.Row> GetHarvesterInDistributionModel(BerryManagementEntities context, long PersonPostID, ref string errorMessage)
        {
            IQueryable<Data.Row> result = null;

            try
            {
                

                result = from row in context.Rows
                         join harvesterRowDistributionInOuts in Data.Operation.SelectQ.GetHarvesterRowDistributions(context, null,null, PersonPostID, null,null,true,ref errorMessage) on row.Row_Id equals harvesterRowDistributionInOuts.HarvesterRowDistribution_Row_Id
                         select row;
                        
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterInDistributionModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterInDistributionModel()\n" + ex.Message;
                }
            }
            return result;

        }
        public static IQueryable<Data.Row> GetHarvesterInAllRows(BerryManagementEntities context, long? rowId,
            string rowBarcode, ref string errorMessage)
        {
            IQueryable<Data.Row> result = null;
            try
            {
                result = from rows in context.Rows
                         join harvesterRowDistribution in context.HarvesterRowDistributions.Where(c => c.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null) on rows.Row_Id equals harvesterRowDistribution.HarvesterRowDistribution_Row_Id
                         select rows;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetHarvesterInAllRows()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetHarvesterInAllRows()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.RowModel> GetTakeRowInOutRow(BerryManagementEntities context, bool direction, long? brigadeId,ref string errorMessage)
        {
            IQueryable<XClasses.RowModel> result = null;
            try
            {

                var TakeRow = context.TakeRows.Where(x => x.TakeRow_Out_TakeRowInOut_Id == null).Select(x => x.TakeRow_Row_Id);
                if (direction)
                {
                    
                    result = context.Rows.Where(c => !TakeRow.Contains(c.Row_Id)).Select(y=> new XClasses.RowModel
                    {
                        Row_Id=y.Row_Id,
                        Row_Barkode=y.Row_Barkode,
                        Row_Number=y.Row_Number,
                        Row_Subrow_Number=y.Row_Subrow_Number,
                        Sector_Number=y.Sector_Number,
                        direction=direction
                    });
                }
                else
                {
                    var TakeRowOut = context.TakeRows.Where(x => x.TakeRow_Out_TakeRowInOut_Id == null && (brigadeId==null || x.TakeRow_Brigade_Id==brigadeId)).Select(x => x.TakeRow_Row_Id);
                    result = context.Rows.Where(c => TakeRowOut.Contains(c.Row_Id)).Select(y => new XClasses.RowModel
                    {
                        Row_Id = y.Row_Id,
                        Row_Barkode = y.Row_Barkode,
                        Row_Number = y.Row_Number,
                        Row_Subrow_Number = y.Row_Subrow_Number,
                        Sector_Number = y.Sector_Number,
                        direction = direction
                    }); ;
                }
                

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRowInOutRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowInOutRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long GetHarvesterPostId(BerryManagementEntities context, long rowId,
    ref string errorMessage)
        {
            long result = 0;
            try
            {
                //result = context.HarvesterRowDistributions.Where(c => c.HarvesterRowDistribution_Row_Id == rowId)
                //    .Select(x => new { x.HarvesterRowDistribution_Harvester_PersonPost_Id}).First());\


                result = (from s in context.HarvesterRowDistributions
                         where s.HarvesterRowDistribution_Row_Id == rowId
                         select s.HarvesterRowDistribution_Harvester_PersonPost_Id).First();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetHarvesterPostId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.PersonPost> GetPersonPost(BerryManagementEntities context, long? personPostId,
            string harvesterBarCode, ref string errorMessage)
        {
            IQueryable<Data.PersonPost> result = null;
            try
            {
                result = context.PersonPosts;
                if (personPostId != null)
                {
                    result = result.Where(r => r.PersonPost_Id == personPostId);
                }
                if (harvesterBarCode != null)
                {
                    result = result.Where(r => r.PersonPost_EmployeeBarCode == harvesterBarCode);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPosts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Structure.XClasses.PostModel> GetPostModel(BerryManagementEntities context, long? PostId, string PostName, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PostModel> result = null;
            try
            {
                var entryPoint = (from post in context.Posts
                                  join balance in context.tf_GetBalanceSheetTypes() on post.Post_BalanceSheetType_Id equals balance.BalanceSheetType_Id
                                  where (PostId == null || post.Post_Id == PostId)
                                  select new Data.Structure.XClasses.PostModel
                                  {
                                      Post_Id = post.Post_Id,
                                      Post_BalanceSheetType_Id = post.Post_BalanceSheetType_Id,
                                      BalanceSheetType_Name = balance.BalanceSheetType_Name,
                                      Post_BarCodePrefix = post.Post_BarCodePrefix,
                                      Post_Description = post.Post_Description,
                                      Post_Name = post.Post_Name
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPostModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPostModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Post> GetPosts(BerryManagementEntities context, long? PostId, string PostName, ref string errorMessage)
        {
            IQueryable<Data.Post> result = null;
            try
            {
                result = context.Posts.Where(n => (PostId == null || n.Post_Id == PostId.Value)
                    && (PostName == null || n.Post_Name == PostName));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPosts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Brigade> GetBrigades(BerryManagementEntities context, long? BrigadeId, string BrigadeName, ref string errorMessage)
        {
            IQueryable<Data.Brigade> result = null;
            try
            {
                result = context.Brigades.Where(n => (BrigadeId == null || n.Brigade_Id == BrigadeId.Value)
                    && (BrigadeName == null || n.Brigade_Name == BrigadeName));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetBrigades()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetBrigades()\n" + ex.Message;
                }
            }
            return result;
        }
      
        public static IQueryable<XClasses.CarDriversModel> GetCarDrivers(
            BerryManagementEntities context, long? CarDriversId, ref string errorMessage)
        {
            IQueryable<XClasses.CarDriversModel> result = null;
            try
            {
                var entryPoint = (from carDriver in context.CarDrivers
                                  join car in context.Cars on carDriver.CarDriver_Car_Id equals car.Car_Id
                                  join person in context.Persons on carDriver.CarDriver_Person_Id equals person.Person_Id
                                  where (CarDriversId == null || carDriver.CarDriver_Id == CarDriversId)
                                  select new XClasses.CarDriversModel
                                  {
                                      CarDriver_Id = carDriver.CarDriver_Id,
                                      CarDriver_Car_Id = carDriver.CarDriver_Car_Id,
                                      CarDriver_Car_Number = car.Car_Number,
                                      CarDriver_Car_Model = car.Car_Model,
                                      CarDriver_Person_Identity = person.Person_Identity,
                                      CarDriver_StartDate = carDriver.CarDriver_StartDate,
                                      CarDriver_EndDate = carDriver.CarDriver_EndDate,
                                      CarDriver_PersonPost_Id = carDriver.CarDriver_PersonPost_Id,
                                      CarDriver_Person_Id = person.Person_Id,
                                      CarDriver_Person_Name = person.Person_FirstName + " "+person.Person_LastName,
                                      CarDriver_IsResident = person.Person_IsResident
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetCarDriver()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetCarDriver()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Structure.XClasses.CarModel> GetCar(BerryManagementEntities context, long? CarId, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.CarModel> result = null;
            try
            {
                var entryPoint = (from car in context.Cars
                                  join sts in context.tf_SideTypes() on car.Car_SideType_Id equals sts.SideType_Id
                                  where (CarId == null || car.Car_Id == CarId)
                                  select new Data.Structure.XClasses.CarModel
                                  {
                                     Car_Id = car.Car_Id,
                                     Car_Model = car.Car_Model,
                                     Car_Number = car.Car_Number,
                                     Car_SideType_Id = car.Car_SideType_Id,
                                     Car_SideType_Name = sts.SideType_Name

                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetCar()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Structure.XClasses.CompanyCarModel> GetCompanyCar(BerryManagementEntities context, long? CompanyCarId, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.CompanyCarModel> result = null;
            try
            {
                var entryPoint = (from companyCar in context.CompanyCars
                                  join car in context.Cars on companyCar.CompanyCar_Car_Id equals car.Car_Id
                                  join company in context.Companyes on companyCar.CompanyCar_Company_Id equals company.Company_Id
                                  where (CompanyCarId == null || companyCar.CompanyCar_Id == CompanyCarId)
                                  select new Data.Structure.XClasses.CompanyCarModel
                                  {
                                      CompanyCar_Id = companyCar.CompanyCar_Id,
                                      CompanyCar_Car_Id = companyCar.CompanyCar_Car_Id,
                                      CompanyCar_Car_Model = car.Car_Model,
                                      CompanyCar_Car_Number = car.Car_Number,
                                      CompanyCar_Company_Id = company.Company_Id,
                                      CompanyCar_Company_Name = company.Company_Name,
                                      CompanyCar_EndDate = companyCar.CompanyCar_EndDate,
                                      CompanyCar_StartDate = companyCar.CompanyCar_StartDate
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetCompanyCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetCompanyCar()\n" + ex.Message;
                }
            }
            return result;
        }




        public static IQueryable<XClasses.CompanyeModel> GetCompany(BerryManagementEntities context, long? CompanyId, long? sideTypeId, ref string errorMessage)
        {
            IQueryable<XClasses.CompanyeModel> result = null;
            try
            {
                var entryPoint = (from company in context.Companyes
                                  join sts in context.tf_SideTypes() on company.Company_SideType_Id equals sts.SideType_Id
                                  join czsh in context.Citizenships on company.Company_CitizenshipId equals czsh.Citizenship_Id
                                  where ((CompanyId == null || company.Company_Id == CompanyId) && (sideTypeId == null || company.Company_SideType_Id == sideTypeId))
                                  select new XClasses.CompanyeModel
                                  {
                                      Company_IBAN = company.Company_IBAN,
                                      Company_Id = company.Company_Id,
                                      Company_CitizenshipId = company.Company_CitizenshipId,
                                      Company_Citizenship_Name = czsh.Citizenship_Name,
                                      Company_Citizenship_NameEn = czsh.Citizenship_NameEn,
                                      Company_Address1 = company.Company_Address1,
                                      Company_Address2 = company.Company_Address2,
                                      Company_Identity = company.Company_Identity,
                                      Company_Name = company.Company_Name,
                                      Company_Phone1 = company.Company_Phone1,
                                      Company_Phone2 = company.Company_Phone2,
                                      Company_SideType_Id = company.Company_SideType_Id,
                                      Company_SideType_Name = sts.SideType_Name,
                                      Company_RS_Password = company.Company_RS_Password,
                                      Company_RS_UserId = company.Company_RS_UserId
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetCompany()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetCompany()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Row> CheckGetRow (BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Row> result = null;
            try
            {
                var DateQuery = context.CompanyRows.Where(b => b.CompanyRow_EndDate <= DateTime.Now || b.CompanyRow_EndDate == null);

                var RowQuery = context.Rows.Where(c => !context.CompanyRows.Select(b => b.CompanyRow_Row_Id).Contains(c.Row_Id));

                var select = from dt in DateQuery
                            join rq in RowQuery on dt.CompanyRow_Row_Id equals rq.Row_Id
                            select new Data.Row
                            {
                                Row_Id = rq.Row_Id,
                                Row_Barkode = rq.Row_Barkode,
                                Row_Number = rq.Row_Number,
                                Row_Subrow_Number = rq.Row_Subrow_Number,
                                Sector_Number = rq.Sector_Number
                            };

                var select2 = select.ToList();



            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: CheckGetRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: CheckGetRow()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.Structure.XClasses.CompanyRowsModel> GetCompanyRow(BerryManagementEntities context, long? CompanyRowId, long? CompanyRow_CompanyID , long? CompanyRow_RowID,ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.CompanyRowsModel> result = null;
            try
            {
                var entryPoint = (from companyRows in context.CompanyRows
                                  join row in context.Rows on companyRows.CompanyRow_Row_Id equals row.Row_Id
                                  join company in context.Companyes on companyRows.CompanyRow_Company_Id equals company.Company_Id
                                  where (CompanyRowId == null || companyRows.CompanyRow_Id == CompanyRowId)&& (CompanyRow_CompanyID==null || companyRows.CompanyRow_Company_Id == CompanyRow_CompanyID) &&(CompanyRow_RowID==null || companyRows.CompanyRow_Row_Id==CompanyRow_RowID)
                                  select new Data.Structure.XClasses.CompanyRowsModel
                                  {
                                      CompanyRow_Id = companyRows.CompanyRow_Id,
                                      CompanyRow_Company_Id = companyRows.CompanyRow_Company_Id,
                                      CompanyRow_Company_Name = company.Company_Name,
                                      CompanyRow_Row_Id = companyRows.CompanyRow_Row_Id,
                                      CompanyRow_Row_Barkode = row.Row_Barkode,
                                      CompanyRow_Row_Number = row.Row_Number,
                                      CompanyRow_Row_Subrow_Number = row.Row_Subrow_Number,
                                      CompanyRow_Sector_Number = row.Sector_Number,
                                      CompanyRow_StartDate = companyRows.CompanyRow_StartDate,
                                      CompanyRow_EndDate = companyRows.CompanyRow_EndDate
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCompanyRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCompanyRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static string GetPointAddress(BerryManagementEntities context, long PointId, ref string errorMessage)
        {
            string result = null;
            try
            {
                result = (from points in context.Points
                                  where points.Point_Id == PointId
                                  select points.Point_Address).First().ToString();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointAddress()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPointAddress()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Structure.XClasses.PointsModel> GetPoint(BerryManagementEntities context, long? PointId, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                result = from points in context.Points
                         join pointType in context.tf_PointTypes() on points.Point_PointType_Id equals pointType.PointType_Id
                        where (PointId == null || points.Point_Id == PointId)
                        select new Data.Structure.XClasses.PointsModel
                        {
                            Point_Id = points.Point_Id,
                            Point_PointType_Id = points.Point_PointType_Id,
                            Point_Car_Id = points.Point_Car_Id,
                            Point_Address = points.Point_Address,
                            Point_BarCode = points.Point_BarCode,
                            Point_Car_Model = null,
                            Point_Car_Number = null,
                            Point_Description = points.Point_Description,
                            Point_IsActive = points.Point_IsActive,
                            Point_Name = points.Point_Name,
                            Point_PointType_IsActive = pointType.PointType_IsActive,
                            Point_PointType_Name = pointType.PointType_Name
                        };
                result = from r in result
                         join car in context.Cars on r.Point_Car_Id equals car.Car_Id into gj
                         from subpet in gj.DefaultIfEmpty()
                         select new Data.Structure.XClasses.PointsModel
                         {
                             Point_Id = r.Point_Id,
                             Point_PointType_Id = r.Point_PointType_Id,
                             Point_Car_Id = r.Point_Car_Id,
                             Point_Address = r.Point_Address,
                             Point_BarCode = r.Point_BarCode,
                             Point_Car_Model = subpet.Car_Id != 0 ? subpet.Car_Model : null,
                             Point_Car_Number = subpet.Car_Id != 0 ? subpet.Car_Number : null,
                             Point_Description = r.Point_Description,
                             Point_IsActive = r.Point_IsActive,
                             Point_Name = r.Point_Name,
                             Point_PointType_IsActive = r.Point_PointType_IsActive,
                             Point_PointType_Name = r.Point_PointType_Name
                         };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPoint()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.Structure.XClasses.PointsModel> GetPointsForWaybillIn(BerryManagementEntities context , ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                
                    var selectText = context.TransportWaybills.Where(c => c.TransportWaybill_RS_Id == null && c.TransportWaybill_RS_Number == null);
                    var point = selectText.Select(y => y.TransportWaybill_Car_Point_Id);
                    var car = selectText.Select(y => y.TransportWaybill_Car_Id);
                var pointl = selectText.Select(y => y.TransportWaybill_Car_Point_Id).ToList();
                var carl = selectText.Select(y => y.TransportWaybill_Car_Id).ToList();
                result = SelectQ.GetPoint(context, null, ref errorMessage).Where(c => point.Contains(c.Point_Id) && car.Contains(c.Point_Car_Id.Value));
       
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointsForWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPointsForWaybill()\n" + ex.Message;
                }
            }
            return result;
        }
        //transportway bill enddate aqvs null 
        public static IQueryable<Data.Structure.XClasses.PointsModel> GetPointsForSendBack(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PointsModel> result = null;
            try
            {

                var point = context.TransportWaybills.Where(c => c.TransportWaybill_End_DateTime == null).Select(y => y.TransportWaybill_Car_Point_Id);
                    result = SelectQ.GetPoint(context, null, ref errorMessage).Where(c => !point.Contains(c.Point_Id) && c.Point_PointType_Id=="LC" && c.Point_IsActive==true);
               
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointsForSendBack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPointsForSendBack()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.Structure.XClasses.PointsModel> GetPointsForWaybill(BerryManagementEntities context, bool direction, long? PointId, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                if (direction)
                {
                    var point = context.TransportWaybills.Where(c => c.TransportWaybill_Destination_Point_Id == null).Select(y => y.TransportWaybill_Car_Point_Id);
                    var car = context.TransportWaybills.Where(c => c.TransportWaybill_Destination_Point_Id == null).Select(y => y.TransportWaybill_Car_Id);
                    result = SelectQ.GetPoint(context, PointId, ref errorMessage).Where(c => /*point.Contains(c.Point_Id) && */car.Contains(c.Point_Car_Id.Value));
                }
                else
                {
                    var selectText = context.TransportWaybills.Where(c => c.TransportWaybill_End_DateTime == null && c.TransportWaybill_Destination_Point_Id != null);
                    var point = selectText.Select(y => y.TransportWaybill_Car_Point_Id);
                    var car = selectText.Select(y => y.TransportWaybill_Car_Id);
                    result = SelectQ.GetPoint(context, PointId, ref errorMessage).Where(c => point.Contains(c.Point_Id) && car.Contains(c.Point_Car_Id.Value));
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointsForWaybill()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPointsForWaybill()\n" + ex.Message;
                }
            }
            return result;
        }
        
        public static IQueryable<Data.Structure.XClasses.RowBreedsModel> GetRowBreeds(BerryManagementEntities context, long? RowBreedId, long? RowBreed_RowID, long? RowBreed_BreedID, ref string errorMessage)
        {
            IQueryable<Data.Structure.XClasses.RowBreedsModel> result = null;
            try
            {
                var entryPoint = (from rowBreed in context.RowBreeds
                                  join row in context.Rows on rowBreed.RowBreed_Row_Id equals row.Row_Id
                                  join breed in context.Breeds on rowBreed.RowBreed_Breed_Id equals breed.Breed_Id
                                  where ((RowBreedId == null || rowBreed.RowBreed_Id == RowBreedId) && (RowBreed_RowID==null || rowBreed.RowBreed_Row_Id==RowBreed_RowID) &&(RowBreed_BreedID==null || rowBreed.RowBreed_Breed_Id==RowBreed_BreedID))
                                  select new Data.Structure.XClasses.RowBreedsModel
                                  {
                                      RowBreed_Id = rowBreed.RowBreed_Id,
                                      RowBreed_Breed_Id = rowBreed.RowBreed_Breed_Id,
                                      RowBreed_Row_Id = rowBreed.RowBreed_Row_Id,
                                      RowBreed_Breed_Name = breed.Breed_Name,
                                      RowBreed_EndDate = rowBreed.RowBreed_EndDate,
                                      RowBreed_StartDate = rowBreed.RowBreed_StartDate,
                                      RowBreed_Row_Barkode = row.Row_Barkode,
                                      RowBreed_Row_Number = row.Row_Number,
                                      RowBreed_Row_Subrow_Number = row.Row_Subrow_Number,
                                      RowBreed_Sector_Number = row.Sector_Number,
                                      RowBreed_PlantYear=rowBreed.RowBreed_PlantYear,
                                      RowBreed_TreeCount=rowBreed.RowBreed_TreeCount
                                      
                                  });

                result = entryPoint;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPoint()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPoint()\n" + ex.Message;
                }
            }
            return result;
        }


    }
}
