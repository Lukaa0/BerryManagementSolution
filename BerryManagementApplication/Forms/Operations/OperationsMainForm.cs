using BerryManagementApplication.Enums;
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

namespace BerryManagementApplication.Forms.Operations
{
    public partial class OperationsMainForm : Form
    {
        //private BM_Security_ServiceReference.User _User;
        //private BM_Security_ServiceReference.Role _Role;
        bool TreeviewIsGenerating = false;
        bool EditingPermissions = false;
        //private long? lastID;



        private String _rowName;
        private long _rowId;
        private OperationsMainForm frm;

        private long _harvesterPersonPost;

        private string _rowBarkode = string.Empty;
        private string _harvesterPersonPostId = string.Empty;

        public OperationsMainForm()
        {
            InitializeComponent();
            this.Text = "უსაფრთხოების მართვის პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;

            if (Program.User.User_Role_ID != 13)
            {
                Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            }
            HarvesterRowDistributionGridView.AutoGenerateColumns = false;
            HarvesterDataGridView.AutoGenerateColumns = false;

            this.OperationTabControl.TabPages.Remove(this.RolesTabPage);
            this.OperationTabControl.TabPages.Remove(this.UsersTabPage);
            this.OperationTabControl.TabPages.Remove(this.PermissionsTabPage);



        }

        public void ActivateTabPage(string name)
        {
            this.OperationTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.OperationTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.OperationTabControl, tabPageName);
        }


