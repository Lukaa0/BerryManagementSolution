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
    public partial class EditPostRoles : Form
    {

        private String _PostRowName = null, _RoleRowName = null;
        private int _PostRowId = 0, _RoleRowId = 0;
        private long _rowId;
        private String _post = null, _role = null;

        private readonly SecurityMainForm _securityMainForm;

        public EditPostRoles(SecurityMainForm frm , long Id, string Post, string Role)
        {
            InitializeComponent();

            _securityMainForm = frm;
            this._rowId = Id;

            this._post = Post;
            this._role = Role;


            loadTables();

            
            
        }

        private void loadTables()
        {
            string errorMessage = null;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                var result = serviceClient.GetAllPost(ref errorMessage);

                var result2 = serviceClient.GetAllRoles(ref errorMessage);

                PostIdDataGridView.DataSource = result.ToList();

                RoleIdDataGridView.DataSource = result2.ToList();

            }

            PostIdDataGridView.Columns["Post_name"].DisplayIndex = 0;
            PostIdDataGridView.Columns["Post_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PostIdDataGridView.Columns["Post_name"].HeaderText = "პოსტის სახელი";
            PostIdDataGridView.Columns["Post_Description"].DisplayIndex = 1;
            PostIdDataGridView.Columns["Post_Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PostIdDataGridView.Columns["Post_Description"].HeaderText = "პოსტის აღწერა";
            PostIdDataGridView.Columns["Post_Id"].Visible = false;
            PostIdDataGridView.Columns["Post_BarCodePrefix"].Visible = false;
            PostIdDataGridView.Columns["Post_BalanceSheetType_Id"].Visible = false;


            RoleIdDataGridView.Columns["Role_name"].DisplayIndex = 0;
            RoleIdDataGridView.Columns["Role_name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RoleIdDataGridView.Columns["Role_name"].HeaderText = "თანამდებობის სახელი";
            RoleIdDataGridView.Columns["Role_Description"].DisplayIndex = 1;
            RoleIdDataGridView.Columns["Role_Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RoleIdDataGridView.Columns["Role_Description"].HeaderText = "თანამდებობის აღწერა";
            RoleIdDataGridView.Columns["Role_Id"].Visible = false;


        }

        private void PostCellName(object sender, DataGridViewCellEventArgs e)
        {
            int PostIndex = e.RowIndex;
            DataGridViewRow seelectedRow = PostIdDataGridView.Rows[PostIndex];

            this._PostRowName = seelectedRow.Cells["Post_name"].Value.ToString();
            this._PostRowId = Int32.Parse(seelectedRow.Cells["Post_Id"].Value.ToString());
        }


        private void RoleCellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RoleIndex = e.RowIndex;
            DataGridViewRow seelectedRow = RoleIdDataGridView.Rows[RoleIndex];

            this._RoleRowName = seelectedRow.Cells["Role_name"].Value.ToString();
            this._RoleRowId = Int32.Parse(seelectedRow.Cells["Role_Id"].Value.ToString());
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

            if (EnddateTimePicker.Value >= StartdateTimePicker.Value || _PostRowId == 0 || _RoleRowId == 0)
            {
                MessageBox.Show("გთხოვთ გადაამოწმოთ მონაცემები, დაფიქსირდა შეცდომა");
            }
            else
            {


                BM_Security_ServiceReference.PostRole postrole = new BM_Security_ServiceReference.PostRole()
                {
                    PostRole_Id = this._rowId,
                    PostRole_Post_Id = this._PostRowId,
                    PostRole_Role_Id = this._RoleRowId,
                    PostRole_EndDate = EnddateTimePicker.Value,
                    PostRole_StartDate = StartdateTimePicker.Value
                };


                string errorMessage = null;

                using (BM_Security_ServiceReference.BM_Security_ServiceClient serviceClient =
                    new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {
                    serviceClient.UpdateRolePost(postrole, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                else
                {

                    MessageBox.Show("ინფორმაცია განახლებულია");

                    _securityMainForm.GetPostRoles();

                    this.Close();
                }



            }
        }
    }
}
