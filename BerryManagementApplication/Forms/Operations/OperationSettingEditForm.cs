using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Operations
{
    public partial class OperationSettingEditForm : Form
    {
        private BM_Operation_ServiceReference.OperationSetting _OperationSetting;

        public OperationSettingEditForm()
        {
            InitializeComponent();
        }

        public OperationSettingEditForm(BM_Operation_ServiceReference.OperationSetting operationSetting)
        {
            InitializeComponent();
            this._OperationSetting = operationSetting;
            this.OperationSettingValueTextBox.Text = operationSetting.OperationSetting_Value;
            this.DescriptionLabel.Text = operationSetting.OperationSetting_Description;
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            this._OperationSetting.OperationSetting_Value = this.OperationSettingValueTextBox.Text;
            try
            {
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = 
                    new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    serviceClient.UpdateOperationSetting(this._OperationSetting, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception("კონფიგურაციის ელემენტი არ შეიცვალა!");
                }
                this.DialogResult = DialogResult.OK;
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