        #region მომხმარებლის ინფორმაცია
        /// <summary>
        /// განისაზღვრება ქმედებები რომლებიც უნდა განხორციელდეს tpUsers-ის გააქტიურებისას
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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
        }
        #endregion მომხმარებლის ინფორმაცია


        #region Settings
        private void SettingsTabPage_Enter(object sender, EventArgs e)
        {
            this.OperationSettingsDataGridView.AutoGenerateColumns = false;
            string errorMessage = null;
            using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient =
                new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
            {
                this.OperationSettingsDataGridView.DataSource = serviceClient.GetOperationSettings(null, ref errorMessage);
            }
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
        }

        private void OperationSettingEdiButton_Click(object sender, EventArgs e)
        {
            BM_Operation_ServiceReference.OperationSetting operationSetting =
                (BM_Operation_ServiceReference.OperationSetting)this.OperationSettingsDataGridView.CurrentRow.DataBoundItem;
            if (operationSetting != null)
            {
                OperationSettingEditForm form = new OperationSettingEditForm(operationSetting);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.OperationSettingsDataGridView.CurrentRow.Index;
                    this.SettingsTabPage_Enter(null, null);
                    this.OperationSettingsDataGridView.CurrentCell = this.OperationSettingsDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }
        #endregion Settings

        #region მკრეფავის რიგებში გადანაწილება
        private void HarvesterRowDistributionTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            //this.HarvesterRowDistributionGridView.AutoGenerateColumns = false;
            using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
            {
                this.HarvesterRowDistributionGridView.DataSource = serviceClient.GetRowsWithBrigade(ref errorMessage);
            }
        }

        private void HarvesterRowDistibutionAddbutton_Click(object sender, EventArgs e)
        {
            BM_Operation_ServiceReference.TakeRowModel takeRowModel = new BM_Operation_ServiceReference.TakeRowModel();
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            //BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            //BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();

            Forms.Operations.HarvesterRowDistributionEditForm HarvesterRowDistributionEditForm = null;


            try
            {

                takeRowModel = (BM_Operation_ServiceReference.TakeRowModel)this.HarvesterRowDistributionGridView.CurrentRow.DataBoundItem;
                if (takeRowModel != null)
                {
                    Row = new BM_Structure_ServiceReference.Row()
                    {
                        Row_Id = (long)takeRowModel.TakeRow_Row_Id,
                        Row_Barkode = takeRowModel.Row_Barcode,
                    };

                    BM_Operation_ServiceReference.HarvesterRowDistribution harvesterRowDistribution = new BM_Operation_ServiceReference.HarvesterRowDistribution()
                    {
                        HarvesterRowDistribution_Row_Id = Row.Row_Id
                    };
                    //companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                    //if (RowBreeddataGridView.Rows.Count == 0)
                    //{

                    //    rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
                    //}
                    //else
                    //{
                    //    rowBreedsModel = (BM_Structure_ServiceReference.RowBreedsModel)this.RowBreeddataGridView.CurrentRow.DataBoundItem;

                    //}

                    /* რედაქტირების ფორმა */
                    HarvesterRowDistributionEditForm = new HarvesterRowDistributionEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, Row, (long)takeRowModel.TakeRow_Brigade_Id);
                    switch (HarvesterRowDistributionEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.HarvesterRowDistributionTabPage_Enter(this.HarvesterRowDistributionTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void HarvesterRowDistributionGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.HarvesterDataGridView.DataSource = null;

            List<BM_Employee_ServiceReference.PersonPostModel> personPostModels = null;
            BM_Operation_ServiceReference.TakeRowModel Row;
            string errorMessage = string.Empty;
            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {
                    Row = (BM_Operation_ServiceReference.TakeRowModel)this.HarvesterRowDistributionGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        personPostModels = service.GetHarvByHarvRowDistrOutsByRowId(true, Row.TakeRow_Brigade_Id, Row.TakeRow_Row_Id, ref errorMessage);
                    }
                    this.HarvesterDataGridView.DataSource = personPostModels;

                    _rowBarkode = Row.Row_Barcode;

                    _rowId = (long)Row.TakeRow_Row_Id;

                }
                else
                {
                    if (this.HarvesterRowDistributionGridView.CurrentRow != null)
                    {
                        Row = (BM_Operation_ServiceReference.TakeRowModel)this.HarvesterRowDistributionGridView.CurrentRow.DataBoundItem;

                        using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                        {
                            personPostModels = service.GetHarvByHarvRowDistrOutsByRowId(false, Row.TakeRow_Brigade_Id, Row.TakeRow_Row_Id, ref errorMessage);
                            _rowBarkode = Row.Row_Barcode;
                        }

                        this.HarvesterDataGridView.DataSource = personPostModels;

                        _rowBarkode = Row.Row_Barcode;

                        _rowId = (long)Row.TakeRow_Row_Id;
                    }
                }




                //using (BM_Structure_ServiceReference.BM_Structure_ServiceClient STservice = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                //{
                //    _harvesterPersonPost = STservice.GetHarvesterPostId(
                //        Int32.Parse(this.HarvesterRowDistributionGridView.Rows[e.RowIndex].Cells["Row_Id"].Value.ToString()), ref errorMessage);

                //}
                //if (!string.IsNullOrEmpty(errorMessage))
                //{
                //    MessageBox.Show(errorMessage);
                //}
            }
        }

        #endregion

        private void RowCloseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("გავანთავისუფლოთ ეს რიგი ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {

                BM_Operation_ServiceReference.HarvesterRowDistributionInOut harvDist = new BM_Operation_ServiceReference.HarvesterRowDistributionInOut()
                {
                    Time = DateTime.Now,
                    Direction = false,
                    RowId = _rowId,
                    Id = Guid.NewGuid(),
                    HarvesterPersonPostId = null,//დასამატებელია
                    IsComplete = false,
                    RowBarCode = _rowBarkode,
                    UserPersonPostId = 1,//დასამატებელია
                };

                string errorMessage = null;
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient =
                    new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    serviceClient.FixHarvesterRowDistributionInOut(harvDist, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }


                string errorMessage2 = null;
                this.HarvesterRowDistributionGridView.DataSource = null;

                this.HarvesterRowDistributionGridView.AutoGenerateColumns = false;
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    this.HarvesterRowDistributionGridView.DataSource = serviceClient.GetRowsWithBrigade(ref errorMessage2);
                }

                if (!string.IsNullOrEmpty(errorMessage2))
                {
                    MessageBox.Show(errorMessage2);
                }
            }
        }


        #region ბრიგადის მინიჭება რიგზე
        private void BrigadeDistributionTabPage_Enter(object sender, EventArgs e)
        {
            UpdateBrigadeDataGridView();
        }

        private void UpdateBrigadeDataGridView(){

            string errorMessage = null;
            this.BrigadeDataGridView.AutoGenerateColumns = false;

            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.BrigadeDataGridView.DataSource = serviceClient.GetBrigades(null, null, ref errorMessage);
            }
        }

        private void BrigadeDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            this.TakeRowRowDataGridView.DataSource = null;
            this.TakeRowRowDataGridView.AutoGenerateColumns = false;

            BM_Structure_ServiceReference.Brigade Brigade;
            string errorMessage = string.Empty;
            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {
                    Brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadeDataGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Operation_ServiceReference.BM_Operation_ServiceClient service = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                    {
                       var RowList = service.GetTakeRowsModel(Brigade.Brigade_Id,null,false, ref errorMessage);
                       this.TakeRowRowDataGridView.DataSource = RowList;
                    }
                    

                }
                else
                {
                    if (this.BrigadeDataGridView.CurrentRow != null)
                    {
                        Brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadeDataGridView.CurrentRow.DataBoundItem;

                        using (BM_Operation_ServiceReference.BM_Operation_ServiceClient service = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                        {
                            var RowList = service.GetTakeRowsModel(Brigade.Brigade_Id, null, false, ref errorMessage);
                            this.TakeRowRowDataGridView.DataSource = RowList;
                        }
                    }
                }

            }
        }

        private void ButtonDistributionButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Brigade Brigade = new BM_Structure_ServiceReference.Brigade();
            Forms.Operation.BrigadeRowEditForm BrigadeRowEditForm = null;

            if (this.BrigadeDataGridView.Rows.Count != 0)
            {
                try
                {



                    /* მიმდინარე ობიექტი */
                    Brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadeDataGridView.CurrentRow.DataBoundItem; 

                    if (Brigade != null)
                    {

                        BM_Operation_ServiceReference.TakeRow TakeRow = new BM_Operation_ServiceReference.TakeRow()
                        {
                            TakeRow_Brigade_Id = Brigade.Brigade_Id
                        };

                        /* რედაქტირების ფორმა */
                        BrigadeRowEditForm = new Operation.BrigadeRowEditForm(DataChangeType.Insert,
                                                                              ActionMode.WriteAndReturnData,
                                                                              TakeRow);
                        switch (BrigadeRowEditForm.ShowDialog(this))
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                                this.BrigadeDistributionTabPage_Enter(this.BrigadeDistributionTabPage, new EventArgs());
                                break;
                            case System.Windows.Forms.DialogResult.Cancel:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadUpdateButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    UpdateBrigadeDataGridView();
                }
            }
            else
            {
                MessageBox.Show("არ არის მონაცემები");
            }
        }
        #endregion

        private void BreedPropertiesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.BreedPropertiesDataGridView.AutoGenerateColumns = false;
            try
            {
                using (BM_Produce_ServiceReference.BM_Produce_ServiceClient serviceClient = new BM_Produce_ServiceReference.BM_Produce_ServiceClient())
                {
                    this.BreedPropertiesDataGridView.DataSource = serviceClient.GetBreedProperty(null, null, null, null, null, null,null, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch(Exception Ex)
            {
                System.Windows.Forms.MessageBox.Show(Ex.Message, " Source: BreedPropertiesTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void BerryProduceAddButtonClick_Click(object sender, EventArgs e)
        {
            BM_Produce_ServiceReference.BreedProperty breedPropery = new BM_Produce_ServiceReference.BreedProperty();
            Forms.Operations.BerryProduceEditForm berryProducedeEditForm = null;
            try
            {
                /* რედაქტირების ფორმა */
                berryProducedeEditForm = new BerryProduceEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,
                                                                      breedPropery);
                switch (berryProducedeEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.BreedPropertiesTabPage_Enter(this.BreedPropertiesTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
                //
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadeAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void BerryPropertiesFilterButton_Click(object sender, EventArgs e)
        {
            BM_Produce_ServiceReference.BreedProperty breedPropery = new BM_Produce_ServiceReference.BreedProperty();
            Forms.Operations.BerryProducePrintForm berryProducedeEditForm = null;
            try
            {
                /* რედაქტირების ფორმა */
                berryProducedeEditForm = new BerryProducePrintForm();
                switch (berryProducedeEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.BreedPropertiesTabPage_Enter(this.BreedPropertiesTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
                //
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadeAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void ClosedRowButton_Click(object sender, EventArgs e)
        {
            Forms.Operations.ClosedRows ClosedRowsForm = null;

            /* რედაქტირების ფორმა */
            ClosedRowsForm = new Operations.ClosedRows();
            ClosedRowsForm.ShowDialog(this);
        }
    }
}

       