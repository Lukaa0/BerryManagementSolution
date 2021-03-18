using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library
{
    public static class Insert
    {
        public static long InsertBank(Bank bank, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Banks.Add(bank);
                    context.SaveChanges();
                    result = bank.Bank_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertBank()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertBank()\n" + ex.Message;
                }
            }
            return result;
        }

        public static void InsertContainers(List<Container> containers, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (DbContextTransaction transaction = context.Database.BeginTransaction())
                    try
                    {
                        context.Containers.AddRange(containers);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainer()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainer()\n" + ex.Message;
                        }
                    }
            }
        }

        public static long InsertNationality(Nationality nationality, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Nationalities.Add(nationality);
                    context.SaveChanges();
                    result = nationality.Nationality_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNationality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertNationality()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertCitizenship(Citizenship citizenship, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Citizenships.Add(citizenship);
                    context.SaveChanges();
                    result = citizenship.Citizenship_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertCitizenship()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertCitizenship()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertDocumentType(DocumentType documentType, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.DocumentTypes.Add(documentType);
                    context.SaveChanges();
                    result = documentType.DocumentType_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentType()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentType()\n" + ex.Message;
                }
            }
            return result;
        }

        public static string InsertContainer(Container container, ref string errorMessage)
        {
            string result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Containers.Add(container);
                    context.SaveChanges();
                    result = container.Container_BarCode;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainer()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertContainer()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertLegalForm(LegalForm legalForm, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.LegalForms.Add(legalForm);
                    context.SaveChanges();
                    result = legalForm.LegalForm_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertLegalForm()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertLegalForm()\n" + ex.Message;
                }
            }
            return result;
        }

        public static long InsertBreed(Breed breed, ref string errorMessage)
        {
            long result = 0;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    context.Breeds.Add(breed);
                    context.SaveChanges();
                    result = breed.Breed_Id;
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertBreed()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertBreed()\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
