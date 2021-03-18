using BerryManagementWindowsService.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.Text;
using System.Xml.Serialization;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Employee_Service" in both code and config file together.
    public class BM_Employee_Service : IBM_Employee_Service
    {
        //serializaciisatvis
        public static string ByteArrayToStr(byte[] barr)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(barr, 0, barr.Length);
        }

        public int GetNumberOfEmployeeSameIdentities(string inEmployeeIdentity, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetNumberOfEmployeeSameIdentities(inEmployeeIdentity, ref errorMessage);
        }

        public void DeletePerson(Data.Person inEmployee, long inUserId, ref String errorMessage)
        {
            Data.Employees.Delete.DeletePerson(inEmployee, inUserId, ref errorMessage);
        }

        public string GetEmployeeCurrentName(long inEmployeeId, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetEmployeeCurrentName(inEmployeeId, ref errorMessage);
        }

        public void UpdateEmployee(Data.Person Employee, long PersonId, ref String errorMessage)
        {
            Data.Employees.Update.UpdateEmployee(Employee, PersonId, ref errorMessage);
        }

        public void InsertEmployee(ref Data.Person Employee,  ref String errorMessage)
        {
            Data.Employees.Insert.InsertEmployee(ref Employee, ref errorMessage);
        }
        public List<Data.Person> GetEmployeeShortData(long? EmployeeId, string EmployeeIdentity, string FirstName, string LastName, long? code, long? postId,bool isFirstUse, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetEmployeeShortData(EmployeeId,EmployeeIdentity,FirstName,LastName,code, postId,isFirstUse, ref errorMessage);
        }
        public  List<Data.Employees.XClasses.PersonPostModel> GetHarvByHarvRowDistrOutsByRowId(bool Direction, long? brigadeId, long? rowId, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetHarvByHarvRowDistrOutsByRowId(Direction, brigadeId, rowId, ref errorMessage);
        }

        public List<Data.RS.XClasses.RS_ProductModel> GetRS_ProductModelByContainers(DateTime Start, DateTime End, int productOwnerStatus, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetRS_ProductModelByContainers(Start, End, productOwnerStatus, null, ref errorMessage);
        }
        public  List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetGivenPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetGivenPunishmentCount(start, end, ref errorMessage);
        }
        public List<Data.Employees.XClasses.ReportModel.RecPunishmentCountModel> GetRecomPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetRecomPunishmentCount(start, end, ref errorMessage);
        }
        public List<Data.Employees.XClasses.ReportModel.PunishmentCountModel> GetPunishmentCount(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPunishmentCount(start, end, ref errorMessage);
        }

        public List<Data.Employees.XClasses.ReportModel.GeneralReportModel> GetGeneralReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetGeneralReport(start, end, ref errorMessage);
        }

        public List<Data.Employees.XClasses.ReportModel.WeightsModelcs> GetBrigadeWeight(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetBrigadeWeight(start, end, ref errorMessage);

        }
        public List<Data.Employees.XClasses.ReportModel.ReportModel> GetBrigadireReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetBrigadireReport(start, end, ref errorMessage);
        } 
        public List<Data.Employees.XClasses.ReportModel.ReportModel> GetPackagerReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPackagerReport(start, end, ref errorMessage);
        }
        public List<Data.Employees.XClasses.ReportModel.ReportModel> GetControliorReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetControliorReport(start, end, ref errorMessage);
        }
        public List<Data.Employees.XClasses.ReportModel.ReportModel> GetRecieverReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetRecieverReport(start, end, ref errorMessage);
        }
        public List<Data.Employees.XClasses.ReportModel.ReportModel> GetHarvesterReport(DateTime? start, DateTime? end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetHarvesterReport(start, end, ref errorMessage);
        }
        public byte[] GetHarvesterReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            try
            {
                //Serialize
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                var dt = Data.Employees.SelectL.GetHarvesterReportWhole(start, end, ref errorMessage);
                string s;
                bformatter.Serialize(stream, dt);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] GetBrigadireReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            try
            {
                //Serialize
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                var dt = Data.Employees.SelectL.GetBrigadireReportWhole(start, end, ref errorMessage);
                string s;
                bformatter.Serialize(stream, dt);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] GetPackagerReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            try
            {
                //Serialize
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                var dt = Data.Employees.SelectL.GetPackagerReportWhole(start, end, ref errorMessage);
                string s;
                bformatter.Serialize(stream, dt);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        public byte[] GetRecieverReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            try
            {
                //Serialize
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                var dt = Data.Employees.SelectL.GetRecieverReportWhole(start, end, ref errorMessage);
                string s;
                bformatter.Serialize(stream, dt);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public byte[] GetControliorReportWhole(DateTime? start, DateTime? end, ref string errorMessage)
        {
            try
            {
                //Serialize
                BinaryFormatter bformatter = new BinaryFormatter();
                MemoryStream stream = new MemoryStream();

                var dt = Data.Employees.SelectL.GetControliorReportWhole(start, end, ref errorMessage);
                string s;
                bformatter.Serialize(stream, dt);
                byte[] b = stream.ToArray();
                s = ByteArrayToStr(b);
                stream.Close();
                return b;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        #region AndroidApp
        public List<Data.Employees.XClasses.PersonPostModel> GetHarvesterByHRDForPunishment(ref string errorMessage)
        {
            return Data.Employees.SelectL.GetHarvesterByHRDForPunishment( ref errorMessage);
        }
        public  List<Data.Employees.XClasses.PersonPostModel> GetHarvByHarvRowDistrOuts(bool Direction, long? brigadeId, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetHarvByHarvRowDistrOuts(Direction, brigadeId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsForPunishment(ref String errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostsForPunishment(ref errorMessage);
        }
        #endregion
        public List<Data.PersonPost> GetPersonPostsIdByPersonId(long personID, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostsIdByPersonId(personID, ref errorMessage);
        }
            public List<Data.Employees.XClasses.PersonDocumentModel> GetPersonDocuments(System.Nullable<long> PersonDocumentId,
                                                       System.Nullable<long> userId,
                                                       string userName,
                                                       System.Nullable<long> PersonDocumentEmployeeId,
                                                       System.Nullable<long> inrsonDocumentDocumentTypeId,
                                                       System.Nullable<long> PersonDocumentCitizenshipId,
                                                       System.Nullable<DateTime> PersonDocumentStartDate,
                                                       System.Nullable<DateTime> PersonDocumentEndDate,
                                                       ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPersonDocuments(PersonDocumentId,
                                                        userId,
                                                       userName,
                                                       PersonDocumentEmployeeId,
                                                       inrsonDocumentDocumentTypeId,
                                                       PersonDocumentCitizenshipId,
                                                       PersonDocumentStartDate,
                                                       PersonDocumentEndDate,
                                                       ref errorMessage);
        }

        public void UpdatePersonDocument(Data.PersonDocument PersonDocument, ref string inoutErrorMessage)
        {
            Data.Employees.Update.UpdatePersonDocument(PersonDocument,  ref inoutErrorMessage);
        }

        public void DeletePersonDocument(Data.PersonDocument PersonDocument,  ref string ErrorMessage)
        {
            Data.Employees.Delete.DeletePersonDocument(PersonDocument,  ref ErrorMessage);
        }
        public void InsertPersonDocument(ref PersonDocument PersonDocument, ref string ErrorMessage)
        {
            Data.Employees.Insert.InsertPersonDocument(ref PersonDocument, ref ErrorMessage);
        }

        public  List<Data.PersonPost> GetPersonPostData(long? personPost_Id, long? Person_Id, long? Post_Id, string employeeBarCode, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostData(personPost_Id, Person_Id, Post_Id, employeeBarCode, ref errorMessage);
        }

        public void InsertPersonPost(ref PersonPost personPost, ref string ErrorMessage)
        {
            Data.Employees.Insert.InsertPersonPost(ref personPost, ref ErrorMessage);
        }

        public void DeletePersonPost(PersonPost personPost, long person_Id, ref String errorMessage)
        {
            Data.Employees.Delete.DeletePersonPost(personPost, person_Id, ref errorMessage);
        }

        public void UpdatePersonPost(PersonPost personPost, long PersonId, ref String errorMessage)
        {
            Data.Employees.Update.UpdatePersonPost(personPost, PersonId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModel(
                                              System.Nullable<long> PersonPost_PersonId,
                                              ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostModel(PersonPost_PersonId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PersonPostModel> GetPersonPostByPostId(long PostId, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostByPostId(PostId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PersonPostModel> GetPersonPostModelForRows(
                                              System.Nullable<long> BrigadeId,
                                              ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostModelForRows(BrigadeId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PersonPostModel> GetPersonPostsByBrigadeId( long? brigadeId, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostsByBrigadeId(brigadeId, ref errorMessage);
        }
        public  List<Data.Person> GetEmployeeData(string EmployeeIdentity, ref String errorMessage)
        {
            return Data.Employees.SelectL.GetEmployeeData(EmployeeIdentity, ref errorMessage);
        }

        public List<Data.Employees.XClasses.EmployeeLabel> GetEmployeeLabels(List<long> employeePostIds, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetEmployeeLabels(employeePostIds, ref errorMessage);
        }

        public List<Data.Post> GetPostById(long? postId, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPostById(postId, ref errorMessage);
        }

        public List<PersonPost> GetPersonPostByBarCode(string harvesterCode, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPersonPostByBarcode(harvesterCode, ref errorMessage);
        }

       

        #region punishment

        public List<Data.Employees.XClasses.PunishmentModel> GetPunishment(long? personID, long? userPersonPostId, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPunishment(personID,userPersonPostId, ref errorMessage);
        }

        public List<Data.Employees.XClasses.PunishmentModel> GetPunishmentByDite(long? personID, DateTime start, DateTime end, ref string errorMessage)
        {
            return Data.Employees.SelectL.GetPunishmentByDite(personID,start, end, ref errorMessage);
        }
        public void UpdatePunishment(Punishment punishment, ref String errorMessage)
        {
            Data.Employees.Update.UpdatePunishment(punishment, ref errorMessage);
        }

        public void InsertPunishment(Punishment punishment, ref string ErrorMessage)
        {
            Data.Employees.Insert.InsertPunishment(punishment, ref ErrorMessage);
        }

        public void InsertPunishmentForAndroid(Punishment punishment, string barcode, ref string ErrorMessage)
        {
            Data.Employees.Insert.InsertPunishmentForAndroid(punishment,barcode, ref ErrorMessage);
        }


        #endregion
    }
}
