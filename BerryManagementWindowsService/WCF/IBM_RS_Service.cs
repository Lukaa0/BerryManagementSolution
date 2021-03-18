using BerryManagementWindowsService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_RS_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_RS_Service
    {
        #region Select

        [OperationContract]
        List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillGoods(TransportWaybill transportWaybill, long personPostId,
        int productOwnerStatus, bool isCheck, ref string errorMessage);

        [OperationContract]
        List<Data.TransportWaybill> GetTransportWaybills(long? id, int? typeId, long? carPointId, long? carId, long? companyId,
            long? startPointId, bool startPointIdFiltered, long? destinationPointId, bool destinationPointIdFiltered,
             long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage);

        [OperationContract]
        List<Data.RS.Model.TransportWaybillModel> GetTransportWaybillModel(DateTime? StartDay, DateTime? EndDay, ref string errorMessage);

        [OperationContract]
        List<Data.RS.Model.NonTransportWaybillModel> GetNonTransportWaybillModel(long? transportWaibylId, ref string errorMessage);

        [OperationContract]
        List<Data.RS.XClasses.RS_ProductModel> GetTransportWaybillWeight(long CompanyId, int productOwnerStatus, ref string errorMessage);


        //[OperationContract]
        //List<Data.RS.XClasses.NonTransportWaybillModel> GetNonTransportWayBillModels(long? id, int? typeId, long? transportWaybillId,
        //    long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage);

        //[OperationContract]
        //List<Data.RS.XClasses.TransportWaybillModel> GetTransportWayBillModels(long? id, int? typeId, long? carPointId,
        //   long? companyId, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage);

        [OperationContract]
        List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillDetailsProduct(long? transportWaybillId, ref string errorMessage);

        [OperationContract]
        List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetNonTransportWaybillDetailsProduct(long? NonTransportWaybillId, ref string errorMessage);

        List<Data.TransportWaybillDetail> GetTransportWaybillDetails(long? transportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage);

        List<Data.NonTransportWaybill> GetNonTransportWaybills(long? id, int? typeId, long? transportWaybillId,
            long? companySelerId, long? companyBuyer_Id, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage);

        List<Data.NonTransportWaybillDetail> GetNonTransportWaybillDetails(long? nonTransportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage);

        #endregion Select

        #region Insert

        [OperationContract]
        long InsertTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage);

        [OperationContract]
        long InsertTransportWaybillDetail(TransportWaybillDetail transportWaybillDetail, ref string errorMessage);

        [OperationContract]
        long InsertNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage);

        [OperationContract]
        long InsertNonTransportWaybillDetail(NonTransportWaybillDetail nonTransportWaybillDetail, ref string errorMessage);

        [OperationContract]
        Data.TransportWaybill InsertTransportWaybillCompanyMove(string barCode, bool direction, ref string errorMessage);

        #endregion

        #region Update

        void UpdateTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage);

        void UpdateNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage);

        #endregion Update
    }
}
