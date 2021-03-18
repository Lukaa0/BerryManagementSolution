using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library
{
    public static class SelectQ
    {

        public static IQueryable<Data.Bank> SelectBanks(BerryManagementEntities context, long? bankId , string bankName , string bankKode , ref string errorMessage)
        {
            IQueryable<Data.Bank> result = null;
            try
            {
               
                    result = context.Banks.Where(b => (bankId == null || b.Bank_Id == bankId)
                      && (bankName == null || b.Bank_Name.ToLower().Contains(bankName.ToLower()))
                      && (bankKode == null || b.Bank_Kode == bankKode));
                
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  SelectBank()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  SelectBank()\n" + ex.Message;
                }
            }
            finally { }
            return result;
        }

        public static IQueryable<Data.Container> GetContainerForQuality(BerryManagementEntities context, long pointId, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {

                result = from container in context.Containers.Where(c => c.Container_ContainerType_Id == "CT")
                         join containerlocation in context.ContainerLocations.Where(y=> y.ContainerLocation_Point_Id==pointId) on container.Container_BarCode equals containerlocation.ContainerLocation_Container_BarCode
                         select container;


            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetContainerForQuality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerForQuality()\n" + ex.Message;
                }
            }
           
            return result;
        }

        public static IQueryable<Data.Citizenship> GetCitizenships(BerryManagementEntities context,long? citizenshipId, string citizenshipName, string citizenshipName_EN, ref string errorMessage)
        {
            IQueryable<Data.Citizenship> result = null;
            try
            {
               
                    result = context.Citizenships.Where(c => (citizenshipId == null || c.Citizenship_Id == citizenshipId)
                        && (citizenshipName == null || c.Citizenship_Name.ToLower().Contains(citizenshipName.ToLower()))
                        && (citizenshipName_EN == null || c.Citizenship_NameEn.ToLower().Contains(citizenshipName_EN.ToLower())));
              
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetCitizenships()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetCitizenships()\n" + ex.Message;
                }
            }
            finally { }
            return result;
        }

        public static IQueryable<Data.Container> SelectContainers(BerryManagementEntities context, string barcode, string containerTypeId,
            bool? isActive, ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                result = SelectContainers(context, ref errorMessage);
                if (barcode != null)
                {
                    result = result.Where(c => c.Container_BarCode == barcode);
                }
                if (containerTypeId != null)
                {
                    result = result.Where(c => c.Container_ContainerType_Id == containerTypeId);
                }
                if (isActive != null)
                {
                    result = result.Where(c => c.Container_IsActive == isActive);
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: SelectContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: SelectContainers()\n" + ex.Message;
                }
            }
            finally
            { }
            return result;
        }
        
        public static IQueryable<XClass.ContainerModel> GetContainersByProductPack(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<XClass.ContainerModel> result = null;
            try
            {
                result = from container in context.Containers
                         join productPack in Data.Operation.SelectQ.GetProductPacks(context, null, null, null, null, null, true, ref errorMessage) on container.Container_BarCode equals productPack.ProductPack_Container_BarCode
                         join product in context.Products on productPack.ProductPack_Product_Id equals product.Product_Id
                         join personPost in context.PersonPosts on product.Product_Harvester_PersonPost_Id equals personPost.PersonPost_Id
                         join person in context.Persons on personPost.PersonPost_Person_Id equals person.Person_Id
                         select new XClass.ContainerModel
                         {
                             Container_BarCode=container.Container_BarCode,
                             Container_ContainerType_Id=container.Container_ContainerType_Id,
                             Container_IsActive=container.Container_IsActive,
                             Container_PersonPost_Id=product.Product_Harvester_PersonPost_Id,
                             Container_Harvester_FullName=person.Person_FirstName + " " + person.Person_LastName
                         };
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainersByProductPack()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetContainersByProductPack()\n" + ex.Message;
                }
            }
          
            return result;
        }
        public static IQueryable<Data.Container> SelectContainers(BerryManagementEntities context,  ref string errorMessage)
        {
            IQueryable<Data.Container> result = null;
            try
            {
                result = context.Containers;
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: SelectContainers()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: SelectContainers()\n" + ex.Message;
                }
            }
            finally
            { }            
            return result;
        }

        public static IQueryable<Data.Nationality> GetNationalities(BerryManagementEntities context, long? nationalityId, string nationalityName, string nationalityName_EN  ,ref string errorMessage)
        {
            IQueryable<Data.Nationality> result = null;
            try
            {
                result = context.Nationalities.Where(n => (nationalityId == null || n.Nationality_Id == nationalityId.Value)
                    && (nationalityName == null || n.Nationality_Name == nationalityName)
                    && (nationalityName_EN == null || n.Nationality_NameEn == nationalityName_EN));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  GetNationalities()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetNationalities()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.DocumentType> GetDocumentTypes(BerryManagementEntities context, long? documentTypeId, string documentTypeName,  ref string errorMessage)
        {
            IQueryable<Data.DocumentType> result = null;
            try
            {
                result = context.DocumentTypes.Where(n => (documentTypeId == null || n.DocumentType_Id == documentTypeId.Value)
                    && (documentTypeName == null || n.DocumentType_Name == documentTypeName));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetDocumentTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetDocumentTypes()\n" + ex.Message;
                }
            }
            return result;
        }

       public static IQueryable<Data.LegalForm> GetLegalForms(BerryManagementEntities context, long? LegalFormId, string LegalFormName,string LegalFromName_EN, ref string errorMessage)
        {
            IQueryable<Data.LegalForm> result = null;
            try
            {

                result = context.LegalForms.Where(p => (LegalFormId == null || p.LegalForm_Id == LegalFormId)
                    && (LegalFormName == null || p.LegalForm_Name.ToLower().Contains(LegalFormName.ToLower()))
                    && (LegalFromName_EN == null || p.LegalForm_NameEn.ToLower().Contains(LegalFromName_EN.ToLower())));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetLegalForms()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetLegalForms()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Breed> GetBreeds(BerryManagementEntities context, long? BreedId, string BreedName, ref string errorMessage)
        {
            IQueryable<Data.Breed> result = null;
            try
            {

                result = context.Breeds.Where(p => (BreedId == null || p.Breed_Id == BreedId)
                    && (BreedName == null || p.Breed_Name.ToLower().Contains(BreedName.ToLower())));
                    

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBreeds()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetBreeds()\n" + ex.Message;
                }
            }
            return result;
        }

        #region function
        public static IQueryable<Data.tf_GenderTypes_Result> GetGenderTypes(BerryManagementEntities context, Nullable<bool> GenderTypeId, string GenderTypeName,ref string errorMessage)
        {
            IQueryable<Data.tf_GenderTypes_Result> result = null;
            try
            {

                result = context.tf_GenderTypes().Where(p => (GenderTypeId == null || p.GenderType_Id== GenderTypeId)
                    && (GenderTypeName == null || p.GenderType_Name.ToLower().Contains(GenderTypeName.ToLower())));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetGenderTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetGenderTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_EmployeeTypes_Result> GetEmployeeTypes(BerryManagementEntities context,Nullable<long> EmployeeTypeId, string EmployeeTypeName, ref string errorMessage)
        {
            IQueryable<Data.tf_EmployeeTypes_Result> result = null;
            try
            {

                result = context.tf_EmployeeTypes().Where(p => (EmployeeTypeId == null || p.EmployeeType_Id == EmployeeTypeId)
                    && (EmployeeTypeName == null || p.EmployeeType_Name.ToLower().Contains(EmployeeTypeName.ToLower())));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetEmployeeTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetEmployeeTypes()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.tf_PunishmentTypes_Result> GetPunishmentTypes(BerryManagementEntities context, long? punishmentTypeId, string punishmentTypeName, ref string errorMessage)
        {
            IQueryable<Data.tf_PunishmentTypes_Result> result = null;
            try
            {

                result = context.tf_PunishmentTypes().Where(p => (punishmentTypeId == null || p.PunishmentType_Id == punishmentTypeId)
                    && (punishmentTypeName == null || p.PunishmentType_Name.ToLower().Contains(punishmentTypeName.ToLower())));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPunishmentTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPunishmentTypes()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.tf_GetBalanceSheetTypes_Result> GetBalanceSheetTypes(BerryManagementEntities context,Nullable<long> BalanceSheetTypeId, string BalanceSheetTypeName, ref string errorMessage) { 
            IQueryable<Data.tf_GetBalanceSheetTypes_Result> result = null;
            try
            {

                result = context.tf_GetBalanceSheetTypes().Where(p => (BalanceSheetTypeId == null || p.BalanceSheetType_Id == BalanceSheetTypeId)
                    && (BalanceSheetTypeName == null || p.BalanceSheetType_Name.ToLower().Contains(BalanceSheetTypeName.ToLower())));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBalanceSheetTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetBalanceSheetTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_MaritalStatus_Result> GetMaritalStatus(BerryManagementEntities context, Nullable<long> MaritalStatusId, string MaritalStatusName, ref string errorMessage)
        {
            IQueryable<Data.tf_MaritalStatus_Result> result = null;
            try
            {

                result = context.tf_MaritalStatus().Where(p => (MaritalStatusId == null || p.MaritalStatus_Id == MaritalStatusId)
                    && (MaritalStatusName == null || p.MaritalStatus_Name.ToLower().Contains(MaritalStatusName.ToLower())));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetMaritalStatus()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetMaritalStatus()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_ContainerTypes_Result> GetContainerTypes(BerryManagementEntities context, string ContainerTypeId, string ContainerTypeName, long? ContainerTypeLevel, Nullable<bool> ContainerTypesIsActive,ref string errorMessage)
        {
            IQueryable<Data.tf_ContainerTypes_Result> result = null;
            try
            {

                result = context.tf_ContainerTypes().Where(p => (ContainerTypeId == null || p.ContainerType_Id == ContainerTypeId)
                    && (ContainerTypeName == null || p.ContainerType_Name.ToLower().Contains(ContainerTypeName.ToLower()))
                    && (ContainerTypeLevel == null || p.ContainerType_Level==ContainerTypeLevel)
                    && (ContainerTypesIsActive == null || p.ContainerType_IsActive == ContainerTypesIsActive));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetContainerTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetContainerTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_LegalStatuseTypes_Result> GetLegalStatuseTypes(BerryManagementEntities context, Nullable<long> LegalStatuseTypeId, string LegalStatuseTypeName, string LegalStatuseTypeNameEn, ref string errorMessage)
        {
            IQueryable<Data.tf_LegalStatuseTypes_Result> result = null;
            try
            {

                result = context.tf_LegalStatuseTypes().Where(p => (LegalStatuseTypeId == null || p.LegalStatuseType_Id == LegalStatuseTypeId)
                    && (LegalStatuseTypeName == null || p.LegalStatuseType_Name.ToLower().Contains(LegalStatuseTypeName.ToLower())
                    && (LegalStatuseTypeNameEn == null || p.LegalStatuseType_NameEn.ToLower().Contains(LegalStatuseTypeNameEn.ToLower()))));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetLegalStatuseTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetLegalStatuseTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_PointTypes_Result> GetPointTypes(BerryManagementEntities context, string PointTypeId, string PointTypeName, Nullable<bool> PointTypeIsActive, ref string errorMessage)
        {
            IQueryable<Data.tf_PointTypes_Result> result = null;
            try
            {

                result = context.tf_PointTypes().Where(p => (PointTypeId == null || p.PointType_Id == PointTypeName)
                    && (PointTypeName == null || p.PointType_Name.ToLower().Contains(PointTypeName.ToLower())
                    && (PointTypeIsActive == null || p.PointType_IsActive == PointTypeIsActive)));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPointTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Point> GetAllPoints(BerryManagementEntities context, long? point ,ref string  errorMessage)
        {
            IQueryable<Point> result = null;
            try
            {

                result = context.Points.Where(c=>c.Point_PointType_Id!="LC" && c.Point_PointType_Id != "LA" && (c.Point_Id != point || point == null));

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPointTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetPointTypes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_ProductQualityes_Result> GetProductQualityes(BerryManagementEntities context, Nullable<long> ProductQualityeId, string ProductQualityeName, ref string errorMessage)
        {
            IQueryable<Data.tf_ProductQualityes_Result> result = null;
            try
            {

                result = context.tf_ProductQualityes().Where(p => (ProductQualityeId == null || p.ProductQuality_Id == ProductQualityeId)
                    && (ProductQualityeName == null || p.ProductQuality_Name.ToLower().Contains(ProductQualityeName.ToLower())));
                   

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetProductQualityes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetProductQualityes()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.tf_SalaryTypes_Result> GetSalaryTypes(BerryManagementEntities context, Nullable<long> SalaryTypeId, string SalaryTypeName, ref string errorMessage)
        {
            IQueryable<Data.tf_SalaryTypes_Result> result = null;
            try
            {

                result = context.tf_SalaryTypes().Where(p => (SalaryTypeId == null || p.SalaryType_Id == SalaryTypeId)
                    && (SalaryTypeName == null || p.SalaryType_Name.ToLower().Contains(SalaryTypeName.ToLower())));


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetSalaryTypes()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetSalaryTypes()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.tf_SideTypes_Result> GetSideType(BerryManagementEntities context, Nullable<long> SideTypeId, string SideTypeName, ref string errorMessage)
        {
            IQueryable<Data.tf_SideTypes_Result> result = null;
            try
            {

                result = context.tf_SideTypes().Where(p => (SideTypeId == null || p.SideType_Id == SideTypeId)
                    && (SideTypeName == null || p.SideType_Name.ToLower().Contains(SideTypeName.ToLower())));


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetSideType()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  GetSideType()\n" + ex.Message;
                }
            }
            return result;
        }




        public static IQueryable<Data.Library.XClass.PalleteWeight> GetPalleteWeight(BerryManagementEntities context,string pal_barcode, ref string errorMessage)
        {
            IQueryable<Data.Library.XClass.PalleteWeight> result = null;
            try
            {
                var query = from pack in context.ContainerPacks
                            join weight in context.ContainerWeights on pack.ContainerPack_Container_BarCode equals weight.ContainerWeight_Container_BarCode
                            where (pack.ContainerPack_Parent_Container_BarCode == pal_barcode)
                            group weight by pack.ContainerPack_Parent_Container_BarCode into g
                            select new Data.Library.XClass.PalleteWeight
                            {
                                Pallete_BarCode = g.Key,
                                Pallete_Gross_weight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                Pallete_Net_weight = g.Select(o => o.ContainerWeight_Net).Sum(),

                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPalleteWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Library.XClass.PalleteModel> GetPallete(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<Data.Library.XClass.PalleteModel> result = null;
            try
            {
                var query = from packGroup in SelectQ.GetPalleteWeight(context,null, ref errorMessage) 
                            join pack in context.ContainerPacks on packGroup.Pallete_BarCode equals pack.ContainerPack_Parent_Container_BarCode
                            select new Data.Library.XClass.PalleteModel
                            {
                                Pallete_Date = pack.ContainerPack_DateTime,
                                Pallete_BarCode = packGroup.Pallete_BarCode,
                                Pallete_Gross_weight = packGroup.Pallete_Gross_weight,
                                Pallete_Net_weight = packGroup.Pallete_Net_weight
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetWeightCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetWeightCount()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<string> GetCS(BerryManagementEntities context,string CB, ref string errorMessage)
        {
            IQueryable<string> result = null;
            try
            {
                result = context.ContainerPacks.Where(c => c.ContainerPack_Parent_Container_BarCode.Equals(CB)).Select(r => r.ContainerPack_Container_BarCode);
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetWeightCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetWeightCount()\n" + ex.Message;
                }
            }
            return result;
        }


        #endregion

    }
}
