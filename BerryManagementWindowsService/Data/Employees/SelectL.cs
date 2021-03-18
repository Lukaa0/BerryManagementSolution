using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerryManagementWindowsService.Classes;

namespace BerryManagementWindowsService.Data.Employees
{
    public static class SelectL
    {
        /// <summary>
        /// მოაქვს ერთნაირი პერსონალური ნომრების რაოდენობა
        /// </summary>
        /// <param name="inEmployeeIdentity"></param>
        /// <returns></returns>
        public static int GetNumberOfEmployeeSameIdentities(string inEmployeeIdentity, ref String errorMessage)
        {
            int result = 0;
            try
            {
                if (!System.String.IsNullOrEmpty(inEmployeeIdentity))
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        var selectText = SelectQ.GetNumberOfEmployeeSameIdentities(context, inEmployeeIdentity);
                        result = selectText.Count();
                    }
                }
                else
                {
                    throw new Exception("თანამშრომლის პერსონალური ნომერი არავალიდურია.");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: GetNumberOfEmployeeSameIdentities()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: GetNumberOfEmployeeSameIdentities()\n" + ex.Message;
                }
            }
            return result;
        }

        /// <summary>
        /// მოაქვს თანამშრომლის მიმდინარე სახელი და გვარი 
        /// </summary>
        /// <param name="inEmployeeId"></param>
        /// <returns></returns>
        public static string GetEmployeeCurrentName(long inEmployeeId, ref String errorMessage)
        {
            string result = System.String.Empty;

            try
            {
                if (inEmployeeId > 0)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        Data.Person currentName = context.Persons.Where(n => n.Person_Id == inEmployeeId).FirstOrDefault();
                        if (currentName != null)
                        {
                            result = (
                                      ((!System.String.IsNullOrEmpty(currentName.Person_LastName)) ? currentName.Person_LastName.Trim() : System.String.Empty) +
                                      " " +
                                      ((!System.String.IsNullOrEmpty(currentName.Person_FirstName)) ? currentName.Person_FirstName.Trim() : System.String.Empty)
                                     ).Trim();
                        }
                    }
                }
                else
                {
                    throw new Exception("თანამშრომლის იდენტიფიკატორი არავალიდურია.");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetEmployeeCurrentName()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetEmployeeCurrentName()\n" + ex.Message;
                }
            }
            return result;
        }

        /// <summary>
        ///  მოაქვს თანამშრომლის დეტალური მონაცემების შეზღუდული ჩამონათვალი
        /// </summary>
        /// <param name="inEmployeeId"></param>
        /// <param name="inEmployeeIdentity"></param>
        /// <param name="inEmployeeFirstName"></param>
        /// <param name="inEmployeeLastName"></param>
        /// <param name="inEmployeePostName"></param>
        /// <param name="inEmployeeWorkStatus"></param>
        /// <returns></returns>
        /// 
        public static List<Data.Person> GetEmployeeShortData(long? EmployeeId,string EmployeeIdentity, string FirstName, string LastName, long? code , long? postId, bool isFirstUse,ref String errorMessage)
        {
            List<Data.Person> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    if (isFirstUse)
                    {
                        var selectText = SelectQ.GetEmployeeShortData(context, EmployeeId, EmployeeIdentity, FirstName, LastName, code, postId, ref errorMessage);
                        result = selectText.ToList();

                    }

                    else
                    {
                        result = (from p in context.Persons
                                  join pp in context.PersonPosts on p.Person_Id equals pp.PersonPost_Person_Id
                                  join post in context.Posts on pp.PersonPost_Post_Id equals post.Post_Id
                                  where (EmployeeId == null || EmployeeId == 0 || p.Person_Id == EmployeeId.Value)
                                                                && (EmployeeIdentity == null || p.Person_Identity == EmployeeIdentity)
                                                                && (FirstName == null || p.Person_FirstName == FirstName)
                                                                && (LastName == null || p.Person_LastName == LastName)
                                                                && (code == null || p.Person_Code == code)
                                                                && (postId == null || post.Post_Id == postId)
                                  select new
                                  {
                                      Person_Address1 = p.Person_Address1,
                                      Person_Address2 = p.Person_Address2,
                                      Person_BankAccount = p.Person_BankAccount,
                                      Person_BankClientName = p.Person_BankClientName,
                                      Person_Bank_Id = p.Person_Bank_Id,
                                      Person_BirthDate = p.Person_BirthDate,
                                      Person_Citizenship_Id = p.Person_Citizenship_Id,
                                      Person_Code = p.Person_Code,
                                      Person_Description = p.Person_Description,
                                      Person_DrivingLicense = p.Person_DrivingLicense,
                                      Person_FirstName = p.Person_FirstName,
                                      Person_GenderType_Id = p.Person_GenderType_Id,
                                      Person_Id = p.Person_Id,
                                      Person_Identity = p.Person_Identity,
                                      Person_IsResident = p.Person_IsResident,
                                      Person_LastName = p.Person_LastName,
                                      Person_LegalForm_Id = p.Person_LegalForm_Id,
                                      Person_LegalStatuseType_Id = p.Person_LegalStatuseType_Id,
                                      Person_MailAddress = p.Person_MailAddress,
                                      Person_MaritalStatus_Id = p.Person_MaritalStatus_Id,
                                      Person_Nationality_Id = p.Person_Nationality_Id,
                                      Person_Phone1 = p.Person_Phone1,
                                      Person_Phone2 = p.Person_Phone2,
                                      Person_SideType_Id = p.Person_SideType_Id,
                                      Post_Name = post.Post_Name

                                  }).ToList()
                    .Select(eN => new Person()
                    {
                        Person_Address1 = eN.Person_Address1,
                        Person_Address2 = eN.Person_Address2,
                        Person_BankAccount = eN.Person_BankAccount,
                        Person_BankClientName = eN.Person_BankClientName,
                        Person_Bank_Id = eN.Person_Bank_Id,
                        Person_BirthDate = eN.Person_BirthDate,
                        Person_Citizenship_Id = eN.Person_Citizenship_Id,
                        Person_Code = eN.Person_Code,
                        Person_Description = eN.Person_Description,
                        Person_DrivingLicense = eN.Person_DrivingLicense,
                        Person_FirstName = eN.Person_FirstName,
                        Person_GenderType_Id = eN.Person_GenderType_Id,
                        Person_Id = eN.Person_Id,
                        Person_Identity = eN.Person_Identity,
                        Person_IsResident = eN.Person_IsResident,
                        Person_LastName = eN.Person_LastName,
                        Person_LegalForm_Id = eN.Person_LegalForm_Id,
                        Person_LegalStatuseType_Id = eN.Person_LegalStatuseType_Id,
                        Person_MailAddress = eN.Person_MailAddress,
                        Person_MaritalStatus_Id = eN.Person_MaritalStatus_Id,
                        Person_Nationality_Id = eN.Person_Nationality_Id,
                        Person_Phone1 = eN.Person_Phone1,
                        Person_Phone2 = eN.Person_Phone2,
                        Person_SideType_Id = eN.Person_SideType_Id,
                        Post_Name = eN.Post_Name
                    }).ToList<Person>();
                    }
                    

                    
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetEmployeeShortData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetEmployeeShortData()\n" + ex.Message;
                }
            }
            return result;
        }
        #region AndroidApp
        public static List<XClasses.PersonPostModel> GetHarvByHarvRowDistrOuts(  bool Direction, long? brigadeId, ref string errorMessage)
        {
            
            List<XClasses.PersonPostModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvByHarvRowDistrOuts(context,Direction, brigadeId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<XClasses.PersonPostModel> GetHarvByHarvRowDistrOutsByRowId(bool Direction, long? brigadeId, long? rowId,ref string errorMessage)
        {

            List<XClasses.PersonPostModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvByHarvRowDistrOutsByRowId(context, Direction, brigadeId, rowId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "GetHarvesterByHarvesterRowDistributionInOuts()\n" + ex.Message;
                }
            }
            return result;
        }



        public static List<XClasses.PersonPostModel> GetHarvesterByHRDForPunishment( ref string errorMessage)
        {
            List<XClasses.PersonPostModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterByHRDForPunishment(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetHarvesterByHarvesterRowDistributionForPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "GetHarvesterByHarvesterRowDistributionForPunishment()\n" + ex.Message;
                }
            }
            return result;
        }
        #endregion

        public static List<Data.PersonPost> GetPersonPostsIdByPersonId( long personID, ref string errorMessage)
    {
        List<Data.PersonPost> result = null;
        try
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                var selectText = SelectQ.GetPersonPostsIdByPersonId(context, personID,ref errorMessage);
                result = selectText.ToList();
            }
        }
        catch (Exception ex)
        {

            if (System.String.IsNullOrEmpty(errorMessage))
            {
                errorMessage = "GetPersonPostsIdByPersonId()\n" + ex.Message;
            }
            else
            {
                errorMessage = errorMessage + "GetPersonPostsIdByPersonId()\n" + ex.Message;
            }
        }
        return result;
    }
        public static List<Data.Person> GetEmployeeData( string EmployeeIdentity, ref String errorMessage)
        {
            List<Data.Person> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetEmployeeData(context, EmployeeIdentity);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetEmployeeData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetEmployeeData()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Employees.XClasses.PersonDocumentModel> GetPersonDocuments(
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
            List<Data.Employees.XClasses.PersonDocumentModel> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                var selectText = SelectQ.GetPersonDocuments(context, PersonDocumentId,
                                                       personId,
                                                       userName,
                                                       PersonDocumentEmployeeId,
                                                       inrsonDocumentDocumentTypeId,
                                                       PersonDocumentCitizenshipId,
                                                       PersonDocumentStartDate,
                                                       PersonDocumentEndDate,
                                                       ref errorMessage);

                result = selectText.ToList<XClasses.PersonDocumentModel>();
            }
            return result;
        }

        public static List<Data.PersonPost> GetPersonPostData(long? personPost_Id, long? Person_Id, long? Post_Id, string employeeBarCode, ref String errorMessage)
        {
            List<Data.PersonPost> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPostData(context,personPost_Id, Person_Id,Post_Id,employeeBarCode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostData()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetPersonPostData()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsByBrigadeId(long? brigadeId, ref String errorMessage)
        {
            List<Data.Employees.XClasses.PersonPostModel> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPostsByBrigadeId(context, brigadeId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetPersonPostsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Employees.XClasses.PersonPostModel> GetPersonPostByPostId(long PostId, ref String errorMessage)
        {
            List<Data.Employees.XClasses.PersonPostModel> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPostByPostId(context, PostId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostByPostId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n GetPersonPostByPostId()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsForPunishment(ref String errorMessage)
        {
            List<Data.Employees.XClasses.PersonPostModel> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPostsForPunishment(context, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostsForPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\n GetPersonPostsForPunishment()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.PersonPost> GetPersonPostByBarcode(string harvesterCode, ref String errorMessage)
        {
            List<Data.PersonPost> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPersonPostByBarcode(context, harvesterCode, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetPersonPostsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.CompanyRow> GetCompanyRow(long rowId, ref String errorMessage)
        {
            List<Data.CompanyRow> result = null;

            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetCompanyRow(context, rowId, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "GetPersonPostsByBrigadeId()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nGetPersonPostsByBrigadeId()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModel(
                                              System.Nullable<long> PersonPost_PersonId,
                                              ref string errorMessage)
        {
            List<Data.Employees.XClasses.PersonPostModel> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                var selectText = SelectQ.GetPersonPostModel(context, PersonPost_PersonId, ref errorMessage);
                result = selectText.ToList<XClasses.PersonPostModel>();
            }
            return result;
        }

        public static List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModelForRows(
                                      System.Nullable<long> BrigadeId,
                                      ref string errorMessage)
        {
            List<Data.Employees.XClasses.PersonPostModel> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                var selectText = SelectQ.GetPersonPostModelForRows(context, BrigadeId, ref errorMessage);
                result = selectText.ToList<XClasses.PersonPostModel>();
            }
            return result;
        }


        public static List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(DateTime Start, DateTime End,
            int productOwnerStatus, DateTime? maxDateTime, ref string errorMessage)
        {
            List<Data.RS.XClasses.RS_ProductModel> result = null;
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var cont = SelectQ.GetCS(context, Start, End, ref errorMessage).ToList();
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


        public static List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetRecomPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRecomPunishmentCount(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetGivenPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetGivenPunishmentCount(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetGivenPunishmentCount()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetGivenPunishmentCount()\n" + ex.Message;
                }
            }
            return result;
        }




        public static List<Data.Employees.XClasses.ReportModel.PunishmentCountModel> GetPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.PunishmentCountModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPunishmentCount(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<Data.Employees.XClasses.ReportModel.GeneralReportModel> GetGeneralReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.GeneralReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetGeneralReport(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
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

        public static List<Data.Employees.XClasses.ReportModel.ReportModel> GetBrigadireReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetBrigadireReport(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBrigadireReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetBrigadireReport()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Employees.XClasses.ReportModel.ReportModel> GetPackagerReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPackagerReport(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPackagerReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPackagerReport()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetBrigadeWeight(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.WeightsModelcs> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetBrigadeWeight(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }

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

        public static List<Data.Employees.XClasses.ReportModel.ReportModel> GetControliorReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetControliorReport(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetControliorReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetControliorReport()\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Employees.XClasses.ReportModel.ReportModel> GetRecieverReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRecieverReport(context, start, end, ref errorMessage);
                    result = selectText.ToList();
                }

            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRecieverReport()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRecieverReport()\n" + ex.Message;
                }
            }
            return result;
        }
        public static List<Data.Employees.XClasses.ReportModel.ReportModel> GetHarvesterReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.ReportModel.ReportModel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetHarvesterReport(context, start, end, ref errorMessage);
                    result = selectText.OrderBy(c => c.PersonPost_Brigade_Name).ThenBy(c => c.PersonPost_Person_FullName).ToList();
                }
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


        public static DataTable GetHarvesterReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            DataTable test = null;
            try
            {
                List<Data.Employees.XClasses.ReportModel.ReportModel>  result = GetHarvesterReport(start, end, ref errorMessage);

                result.RemoveAll(c => c.NetWeight == 0 && c.Punishment_Count == 0);

                var pun = GetPunishmentCount(start, end, ref errorMessage);

                var pivotArray =
                        pun.ToPivotArray(
                            item => item.Punishment_Name,
                            item => item.PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Punishment_Count) : 0);

                List<string> calculatedColumnNames = pun.Select(d => d.Punishment_Name).Distinct().ToList();

                var New = (from all in result
                           join piv in pivotArray on all.PersonPost_Id equals piv.PersonPost_Id into gj
                           from x in gj.DefaultIfEmpty()
                           select new
                           {
                               ჯგუფის_სახელი = all.PersonPost_Brigade_Name,
                               სახელი = all.PersonPost_Person_FullName,
                               ბარკოდი = all.PersonPost_EmployeeBarCode,
                               თანამდებობა = all.PersonPost_Post_Name,
                               მოკრეფილი_პროდუქცია = all.NetWeight,
                               საშუალო_ნეტო = all.NetWeight_Average.ToString("0.000"),
                               Pivoted_Tables1 = x,
                               პერიოდი = all.Date
                           }).ToList();

                List<string> hideColumns = new List<string>() { "PersonPost_Id"};

                List<dynamic[]> pivotArraies = new List<dynamic[]>() { pivotArray };

                test = Pivot.GetPivotDataTable(calculatedColumnNames, New, pivotArraies, false, hideColumns);


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetHarvesterReportWhole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetHarvesterReportWhole()\n" + ex.Message;
                }
            }
            return test;
        }


        public static DataTable GetBrigadireReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            DataTable test = null;
            try
            {
                List<Data.Employees.XClasses.ReportModel.ReportModel> result = GetBrigadireReport(start, end, ref errorMessage);

                var pun = GetPunishmentCount(start, end, ref errorMessage);

                var pivotArray =
                        pun.ToPivotArray(
                            item => item.Punishment_Name,
                            item => item.PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Punishment_Count) : 0);


                var givenPun = GetGivenPunishmentCount(start, end, ref errorMessage);

                var pivotArray2 =
                        givenPun.ToPivotArray(
                            item => item.Recomendator_Punishment_Name,
                            item => item.Recomendator_PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Recomendator_Punishment_Count) : 0);

                List<string> calculatedColumnNames = pun.Select(d => d.Punishment_Name).Distinct().ToList();

                List<string> calculatedGivenColumnNames = givenPun.Select(d => d.Recomendator_Punishment_Name).Distinct().ToList();

                calculatedColumnNames.AddRange(calculatedGivenColumnNames);

                var New = (from all in result
                           join piv in pivotArray on all.PersonPost_Id equals piv.PersonPost_Id into gj
                           from x in gj.DefaultIfEmpty()
                           join giv in pivotArray2 on all.PersonPost_Id equals giv.Recomendator_PersonPost_Id into gl
                           from c in gl.DefaultIfEmpty()
                           select new
                           {
                               ჯგუფის_სახელი = all.PersonPost_Brigade_Name,
                               სახელი = all.PersonPost_Person_FullName,
                               ბარკოდი = all.PersonPost_EmployeeBarCode,
                               თანამდებობა = all.PersonPost_Post_Name,
                               მოკრეფილი_პროდუქცია = all.NetWeight,
                               Pivoted_Tables1 = x,
                               Pivoted_Tables2 = c,
                               პერიოდი = all.Date
                           }).ToList();

                List<string> hideColumns = new List<string>() { "PersonPost_Id", "Recomendator_PersonPost_Id" };


                List<dynamic[]> pivotArraies = new List<dynamic[]>() { pivotArray, pivotArray2};

                test = Pivot.GetPivotDataTable(calculatedColumnNames, New, pivotArraies, false, hideColumns);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetBrigadireReportWhole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetBrigadireReportWhole()\n" + ex.Message;
                }
            }
            return test;
        }

        public static DataTable GetPackagerReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            DataTable test = null;
            try
            {
                List<Data.Employees.XClasses.ReportModel.ReportModel> result = GetPackagerReport(start, end, ref errorMessage);

                var pun = GetPunishmentCount(start, end, ref errorMessage);

                var pivotArray =
                        pun.ToPivotArray(
                            item => item.Punishment_Name,
                            item => item.PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Punishment_Count) : 0);

                List<string> calculatedColumnNames = pun.Select(d => d.Punishment_Name).Distinct().ToList();

                var New = (from all in result
                           join piv in pivotArray on all.PersonPost_Id equals piv.PersonPost_Id into gj
                           from x in gj.DefaultIfEmpty()
                           select new
                           {
                               ჯგუფის_სახელი = all.PersonPost_Brigade_Name,
                               სახელი = all.PersonPost_Person_FullName,
                               ბარკოდი = all.PersonPost_EmployeeBarCode,
                               თანამდებობა = all.PersonPost_Post_Name,
                               მოკრეფილი_პროდუქცია = all.NetWeight,
                               Pivoted_Tables1 = x,
                               პერიოდი = all.Date
                           }).ToList();

                List<string> hideColumns = new List<string>() { "PersonPost_Id" };

                List<dynamic[]> pivotArraies = new List<dynamic[]>() { pivotArray };

                test = Pivot.GetPivotDataTable(calculatedColumnNames, New, pivotArraies, false, hideColumns);


            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPackagerReportWhole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPackagerReportWhole()\n" + ex.Message;
                }
            }
            return test;
        }

        public static DataTable GetRecieverReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            DataTable test = null;
            try
            {
                List<Data.Employees.XClasses.ReportModel.ReportModel> result = GetRecieverReport(start, end, ref errorMessage);

                var pun = GetPunishmentCount(start, end, ref errorMessage);

                var pivotArray =
                        pun.ToPivotArray(
                            item => item.Punishment_Name,
                            item => item.PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Punishment_Count) : 0);

                var recPun = GetRecomPunishmentCount(start, end, ref errorMessage);

                var pivotArray2 =
                        recPun.ToPivotArray(
                            item => item.Recomendator_Punishment_Name,
                            item => item.Recomendator_PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Recomendator_Punishment_Count) : 0);

                List<string> calculatedColumnNames = pun.Select(d => d.Punishment_Name).Distinct().ToList();

                List<string> calculatedGivenColumnNames = recPun.Select(d => d.Recomendator_Punishment_Name).Distinct().ToList();

                calculatedColumnNames.AddRange(calculatedGivenColumnNames);

                var New = (from all in result
                           join piv in pivotArray on all.PersonPost_Id equals piv.PersonPost_Id into gj
                           from x in gj.DefaultIfEmpty()
                           join rec in pivotArray2 on all.PersonPost_Id equals rec.Recomendator_PersonPost_Id into gl
                           from c in gl.DefaultIfEmpty()
                           select new
                           {
                               ჯგუფის_სახელი = all.PersonPost_Brigade_Name,
                               სახელი = all.PersonPost_Person_FullName,
                               ბარკოდი = all.PersonPost_EmployeeBarCode,
                               თანამდებობა = all.PersonPost_Post_Name,
                               მიღებული_პროდუქცია = all.NetWeight,
                               Pivoted_Tables1 = x,
                               Pivoted_Tables2 = c,
                               პერიოდი = all.Date
                           }).ToList();

                List<string> hideColumns = new List<string>() { "PersonPost_Id", "Recomendator_PersonPost_Id" };


                List<dynamic[]> pivotArraies = new List<dynamic[]>() { pivotArray, pivotArray2 };

                test = Pivot.GetPivotDataTable(calculatedColumnNames, New, pivotArraies, false, hideColumns);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRecieverReportWhole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRecieverReportWhole()\n" + ex.Message;
                }
            }
            return test;
        }

        public static DataTable GetControliorReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            DataTable test = null;
            try
            {
                List<Data.Employees.XClasses.ReportModel.ReportModel> result = GetControliorReport(start, end, ref errorMessage);

                var pun = GetPunishmentCount(start, end, ref errorMessage);

                var pivotArray =
                        pun.ToPivotArray(
                            item => item.Punishment_Name,
                            item => item.PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Punishment_Count) : 0);

                var recPun = GetRecomPunishmentCount(start, end, ref errorMessage);

                var pivotArray2 =
                        recPun.ToPivotArray(
                            item => item.Recomendator_Punishment_Name,
                            item => item.Recomendator_PersonPost_Id,
                            items => items.Any() ? items.Sum(x => x.Recomendator_Punishment_Count) : 0);

                List<string> calculatedColumnNames = pun.Select(d => d.Punishment_Name).Distinct().ToList();

                List<string> calculatedGivenColumnNames = recPun.Select(d => d.Recomendator_Punishment_Name).Distinct().ToList();

                calculatedColumnNames.AddRange(calculatedGivenColumnNames);

                var New = (from all in result
                           join piv in pivotArray on all.PersonPost_Id equals piv.PersonPost_Id into gj
                           from x in gj.DefaultIfEmpty()
                           join rec in pivotArray2 on all.PersonPost_Id equals rec.Recomendator_PersonPost_Id into gl
                           from c in gl.DefaultIfEmpty()
                           select new
                           {
                               ჯგუფის_სახელი = all.PersonPost_Brigade_Name,
                               სახელი = all.PersonPost_Person_FullName,
                               ბარკოდი = all.PersonPost_EmployeeBarCode,
                               თანამდებობა = all.PersonPost_Post_Name,
                               მიღებული_პროდუქცია = all.NetWeight,
                               Pivoted_Tables1 = x,
                               Pivoted_Tables2 = c,
                               პერიოდი = all.Date
                           }).ToList();

                List<string> hideColumns = new List<string>() { "PersonPost_Id", "Recomendator_PersonPost_Id" };


                List<dynamic[]> pivotArraies = new List<dynamic[]>() { pivotArray, pivotArray2 };

                test = Pivot.GetPivotDataTable(calculatedColumnNames, New, pivotArraies, false, hideColumns);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetControliorReportWhole()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetControliorReportWhole()\n" + ex.Message;
                }
            }
            return test;
        }


        public static List<XClasses.EmployeeLabel> GetEmployeeLabels(List<long> employeePostIds, ref string errorMessage)
        {
            List<XClasses.EmployeeLabel> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetEmployeeLabels(context, employeePostIds, ref errorMessage);
                    result = selectText.ToList<XClasses.EmployeeLabel>();
                }
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

        public static List<Data.Post> GetPostById(long? postId,
                                       ref string errorMessage)
        {
            List<Data.Post> result = null;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                var selectText = SelectQ.GetPostById(context, postId, ref errorMessage);
                result = selectText.ToList();
            }
            return result;
        }

        public static List<Data.Employees.XClasses.PunishmentModel> GetPunishment(long? personID, long? userPersonPostId, ref string errorMessage)
        {
            List<Data.Employees.XClasses.PunishmentModel> result = null;
            try {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                        var selectText = SelectQ.GetPunishment(context, personID, userPersonPostId, ref errorMessage);
                        result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishment()\n" + ex.Message;
                }
            }
            return result;
        }


        public static List<Data.Employees.XClasses.PunishmentModel> GetPunishmentByDite(long? personID, DateTime start, DateTime end, ref string errorMessage)
        {
            List<Data.Employees.XClasses.PunishmentModel> result = null;
            try
            {

                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPunishmentByDite(context, personID, start, end, ref errorMessage);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {

                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPunishment()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPunishment()\n" + ex.Message;
                }
            }
            return result;
        }




    }
}
