using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Template
{
    public static class Insert
    {
        public static long InsertDocumentTemplate(Data.DocumentTemplateTitle documentTemplateTitle,
            Data.DocumentTemplate documentTemplate, ref string errorMessage)
        {
            long result = 0;
            using (BerryManagementEntities context = new BerryManagementEntities())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.DocumentTemplates.Add(documentTemplate);
                        context.SaveChanges();
                        documentTemplateTitle.DocumentTemplateTitleDocumentTemplateId = documentTemplate.DocumentTemplateId;
                        context.DocumentTemplateTitles.Add(documentTemplateTitle);
                        context.SaveChanges();
                        dbContextTransaction.Commit();
                        result = documentTemplate.DocumentTemplateId;
                    }
                    catch (Exception ex)
                    {
                        dbContextTransaction.Rollback();
                        if (System.String.IsNullOrEmpty(errorMessage))
                        {
                            errorMessage = "ჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentTemplate()\n" + ex.Message;
                        }
                        else
                        {
                            errorMessage = errorMessage + "\nჩანაწერის დაფიქსირება ვერ მოხერხდა: InsertDocumentTemplate()\n" + ex.Message;
                        }
                    }
                }
            }
            return result;
        }
    }
}
