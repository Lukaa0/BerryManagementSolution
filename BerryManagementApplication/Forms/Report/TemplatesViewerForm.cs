using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Report
{
    public partial class TemplatesViewerForm : Form
    {
        public object ListReportObjects;

        public TemplatesViewerForm()
        {
            InitializeComponent();
            this.DocumentTemplatesDataGridView.AutoGenerateColumns = false;
        }

        public TemplatesViewerForm(object listReportObjects)
        {
            InitializeComponent();
            this.DocumentTemplatesDataGridView.AutoGenerateColumns = false;
            this.ListReportObjects = listReportObjects;
        }

        private void TemplatesViewerForm_Load(object sender, EventArgs e)
        {
            string errorMessage = null;
            using (BM_Template_ServiceReference.BM_Template_ServiceClient serviceClient =
                new BM_Template_ServiceReference.BM_Template_ServiceClient())
            {
                this.DocumentTemplatesDataGridView.DataSource = serviceClient.GetDocumentTemplateTitles(null, ref errorMessage);
            }

        }

        private void DocumentTemplatesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cursor cursor = this.Cursor;
            string errorCode = null;
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (this.DocumentTemplatesDataGridView.RowCount < 1)
                {
                    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                BM_Template_ServiceReference.DocumentTemplate documentTemplate;
                BM_Template_ServiceReference.DocumentTemplateTitle documentTemplateTitle =
                    (BM_Template_ServiceReference.DocumentTemplateTitle)this.DocumentTemplatesDataGridView.CurrentRow.DataBoundItem;
                if (documentTemplateTitle != null)
                {
                    using (BM_Template_ServiceReference.BM_Template_ServiceClient serviceClient =
                       new BM_Template_ServiceReference.BM_Template_ServiceClient())
                    {
                        documentTemplate = serviceClient.GetDocumentTemplate(documentTemplateTitle.DocumentTemplateTitleDocumentTemplateId, ref errorCode);
                    }
                    string filename = BerryManagementApplication.Classes.WordReportMaker.Generate(documentTemplate.DocumentTemplateData, this.ListReportObjects);
                    System.Diagnostics.Process.Start(filename);
                }
            }
            catch { }
            finally
            {
                this.Cursor = cursor;
            }
        }
    }
}
