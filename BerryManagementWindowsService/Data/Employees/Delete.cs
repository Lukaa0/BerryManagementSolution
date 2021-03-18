using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees
{
    class Delete
    {
        /// <summary>
        /// თანამშრომლის ჩანაწერის წაშლა
        /// </summary>
        /// <param name="inEmployee"></param>
        /// <param name="inUserId"></param>
        public static void DeletePerson(Person inEmployee, long inUserId, ref String errorMessage)
        {
            Person dEmployee = null;

            try
            {
                if (inEmployee != null && inUserId != 0)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        dEmployee = context.Persons.Where(e => e.Person_Id == inEmployee.Person_Id).ToList().FirstOrDefault();
                        if (dEmployee != null)
                        {
                            // ჩავრთოთ ტრანზაქცია
                            context.Database.BeginTransaction();
                            try
                            {
                                // წავშალოთ ჩანაწერი
                                context.Persons.Remove(dEmployee);
                                context.SaveChanges();
                                // დავამატოთ წაშლილი ჩანაწერი ისტორიაში
                                //Insert.InsertEmployeesHistory(dEmployee, 3, inUserId);
                                // წარმატება. დავასრულოთ ტრანზაქცია
                                context.Database.CurrentTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                // ავარია. გავაუქმოთ ტრანზაქცია
                                context.Database.CurrentTransaction.Rollback();
                                // ავწიოთ ზევით ავარიული შეტყობინება
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                            }
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
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeletePerson()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeletePerson()\n" + ex.Message;
                }
            }
        }
        public static void DeletePersonDocument(PersonDocument PersonDocument, ref string ErrorMessage)
        {
            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                ErrorMessage = System.String.Empty;

                if (PersonDocument != null)
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
                                    // წავშალოთ ჩანაწერი
                                    context.PersonDocuments.Remove(personDocument);
                                    context.SaveChanges();
                                    // დავამატოთ წაშლილი ჩანაწერი ისტორიაში
                                    //Insert.InsertPersonDocumentsHistory(personDocument, 3, inUserId, ref inoutErrorMessage);
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
                            throw new Exception("წასაშლელი ჩანაწერის მოძიება ვერ მოხერხდა!");
                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: DeletePersonDocument()\n" + "ჩანაწერის წაშლა ვერ მოხერხდა:\n" + ex.Message;
            }
        }
        public static void DeletePersonPost(PersonPost personPost , long person_Id, ref String errorMessage)
        {
            PersonPost personPoste = null;

            try
            {
                if (personPost != null && person_Id != 0)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        personPoste = context.PersonPosts.Where(e => e.PersonPost_Id==personPost.PersonPost_Id).ToList().FirstOrDefault();
                        if (personPoste != null)
                        {
                            // ჩავრთოთ ტრანზაქცია
                            context.Database.BeginTransaction();
                            try
                            {
                                // წავშალოთ ჩანაწერი
                                context.PersonPosts.Remove(personPoste);
                                context.SaveChanges();
                                // დავამატოთ წაშლილი ჩანაწერი ისტორიაში
                                //Insert.InsertEmployeesHistory(dEmployee, 3, inUserId);
                                // წარმატება. დავასრულოთ ტრანზაქცია
                                context.Database.CurrentTransaction.Commit();
                            }
                            catch (Exception ex)
                            {
                                // ავარია. გავაუქმოთ ტრანზაქცია
                                context.Database.CurrentTransaction.Rollback();
                                // ავწიოთ ზევით ავარიული შეტყობინება
                                throw new Exception(ex.Message);
                            }
                            finally
                            {
                            }
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
                    errorMessage = "ჩანაწერის წაშლა ვერ მოხერხდა: DeletePersonPost()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის წაშლა ვერ მოხერხდა: DeletePersonPost()\n" + ex.Message;
                }
            }
        }
    }
}

