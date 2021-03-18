using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees
{
    public static class SelectQ
    {
        public static IQueryable<Data.Person> GetNumberOfEmployeeSameIdentities(BerryManagementEntities context, string inEmployeeIdentity)
        {
            IQueryable<Data.Person> result = null;
            result = context.Persons;
            result = result.Where(e => e.Person_Identity == inEmployeeIdentity);

            return result;
        }

        public static IEnumerable<Data.Person> GetEmployeeShortData(BerryManagementEntities context, long? EmployeeId,
                                                                          string EmployeeIdentity, string FirstName, string LastName, long? code, long? postId, ref string errorMessage)
        {

            IEnumerable<Data.Person> result = null;
            result = context.Persons.Where(e =>
                                           (EmployeeId == null || EmployeeId == 0 || e.Person_Id == EmployeeId.Value)
                                          && (EmployeeIdentity == null || e.Person_Identity == EmployeeIdentity)
                                          && (FirstName == null || e.Person_FirstName == FirstName)
                                          && (LastName == null || e.Person_LastName == LastName)
                                          && (code == null || e.Person_Code == code));


            //result = from p in context.Persons
            //         join pp in context.PersonPosts on p.Person_Id equals pp.PersonPost_Person_Id
            //         join post in context.Posts on pp.PersonPost_Post_Id equals post.Post_Id
            //         where (EmployeeId == null || EmployeeId == 0 || p.Person_Id == EmployeeId.Value)
            //                                       && (EmployeeIdentity == null || p.Person_Identity == EmployeeIdentity)
            //                                       && (FirstName == null || p.Person_FirstName.Contains(FirstName))
            //                                       && (LastName == null || p.Person_LastName.Contains(LastName))
            //                                       && (code == null || p.Person_Code == code)
            //                                       && (postId == null || post.Post_Id == postId)


            //         select new Data.Person
            //         {
            //           Person_Address1 = p.Person_Address1,
            //           Person_Address2 = p.Person_Address2,
            //           Person_BankAccount = p.Person_BankAccount,
            //           Person_BankClientName = p.Person_BankClientName,
            //           Person_Bank_Id = p.Person_Bank_Id,
            //           Person_BirthDate = p.Person_BirthDate,
            //           Person_Citizenship_Id = p.Person_Citizenship_Id,
            //           Person_Code = p.Person_Code,
            //           Person_Description = p.Person_Description,
            //           Person_DrivingLicense = p.Person_DrivingLicense,
            //           Person_FirstName = p.Person_FirstName,
            //           Person_GenderType_Id = p.Person_GenderType_Id,
            //           Person_Id = p.Person_Id,
            //           Person_Identity = p.Person_Identity,
            //           Person_IsResident = p.Person_IsResident,
            //           Person_LastName = p.Person_LastName,
            //           Person_LegalForm_Id = p.Person_LegalForm_Id,
            //           Person_LegalStatuseType_Id = p.Person_LegalStatuseType_Id,
            //           Person_MailAddress = p.Person_MailAddress,
            //           Person_MaritalStatus_Id = p.Person_MaritalStatus_Id,
            //           Person_Nationality_Id = p.Person_Nationality_Id,
            //           Person_Phone1 = p.Person_Phone1,
            //           Person_Phone2 = p.Person_Phone2,
            //           Person_SideType_Id = p.Person_SideType_Id,
            //           Post_Name = post.Post_Name

            //         };



            try
            {

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetEmployeeShortData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetEmployeeShortData()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Person> GetEmployeeData(BerryManagementEntities context,
                                                                         string EmployeeIdentity)
        {

            var result = context.Persons.Where(e => (EmployeeIdentity == null || e.Person_Identity == EmployeeIdentity)
                                           );

            return result;
        }

        public static IQueryable<Data.Employees.XClasses.PersonDocumentModel> GetPersonDocuments(BerryManagementEntities context,
                                               System.Nullable<long> PersonDocumentId,
                                               System.Nullable<long> personId,
                                               string userName,
                                               System.Nullable<long> PersonDocumentEmployeeId,
                                               System.Nullable<long> inrsonDocumentDocumentTypeId,
                                               System.Nullable<long> PersonDocumentCitizenshipId,
                                               System.Nullable<DateTime> PersonDocumentStartDate,
                                               System.Nullable<DateTime> PersonDocumentEndDate,
                                               ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonDocumentModel> result = null;
            try
            {
                result = from ep in context.PersonDocuments
                         join ci in context.Citizenships on ep.PersonDocument_Citizenship_Id equals ci.Citizenship_Id
                         join doc in context.DocumentTypes on ep.PersonDocument_DocumentType_Id equals doc.DocumentType_Id
                         where (personId == null || ep.PersonDocument_Person_Id == personId)
                         select new Data.Employees.XClasses.PersonDocumentModel
                         {
                             PersonDocument_Id = ep.PersonDocument_Id,
                             PersonDocument_Employee_Id = ep.PersonDocument_Person_Id,
                             PersonDocument_DocumentType_Id = doc.DocumentType_Id,
                             PersonDocument_DocumentType_Name = doc.DocumentType_Name,
                             PersonDocument_Employee_FullName = ep.PersonDocument_FirstName + " " + ep.PersonDocument_LastName,
                             PersonDocument_Employee_FirstName = ep.PersonDocument_FirstName,
                             PersonDocument_Employee_LastName = ep.PersonDocument_LastName,
                             PersonDocument_StartDate = ep.PersonDocument_StartDate,
                             PersonDocument_EndDate = ep.PersonDocument_EndDate,
                             PersonDocument_Number = ep.PersonDocument_Number,
                             PersonDocument_Isuer = ep.PersonDocument_Isuer,
                             PersonDocument_Description = ep.PersonDocument_Description,
                             Citizenship_Id = ci.Citizenship_Id,
                             Citizenship_Citizenship_Name = ci.Citizenship_Name,
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonDocuments()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonDocuments()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.PersonPost> GetPersonPostData(BerryManagementEntities context, long? id, long? person_Id, long? post_Id,
            string employeeBarCode, ref string errorMessage)
        {
            IQueryable<Data.PersonPost> result = null;
            try
            {
                result = context.PersonPosts;
                if (id != null)
                {
                    result = result.Where(r => r.PersonPost_Id == id);
                }
                if (person_Id != null)
                {
                    result = result.Where(r => r.PersonPost_Person_Id == person_Id);
                }
                if (post_Id != null)
                {
                    result = result.Where(r => r.PersonPost_Post_Id == post_Id);
                }
                if (!string.IsNullOrEmpty(employeeBarCode))
                {
                    result = result.Where(r => r.PersonPost_EmployeeBarCode == employeeBarCode);
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostData()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.PersonPostModel> GetPersonPostsByBrigadeId(BerryManagementEntities context, long? brigadeId,
            ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonPostModel> result = null;
            try
            {
                //result = from cx in context.TakeRowInOuts
                //         join pp in context.PersonPosts on cx.TakeRowInOut_Brigade_Id equals pp.PersonPost_Brigade_Id
                //         where cx.TakeRowInOut_Brigade_Id == brigadeId && (DateTime.Now >= pp.PersonPost_StartDate && DateTime.Now <= pp.PersonPost_EndDate)
                //         select new
                //         {
                //             PersonPost = pp
                //         }.PersonPost;

                result = from personPost in context.PersonPosts
                         join tf_Balance in context.tf_GetBalanceSheetTypes() on personPost.PersonPost_BalanceSheetType_Id equals tf_Balance.BalanceSheetType_Id
                         join tf_EmployeeTypes in context.tf_EmployeeTypes() on personPost.PersonPost_EmployeeType_Id equals tf_EmployeeTypes.EmployeeType_Id
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         where (brigadeId == null || personPost.PersonPost_Brigade_Id == brigadeId)
                         select new Data.Employees.XClasses.PersonPostModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                             PersonPost_BalanceSheetType_Name = tf_Balance.BalanceSheetType_Name,
                             PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                             PersonPost_EmployeeType_Name = tf_EmployeeTypes.EmployeeType_Name,
                             PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             PersonPost_StartDate = personPost.PersonPost_StartDate,
                             PersonPost_EndDate = personPost.PersonPost_EndDate,
                             PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                             PersonPost_Description = personPost.PersonPost_Description,
                             PersonPost_Direction = false
                         };

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonDocuments()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonDocuments()\n" + ex.Message;
                }
            }
            return result;
        }



        public static IQueryable<Data.Employees.XClasses.PersonPostModel> GetPersonPostsForPunishment(BerryManagementEntities context,
            ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonPostModel> result = null;
            try
            {
                result = from personPost in context.PersonPosts
                         join tf_Balance in context.tf_GetBalanceSheetTypes() on personPost.PersonPost_BalanceSheetType_Id equals tf_Balance.BalanceSheetType_Id
                         join tf_EmployeeTypes in context.tf_EmployeeTypes() on personPost.PersonPost_EmployeeType_Id equals tf_EmployeeTypes.EmployeeType_Id
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         where (personPost.PersonPost_Post_BarCodePrefix == "PK")
                         select new Data.Employees.XClasses.PersonPostModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                             PersonPost_BalanceSheetType_Name = tf_Balance.BalanceSheetType_Name,
                             PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                             PersonPost_EmployeeType_Name = tf_EmployeeTypes.EmployeeType_Name,
                             PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             PersonPost_StartDate = personPost.PersonPost_StartDate,
                             PersonPost_EndDate = personPost.PersonPost_EndDate,
                             PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                             PersonPost_Description = personPost.PersonPost_Description,
                             PersonPost_Direction = false
                         };

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostsForPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostsForPunishment()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.PersonPostModel> GetPersonPostModel(BerryManagementEntities context,
                                               System.Nullable<long> PersonPost_PersonId,
                                               ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonPostModel> result = null;
            try
            {
                result = from personPost in context.PersonPosts
                         join tf_Balance in context.tf_GetBalanceSheetTypes() on personPost.PersonPost_BalanceSheetType_Id equals tf_Balance.BalanceSheetType_Id
                         join tf_EmployeeTypes in context.tf_EmployeeTypes() on personPost.PersonPost_EmployeeType_Id equals tf_EmployeeTypes.EmployeeType_Id
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         where (PersonPost_PersonId == null || personPost.PersonPost_Person_Id == PersonPost_PersonId)
                         select new Data.Employees.XClasses.PersonPostModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                             PersonPost_BalanceSheetType_Name = tf_Balance.BalanceSheetType_Name,
                             PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                             PersonPost_EmployeeType_Name = tf_EmployeeTypes.EmployeeType_Name,
                             PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             PersonPost_StartDate = personPost.PersonPost_StartDate,
                             PersonPost_EndDate = personPost.PersonPost_EndDate,
                             PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                             PersonPost_Description = personPost.PersonPost_Description,
                             PersonPost_Direction = false
                         };


            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostModel()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostModel()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<string> GetCS(BerryManagementEntities context, DateTime Start,DateTime End, ref string errorMessage)
        {
            IQueryable<string> result = null;
            try
            {
                result = context.ContainerPacks.Where(c => c.ContainerPack_IsComplite == true 
                    && c.ContainerPack_DateTime >= Start 
                    && c.ContainerPack_DateTime <= End)
                    .Select(r => r.ContainerPack_Container_BarCode);
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

        public static IQueryable<Data.Employees.XClasses.PersonPostModel> GetPersonPostByPostId(BerryManagementEntities context,
                                               long PostId,
                                               ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonPostModel> result = null;
            try
            {
                result = from personPost in context.PersonPosts
                         join tf_Balance in context.tf_GetBalanceSheetTypes() on personPost.PersonPost_BalanceSheetType_Id equals tf_Balance.BalanceSheetType_Id
                         join tf_EmployeeTypes in context.tf_EmployeeTypes() on personPost.PersonPost_EmployeeType_Id equals tf_EmployeeTypes.EmployeeType_Id
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         where (personPost.PersonPost_Post_Id == PostId)
                         select new Data.Employees.XClasses.PersonPostModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                             PersonPost_BalanceSheetType_Name = tf_Balance.BalanceSheetType_Name,
                             PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                             PersonPost_EmployeeType_Name = tf_EmployeeTypes.EmployeeType_Name,
                             PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             PersonPost_StartDate = personPost.PersonPost_StartDate,
                             PersonPost_EndDate = personPost.PersonPost_EndDate,
                             PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                             PersonPost_Description = personPost.PersonPost_Description,
                             PersonPost_Direction = false
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static bool IsBetween<T>(this T item, T start, T end)
        {
            return Comparer<T>.Default.Compare(item, start) >= 0
                && Comparer<T>.Default.Compare(item, end) <= 0;
        }
        
        public static IQueryable<Data.Employees.XClasses.ReportModel.GeneralReportModel> GetGeneralReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.GeneralReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                var query = from weight in context.ContainerWeights
                            join reciver in context.ProductReceives on weight.ContainerWeight_Id equals reciver.ProductReceive_Id
                            join personPost in context.PersonPosts on reciver.ProductReceive_HarvesterBarCode equals personPost.PersonPost_EmployeeBarCode
                            join distribution in context.HarvesterRowDistributions on personPost.PersonPost_Id equals distribution.HarvesterRowDistribution_Harvester_PersonPost_Id 
                            join rowBreed in context.RowBreeds on distribution.HarvesterRowDistribution_Row_Id equals rowBreed.RowBreed_Row_Id
                            join breed in context.Breeds on rowBreed.RowBreed_Breed_Id equals breed.Breed_Id
                            join companyRow in context.CompanyRows on distribution.HarvesterRowDistribution_Row_Id equals companyRow.CompanyRow_Id
                            join company in context.Companyes on companyRow.CompanyRow_Company_Id equals company.Company_Id
                            where ((start == null && end == null) || (weight.ContainerWeight_DateTime >= start && weight.ContainerWeight_DateTime <= end))
                            && (weight.ContainerWeight_Container_BarCode.StartsWith("CT-")
                            && ((reciver.ProductReceive_DateTime >= distribution.HarvesterRowDistribution_In_DateTime && distribution.HarvesterRowDistribution_Out_DateTime == null) ||
                                (reciver.ProductReceive_DateTime >= distribution.HarvesterRowDistribution_In_DateTime && reciver.ProductReceive_DateTime <= distribution.HarvesterRowDistribution_Out_DateTime)))
                            group weight by new { company.Company_Name, breed.Breed_Name } into g
                            select new Data.Employees.XClasses.ReportModel.GeneralReportModel
                            {
                                BreedName = g.Key.Breed_Name,
                                CompanyName = g.Key.Company_Name,
                                Sum = g.Select(o => o.ContainerWeight_Net).Sum(),
                                EndDate = End,
                                StartDate = start
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetGeneralReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetGeneralReport()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Employees.XClasses.ReportModel.PunishmentCountModel> GetPunishmentCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.PunishmentCountModel> result = null;
            try
            {
                var query = from typ in context.tf_PunishmentTypes() 
                            join pun in context.Punishments on typ.PunishmentType_Id  equals pun.Punishment_PunishmentType_Id
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by new { pun.Punishment_PersonPost_Id, typ.PunishmentType_Name} into g
                            select new Data.Employees.XClasses.ReportModel.PunishmentCountModel
                            {
                                PersonPost_Id = g.Key.Punishment_PersonPost_Id,
                                Punishment_Name = "მიღებული " + g.Key.PunishmentType_Name,
                                Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                if (wqe.Count == 0)
                {
                    query = from typ in context.tf_PunishmentTypes()
                            group typ by new { typ.PunishmentType_Name } into g
                            select new Data.Employees.XClasses.ReportModel.PunishmentCountModel
                            {
                                PersonPost_Id = 0,
                                Punishment_Name = "მიღებული " + g.Key.PunishmentType_Name,
                                Punishment_Count = g.Count()
                            };
                }
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPunishmentCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishmentCount()\n" + ex.Message;
                }
            }
            return result;
        }
        public static IQueryable<Data.Employees.XClasses.ReportModel.PunishmentCountModel> GetPunishmentCountInner(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.PunishmentCountModel> result = null;
            try
            {
                var query = from pun in context.Punishments
                            join typ in context.tf_PunishmentTypes() on pun.Punishment_PunishmentType_Id equals typ.PunishmentType_Id
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by pun.Punishment_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.PunishmentCountModel
                            {
                                PersonPost_Id = g.Key,
                                Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPunishmentCountInner()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishmentCountInner()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetWeightCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                var query = from weight in context.ContainerWeights
                            join prod in context.Products on weight.ContainerWeight_Id equals prod.Product_Id
                            where ((start == null && end == null) || (weight.ContainerWeight_DateTime >= start && weight.ContainerWeight_DateTime <= end))
                            group weight by prod.Product_Harvester_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.WeightsModelcs
                            {
                                Harvester_PersonPost_Id = g.Key,
                                GrossWeight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                NetWeight = g.Select(o => o.ContainerWeight_Net).Sum(),
                                NetWeight_Average = g.Select(o => o.ContainerWeight_Net).Average(),
                                GrossWeight_Average = g.Select(o => o.ContainerWeight_Gross).Average(),
                                //Punishment_Count = g.Count()
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
        public static IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetWeightCountForPackager(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                var query = from weight in context.ContainerWeights
                            where ((start == null && end == null) || (weight.ContainerWeight_DateTime >= start && weight.ContainerWeight_DateTime <= end))
                            group weight by weight.ContainerWeight_User_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.WeightsModelcs
                            {
                                Harvester_PersonPost_Id = g.Key,
                                GrossWeight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                NetWeight = g.Select(o => o.ContainerWeight_Net).Sum(),
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

        public static IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetBrigadeWeight(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                var query = from weight in SelectQ.GetBrigadireReport(context,start,end,ref errorMessage)
                            //where ((start == null && end == null) || (weight.da >= start && weight.ContainerWeight_DateTime <= end))
                            group weight  by weight.PersonPost_Brigade_Id into g
                            select new Data.Employees.XClasses.ReportModel.WeightsModelcs
                            {
                                Harvester_PersonPost_Id = (long)g.Key,
                                GrossWeight = g.Select(o => o.NetWeight).Sum(),
                                NetWeight = g.Select(o => o.GrossWeight).Sum(),
                            };


                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBrigadeWeight()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetBrigadeWeight()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetRecomPunishmentCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                var query = from typ in context.tf_PunishmentTypes() 
                            join pun in context.Punishments on typ.PunishmentType_Id equals pun.Punishment_PunishmentType_Id
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by new { pun.Punishment_RecomenderUser_PersonPost_Id, typ.PunishmentType_Name } into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = g.Key.Punishment_RecomenderUser_PersonPost_Id,
                                Recomendator_Punishment_Name = "რეკომენდირებული " + g.Key.PunishmentType_Name,
                                Recomendator_Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                if(wqe.Count == 0)
                {
                    query = from typ in context.tf_PunishmentTypes()
                            group typ by new { typ.PunishmentType_Name } into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = 0,
                                Recomendator_Punishment_Name = "რეკომენდირებული " + g.Key.PunishmentType_Name,
                                Recomendator_Punishment_Count = g.Count()
                            };
                }
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRecomPunishmentCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRecomPunishmentCount()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetRecomPunishmentCountInner(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                var query = from pun in context.Punishments
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by pun.Punishment_RecomenderUser_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = g.Key,
                                Recomendator_Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRecomPunishmentCountInner()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRecomPunishmentCountInner()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetGivenPunishmentCountInner(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                var query = from pun in context.Punishments
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by pun.Punishment_User_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = g.Key,
                                Recomendator_Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetGivenPunishmentCountInner()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetGivenPunishmentCountInner()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetGivenPunishmentCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                //var query = from pun in context.Punishments
                //            join typ in context.tf_PunishmentTypes() on pun.Punishment_PunishmentType_Id equals typ.PunishmentType_Id
                //            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                //            group pun by new { pun.Punishment_User_PersonPost_Id, typ.PunishmentType_Name } into g
                //            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                //            {
                //                Recomendator_PersonPost_Id = g.Key.Punishment_User_PersonPost_Id,
                //                Recomendator_Punishment_Name = g.Key.PunishmentType_Name,
                //                Recomendator_Punishment_Count = g.Count()
                //            };
                var query = from typ in context.tf_PunishmentTypes() 
                            join pun in context.Punishments on  typ.PunishmentType_Id equals pun.Punishment_PunishmentType_Id 
                            where ((start == null && end == null) || (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end))
                            group pun by new { pun.Punishment_User_PersonPost_Id, typ.PunishmentType_Name } into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = g.Key.Punishment_User_PersonPost_Id,
                                Recomendator_Punishment_Name = "გაცემული " + g.Key.PunishmentType_Name,
                                Recomendator_Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                if (wqe.Count == 0)
                {
                    query = from typ in context.tf_PunishmentTypes()
                            group typ by new { typ.PunishmentType_Name } into g
                            select new Data.Employees.XClasses.ReportModel.RecPunishmentCountModel
                            {
                                Recomendator_PersonPost_Id = 0,
                                Recomendator_Punishment_Name = "გაცემული " + g.Key.PunishmentType_Name,
                                Recomendator_Punishment_Count = g.Count()
                            };
                }
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetGivenPunishmentCountInner()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetGivenPunishmentCountInner()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetUserWeightCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                var query = from weight in context.ContainerWeights
                            join prod in context.Products on weight.ContainerWeight_Id equals prod.Product_Id
                            where ((start == null && end == null) || (weight.ContainerWeight_DateTime >= start && weight.ContainerWeight_DateTime <= end))
                            group weight by prod.Product_User_PersonPost_Id into g
                            select new Data.Employees.XClasses.ReportModel.WeightsModelcs
                            {
                                Reciever_PersonPost_Id = g.Key,
                                GrossWeight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                NetWeight = g.Select(o => o.ContainerWeight_Net).Sum(),

                                //Punishment_Count = g.Count()
                            };
                var wqe = query.ToList();
                result = query;
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetUserWeightCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetUserWeightCount()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> GetHarvesterReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                result = from personPost in context.PersonPosts
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         join punishment in GetPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals punishment.PersonPost_Id into gj
                         from x in gj.DefaultIfEmpty()
                         join weight in GetWeightCount(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals weight.Harvester_PersonPost_Id into gl
                         from w in gl.DefaultIfEmpty()
                         where (personPost.PersonPost_Post_Id == 1)
                         select new Data.Employees.XClasses.ReportModel.ReportModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_Person_FullName = Person.Person_LastName + " " + Person.Person_FirstName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             Punishment_Count = (x == null ? 0 : x.Punishment_Count),
                             //Punishment_Name = (x == null ? "" : x.Punishment_Name),
                             GrossWeight = (w == null ? 0 : w.GrossWeight),
                             NetWeight = (w == null ? 0 : w.NetWeight),
                             NetWeight_Average = (w == null ? 0 : w.NetWeight_Average),
                             GrossWeight_Average = (w == null ? 0 : w.GrossWeight_Average),
                             StartDate = start,
                             EndDate = End,
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterReport()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> GetRecieverReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                result = from personPost in context.PersonPosts
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         join punishment in GetPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals punishment.PersonPost_Id into gj
                         from x in gj.DefaultIfEmpty()
                         join recPunishment in GetRecomPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals recPunishment.Recomendator_PersonPost_Id into gr
                         from r in gr.DefaultIfEmpty()
                         join weight in GetUserWeightCount(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals weight.Reciever_PersonPost_Id into gl
                         from w in gl.DefaultIfEmpty()
                         where (Post.Post_BarCodePrefix == "PR")
                         select new Data.Employees.XClasses.ReportModel.ReportModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_Person_FullName = Person.Person_LastName + " " + Person.Person_FirstName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             Punishment_Count = (x == null ? 0 : x.Punishment_Count),
                             GrossWeight = (w == null ? 0 : w.GrossWeight),
                             NetWeight = (w == null ? 0 : w.NetWeight),
                             Recomendator_PersonPost_Id = (long)(r == null ? 0 : r.Recomendator_PersonPost_Id),
                             Recomendator_Punishment_Count = (r == null ? 0 : r.Recomendator_Punishment_Count),
                             StartDate = start,
                             EndDate = End
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> GetControliorReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                result = from personPost in context.PersonPosts
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         join punishment in GetPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals punishment.PersonPost_Id into gj
                         from x in gj.DefaultIfEmpty()
                         join recPunishment in GetRecomPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals recPunishment.Recomendator_PersonPost_Id into gr
                         from r in gr.DefaultIfEmpty()
                         where (personPost.PersonPost_Post_Id == 8)
                         select new Data.Employees.XClasses.ReportModel.ReportModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             Punishment_Count = (x == null ? 0 : x.Punishment_Count),
                             Recomendator_PersonPost_Id = (long)(r == null ? 0 : r.Recomendator_PersonPost_Id),
                             Recomendator_Punishment_Count = (r == null ? 0 : r.Recomendator_Punishment_Count),
                             StartDate = start,
                             EndDate = End
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }



        public static IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetBrigadeWeightCount(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                var query = from weight in context.ContainerWeights
                            join prod in context.Products on weight.ContainerWeight_Id equals prod.Product_Id
                            join brig in context.PersonPosts on prod.Product_Harvester_PersonPost_Id equals brig.PersonPost_Id
                            where ((start == null && end == null) || (weight.ContainerWeight_DateTime >= start && weight.ContainerWeight_DateTime <= end))
                            group weight by brig.PersonPost_Brigade_Id into g
                            select new Data.Employees.XClasses.ReportModel.WeightsModelcs
                            {
                                Harvester_PersonPost_Id = (long)g.Key,
                                GrossWeight = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                NetWeight = g.Select(o => o.ContainerWeight_Net).Sum(),

                                //Punishment_Count = g.Count()
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

        public static IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> GetBrigadireReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                result = from personPost in context.PersonPosts
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         join punishment in GetPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals punishment.PersonPost_Id into gj
                         from x in gj.DefaultIfEmpty()
                         join recPunishment in GetGivenPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals recPunishment.Recomendator_PersonPost_Id into gr
                         from r in gr.DefaultIfEmpty()
                         join weight in GetBrigadeWeightCount(context, start, end, ref errorMessage) on personPost.PersonPost_Brigade_Id equals weight.Harvester_PersonPost_Id into gl
                         from w in gl.DefaultIfEmpty()
                         where (personPost.PersonPost_Post_Id == 2)
                         select new Data.Employees.XClasses.ReportModel.ReportModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_Person_FullName = Person.Person_LastName  + " " + Person.Person_FirstName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             Punishment_Count = (x == null ? 0 : x.Punishment_Count),
                             Recomendator_PersonPost_Id = (long)(r == null ? 0 : r.Recomendator_PersonPost_Id),
                             Recomendator_Punishment_Count = (r == null ? 0 : r.Recomendator_Punishment_Count),
                             GrossWeight = (w == null ? 0 : w.GrossWeight),
                             NetWeight = (w == null ? 0 : w.NetWeight),
                             StartDate = start,
                             EndDate = End
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> GetPackagerReport(BerryManagementEntities context, DateTime? start, DateTime? end, ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                DateTime? End = end.Value.AddDays(-1);
                result = from personPost in context.PersonPosts
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         join punishment in GetPunishmentCountInner(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals punishment.PersonPost_Id into gj
                         from x in gj.DefaultIfEmpty()
                         join weight in GetWeightCountForPackager(context, start, end, ref errorMessage) on personPost.PersonPost_Id equals weight.Harvester_PersonPost_Id into gl
                         from w in gl.DefaultIfEmpty()
                         where (Post.Post_BarCodePrefix == "PW")
                         select new Data.Employees.XClasses.ReportModel.ReportModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             Punishment_Count = (x == null ? 0 : x.Punishment_Count),
                             GrossWeight = (w == null ? 0 : w.GrossWeight),
                             NetWeight = (w == null ? 0 : w.NetWeight),
                             StartDate = start,
                             EndDate = End

                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }




        public static IQueryable<Data.Employees.XClasses.PersonPostModel> GetPersonPostModelForRows(BerryManagementEntities context,
                                               System.Nullable<long> BrigadeId,
                                               ref string errorMessage)
        {
            IQueryable<Data.Employees.XClasses.PersonPostModel> result = null;
            try
            {
                result = from personPost in context.PersonPosts
                         join tf_Balance in context.tf_GetBalanceSheetTypes() on personPost.PersonPost_BalanceSheetType_Id equals tf_Balance.BalanceSheetType_Id
                         join tf_EmployeeTypes in context.tf_EmployeeTypes() on personPost.PersonPost_EmployeeType_Id equals tf_EmployeeTypes.EmployeeType_Id
                         join Person in context.Persons on personPost.PersonPost_Person_Id equals Person.Person_Id
                         join Post in context.Posts on personPost.PersonPost_Post_Id equals Post.Post_Id
                         join Brigade in context.Brigades on personPost.PersonPost_Brigade_Id equals Brigade.Brigade_Id
                         where (BrigadeId == null || personPost.PersonPost_Brigade_Id == BrigadeId) /*&& personPost.PersonPost_Post_Id == 1 */
                         select new Data.Employees.XClasses.PersonPostModel
                         {
                             PersonPost_Id = personPost.PersonPost_Id,
                             PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                             PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                             PersonPost_BalanceSheetType_Name = tf_Balance.BalanceSheetType_Name,
                             PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                             PersonPost_EmployeeType_Name = tf_EmployeeTypes.EmployeeType_Name,
                             PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                             PersonPost_Person_FullName = Person.Person_FirstName + " " + Person.Person_LastName,
                             PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                             PersonPost_Post_Name = Post.Post_Name,
                             PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                             PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                             PersonPost_Brigade_Name = Brigade.Brigade_Name,
                             PersonPost_StartDate = personPost.PersonPost_StartDate,
                             PersonPost_EndDate = personPost.PersonPost_EndDate,
                             PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                             PersonPost_Description = personPost.PersonPost_Description,
                             PersonPost_Direction = false
                         };


            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostModelForRows()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostModelForRows()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<XClasses.EmployeeLabel> GetEmployeeLabels(BerryManagementEntities context, List<long> employeePostIds, ref string errorMessage)
        {
            IQueryable<XClasses.EmployeeLabel> result = null;
            try
            {
                result = from pp in context.PersonPosts
                         join p in context.Persons on pp.PersonPost_Person_Id equals p.Person_Id
                         join ppp in context.Posts on pp.PersonPost_Post_Id equals ppp.Post_Id
                         join b in context.Brigades on pp.PersonPost_Brigade_Id equals b.Brigade_Id
                         where employeePostIds.Contains(pp.PersonPost_Id)
                         select new Data.Employees.XClasses.EmployeeLabel
                         {
                             FirstName = p.Person_FirstName,
                             LastName = p.Person_LastName,
                             Barcode = pp.PersonPost_EmployeeBarCode,
                             PostName = ppp.Post_Name,
                             BrigadeName = b.Brigade_Name
                         };
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetEmployeeLabels()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetEmployeeLabels()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.PersonPost> GetPersonPostByBarcode(BerryManagementEntities context,
            string harvesterBarCOde,
            ref string errorMessage)
        {
            

            IQueryable<Data.PersonPost> result = null;
            try
            {
                result = context.PersonPosts.Where(p=>p.PersonPost_EmployeeBarCode==harvesterBarCOde);

                return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPersonPostByBarcode()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByBarcode()\n" + ex.Message;
                }
            }
            return result;
        }public static IQueryable<Data.CompanyRow> GetCompanyRow(BerryManagementEntities context,
            long rowId,
            ref string errorMessage)
        {


            IQueryable<Data.CompanyRow> result = null;
            try
            {
                result = context.CompanyRows.Where(c=>c.CompanyRow_Row_Id==rowId);

                return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetCompanyRow()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPersonPostByBarcode()\n" + ex.Message;
                }
            }
            return result;
        }

        public static IQueryable<Data.Post> GetPostById(BerryManagementEntities context,
                                               long? postId,
                                               ref string errorMessage)
        {
            if (postId == null)
            {
                postId = 0;
            }

            IQueryable<Data.Post> result = null;
            try
            {
                result = context.Posts;
                result = result.Where(e => e.Post_Id == postId);

                return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPostById()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPostById()\n" + ex.Message;
                }
            }
            return result;
        }



        //public static IQueryable<Data.Employees.XClasses.PersonEverything> LiftJoinSelectResults(BerryManagementEntities context, long? EmployeeId,
        //                                                                  string EmployeeIdentity, string FirstName, string LastName, long? code)
        //{
        //    IQueryable<Data.Employees.XClasses.PersonEverything> result = null;
        //    result = (from person in context.Persons
        //              join personpost in context.PersonPosts on person.Person_Id equals personpost.PersonPost_Person_Id
        //              join post in context.Posts on personpost.PersonPost_Post_Id equals post.Post_Id
        //              join brg in context.Brigades on person


        //    return result;
        //}

        public static IQueryable<Data.Employees.XClasses.PunishmentModel> GetPunishment(BerryManagementEntities context,long? personID, long? userPersonPostId,
                                       ref string errorMessage)
        {
            string GetPunishmentTypesErrorMessage = string.Empty;

            IQueryable<Data.Employees.XClasses.PunishmentModel> result = null;
            try
            {
                result = from pun in context.Punishments.Where(c=> (userPersonPostId == null || c.Punishment_User_PersonPost_Id== userPersonPostId)/* && c.Punishment_DateTime>DateTime.Today*/)
                         join pt in Data.Library.SelectQ.GetPunishmentTypes(context, null, null, ref GetPunishmentTypesErrorMessage) on pun.Punishment_PunishmentType_Id equals pt.PunishmentType_Id
                         join HarvesterPersonPost in context.PersonPosts on pun.Punishment_PersonPost_Id equals HarvesterPersonPost.PersonPost_Id
                         join harvester in context.Persons on HarvesterPersonPost.PersonPost_Person_Id equals harvester.Person_Id
                         //join UserPersonPost in context.PersonPosts on pun.Punishment_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                         //join User in context.Persons on pun.Punishment_User_PersonPost_Id equals User.Person_Id
                         where (pun.Punishment_PersonPost_Id == personID) || (personID == null)
                         select new Data.Employees.XClasses.PunishmentModel
                         {
                             Punishment_Id = pun.Punishment_Id,
                             Punishment_PersonPost_Id = pun.Punishment_PersonPost_Id,
                             Punishment_PunishmentType_Id = pun.Punishment_PunishmentType_Id,
                             PunishmentType_Name = pt.PunishmentType_Name,
                             Punishment_DateTime = pun.Punishment_DateTime,
                             Punishment_User_PersonPost_Id = pun.Punishment_User_PersonPost_Id,
                             Punishment_Harvester_FullName = harvester.Person_FirstName + " " + harvester.Person_LastName,
                             //Punishment_User_FullName = User.Person_FirstName + " " + User.Person_LastName,
                             IsComplete = true,
                             Punishment_Description = pun.Punishment_Description
                         };



                return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = errorMessage + "მეთოდი: GetPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishment()\n" + ex.Message;
                }


            }

            if (!System.String.IsNullOrEmpty(GetPunishmentTypesErrorMessage))
            {
                GetPunishmentTypesErrorMessage = GetPunishmentTypesErrorMessage + "\n GetPunishmentTypesErrorMessage ";
            }

            return result;

        }

        public static IQueryable<Data.Employees.XClasses.PunishmentModel> GetPunishmentByDite(BerryManagementEntities context, long? personID,DateTime start,DateTime end,
                                ref string errorMessage)
        {
            string GetPunishmentTypesErrorMessage = string.Empty;

            IQueryable<Data.Employees.XClasses.PunishmentModel> result = null;
            try
            {
                result = from pun in context.Punishments
                         join pt in Data.Library.SelectQ.GetPunishmentTypes(context, null, null, ref GetPunishmentTypesErrorMessage) on pun.Punishment_PunishmentType_Id equals pt.PunishmentType_Id
                         join HarvesterPersonPost in context.PersonPosts on pun.Punishment_PersonPost_Id equals HarvesterPersonPost.PersonPost_Id
                         join harvester in context.Persons on HarvesterPersonPost.PersonPost_Person_Id equals harvester.Person_Id
                         //join UserPersonPost in context.PersonPosts on pun.Punishment_User_PersonPost_Id equals UserPersonPost.PersonPost_Id
                         //join User in context.Persons on pun.Punishment_User_PersonPost_Id equals User.Person_Id
                         where ((pun.Punishment_PersonPost_Id == personID) || (personID == null)) &&
                         (pun.Punishment_DateTime >= start && pun.Punishment_DateTime <= end)
                         select new Data.Employees.XClasses.PunishmentModel
                         {
                             Punishment_Id = pun.Punishment_Id,
                             Punishment_PersonPost_Id = pun.Punishment_PersonPost_Id,
                             Punishment_PunishmentType_Id = pun.Punishment_PunishmentType_Id,
                             PunishmentType_Name = pt.PunishmentType_Name,
                             Punishment_DateTime = pun.Punishment_DateTime,
                             Punishment_User_PersonPost_Id = pun.Punishment_User_PersonPost_Id,
                             Punishment_Harvester_FullName = harvester.Person_FirstName + " " + harvester.Person_LastName,
                             //Punishment_User_FullName = User.Person_FirstName + " " + User.Person_LastName,
                             IsComplete = true,
                             Punishment_Description = pun.Punishment_Description
                         };



                return result;

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = errorMessage + "მეთოდი: GetPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishment()\n" + ex.Message;
                }


            }

            if (!System.String.IsNullOrEmpty(GetPunishmentTypesErrorMessage))
            {
                GetPunishmentTypesErrorMessage = GetPunishmentTypesErrorMessage + "\n GetPunishmentTypesErrorMessage ";
            }

            return result;

        }

        #region AndroidAppp

        #region Harvester
        //Harvester For HarvesterRowDistributionInOut
        public static IQueryable<XClasses.PersonPostModel> GetHarvByHarvRowDistrOuts(BerryManagementEntities context, bool direction,long? brigadeId, ref string errorMessage)
        {
            IQueryable<XClasses.PersonPostModel> result = null;
            try
            {
                if (direction)
                {
                    var HarvesterRow = context.HarvesterRowDistributions.Where(x => x.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null).Select(x => x.HarvesterRowDistribution_Harvester_PersonPost_Id);
                    var HarvesterRowList = context.HarvesterRowDistributions.Where(x => x.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null).Select(x => x.HarvesterRowDistribution_Harvester_PersonPost_Id).ToList();
                    //var personPosts = SelectQ.GetPersonPostModel(context, null, ref errorMessage).ToList();
                    result = SelectQ.GetPersonPostsByBrigadeId(context, brigadeId, ref errorMessage).Where(
                        c => !HarvesterRow.Contains(c.PersonPost_Id) && c.PersonPost_Post_BarCodePrefix=="PH"

                        ).Select(y => new XClasses.PersonPostModel
                    {
                        PersonPost_Id = y.PersonPost_Id,
                        PersonPost_EmployeeBarCode = y.PersonPost_EmployeeBarCode,
                        PersonPost_BalanceSheetType_Id = y.PersonPost_BalanceSheetType_Id,
                        PersonPost_BalanceSheetType_Name = y.PersonPost_BalanceSheetType_Name,
                        PersonPost_EmployeeType_Id = y.PersonPost_EmployeeType_Id,
                        PersonPost_EmployeeType_Name = y.PersonPost_EmployeeType_Name,
                        PersonPost_Person_Id = y.PersonPost_Person_Id,
                        PersonPost_Person_FullName = y.PersonPost_Person_FullName,
                        PersonPost_Post_Id = y.PersonPost_Post_Id,
                        PersonPost_Post_Name = y.PersonPost_Post_Name,
                        PersonPost_Post_BarCodePrefix = y.PersonPost_Post_BarCodePrefix,
                        PersonPost_Brigade_Id = y.PersonPost_Brigade_Id,
                        PersonPost_Brigade_Name = y.PersonPost_Brigade_Name,
                        PersonPost_StartDate = y.PersonPost_StartDate,
                        PersonPost_EndDate = y.PersonPost_EndDate,
                        PersonPost_DismissalOrder = y.PersonPost_DismissalOrder,
                        PersonPost_Description = y.PersonPost_Description,
                        PersonPost_Direction = direction

                    });
                }
                else
                {
                    result = from personPost in SelectQ.GetPersonPostsByBrigadeId(context, brigadeId, ref errorMessage)
                             join harvesterDistribution in Data.Operation.SelectQ.GetHarvesterRowDistributions(context, null, null, null, null, null, true, ref errorMessage) on personPost.PersonPost_Id equals harvesterDistribution.HarvesterRowDistribution_Harvester_PersonPost_Id
                             select new XClasses.PersonPostModel
                             {
                                 PersonPost_Id = personPost.PersonPost_Id,
                                 PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                                 PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                                 PersonPost_BalanceSheetType_Name = personPost.PersonPost_BalanceSheetType_Name,
                                 PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                                 PersonPost_EmployeeType_Name = personPost.PersonPost_EmployeeType_Name,
                                 PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                                 PersonPost_Person_FullName = personPost.PersonPost_Person_FullName,
                                 PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                                 PersonPost_Post_Name = personPost.PersonPost_Post_Name,
                                 PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                                 PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                                 PersonPost_Brigade_Name = personPost.PersonPost_Brigade_Name,
                                 PersonPost_StartDate = personPost.PersonPost_StartDate,
                                 PersonPost_EndDate = personPost.PersonPost_EndDate,
                                 PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                                 PersonPost_Description = personPost.PersonPost_Description,
                                 PersonPost_Direction = direction
                             };

                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
            }
            return result;
        }


        public static IQueryable<XClasses.PersonPostModel> GetHarvByHarvRowDistrOutsByRowId(BerryManagementEntities context, bool direction, long? brigadeId, long? RowId, ref string errorMessage)
        {
            IQueryable<XClasses.PersonPostModel> result = null;
            try
            {
                    result = from personPost in SelectQ.GetPersonPostsByBrigadeId(context, brigadeId, ref errorMessage)
                             join harvesterDistribution in Data.Operation.SelectQ.GetHarvesterRowDistributions(context, null, RowId, null, null, null, direction, ref errorMessage) on personPost.PersonPost_Id equals harvesterDistribution.HarvesterRowDistribution_Harvester_PersonPost_Id
                             select new XClasses.PersonPostModel
                             {
                                 PersonPost_Id = personPost.PersonPost_Id,
                                 PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode,
                                 PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id,
                                 PersonPost_BalanceSheetType_Name = personPost.PersonPost_BalanceSheetType_Name,
                                 PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id,
                                 PersonPost_EmployeeType_Name = personPost.PersonPost_EmployeeType_Name,
                                 PersonPost_Person_Id = personPost.PersonPost_Person_Id,
                                 PersonPost_Person_FullName = personPost.PersonPost_Person_FullName,
                                 PersonPost_Post_Id = personPost.PersonPost_Post_Id,
                                 PersonPost_Post_Name = personPost.PersonPost_Post_Name,
                                 PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix,
                                 PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id,
                                 PersonPost_Brigade_Name = personPost.PersonPost_Brigade_Name,
                                 PersonPost_StartDate = personPost.PersonPost_StartDate,
                                 PersonPost_EndDate = personPost.PersonPost_EndDate,
                                 PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder,
                                 PersonPost_Description = personPost.PersonPost_Description,
                                 PersonPost_Direction = direction
                             };

                }            
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvByHarvRowDistrOutsByRowId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvByHarvRowDistrOutsByRowId()\n" + ex.Message;
                }
            }
            return result;
        }

        //Harvester For Punishment 
        public static IQueryable<XClasses.PersonPostModel> GetHarvesterByHRDForPunishment(BerryManagementEntities context, ref string errorMessage)
        {
            IQueryable<XClasses.PersonPostModel> result = null;
            try
            {
                    var HarvesterRow = context.HarvesterRowDistributions.Where(x => x.HarvesterRowDistribution_Out_HarvesterRowDistributionInOut_Id == null).Select(x => x.HarvesterRowDistribution_Harvester_PersonPost_Id);
                var ey = HarvesterRow.ToList();
                    result = SelectQ.GetPersonPostModel(context, null, ref errorMessage).Where(c =>HarvesterRow.Contains(c.PersonPost_Id)).Select(y => new XClasses.PersonPostModel
                        {
                            PersonPost_Id = y.PersonPost_Id,
                            PersonPost_EmployeeBarCode = y.PersonPost_EmployeeBarCode,
                            PersonPost_BalanceSheetType_Id = y.PersonPost_BalanceSheetType_Id,
                            PersonPost_BalanceSheetType_Name = y.PersonPost_BalanceSheetType_Name,
                            PersonPost_EmployeeType_Id = y.PersonPost_EmployeeType_Id,
                            PersonPost_EmployeeType_Name = y.PersonPost_EmployeeType_Name,
                            PersonPost_Person_Id = y.PersonPost_Person_Id,
                            PersonPost_Person_FullName = y.PersonPost_Person_FullName,
                            PersonPost_Post_Id = y.PersonPost_Post_Id,
                            PersonPost_Post_Name = y.PersonPost_Post_Name,
                            PersonPost_Post_BarCodePrefix = y.PersonPost_Post_BarCodePrefix,
                            PersonPost_Brigade_Id = y.PersonPost_Brigade_Id,
                            PersonPost_Brigade_Name = y.PersonPost_Brigade_Name,
                            PersonPost_StartDate = y.PersonPost_StartDate,
                            PersonPost_EndDate = y.PersonPost_EndDate,
                            PersonPost_DismissalOrder = y.PersonPost_DismissalOrder,
                            PersonPost_Description = y.PersonPost_Description,
                            PersonPost_Direction = false

                        });
                
                
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterByHarvesterRowDistributionForPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterByHarvesterRowDistributionForPunishment()\n" + ex.Message;
                }
            }
            return result;
        }
        #endregion
        #endregion
        public static IQueryable<Data.PersonPost> GetPersonPostsIdByPersonId (BerryManagementEntities context, long personID, ref string errorMessage)
        {
            IQueryable<Data.PersonPost> personPosts = null;
            try
            {
                personPosts = context.PersonPosts.Where(c => (c.PersonPost_EndDate == null || c.PersonPost_EndDate <= DateTime.Now) && c.PersonPost_Person_Id == personID);

            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: getHarvesterInRowPersonPos()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: getHarvesterInRowPersonPos()\n" + ex.Message;
                }
            }
            return personPosts;
        }

      
        
    }
}

