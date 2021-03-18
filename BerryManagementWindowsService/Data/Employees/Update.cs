using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees
{
    class Update
    {
        /// <summary>
        /// თანამშრომლის ჩანაწერის განახლება
        /// </summary>
        /// <param name="inEmployee"></param>
        /// <param name="inUserId"></param>
        public static void UpdateEmployee(Person Employee, long PersonId, ref String errorMessage)
        {
            try
            {
                if (Employee != null && PersonId != 0)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        Person employee = context.Persons.Where(e => e.Person_Id == Employee.Person_Id).FirstOrDefault();
                        if (employee != null)
                        {
                            using (System.Data.Entity.DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                            {
                                try
                                {

                                    // დავარედაქტიროთ ჩანაწერი
                                    employee.Person_Address1 = Employee.Person_Address1;
                                    employee.Person_Address2 = Employee.Person_Address2;
                                    employee.Person_BankAccount = Employee.Person_BankAccount;
                                    employee.Person_BankClientName = Employee.Person_BankClientName;
                                    employee.Person_Bank_Id = Employee.Person_Bank_Id;
                                    employee.Person_BirthDate = Employee.Person_BirthDate;
                                    employee.Person_Citizenship_Id = Employee.Person_Citizenship_Id;
                                    employee.Person_Code = Employee.Person_Code;
                                    employee.Person_Description = Employee.Person_Description;
                                    employee.Person_DrivingLicense = Employee.Person_DrivingLicense;
                                    employee.Person_FirstName = Employee.Person_FirstName;
                                    employee.Person_GenderType_Id = Employee.Person_GenderType_Id;
                                    employee.Person_Identity = Employee.Person_Identity;
                                    employee.Person_IsResident = Employee.Person_IsResident;
                                    employee.Person_LastName = Employee.Person_LastName;
                                    employee.Person_LegalForm_Id = Employee.Person_LegalForm_Id;
                                    employee.Person_LegalStatuseType_Id = Employee.Person_LegalStatuseType_Id;
                                    employee.Person_MailAddress = Employee.Person_MailAddress;
                                    employee.Person_MaritalStatus_Id = Employee.Person_MaritalStatus_Id;
                                    employee.Person_Nationality_Id = Employee.Person_Nationality_Id;
                                    employee.Person_Phone1 = Employee.Person_Phone1;
                                    employee.Person_Phone2 = Employee.Person_Phone2;
                                    employee.Person_SideType_Id = Employee.Person_SideType_Id;


                                    context.SaveChanges();
                                    // დავამატოთ იგივე ისტორიაშიც
                                    //Insert.InsertEmployeesHistory(employee, 2, inUserId);
                                    // წარმატება. დავასრულოთ ტრანზაქცია
                                    dbContextTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    // ავარია. გავაუქმოთ ტრანზაქცია
                                    dbContextTransaction.Rollback();
                                    // ავწიოთ ზევით ავარიული შეტყობინება
                                    throw new Exception(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("შესაცვლელი ჩანაწერის მოძიება ვერ მოხერხდა!");
                        }
                    }
                }
                else
                {
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "UpdateEmployee\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nUpdateEmployee\n" + ex.Message;
                }
            }
        }

        public static void UpdatePersonDocument(PersonDocument PersonDocument, ref string ErrorMessage)
        {
            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                ErrorMessage = System.String.Empty;

                if (PersonDocument != null )
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        PersonDocument personDocument = context.PersonDocuments.Where(pD => pD.PersonDocument_Id == PersonDocument.PersonDocument_Id).FirstOrDefault();
                        if (personDocument != null)
                        {
                            using (System.Data.Entity.DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                            {
                                try
                                {
                                    personDocument.PersonDocument_Id = PersonDocument.PersonDocument_Id;
                                    personDocument.PersonDocument_StartDate = PersonDocument.PersonDocument_StartDate;
                                    personDocument.PersonDocument_FirstName = PersonDocument.PersonDocument_FirstName;
                                    personDocument.PersonDocument_LastName = PersonDocument.PersonDocument_LastName;
                                    personDocument.PersonDocument_EndDate = PersonDocument.PersonDocument_EndDate;
                                    personDocument.PersonDocument_Number = PersonDocument.PersonDocument_Number;
                                    personDocument.PersonDocument_Isuer = PersonDocument.PersonDocument_Isuer;
                                    personDocument.PersonDocument_Person_Id = PersonDocument.PersonDocument_Person_Id;
                                    personDocument.PersonDocument_DocumentType_Id = PersonDocument.PersonDocument_DocumentType_Id;
                                    personDocument.PersonDocument_Citizenship_Id = PersonDocument.PersonDocument_Citizenship_Id;
                                    personDocument.PersonDocument_Description = PersonDocument.PersonDocument_Description;



                                    // დავარედაქტიროთ ჩანაწერი
                                    context.SaveChanges();
                                    // დავამატოთ იგივე ისტორიაშიც
                                    //Insert.InsertPersonDocumentsHistory(inPersonDocument, 2, inUserId, ref inoutErrorMessage);
                                    // წარმატება. დავასრულოთ ტრანზაქცია
                                    dbContextTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    // ავარია. გავაუქმოთ ტრანზაქცია
                                    dbContextTransaction.Rollback();
                                    // ავწიოთ ზევით ავარიული შეტყობინება
                                    throw new Exception(ex.Message);
                                }
                            }
                        }
                        else
                            throw new Exception("შესაცვლელი ჩანაწერის მოძიება ვერ მოხერხდა!");
                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: UpdatePersonDocument()\n" + "ჩანაწერის შეცვლა ვერ მოხერხდა:\n" + ex.Message;
            }
        }

        public static void UpdatePersonPost(PersonPost personPost, long PersonId, ref String errorMessage)
        {
            try
            {
                if (personPost != null && PersonId != 0)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        PersonPost personPoste = context.PersonPosts.Where(e => e.PersonPost_Id == personPost.PersonPost_Id).FirstOrDefault();
                        if (personPost != null)
                        {
                            using (System.Data.Entity.DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                            {
                                try
                                {

                                    // დავარედაქტიროთ ჩანაწერი
                                    personPoste.PersonPost_EmployeeBarCode = personPost.PersonPost_EmployeeBarCode;
                                    personPoste.PersonPost_BalanceSheetType_Id = personPost.PersonPost_BalanceSheetType_Id;
                                    personPoste.PersonPost_EmployeeType_Id = personPost.PersonPost_EmployeeType_Id;
                                    personPoste.PersonPost_Person_Id = personPost.PersonPost_Person_Id;
                                    personPoste.PersonPost_Post_Id = personPost.PersonPost_Post_Id;
                                    personPoste.PersonPost_Post_BarCodePrefix = personPost.PersonPost_Post_BarCodePrefix;
                                    personPoste.PersonPost_Brigade_Id = personPost.PersonPost_Brigade_Id;
                                    personPoste.PersonPost_StartDate = personPost.PersonPost_StartDate;
                                    personPoste.PersonPost_EndDate = personPost.PersonPost_EndDate;
                                    personPoste.PersonPost_DismissalOrder = personPost.PersonPost_DismissalOrder;
                                    personPoste.PersonPost_Description = personPost.PersonPost_Description;


                                    context.SaveChanges();
                                    
                                    dbContextTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    // ავარია. გავაუქმოთ ტრანზაქცია
                                    dbContextTransaction.Rollback();
                                    // ავწიოთ ზევით ავარიული შეტყობინება
                                    throw new Exception(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("შესაცვლელი ჩანაწერის მოძიება ვერ მოხერხდა!");
                        }
                    }
                }
                else
                {
                    throw new Exception("მითითებული ჩანაწერი არავალიდურია");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "UpdatePersonPost\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nUpdatePersonPost\n" + ex.Message;
                }
            }
        }

        public static void UpdatePunishment(Punishment punishment,ref String errorMessage)
        {
            try
            {
                if (punishment != null)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        Punishment Punishment = context.Punishments.Where(e => e.Punishment_Id== punishment.Punishment_Id).FirstOrDefault();
                        if (punishment != null)
                        {
                            using (System.Data.Entity.DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                            {
                                try
                                {

                                    // დავარედაქტიროთ ჩანაწერი
                                    Punishment.Punishment_Id = Punishment.Punishment_Id;
                                    Punishment.Punishment_PersonPost_Id = punishment.Punishment_PersonPost_Id;
                                    Punishment.Punishment_PunishmentType_Id = punishment.Punishment_PunishmentType_Id;
                                    Punishment.Punishment_User_PersonPost_Id = punishment.Punishment_User_PersonPost_Id;
                                    Punishment.Punishment_DateTime = punishment.Punishment_DateTime;
                                    Punishment.Punishment_Description = punishment.Punishment_Description;

                                    context.SaveChanges();

                                    dbContextTransaction.Commit();
                                }
                                catch (Exception ex)
                                {
                                    // ავარია. გავაუქმოთ ტრანზაქცია
                                    dbContextTransaction.Rollback();
                                    // ავწიოთ ზევით ავარიული შეტყობინება
                                    throw new Exception(ex.Message);
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("შესაცვლელი ჩანაწერის მოძიება ვერ მოხერხდა!");
                        }
                    }
                }
                else
                {
                    throw new Exception("მითითებული ჩანაწერი არავალიდურია");
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "UpdatePunishment\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nUpdatePunishment\n" + ex.Message;
                }
            }
        }
    }
}
