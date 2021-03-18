using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace BerryManagementWindowsService.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBM_Template_Service" in both code and config file together.
    [ServiceContract]
    public interface IBM_Template_Service
    {
        [OperationContract]
        #region Select
        List<Data.DocumentTemplateTitle> GetDocumentTemplateTitles(long? documentTemplateTitleDocumentTemplateId,
            ref string errorMessage);

        [OperationContract]
        Data.DocumentTemplate GetDocumentTemplate(long documentTemplateId, ref string errorMessage);
        #endregion Select

        #region Insert
        [OperationContract]
        long InsertDocumentTemplate(Data.DocumentTemplateTitle documentTemplateTitle,
            Data.DocumentTemplate documentTemplate, ref string errorMessage);
        #endregion Insert

        #region Update
        [OperationContract]
        void UpdateDocumentTemplate(Data.DocumentTemplate documentTemplate,
            Data.DocumentTemplateTitle documentTemplateTitle, ref string errorMessage);
        #endregion Update

        #region Delete
        [OperationContract]
        void DeleteDocumentTemplate(long documentTemplateId, ref string errorMessage);
        #endregion Delete
    }
}