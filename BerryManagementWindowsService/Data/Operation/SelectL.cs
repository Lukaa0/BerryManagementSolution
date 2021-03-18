using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Operation
{
    public static class SelectL
    {
        public static List<Data.ContainerMove> GetContainerMove(long? id, Guid? inId, long? transportWaybillId, string containerBarCode,Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.ContainerMove> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerMove(context, id, transportWaybillId, containerBarCode, inId, outId, outIdFiltered,
                        ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static string GetLatestVersion(ref string errorMessage)
        {
            string result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetOperationSettings(context, ref errorMessage);

                    result = selectText.ToList()[0].OperationSetting_Value;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static int GetCountForContainerMove(long transportWaybillId, bool direction, ref string errorMessage)
        {
            int result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (direction)
                    {
                        result = SelectL.GetContainerMove(null, null, transportWaybillId, null, null, true, ref errorMessage).Count();
                    }
                    else
                    {
                        result = SelectL.GetContainerMove(null, null, transportWaybillId, null, null, true, ref errorMessage).Count();
                    }                   
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCountForContainerMove()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCountForContainerMove()\n" + ex.Message;
                }
            }
            return result;
        }

        public static int GetCountForContainerPack(string parentBarcode, bool direction, ref string errorMessage)
        {
            int result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                   
                        result = SelectL.GetContainerPackModel( direction, parentBarcode, ref errorMessage).Count();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCountForContainerMove()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetCountForContainerMove()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.ContainerPackModel> GetContainerPackModel(bool direction, string parentContainerBarCode, ref string errorMessage)
        {
            List<XClasses.ContainerPackModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerPackModel(context, direction, parentContainerBarCode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerPackModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerPackModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Point> GetPointById(long? id,string barcode,ref string errorMessage)
        {
            List<Data.Point> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPointById(context, id,barcode,ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.HarvesterRowDistribution> GetHarvRowDistribByPersonPostId( long personPostId, ref string errorMessage)
        {
            List<Data.HarvesterRowDistribution> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvRowDistribByPersonPostId(context,personPostId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionOut( long userPersonPostId, ref string errorMessage)
        {
            List<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterRowDistributionOut(context,userPersonPostId, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionIn(long userPersonPostId, ref string errorMessage)
        {
            List<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterRowDistributionIn(context, userPersonPostId, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts( bool Direction, ref string errorMessage)
        {
            List<XClasses.HarvesterRowDistributionInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterRowDistributionInOuts(context, Direction, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.ContainerMoveInOut> GetContainerMoveInOut(bool direction,long carPoinID, ref string errorMessage)
        {
            List<XClasses.ContainerMoveInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerMoveInOut(context,direction, carPoinID, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerMoveInOut()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerMoveInOut()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.Pallete.ContainerModel> GetContainerModelByPalette(string containerBarcode, ref string errorMessage)
        {
            List<Data.Operation.XClasses.Pallete.ContainerModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerModelByPalette(context, containerBarcode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerModelByPalette()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerModelByPalette()\n" + ex.Message;
                }
            }
            return result;
        }


        public static long GetContainerPackByPalette(string containerBarcode, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerPackByPalette(context,containerBarcode, ref errorMessage);
                    result = selectText.ToList().Count();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerPackByPalette()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerPackByPalette()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long GetContainerPackCountByCarId(long carId, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerPackByCarId(context, carId, ref errorMessage);
                    result = selectText.ToList().Count();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerPackCountByCarId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerPackCountByCarId()\n" + ex.Message;
                }
            }
            return result;
        }

        //public static List<XClasses.SaleContainer> GetSaleContainer(bool direction, long buyerId, ref string errorMessage)
        //{
        //    List<XClasses.SaleContainer> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetSaleContainer(context, direction, buyerId, ref errorMessage);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetSaleContainer()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetSaleContainer()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        public static List<Data.HarvesterRowDistribution> GetHarvesterRowDistribution(long? id, long? Row_Id, long? Harvester_PersonPost_Id,
            Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.HarvesterRowDistribution> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterRowDistributions(context, id, Row_Id, Harvester_PersonPost_Id, inId, outId, outIdFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static bool CheckHarvesterInRowPersonPost( long personpostID, ref string errorMessage)
        {
            bool result = false;
            
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    int selectText = SelectQ.GetHarvesterRowDistributions(context, null, null, personpostID, null, null, true, ref errorMessage).ToList().Count;
                    if (selectText == 0)
                    {
                        result = true;
                    }
                    
                }
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

        public static bool CheckTakeRows(long brgID, ref string errorMessage)
        {
            bool result = false;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    int selectText = SelectQ.GetTakeRows(context, null, null, brgID, null, null, true, ref errorMessage).ToList().Count;
                    if (selectText == 0)
                    {
                        result = true;
                    }

                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.HarvesterContainerDistribution> GetHarvesterContainerDistributions(long? id, string containerBarcode, long? Harvester_PersonPost_Id,
            Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.HarvesterContainerDistribution> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterContainerDistributions(context, id, containerBarcode, Harvester_PersonPost_Id, inId, outId, outIdFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.TakeRowModel> GetRowsWithBrigade(ref string errorMessage)
        {
            List<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRowsWithBrigade(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.TakeRow> GetTakeRows(long? id, long? rowId, long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.TakeRow> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRows(context, id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRow()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.TakeRow> GetTakeRowsByBrigadeId( ref string errorMessage)
        {
            List<Data.TakeRow> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowsByBrigadeId(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTakeRowsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModel(long? brigadeId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowsModel(context,brigadeId,outId, outIdFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.TakeRowModel> GetClosedTakeRowsModel(DateTime? closedTime, DateTime? closedTimeTwo, ref string errorMessage)
        {
            List<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetClosedTakeRowsModel(context, closedTime, closedTimeTwo, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetClosedTakeRowsModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetClosedTakeRowsModel()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.TakeRowModel> GetTakeRowsModelByBrigadeId(ref string errorMessage)
        {
            List<Data.Operation.XClasses.TakeRowModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowsModelByBrigadeId(context,ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsModelByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsModelByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.TakeRow> GetTakeRowForBrigade( long? id, long? rowId,
            long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, ref string errorMessage)
        {
            List<Data.TakeRow> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowForBrigade(context, id, rowId, brigadeId, inId, outId, outIdFiltered, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowForBrigade()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowForBrigade()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ProductOwner> GetProductOwners(long? id, Guid? productId,
            long? companyId, int? status, ref string errorMessage)
        {
            List<Data.ProductOwner> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductOwners(context, id, productId, companyId, status, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetProductOwners()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetProductOwners()\n" + ex.Message;
                }
            }
            return result;
        }


        //public static List<Data.OperationSetting> GetOperationSettings(string key, ref string errorMessage)
        //{
        //    List<Data.OperationSetting> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetOperationSettings(context, key, ref errorMessage);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი:  GetOperationSettings()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი:  GetOperationSettings()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        public static List<XClasses.TakeRowInOut> GetTakeRowsInByPersonPostID( long? id, long? rowId,
           long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            List<XClasses.TakeRowInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowsInByPersonPostID(context, id, rowId, brigadeId, inId, outId, outIdFiltered,userPersonPostId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetTakeRowsInByPersonPostID()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetTakeRowsInByPersonPostID()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<ProductPack> GetContainerForQuality(ref string errorMessage)
        {
            List<Data.ProductPack> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerForQuality(context, ref errorMessage);
                    result = selectText.ToList();
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetContainerForQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  GetContainerForQuality()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.TakeRowInOut> GetTakeRowsOutByPersonPostID(long? id, long? rowId,
          long? brigadeId, Guid? inId, Guid? outId, bool outIdFiltered, long userPersonPostId, ref string errorMessage)
        {
            List<XClasses.TakeRowInOut> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRowsOutByPersonPostID(context, id, rowId, brigadeId, inId, outId, outIdFiltered, userPersonPostId, ref errorMessage);
                    result = selectText.ToList();
                }
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

        //public static IQueryable<XClasses.HarvesterRowDistributionInOut> GetHarvesterRowDistributionIn(BerryManagementEntities context, long userPersonPostId, ref string errorMessage)
        //{
        //    List<XClasses.HarvesterRowDistributionInOut> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetTakeRowsOutByPersonPostID(context, id, rowId, brigadeId, inId, outId, outIdFiltered, userPersonPostId, ref errorMessage);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public static List<Data.OperationSetting> GetOperationSettings(string key, ref string errorMessage)
        {
            List<Data.OperationSetting> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetOperationSettings(context, key, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetOperationSettings()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetOperationSettings()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ProductPack> GetProductPacks(long? id, Guid? productId,
            string containerBarcode, Guid? inId, Guid? outId, bool outIdIsFiltered, ref string errorMessage)
        {
            List<Data.ProductPack> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductPacks(context, id, productId, containerBarcode, inId, outId, outIdIsFiltered, ref errorMessage);
                    result = selectText.ToList();
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

        public static List<Product> GetContainerQuality(Guid Id, ref string errorMessage)
        {
            List<Data.Product> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerQuality(context, Id, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerQuality()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ProductQuality> GetProductQualities(Guid? id, Guid? productId, ref string errorMessage)
        {
            List<Data.ProductQuality> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductQualities(context, id, productId, ref errorMessage);
                    result = selectText.ToList();
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

        //public static List<Data.HarvesterContainerDistribution> GetHarvesterContainerDistributions(long? HarvesterContainerDistribution_Harvester_Person_Id,
        //    ref string errorMessage)
        //{
        //    List<Data.HarvesterContainerDistribution> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetHarvesterContainerDistributions(context, HarvesterContainerDistribution_Harvester_Person_Id);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        public static List<Data.ContainerWeight> GetContainerWeights(
            ref string errorMessage)
        {
            List<Data.ContainerWeight> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerWeights(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerWeights()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainerWeights()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Operation.XClasses.Pallete.PalleteModel> GetContainerWeightsByChars(string barcodeType, DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Operation.XClasses.Pallete.PalleteModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerWeightsByChars(context, barcodeType, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<Data.tf_ProductQualityes_Result> GetTf_ProductQualityes(
                    ref string errorMessage)
        {
            List<Data.tf_ProductQualityes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTf_ProductQualityes(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTf_ProductQualityes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetTf_ProductQualityes()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ProductReceive> GetAllProducts(ref string errorMessage)
        {
            List<Data.ProductReceive> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetAllProducts(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetAllProducts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetAllProducts()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ProductReceive> GetProductReceives(string containerBarcode,ref string errorMessage)
        {
            List<Data.ProductReceive> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductReceives(containerBarcode, context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetProductReceives()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetProductReceives()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.ContainerLocation> CheckContainerLocationForPackaging(string containerBarcode, ref string errorMessage)
        {
            List<Data.ContainerLocation> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.CheckContainerLocationForPackaging(containerBarcode, context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
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

        public static List<Data.Operation.XClasses.ContainerWeightModel> GetWeightsForReport(long PersonPostId, DateTime Time, DateTime Timeplusone, ref string errorMessage)
        {
            List<Data.Operation.XClasses.ContainerWeightModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetWeightsForReport(context, PersonPostId,Time, Timeplusone, ref errorMessage);
                    result = selectText.ToList();
                }
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


        //public static List<Data.TakeRowInOut> GetTakeRowInOuts(ref string errorMessage)
        //{
        //    List<Data.TakeRowInOut> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetTakeRowInOut(context);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        //public static List<Data.HarvesterRowDistributionInOut> GetHarvesterRowDistributionInOuts(ref string errorMessage)
        //{
        //    List<Data.HarvesterRowDistributionInOut> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetHarvesterRowDistributionInOuts(context);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        //public static List<Data.ContainerMoveInOut> GetContainerMoveInOuts(ref string errorMessage)
        //{
        //    List<Data.ContainerMoveInOut> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetContainerMoveInOuts(context);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        //public static List<Classes.HarvesterRowViewModel> GetJoinedHarvesters(ref string errorMessage)
        //{
        //    List<Classes.HarvesterRowViewModel> result = null;
        //    try
        //    {
        //        using (BerryManagementEntities context = new BerryManagementEntities())
        //        {
        //            var selectText = SelectQ.GetJoinedHarvesters(context,ref errorMessage);
        //            result = selectText.ToList();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (System.String.IsNullOrEmpty(errorMessage))
        //        {
        //            errorMessage = "მეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //        else
        //        {
        //            errorMessage = errorMessage + "\nმეთოდი: GetHarvesterContainerDistributions()\n" + ex.Message;
        //        }
        //    }
        //    return result;
        //}

        public static List<Data.Operation.XClasses.PalleteWeight> GetPalleteWeight(string pal_barcode, ref string errorMessage)
        {
            List<Data.Operation.XClasses.PalleteWeight> result = null;
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPalleteWeight(context, pal_barcode, ref errorMessage);

                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n მეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.TakeRows_Harvesters> GetTakeRows_Harvesters(long? brigadeId, ref string errorMessage)
        {
            List<XClasses.TakeRows_Harvesters> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetTakeRows_Harvesters(context, brigadeId, ref errorMessage);

                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetTakeRows_Harvesters()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n მეთოდი: GetTakeRows_Harvesters()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<XClasses.ContainerLocationModel> GetContainersLocationss(long? PointId, ref string errorMessage)
        {
            List<XClasses.ContainerLocationModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersLocationss(context, PointId, ref errorMessage);

                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersLocationss()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n მეთოდი: GetContainersLocationss()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
