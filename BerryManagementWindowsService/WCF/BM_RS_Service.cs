using BerryManagementWindowsService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_RS_Service" in both code and config file together.
    public class BM_RS_Service : IBM_RS_Service
    {
        #region Select

        public List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillGoods(TransportWaybill transportWaybill, long personPostId,
    int productOwnerStatus, bool isCheck, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybillGoods(transportWaybill, personPostId, productOwnerStatus, isCheck, ref errorMessage);

        }

        public List<Data.TransportWaybill> GetTransportWaybills(long? id, int? typeId, long? carPointId, long? carId, long? companyId,
            long? startPointId, bool startPointIdFiltered, long? destinationPointId, bool destinationPointIdFiltered,
             long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybills(id, typeId, carPointId, carId, companyId, startPointId, startPointIdFiltered, 
                destinationPointId, destinationPointIdFiltered, rSId, rSIdFiltered, rSNumber, rSNumberFiltered, ref errorMessage);
        }

        public List<Data.RS.Model.TransportWaybillModel> GetTransportWaybillModel(DateTime? StartDay, DateTime? EndDay, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybillModel(StartDay,EndDay, ref errorMessage);
        }
        public List<Data.RS.Model.NonTransportWaybillModel> GetNonTransportWaybillModel(long? transportWaibylId, ref string errorMessage)
        {
            return Data.RS.SelectL.GetNonTransportWaybillModel(transportWaibylId, ref errorMessage);
        }

        public List<Data.RS.XClasses.RS_ProductModel> GetTransportWaybillWeight(long CompanyId, int productOwnerStatus, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybillWeight(CompanyId, productOwnerStatus, null, ref errorMessage);
        }

        public List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetTransportWaybillDetailsProduct(long? transportWaybillId, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybillDetailsProduct(transportWaybillId, ref errorMessage);
        }

        public List<Data.RS.XClasses.WaybillContainer.WAYBILL.GOODS> GetNonTransportWaybillDetailsProduct(long? NonTransportWaybillId, ref string errorMessage)
        {
            return Data.RS.SelectL.GetNonTransportWaybillDetailsProduct(NonTransportWaybillId, ref errorMessage);
        }


        public List<Data.TransportWaybillDetail> GetTransportWaybillDetails(long? transportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            return Data.RS.SelectL.GetTransportWaybillDetails(transportWaybillId, waybillStatus, state, ref errorMessage);
        }

        public List<Data.NonTransportWaybill> GetNonTransportWaybills(long? id, int? typeId, long? transportWaybillId,
            long? companySelerId, long? companyBuyer_Id, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        {
            return Data.RS.SelectL.GetNonTransportWaybills(id, typeId, transportWaybillId, companySelerId, companyBuyer_Id, rSId, rSIdFiltered,
                        rSNumber, rSNumberFiltered, ref errorMessage);
        }

        public List<Data.NonTransportWaybillDetail> GetNonTransportWaybillDetails(long? nonTransportWaybillId,
            int? waybillStatus, int? state, ref string errorMessage)
        {
            return Data.RS.SelectL.GetNonTransportWaybillDetails(nonTransportWaybillId, waybillStatus, state, ref errorMessage);
        }

        //public  List<Data.RS.XClasses.TransportWaybillModel> GetTransportWayBillModels(long? id, int? typeId, long? carPointId,
        //   long? companyId, long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //{
        //    return Data.RS.SelectL.GetTransportWayBillModels(id, typeId, carPointId, companyId, rSId, rSIdFiltered, rSNumber, rSNumberFiltered, ref errorMessage);
        //}
        //public  List<Data.RS.XClasses.NonTransportWaybillModel> GetNonTransportWayBillModels(long? id, int? typeId, long? transportWaybillId,
        //    long? rSId, bool rSIdFiltered, string rSNumber, bool rSNumberFiltered, ref string errorMessage)
        //{
        //    return Data.RS.SelectL.GetNonTransportWayBillModels(id, typeId, transportWaybillId, rSId, rSIdFiltered, rSNumber, rSNumberFiltered, ref errorMessage);
        //}
            
        #endregion Select

          
           
        #region Insert

        public long InsertTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage)
        {
            return Data.RS.Insert.InsertTransportWaybill(transportWaybill, ref errorMessage);
        }
        public Data.TransportWaybill InsertTransportWaybillCompanyMove(string barCode, bool direction, ref string errorMessage)
        {
            return Data.RS.Insert.InsertTransportWaybillCompanyMove(barCode, direction, ref errorMessage);
        }
        public long InsertTransportWaybillDetail(TransportWaybillDetail transportWaybillDetail, ref string errorMessage)
        {
            return Data.RS.Insert.InsertTransportWaybillDetail(transportWaybillDetail, ref errorMessage);
        }

        public long InsertNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage)
        {
            return Data.RS.Insert.InsertNonTransportWaybill(nonTransportWaybill, ref errorMessage);
        }

        public long InsertNonTransportWaybillDetail(NonTransportWaybillDetail nonTransportWaybillDetail, ref string errorMessage)
        {
            return Data.RS.Insert.InsertNonTransportWaybillDetail(nonTransportWaybillDetail, ref errorMessage);
        }

        #endregion

        #region Update

        public void UpdateTransportWaybill(TransportWaybill transportWaybill, ref string errorMessage)
        {
            Data.RS.Update.UpdateTransportWaybill(transportWaybill, ref errorMessage);
        }

        public void UpdateNonTransportWaybill(NonTransportWaybill nonTransportWaybill, ref string errorMessage)
        {
            Data.RS.Update.UpdateNonTransportWaybill(nonTransportWaybill, ref errorMessage);
        }

        #endregion Update
    }
}
