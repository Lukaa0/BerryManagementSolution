using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Data;
using BerryManagementWindowsService.Data.Operation.XClasses;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Operation_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Operation_Service
    {
        #region Fixator
        [OperationContract]
        void FixTakeRowInOut(Data.Operation.XClasses.TakeRowInOut takeRowInOut, ref string errorMessage);

        [OperationContract]
        void FixProductReceive(ProductReceive productReceive, ref string errorMessage);

        [OperationContract]
        void FixContainerPack(ContainerPack containerPack, bool insert, string paletbarCode, bool closePalet, long? userPointId, long? userPersonPostId, ref string errorMessage);

        [OperationContract]
        int FixSaleContainer(SaleContainer saleContainer, bool isComplite, long? companyId, ref string errorMessage);

        [OperationContract]
        void  FixProductQuality(string containerBarcode, ref string errorMessage);

        [OperationContract]
        string FixContainerSendBack(int containerCount, long carId, long startPointId, long destinationPointId, ref string errorMessage);

        [OperationContract]
        List<Data.TakeRow> GetTakeRowsByBrigadeId(ref string errorMessage);
    
        [OperationContract]
        void FixHarvesterRowDistributionInOut(Data.Operation.XClasses.HarvesterRowDistributionInOut harvDist, ref string errorMessage);

        [OperationContract]
        int FixContainerMove(ContainerMove container, bool direction, ref string errorMessage);

        [OperationContract]
        void FixHarvesterContainerDistribution(HarvesterContainerDistributionInOut container, ref string errorMessage);

        [OperationContract]
        void FixPunishment(PunishmentIn punishmentIn, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts(bool Direction, ref string errorMessage);
        
        [OperationContract]
        ProductRepackAndWeight FixProductRepackAndWeight(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.ContainerPackModel> GetContainerPackModel(bool direction, string parentContainerBarCode, ref string errorMessage);


        [OperationContract]
        string CreateTransportWaybill(long carId, long startPointId, long destinationPointId, long personPostId, ref string errorMessage);

        [OperationContract]
        string CloseTransportWaybill(long carId, long destinationPointId, ref string errorMessage);

        [OperationContract]
        bool InsertContainerPack(Data.ContainerPack containerPack, long userPointId, ref String errorMessage);

        [OperationContract]
        void CorrectWaybill(long transportWaybillId, ref string errorMessage);
        #endregion Fixator

        #region Select
        [OperationContract]
        List<Data.OperationSetting> GetOperationSettings(string key, ref string errorMessage);

        [OperationContract]
        int GetCountForContainerMove(long transportWaybillId, bool direction, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.Pallete.ContainerModel> GetContainerModelByPalette(string containerBarcode, ref string errorMessage);

        [OperationContract]
        long GetContainerPackByPalette(string containerBarcode, ref string errorMessage);

        [OperationContract]
        long GetContainerPackCountByCarId(long carId, ref string errorMessage);

        [OperationContract]
        List<ProductPack> GetContainerForQuality(ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.ContainerMoveInOut> GetContainerMoveInOut(bool direction, long carPointId, ref string errorMessage);
        
        [OperationContract]
        List<Data.HarvesterRowDistribution> GetHarvesterRowDistribution(long? id, long? Row_Id, long? Harvester_PersonPost_Id,
            Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage);
        [OperationContract]
        bool CheckHarvesterInRowPersonPost(long personpostID, ref string errorMessage);

        [OperationContract]
        bool CheckTakeRows(long brgID, ref string errorMessage);


        [OperationContract]
        List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModel(long? brigadeId, Guid? outId, bool outIdFiltered, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModelByBrigadeId(ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.TakeRowModel> GetRowsWithBrigade(ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.TakeRowModel> GetClosedTakeRowsModel(DateTime? closedTime, DateTime? closedTimeTwo, ref string errorMessage);

        [OperationContract]
        List<Data.TakeRow> GetTakeRows(long? id, long? rowId, long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage);
        [OperationContract]
        List<Data.Operation.XClasses.TakeRowInOut> GetTakeRowsOutByPersonPostID(long? id, long? rowId,
          long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage);
        [OperationContract]
        List<Data.Operation.XClasses.TakeRowInOut> GetTakeRowsInByPersonPostID(long? id, long? rowId,
         long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionOut(long userPersonPostId, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionIn(long userPersonPostId, ref string errorMessage);


        [OperationContract]
        List<Data.HarvesterRowDistribution> GetHarvRowDistribByPersonPostId(long personPostId, ref string errorMessage);

        [OperationContract]
        List<Data.ContainerLocation> CheckContainerLocationForPackaging(string containerBarcode, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.ContainerWeightModel> GetWeightsForReport(long? PersonPostId, long? RecieverPostId, DateTime Time, DateTime Timeplusone, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.TakeRows_Harvesters> GetTakeRows_Harvesters(long? brigadeId, ref string errorMessage);

        [OperationContract]
        List<Data.Operation.XClasses.ContainerLocationModel> GetContainersLocationss(long? PointId, ref string errorMessage);
        #endregion Select

        #region update
        [OperationContract]
        void UpdateOperationSetting(OperationSetting operationSetting, ref String errorMessage);
        #endregion Update

        //[OperationContract]
        //bool InsertPalleteWeight(string pal_barcode, long user_Id, ref string errorMessage);


        [OperationContract]
        int GetCountForContainerPack(string parentBarcode, bool direction, ref string errorMessage);

        [OperationContract]
        string GetLatestVersion(ref string errorMessage);

        [OperationContract]
        void UpdateTakeRowWith(TakeRow takeRow, ref String errorMessage);

        [OperationContract]
        void UpdateTakeRow(TakeRow takeRow, ref String errorMessage);

        [OperationContract]
        bool InsertContainerMove(ContainerMove containerMove, bool direction,ref String errorMessage);

        [OperationContract]
        Stream DownloadNewVersion();

        [OperationContract]
        List<Data.Operation.XClasses.Pallete.PalleteModel> GetContainerWeightsByChars(string barcodeType, DateTime? start, DateTime? end, ref string errorMessage);

    }
}
