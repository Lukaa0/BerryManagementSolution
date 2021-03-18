using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Template
{
    public static class Delete
    {
        public static void DeleteDocumentTemplate(long documentTemplateId, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Data.DocumentTemplateTitle documentTemplateTitle = context.DocumentTemplateTitles.Where(
                            d => d.DocumentTemplateTitleDocumentTemplateId == documentTemplateId).FirstOrDefault();
                        Data.DocumentTemplate documentTemplate = context.DocumentTemplates.Where(
                            d => d.DocumentTemplateId == documentTemplateId).FirstOrDefault();
                        if (documentTemplate != null && documentTemplateTitle != null)
                        {
                            context.DocumentTemplateTitles.Remove(documentTemplateTitle);
                            context.DocumentTemplates.Remove(documentTemplate);
                            context.SaveChanges();
                            dbContextTransaction.Commit();
                        }
                        else
                        {
                            throw new Exception("ჩანაწერის შეცვლა ვერ მოხერხდა!");
                        }
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateDocumentTemplate()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა:  UpdateDocumentTemplate()\n" + ex.Message;
                        }
                    }
                }
            }
        }
    }
}
