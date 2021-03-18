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
    public partial class BankEditForm : Form
    {
        public long Id;
        private Enums.DataChangeType _DataChangeType;
        private BM_Library_ServiceReference.Bank _Bank;
        public BankEditForm()
        {
            InitializeComponent();
            this.Text = "ბანკის დამატება";
            this._DataChangeType = Enums.DataChangeType.Insert;
            this._Bank = new BM_Library_ServiceReference.Bank();
        }

        public BankEditForm(BM_Library_ServiceReference.Bank bank)
        {
            InitializeComponent();
            this.Text = "ბანკის რედაქტირება";
            this._DataChangeType = Enums.DataChangeType.Update;
            this._Bank = bank;
            this.Id = bank.Bank_Id;
            this.BankNameTextBox.Text = bank.Bank_Name;
            this.BankKodeTextBox.Text = bank.Bank_Kode;
        }
        public BM_Library_ServiceReference.Bank BankObject
        {
            get { return this._Bank; }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            try
            {
                if (this._Bank == null)
                {
                    this._Bank = new BM_Library_ServiceReference.Bank();
                }
                this._Bank.Bank_Name = this.BankNameTextBox.Text;
                this._Bank.Bank_Kode = this.BankKodeTextBox.Text;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    switch (this._DataChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertBank(this._Bank, ref errorMessage);
                            this._Bank.Bank_Id = this.Id;
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateBank(this._Bank, ref errorMessage);
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
