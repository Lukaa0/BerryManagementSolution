using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Template
{
    public static class Update
    {
        public static void UpdateDocumentTemplate(Data.DocumentTemplate documentTemplate,
            Data.DocumentTemplateTitle documentTemplateTitle, ref string errorMessage)
        {
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        DocumentTemplateTitle documentTemplateTitleT = context.DocumentTemplateTitles.Where(d =>
                            d.DocumentTemplateTitleDocumentTemplateId == documentTemplateTitle.DocumentTemplateTitleDocumentTemplateId).FirstOrDefault();
                        documentTemplateTitleT.DocumentTemplateTitleDescription = documentTemplateTitle.DocumentTemplateTitleDescription;
                        documentTemplateTitleT.DocumentTemplateTitleExtension = documentTemplateTitle.DocumentTemplateTitleExtension;
                        if (documentTemplate != null)
                        {
                            DocumentTemplate documentTemplateT = context.DocumentTemplates.Where(d =>
                                d.DocumentTemplateId == documentTemplate.DocumentTemplateId).FirstOrDefault();
                            documentTemplateT.DocumentTemplateData = documentTemplate.DocumentTemplateData;
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
