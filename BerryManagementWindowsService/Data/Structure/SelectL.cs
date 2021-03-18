using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Structure
{
    public static class SelectL
    {
        public static List<Data.PersonPost> GetPersonPosts(long? personPostId, string harvesterBarCode, ref string errorMessage)
        {
            List<Data.PersonPost> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPost(context, personPostId, harvesterBarCode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Structure.XClasses.PointsModel> GetPointsForWaybill( bool direction, long? PointId, ref string errorMessage)
        {
            List<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPointsForWaybill(context,  direction,  PointId, ref errorMessage);
                    result = selectText.ToList();
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

        public static List<Data.Structure.XClasses.PointsModel> GetPointsForSendBack(ref string errorMessage)
        {
            List<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = SelectQ.GetPointsForSendBack(context, ref errorMessage).ToList();
                }
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

            public static List<XClasses.PointsModel> GetCarsPointModelForContainerMove( bool direction,ref string errorMessage)
        {
            List<XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetCarsPointModelForContainerMove(context, direction,ref errorMessage);
                    result = selectText.ToList();
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
        public static List<XClasses.RowModel> GetRowsByHarvesterRowInDistribution(long? brigadeId,ref string errorMessage)
        {
            List<XClasses.RowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRowsByHarvesterRowInDistribution(context,brigadeId,ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRowInRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRowInRow()\n" + ex.Message;
                }
            }
            return result;
        }

        #region AndroidApp

        
            public static List<Data.Container> GetContainersForContainerMove( bool direction,long? pointId, ref string errorMessage)
        {
            List<Data.Container> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersForContainerMove(context,direction, pointId, ref errorMessage);
                    result = selectText.ToList();
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
        public static List<Data.Container> GetContainersForContainerLocations(long? pointId, bool direction,string prefix, ref string errorMessage)
        {
            List<Data.Container> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersForContainerLocations(context, pointId, direction,prefix, ref errorMessage);
                    result = selectText.ToList();
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

        public static List<Data.Container> GetContainersForSale(long? pointId, bool direction, ref string errorMessage)
        {
            List<Data.Container> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersForSale(context, pointId, direction, ref errorMessage);
                    result = selectText.ToList();
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
        public static List<Data.Container> GetContainerForProductRecieve( ref string errorMessage)
        {
            List<Data.Container> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerForProductRecieve(context, ref errorMessage);
                    result = selectText.ToList();
                }
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
        public static List<XClasses.PointsModel> GetCarsPointModel(ref string errorMessage)
        {
            List<XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetCarsPointModel(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCarsPointModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCarsPointModel()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<XClasses.SalePointsModel> GetCarsPointModelForSale(ref string errorMessage)
        {
            List<XClasses.SalePointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetCarsPointModelForSale(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCarsPointModelForSale()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCarsPointModelForSale()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.ProductPack> GetContainersForContainerPack( ref string errorMessage)
        {
            List<Data.ProductPack> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersForContainerPack(context, ref errorMessage);
                    result = selectText.ToList();
                }
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
            public static List<string> GetPaletForContainerPack( bool direction, ref string errorMessage)
        {
            List<string> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPaletForContainerPack(context,direction, ref errorMessage);
                    result = selectText.ToList();
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
            #endregion
            public static List<XClasses.RowModel> GetTakeRowInOutRow(bool direction,long? brigadeId, ref string errorMessage)
        {
            List<XClasses.RowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowInOutRow(context,  direction,brigadeId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRowInRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRowInRow()\n" + ex.Message;
                }
            }
            return result;
        }
            public static List<Data.Row> GetBrigadeRowDistribution(long?BrigadeID,ref string errorMessage)
        {
            List<Data.Row> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetBrigadeRowDistribution(context, BrigadeID, ref errorMessage);
                    result = selectText.ToList();
                }
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
        public static List<Data.Structure.XClasses.PointsModel> GetPointsForWaybillIn( ref string errorMessage)
        {
            List<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPointsForWaybillIn(context,  ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointsForWaybillIn()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPointsForWaybillIn()\n" + ex.Message;
                }
            }
            return result;
        }
            public static List<Data.Row> GetHarvesterInDistributionModel( long PersonPostID, ref string errorMessage)
        {
            List<Data.Row> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterInDistributionModel(context, PersonPostID, ref errorMessage);
                    result = selectText.ToList();
                }
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
            public static List<Data.Row> GetHarvesterInAllRows( long? rowId,
            string rowBarcode, ref string errorMessage)
        {
            List<Data.Row> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterInAllRows(context, rowId, rowBarcode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterInAllRows()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterInAllRows()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Row> GetRows(long? rowId, string rowBarcode, ref string errorMessage)
        {
            List<Data.Row> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRows(context, rowId, rowBarcode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<XClasses.RowWithDateModel> GetRowsWithDate(ref string errorMessage)
        {
            List<XClasses.RowWithDateModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRowsWithDate(context, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<Data.Structure.XClasses.PostModel> GetPostModel(long? PostId, string PostName, ref string errorMessage)
        {
            List<Data.Structure.XClasses.PostModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetPostModel(context, PostId, PostName,ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPostModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPostModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Row> CheckGetRow( ref string errorMessage)
        {
            List<Data.Row> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.CheckGetRow(context,ref errorMessage);
                    result = select.ToList();
                }
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
        public static List<Data.Post> GetPosts(long? PostId, string PostName, ref string errorMessage)
        {
            List<Data.Post> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetPosts(context, PostId, PostName, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPosts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Brigade> GetBrigades(long? BrigadeId, string BrigadeName, ref string errorMessage)
        {
            List<Data.Brigade> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetBrigades(context, BrigadeId, BrigadeName, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBrigades()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetBrigades()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.CarDriversModel> GetCarDrivers(long? CarDriversId, ref string errorMessage)
        {
            List<XClasses.CarDriversModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetCarDrivers(context,CarDriversId, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCarDrivers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCarDrivers()\n" + ex.Message;
                }
            }
            return result;
        }



        public static List<Data.Structure.XClasses.CarModel> GetCar(long? CarId, ref string errorMessage)
        {
            List<Data.Structure.XClasses.CarModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetCar(context, CarId, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCar()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Structure.XClasses.CompanyCarModel> GetCompanyCar(long? CompanyCarId, ref string errorMessage)
        {
            List<Data.Structure.XClasses.CompanyCarModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetCompanyCar(context, CompanyCarId, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCompanyCar()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCompanyCar()\n" + ex.Message;
                }
            }
            return result;
        }



        public static List<Data.Structure.XClasses.CompanyeModel> GetCompany(long? CompanyId, long? sideTypeId, ref string errorMessage)
        {
            List<Data.Structure.XClasses.CompanyeModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetCompany(context, CompanyId, sideTypeId, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCompany()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCompany()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Structure.XClasses.CompanyRowsModel> GetCompanyRow(long? CompanyRowId, long? CompanyRow_CompanyID, long? CompanyRow_RowID,ref string errorMessage)
        {
            List<Data.Structure.XClasses.CompanyRowsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetCompanyRow(context, CompanyRowId, CompanyRow_CompanyID,CompanyRow_RowID,ref errorMessage);
                    result = select.ToList();
                }
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


        public static List<Data.Structure.XClasses.PointsModel> GetPoint(long? PointId, ref string errorMessage)
        {
            List<Data.Structure.XClasses.PointsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetPoint(context, PointId, ref errorMessage);
                    result = select.ToList();
                }
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


        public static List<Data.Structure.XClasses.RowBreedsModel> GetRowBreeds(long? RowBreedId, long? RowBreed_RowID,long? RowBreed_BreedID, ref string errorMessage)
        {
            List<Data.Structure.XClasses.RowBreedsModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetRowBreeds(context, RowBreedId, RowBreed_RowID, RowBreed_BreedID, ref errorMessage);
                    result = select.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRowBreeds()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRowBreeds()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long GetHarvesterPostId(long rowId,
    ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var select = SelectQ.GetHarvesterPostId(context, rowId, ref errorMessage);
                    result = select;
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterPostId()\n" + ex.Message;
                }
            }
            return result;
        }

    }
}
