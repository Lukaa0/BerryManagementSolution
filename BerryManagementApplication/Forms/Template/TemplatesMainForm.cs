using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Template
{
    public partial class TemplatesMainForm : Form
    {
        public TemplatesMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
           // Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
        }

        public void ActivateTabPage(string name)
        {
            this.TemplatesTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.TemplatesTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.TemplatesTabControl, tabPageName);
        }

        private void DocumentTemplatesTabPage_Enter(object sender, EventArgs e)
        {
            ///////////////////////////////////
            string errorMessage = null;
            this.DocumentTemplatesDataGridView.AutoGenerateColumns = false;
            using (BM_Template_ServiceReference.BM_Template_ServiceClient serviceClient = 
                new BM_Template_ServiceReference.BM_Template_ServiceClient())
            {
                this.DocumentTemplatesDataGridView.DataSource = serviceClient.GetDocumentTemplateTitles(null, ref errorMessage);
            }
        }

        private void DocumentTemplateViewButton_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////
            string errorMessage = null;
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
                    documentTemplate = serviceClient.GetDocumentTemplate(documentTemplateTitle.DocumentTemplateTitleDocumentTemplateId, ref errorMessage);
                }
                string filename = Path.GetTempPath() + Guid.NewGuid().ToString() + "." + documentTemplateTitle.DocumentTemplateTitleExtension;
                File.WriteAllBytes(filename, documentTemplate.DocumentTemplateData);
                System.Diagnostics.Process.Start(filename);
            }
        }

        private void DocumentTemplateAddButton_Click(object sender, EventArgs e)
        {
            DocumentTemplateEditForm form = new DocumentTemplateEditForm(Enums.DataChangeType.Insert, null);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DocumentTemplatesTabPage_Enter(null, null);
                DataGridViewRow row = this.DocumentTemplatesDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    r => ((BM_Template_ServiceReference.DocumentTemplateTitle)r.DataBoundItem).DocumentTemplateTitleDocumentTemplateId == 
                    (long)form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.DocumentTemplatesDataGridView.CurrentCell = this.DocumentTemplatesDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }

        private void DocumentTemplateEditButton_Click(object sender, EventArgs e)
        {
            if (this.DocumentTemplatesDataGridView.RowCount < 1)
            {
                MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BM_Template_ServiceReference.DocumentTemplateTitle documentTemplateTitle =
                (BM_Template_ServiceReference.DocumentTemplateTitle)this.DocumentTemplatesDataGridView.CurrentRow.DataBoundItem;
            if (documentTemplateTitle != null)
            {
                DocumentTemplateEditForm form = new DocumentTemplateEditForm(Enums.DataChangeType.Update, documentTemplateTitle);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int CurRowNum = this.DocumentTemplatesDataGridView.CurrentRow.Index;
                    this.DocumentTemplatesTabPage_Enter(null, null);
                    this.DocumentTemplatesDataGridView.CurrentCell = this.DocumentTemplatesDataGridView.Rows[CurRowNum].Cells[0];
                }
            }
        }

        private void DocumentTemplateDeleteButton_Click(object sender, EventArgs e)
        {
            ///////////////////////////////////
            string errorMessage = null;
            if (this.DocumentTemplatesDataGridView.RowCount < 1)
            {
                MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BM_Template_ServiceReference.DocumentTemplateTitle documentTemplateTitle =
                (BM_Template_ServiceReference.DocumentTemplateTitle)this.DocumentTemplatesDataGridView.CurrentRow.DataBoundItem;
            if (documentTemplateTitle != null)
            {
                if (MessageBox.Show("ნამდვილად წაიშალოს შაბლონი - '" + documentTemplateTitle.DocumentTemplateTitleDescription + "' წაშლა?",
                    "ყურადღება!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes )
                {
                    return;
                }
                try
                {
                    using (BM_Template_ServiceReference.BM_Template_ServiceClient serviceClient =
                       new BM_Template_ServiceReference.BM_Template_ServiceClient())
                    {
                        serviceClient.DeleteDocumentTemplate(documentTemplateTitle.DocumentTemplateTitleDocumentTemplateId, ref errorMessage);
                        this.DocumentTemplatesTabPage_Enter(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
                    return;
                }
            }
        }
    }
}
