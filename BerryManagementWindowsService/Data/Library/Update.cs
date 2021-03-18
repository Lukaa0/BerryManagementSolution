using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Library
{
    class Update
    {
        public static void UpdateBank(Bank bank, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Bank bankT = context.Banks.Where(b => b.Bank_Id == bank.Bank_Id).FirstOrDefault();
                    if (bankT != null)
                    {
                        bankT.Bank_Kode = bank.Bank_Kode;
                        bankT.Bank_Name = bank.Bank_Name;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateBank()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateBank()\n" + ex.Message;
                }
            }
        }

        public static void UpdateNationality(Nationality nationality, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Nationality nationalityT = context.Nationalities.Where(n => n.Nationality_Id == nationality.Nationality_Id).FirstOrDefault();
                    if (nationalityT != null)
                    {
                        nationalityT.Nationality_Name = nationality.Nationality_Name;
                        nationalityT.Nationality_NameEn = nationality.Nationality_NameEn;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNationality()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateNationality()\n" + ex.Message;
                }
            }
        }

        public static void UpdateCitizenship(Citizenship citizenship, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Citizenship citizenshipT = context.Citizenships.Where(c => c.Citizenship_Id == citizenship.Citizenship_Id).FirstOrDefault();
                    if (citizenshipT != null)
                    {
                        citizenshipT.Citizenship_Name = citizenship.Citizenship_Name;
                        citizenshipT.Citizenship_NameEn = citizenship.Citizenship_NameEn;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateCitizenship()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateCitizenship()\n" + ex.Message;
                }
            }
        }

        public static void UpdateDocumentType(DocumentType documentType, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    DocumentType documentTypeT = context.DocumentTypes.Where(c => c.DocumentType_Id == documentType.DocumentType_Id).FirstOrDefault();
                    if (documentTypeT != null)
                    {
                        documentTypeT.DocumentType_Name = documentType.DocumentType_Name;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateDocumentType()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateDocumentType()\n" + ex.Message;
                }
            }
        }

        public static void UpdateLegalForm(LegalForm legalForm, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    LegalForm legalFormT = context.LegalForms.Where(p => p.LegalForm_Id == legalForm.LegalForm_Id).FirstOrDefault();
                    if (legalFormT != null)
                    {
                        legalFormT.LegalForm_Name = legalForm.LegalForm_Name;
                        legalFormT.LegalForm_NameEn = legalForm.LegalForm_NameEn;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateLegalForm()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateLegalForm()\n" + ex.Message;
                }
            }
        }

        public static void UpdateBreed(Breed breed, ref string errorMessage)
        {
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    Breed breedT = context.Breeds.Where(p => p.Breed_Id == breed.Breed_Id).FirstOrDefault();
                    if (breedT != null)
                    {
                        breedT.Breed_Name = breed.Breed_Name;
                        context.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateBreed()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateBreed()\n" + ex.Message;
                }
            }
        }

    }
}
