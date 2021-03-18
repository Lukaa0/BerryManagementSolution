using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Data;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Library_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Library_Service
    {
        #region select

        [OperationContract]
        List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(string CB, int productOwnerStatus, ref string errorMessage);

        [OperationContract]
        List<Data.Library.XClass.PalleteModel> GetPallete(ref string errorMessage);

        [OperationContract]
        List<Data.Library.XClass.PalleteWeight> GetPalleteWeight(string pal_barcode, ref string errorMessage);

        [OperationContract]
        List<Data.Bank> SelectBanks(long? bankId, string bankName, string bankKode , ref string errorMessage);

        [OperationContract]
        List<string> CreateContainers(string containerTypeId, int count, ref string errorMessage);

        [OperationContract]
        List<Data.Library.XClass.ContainerModel> GetContainersByProductPack(ref string errorMessage);

        [OperationContract]
        string CreateContainer(string containerTypeId, ref string errorMessage);

        [OperationContract]
        List<Data.Container> SelectContainers(string barcode, string containerTypeId,
          bool? isActive, ref string errorMessage);
        
        [OperationContract]
        List<Data.Nationality> GetNationalities(long? nationalityId, string nationalityName, string nationalityName_EN, ref string errorMessage);

        [OperationContract]
        List<Data.Citizenship> GetCitizenships(long? citizenshipId, string citizenshipName, string citizenshipName_EN, ref string errorMessage);

        [OperationContract]
        List<Data.Container> GetContainerForQuality(long pointId, ref string errorMessage);

        [OperationContract]
        List<Data.DocumentType> GetDocumentTyped(long? documentTypeId, string documentTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_PunishmentTypes_Result> GetPunishmentTypes(long? punishmentTypeId, string punishmentTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.LegalForm> GetLegalForms(long? LegalFormId, string LegalFormName, string LegalFromName_EN, ref string errorMessage);

        [OperationContract]
        List<Data.tf_GenderTypes_Result> GetGenderTypes(Nullable<bool> GenderTypeId, string GenderTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_EmployeeTypes_Result> GetEmployeeTypes(Nullable<long> EmployeeTypeId, string EmployeeTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_GetBalanceSheetTypes_Result> GetBalanceSheetTypes(Nullable<long> BalanceSheetTypeId, string BalanceSheetTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_MaritalStatus_Result> GetMaritalStatus(Nullable<long> MaritalStatusId, string MaritalStatusName, ref string errorMessage);

        [OperationContract]
        List<Data.Breed> GetBreeds(long? BreedId, string BreedName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_ContainerTypes_Result> GetContainerTypes(string ContainerTypeId, string ContainerTypeName, long? ContainerTypeLevel, Nullable<bool> ContainerTypesIsActive, ref string errorMessage);

        [OperationContract]
        List<Data.tf_LegalStatuseTypes_Result> GetLegalStatuseTypes(Nullable<long> LegalStatuseTypeId, string LegalStatuseTypeName, string LegalStatuseTypeNameEn, ref string errorMessage);

        [OperationContract]
        List<Data.tf_PointTypes_Result> GetPointTypes(string PointTypeId, string PointTypeName, Nullable<bool> PointTypeIsActive, ref string errorMessage);

        [OperationContract]
        List<Data.tf_ProductQualityes_Result> GetProductQualityes(Nullable<long> ProductQualityeId, string ProductQualityeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_SalaryTypes_Result> GetSalaryTypes(Nullable<long> SalaryTypeId, string SalaryTypeName, ref string errorMessage);

        [OperationContract]
        List<Data.tf_SideTypes_Result> GetSideTypes(Nullable<long> SideTypeId, string SideTypeName, ref string errorMessage);

        [OperationContract]
        List<Point> GetAllPoints(long? pointId,ref string errorMessage);
        #endregion select

        #region insert
        [OperationContract]
        long InsertBank(Data.Bank bank, ref string errorMessage);

        [OperationContract]
        long InsertNationality(Data.Nationality nationality, ref string errorMessage);

        [OperationContract]
        long InsertCitizenship(Data.Citizenship citizenship, ref string errorMessage);

        [OperationContract]
        long InsertDocumentType(Data.DocumentType documentType, ref string errorMessage);

        //[OperationContract]
        //long InsertPunishmentType(Data.PunishmentType punishmentType, ref string errorMessage);

        [OperationContract]
        long InsertLegalForm(Data.LegalForm legalForm, ref string errorMessage);

        [OperationContract]
        long InsertBreed(Data.Breed breed, ref string errorMessage);

        #endregion insert

        #region update
        [OperationContract]
        void UpdateBank(Data.Bank bank,ref string errorMessage);

        [OperationContract]
        void UpdateNationality(Data.Nationality nationality, ref string errorMessage);

        [OperationContract]
        void UpdateCitizenship(Data.Citizenship citizenship, ref string errorMessage);

        [OperationContract]
        void UpdateDocumentType(Data.DocumentType document, ref string errorMessage);

        //[OperationContract]
        //void UpdatePunishmentType(Data.PunishmentType punishmentType, ref string errorMessage);

        [OperationContract]
        void UpdateLegalForm(Data.LegalForm legalForm, ref string errorMessage);

        [OperationContract]
        void UpdateBreed(Data.Breed breed, ref string errorMessage);
        #endregion update
    }
}
