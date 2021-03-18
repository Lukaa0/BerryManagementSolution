using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library
{
    public static class SelectL
    {
        public static List<Data.Bank> SelectBanks(long? bankId, string bankName, string bankKode, ref string errorMessage)
        {
            List<Data.Bank> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectBanks(context, bankId, bankName, bankKode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.Container> GetContainerForQuality( long pointId, ref string errorMessage)
        {
            List<Data.Container> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerForQuality(context, pointId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }
        public static List<Data.Nationality> GetNationalities(long? nationalityId, string nationalityName, string nationalityName_EN , ref string errorMessage)
        {
            List<Data.Nationality> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetNationalities(context,nationalityId, nationalityName, nationalityName_EN, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.Citizenship> GetCitizenships(long? citizenshipId, string citizenshipName, string citizenshipName_EN, ref string errorMessage)
        {
            List<Data.Citizenship> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetCitizenships(context, citizenshipId,citizenshipName,citizenshipName_EN, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;

        }

        public static List<Data.DocumentType> GetDocumentTypes(long? documentTypeId, string documentTypeName, ref string errorMessage)
        {
            List<Data.DocumentType> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetDocumentTypes(context, documentTypeId, documentTypeName , ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;

        }

        public static List<Data.tf_PunishmentTypes_Result> GetPunishmentTypes( long? punishmentTypeId, string punishmentTypeName, ref string errorMessage)
        {
            List<Data.tf_PunishmentTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPunishmentTypes(context, punishmentTypeId, punishmentTypeName, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.Breed> GetBreeds(long? BreedId, string BreedName, ref string errorMessage)
        {
            List<Data.Breed> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetBreeds(context, BreedId, BreedName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }
        public static List<XClass.ContainerModel> GetContainersByProductPack( ref string errorMessage)
        {
            List<XClass.ContainerModel> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainersByProductPack(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }

            return result;
        }

        public static List<Data.Container> SelectContainers( string barcode, string containerTypeId,
           bool? isActive, ref string errorMessage)
        {
            List<Data.Container> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.SelectContainers(context, barcode, containerTypeId, isActive,ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }

            return result;
        }

            public static List<Data.LegalForm> GetLegalForms( long? LegalFormId, string LegalFormName, string LegalFromName_EN, ref string errorMessage)
        {
            List<Data.LegalForm> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetLegalForms(context, LegalFormId, LegalFormName, LegalFromName_EN, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }

            return result;
        }

        public static List<Data.Library.XClass.PalleteModel> GetPallete(ref string errorMessage)
        {
            List<Data.Library.XClass.PalleteModel> result = null;
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPallete(context, ref errorMessage).Distinct();

                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPallete()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n მეთოდი: GetPallete()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Library.XClass.PalleteWeight> GetPalleteWeight(string pal_barcode, ref string errorMessage)
        {
            List<Data.Library.XClass.PalleteWeight> result = null;
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

        public static List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(string CB, int productOwnerStatus,
             DateTime? maxDateTime, ref string errorMessage)
        {
            List< Data.RS.XClasses.RS_ProductModel> result = null;
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var cont = SelectQ.GetCS(context, CB, ref errorMessage).ToList();
                    var selectText = Data.RS.SelectQ.GetRS_ProductModelByContainers(context, cont, productOwnerStatus, maxDateTime, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRS_ProductModelByContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRS_ProductModelByContainers()\n" + ex.Message;
                }
            }
            return result;
        }

        #region function
        public static List<Data.tf_GenderTypes_Result> GetGenderTypes( Nullable<bool> GenderTypeId, string GenderTypeName, ref string errorMessage)
        {
            List<Data.tf_GenderTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetGenderTypes(context, GenderTypeId,GenderTypeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_EmployeeTypes_Result> GetEmployeeTypes(Nullable<long> EmployeeTypeId, string EmployeeTypeName, ref string errorMessage)
        {
            List<Data.tf_EmployeeTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetEmployeeTypes(context, EmployeeTypeId, EmployeeTypeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_GetBalanceSheetTypes_Result> GetBalanceSheetTypes(Nullable<long> BalanceSheetTypeId, string BalanceSheetTypeName, ref string errorMessage)
        {
            List<Data.tf_GetBalanceSheetTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetBalanceSheetTypes(context, BalanceSheetTypeId, BalanceSheetTypeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_MaritalStatus_Result> GetMaritalStatus(Nullable<long> MaritalStatusId, string MaritalStatusName, ref string errorMessage)
        {
            List<Data.tf_MaritalStatus_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetMaritalStatus(context, MaritalStatusId, MaritalStatusName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_ContainerTypes_Result> GetContainerTypes(string ContainerTypeId, string ContainerTypeName, long? ContainerTypeLevel, Nullable<bool> ContainerTypesIsActive, ref string errorMessage)
        {
            List<Data.tf_ContainerTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetContainerTypes(context, ContainerTypeId, ContainerTypeName, ContainerTypeLevel, ContainerTypesIsActive, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_LegalStatuseTypes_Result> GetLegalStatuseTypes( Nullable<long> LegalStatuseTypeId, string LegalStatuseTypeName, string LegalStatuseTypeNameEn, ref string errorMessage)
        {
            List<Data.tf_LegalStatuseTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetLegalStatuseTypes(context, LegalStatuseTypeId, LegalStatuseTypeName,LegalStatuseTypeNameEn, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_PointTypes_Result> GetPointTypes(string PointTypeId, string PointTypeName, Nullable<bool> PointTypeIsActive, ref string errorMessage)
        {
            List<Data.tf_PointTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPointTypes(context, PointTypeId, PointTypeName, PointTypeIsActive, ref errorMessage);
                    result = selectText.ToList();
                    
                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Point> GetAllPoints(long? pointId,ref string errorMessage)
        {
            List<Point> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetAllPoints(context,pointId,ref errorMessage).Where(x=>x.Point_IsActive==true);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_ProductQualityes_Result> GetProductQualityes( Nullable<long> ProductQualityeId, string ProductQualityeName, ref string errorMessage)
        {
            List<Data.tf_ProductQualityes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetProductQualityes(context, ProductQualityeId, ProductQualityeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_SalaryTypes_Result> GetSalaryTypes( Nullable<long> SalaryTypeId, string SalaryTypeName, ref string errorMessage)
        {
            List<Data.tf_SalaryTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetSalaryTypes(context, SalaryTypeId, SalaryTypeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }

        public static List<Data.tf_SideTypes_Result> GetSideTypes(Nullable<long> SideTypeId, string SideTypeName, ref string errorMessage)
        {
            List<Data.tf_SideTypes_Result> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetSideType(context, SideTypeId, SideTypeName, ref errorMessage);
                    result = selectText.ToList();

                }

            }
            catch (Exception ex)
            {

                throw new Exception("ინფორმაციის ამოღება ვერ მოხერხდა:\n" + ex.Message);
            }
            return result;
        }
        #endregion function
    }
}
