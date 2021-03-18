using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Security
{
    public partial class RoleEditForm : Form
    {
        public long? Id;
        private Enums.DataChangeType _ChangeType;
        private BM_Security_ServiceReference.Role _Role;

        public RoleEditForm(Enums.DataChangeType changeType, BM_Security_ServiceReference.Role role)
        {
            InitializeComponent();
            this._ChangeType = changeType;
            this._Role = role;
        }

        //გაუქმება
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //მონაცემების შენახვა
        private void OKButton_Click(object sender, EventArgs e)
        {
            string errorMessage = System.String.Empty;
            if (this._ChangeType != Enums.DataChangeType.Delete && string.IsNullOrEmpty(this.RoleNameTextbox.Text.Trim()))
            {
                MessageBox.Show("შეიყვანეთ როლის დასახელება", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Retry;
                return;
            }
            try
            {
                if (this._Role == null)
                {
                    this._Role = new BM_Security_ServiceReference.Role();
                }
                this._Role.Role_Name = this.RoleNameTextbox.Text;
                this._Role.Role_Description = this.RoleDescriptionTextBox.Text;
                using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = 
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {
                    switch (this._ChangeType)
                    {
                        case Enums.DataChangeType.Insert:
                            this.Id = serviceClient.InsertRole(this._Role, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                throw new Exception(errorMessage);
                            }
                            break;
                        case Enums.DataChangeType.Update:
                            serviceClient.UpdateRole(this._Role, ref errorMessage);
                            break;
                        case Enums.DataChangeType.Delete:
                            serviceClient.DeleteRole(_Role.Role_Id, ref errorMessage);
                            break;
                    }
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                return;
            }
        }

        //ფორმის ჩატვირთვა
        private void AddEditRole_Load(object sender, EventArgs e)
        {
            switch (this._ChangeType)
            {
                case Enums.DataChangeType.Insert:
                    {
                        this.Text = "როლის დამატება";
                    }
                    break;
                case Enums.DataChangeType.Update:
                    {
                        this.Text = "როლის ცვლილება";
                        this.RoleNameTextbox.Text = this._Role.Role_Name.ToString();
                        this.RoleDescriptionTextBox.Text = this._Role.Role_Description.ToString();
                    }
                    break;
                case Enums.DataChangeType.Delete:
                    this.Text = "როლის წაშლა";
                    if (MessageBox.Show("ნამდვილად გსურთ როლი '" + _Role.Role_Name + "-ს' წაშლა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.OKButton_Click(null, null);
                    }
                    else
                    {
                        this.Close();
                    }
                        break;
            }
        }

        private void RoleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.Retry)
            {
                e.Cancel = true;
            }
        }
    }
}
