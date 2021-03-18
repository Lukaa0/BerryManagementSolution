using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Employees
{
    class Insert
    {

        public static void InsertEmployee(ref Person Employee, ref String errorMessage)
        {
            try
            {
                if (Employee != null)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        using (System.Data.Entity.DbContextTransaction dbContextTransaction = context.Database.BeginTransaction())
                        {
                            try
                            {
                                // დავამატოთ ჩანაწერი
                                context.Persons.Add(Employee);
                                context.SaveChanges();
                                // დავამატოთ იგივე ისტორიაშიც
                                //InsertEmployeesHistory(inEmployee, 1, inUserId);
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
                    errorMessage = "InsertEmployee()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nInsertEmployee()\n" + ex.Message;
                }
            }
        }

        public static void InsertPersonDocument(ref PersonDocument PersonDocument, ref string ErrorMessage)
        {
            try
            {
                
                if (PersonDocument != null )
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {
                        
                            try
                            {
                                // დავამატოთ ჩანაწერი
                                context.PersonDocuments.Add(PersonDocument);
                                context.SaveChanges();
                                // წარმატება. დავასრულოთ ტრანზაქცია
                            }
                            catch (Exception ex)
                            {
                                
                                // ავწიოთ ზევით ავარიული შეტყობინება
                                throw new Exception(ex.Message);
                            }
                        
                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: InsertPersonDocument()\n" + "ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message;
            }
        }

        public static void InsertPersonPost(ref PersonPost personPost, ref string ErrorMessage)
        {
            try
            {

                if (personPost != null)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {

                        try
                        {
                            // დავამატოთ ჩანაწერი
                            context.PersonPosts.Add(personPost);
                            context.SaveChanges();
                            // წარმატება. დავასრულოთ ტრანზაქცია
                        }
                        catch (Exception ex)
                        {

                            // ავწიოთ ზევით ავარიული შეტყობინება
                            throw new Exception(ex.Message);
                        }

                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: InsertPersonPost()\n" + "ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message;
            }
        }


        public static void InsertPunishment(Punishment punishment, ref string ErrorMessage)
        {
            try
            {

                if (punishment != null)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {

                        try
                        {
                            punishment.Punishment_Id = Guid.NewGuid();
                            // დავამატოთ ჩანაწერი
                            context.Punishments.Add(punishment);
                            context.SaveChanges();
                            // წარმატება. დავასრულოთ ტრანზაქცია
                        }
                        catch (Exception ex)
                        {
                            // ავწიოთ ზევით ავარიული შეტყობინება
                            throw new Exception(ex.Message);
                        }

                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: InsertPunishment()\n" + "ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message;
            }
        }


        public static void InsertPunishmentForAndroid(Punishment punishment,string barcode, ref string ErrorMessage)
        {
            try
            {

                if (punishment != null)
                {
                    using (BerryManagementEntities context = new BerryManagementEntities())
                    {

                        try
                        {
                            punishment.Punishment_Id = Guid.NewGuid();
                            if (punishment.Punishment_RecomenderUser_PersonPost_Id != null)
                            {
                                // დავამატოთ ჩანაწერი
                                context.Punishments.Add(punishment);
                                context.SaveChanges();
                                // წარმატება. დავასრულოთ ტრანზაქცია
                            }
                            else
                            {
                                var check = context.ProductPacks.Where(c => c.ProductPack_Container_BarCode == barcode && c.ProductPack_Out_DateTime == null && c.ProductPack_Out_ProductPackInOut_Id == null && c.ProductPack_Out_User_PersonPost_Id == null).FirstOrDefault();
                                if(check != null)
                                     punishment.Punishment_RecomenderUser_PersonPost_Id = check.ProductPack_In_User_PersonPost_Id;

                                context.Punishments.Add(punishment);
                                context.SaveChanges();
                            }

                        }
                        catch (Exception ex)
                        {
                            // ავწიოთ ზევით ავარიული შეტყობინება
                            throw new Exception(ex.Message);
                        }

                    }
                }
                else
                    throw new Exception("მითითებული ჩანაწერი/მომხმარებელი არავალიდურია");
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(ErrorMessage))
                    ErrorMessage = "მეთოდი: InsertPunishmentForAndroid()\n" + "ჩანაწერის დაფიქსირება ვერ მოხერხდა:\n" + ex.Message;
            }
        }

    }
}

