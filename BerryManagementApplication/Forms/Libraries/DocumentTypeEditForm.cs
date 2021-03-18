using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Libraries
{
    public partial class DocumentTypeEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.DocumentType _DocumentType;

        public DocumentTypeEditForm()
        {
            InitializeComponent();
            this.Text = "საბუთის ტიპის დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._DocumentType = new BM_Library_ServiceReference.DocumentType();
        }

        public DocumentTypeEditForm(BM_Library_ServiceReference.DocumentType documentType)
        {
            InitializeComponent();
            this.Text = "საბუთის ტიპის რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._DocumentType = documentType;
            this.DocumentTypeNameTextBox.Text = documentType.DocumentType_Name;
        }

        public BM_Library_ServiceReference.DocumentType DocumentTypeObject
        {
            get { return this._DocumentType; }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._DocumentType == null)
                {
                    this._DocumentType = new BM_Library_ServiceReference.DocumentType();
                }
                this._DocumentType.DocumentType_Name = this.DocumentTypeNameTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertDocumentType(this._DocumentType,ref errorMessage);
                            this._DocumentType.DocumentType_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateDocumentType(this._DocumentType,ref errorMessage);
                            break;
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
                return;
            }
        }
    }
}

