using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Data;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Structure_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Structure_Service
    {
        #region insert

        [OperationContract]
        long InsertPersonPost(Data.PersonPost PersonPost, ref String errorMessage);

        [OperationContract]
        void InserBrigades(Brigade Brigades, ref String errorMessage);

        [OperationContract]
        void InsertCarDriver(CarDriver CarDrivers, ref String errorMessage);

        [OperationContract]
        void InsertCar(Car car, ref String errorMessage);

        [OperationContract]
        void InsertCompanyCar(CompanyCar compCar, ref String errorMessage);

        [OperationContract]
        void InsertCompany(Companye company, ref String errorMessage);

        [OperationContract]
        void InsertCompanyRow(CompanyRow companyRow, ref String errorMessage);

        [OperationContract]
        void InsertPoint(Point point, ref String errorMessage);

        [OperationContract]
        void InsertPost(Post post, ref String errorMessage);

        [OperationContract]
        void InsertRowBreed(RowBreed rowBreed, ref String errorMessage);

        [OperationContract]
        void InsertRow(Row row, ref String errorMessage);

        [OperationContract]
        void InsertRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage);

        #endregion

        #region select

        [OperationContract]
        List<Row> GetRows(long? rowId, string rowBarcode, ref string errorMessage);

        [OperationContract]
        List<Data.Container> GetContainersForSale(long? pointId, bool direction, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.RowWithDateModel> GetRowsWithDate(ref string errorMessage);

        [OperationContract]
        List<Data.Row> GetBrigadeRowDistribution(long?BrigadeID,ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetPointsForSendBack(ref string errorMessage);

        [OperationContract]
        List<Data.Row> GetHarvesterInDistributionModel(long PersonPostID, ref string errorMessage);

        [OperationContract]
        List<Data.Row> GetHarvesterInAllRows(long? rowId,
          string rowBarcode, ref string errorMessage);

        [OperationContract]
        List<Data.Row> CheckGetRow(ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.RowModel> GetRowsByHarvesterRowInDistribution(long? brigadeId,ref string errorMessage);

        #region AndroidApp
        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetCarsPointModelForContainerMove(bool direction,ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetPointsForWaybillIn(ref string errorMessage);

        [OperationContract]
        List<Data.ProductPack> GetContainersForContainerPack(ref string errorMessage);
        
        [OperationContract]
        List<Data.Container> GetContainerForProductRecieve( ref string errorMessage);

        [OperationContract]
        List<Data.Container> GetContainersForContainerMove(bool direction,long? pointId, ref string errorMessage);

        [OperationContract]
        List<Data.Container> GetContainersForContainerLocations(long? pointId, bool direction,string prefix, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetCarsPointModel(ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.SalePointsModel> GetCarsPointModelForSale(ref string errorMessage);

        [OperationContract]
        List<string> GetPaletForContainerPack(bool direction, ref string errorMessage);
        #endregion

        [OperationContract]
        List<Data.Structure.XClasses.RowModel> GetTakeRowInRow(bool direction,long? brigadeId,ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetPointsForWaybill(bool direction, long? PointId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PostModel> GetPostModel(long? PostId, string PostName, ref string errorMessage);

        [OperationContract]
        List<Data.Post> GetPosts(long? PostId, string PostName, ref string errorMessage);

        [OperationContract]
        List<Data.Brigade> GetBrigades(long? BrigadeId, string BrigadeName, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.CarDriversModel> GetCarDrivers(long? CarDriversId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.CarModel> GetCar(long? CarId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.CompanyCarModel> GetCompanyCar(long? CompanyCarId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.CompanyeModel> GetCompany(long? CompanyId, long? sideTypeId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.CompanyRowsModel> GetCompanyRow(long? CompanyRowId, long? CompanyRow_CompanyID,long?CompanyRow_RowID, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.PointsModel> GetPoint(long? PointId, ref string errorMessage);

        [OperationContract]
        List<Data.Structure.XClasses.RowBreedsModel> GetRowBreeds(long? RowBreedId, long? RowBreed_RowID, long? RowBreed_BreedID, ref string errorMessage);

        [OperationContract]
        long GetHarvesterPostId(long rowId, ref string errorMessage);
        #endregion

        #region delete
        [OperationContract]
        void DeleteBrigade(long brigadeId, ref string errorMessage);
        [OperationContract]
        void DeleteCarDriver(long CarDriverId, ref string errorMessage);
        [OperationContract]
        void DeleteCar(long CarId, ref string errorMessage);
        [OperationContract]
        void DeleteCompanyCar(long CompanyCarId, ref string errorMessage);
        [OperationContract]
        void DeleteCompany(long CompanyId, ref string errorMessage);
        [OperationContract]
        void DeleteCompanyRows(long CompanyRowsId, ref string errorMessage);
        [OperationContract]
        void DeletePoint(Point PointObj, ref string errorMessage);
        [OperationContract]
        void DeleteRowBreeds(long RowBreedId, ref string errorMessage);
        [OperationContract]
        void DeleteRow(long RowId, ref string errorMessage);
        [OperationContract]
        void DeletePost(long PostId, ref string errorMessage);

        #endregion

        #region update
        [OperationContract]
        void UpdateRowBreedContainer(RowBreed rowBreeds, CompanyRow companyRows, Row row, ref string errorMessage);

        [OperationContract]
        void UpdateBrigade(Brigade brigadeObj, ref string errorMessage);

        [OperationContract]
        void UpdateCarDriver(CarDriver CarDriverObj, ref string errorMessage);

        [OperationContract]
        void UpdateCar(Car CarObj, ref string errorMessage);

        [OperationContract]
        void UpdateCompanyCar(CompanyCar companyCarObj, ref string errorMessage);

        [OperationContract]
        void UpdateCompany(Companye companyObj, ref string errorMessage);

        [OperationContract]
        void UpdateCompanyRow(CompanyRow companyRowObj, ref string errorMessage);

        [OperationContract]
        void UpdatePoint(Point pointObj, ref string errorMessage);

        [OperationContract]
        void UpdatePost(Post postObj, ref string errorMessage);

        [OperationContract]
        void UpdateRowBreed(RowBreed rowBreedObj, ref string errorMessage);

        [OperationContract]
        void UpdateRow(Row rowObj, ref string errorMessage);

        #endregion

    }
}
