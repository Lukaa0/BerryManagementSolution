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
    public partial class CitizenshipEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.Citizenship _Citizenship;

        public CitizenshipEditForm()
        {
            InitializeComponent();
            this.Text = "მოქალაქეობის დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._Citizenship = new BM_Library_ServiceReference.Citizenship();
        }

        public CitizenshipEditForm(BM_Library_ServiceReference.Citizenship citizenship)
        {
            InitializeComponent();
            this.Text = "მოქალაქეობის რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._Citizenship = citizenship;
            this.CitizenshipNameKaTextBox.Text = citizenship.Citizenship_Name;
            this.CitizenshipNameEnTextBox.Text = citizenship.Citizenship_NameEn;
        }

        public BM_Library_ServiceReference.Citizenship CitizenshipObject
        {
            get { return this._Citizenship; }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._Citizenship == null)
                {
                    this._Citizenship = new BM_Library_ServiceReference.Citizenship();
                }
                this._Citizenship.Citizenship_Name = this.CitizenshipNameKaTextBox.Text;
                this._Citizenship.Citizenship_NameEn = this.CitizenshipNameEnTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertCitizenship(this._Citizenship,ref errorMessage);
                            this._Citizenship.Citizenship_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateCitizenship(this._Citizenship,ref errorMessage);
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
