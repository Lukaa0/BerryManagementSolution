using BerryManagementApplication.Forms.Operations;
using BerryManagementApplication.Forms.Security;
using BerryManagementApplication.Forms.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BerryManagementApplication.Forms.Main
{
    public partial class BerryManagementMainForm : Form
    {
        public BerryManagementMainForm()
        {
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            if (Program.User.User_Role_ID == 13)
            {

                this.AdministrationToolStripMenuItem.Tag = "-1";
                this.usersToolStripMenuItem.Tag = "-1";
                this.rolesToolStripMenuItem.Tag = "-1";
                this.permissionsToolStripMenuItem.Tag = "-1";
                this.securityToolStripMenuItem.Tag = "-1";
            }
            Classes.PermissionManagement.ManageMenuAccessByUserPermissions((object)this.mainMenuStrip, Program.userPermissions.UserPermisions);


        }

        #region უსაფრთხოება
        private void securityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Security.SecurityMainForm form = (Security.SecurityMainForm)Classes.FindControl.FindForm(this.MdiChildren, "SecurityMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Security.SecurityMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }

        #endregion უსაფრთხოება

        #region ცნობარები
        private void LibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libraries.LibrariesMainForm form = (Libraries.LibrariesMainForm)Classes.FindControl.FindForm(this.MdiChildren, "LibrariesMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Libraries.LibrariesMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }
        #endregion

        #region კონტეინერები
        private void ContainersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Libraries.LibrariesMainForm form = (Libraries.LibrariesMainForm)Classes.FindControl.FindForm(this.MdiChildren, "LibrariesMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Libraries.LibrariesMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }

        #endregion

        #region ბუღალტერია

        private void AccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts.AccountsMainForm form = (Accounts.AccountsMainForm)Classes.FindControl.FindForm(this.MdiChildren, "AccountsMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Accounts.AccountsMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }
        #endregion

        private void EmployeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //BerryManagementApplication.Forms.Employee.EmployeeEditFrom newEmployeeForm = null;
            //Forms.Employee.VerifyPersonalNumber verifyPersonalNumber = null;
            //BM_Employee_ServiceReference.Person employeeData = null;
            //string verifiedPersonalID = System.String.Empty;
            //int numberOfSamePersonalIDs = 0;

            //verifyPersonalNumber = new Forms.Employee.VerifyPersonalNumber(); ;
            //switch (verifyPersonalNumber.ShowDialog(this))
            //{
            //    case System.Windows.Forms.DialogResult.OK:
            //        verifiedPersonalID = verifyPersonalNumber.VerifiedPersonalID;
            //        numberOfSamePersonalIDs = verifyPersonalNumber.NumberOfSamePersonalIDs;
            //        verifyPersonalNumber = null;
            //        if (numberOfSamePersonalIDs == 0)
            //        {
            //            // დამატების რეჟიმი
            //            if (!System.String.IsNullOrEmpty(verifiedPersonalID))
            //            {
            //                // დამატების რეჟიმი პერსონალური ნომრის წინასწარი მითითებით
            //                employeeData = new BM_Employee_ServiceReference.Person()
            //                {
            //                    Person_Identity = verifiedPersonalID
            //                };
            //            }
            //            else
            //            {
            //                // სტანდარტული დამატების რეჟიმი
            //                employeeData = new BM_Employee_ServiceReference.Person();
            //            }
            //            // ვიძახებთ დამატების ფორმას
            //            // user ID ????
            //            newEmployeeForm = new Forms.Employee.EmployeeEditFrom(Enums.DataChangeType.Insert, Enums.ActionMode.WriteAndReturnData, 1, employeeData);
            //            if (newEmployeeForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //                if (newEmployeeForm.EmployeeObject != null)
            //                {
            //                    if (newEmployeeForm.EmployeeObject.Person_Id > 0)
            //                    {
            //                        // დავხუროთ პერსონალის მთავარი ფორმა თუ ის აქტიურია
            //                        Forms.Employee.EmployeeMainForm employeeMainForm = (Forms.Employee.EmployeeMainForm)Classes.FindControl.FindForm(this.MdiChildren, "EmployeeMainForm");
            //                        if (employeeMainForm != null)
            //                        {
            //                            employeeMainForm.Close();
            //                        }
            //                        // გავხსნათ ახალი თანამშრომლის პარამეტრით
            //                        employeeMainForm = new Forms.Employee.EmployeeMainForm();
            //                        if (this.ActiveMdiChild == null)
            //                        {
            //                            employeeMainForm.WindowState = FormWindowState.Maximized;
            //                        }
            //                        employeeMainForm.MdiParent = this;
            //                        employeeMainForm.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            //                        employeeMainForm.Show();
            //                    }
            //                }
            //        }
            //        else
            //        {
            //            // ძიების რეჟიმი
            //            if (!System.String.IsNullOrEmpty(verifiedPersonalID))
            //            {
            //                // ძიების რეჟიმი პერსონალური ნომრის წინასწარი მითითებით
            //                // დავხუროთ პერსონალის მთავარი ფორმა თუ ის აქტიურია
            //                HR.Forms.Employee.EmployeeMainForm employeeMainForm = (HR.Forms.Employee.EmployeeMainForm)Classes.FindControl.FindForm(this.MdiChildren, "EmployeeMainForm");
            //                if (employeeMainForm != null)
            //                {
            //                    employeeMainForm.Close();
            //                }
            //                // გავხსნათ ახალი თანამშრომლის პარამეტრით
            //                employeeMainForm = new HR.Forms.Employee.EmployeeMainForm(verifiedPersonalID);
            //                if (this.ActiveMdiChild == null)
            //                {
            //                    employeeMainForm.WindowState = FormWindowState.Maximized;
            //                }
            //                employeeMainForm.MdiParent = this;
            //                employeeMainForm.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            //                employeeMainForm.Show();
            //            }
            //        }
            //        break;
            //    default:
            //        break;
            //}
        }


        private void NewEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Employee.EmployeeEditFrom newEmployeeForm = null;
            Forms.Employee.VerifyPersonalNumber verifyPersonalNumber = null;
            BM_Employee_ServiceReference.Person employeeData = null;
            string verifiedPersonalID = System.String.Empty;
            int numberOfSamePersonalIDs = 0;

            verifyPersonalNumber = new Forms.Employee.VerifyPersonalNumber(); 
            switch (verifyPersonalNumber.ShowDialog(this))
            {
                case System.Windows.Forms.DialogResult.OK:
                    verifiedPersonalID = verifyPersonalNumber.VerifiedPersonalID;
                    numberOfSamePersonalIDs = verifyPersonalNumber.NumberOfSamePersonalIDs;
                    verifyPersonalNumber = null;
                    if (numberOfSamePersonalIDs == 0)
                    {
                        // დამატების რეჟიმი
                        if (!System.String.IsNullOrEmpty(verifiedPersonalID))
                        {
                            // დამატების რეჟიმი პერსონალური ნომრის წინასწარი მითითებით
                            employeeData = new BM_Employee_ServiceReference.Person()
                            {
                                Person_Identity = verifiedPersonalID
                            };

                        }
                        else
                        {
                            // სტანდარტული დამატების რეჟიმი
                            employeeData = new BM_Employee_ServiceReference.Person();
                        }
                        // ვიძახებთ დამატების ფორმას
                        newEmployeeForm = new Forms.Employee.EmployeeEditFrom(Enums.DataChangeType.Insert, Enums.ActionMode.WriteAndReturnData, 1, employeeData);
                        if (newEmployeeForm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            if (newEmployeeForm.EmployeeObject != null)
                            {
                                if (newEmployeeForm.EmployeeObject.Person_Id > 0)
                                {
                                    // დავხუროთ პერსონალის მთავარი ფორმა თუ ის აქტიურია
                                    Forms.Employee.EmployeeMainForm employeeMainForm = (Forms.Employee.EmployeeMainForm)Classes.FindControl.FindForm(this.MdiChildren, "EmployeeMainForm");
                                    if (employeeMainForm != null)
                                    {
                                        employeeMainForm.Close();
                                    }
                                    // გავხსნათ ახალი თანამშრომლის პარამეტრით
                                    employeeMainForm = new Forms.Employee.EmployeeMainForm(newEmployeeForm.EmployeeObject.Person_Id);
                                    if (this.ActiveMdiChild == null)
                                    {
                                        employeeMainForm.WindowState = FormWindowState.Maximized;
                                    }
                                    employeeMainForm.MdiParent = this;
                                    employeeMainForm.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                                    employeeMainForm.Show();
                                }
                            }
                    }
                    else
                    {
                        // ძიების რეჟიმი
                        if (!System.String.IsNullOrEmpty(verifiedPersonalID))
                        {
                            // ძიების რეჟიმი პერსონალური ნომრის წინასწარი მითითებით
                            // დავხუროთ პერსონალის მთავარი ფორმა თუ ის აქტიურია
                            Forms.Employee.EmployeeMainForm employeeMainForm = (Forms.Employee.EmployeeMainForm)Classes.FindControl.FindForm(this.MdiChildren, "EmployeeMainForm");
                            if (employeeMainForm != null)
                            {
                                employeeMainForm.Close();
                            }
                            // გავხსნათ ახალი თანამშრომლის პარამეტრით
                            employeeMainForm = new Forms.Employee.EmployeeMainForm(verifiedPersonalID);
                            if (this.ActiveMdiChild == null)
                            {
                                employeeMainForm.WindowState = FormWindowState.Maximized;
                            }
                            employeeMainForm.MdiParent = this;
                            employeeMainForm.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                            employeeMainForm.Show();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        #region შაბლონები
        private void documentTemplatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Template.TemplatesMainForm form = (Template.TemplatesMainForm)Classes.FindControl.FindForm(this.MdiChildren, "TemplatesMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Template.TemplatesMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }
        #endregion შაბლონები

        private void FindEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.Employee.EmployeeMainForm employeeMainForm = (Forms.Employee.EmployeeMainForm)Classes.FindControl.FindForm(this.MdiChildren, "EmployeeMainForm");
            if (employeeMainForm == null)
            {
                employeeMainForm = new Employee.EmployeeMainForm();
                employeeMainForm.MdiParent = this;
                employeeMainForm.Show();
                employeeMainForm.WindowState = FormWindowState.Maximized;
                employeeMainForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
            else
                employeeMainForm.Activate();
        }

        #region ოპერაციები
        private void OperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationsMainForm form = (OperationsMainForm)Classes.FindControl.FindForm(this.MdiChildren, "OperationsMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new OperationsMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }
        #endregion ოპერაციები

        private void StructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StructureMainForm form = (StructureMainForm)Classes.FindControl.FindForm(this.MdiChildren, "StructureMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new StructureMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }

        private void PreEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void კარიერაToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void რიგისმონაცებებიToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OperationsMainForm form = (OperationsMainForm)Classes.FindControl.FindForm(this.MdiChildren, "OperationsMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new OperationsMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }

        private void ReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            BerryManagementApplication.Forms.Reports.ReportsMainForm form = (Reports.ReportsMainForm)Classes.FindControl.FindForm(this.MdiChildren, "ReportsMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Reports.ReportsMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BerryManagementApplication.Forms.Accounts.AccountsMainForm form = (Accounts.AccountsMainForm)Classes.FindControl.FindForm(this.MdiChildren, "AccountsMainForm");
            if (form != null)
            {
                form.Activate();
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
            }
            else
            {
                form = new Accounts.AccountsMainForm();
                if (this.ActiveMdiChild == null)
                {
                    form.WindowState = FormWindowState.Maximized;
                }
                form.MdiParent = this;
                form.ActivateTabPage(((ToolStripMenuItem)(sender)).Name);
                form.Show();
            }
        }
    }
}
