using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Template
{
    public static class SelectQ
    {
        public static IQueryable<Data.DocumentTemplateTitle> GetDocumentTemplateTitles(BerryManagementEntities context,
            long? documentTemplateTitleDocumentTemplateId, ref string errorMessage)
        {
            IQueryable<Data.DocumentTemplateTitle> result = null;
            try
            {
                result = context.DocumentTemplateTitles.Where(d => (documentTemplateTitleDocumentTemplateId == null ||
                    d.DocumentTemplateTitleDocumentTemplateId == documentTemplateTitleDocumentTemplateId));
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  SelectBank()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  SelectBank()\n" + ex.Message;
                }
            }
            finally { }
            return result;
        }

        public static Data.DocumentTemplate GetDocumentTemplate(BerryManagementEntities context,
            long documentTemplateId, ref string errorMessage)
        {
            Data.DocumentTemplate result = null;
            try
            {
                result = context.DocumentTemplates.Where(d => d.DocumentTemplateId == documentTemplateId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი:  SelectBank()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი:  SelectBank()\n" + ex.Message;
                }
            }
            finally { }
            return result;
        }

        public static IQueryable<Data.Role> GetRoles(BerryManagementEntities context)
        {
            IQueryable<Data.Role> result = context.Roles;

            return result;
        }

        public static IQueryable<Data.Post> GetPosts(BerryManagementEntities context)
        {
            IQueryable<Data.Post> result = context.Posts;

            return result;
        }
    }
}
