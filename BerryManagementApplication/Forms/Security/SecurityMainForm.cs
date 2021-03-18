using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Security
{
    public partial class SecurityMainForm : Form
    {
        //private BM_Security_ServiceReference.User _User;
        //private BM_Security_ServiceReference.Role _Role;
        bool TreeviewIsGenerating = false;
        bool EditingPermissions = false;
        //private long? lastID;

        private String _rowName, _rowPostName, _rowRoletName;
        private long _rowId, _passworRowId, _userId;
        private SecurityMainForm frm;

        public SecurityMainForm()
        {
            InitializeComponent();
            this.Text = "უსაფრთხოების მართვის პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;
            if (Program.User.User_Role_ID != 13)
            {
                Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            }

            frm = this;
        }

        public void ActivateTabPage(string name)
        {
            this.SecurityTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.SecurityTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.SecurityTabControl, tabPageName);
        }


        #region მომხმარებლის ინფორმაცია
        /// <summary>
        /// განისაზღვრება ქმედებები რომლებიც უნდა განხორციელდეს tpUsers-ის გააქტიურებისას
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersTabPage_Enter(object sender, EventArgs e)
        {
            UsersDataGridView.AutoGenerateColumns = false;
            //this.RolesforUserDataGridView.AutoGenerateColumns = false;
            this.GetUsers(this.UserIsActiveCheckBox);

            // დავიმახსოვროთ მიმდინარე სტრიქონის ნომერი
            int pCurrentRowIndex = -1;
            pCurrentRowIndex = (this.UsersDataGridView.CurrentCell != null) ? this.UsersDataGridView.CurrentRow.Index : -1;

            //შევავსოთ ცხილი
            FillUsersDataGridView(pCurrentRowIndex);
        }

        private void FillUsersDataGridView(int inCurrentRowIndex)
        {
            List<BM_Security_ServiceReference.UserModel> userData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                

                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.UsersDataGridView.DataSource = null;
                this.UsersDataGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Security_ServiceReference.BM_Security_ServiceClient ServiceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {

                    userData = ServiceClient.GetUsersModel(null, null, null, null, null, null, ref ErrorMessage).ToList<BM_Security_ServiceReference.UserModel>();
                }

                // შევავსოთ ცხრილი
                this.UsersDataGridView.DataSource = userData;

                // დავაყენოთ მიმდინარე სტრიქონი და სვეტი თუ მოითხოვება
                if (inCurrentRowIndex >= 0 && this.UsersDataGridView.Rows.Count > 0)
                {
                    inCurrentRowIndex = (this.UsersDataGridView.Rows.Count <= inCurrentRowIndex) ? this.UsersDataGridView.Rows.Count - 1 : inCurrentRowIndex;
                    this.UsersDataGridView.CurrentCell =
                        this.UsersDataGridView.Rows[inCurrentRowIndex].Cells[(this.UsersDataGridView.CurrentCell != null) ? this.UsersDataGridView.CurrentCell.ColumnIndex : 0];
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillPostssDataGridView()");
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        /// <summary>
        /// განისაზღვრება ქმედებები რომლებიც უნდა განხორციელდეს cbUserIsActive-ის მდგომარეობის შეცვლით
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserIsActiveCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            this.GetUsers((CheckBox)sender);
        }

        /// <summary>
        /// მეთოდი რომელიც ქმნის მომხმარებლების ცხრილს
        /// </summary>
        /// <param name="cb">ჩეკბოქსი, რომელიც განსაზღვრავს გამოსატანი მომხმარებლების ფილტრაციას:
        /// CheckState.Indeterminate - ყველა მომხმარებელი
        /// cb.Checked = true - აქტიური მომხმარებლები
        /// cb.Checked = false - წაშლილი მომხმარებლები</param>
        private void GetUsers(CheckBox cb)
        {
            //using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = 
            //    new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //{
            //    if (cb.CheckState == CheckState.Indeterminate)// || u.UserIsActive == cb.Checked)
            //    {
            //        this.UsersDataGridView.DataSource = serviceClient.GetUsers(null, null, null);
            //    }
            //    else
            //    {
            //        this.UsersDataGridView.DataSource = serviceClient.GetUsers(null, null, cb.Checked);
            //    }
            //}
        }

        //dgvUsers_SelectionChang,e ირთვება და ითიშება შესაბამისი ღილაკები "მოქმედებები მომხმარებლებზე"
        private void UsersDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.UsersTimer.Enabled = false;
            this.UsersTimer.Enabled = true;
        }

        //Timer რეფრეშდება მომხმარებლის როლები გრიდი
        private void UsersTimer_Tick(object sender, EventArgs e)
        {
            //this.UsersTimer.Enabled = false;
            //if (this.UsersDataGridView.RowCount < 1)
            //{
            //    return;
            //}
            //try
            //{
            //    BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //    if (user != null)
            //    {
            //        if ((user.UserName).ToLower() == "admin" || user.UserId == 1)
            //    {
            //        this.EditUserButton.Enabled = false;
            //        this.DeleteUserButton.Enabled = false;
            //        this.RestoreUserButton.Enabled = false;
            //    }
            //    else
            //    {
            //        this.EditUserButton.Enabled = true;
            //        this.DeleteUserButton.Enabled = user.UserIsActive;
            //        this.RestoreUserButton.Enabled = !user.UserIsActive;
            //    }
            //        using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
            //            new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //        {
            //            this.RolesforUserDataGridView.DataSource = serviceClient.GetUsersRoles(null, user.UserId, null);
            //        }
            //    }
            //}
            //catch
            //{ } 
        }

        //მომხმარებლის დამატება
        private void AddUserButton_Click(object sender, EventArgs e)
        {
            //UserEditForm form = new UserEditForm(Enums.DataChangeType.Insert, null);
            //if (form.ShowDialog(this) == DialogResult.OK)
            //{
            //    this.UsersTabPage_Enter(null, null);
            //    DataGridViewRow row = this.UsersDataGridView.Rows.Cast<DataGridViewRow>().Where(
            //       u => ((BM_Security_ServiceReference.User)u.DataBoundItem).UserId == form.Id).SingleOrDefault();
            //    if (row != null)
            //    {
            //        this.UsersDataGridView.CurrentCell = this.UsersDataGridView.Rows[row.Index].Cells[1];
            //    }
            //}
        }

        //მომხმარებლის შეცვლა
        private void EditUserButton_Click(object sender, EventArgs e)
        {
            //if (this.UsersDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //if (user != null)
            //{
            //    UserEditForm form = new UserEditForm(Enums.DataChangeType.Update, user);
            //    if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            //    {
            //        int rowNumber = this.UsersDataGridView.CurrentRow.Index;
            //        this.UsersTabPage_Enter(null, null);
            //        this.UsersDataGridView.CurrentCell = this.UsersDataGridView.Rows[rowNumber].Cells[1];
            //    }
            //}
        }

        //მომხმარებლის წაშლა (აქტიური სტატუსის მოხსნა)
        private void DeleteUserButton_Click(object sender, EventArgs e)
        {
            //if (this.UsersDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //if (MessageBox.Show("ნამდვილად გსურთ მომხმარებელი '" + user.UserName + "' წაშლა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = 
            //            new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //        {
            //            serviceClient.DeleteUser(user.UserId);
            //        }
            //        //this._User = null;
            //        this.UsersTabPage_Enter(null, null);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
            //    }
            //}
        }

        //მომხმარებლის აღდგენა
        private void RestoreUserButton_Click(object sender, EventArgs e)
        {
            //if (this.UsersDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //if (MessageBox.Show("ნამდვილად გსურთ მომხმარებელი '" + user.UserName + "' წაშლა?", "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    try
            //    {
            //        using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = 
            //        new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //        {
            //            serviceClient.RestoreUser(user.UserId);
            //        }
            //        //this._User = null;
            //        this.UsersTabPage_Enter(null, null);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
            //    }
            //}
        }

        //პაროლის შეცვლა
        private void PasswordResetButton_Click(object sender, EventArgs e)
        {
            //if (this.UsersDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //PasswordChangeForm form = new PasswordChangeForm(user, true);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    int CurRowNum = this.UsersDataGridView.CurrentRow.Index;
            //    this.UsersTabPage_Enter(null, null);
            //    this.UsersDataGridView.CurrentCell = this.UsersDataGridView.Rows[CurRowNum].Cells[1];
            //}



            if (_userId == 0)
            {
                MessageBox.Show("გთხოვთ, აირჩიოთ მომხმარებელი, პაროლის შესაცვლელად");
            }
            else
            {
                ChangePasswordFrom t = new ChangePasswordFrom(_userId, true);
                t.Show();
            }
            
        }
        #endregion მომხმარებლის ინფორმაცია


        #region როლები


        private void RolesTabPage_Enter(object sender, EventArgs e)
        {
        
            this.GetRoles();
            PostRoledataGridView.AutoGenerateColumns = false;
            GetPostRoles();

        }

        /// <summary>
        /// მეთოდი რომელიც ქმნის როლების ცხრილს
        /// </summary>
        private void GetRoles()
        {
            string errorMessage = null;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                this.RolesDataGridView.DataSource = serviceClient.GetRoles(null, null, ref errorMessage);
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }
        
        public void GetPostRoles()
        {
            string errorMessage = null;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                PostRoledataGridView.DataSource = serviceClient.GetPostRoles(ref errorMessage);
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }

        }
        
        //როლის დამატება
        private void AddRoleButton_Click(object sender, EventArgs e)
        {
            RoleEditForm form = new RoleEditForm(Enums.DataChangeType.Insert, null);
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                this.RolesTabPage_Enter(null, null);
                DataGridViewRow row = this.RolesDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    r => (long)r.Cells["Role_Id"].Value == (long)form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.RolesDataGridView.CurrentCell = this.RolesDataGridView.Rows[row.Index].Cells[2];
                }
            }
        }

        //როლის შეცვლა
        private void EditRoleButton_Click(object sender, EventArgs e)
        {
            if (this.RolesDataGridView.RowCount < 1)
            {
                MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            RoleEditForm form = new RoleEditForm(Enums.DataChangeType.Update, role);
            if (form.ShowDialog() == DialogResult.OK)
            {
                int rowNumber = this.RolesDataGridView.CurrentRow.Index;
                this.RolesTabPage_Enter(null, null);
                this.RolesDataGridView.CurrentCell = this.RolesDataGridView.Rows[rowNumber].Cells[2];
            }
        }

        //როლის წაშლა
        private void DeleteRoleButton_Click(object sender, EventArgs e)
        {
            if (this.RolesDataGridView.RowCount < 1)
            {
                MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            RoleEditForm form = new RoleEditForm(Enums.DataChangeType.Delete, role);
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.RolesTabPage_Enter(null, null);
            }
        }

        //მოქმედებების ღილაკების გამორთვა თუ მონიშნულია ადმინისტრატორების როლი
        private void RolesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            this.RolesTimer.Enabled = false;
            this.RolesTimer.Enabled = true;
        }

        //Timer რომელიც არეფრეშებს მომხმარებლები როლში ცხრილს
        private void RolesTimer_Tick(object sender, EventArgs e)
        {
            //this.RolesTimer.Enabled = false;
            //try
            //{
            //    BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            //    if (role != null)
            //    {
            //        if ((role.RoleName).ToLower() == "administrators" || role.RoleId == 1)
            //        {
            //            this.EditRoleButton.Enabled = false;
            //            this.DeleteRoleButton.Enabled = false;
            //        }
            //        else
            //        {
            //            this.EditRoleButton.Enabled = true;
            //            this.DeleteRoleButton.Enabled = true;
            //        }
            //        using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
            //            new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //        {
            //            this.UsersInRoleDataGridView.DataSource = serviceClient.GetUsersRoles(null, null, role.RoleId);
            //        }
            //    }
            //}
            //catch { }
        }

        #endregion როლები


        #region როლის მომხმარებლები



        /// <summary>
        /// მეთოდი რომელიც ქმნის "როლის მომხმარებლები"-ს ცხრილს
        /// </summary>
        private void GetUsersInRole()
        {
            //BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            //using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //{
            //    this.UsersInRoleDataGridView.DataSource = serviceClient.GetUsersWithRole(role.RoleId);
            //}
        }

        //მომხმარებლის დამატება როლში
        private void UserAddInRoleButton_Click(object sender, EventArgs e)
        {
            //BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            //UserAddToRoleForm form = new UserAddToRoleForm(Enums.DataChangeType.Insert, role, null);
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    int CurRowNum = this.RolesDataGridView.CurrentRow.Index;
            //    this.GetRoles();
            //    this.RolesDataGridView.CurrentCell = this.RolesDataGridView.Rows[CurRowNum].Cells[1];
            //}            



            AddPostRole t = new AddPostRole(frm);
            t.Show();


        }
        private void UserDataCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex != -1)
            {
                DataGridViewRow seelectedRowForPassword = UsersDataGridView.Rows[index];

                _userId = Int32.Parse(seelectedRowForPassword.Cells[0].Value.ToString());

                //MessageBox.Show(_userId.ToString());

                //_passworRowId = Int32.Parse(seelectedRow.Cells["User_Person_FirstName"].Value.ToString());

            }
        }


        private void PostRoleCellName(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (e.RowIndex != -1)
            {
                DataGridViewRow seelectedRow = PostRoledataGridView.Rows[index];

                _rowId = Int32.Parse(seelectedRow.Cells["PostRole_Id"].Value.ToString());
                _rowName = seelectedRow.Cells["PostRole_Role_Name"].Value.ToString() + " " +
                           seelectedRow.Cells["PostRole_Post_Name"].Value.ToString();

                _rowPostName = seelectedRow.Cells["PostRole_Post_Name"].Value.ToString();
                _rowRoletName = seelectedRow.Cells["PostRole_Role_Name"].Value.ToString();
            }

        }


        //მომხმარებლის ამოშლა როლიდან
        private void RemoveUserFromRoleButton_Click(object sender, EventArgs e)
        {
            //if (this.UsersInRoleDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesDataGridView.CurrentRow.DataBoundItem;
            //BM_Security_ServiceReference.UsersInRole usersinrole = (BM_Security_ServiceReference.UsersInRole)this.UsersInRoleDataGridView.CurrentRow.DataBoundItem;
            //if (MessageBox.Show("ნამდვილად გსურთ მომხმარებელი '" + usersinrole.UserRoleUserName + "-ს' წაშლა როლიდან - "+ role.RoleName, "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //        //try
            //        //{
            //        //   serviceClient.DeleteUsersRole()
            //        //}
            //        //catch (Exception ex)
            //        //{
            //        //    MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
            //        //}

            //    int CurRowNum = this.RolesDataGridView.CurrentRow.Index;
            //    this.GetRoles();
            //    this.RolesDataGridView.CurrentCell = this.RolesDataGridView.Rows[CurRowNum].Cells[1];
            //}

            if (_rowName != null)
            {
                DialogResult res = MessageBox.Show("წავშალოთ - " + _rowName + " ? ", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    try
                    {
                        string errorMessage = null;
                        using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                            new BM_Security_ServiceReference.BM_Security_ServiceClient())
                        {
                            this.PostRoledataGridView.DataSource = serviceClient.DeletePostRoleById(_rowId,ref errorMessage);
                        }
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            MessageBox.Show(errorMessage);
                        }
                        else
                        {
                            GetPostRoles();
                            MessageBox.Show("წაიშალა");
                            _rowName = null;
                        }


                    }
                    catch(Exception Ex)
                    {
                        MessageBox.Show("მონაცემი ვერ წაიშალა, ცადეთ მოგვიანებით" + Ex.ToString());
                    }

                    
                    
                } 
                if (res == DialogResult.Cancel)
                {
                    
                }
            }
            else
            {
                MessageBox.Show("გთხოვთ აირჩიოთ მონაცემბი მოსაშლელად");
            }

        }

        private void UpdatePostRole_Click(object sender, EventArgs e)
        {
            BM_Security_ServiceReference.PostRole postRole = new BM_Security_ServiceReference.PostRole();
            BM_Security_ServiceReference.PostRoleName postRoleName = new BM_Security_ServiceReference.PostRoleName();


            try
            {
                /* მიმდინარე ობიექტი */
                postRoleName = (BM_Security_ServiceReference.PostRoleName)this.PostRoledataGridView.CurrentRow.DataBoundItem;
                if (postRoleName != null)
                {
                    postRole = new BM_Security_ServiceReference.PostRole()
                    {

                        PostRole_Post_Id = postRoleName.PostRole_Post_Id,
                        PostRole_Role_Id = postRoleName.PostRole_Role_Id,
                        PostRole_EndDate = postRoleName.PostRole_End,
                        PostRole_StartDate = postRoleName.PostRole_Start,
                        PostRole_Id = postRoleName.PostRole_Id

                    };

                    AddPostRole t = new AddPostRole(frm, postRole);
                    t.ShowDialog();
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PostDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }



            //if (_rowName != null)
            //{
            //    EditPostRoles t = new EditPostRoles(frm, _rowId, _rowPostName, _rowRoletName);
            //    t.Show();
            //}
            //else
            //{
            //    MessageBox.Show("გთხოვთ აირჩიოთ მონაცემბი რედაქტირებისათვის");
            //}

        }



        #endregion როლის მომხმარებლები


        #region მომხმარებლის როლები

        /// <summary>
        /// მეთოდი რომელიც ქმნის "მომხმარებლის როლები"-ს ცხრილს
        /// </summary>
        private void GetRolesForUser()
        {
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            //{
            //    this.RolesforUserDataGridView.DataSource = serviceClient.GetRolesWithUser(user.UserId);
            //}
        }

        //როლის ამოშლა მომხმარებლიდან
        private void RoleRemoveFromUserButton_Click(object sender, EventArgs e)
        {
            //if (this.RolesforUserDataGridView.RowCount < 1)
            //{
            //    MessageBox.Show("ცხრილი ცარიელია!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //DataClasses.RolesForUser RolesForUser rolesforuser = (RolesForUser)this.RolesforUserDataGridView.CurrentRow.DataBoundItem;

            //if (MessageBox.Show("ნამდვილად გსურთ როლი '" + rolesforuser.RoleName_UR + "-ს' წაშლა მომხმარებლისთვის - " + user.UserName, "დადასტურება", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    using (TransactionScope tran = new TransactionScope())
            //    {
            //        try
            //        {
            //            Data.SecurityDataClassesDataContext dc = new Data.SecurityDataClassesDataContext(Program.User.ConnectionString);

            //            dc.p_UsersRoles_Delete(rolesforuser.UserRoleID_UR, user.UserId, rolesforuser.UserRoleRoleId_UR, rolesforuser.UserRoleStartDate_UR, rolesforuser.UserRoleEndDate_UR, Program.User.UserId);

            //            tran.Complete();


            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + ex.Message);
            //        }

            //    }
            //    int CurRowNum = this.UsersDataGridView.CurrentRow.Index;
            //    this.GetUsers(this.UserIsActiveCheckBox);
            //    this.UsersDataGridView.CurrentCell = this.UsersDataGridView.Rows[CurRowNum].Cells[1];
            //}
        }

        //როლის დამატება მომხმარებლისთვის
        private void RoleAddInUserButton_Click(object sender, EventArgs e)
        {
            //BM_Security_ServiceReference.User user = (BM_Security_ServiceReference.User)this.UsersDataGridView.CurrentRow.DataBoundItem;
            //RoleEditToUserForm form = new RoleEditToUserForm(Enums.DataChangeType.Insert, user, null);

            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    int CurRowNum = this.UsersDataGridView.CurrentRow.Index;
            //    this.GetUsers(this.UserIsActiveCheckBox);
            //    this.UsersDataGridView.CurrentCell = this.UsersDataGridView.Rows[CurRowNum].Cells[1];
            //}
        }


        #endregion მომხმარებლის როლები

        #region უფლებები

        //ტაბპეიჯის ჩატვირთვა
        private void PermissionsTabPage_Enter(object sender, EventArgs e)
        {
            this.PermissionsTreeView.Visible = false;
            this.GetRolesForPermissions();
            this.PermissionsTreeView.ForeColor = System.Drawing.Color.Gray;

        }


        /// <summary>
        /// მეთოდი რომელიც ქმნის როლების ცხრილს
        /// </summary>
        private void GetRolesForPermissions()
        {
            string errorMessage = null;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                this.RolesForPermissionDataGridView.DataSource = serviceClient.GetRoles(null, null, ref errorMessage);
                if (!System.String.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }

        //ხის შევსება
        private void PopulateTree()
        {
            this.PermissionsTreeView.Visible = false;
            Cursor currentCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            TreeviewIsGenerating = true;
            this.PermissionsTreeView.Nodes.Clear();
            string errorMessage = null;

            BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesForPermissionDataGridView.CurrentRow.DataBoundItem;
            //გამოჩნდეს ყველა უფლება და ჩეკბოქსიანები მოიპტიჩკოს
            List<BM_Security_ServiceReference.PermissionsForRole> permissions;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                permissions = serviceClient.GetPermissionsForRole(role.Role_Id, ref errorMessage);

            }
            foreach (var p in permissions)
            {

                if (p.PermissionParentId == 0)
                {
                    TreeNode CurrentParentNode = this.PermissionsTreeView.Nodes.Add(p.PermissionId.ToString(), p.PermissionName);

                    if (p.RolesPermissionPermissionId > 0 && p.RolesPermissionRoleId == role.Role_Id)
                    {
                        CurrentParentNode.Checked = true;
                    }
                }
                else
                {
                    TreeNode[] CurrentNode = PermissionsTreeView.Nodes.Find(p.PermissionParentId.ToString(), true);

                    if (CurrentNode.Length > 0)
                    {
                        PermissionsTreeView.SelectedNode = CurrentNode[0];

                        TreeNode CurrentParentNodeFound = PermissionsTreeView.SelectedNode;

                        TreeNode CurrentChildNode = CurrentParentNodeFound.Nodes.Add(p.PermissionId.ToString(), p.PermissionName);

                        if (p.RolesPermissionPermissionId > 0 && p.RolesPermissionRoleId == role.Role_Id)
                        {
                            CurrentChildNode.Checked = true;
                        }
                    }
                }
            }


            this.PermissionsTreeView.CollapseAll();
            this.PermissionsTreeView.SelectedNode = this.PermissionsTreeView.Nodes[0];
            this.PermissionsTreeView.Nodes[0].EnsureVisible();
            TreeviewIsGenerating = false;
            Cursor.Current = currentCursor;
            this.PermissionsTreeView.Visible = true;

        }

        //უფლების შეცვლა
        private void ChangePermissionButton_Click(object sender, EventArgs e)
        {
            if (this.ChangePermissionButton.Text == "უფლებების შეცვლა")
            {
                this.EditingPermissions = true;
                this.CancelSavePermissionButton.Visible = true;
                this.RolesForPermissionDataGridView.Enabled = false;
                this.RolesForPermissionDataGridView.ForeColor = System.Drawing.Color.Gray;
                this.PermissionsTreeView.ForeColor = System.Drawing.Color.Black;
                this.ChangePermissionButton.Text = "შენახვა";
            }
            else
            {
                //შენახვა
                string errorMessage = null;
                Cursor currentCursor = Cursor.Current;
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
                    {
                        BM_Security_ServiceReference.Role role = (BM_Security_ServiceReference.Role)this.RolesForPermissionDataGridView.CurrentRow.DataBoundItem;
                        serviceClient.DeleteRolesPermissionByRoleId(role.Role_Id, ref errorMessage);
                        List<BM_Security_ServiceReference.RolePermission> permissions = this.GetNewRolePermissionsList(this.PermissionsTreeView.Nodes, role.Role_Id);
                        serviceClient.InsertRolesPermissionsList(permissions, ref errorMessage);
                    }
                }
                catch (Exception exr)
                {
                    MessageBox.Show("ოპერაცია ვერ შესრულდა!\n" + exr.Message);
                    return;
                }
                Cursor.Current = currentCursor;
                this.CancelSavePermissionButton_Click(null, null);
            }
        }
        private List<BM_Security_ServiceReference.RolePermission> GetNewRolePermissionsList(System.Windows.Forms.TreeNodeCollection nodes, long roleId)
        {
            List<BM_Security_ServiceReference.RolePermission> result = new List<BM_Security_ServiceReference.RolePermission>();
            foreach (TreeNode node in nodes)
            {
                if (node.Checked)
                {
                    BM_Security_ServiceReference.RolePermission rolePermission = new BM_Security_ServiceReference.RolePermission();
                    rolePermission.RolePermission_Role_Id = roleId;
                    rolePermission.RolePermission_Permission_Id = Convert.ToInt64(node.Name);
                    result.Add(rolePermission);
                    if (node.Nodes.Count > 0)
                    {
                        result.AddRange(GetNewRolePermissionsList(node.Nodes, roleId));
                    }
                }
            }
            return result;
        }

        //უფლების შენახვის გაუქმება
        private void CancelSavePermissionButton_Click(object sender, EventArgs e)
        {
            this.PopulateTree();
            this.CancelSavePermissionsButtonsEnableDisable();
        }

        //ღილაკების ჩართვა/გამორთვა უფლებების რედაქტირების გაუქმების დროს. ხის პოპულაციის გარეშე.
        private void CancelSavePermissionsButtonsEnableDisable()
        {
            this.EditingPermissions = false;
            this.CancelSavePermissionButton.Visible = false;
            this.RolesForPermissionDataGridView.Enabled = true;
            this.RolesForPermissionDataGridView.ForeColor = System.Drawing.Color.Black;
            this.PermissionsTreeView.ForeColor = System.Drawing.Color.Gray;
            this.ChangePermissionButton.Text = "უფლებების შეცვლა";
        }

        //როლების სიაში სხვა ჩანაწერზე გადასვლა ცხრილში
        private void RolesForPermissionDataGridView_SelectionChanged(object sender, EventArgs e)
        {


            if (this.RolesForPermissionDataGridView.CurrentRow != null)
            {
                this.PermissionsTimer.Enabled = false;
                this.PermissionsTimer.Enabled = true;

            }
        }

        //ტაიმერის აქტივაციით ხის პოპულაცია
        private void PermissionsTimer_Tick(object sender, EventArgs e)
        {
            this.PopulateTree();
            this.PermissionsTimer.Enabled = false;
        }

        //ხის ჩეკბოქსების გაააქტიურების ჩართვა/გამორთვა
        private void PermissionsTreeView_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (!(this.TreeviewIsGenerating || this.EditingPermissions))
            {
                e.Cancel = true;
            }

        }


        //ყველა Child ის მონიშვნა ხეში
        private void CheckTreeViewNode(TreeNode node, Boolean isChecked)
        {
            foreach (TreeNode item in node.Nodes)
            {
                item.Checked = isChecked;

                if (item.Nodes.Count > 0)
                {
                    this.CheckTreeViewNode(item, isChecked);
                }
            }

        }

        //Child ების და Paren ების მონიშვნა ხეში
        private void PermissionsTreeView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            this.PermissionsTreeView.AfterCheck -= PermissionsTreeView_AfterCheck;

            CheckTreeViewNode(e.Node, e.Node.Checked);
            SelectParents(e.Node, e.Node.Checked);

            this.PermissionsTreeView.AfterCheck += PermissionsTreeView_AfterCheck;
        }

        //ყველა პარენტის მონიშვნა
        private void SelectParents(TreeNode node, Boolean isChecked)
        {
            TreeNode parent = node.Parent;

            if (parent == null)
                return;

            if (isChecked)
            {
                parent.Checked = true;
                SelectParents(parent, true);
            }
            else
            {
                if (parent.Nodes.Cast<TreeNode>().Any(n => n.Checked))
                {
                    return;
                }
                else
                {
                    parent.Checked = false;
                    SelectParents(parent, false);
                }
            }
        }

        //სხვა ტაბზე გადასვლისას თუ ხდება უფლებების ხის რედაქტირება შეეკითხოს
        private void SecurityTabControl_Selecting(object sender, TabControlCancelEventArgs e)
        {

            if (this.EditingPermissions)
            {
                bool answer = QuestionWhenEditing();
                if (answer)
                {
                    e.Cancel = true;
                }
            }
        }

        //ძირითადი ფორმის დახურვისას თუ ხდება უფლებების ხის რედაქტირება შეეკითხოს
        private void HRSecMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.EditingPermissions)
            {
                bool answer = QuestionWhenEditing();
                if (answer)
                {
                    e.Cancel = true;
                }
            }
        }


        //როდესაც ხდება უფლებების ხის რედაქტირება, შეეკითხოს ცვლილებების შენახვაზე, გაუქმებაზე ან Cancelზე და შესრულდეს შესაბამისი მოქმედებები
        private bool QuestionWhenEditing()
        {
            bool CancelProcessing;

            DialogResult answ = MessageBox.Show("შევინახოთ ცვლილებები უფლებების ცხრილში?", "დადასტურება", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            switch (answ)
            {
                case DialogResult.Yes:
                    {
                        this.ChangePermissionButton_Click(null, null);
                        CancelProcessing = false;
                        return CancelProcessing;
                    }
                case DialogResult.No:
                    {
                        this.CancelSavePermissionsButtonsEnableDisable();
                        CancelProcessing = false;
                        return CancelProcessing;
                    }
                case DialogResult.Cancel:
                    {
                        CancelProcessing = true;
                        return CancelProcessing;
                    }
                default:
                    {
                        CancelProcessing = true;
                        return CancelProcessing;
                    }
            }
        }


    }
}
       #endregion