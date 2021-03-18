using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Classes;
using BerryManagementWindowsService.Data;
using BerryManagementWindowsService.Data.Operation;
using BerryManagementWindowsService.Data.Operation.XClasses;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Operation_Service" in both code and config file together.
    public class BM_Operation_Service : IBM_Operation_Service
    {
        #region Fixator
        public void FixTakeRowInOut(Data.Operation.XClasses.TakeRowInOut takeRowInOut, ref string errorMessage)
        {
            Data.Operation.Fixator.FixTakeRowInOut(takeRowInOut, ref errorMessage);
        }

        public string FixContainerSendBack(int containerCount, long carId, long startPointId, long destinationPointId, ref string errorMessage)
        {
            return Data.Operation.Fixator.FixContainerSendBack(containerCount, carId, startPointId, destinationPointId, ref errorMessage);
        }

        public void FixProductQuality(string containerBarcode, ref string errorMessage)
        {
            Data.Operation.Fixator.FixProductQuality(containerBarcode, ref errorMessage);
        }

        public int FixSaleContainer(SaleContainer saleContainer, bool isComplite, long? companyId, ref string errorMessage)
        {
           return  Data.Operation.Fixator.FixSaleContainer(saleContainer, isComplite, companyId, ref errorMessage);
        }

        public void FixContainerPack(ContainerPack containerPack, bool insert, string paletbarCode, bool closePalet, long? userPointId, long? userPersonPostId, ref string errorMessage)
        {
            Data.Operation.Fixator.FixContainerPack(containerPack, insert, paletbarCode, closePalet, userPointId, userPersonPostId, ref errorMessage);
        }

        public List<Data.TakeRow> GetTakeRowsByBrigadeId(ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowsByBrigadeId(ref errorMessage);
        }

        public List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts(bool Direction, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetHarvesterRowDistributionInOuts(Direction, ref errorMessage);
        }
        public void FixHarvesterRowDistributionInOut(HarvesterRowDistributionInOut harvDist, ref string errorMessage)
        {
            Fixator.FixHarvesterRowDistributionInOut(harvDist, ref errorMessage);
        }

        public int FixContainerMove(ContainerMove container, bool direction, ref string errorMessage)
        {
            return Fixator.FixContainerMoveInOut(container, direction, ref errorMessage);
        }
        public void FixProductReceive(ProductReceive productReceive, ref string errorMessage)
        {
            Fixator.FixProductReceives(productReceive, ref errorMessage);
        }

        public void FixHarvesterContainerDistribution(HarvesterContainerDistributionInOut container, ref string errorMessage)
        {
            Fixator.FixHarvesterContainerDistribution(container, ref errorMessage);
        }

        public void FixPunishment(PunishmentIn punishmentIn, ref string errorMessage)
        {
            Fixator.FixPunishment(punishmentIn, ref errorMessage);
        }

        public ProductRepackAndWeight FixProductRepackAndWeight(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            return Fixator.FixProductRepackAndWeight(productRepackAndWeight, ref errorMessage);
        }

        public string CreateTransportWaybill(long carId, long startPointId, long destinationPointId, long personPostId, ref string errorMessage)
        {
            return Fixator.CreateTransportWaybill(carId, startPointId, destinationPointId, personPostId, ref errorMessage);
        }

        public string CloseTransportWaybill(long carId, long destinationPointId, ref string errorMessage)
        {
            return Fixator.CloseTransportWaybill(carId, destinationPointId, ref errorMessage);
        }

        public void CorrectWaybill(long transportWaybillId, ref string errorMessage)
        {
            Fixator.CorrectWaybill(transportWaybillId, ref errorMessage);
        }

        #endregion Fixator

        #region Select
        public List<Data.OperationSetting> GetOperationSettings(string key, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetOperationSettings(key, ref errorMessage);
        }

        public List<ProductPack> GetContainerForQuality(ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerForQuality(ref errorMessage);
        }
        public List<Data.Operation.XClasses.Pallete.ContainerModel> GetContainerModelByPalette(string containerBarcode, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerModelByPalette(containerBarcode, ref errorMessage);
        }

        public long GetContainerPackByPalette(string containerBarcode, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerPackByPalette(containerBarcode, ref errorMessage);
        }
        public long GetContainerPackCountByCarId(long carId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerPackCountByCarId(carId, ref errorMessage);
        }

        public int GetCountForContainerMove(long transportWaybillId, bool direction, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetCountForContainerMove(transportWaybillId, direction, ref errorMessage);
        }

        public List<Data.Operation.XClasses.ContainerPackModel> GetContainerPackModel(bool direction, string parentContainerBarCode, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerPackModel(direction, parentContainerBarCode, ref errorMessage);
        }

        public List<Data.Operation.XClasses.ContainerMoveInOut> GetContainerMoveInOut(bool direction, long carPointId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerMoveInOut(direction, carPointId, ref errorMessage);
        }

        public List<Data.HarvesterRowDistribution> GetHarvesterRowDistribution(long? id, long? Row_Id, long? Harvester_PersonPost_Id,
            Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetHarvesterRowDistribution(id, Row_Id, Harvester_PersonPost_Id, inId, outId, outIdFiltered, ref errorMessage);
        }

        public bool CheckHarvesterInRowPersonPost(long personpostID, ref string errorMessage)
        {
            return Data.Operation.SelectL.CheckHarvesterInRowPersonPost(personpostID, ref errorMessage);
        }

        public bool CheckTakeRows(long brgID, ref string errorMessage)
        {
            return Data.Operation.SelectL.CheckTakeRows(brgID, ref errorMessage);
        }
        public List<Data.TakeRow> GetTakeRows(long? id, long? rowId, long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRows(id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage);
        }

        public List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModel(long? brigadeId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowsModel(brigadeId, outId, outIdFiltered, ref errorMessage);
        }

        public List<Data.Operation.XClasses.TakeRowModel> GetClosedTakeRowsModel(DateTime? closedTime, DateTime? closedTimeTwo, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetClosedTakeRowsModel(closedTime, closedTimeTwo, ref errorMessage);
        }
        public List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModelByBrigadeId(ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowsModelByBrigadeId(ref errorMessage);

        }

        public List<Data.Operation.XClasses.TakeRowInOut> GetTakeRowsInByPersonPostID(long? id, long? rowId,
          long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowsInByPersonPostID(id, rowId, brigadeId, inId, outId, outIdFiltered, userPersonPostId, ref errorMessage);
        }
        public List<Data.Operation.XClasses.TakeRowInOut> GetTakeRowsOutByPersonPostID(long? id, long? rowId,
         long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowsOutByPersonPostID(id, rowId, brigadeId, inId, outId, outIdFiltered, userPersonPostId, ref errorMessage);
        }

        public List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionIn(long userPersonPostId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetHarvesterRowDistributionIn(userPersonPostId, ref errorMessage);
        }

        public List<Data.Operation.XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionOut(long userPersonPostId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetHarvesterRowDistributionOut(userPersonPostId, ref errorMessage);
        }

        public List<Data.TakeRow> GetTakeRowForBrigade(long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRowForBrigade(id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage);
        }

        public List<Data.Operation.XClasses.TakeRowModel> GetRowsWithBrigade(ref string errorMessage)
        {
            return Data.Operation.SelectL.GetRowsWithBrigade(ref errorMessage);

        }

        public List<Data.HarvesterRowDistribution> GetHarvRowDistribByPersonPostId(long personPostId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetHarvRowDistribByPersonPostId(personPostId, ref errorMessage);
        }

        public List<Data.ContainerLocation> CheckContainerLocationForPackaging(string containerBarcode, ref string errorMessage)
        {
            return Data.Operation.SelectL.CheckContainerLocationForPackaging(containerBarcode, ref errorMessage);
        }

        public List<Data.Operation.XClasses.ContainerWeightModel> GetWeightsForReport(long? PersonPostId, long? RecieverPostId, DateTime Time, DateTime Timeplusone, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetWeightsForReport((long)PersonPostId, Time, Timeplusone, ref errorMessage);

        }

        public List<Data.Operation.XClasses.TakeRows_Harvesters> GetTakeRows_Harvesters(long? brigadeId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetTakeRows_Harvesters(brigadeId, ref errorMessage);
        }

        public List<Data.Operation.XClasses.ContainerLocationModel> GetContainersLocationss(long? PointId, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainersLocationss(PointId, ref errorMessage);
        }
        #endregion Select

        #region update
        public void UpdateOperationSetting(OperationSetting operationSetting, ref String errorMessage)
        {
            Data.Operation.Update.UpdateOperationSetting(operationSetting, ref errorMessage);
        }
        public void UpdateTakeRowWith(TakeRow takeRow, ref String errorMessage)
        {
            Data.Operation.Update.UpdateTakeRowWith(takeRow, ref errorMessage);
        }
        public void UpdateTakeRow(TakeRow takeRow, ref String errorMessage)
        {
            Data.Operation.Update.UpdateTakeRow(takeRow, ref errorMessage);
        }
        public void testc()
        {
        }


        #endregion Update

        //public bool InsertPalleteWeight(string pal_barcode, long user_Id, ref string errorMessage)
        //{
        //    return Data.Operation.Insert.InsertPalleteWeight(pal_barcode, user_Id, ref errorMessage);
        //}


        public int GetCountForContainerPack(string parentBarcode, bool direction, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetCountForContainerPack(parentBarcode, direction, ref errorMessage);
        }

        public string GetLatestVersion(ref string errorMessage)
        {
            return SelectL.GetLatestVersion(ref errorMessage);
        }

        public Stream DownloadNewVersion()
        {
            try
            {
                string errorMessage = null;
                string workingDirectory = Environment.CurrentDirectory;
                string projectDirectory = SelectL.GetOperationSettings("NewVersionPath", ref errorMessage).First().OperationSetting_Value;
                var file = File.OpenRead(projectDirectory);
                return file;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        //public byte[] GetNewVersion()
        //{
        //    try
        //    {
        //        byte[] buff = null;
        //        FileStream fs = new FileStream(fileName,
        //                                       FileMode.Open,
        //                                       FileAccess.Read);
        //        BinaryReader br = new BinaryReader(fs);
        //        long numBytes = new FileInfo(fileName).Length;
        //        buff = br.ReadBytes((int)numBytes);
        //        return buff;



        //        string workingDirectory = Environment.CurrentDirectory;
        //        string projectDirectory =
        //            Directory.GetParent(workingDirectory).Parent.FullName + @"\NewVersion\BerryApp.apk";
        //        byte[] file = ope
        //        var file = File.OpenRead(projectDirectory);
        //        return file;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}

        public bool InsertContainerMove(ContainerMove containerMove, bool direction, ref String errorMessage)
        {
            return Data.Operation.Insert.InsertContainerMove(containerMove, direction, ref errorMessage);
        }

        //public List<Data.HarvesterContainerDistribution> GetHarvesterContainerDistributions(long? HarvesterContainerDistribution_Harvester_Person_Id,
        //    ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetHarvesterContainerDistributions(HarvesterContainerDistribution_Harvester_Person_Id, ref errorMessage);
        //}

        //ჩაწერა ConterinerWeigt
        //public bool InsertContainerWeight(Data.ContainerWeight containerWeight, ref String errorMessage)
        //{
        //    return Data.Operation.Insert.InsertContainerWeight(containerWeight,ref errorMessage);
        //}
        ////სელექტ ConterinerWeigt
        //public List<Data.ContainerWeight> GetContainerWeights(ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetContainerWeights(ref errorMessage);
        //}

        //public  string CreateContainer(string containerTypeId, ref string errorMessage)
        //{
        //    return Data.Library.XClass.ContainerBarCodeGenerator.CreateContainer(containerTypeId, ref errorMessage);
        //}
        ////სელექტ Quality (ComboBox)
        //public List<Data.tf_ProductQualityes_Result> GetTf_ProductQualityes(ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetTf_ProductQualityes(ref errorMessage);
        //}

        //ჩაწერა ContainerPack
        public bool InsertContainerPack(Data.ContainerPack containerPack, long userPointId, ref String errorMessage)
        {
            return Data.Operation.Insert.InsertContainerPack(containerPack, userPointId, ref errorMessage);
        }
        //public List<Data.ProductReceive> GetAllProducts(ref String errorMessage)
        //{
        //    return Data.Operation.SelectL.GetAllProducts(ref errorMessage);
        //}

        //public bool InsertProduct(ProductReceive product, ref String errorMessage)
        //{
        //    return Data.Operation.Insert.InsertProductReceive(product, ref errorMessage);
        //}

        //public bool InsertTakeRowInOut(TakeRowInOut productReceive, ref string errorMessage)
        //{
        //    return Data.Operation.Insert.InsertTakeRowInOut(productReceive, ref errorMessage);
        //}

        //public bool InsertContainerInOut(ContainerMoveInOut containerInOut, ref String errorMessage)
        //{
        //    return Data.Operation.Insert.InsertContainerInOut(containerInOut, ref errorMessage);
        //}
        //public List<Data.ContainerMoveInOut> GetContainerMoveInOuts(ref String errorMessage)
        //{
        //    return Data.Operation.SelectL.GetContainerMoveInOuts(ref errorMessage);
        //}

        //public List<TakeRowInOut> GetTakeRowInOuts(ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetTakeRowInOuts(ref errorMessage);
        //}

        //public List<HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts(ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetHarvesterRowDistributionInOuts(ref errorMessage);
        //}

        //public bool InsertHarvesterRowDistributionInOut(HarvesterRowDistributionInOut harvesterInOut, ref string errorMessage)
        //{
        //    return Data.Operation.Insert.InsertHarvesterRowDistributionInOut(harvesterInOut,ref errorMessage);
        //}

        //public List<HarvesterRowViewModel> GetJoinedHarvesters( ref string errorMessage)
        //{
        //    return Data.Operation.SelectL.GetJoinedHarvesters(ref errorMessage);
        //}

        public List<Data.Operation.XClasses.Pallete.PalleteModel> GetContainerWeightsByChars(string barcodeType, DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Operation.SelectL.GetContainerWeightsByChars(barcodeType, start, end, ref errorMessage);
        }
    }
}