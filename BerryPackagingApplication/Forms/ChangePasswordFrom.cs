using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryPackagingApplication
{
    public partial class ChangePasswordFrom : Form
    {
        private long _userId;
        private bool _admin;
        private string _userPassword, _userPasswordCheck;
        public ChangePasswordFrom(long Id, bool isAdmin)
        {
            InitializeComponent();

            _userId = Id;
            _admin = isAdmin;
            
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            
            _userPassword = NewPasswordTextBox.Text.Trim();
            _userPasswordCheck = PasswordTextBox.Text.Trim();
            if (_userPassword != "" && _userPassword == _userPasswordCheck)
            {
                string errorMessage = null;

                using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {
                    serviceClient.UpdateUser(_userId, StaticClasses.Security.GetSecurityCode(_userPassword), _admin, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    MessageBox.Show("პაროლი განახლებულია");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("მონაცემები არ დაემთხვა ერთმანეთს");
            }
        }
    }
}
