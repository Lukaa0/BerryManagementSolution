using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerryManagementWindowsService.Data.Template
{
    public static class SelectL
    {

        public static List<Data.DocumentTemplateTitle> GetDocumentTemplateTitles(long? documentTemplateTitleDocumentTemplateId,
            ref string errorMessage)
        {
            List<Data.DocumentTemplateTitle> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = SelectQ.GetDocumentTemplateTitles(context, documentTemplateTitleDocumentTemplateId, ref errorMessage).ToList();
                }
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
            return result;
        }

        public static Data.DocumentTemplate GetDocumentTemplate(long documentTemplateId, ref string errorMessage)
        {
            Data.DocumentTemplate result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    result = SelectQ.GetDocumentTemplate(context, documentTemplateId, ref errorMessage);
                }
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
            return result;
        }

        public static List<Data.Role> GetRoles(ref string errorMessage)
        {
            List<Data.Role> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetRoles(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetRoles()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetRoles\n" + ex.Message;
                }
            }
            return result;
        }

        public static List<Data.Post> GetPosts(ref string errorMessage)
        {
            List<Data.Post> result = null;
            try
            {
                using (BerryManagementEntities context = new BerryManagementEntities())
                {
                    var selectText = SelectQ.GetPosts(context);
                    result = selectText.ToList();
                }
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "მეთოდი: GetPosts()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nმეთოდი: GetPosts\n" + ex.Message;
                }
            }
            return result;
        }
    }
}
