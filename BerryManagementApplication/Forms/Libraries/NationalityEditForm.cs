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
    public partial class NationalityEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.Nationality _Nationality;
        public NationalityEditForm()
        {
            InitializeComponent();
            this.Text = "ნაციონალობის დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._Nationality = new BM_Library_ServiceReference.Nationality();
        }
        public NationalityEditForm(BM_Library_ServiceReference.Nationality nationality)
        {
            InitializeComponent();
            this.Text = "ნაციონალობის რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._Nationality = nationality;
            this.NationalityNameKATextBox.Text = nationality.Nationality_Name;
            this.NationalityNameENGTextBox.Text = nationality.Nationality_NameEn;
        }


        public BM_Library_ServiceReference.Nationality NationalityObject
        {
            get { return this._Nationality; }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._Nationality == null)
                {
                    this._Nationality = new BM_Library_ServiceReference.Nationality();
                }
                this._Nationality.Nationality_Name = this.NationalityNameKATextBox.Text;
                this._Nationality.Nationality_NameEn = this.NationalityNameENGTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertNationality(this._Nationality,ref errorMessage);
                            this._Nationality.Nationality_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateNationality(this._Nationality, ref errorMessage);
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

