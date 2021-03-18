using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BM_Template_Service" in both code and config file together.
    public class BM_Template_Service : IBM_Template_Service
    {
        #region Select
        public List<Data.DocumentTemplateTitle> GetDocumentTemplateTitles(long? documentTemplateTitleDocumentTemplateId,
            ref string errorMessage)
        {
            return Data.Template.SelectL.GetDocumentTemplateTitles(documentTemplateTitleDocumentTemplateId, ref errorMessage);
        }

        public Data.DocumentTemplate GetDocumentTemplate(long documentTemplateId, ref string errorMessage)
        {
            return Data.Template.SelectL.GetDocumentTemplate(documentTemplateId, ref errorMessage);
        }
        #endregion Select

        #region Insert
        public long InsertDocumentTemplate(Data.DocumentTemplateTitle documentTemplateTitle,
            Data.DocumentTemplate documentTemplate, ref string errorMessage)
        {
            return Data.Template.Insert.InsertDocumentTemplate(documentTemplateTitle, documentTemplate, ref errorMessage);
        }
        #endregion Insert

        #region Update
        public void UpdateDocumentTemplate(Data.DocumentTemplate documentTemplate,
            Data.DocumentTemplateTitle documentTemplateTitle, ref string errorMessage)
        {
            Data.Template.Update.UpdateDocumentTemplate(documentTemplate, documentTemplateTitle, ref errorMessage);
        }
        #endregion Update

        #region Delete
        public void DeleteDocumentTemplate(long documentTemplateId, ref string errorMessage)
        {
            Data.Template.Delete.DeleteDocumentTemplate(documentTemplateId, ref errorMessage);
        }
        #endregion Delete
    }
}
