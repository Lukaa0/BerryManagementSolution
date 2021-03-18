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
    public partial class AutentificationForm : Form
    {
        //private string _MainConnectionString = null;
        //private string _NewPassword = null;
        public static long _personPost = 0;

        public AutentificationForm()
        {
            InitializeComponent();
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            this.AutentificationUser();
        }

        private void AutentificationUser()
        {
            try
            {
                string errorMessage = string.Empty;
                using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {
                    string UserID = null;
                    string UserBarcode = null;
                    if (this.UserNameTextBox.Text.All(c => char.IsDigit(c))){
                        UserID = UserNameTextBox.Text;
                    }
                    else
                    {
                        UserBarcode = UserNameTextBox.Text;
                    }
                    string code = Classes.Security.GetSecurityCode(this.PasswordTextBox.Text);

                    Program.User = serviceClient.AutorizeUser(code, UserID, UserBarcode,ref errorMessage).FirstOrDefault();
                    if (Program.User != null)
                    {
                        if (Program.User.User_PasswordIsReset)
                        {
                            this.SetNewPassword();
                            
                        }
                        _personPost = Program.User.User_PersonPost_ID;
                        Program.userPermissions = serviceClient.GetUserPermissions(Program.User.User_Person_ID,ref errorMessage);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        this.DialogResult = DialogResult.Cancel;
                        MessageBox.Show("მომხმარებლის სახელი ან პაროლი არ არის სწორი!",
                            "აუტენტიფიკაციის შეცდომა",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                this.DialogResult = DialogResult.Cancel;
                MessageBox.Show(ex.Message,
                            "აუტენტიფიკაციის შეცდომა",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);               
            }
            finally
            {
                this.Close();
            }
        }

        private void SetReportParameters()
        {
            //string reportPassword = null;
            //string reportUserName = null;
            //string reportPath = null;
            //string reportUrlSufix = null;
            //string reportUrlPrefix = null;
            //try
            //{
            //    using (HR_Security_ServiceReference.HR_Security_ServiceClient serviceClient = new HR_Security_ServiceReference.HR_Security_ServiceClient())
            //    {
                    //if (serviceClient.GetReportParameters(out reportPath, out reportUrlPrefix, out reportUrlSufix, out reportUserName, out reportPassword))
                    //{
                    //    Program.ReportParameters = new Classes.ReportParameters();
                    //    Program.ReportParameters.ReportPassword = reportPassword;
                    //    Program.ReportParameters.ReportUserName = reportUserName;
                    //    Program.ReportParameters.ReportPath = reportPath;
                    //    Program.ReportParameters.SetReportUrl(this._MainConnectionString, reportUrlPrefix, reportUrlSufix);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("ანგარიშგებების პარამეტრების იდენტიფიკაცია ვერ მოხერხდა!",
                    //        "ანგარიშგებები",
                    //        MessageBoxButtons.OK,
                    //        MessageBoxIcon.Error);
                    //}
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message,
            //                "ანგარიშგებების პარამეტრების იდენტიფიკაცია ვერ მოხერხდა!",
            //                MessageBoxButtons.OK,
            //                MessageBoxIcon.Error);
            //}
        }

        private void SetNewPassword()
        {
            bool isAdmin = false;
            ChangePasswordFrom form = new ChangePasswordFrom(
                Program.User.User_Person_ID,
                isAdmin
                );
            if (form.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show(this, "პაროლი შეიცვალა!!!", "შეტყობინება");
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {

        }
    }
}
