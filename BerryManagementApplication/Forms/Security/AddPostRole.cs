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
    public partial class AddPostRole : Form
    {


        private readonly SecurityMainForm _securityMainForm;
        private BM_Security_ServiceReference.PostRole _postRole;
        private bool _update = false;

        public AddPostRole(SecurityMainForm frm)
        {
            InitializeComponent();

            _securityMainForm = frm;
            _postRole = new BM_Security_ServiceReference.PostRole();

            load();
        }
        public AddPostRole(SecurityMainForm frm, BM_Security_ServiceReference.PostRole postRole)
        {
            InitializeComponent();

            _securityMainForm = frm;

            this._postRole = (postRole != null) ? postRole : new BM_Security_ServiceReference.PostRole();

            _update = true;
            load();
        }

        private void load()
        {
            List<BM_Security_ServiceReference.Post> posts = null;
            List<BM_Security_ServiceReference.Role> roles = null;

            string errorMessage = null;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                posts = serviceClient.GetAllPost(ref errorMessage);

                roles = serviceClient.GetAllRoles(ref errorMessage);
            }
            if (!string.IsNullOrEmpty(errorMessage))
                MessageBox.Show(errorMessage);
            else
            {
                this.RolecomboBox.DataSource = roles;
                this.RolecomboBox.DisplayMember = "Role_Name";
                this.RolecomboBox.ValueMember = "Role_Id";
                this.RolecomboBox.SelectedIndex = -1;
                if ((this.RolecomboBox.Items.Count > 0) && (this._postRole.PostRole_Role_Id > 0))
                    foreach (BM_Security_ServiceReference.Role postRoleModel in this.RolecomboBox.Items)
                        if ((long)postRoleModel.Role_Id == this._postRole.PostRole_Role_Id)
                        {
                            this.RolecomboBox.SelectedIndex = this.RolecomboBox.Items.IndexOf(postRoleModel);
                            break;
                        }

                this.PostcomboBox.DataSource = posts;
                this.PostcomboBox.DisplayMember = "Post_Name";
                this.PostcomboBox.ValueMember = "Post_Id";
                this.PostcomboBox.SelectedIndex = -1;
                if ((this.PostcomboBox.Items.Count > 0) && (this._postRole.PostRole_Post_Id > 0))
                    foreach (BM_Security_ServiceReference.Post postRoleModel in this.PostcomboBox.Items)
                        if ((long)postRoleModel.Post_Id == this._postRole.PostRole_Post_Id)
                        {
                            this.PostcomboBox.SelectedIndex = this.PostcomboBox.Items.IndexOf(postRoleModel);
                            break;
                        }
            }

            this.RolecomboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PostcomboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            // დასრულების თარიღის კონტროლის მდგომარეობა
            this.StartdateTimePicker.Value = ((this._postRole.PostRole_StartDate != System.DateTime.MinValue) && (this._postRole.PostRole_StartDate != System.DateTime.MaxValue)) ? this._postRole.PostRole_StartDate : this.StartdateTimePicker.Value;
            this.EnddateTimePicker.Value = ((this._postRole.PostRole_EndDate.HasValue) && (this._postRole.PostRole_EndDate != System.DateTime.MinValue) && (this._postRole.PostRole_EndDate != System.DateTime.MaxValue)) ? this._postRole.PostRole_EndDate.Value : this.EnddateTimePicker.Value;

            // დასრულების თარიღის კონტროლის მდგომარეობა
            this.PersonPostEndDateTitleCheckBox.Checked = (this._postRole.PostRole_EndDate.HasValue);
            this.EnddateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

            // თარიღის ქართული ფორმატი
            this.StartdateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            this.StartdateTimePicker.Format = DateTimePickerFormat.Custom;
            this.EnddateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            this.EnddateTimePicker.Format = DateTimePickerFormat.Custom;
        }

       

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (PersonPostEndDateTitleCheckBox.Checked)
            {
                {
                    if (this.StartdateTimePicker.Value >= this.EnddateTimePicker.Value)
                        MessageBox.Show("არასწორი თარიღი!");
                }
            }

            if (this.PostcomboBox.SelectedItem == null || this.RolecomboBox.SelectedItem == null)
            {
                MessageBox.Show("გთხოვთ გადაამოწმოთ მონაცემები, დაფიქსირდა შეცდომა");
            }
            
            else
            {



                BM_Security_ServiceReference.PostRole PostRole = new BM_Security_ServiceReference.PostRole()
                {
                    PostRole_Post_Id = System.Convert.ToInt32(this.PostcomboBox.SelectedValue),
                    PostRole_Role_Id = System.Convert.ToInt32(this.RolecomboBox.SelectedValue),
                    PostRole_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EnddateTimePicker.Value : (DateTime?)null,
                    PostRole_StartDate = StartdateTimePicker.Value
                };


                string errorMessage = null;

                if (_update == false)
                {
                    using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                        new BM_Security_ServiceReference.BM_Security_ServiceClient())
                    {
                        var v = serviceClient.InsertPostRole(PostRole, ref errorMessage);

                    }
                }
                else
                {
                    using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
                    {
                        PostRole.PostRole_Id = _postRole.PostRole_Id;
                        serviceClient.UpdateRolePost(PostRole, ref errorMessage);
                    }
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {
                    MessageBox.Show("ატვირთულია");

                    _securityMainForm.GetPostRoles();

                    this.Close();
                }


            }
        }

        private void PersonPostEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.EnddateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
    }
}
