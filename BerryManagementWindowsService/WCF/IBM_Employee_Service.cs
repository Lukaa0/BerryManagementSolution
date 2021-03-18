using BerryManagementWindowsService.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Employee_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Employee_Service
    {
        [OperationContract]
        int GetNumberOfEmployeeSameIdentities(string inEmployeeIdentity, ref String errorMessage);

        [OperationContract]
        List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(DateTime Start, DateTime End, int productOwnerStatus, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetGivenPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetRecomPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.PunishmentCountModel> GetPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetBrigadeWeight(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.GeneralReportModel> GetGeneralReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.ReportModel> GetBrigadireReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.ReportModel> GetPackagerReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.ReportModel> GetControliorReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.ReportModel> GetRecieverReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.ReportModel.ReportModel> GetHarvesterReport(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        byte[] GetHarvesterReportWhole(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        byte[] GetBrigadireReportWhole(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        byte[] GetPackagerReportWhole(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        byte[] GetRecieverReportWhole(DateTime? start, DateTime? end, ref string errorMessage);

        [OperationContract]
        byte[] GetControliorReportWhole(DateTime? start, DateTime? end, ref string errorMessage);


        #region AndroidApp
        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetHarvByHarvRowDistrOuts(bool Direction, long? brigadeId, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetHarvesterByHRDForPunishment(ref string errorMessage);
        #endregion

        [OperationContract]
        void DeletePerson(Data.Person inEmployee, long inUserId, ref String errorMessage);

        [OperationContract]
        string GetEmployeeCurrentName(long inEmployeeId, ref String errorMessage);

        [OperationContract]
        void UpdateEmployee(Data.Person Employee, long PersonId, ref String errorMessage);

        [OperationContract]
        void InsertEmployee(ref Data.Person Employee, ref String errorMessage);

        [OperationContract]
        List<Data.PersonPost> GetPersonPostsIdByPersonId(long personID, ref string errorMessage);

        [OperationContract]
        List<Data.Person> GetEmployeeShortData(long? EmployeeId, string EmployeeIdentity, string FirstName, string LastName, long? code,long? postId,bool isFirstUse, ref String errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.PersonDocumentModel> GetPersonDocuments(System.Nullable<long> PersonDocumentId,
                                                       System.Nullable<long> userId,
                                                       string userName,
                                                       System.Nullable<long> PersonDocumentEmployeeId,
                                                       System.Nullable<long> inrsonDocumentDocumentTypeId,
                                                       System.Nullable<long> PersonDocumentCitizenshipId,
                                                       System.Nullable<DateTime> PersonDocumentStartDate,
                                                       System.Nullable<DateTime> PersonDocumentEndDate,
                                                       ref string errorMessage);
        [OperationContract]
        void UpdatePersonDocument(Data.PersonDocument PersonDocument, ref string inoutErrorMessage);
        [OperationContract]
        void DeletePersonDocument(Data.PersonDocument PersonDocument, ref string ErrorMessage);
        [OperationContract]
        void InsertPersonDocument(ref PersonDocument PersonDocument, ref string ErrorMessage);
        [OperationContract]
        List<Data.PersonPost> GetPersonPostData(long? personPost_Id, long? Person_Id, long? Post_Id, string employeeBarCode, ref String errorMessage);
        [OperationContract]
        void InsertPersonPost(ref PersonPost personPost, ref string ErrorMessage);
        [OperationContract]
        void DeletePersonPost(PersonPost personPost, long person_Id, ref String errorMessage);
        [OperationContract]
        void UpdatePersonPost(PersonPost personPost, long PersonId, ref String errorMessage);
        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModel(
                                              System.Nullable<long> PersonPost_PersonId,
                                              ref string errorMessage);
        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModelForRows(
                                              System.Nullable<long> BrigadeId,
                                              ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetPersonPostByPostId(long PostId, ref String errorMessage);


        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsByBrigadeId(long? brigadeId, ref String errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsForPunishment(ref String errorMessage);


        [OperationContract]
        List<Data.Person> GetEmployeeData(string EmployeeIdentity, ref String errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.EmployeeLabel> GetEmployeeLabels(List<long> employeePostIds, ref string errorMessage);

        [OperationContract]
        List<Data.Post> GetPostById(long? postId, ref string errorMessage);

        [OperationContract]
        List<Data.PersonPost> GetPersonPostByBarCode(string harvesterCode, ref string errorMessage);

        [OperationContract]
        List<Data.Employees.XClasses.PersonPostModel> GetHarvByHarvRowDistrOutsByRowId(bool Direction, long? brigadeId, long? rowId, ref string errorMessage);



        #region punishment

        [OperationContract]
        List<Data.Employees.XClasses.PunishmentModel> GetPunishment(long? personID, long? userPersonPostId, ref string errorMessage);
        [OperationContract]
        List<Data.Employees.XClasses.PunishmentModel> GetPunishmentByDite(long? personID, DateTime start, DateTime end, ref string errorMessage);

        [OperationContract]
        void UpdatePunishment(Punishment punishment, ref String errorMessage);

        [OperationContract]
        void InsertPunishment(Punishment punishment, ref string ErrorMessage);

        [OperationContract]
        void InsertPunishmentForAndroid(Punishment punishment, string barcode, ref string ErrorMessage);


        #endregion

    }
}
