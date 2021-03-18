using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BerryManagementWindowsService.Data;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Library_Service" in both code and config file together.
    public class BM_Library_Service : IBM_Library_Service
    {
        #region operation
        public List<string> CreateContainers(string containerTypeId, int count, ref string errorMessage)
        {
            return Data.Library.XClass.ContainerBarCodeGenerator.CreateContainers(containerTypeId, count, ref errorMessage);
        }

        public string CreateContainer(string containerTypeId, ref string errorMessage)
        {
            return Data.Library.XClass.ContainerBarCodeGenerator.CreateContainer(containerTypeId, ref errorMessage);
        }
        #endregion operation

        #region select

        public List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(string CB, int productOwnerStatus, ref string errorMessage)
        {
            return Data.Library.SelectL.GetRS_ProductModelByContainers(CB, productOwnerStatus, null, ref errorMessage);
        }

        public List<Data.Library.XClass.PalleteModel> GetPallete(ref string errorMessage)
        {
            return Data.Library.SelectL.GetPallete(ref errorMessage);
        }

        public List<Data.Library.XClass.PalleteWeight> GetPalleteWeight(string pal_barcode, ref string errorMessage)
        {
            return Data.Library.SelectL.GetPalleteWeight(pal_barcode,ref errorMessage);
        }

        public List<Data.Container> SelectContainers(string barcode, string containerTypeId,
           bool? isActive, ref string errorMessage)
        {
            return Data.Library.SelectL.SelectContainers(barcode, containerTypeId, isActive, ref errorMessage);
        }

        public List<Data.Bank> SelectBanks(long? bankId, string bankName, string bankKode,ref string errorMessage)
        {
            return Data.Library.SelectL.SelectBanks(bankId, bankName, bankKode, ref errorMessage);
        }

        public  List<Data.Container> GetContainerForQuality(long pointId, ref string errorMessage)
        {
            return Data.Library.SelectL.GetContainerForQuality(pointId, ref errorMessage);
        }

        public List<Data.Citizenship> GetCitizenships(long? citizenshipId, string citizenshipName, string citizenshipName_EN, ref string errorMessage)
        {
            return Data.Library.SelectL.GetCitizenships(citizenshipId, citizenshipName, citizenshipName_EN, ref errorMessage);
        }

        public  List<Data.Nationality> GetNationalities(long? nationalityId, string nationalityName, string nationalityName_EN , ref string errorMessage)
        {
            return Data.Library.SelectL.GetNationalities(nationalityId, nationalityName, nationalityName_EN, ref errorMessage);
        }

        public List<Data.DocumentType> GetDocumentTyped(long? documentTypeId, string documentTypeName,  ref string errorMessage)
        {
            return Data.Library.SelectL.GetDocumentTypes(documentTypeId, documentTypeName, ref errorMessage);
        }

        public List<Data.tf_PunishmentTypes_Result> GetPunishmentTypes(long? punishmentTypeId, string punishmentTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetPunishmentTypes(punishmentTypeId, punishmentTypeName, ref errorMessage);
        }

        public List<Data.LegalForm> GetLegalForms(long? LegalFormId, string LegalFormName, string LegalFromName_EN, ref string errorMessage)
        {
            return Data.Library.SelectL.GetLegalForms(LegalFormId, LegalFormName, LegalFromName_EN, ref errorMessage);
        }

        public  List<Data.Library.XClass.ContainerModel> GetContainersByProductPack(ref string errorMessage)
        {
            return Data.Library.SelectL.GetContainersByProductPack(ref errorMessage);
        }

            public List<Data.tf_GenderTypes_Result> GetGenderTypes(Nullable<bool> GenderTypeId, string GenderTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetGenderTypes(GenderTypeId, GenderTypeName, ref errorMessage);
        }

        public List<Data.tf_EmployeeTypes_Result> GetEmployeeTypes(Nullable<long> EmployeeTypeId, string EmployeeTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetEmployeeTypes(EmployeeTypeId, EmployeeTypeName, ref errorMessage);
        }

        public List<Data.tf_GetBalanceSheetTypes_Result> GetBalanceSheetTypes(Nullable<long> BalanceSheetTypeId, string BalanceSheetTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetBalanceSheetTypes(BalanceSheetTypeId, BalanceSheetTypeName, ref errorMessage);
        }

        public List<Data.tf_MaritalStatus_Result> GetMaritalStatus(Nullable<long> MaritalStatusId, string MaritalStatusName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetMaritalStatus(MaritalStatusId, MaritalStatusName, ref errorMessage);
        }

        public List<Data.Breed> GetBreeds(long? BreedId, string BreedName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetBreeds(BreedId, BreedName, ref errorMessage);
        }

        public List<Data.tf_ContainerTypes_Result> GetContainerTypes( string ContainerTypeId, string ContainerTypeName, long? ContainerTypeLevel, Nullable<bool> ContainerTypesIsActive, ref string errorMessage)
        {
            return Data.Library.SelectL.GetContainerTypes(ContainerTypeId, ContainerTypeName, ContainerTypeLevel, ContainerTypesIsActive, ref errorMessage);
        }

        public List<Data.tf_LegalStatuseTypes_Result> GetLegalStatuseTypes(Nullable<long> LegalStatuseTypeId, string LegalStatuseTypeName, string LegalStatuseTypeNameEn, ref string errorMessage)
        {
            return Data.Library.SelectL.GetLegalStatuseTypes(LegalStatuseTypeId, LegalStatuseTypeName, LegalStatuseTypeNameEn, ref errorMessage);
        }

        public List<Data.tf_PointTypes_Result> GetPointTypes(string PointTypeId, string PointTypeName, Nullable<bool> PointTypeIsActive, ref string errorMessage)
        {
            return Data.Library.SelectL.GetPointTypes(PointTypeId, PointTypeName, PointTypeIsActive, ref errorMessage);
        }

        public List<Point> GetAllPoints(long? pointId,ref string errorMessage)
        {
            return Data.Library.SelectL.GetAllPoints(pointId,ref errorMessage);
        }

        public List<Data.tf_ProductQualityes_Result> GetProductQualityes(Nullable<long> ProductQualityeId, string ProductQualityeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetProductQualityes(ProductQualityeId, ProductQualityeName, ref errorMessage);
        }

        public List<Data.tf_SalaryTypes_Result> GetSalaryTypes(Nullable<long> SalaryTypeId, string SalaryTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetSalaryTypes(SalaryTypeId, SalaryTypeName, ref errorMessage);
        }

        public List<Data.tf_SideTypes_Result> GetSideTypes(Nullable<long> SideTypeId, string SideTypeName, ref string errorMessage)
        {
            return Data.Library.SelectL.GetSideTypes(SideTypeId, SideTypeName, ref errorMessage);
        }
        #endregion select

        #region insert

        public long InsertBank(Data.Bank bank, ref string errorMessage)
        {
            return Data.Library.Insert.InsertBank(bank,ref errorMessage);
        }

        public long InsertNationality(Data.Nationality nationality , ref string errorMessage)
        {
            return Data.Library.Insert.InsertNationality(nationality, ref errorMessage );
        }

        public long InsertCitizenship(Data.Citizenship citizenship , ref string errorMessage)
        {
            return Data.Library.Insert.InsertCitizenship(citizenship, ref errorMessage);
        }

        public long InsertDocumentType(Data.DocumentType documentType, ref string errorMessage)
        {
            return Data.Library.Insert.InsertDocumentType(documentType, ref errorMessage);
        }

        //public long InsertPunishmentType(Data.PunishmentType punishmentType, ref string errorMessage)
        //{
        //    return Data.Library.Insert.InsertPunishmentType(punishmentType, ref errorMessage);
        //}

        public long InsertLegalForm(Data.LegalForm legalForm, ref string errorMessage)
        {
            return Data.Library.Insert.InsertLegalForm(legalForm, ref errorMessage);
        }

        public long InsertBreed(Data.Breed breed, ref string errorMessage)
        {
            return Data.Library.Insert.InsertBreed(breed, ref errorMessage);
        }

        #endregion

        #region update
        public void UpdateBank(Data.Bank bank, ref string errorMessage)
        {
            Data.Library.Update.UpdateBank(bank, ref errorMessage);
        }

        public void UpdateNationality(Data.Nationality nationality, ref string errorMessage)
        {
            Data.Library.Update.UpdateNationality(nationality,ref errorMessage);
        }

        public void UpdateCitizenship(Data.Citizenship citizenship, ref string errorMessage)
        {
            Data.Library.Update.UpdateCitizenship(citizenship, ref errorMessage);
        }

        public void UpdateDocumentType(Data.DocumentType document, ref string errorMessage)
        {
            Data.Library.Update.UpdateDocumentType(document, ref errorMessage);
        }
    
        //public void UpdatePunishmentType(Data.PunishmentType punishmentType, ref string errorMessage)
        //{
        //    Data.Library.Update.UpdatePunishmentType(punishmentType,ref errorMessage);
        //}

        public void UpdateLegalForm(Data.LegalForm legalForm, ref string errorMessage)
        {
            Data.Library.Update.UpdateLegalForm(legalForm, ref errorMessage);
        }

        public void UpdateBreed(Data.Breed breed, ref string errorMessage)
        {
            Data.Library.Update.UpdateBreed(breed, ref errorMessage);
        }


        #endregion


        
        }
}
