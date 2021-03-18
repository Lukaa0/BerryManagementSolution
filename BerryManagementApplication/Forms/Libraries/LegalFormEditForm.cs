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
    public partial class LegalFormEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.LegalForm _LegalForm;
        public LegalFormEditForm()
        {
            InitializeComponent();
            this.Text = "სამართლებრივი ფორმა დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._LegalForm = new BM_Library_ServiceReference.LegalForm();
        }

        public LegalFormEditForm(BM_Library_ServiceReference.LegalForm legalForm)
        {
            InitializeComponent();
            this.Text = "სამართლებრივი ფორმა რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._LegalForm = legalForm;
            this.LegalFormNameKaTextBox.Text = legalForm.LegalForm_Name;
            this.LegalFormNameEnTextBox.Text = legalForm.LegalForm_NameEn;
        }
        public BM_Library_ServiceReference.LegalForm LegalFormObject
        {
            get { return this._LegalForm; }
        }
        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._LegalForm == null)
                {
                    this._LegalForm = new BM_Library_ServiceReference.LegalForm();
                }
                this._LegalForm.LegalForm_Name = this.LegalFormNameKaTextBox.Text;
                this._LegalForm.LegalForm_NameEn = this.LegalFormNameEnTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertLegalForm(this._LegalForm, ref errorMessage);
                            this._LegalForm.LegalForm_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateLegalForm(this._LegalForm, ref errorMessage);
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
