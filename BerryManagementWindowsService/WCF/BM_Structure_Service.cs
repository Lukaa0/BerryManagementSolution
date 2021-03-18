using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Data;
using BerryManagementWindowsService.Data.Structure;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Structure_Service" in both code and config file together.
    public class BM_Structure_Service : IBM_Structure_Service
    {
        #region insert
        public long InsertPersonPost(Data.PersonPost PersonPost, ref String errorMessage)
        {
            return Data.Structure.insert.InsertPersonPost(PersonPost, ref errorMessage);
        }

        public void InserBrigades(Brigade Brigades, ref String errorMessage)
        {
            Data.Structure.insert.InsertBrigades(Brigades, ref errorMessage);
        }

        public void InsertCarDriver(CarDriver CarDrivers, ref String errorMessage)
        {
            Data.Structure.insert.InsertCarDriver(CarDrivers, ref errorMessage);
        }

        public void InsertCar(Car car, ref String errorMessage)
        {
            Data.Structure.insert.InsertCar(car, ref errorMessage);
        }

        public void InsertCompanyCar(CompanyCar compCar, ref String errorMessage)
        {
            Data.Structure.insert.InsertCompanyCar(compCar, ref errorMessage);
        }

        public void InsertCompany(Companye company, ref String errorMessage)
        {
            Data.Structure.insert.InsertCompany(company, ref errorMessage);
        }

        public void InsertCompanyRow(CompanyRow companyRow, ref String errorMessage)
        {
            Data.Structure.insert.InsertCompanyRow(companyRow, ref errorMessage);
        }
        public void InsertPoint(Point point, ref String errorMessage)
        {
            Data.Structure.insert.InsertPoint(point, ref errorMessage);
        }
        public void InsertPost(Post post, ref String errorMessage)
        {
            Data.Structure.insert.InsertPost(post, ref errorMessage);
        }
        public void InsertRowBreed(RowBreed rowBreed, ref String errorMessage)
        {
            Data.Structure.insert.InsertRowBreed(rowBreed, ref errorMessage);
        }
        public void InsertRow(Row row, ref String errorMessage)
        {
            Data.Structure.insert.InsertRow(row, ref errorMessage);
        }
        public void InsertRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage)
        {
            Data.Structure.insert.InsertRowBreedContainer(rowBreeds, companyRows, row, ref errorMessage);
        }
        #endregion

        #region select
        public  List<Data.Row> GetBrigadeRowDistribution(long?BrigadeID,ref string errorMessage)
        {
            return Data.Structure.SelectL.GetBrigadeRowDistribution(BrigadeID,ref errorMessage);
        }
        public List<Data.Row> GetHarvesterInAllRows(long? rowId,
           string rowBarcode, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetHarvesterInAllRows(rowId, rowBarcode, ref errorMessage);
        }
        public List<Data.Structure.XClasses.PointsModel> GetPointsForSendBack(ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPointsForSendBack(ref errorMessage);
        }
        public List<Data.Structure.XClasses.PointsModel> GetPointsForWaybillIn(ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPointsForWaybillIn( ref errorMessage);
        }
        public  List<Data.Row> GetHarvesterInDistributionModel(long PersonPostID, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetHarvesterInDistributionModel(PersonPostID, ref errorMessage);
        }
        public  List<Data.Structure.XClasses.RowModel> GetRowsByHarvesterRowInDistribution(long? brigadeId,ref string errorMessage)
        {
            return Data.Structure.SelectL.GetRowsByHarvesterRowInDistribution(brigadeId,ref errorMessage);
        }

            public  List<Data.Row> CheckGetRow(ref string errorMessage)
        {
            return SelectL.CheckGetRow(ref errorMessage);
        }

        #region AndroidApp

        public  List<Data.ProductPack> GetContainersForContainerPack(ref string errorMessage)
        {
            return Data.Structure.SelectL.GetContainersForContainerPack( ref errorMessage);
        }
            public  List<Data.Structure.XClasses.PointsModel> GetPointsForWaybill(bool direction, long? PointId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPointsForWaybill(direction, PointId, ref errorMessage);
        }
            public  List<Data.Structure.XClasses.PointsModel> GetCarsPointModelForContainerMove(bool direction,ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCarsPointModelForContainerMove(direction,ref errorMessage);
        }
        public  List<Data.Container> GetContainerForProductRecieve( ref string errorMessage)
        {
            return Data.Structure.SelectL.GetContainerForProductRecieve(ref errorMessage);
        }
        public  List<Data.Container> GetContainersForContainerMove(bool direction,long? pointId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetContainersForContainerMove(direction,pointId, ref errorMessage);
        }
        public List<Data.Container> GetContainersForContainerLocations(long? pointId, bool direction,string prefix, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetContainersForContainerLocations(pointId,direction, prefix, ref errorMessage);
        }
        public  List<Data.Container> GetContainersForSale(long? pointId, bool direction, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetContainersForSale(pointId, direction,ref errorMessage);
        }
            public  List<Data.Structure.XClasses.PointsModel> GetCarsPointModel(ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCarsPointModel(ref errorMessage);
        }

        public List<Data.Structure.XClasses.SalePointsModel> GetCarsPointModelForSale(ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCarsPointModelForSale(ref errorMessage);
        }

        public  List<string> GetPaletForContainerPack(bool direction, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPaletForContainerPack(direction, ref errorMessage);
        }
            #endregion
            public List<Row> GetRows(long? rowId, string rowBarcode, ref string errorMessage)
        {
            return SelectL.GetRows(rowId, rowBarcode, ref errorMessage);
        }
        public List<Data.Structure.XClasses.RowWithDateModel> GetRowsWithDate(ref string errorMessage)
        {
            return SelectL.GetRowsWithDate(ref errorMessage);
        }

        public List<Data.Structure.XClasses.RowModel> GetTakeRowInRow(bool direction,long? brigadeId,ref string errorMessage)
        {
            return SelectL.GetTakeRowInOutRow(direction, brigadeId,ref errorMessage);
        }
        public List<Data.Structure.XClasses.PostModel> GetPostModel(long? PostId, string PostName, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPostModel(PostId, PostName, ref errorMessage);
        }
        public List<Data.Post> GetPosts(long? PostId, string PostName, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPosts(PostId, PostName, ref errorMessage);
        }
        public List<Data.Brigade> GetBrigades(long? BrigadeId, string BrigadeName, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetBrigades(BrigadeId, BrigadeName, ref errorMessage);
        }
        public List<Data.Structure.XClasses.CarDriversModel> GetCarDrivers(long? CarDriversId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCarDrivers(CarDriversId, ref errorMessage);
        }
        public List<Data.Structure.XClasses.CarModel> GetCar(long? CarId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCar(CarId, ref errorMessage);
        }
        public List<Data.Structure.XClasses.CompanyCarModel> GetCompanyCar(long? CompanyCarId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCompanyCar(CompanyCarId, ref errorMessage);
        }
        public List<Data.Structure.XClasses.CompanyeModel> GetCompany(long? CompanyId, long? sideTypeId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCompany(CompanyId,sideTypeId, ref errorMessage);
        }
        public List<Data.Structure.XClasses.CompanyRowsModel> GetCompanyRow(long? CompanyRowId, long? CompanyRow_CompanyID, long? CompanyRow_RowID, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetCompanyRow(CompanyRowId, CompanyRow_CompanyID, CompanyRow_RowID, ref errorMessage);
        }
        public List<Data.Structure.XClasses.PointsModel> GetPoint(long? PointId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetPoint(PointId, ref errorMessage);
        }

        public List<Data.Structure.XClasses.RowBreedsModel> GetRowBreeds(long? RowBreedId, long? RowBreed_RowID,long? RowBreed_BreedID, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetRowBreeds(RowBreedId, RowBreed_RowID,RowBreed_BreedID, ref errorMessage);
        }
        public long GetHarvesterPostId(long rowId, ref string errorMessage)
        {
            return Data.Structure.SelectL.GetHarvesterPostId(rowId, ref errorMessage);
        }

        #endregion

        #region delete
        public void DeleteBrigade(long brigadeId, ref string errorMessage)
        {
            Delete.DeleteBrigade(brigadeId, ref errorMessage);
        }

        public void DeleteCarDriver(long CarDriverId, ref string errorMessage)
        {
            Delete.DeleteCarDriver(CarDriverId, ref errorMessage);
        }

        public void DeleteCar(long CarId, ref string errorMessage)
        {
            Delete.DeleteCar(CarId, ref errorMessage);
        }

        public void DeleteCompanyCar(long CompanyCarId, ref string errorMessage)
        {
            Delete.DeleteCompanyCar(CompanyCarId, ref errorMessage);
        }

        public void DeleteCompany(long CompanyId, ref string errorMessage)
        {
            Delete.DeleteCompany(CompanyId, ref errorMessage);
        }

        public void DeleteCompanyRows(long CompanyRowsId, ref string errorMessage)
        {
            Delete.DeleteCompanyRows(CompanyRowsId, ref errorMessage);
        }

        public void DeletePoint(Point PointObj, ref string errorMessage)
        {
            Delete.DeletePoint(PointObj, ref errorMessage);
        }
        public void DeleteRowBreeds(long RowBreedId, ref string errorMessage)
        {
            Delete.DeleteRowBreeds(RowBreedId, ref errorMessage);
        }
        public void DeleteRow(long RowId, ref string errorMessage)
        {
            Delete.DeleteRow(RowId, ref errorMessage);
        }

        public void DeletePost(long PostId, ref string errorMessage)
        {
            Delete.DeletePost(PostId, ref errorMessage);
        }


        #endregion

        #region update

        public  void UpdateRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage)
        {
            Data.Structure.Update.UpdateRowBreedContainer(rowBreeds, companyRows, row, ref errorMessage);
        }
        public  void UpdateBrigade(Brigade brigadeObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateBrigade(brigadeObj, ref errorMessage);
        }

        public void UpdateCarDriver(CarDriver CarDriverObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateCarDriver(CarDriverObj, ref errorMessage);
        }

        public void UpdateCar(Car CarObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateCar(CarObj, ref errorMessage);
        }

        public void UpdateCompanyCar(CompanyCar companyCarObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateCompanyCar(companyCarObj, ref errorMessage);
        }

        public void UpdateCompany(Companye companyObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateCompany(companyObj, ref errorMessage);
        }

        public void UpdateCompanyRow(CompanyRow companyRowObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateCompanyRow(companyRowObj, ref errorMessage);
        }


        public void UpdatePoint(Point pointObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdatePoint(pointObj, ref errorMessage);
        }


        public void UpdatePost(Post postObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdatePost(postObj, ref errorMessage);
        }


        public void UpdateRowBreed(RowBreed rowBreedObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateRowBreed(rowBreedObj, ref errorMessage);
        }

        public void UpdateRow(Row rowObj, ref string errorMessage)
        {
            Data.Structure.Update.UpdateRow(rowObj, ref errorMessage);
        }

        #endregion

    }
}
