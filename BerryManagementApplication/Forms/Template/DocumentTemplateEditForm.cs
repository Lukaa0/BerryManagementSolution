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
    public partial class DocumentTemplateEditForm : Form
    {
        public long? Id;
        private Enums.DataChangeType _ChangeType;
        private BM_Template_ServiceReference.DocumentTemplate _DocumentTemplate;
        private BM_Template_ServiceReference.DocumentTemplateTitle _DocumentTemplateTitle;

        public DocumentTemplateEditForm(Enums.DataChangeType changeType,
            BM_Template_ServiceReference.DocumentTemplateTitle documentTemplateTitle)
        {
            InitializeComponent();
            this._ChangeType = changeType;
            this._DocumentTemplateTitle = documentTemplateTitle;
        }

        //ფორმის ჩატვირთვა
        private void AddEditDocumentTemplate_Load(object sender, EventArgs e)
        {
            switch (this._ChangeType)
            {
                case Enums.DataChangeType.Insert:
                    {
                        this.Text = "დოკუმენტის შაბლონის დამატება";
                    }
                    break;
                case Enums.DataChangeType.Update:
                    {
                        this.Text = "დოკუმენტის შაბლონის ცვლილება";
                        this.DocumentTemplateNameTextbox.Text = this._DocumentTemplateTitle.DocumentTemplateTitleDescription.ToString();
                        this.FileNameLabel.Text = "თუ გსურთ შაბლონის ფაილის შეცვლა, ჩატვირთეთ შესაბამისი ფაილი";
                        this.Id = this._DocumentTemplateTitle.DocumentTemplateTitleDocumentTemplateId;
                    }
                    break;
            }
        }

        //გაუქმება
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //მონაცემების შენახვა
        private void OKButton_Click(object sender, EventArgs e)
        {
            ////////////////////////
            string errorMessage = null;
            if (string.IsNullOrEmpty(this.DocumentTemplateNameTextbox.Text.Trim()))
            {
                MessageBox.Show("შეიყვანეთ დასახელება", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.FileNameLabel.Text.Trim()))
            {
                MessageBox.Show("აირჩიეთ ფაილი", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this._DocumentTemplateTitle.DocumentTemplateTitleDescription = this.DocumentTemplateNameTextbox.Text;
            try
            {
                using (BM_Template_ServiceReference.BM_Template_ServiceClient serviceClient = 
                    new BM_Template_ServiceReference.BM_Template_ServiceClient())
                {
                    switch (this._ChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertDocumentTemplate(this._DocumentTemplateTitle, this._DocumentTemplate, ref errorMessage);
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateDocumentTemplate(this._DocumentTemplate, this._DocumentTemplateTitle, ref errorMessage);
                            break;
                    }
                }
                MessageBox.Show("შაბლონი დაფიქსირებულია!");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
                return;
            }
        }

        private void FileLoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                byte[] file;
                using (var stream = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        file = reader.ReadBytes((int)stream.Length);
                    }
                }
                switch (this._ChangeType)
                {
                    case Enums.DataChangeType.Insert:
                        this._DocumentTemplateTitle = new BM_Template_ServiceReference.DocumentTemplateTitle();
                        this._DocumentTemplateTitle.DocumentTemplateTitleDescription = this.DocumentTemplateNameTextbox.Text;
                        this._DocumentTemplateTitle.DocumentTemplateTitleExtension = Path.GetExtension(ofd.FileName);
                        this._DocumentTemplate = new BM_Template_ServiceReference.DocumentTemplate();
                        this._DocumentTemplate.DocumentTemplateData = file;
                        this.FileNameLabel.Text = ofd.FileName;
                        break;
                    case Enums.DataChangeType.Update:
                        this._DocumentTemplateTitle.DocumentTemplateTitleExtension = Path.GetExtension(ofd.FileName);
                        if (file != null)
                        {
                            if (this._DocumentTemplate == null)
                            {
                                this._DocumentTemplate = new BM_Template_ServiceReference.DocumentTemplate();
                                this._DocumentTemplate.DocumentTemplateId = this._DocumentTemplateTitle.DocumentTemplateTitleDocumentTemplateId;
                            }
                            this._DocumentTemplate.DocumentTemplateData = file;
                            this.FileNameLabel.Text = ofd.FileName;
                        }                       
                        break;
                }
            }
        }
    }
}
