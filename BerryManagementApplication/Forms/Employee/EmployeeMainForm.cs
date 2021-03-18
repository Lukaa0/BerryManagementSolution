using BerryManagementApplication.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Employee
{
    public partial class EmployeeMainForm : Form
    {
        #region Private Properties
        private System.Windows.Forms.TabPage _hiddenEmployeeDetailsTabPage;
        private long _employeeIdToFind=0;
        private bool _isUser;
        private string _employeeIdentityToFind=null;
        private BM_Employee_ServiceReference.Person _personData;
        private List<BM_Employee_ServiceReference.Person> _personDatas;
        private List<BM_Employee_ServiceReference.PersonPost> _PersonPosts;
        private BM_Employee_ServiceReference.PersonPost _PersonPost;
        private List<BM_Employee_ServiceReference.Post> _posts;
        private BM_Employee_ServiceReference.Post _post;
        private List<BM_Structure_ServiceReference.Brigade> _brigades;
        private BM_Structure_ServiceReference.Brigade _brigade;
        private long _personPostDataGridViewPersonPostId = 0;


        private long _currentEmployeeId;

        private long _id;

        //პირადი ტაბის სექცია
        private bool _personDocumentsDataGridViewFill;
        private bool _careerDataGridViewFill;
        private bool _employeeHistoryDataGridViewFill;
        
        #endregion

        #region Constructors
        public EmployeeMainForm()
        {
            InitializeComponent();
        }
        public EmployeeMainForm(long EmployeeIdToFind)
        {
            InitializeComponent();
            this._employeeIdToFind = EmployeeIdToFind;
            this._currentEmployeeId = (this._employeeIdToFind > 0) ? this._employeeIdToFind : this._currentEmployeeId;
        }

        public EmployeeMainForm(string EmployeeIdentityToFind)
        {
            InitializeComponent();
            
            this._employeeIdentityToFind = EmployeeIdentityToFind;
            
        }

        #endregion

        public void ActivateTabPage(string name)
        {
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            this.EmployeeMainTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.EmployeeMainTabControl, tabPageName);
        }
        private void EmployeeMainForm_Load(object sender, EventArgs e)
        {
            string errorMessage = null;
            List<BM_Structure_ServiceReference.Post> Post = null;

            try
            {
               
                // შევინახოთ დეტალური ინფორმაციის ტაბი
                this._hiddenEmployeeDetailsTabPage = this.EmployeeMainTabControl.TabPages["EmployeeDetailsTabPage"];
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    Post = StructureService.GetPosts(null, null, ref errorMessage).ToList();
                }


                /*თანამდებობის კომბო*/
                this.PersonPostPostValueComboBox.DataSource = Post;
                this.PersonPostPostValueComboBox.DisplayMember = "Post_Name";
                this.PersonPostPostValueComboBox.ValueMember = "Post_Id";
                this.PersonPostPostValueComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeMainForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
            }
            finally
            {
            }

        }

        #region საძიებელი ტაბის აქტივაცია და ფუნქციონალი
        private void EmployeeFindTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                if (this.EmployeeMainTabControl.TabPages.Contains(this._hiddenEmployeeDetailsTabPage))
                    this.EmployeeMainTabControl.TabPages.Remove(this.EmployeeMainTabControl.TabPages[1]);
                this.MainFiltersViewDataButton.Enabled = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeFindTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }



        private void EmployeeIDValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // ვატარებთ მხოლოდ ციფრულ სიმბოლოებს და backspace
                e.Handled = !System.Char.IsDigit(e.KeyChar) && !(e.KeyChar == '\b');
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeIDValueTextBox_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void MainEmployeeCode1ValueTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // ვატარებთ მხოლოდ ციფრულ სიმბოლოებს
                e.Handled = !System.Char.IsDigit(e.KeyChar) && !(e.KeyChar == '\b'); 
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainEmployeeCode1ValueTextBox_KeyPress", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        

        // ძიების ღილაკი
        private void MainFiltersViewDataButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.FillEmployeeFindTabPageXData();
                // დავცალოთ ფილტრაციის პანელი
                this.ClearFindPanel();
                /* გავააქტიუროთ ცხრილი */
                if (this.Visible && (this.MainFindResultsDataGridView.RowCount > 0))
                    this.MainFindResultsDataGridView.Focus();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainFiltersViewDataButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // ავტომატური შეყობინებების პარამეტრების რედაქტირების ღილაკი
        private void NotificationSettingsButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.Person employeeShort = null;
            List<BM_Employee_ServiceReference.Person> employeeShortData = null;
            //HR.Forms.Notification.NotificationServiceForm notificationsEditor = null;
            int iCounter = 0;

            try
            {
                // ფილტრი
                if (this.MainFindResultsDataGridView.RowCount == 1)
                    this.MainFindResultsDataGridView.Rows[0].Selected = true;

                // ამოვყაროთ შერჩეული თანამშრომლების იდენტიფიკატორები

                if (this.MainFindResultsDataGridView.SelectedRows != null &&
                    this.MainFindResultsDataGridView.SelectedRows.Count > 0)
                {
                    employeeShortData = new List<BM_Employee_ServiceReference.Person>();

                    for (iCounter = 0; iCounter < this.MainFindResultsDataGridView.SelectedRows.Count; iCounter++)
                    {
                        employeeShort = (BM_Employee_ServiceReference.Person)this.MainFindResultsDataGridView.SelectedRows[iCounter].DataBoundItem;
                        employeeShortData.Add(employeeShort);

                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("არ არის მონიშნული არცერთი თანამშრომელი", "ავტომატური შეტყობინებები", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                // გამოვიძახოთ ავტომატური შეტყობინებების სერვისი
                employeeShortData = (employeeShortData == null) ? new List<BM_Employee_ServiceReference.Person>() : employeeShortData;
                //notificationsEditor = new Notification.NotificationServiceForm(employeeShortData);
                //notificationsEditor.ShowDialog(this);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: NotificationSettingsButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // დეტალური ინფორმაციის ღილაკი
        private void MainXEmployeeDetailInfoButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClearData();

                if ((this.EmployeeMainTabControl.TabPages.Count < 2) &&
                    (this.MainFindResultsDataGridView.RowCount > 0) &&
                    (this.MainFindResultsDataGridView.CurrentRow != null) &&
                    (this.MainFindResultsDataGridView.CurrentRow.Cells[0].Value != System.DBNull.Value))
                {
                    //this._hiddenEmployeeDetailsTabPage.Text = this.MainXEmployeeFirstNameValueLabel.Text.Trim();
                    this.EmployeeMainTabControl.TabPages.Add(this._hiddenEmployeeDetailsTabPage);
                    //if (this._toolTip == null)
                    //    this._toolTip = new ToolTip();
                    //this._toolTip.SetToolTip(this.DetailsCode1TitleLabel, "კოდი");
                    //this._toolTip.SetToolTip(this.DetailsCode2TitleLabel, "იუზერი");
                    /* დავაყენოთ პერსონალური მონაცემების ტაბკონტროლის ტაბის ინდექსი -1-ზე(სასტარტო შესვლა ამ ტაბკონტროლში) */
                    this.PersonalTabControl.SelectedIndex = -1;
                    /* გავააქტიუროთ EmployeeDetailsTabPage */
                    this.EmployeeMainTabControl.SelectedIndex = this.EmployeeMainTabControl.TabPages.IndexOf(this._hiddenEmployeeDetailsTabPage);
                    /* უფლებების ფორმირება ახლად დამატებული ტაბისთვის */
                    // დროებით გათიშულია
                    Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
                    // დროებით გათიშულია :::
                    /* EmployeeDetailsTabPage-ის EmployeeTabControl-ზე გავააქტიუროთ DetailsTabPage */
                    this.EmployeeTabControl.SelectedIndex = 0;
                    /* კარიერის ქვე ტაბ კონტროლის სასტარტო ტაბი */
                    this.CareerTabControl.SelectedIndex = 0;

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainXEmployeeDetailInfoButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // განვსაზღვროთ დეტალიზაციის ღილაკის აქტივობა
        private void MainFindResultsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.MainXEmployeeDetailInfoButton.Enabled = (this.MainFindResultsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainFindResultsDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // განვსაზღვროთ დეტალიზაციის ღილაკის აქტივობა
        private void MainFindResultsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.MainXEmployeeDetailInfoButton.Enabled = (this.MainFindResultsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainFindResultsDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // მიმდინარე სტრიქონის ცვლილებაზე დამატებითი ინფორმაციის პანელზე ავსახოთ შესაბამისი თანამშრომლის მონაცემები
        private void MainFindResultsDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.MainFindResultsDataGridView.CurrentCell != null)
                {
                    //// მიმდინარე თანამშრომელი
                    this._currentEmployeeId = ((BM_Employee_ServiceReference.Person)this.MainFindResultsDataGridView.CurrentRow.DataBoundItem).Person_Id;
                    // გავასუფთაოთ დამატებითი ინფორმაციის პანელი
                    this.ClearMainAdditionalInfo();
                    // შევავსოთ დამატებითი ინფორმაციის პანელი
                    this.FillMainAdditionalInfo();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainFindResultsDataGridView_RowEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void MainFindResultsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.MainFindResultsDataGridView.CurrentCell != null)
                    this.MainXEmployeeDetailInfoButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: MainFindResultsDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void MainFindResultsDataGridView_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                // შევავსოთ დამატებითი ინფორმაციის პანელი
                this.FillMainAdditionalInfo();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: MainFindResultsDataGridView_CurrentCellChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        #endregion

        #region დეტალური ინფორმაციის მთავარი ტაბის აქტივაცია და ფუნქციონალი
        private void EmployeeDetailsTabPage_Enter(object sender, EventArgs e)
        {
            int iCounter = 0;
            string errorMessage = string.Empty;
            using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeService = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
            {
                this._personDatas = EmployeeService.GetEmployeeShortData(this._currentEmployeeId, this._employeeIdentityToFind, null, null, null,null,true, ref errorMessage).ToList<BM_Employee_ServiceReference.Person>();
                this._personData = this._personDatas.FirstOrDefault();

            }

            if (this._personData != null)
            {
                this.FillDetailsTabPagePersonalData(this._personData);

            }
            try
            {
                // პარამეტრით აქტივაციის რეჟიმი
                if (this._employeeIdToFind > 0 || !System.String.IsNullOrEmpty(this._employeeIdentityToFind))
                {
                    // მომხმარებლის უფლებების კონტროლი
                    Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);

                    // აქტივაცია პარამეტრით
                    //this.EmployeeIDValueTextBox.Text = (this._employeeIdToFind > 0) ? this._employeeIdToFind.ToString().Trim() : System.String.Empty;
                    //this.EmployeeIdentityValueTextBox.Text = this._employeeIdentityToFind.ToString().Trim();

                    /* ამოვიღოთ ინფორმაცია */
                    //this.FillEmployeeFindTabPageXData();
                    if (this.MainFindResultsDataGridView.RowCount > 0)
                    {
                        // გავასუფთაოთ გამოყენებული საძიებელი ველები
                        this.EmployeeIdentityValueTextBox.Text = System.String.Empty;
                        this.MainEmployeeFirstNameValueTextBox.Text = System.String.Empty;
                        this.MainEmployeeLastNameValueTextBox.Text = System.String.Empty;
                        this.EmployeeIDValueTextBox.Text = System.String.Empty;

                        // გავთიშოთ ძიების ღილაკი
                        this.MainFiltersViewDataButton.Enabled = false;

                        // დავაყენოთ მიმდინარე უჯრა
                        if (this.MainFindResultsDataGridView.CurrentCell == null)
                        {
                            for (iCounter = 0; iCounter < this.MainFindResultsDataGridView.Rows[0].Cells.Count; iCounter++)
                            {
                                if (this.MainFindResultsDataGridView.Rows[0].Cells[iCounter].Visible)
                                {
                                    this.MainFindResultsDataGridView.CurrentCell = this.MainFindResultsDataGridView.Rows[0].Cells[iCounter];
                                    break;
                                }
                            }
                        }

                        
                    }
                   
                }

                // სტანდარტული აქტივაციის რეჟიმი
                if (this.EmployeeTabControl.SelectedIndex == this.EmployeeTabControl.TabPages.IndexOf(this.EmployeeGeneralTabPage))
                    this.EmployeeGeneralTabPage_Enter(this.EmployeeGeneralTabPage, new EventArgs());
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeDetailsTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #region ზოგადი ინფორმაციის ტაბის აქტივაცია და ფუნქციონალი
        private void EmployeeGeneralTabPage_Enter(object sender, EventArgs e)
        {

            try
            {
                this.FillDetailsTabPagePersonalData(this._personData);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeGeneralTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // პერსონალური მონაცემების რედაქტირება
        private void DetailsEditButton_Click(object sender, EventArgs e)
        {
            

            try
            {
                EmployeeEditFrom employeeDataEditor = new EmployeeEditFrom(DataChangeType.Update, ActionMode.WriteAndReturnData, 1, this._personData);
                        switch (employeeDataEditor.ShowDialog(this))
                        {
                            case DialogResult.OK:
                                this._personData = employeeDataEditor.EmployeeObject;
                                this.EmployeeGeneralTabPage_Enter(this.EmployeeGeneralTabPage, new EventArgs());
                                break;
                            case DialogResult.Cancel:
                                break;
                            default:
                                break;
                        }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: DetailsEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void ClearData()
        {
            // დავცალოთ დეტალური მონაცემების პანელი
            this.DetailsEmployeeIDValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeIdentityValueTextBox.Text = System.String.Empty;
            this.DetailsEmployeeFirstNameValueLabel.Text = System.String.Empty;

            //this.DetailsEmployeeNationalityValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeBirthDateValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeIsResidentCheckBox.Checked = false;
            this.DetailsEmployeeCitizenShipValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeSexValueLabel.Text = System.String.Empty;
            //this.DetailsEmployeeMaritalStatusValueLabel.Text = System.String.Empty;

            //this.DetailsEmployeeDrivingLicenseValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeAddress1ValueTextBox.Text = System.String.Empty;
            this.DetailsEmployeeAddress2ValueTextBox.Text = System.String.Empty;
            this.DetailsEmployeePhone1ValueLabel.Text = System.String.Empty;
            this.DetailsEmployeePhone2ValueLabel.Text = System.String.Empty;
            this.DetailsCode1ValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeBankNameValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeBankCodeValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeBankAccountValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeBankClientValueLabel.Text = System.String.Empty;
            //this.DetailsEmployeeMailAddressTitleLabel.Text = System.String.Empty;
            this.DetailsEmployeeSideTypeValueLabel.Text = System.String.Empty;
            this.DetailsEmployeeLegalFormValueLabel.Text = System.String.Empty;
            //this.DetailsEmployeeLegalStatusValueLabel.Text = System.String.Empty;

            DetailsEmployeeCareerStartDateValueLabel.Text = System.String.Empty;
            DetailsEmployeeWorkCalculatedExperienceValueLabel.Text = System.String.Empty;
            DetailsEmployeePostNameValueLabel.Text = System.String.Empty;

            DetailsEmployeeWorkStatusStartDateValueLabel.Text = System.String.Empty;
            DetailsEmployeeWorkStatusEndDateValueLabel.Text = System.String.Empty;

            DetailsEmployeeCareerStartDateValueLabel.Text = System.String.Empty;
            DetailsEmployeeWorkCalculatedExperienceValueLabel.Text = System.String.Empty;
            DetailsEmployeePostNameValueLabel.Text = System.String.Empty;
            DetailsEmployeeWorkStatusStartDateValueLabel.Text = System.String.Empty;
            DetailsEmployeeWorkStatusEndDateValueLabel.Text = System.String.Empty;
            DetailsEmployeeBrigadeValueLabel.Text = System.String.Empty;
        }

        private void FillDetailsTabPagePersonalData(BM_Employee_ServiceReference.Person Employee)
        {
            try
            {
                string errorMessage = string.Empty;
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeService = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {

                    this._PersonPosts = EmployeeService.GetPersonPostData(null,_personData.Person_Id,null,null, ref errorMessage).ToList<BM_Employee_ServiceReference.PersonPost>();
                    this._PersonPost = this._PersonPosts.FirstOrDefault();


                    
                    if (this._PersonPost != null)
                    {
                        this._posts = EmployeeService.GetPostById(_PersonPost.PersonPost_Post_Id, ref errorMessage).ToList<BM_Employee_ServiceReference.Post>();
                        this._post = this._posts.FirstOrDefault();
                    }

                }
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    if (this._PersonPost != null)
                    {
                        this._brigades = StructureService.GetBrigades(this._PersonPost.PersonPost_Brigade_Id, null, ref errorMessage).ToList<BM_Structure_ServiceReference.Brigade>();
                        this._brigade = this._brigades.FirstOrDefault();
                    }
                }

                this.ClearData();


                // გავთიშოთ რედაქტირების ღილაკი
                this.DetailsEditButton.Enabled = false;
                string ErrorMessage = string.Empty;
                BM_Library_ServiceReference.Nationality nationality = null;
                BM_Library_ServiceReference.Bank bank = null;
                BM_Library_ServiceReference.Citizenship citizenship = null;
                BM_Library_ServiceReference.LegalForm legalForm = null;
                BM_Library_ServiceReference.tf_GenderTypes_Result tf_GenderTypes = null;
                BM_Library_ServiceReference.tf_MaritalStatus_Result tf_MaritalStatus = null;
                BM_Library_ServiceReference.tf_SideTypes_Result tf_SideTypes = null;
                BM_Library_ServiceReference.tf_LegalStatuseTypes_Result tf_LegalStatuse = null;

                using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    nationality = LibraryService.GetNationalities(Employee.Person_Nationality_Id, null, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.Nationality>().FirstOrDefault();
                    bank = LibraryService.SelectBanks(Employee.Person_Bank_Id, null, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.Bank>().FirstOrDefault();
                    citizenship = LibraryService.GetCitizenships(Employee.Person_Citizenship_Id, null, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.Citizenship>().FirstOrDefault();
                    legalForm = LibraryService.GetLegalForms(Employee.Person_LegalForm_Id, null, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.LegalForm>().FirstOrDefault();
                    tf_GenderTypes = LibraryService.GetGenderTypes(Employee.Person_GenderType_Id, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.tf_GenderTypes_Result>().FirstOrDefault();
                    tf_MaritalStatus = LibraryService.GetMaritalStatus(Employee.Person_MaritalStatus_Id, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.tf_MaritalStatus_Result>().FirstOrDefault();
                    tf_SideTypes = LibraryService.GetSideTypes(Employee.Person_SideType_Id, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.tf_SideTypes_Result>().FirstOrDefault();
                    tf_LegalStatuse = LibraryService.GetLegalStatuseTypes(Employee.Person_LegalStatuseType_Id, null, null, ref ErrorMessage).ToList<BM_Library_ServiceReference.tf_LegalStatuseTypes_Result>().FirstOrDefault();

                }
                // შევავსოთ დეტალური მონაცემების პანელი
                if (Employee != null)
                {
                    this.DetailsEmployeeIDValueLabel.Text = (Employee.Person_Id > 0) ? Employee.Person_Id.ToString().Trim() : System.String.Empty;
                    this.DetailsEmployeeIdentityValueTextBox.Text = (Employee.Person_Identity != null) ? Employee.Person_Identity.Trim() : System.String.Empty;
                    this.DetailsEmployeeFirstNameValueLabel.Text = (Employee.Person_FirstName != null) ? Employee.Person_FirstName.Trim() : System.String.Empty;
                    this.DetailsEmployeeLastNameValueLabel.Text = (Employee.Person_LastName != null) ? Employee.Person_LastName.Trim() : System.String.Empty;
                    //this.DetailsEmployeeNationalityValueLabel.Text = (Employee.Person_Nationality_Id.HasValue) ? nationality.Nationality_Name.ToString().Trim() : System.String.Empty;
                    this.DetailsEmployeeBirthDateValueLabel.Text = Employee.Person_BirthDate.ToString(Classes.GlobalConstants.SHORT_DATE_FORMAT_GEO);
                    this.DetailsEmployeeIsResidentCheckBox.Checked = Employee.Person_IsResident;
                    this.DetailsEmployeeCitizenShipValueLabel.Text = (Employee.Person_Citizenship_Id.HasValue) && (citizenship != null) ? citizenship.Citizenship_Name.Trim() : System.String.Empty;
                    this.DetailsEmployeeSexValueLabel.Text = tf_GenderTypes.GenderType_Name.Trim();
                    //this.DetailsEmployeeMaritalStatusValueLabel.Text = (Employee.Person_MaritalStatus_Id.HasValue) ? tf_MaritalStatus.MaritalStatus_Name.Trim() : System.String.Empty;
                    //this.DetailsEmployeeDrivingLicenseValueLabel.Text = (Employee.Person_DrivingLicense != null) ? Employee.Person_DrivingLicense.Trim() : System.String.Empty;
                    this.DetailsEmployeeAddress1ValueTextBox.Text = (Employee.Person_Address1 != null) ? Employee.Person_Address1.Trim() : System.String.Empty;
                    this.DetailsEmployeeAddress2ValueTextBox.Text = (Employee.Person_Address2 != null) ? Employee.Person_Address2.Trim() : System.String.Empty;
                    this.DetailsEmployeePhone1ValueLabel.Text = (Employee.Person_Phone1 != null) ? Employee.Person_Phone1.Trim() : System.String.Empty;
                    this.DetailsEmployeePhone2ValueLabel.Text = (Employee.Person_Phone2 != null) ? Employee.Person_Phone2.Trim() : System.String.Empty;
                    this.DetailsCode1ValueLabel.Text = (Employee.Person_Code.HasValue) ? Employee.Person_Code.Value.ToString().Trim() : System.String.Empty;
                    this.DetailsEmployeeBankNameValueLabel.Text = (Employee.Person_Bank_Id != null) && (bank != null) ? bank.Bank_Name.Trim() : System.String.Empty;
                    this.DetailsEmployeeBankCodeValueLabel.Text = (bank != null) && (bank.Bank_Kode != null) ? bank.Bank_Kode.Trim() : System.String.Empty;
                    this.DetailsEmployeeBankAccountValueLabel.Text = (Employee.Person_BankAccount != null) ? Employee.Person_BankAccount.Trim() : System.String.Empty;
                    this.DetailsEmployeeBankClientValueLabel.Text = (Employee.Person_BankClientName != null) ? Employee.Person_BankClientName : System.String.Empty;
                    //this.DetailsEmployeeMailAddressTitleLabel.Text = (Employee.Person_MailAddress != null) ? Employee.Person_MailAddress.Trim() : System.String.Empty;
                    this.DetailsEmployeeSideTypeValueLabel.Text = (Employee.Person_SideType_Id.ToString() != null)&&(tf_SideTypes != null) ? tf_SideTypes.SideType_Name.Trim() : System.String.Empty;
                    this.DetailsEmployeeLegalFormValueLabel.Text = (Employee.Person_LegalForm_Id.HasValue) && (legalForm != null) ? legalForm.LegalForm_Name.Trim() : System.String.Empty;
                    //this.DetailsEmployeeLegalStatusValueLabel.Text = (Employee.Person_LegalStatuseType_Id.HasValue) ? tf_LegalStatuse.LegalStatuseType_Name.Trim() : System.String.Empty;


                    // ჩავრთოთ რედაქტირების ღილაკი
                    this.DetailsEditButton.Enabled = true;


                    if ((this._PersonPost != null))
                    {
                        DetailsEmployeeCareerStartDateValueLabel.Text = _PersonPost.PersonPost_StartDate.ToString();
                        DetailsEmployeeWorkCalculatedExperienceValueLabel.Text = (DateTime.Now.Year - _PersonPost.PersonPost_StartDate.Year).ToString();
                        DetailsEmployeePostNameValueLabel.Text = _post.Post_Name;
                        DetailsEmployeeWorkStatusStartDateValueLabel.Text = _PersonPost.PersonPost_StartDate.ToString();
                        DetailsEmployeeWorkStatusEndDateValueLabel.Text = _PersonPost.PersonPost_EndDate.ToString();
                        DetailsEmployeeBrigadeValueLabel.Text = _brigade.Brigade_Name.ToString();
                        if (_post.Post_Name == "ადმინი")
                        {
                            EditPersonalDataGroupBox.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
            }
        }


        #endregion

        #endregion

        #region პირადი ინფორმაციის მთავარი ტაბის აქტივაცია და ფუნქციონალი
        private void EmployeeTabControl_Enter(object sender, EventArgs e)
        {
            try
            {
                this.PersonalTabControl.SelectedIndex = -1;
                if (this.PersonalTabControl.SelectedIndex < 0)
                {
                    this.PersonalTabControl.TabIndex = 0;
                    this.PersonalTabControl.SelectedIndex = this.PersonalTabControl.TabIndex;
                }

                switch (this.PersonalTabControl.TabIndex)
                {
                    case 0:
                        this.PersonDocumentsTabPage_Enter(this.PersonDocumentsTabPage, new EventArgs());                        
                        break;                  
                    default:
                        break;
                }

                int pCurrentRowIndex = -1;
                // რედაქტირების კონტროლების აქტივობის ინიციალიზაცია


                // დავიმახსოვროთ მიმდინარე სტრიქონის ნომერი
                pCurrentRowIndex = (this.PersonPostDataGridView.CurrentCell != null) ? this.PersonPostDataGridView.CurrentRow.Index : -1;

                this.FillPostssDataGridView(pCurrentRowIndex);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeePersonalTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        #region _ პირადი ინფორმაციის ტაბის პერსონალური დოკუმენტების ქვეტაბის აქტივაცია და ფუნქციონალი

        private void PersonDocumentsTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                this._currentEmployeeId =(this._personData != null) && (this._personData.Person_Id > 0) ? this._personData.Person_Id : this._currentEmployeeId;
                int pCurrentRowIndex = -1;
                // რედაქტირების კონტროლების აქტივობის ინიციალიზაცია
                

                // დავიმახსოვროთ მიმდინარე სტრიქონის ნომერი
                pCurrentRowIndex = (this.PersonDocumentsDataGridView.CurrentCell != null) ? this.PersonDocumentsDataGridView.CurrentRow.Index : -1;

                // შევავსოთ ცხრილი
                this.FillPersonDocumentsDataGridView(pCurrentRowIndex);

           
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void FillPersonDocumentsDataGridView(int inCurrentRowIndex)
        {
            List<BM_Employee_ServiceReference.PersonDocumentModel> personDocumentsData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PersonDocumentsDataGridView.DataSource = null;
                this.PersonDocumentsDataGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    
                        personDocumentsData = EmployeeServiceClient.GetPersonDocuments(null,this._currentEmployeeId, null,null,null,null,null,null,ref ErrorMessage).ToList(); 
                    }
                    
                    // შევავსოთ ცხრილი
                    this.PersonDocumentsDataGridView.DataSource = personDocumentsData;

                    // დავაყენოთ მიმდინარე სტრიქონი და სვეტი თუ მოითხოვება
                    if (inCurrentRowIndex >= 0 && this.PersonDocumentsDataGridView.Rows.Count > 0)
                    {
                        inCurrentRowIndex = (this.PersonDocumentsDataGridView.Rows.Count <= inCurrentRowIndex) ? this.PersonDocumentsDataGridView.Rows.Count - 1 : inCurrentRowIndex;
                        this.PersonDocumentsDataGridView.CurrentCell =
                            this.PersonDocumentsDataGridView.Rows[inCurrentRowIndex].Cells[(this.PersonDocumentsDataGridView.CurrentCell != null) ? this.PersonDocumentsDataGridView.CurrentCell.ColumnIndex : 0];
                    }
              
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillPersonDocumentsDataGridView()");
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void PersonDocumentsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.PersonDocumentAddButton.Enabled = true;
                this.PersonDocumentEditButton.Enabled =  (this.PersonDocumentsDataGridView.RowCount > 0);
                this.PersonDocumentDeleteButton.Enabled = (this.PersonDocumentsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.PersonDocumentAddButton.Enabled = true;
                this.PersonDocumentEditButton.Enabled =  (this.PersonDocumentsDataGridView.RowCount > 0);
                this.PersonDocumentDeleteButton.Enabled = (this.PersonDocumentsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.PersonDocumentEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentAddButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonDocument personDocumentData = null;
            Forms.Employee.PersonDocumentEditForm personDocumentDataEditor = null;
            string EmployeeFullName = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                /* ახალი ობიექტი */
                personDocumentData = new BM_Employee_ServiceReference.PersonDocument()
                {
                    PersonDocument_Person_Id = this._currentEmployeeId
                };

                /* თანამშრომლის მიმდინარე სახელი */
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    EmployeeFullName = this._personData.Person_FirstName + "  " + this._personData.Person_LastName;
                }

                /* რედაქტირების ფორმა */
                personDocumentDataEditor = new PersonDocumentEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,
                                                                      EmployeeFullName,
                                                                      personDocumentData);
                switch (personDocumentDataEditor.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                        this._personDocumentsDataGridViewFill = true;
                        this.PersonDocumentsTabPage_Enter(this.PersonDocumentsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentEditButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonDocument personDocumentData = null;
            BM_Employee_ServiceReference.PersonDocumentModel personDocumentDataModel = null;
            Forms.Employee.PersonDocumentEditForm personDocumentDataEditor = null;

            string EmployeeFullName = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                /* თანამშრომლის მიმდინარე სახელი */
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient hrEmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    EmployeeFullName = this._personData.Person_FirstName + " " + this._personData.Person_LastName;
                }

                /* მიმდინარე ობიექტი */
                personDocumentDataModel = (BM_Employee_ServiceReference.PersonDocumentModel)this.PersonDocumentsDataGridView.CurrentRow.DataBoundItem;
                if (personDocumentDataModel != null)
                {
                    personDocumentData = new BM_Employee_ServiceReference.PersonDocument()
                    {
                        PersonDocument_Id = personDocumentDataModel.PersonDocument_Id,
                        PersonDocument_Person_Id = personDocumentDataModel.PersonDocument_Employee_Id,
                        PersonDocument_FirstName=personDocumentDataModel.PersonDocument_Employee_FirstName,
                        PersonDocument_LastName=personDocumentDataModel.PersonDocument_Employee_LastName,
                        PersonDocument_DocumentType_Id = personDocumentDataModel.PersonDocument_DocumentType_Id,
                        PersonDocument_StartDate = personDocumentDataModel.PersonDocument_StartDate,
                        PersonDocument_EndDate = personDocumentDataModel.PersonDocument_EndDate,
                        PersonDocument_Number = personDocumentDataModel.PersonDocument_Number,
                        PersonDocument_Isuer = personDocumentDataModel.PersonDocument_Isuer,
                        PersonDocument_Citizenship_Id = personDocumentDataModel.Citizenship_Id,
                        PersonDocument_Description = personDocumentDataModel.PersonDocument_Description

                    };

                    /* რედაქტირების ფორმა */
                    personDocumentDataEditor = new PersonDocumentEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          EmployeeFullName,
                                                                          personDocumentData);
                    switch (personDocumentDataEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                            this._personDocumentsDataGridViewFill = true;
                            this.PersonDocumentsTabPage_Enter(this.PersonDocumentsTabPage, new EventArgs());
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
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void PersonDocumentDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonDocument personDocumentData = null;
            BM_Employee_ServiceReference.PersonDocumentModel personDocumentDataModel = null;
            Forms.Employee.PersonDocumentEditForm personDocumentDataEditor = null;
            string EmployeeFullName = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                /* მიმდინარე ობიექტი */
                personDocumentDataModel = (BM_Employee_ServiceReference.PersonDocumentModel)this.PersonDocumentsDataGridView.CurrentRow.DataBoundItem;
                if (personDocumentDataModel != null)
                {
                    personDocumentData = new BM_Employee_ServiceReference.PersonDocument()
                    {
                        PersonDocument_Id = personDocumentDataModel.PersonDocument_Id,
                        PersonDocument_Person_Id = personDocumentDataModel.PersonDocument_Employee_Id,
                        PersonDocument_FirstName = personDocumentDataModel.PersonDocument_Employee_FirstName,
                        PersonDocument_LastName = personDocumentDataModel.PersonDocument_Employee_LastName,
                        PersonDocument_DocumentType_Id = personDocumentDataModel.PersonDocument_DocumentType_Id,
                        PersonDocument_StartDate = personDocumentDataModel.PersonDocument_StartDate,
                        PersonDocument_EndDate = personDocumentDataModel.PersonDocument_EndDate,
                        PersonDocument_Number = personDocumentDataModel.PersonDocument_Number,
                        PersonDocument_Isuer = personDocumentDataModel.PersonDocument_Isuer,
                        PersonDocument_Citizenship_Id = personDocumentDataModel.Citizenship_Id,
                        PersonDocument_Description = personDocumentDataModel.PersonDocument_Description
                    };

                    /* რედაქტირების ფორმა */
                    personDocumentDataEditor = new PersonDocumentEditForm(DataChangeType.Delete,
                                                                          ActionMode.WriteAndReturnData,
                                                                          EmployeeFullName,
                                                                          personDocumentData);
                    switch (personDocumentDataEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                            this._personDocumentsDataGridViewFill = true;
                            this.PersonDocumentsTabPage_Enter(this.PersonDocumentsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("წაშლისთვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }





        #endregion

        #endregion

        #region კარიერის ინფორმაციის მთავარი ტაბის აქტივაცია და ფუნქციონალი
        private void EmployeeCareerTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                this._careerDataGridViewFill = true;        // თანამდებობები

                this.CareerTabControl.SelectedIndex = -1;
                if (this.CareerTabControl.SelectedIndex < 0)
                {
                    this.CareerTabControl.TabIndex = 0;
                    this.CareerTabControl.SelectedIndex = this.CareerTabControl.TabIndex;
                }

                switch (this.CareerTabControl.SelectedIndex)
                {
                    case 0: // სტატუსები
                        //this.CareerSubWorkStatusTabPage_Enter(this.CareerSubWorkStatusTabPage, new EventArgs());
                        break;
                    case 1: // თანამდებობები
                        this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
                        break;
                    case 2:  // შვებულებები
                        //this.CareerSubVacationTabPage_Enter(this.CareerSubVacationTabPage, new EventArgs());
                        break;
                    case 3: // მივლინებები
                        //this.CareerSubMissionTabPage_Enter(this.CareerSubMissionTabPage, new EventArgs());
                        break;
                    case 4: // გაცდენები
                        //this.MissedDaysTabPage_Enter(this.MissedDaysTabPage, new EventArgs());
                        break;
                    case 5: // დაგვიანებები
                        //this.DelaysTabPage_Enter(this.DelaysTabPage, new EventArgs());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex )
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        #region  _ კარიერის ტაბის თანამდებობიდ ქვეტაბის აქტივაცია და ფუნქციონალი
        private void CareerSubCareerTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                this._currentEmployeeId = (this._personData != null) && (this._personData.Person_Id > 0) ? this._personData.Person_Id : this._currentEmployeeId;
                int pCurrentRowIndex = -1;
                // რედაქტირების კონტროლების აქტივობის ინიციალიზაცია


                // დავიმახსოვროთ მიმდინარე სტრიქონის ნომერი
                pCurrentRowIndex = (this.PersonPostDataGridView.CurrentCell != null) ? this.PersonPostDataGridView.CurrentRow.Index : -1;

                // შევავსოთ ცხრილი
                this.FillPostssDataGridView(pCurrentRowIndex);


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CareerSubCareerTabPage_Enter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


        

        private void FillPostssDataGridView(int inCurrentRowIndex)
        {
            List<BM_Employee_ServiceReference.PersonPostModel> personPostsData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PersonPostDataGridView.DataSource = null;
                this.PersonPostDataGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {

                    personPostsData = EmployeeServiceClient.GetPersonPostModel(this._currentEmployeeId, ref ErrorMessage).ToList();
                }

                // შევავსოთ ცხრილი
                this.PersonPostDataGridView.DataSource = personPostsData;

                //თანამდებობისთის როლის არსებობის შემოწმება
                if (personPostsData != null || this._isUser)
                {
                    if (CheckAllPostHasRole(personPostsData))
                    {
                        InsertUser();
                    }
                }
                // დავაყენოთ მიმდინარე სტრიქონი და სვეტი თუ მოითხოვება
                if (inCurrentRowIndex >= 0 && this.PersonPostDataGridView.Rows.Count > 0)
                {
                    inCurrentRowIndex = (this.PersonPostDataGridView.Rows.Count <= inCurrentRowIndex) ? this.PersonPostDataGridView.Rows.Count - 1 : inCurrentRowIndex;
                    this.PersonPostDataGridView.CurrentCell =
                        this.PersonPostDataGridView.Rows[inCurrentRowIndex].Cells[(this.PersonPostDataGridView.CurrentCell != null) ? this.PersonPostDataGridView.CurrentCell.ColumnIndex : 0];
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

        private void PersonPostDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.PersonPostAddButton.Enabled = true;
                this.PersonPostEditButton.Enabled = (this.PersonPostDataGridView.RowCount > 0);
                this.PersonPostDeleteButton.Enabled = (this.PersonPostDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.PersonPostAddButton.Enabled = true;
                this.PersonPostEditButton.Enabled = (this.PersonPostDataGridView.RowCount > 0);
                this.PersonPostDeleteButton.Enabled = (this.PersonPostDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.PersonPostEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostAddButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonPost personPostData = null;
            Forms.Employee.PersonPostEditForm personPostDataEditor = null;
            string EmployeeFullName = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                /* ახალი ობიექტი */
                personPostData = new BM_Employee_ServiceReference.PersonPost()
                {
                    PersonPost_Person_Id = this._currentEmployeeId
                };

                /* თანამშრომლის მიმდინარე სახელი */
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    EmployeeFullName = this._personData.Person_FirstName + " " +  this._personData.Person_LastName;
                }

                /* რედაქტირების ფორმა */
                personPostDataEditor = new PersonPostEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,
                                                                      this._currentEmployeeId,
                                                                      EmployeeFullName,
                                                                      personPostData);
                switch (personPostDataEditor.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                        this._careerDataGridViewFill = true;
                        if (!_isUser)
                        {
                            if (checkOnePostHasRole(personPostDataEditor.PersonPostObject.PersonPost_Post_Id))
                            {
                                InsertUser();
                            }  
                        }
                        this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostEditButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonPost personPostData = null;
            BM_Employee_ServiceReference.PersonPostModel personPostDataModel = null;
            Forms.Employee.PersonPostEditForm personPostDataEditor = null;

            string EmployeeFullName = System.String.Empty;

                try
                {
                    /* ფილტრი */
                    if (this._currentEmployeeId == 0) return;

                    /* თანამშრომლის მიმდინარე სახელი */
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient hrEmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        EmployeeFullName = this._personData.Person_FirstName + " " + this._personData.Person_LastName;
                    }

                    /* მიმდინარე ობიექტი */
                    personPostDataModel = (BM_Employee_ServiceReference.PersonPostModel)this.PersonPostDataGridView.CurrentRow.DataBoundItem;
                    if (personPostDataModel != null)
                    {
                        personPostData = new BM_Employee_ServiceReference.PersonPost()
                        {
                            PersonPost_Id = personPostDataModel.PersonPost_Id,
                            PersonPost_EmployeeBarCode = personPostDataModel.PersonPost_EmployeeBarCode,
                            PersonPost_BalanceSheetType_Id = personPostDataModel.PersonPost_BalanceSheetType_Id,
                            PersonPost_EmployeeType_Id = personPostDataModel.PersonPost_EmployeeType_Id,
                            PersonPost_Person_Id = personPostDataModel.PersonPost_Person_Id,
                            PersonPost_Post_Id = personPostDataModel.PersonPost_Post_Id,
                            PersonPost_Post_BarCodePrefix = personPostDataModel.PersonPost_Post_BarCodePrefix,
                            PersonPost_Brigade_Id = personPostDataModel.PersonPost_Brigade_Id,
                            PersonPost_StartDate = personPostDataModel.PersonPost_StartDate,
                            PersonPost_EndDate = personPostDataModel.PersonPost_EndDate,
                            PersonPost_DismissalOrder = personPostDataModel.PersonPost_DismissalOrder,
                            PersonPost_Description = personPostDataModel.PersonPost_Description

                        };


                        if (!personPostData.PersonPost_Post_BarCodePrefix.Equals("PP"))
                        {
                            /* რედაქტირების ფორმა */
                            personPostDataEditor = new PersonPostEditForm(DataChangeType.Update,
                                                                                  ActionMode.WriteAndReturnData,
                                                                                  this._currentEmployeeId,
                                                                                  EmployeeFullName,
                                                                                  personPostData);
                            switch (personPostDataEditor.ShowDialog(this))
                            {
                                case System.Windows.Forms.DialogResult.OK:
                                    /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                                    this._careerDataGridViewFill = true;
                                    if (!_isUser)
                                    {
                                        if (checkOnePostHasRole(personPostDataEditor.PersonPostObject.PersonPost_Post_Id))
                                        {
                                            InsertUser();
                                        }
                                    }
                                    this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
                                    break;
                                case System.Windows.Forms.DialogResult.Cancel:
                                    break;
                                default:
                                    break;
                            }
                        }
                        else
                            MessageBox.Show("ადმინისტრატორის ცვლილება შეუძლებელია");
                    }
                    else
                    {
                       throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
                    }
            }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }

        }
        private void CareerDischargeButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonPost personPostData = null;
            BM_Employee_ServiceReference.PersonPostModel personPostDataModel = null;
            Forms.Employee.PersonPostEditForm personPostDataEditor = null;

            string EmployeeFullName = System.String.Empty;

                try
                {
                    /* ფილტრი */
                    if (this._currentEmployeeId == 0) return;

                    /* თანამშრომლის მიმდინარე სახელი */
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient hrEmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        EmployeeFullName = this._personData.Person_FirstName + this._personData.Person_LastName;
                    }

                    /* მიმდინარე ობიექტი */
                    personPostDataModel = (BM_Employee_ServiceReference.PersonPostModel)this.PersonPostDataGridView.CurrentRow.DataBoundItem;
                if (personPostDataModel != null)
                {
                    personPostData = new BM_Employee_ServiceReference.PersonPost()
                    {
                        PersonPost_Id = personPostDataModel.PersonPost_Id,
                        PersonPost_EmployeeBarCode = personPostDataModel.PersonPost_EmployeeBarCode,
                        PersonPost_BalanceSheetType_Id = personPostDataModel.PersonPost_BalanceSheetType_Id,
                        PersonPost_EmployeeType_Id = personPostDataModel.PersonPost_EmployeeType_Id,
                        PersonPost_Person_Id = personPostDataModel.PersonPost_Person_Id,
                        PersonPost_Post_Id = personPostDataModel.PersonPost_Post_Id,
                        PersonPost_Post_BarCodePrefix = personPostDataModel.PersonPost_Post_BarCodePrefix,
                        PersonPost_Brigade_Id = personPostDataModel.PersonPost_Brigade_Id,
                        PersonPost_StartDate = personPostDataModel.PersonPost_StartDate,
                        PersonPost_EndDate = personPostDataModel.PersonPost_EndDate,
                        PersonPost_DismissalOrder = personPostDataModel.PersonPost_DismissalOrder,
                        PersonPost_Description = personPostDataModel.PersonPost_Description

                    };
                    if (!personPostData.PersonPost_Post_BarCodePrefix.Equals("PP"))
                    {
                        /* რედაქტირების ფორმა */
                        personPostDataEditor = new PersonPostEditForm(DataChangeType.Update,
                                                                              ActionMode.WriteAndReturnData,
                                                                              this._currentEmployeeId,
                                                                              true,
                                                                              EmployeeFullName,
                                                                              personPostData);
                        switch (personPostDataEditor.ShowDialog(this))
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                                this._careerDataGridViewFill = true;
                                if (!_isUser)
                                {
                                    if (checkOnePostHasRole(personPostDataEditor.PersonPostObject.PersonPost_Post_Id))
                                    {
                                        InsertUser();
                                    }
                                }
                                this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
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
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }

        }
        private void PersonPostDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonPost personPostData = null;
            BM_Employee_ServiceReference.PersonPostModel personPostDataModel = null;
            Forms.Employee.PersonPostEditForm personPostDataEditor = null;

            string EmployeeFullName = System.String.Empty;
            if (!PersonPost_Post_BarCodePrefix.Equals("PP"))
            {
                try
                {
                    /* ფილტრი */
                    if (this._currentEmployeeId == 0) return;

                    /* მიმდინარე ობიექტი */
                    personPostDataModel = (BM_Employee_ServiceReference.PersonPostModel)this.PersonPostDataGridView.CurrentRow.DataBoundItem;
                    if (personPostDataModel != null)
                    {
                        personPostData = new BM_Employee_ServiceReference.PersonPost()
                        {
                            PersonPost_Id = personPostDataModel.PersonPost_Id,
                            PersonPost_EmployeeBarCode = personPostDataModel.PersonPost_EmployeeBarCode,
                            PersonPost_BalanceSheetType_Id = personPostDataModel.PersonPost_BalanceSheetType_Id,
                            PersonPost_EmployeeType_Id = personPostDataModel.PersonPost_EmployeeType_Id,
                            PersonPost_Person_Id = personPostDataModel.PersonPost_Person_Id,
                            PersonPost_Post_Id = personPostDataModel.PersonPost_Post_Id,
                            PersonPost_Post_BarCodePrefix = personPostDataModel.PersonPost_Post_BarCodePrefix,
                            PersonPost_Brigade_Id = personPostDataModel.PersonPost_Brigade_Id,
                            PersonPost_StartDate = personPostDataModel.PersonPost_StartDate,
                            PersonPost_EndDate = personPostDataModel.PersonPost_EndDate,
                            PersonPost_DismissalOrder = personPostDataModel.PersonPost_DismissalOrder,
                            PersonPost_Description = personPostDataModel.PersonPost_Description

                        };

                        /* რედაქტირების ფორმა */
                        personPostDataEditor = new PersonPostEditForm(DataChangeType.Delete,
                                                                              ActionMode.WriteAndReturnData,
                                                                              this._currentEmployeeId,
                                                                              EmployeeFullName,
                                                                              personPostData);
                        switch (personPostDataEditor.ShowDialog(this))
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                                this._careerDataGridViewFill = true;
                                this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
                                break;
                            case System.Windows.Forms.DialogResult.Cancel:
                                break;
                            default:
                                break;
                        }
                    }
                    else
                        throw new Exception("წაშლისთვის განკუთვნილი ობიექტი ცარიელია");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }
            }
            else
            {
                MessageBox.Show("ადმინის რედაქტირება არ შეიძლება");
            }
        }
        
        private void InsertUser()
        {
            string errorMessage = string.Empty;
            try
            {
                using (BM_Security_ServiceReference.BM_Security_ServiceClient security_ServiceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
                {
                    BM_Security_ServiceReference.User userModel = new BM_Security_ServiceReference.User
                    {
                        User_Person_Id = this._currentEmployeeId,
                        User_Password= "5fa285e1bebe0a6623e33afc04a1fbd5",
                        User_PasswordIsReset=true

                    };
                    security_ServiceClient.InsertUser(userModel, ref errorMessage);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
           
        }
        private bool CheckAllPostHasRole(List<BM_Employee_ServiceReference.PersonPostModel> personPostsData)
        {
            string errorMessage = string.Empty;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient security_ServiceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
            foreach (BM_Employee_ServiceReference.PersonPostModel personPostModel in personPostsData)
            {   
                if(security_ServiceClient.CheckPostRole(personPostModel.PersonPost_Post_Id,ref errorMessage))
                    {
                        return true;
                    }
            }
            }
            return false;

        }
        private bool checkOnePostHasRole(long PostId)
        {
            string errorMessage = string.Empty;
            using (BM_Security_ServiceReference.BM_Security_ServiceClient security_ServiceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
            {
                    if (security_ServiceClient.CheckPostRole(PostId, ref errorMessage))
                    {
                        return true;
                    }
             
            }
            return false;
        }

        //


        #endregion

        #endregion

        #region მონაცემების გამოტანის ფუნქციები
        // ინფორმაციის მოძიება და მონაცემთა პანელების შევსება
        private void FillEmployeeFindTabPageXData()
        {
            List<BM_Employee_ServiceReference.Person> employeeShortData = null;
            bool filter = false;

            try
            {
                /* დავცალოთ დამატებითი ინფორმაცის პანელი */
                this.ClearMainAdditionalInfo();
                /* დავცალოთ მთავარი ცხრილი */
                this.MainFindResultsDataGridView.DataSource = null;
                this.MainFindResultsDataGridView.AutoGenerateColumns = false;
                /* დავცალოთ მოკლე დეტალიზაციის მასივი */
                //this._employeeShortDataArray = null;
                /* გავანულოთ თანამშრომლის მიმდინარე იდენტიფიკატორი */
                this._currentEmployeeId = 0;
                /* გავთიშოთ დეტალურ მონაცემებზე გადასვლის ღილაკი */
                this.MainXEmployeeDetailInfoButton.Enabled = false;

                // მონაცემების მოძიების აუცილებლობის განსაზღვრა
                filter = (this.EmployeeIDValueTextBox.Text.Trim().Length > 0) ||
                         (this.EmployeeIdentityValueTextBox.Text.Trim().Length > 0) ||
                         (this.MainEmployeeFirstNameValueTextBox.Text.Trim().Length > 0) ||
                         (this.MainEmployeeLastNameValueTextBox.Text.Trim().Length > 0) ||
                         (this.MainEmployeeCode1ValueTextBox.Text.Trim().Length > 0) ||
                         (this.PersonPostPostValueComboBox.Text.Trim().Length >0 );

                

                // ფილტრი
                if (filter)
                {
                    // გავანულოთ მიმდინარე პერსონის იდენტიფიკატორი
                    this._currentEmployeeId = 0;
                    string errorMessage=string.Empty;

                    // მონაცემების მოძიება
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        employeeShortData = EmployeeServiceClient.GetEmployeeShortData(
                            (this.EmployeeIDValueTextBox.Text.Trim().Length > 0) ? System.Convert.ToInt32(this.EmployeeIDValueTextBox.Text.Trim()) : (long?)null,
                            (this.EmployeeIdentityValueTextBox.Text.Trim().Length > 0) ? this.EmployeeIdentityValueTextBox.Text.Trim() : null,
                            (this.MainEmployeeFirstNameValueTextBox.Text.Trim().Length > 0) ? this.MainEmployeeFirstNameValueTextBox.Text.Trim() : null,
                            (this.MainEmployeeLastNameValueTextBox.Text.Trim().Length > 0) ? this.MainEmployeeLastNameValueTextBox.Text.Trim() : null,
                            (this.MainEmployeeCode1ValueTextBox.Text.Trim().Length > 0) ? System.Convert.ToInt32(this.MainEmployeeCode1ValueTextBox.Text.Trim()) : (long?)null,
                            (this.PersonPostPostValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.PersonPostPostValueComboBox.SelectedValue) : (long?)null,
                            false,
                            ref errorMessage);
                    }
                    if (employeeShortData != null && employeeShortData.Count != 0)
                    {
                        this.MainFindResultsDataGridView.DataSource = employeeShortData;
                        this._employeeIdentityToFind = employeeShortData.FirstOrDefault().Person_Identity;
                        /* ჩავრთოთ დეტალურ მონაცემებზე გადასვლის ღილაკი */
                        this.MainXEmployeeDetailInfoButton.Enabled = true;
                        /* ჩავრთოთ ცხრილის განახლების ინდიკატორი */
                        this._employeeHistoryDataGridViewFill = true;
                    }
                    else
                    {
                        MessageBox.Show("პიროვნება ასეთი მონაცემებით ვერ მოიძებნა");
                    }
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        MessageBox.Show(errorMessage);
                    }

                }

                // დავცალოთ ფილტრაციის პანელი
                this.ClearFindPanel();
                PersonPostPostValueComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillEmployeeFindTabPageXData", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // საძიებელი ტაბის საძიებელი ნაწილის კონტროლების გასუფთავება
        private void ClearFindPanel()
        {
            try
            {
                // გავასუფთაოთ საძიებელი ველები
                this.EmployeeIdentityValueTextBox.Text = System.String.Empty;
                this.MainEmployeeFirstNameValueTextBox.Text = System.String.Empty;
                this.MainEmployeeLastNameValueTextBox.Text = System.String.Empty;
                this.EmployeeIDValueTextBox.Text = System.String.Empty;
                this.MainEmployeeCode1ValueTextBox.Text = System.String.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: ClearFindPanel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        // დამატებითი მონაცემების პანელის გასუფთავება
        private void ClearMainAdditionalInfo()
        {
            try
            {
                /* დავცალოთ დამატებითი ინფორმაცის პანელი */
                this.MainXEmployeeIdValueLabel.Text = System.String.Empty;
                this.MainXEmployeeIdentityValueTextBox.Text = System.String.Empty;
                this.MainXEmployeeFirstNameValueLabel.Text = System.String.Empty;
                this.MainXEmployeeBirthDateValueLabel.Text = System.String.Empty;
                this.MainXEmployeeIsResidentValueCheckBox.Checked = false;
                this.MainXEmployeeCode1ValueLabel.Text = System.String.Empty;
                this.MainXEmployeeAddress1ValueLabel.Text = System.String.Empty;
                this.MainXEmployeeAddress2ValueLabel.Text = System.String.Empty;
                this.MainXEmployeePhone1ValueLabel.Text = System.String.Empty;
                this.MainXEmployeePhone2ValueLabel.Text = System.String.Empty;
                this.MainXEmployeeBankAccountValueLabel.Text = System.String.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillMainAdditionalInfo()");
            }
            finally
            {
            }
        }

        // დამატებითი მონაცემების დაფის შევსება
        private void FillMainAdditionalInfo()
        {
            BM_Employee_ServiceReference.Person employeeData = null;
            string errorMessage=string.Empty;
            try
            {
                if (this.MainFindResultsDataGridView.CurrentCell != null)
                {
                    employeeData = (BM_Employee_ServiceReference.Person)this.MainFindResultsDataGridView.CurrentRow.DataBoundItem;
                    this._currentEmployeeId = employeeData.Person_Id;

                    using (BM_Security_ServiceReference.BM_Security_ServiceClient security_ServiceClient = new BM_Security_ServiceReference.BM_Security_ServiceClient())
                    {
                        this._isUser = security_ServiceClient.CheckUser(this._currentEmployeeId, ref errorMessage);
                    }
                    //this._employeeIdToFind = employeeData.Person_Id;
                    this._employeeIdentityToFind = employeeData.Person_Identity;

                    // შევავსოთ მოკლე ინფორმაციის ველები
                    if (employeeData.Person_Id > 0)
                    {
                        this.MainXEmployeeIdValueLabel.Text = employeeData.Person_Id.ToString();
                        this.MainXEmployeeIdentityValueTextBox.Text = employeeData.Person_Identity.ToString();
                        this.MainXEmployeeFirstNameValueLabel.Text = employeeData.Person_FirstName.ToString();
                        this.MainXEmployeeLastNameValueLabel.Text = employeeData.Person_LastName.ToString();
                        this.MainXEmployeeBirthDateValueLabel.Text = (employeeData.Person_BirthDate != null) ? employeeData.Person_BirthDate.ToShortDateString().Trim() : System.String.Empty;
                        this.MainXEmployeeIsResidentValueCheckBox.Checked = (bool)employeeData.Person_IsResident;
                        this.MainXEmployeeCode1ValueLabel.Text = employeeData.Person_Code.ToString();
                        this.MainXEmployeeAddress1ValueLabel.Text = (employeeData.Person_Address1 != null) ? employeeData.Person_Address1.ToString() : System.String.Empty;
                        this.MainXEmployeeAddress2ValueLabel.Text = (employeeData.Person_Address2 != null) ? employeeData.Person_Address2.ToString() : System.String.Empty;
                        this.MainXEmployeePhone1ValueLabel.Text = (employeeData.Person_Phone1 != null) ? employeeData.Person_Phone1.ToString() : System.String.Empty;
                        this.MainXEmployeePhone2ValueLabel.Text = (employeeData.Person_Phone2 != null) ? employeeData.Person_Phone2.ToString() : System.String.Empty;
                        this.MainXEmployeeBankAccountValueLabel.Text = (employeeData.Person_BankAccount != null) ? employeeData.Person_BankAccount.ToString() : System.String.Empty;
                    }

                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillMainAdditionalInfo()");
            }
            finally
            {
            }
        }

        private void LabelPrintButton_Click(object sender, EventArgs e)
        {
            string errorMessage = null;
            BM_Employee_ServiceReference.EmployeeLabel employee = null;
            if (this.PersonPostDataGridView.RowCount == 0)
            {
                return;
            }
            BM_Employee_ServiceReference.PersonPostModel personPostDataModel = 
                (BM_Employee_ServiceReference.PersonPostModel)this.PersonPostDataGridView.CurrentRow.DataBoundItem;
            List<long> personPostId = new List<long>() { personPostDataModel.PersonPost_Id };
            using (BM_Employee_ServiceReference.BM_Employee_ServiceClient hrEmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
            {
                employee = 
                    hrEmployeeServiceClient.GetEmployeeLabels(personPostId, ref errorMessage).FirstOrDefault();
            }
            if (employee != null)
            {
                Classes.EmployeeLabel employeeLabel = new Classes.EmployeeLabel()
                {
                    Employee = employee
                };
                List<Classes.EmployeeLabel> employeeLabels = new List<Classes.EmployeeLabel>();
                employeeLabels.Add(employeeLabel);
                Report.TemplatesViewerForm templatesViewerForm = new Report.TemplatesViewerForm(employeeLabels);
                templatesViewerForm.ShowDialog(this);
            }
        }

        private void CareerCustomPrintButton_Click(object sender, EventArgs e)
        {

        }

        private void PunishmentAddButton_Click(object sender, EventArgs e)
        {
            if (_personPostDataGridViewPersonPostId != 0)
            {
                
                Forms.Employee.PunishmentEditForm PunishmentEditForm = null;

                try
                {

                    /* რედაქტირების ფორმა */
                    PunishmentEditForm = new PunishmentEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData, _personPostDataGridViewPersonPostId);
                    switch (PunishmentEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                            this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, " PunishmentAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                }
            }
        }

        private void PunishmentEditButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.Punishment punishment = new BM_Employee_ServiceReference.Punishment();
            BM_Employee_ServiceReference.PunishmentModel punishmentMod = new BM_Employee_ServiceReference.PunishmentModel();

            Forms.Employee.PunishmentEditForm PunishmentEditForm = null;


            try
            {
                /* მიმდინარე ობიექტი */
                punishmentMod = (BM_Employee_ServiceReference.PunishmentModel)this.PunishmentGridView.CurrentRow.DataBoundItem;
                if (punishmentMod != null)
                {
                    punishment = new BM_Employee_ServiceReference.Punishment()
                    {
                        
                        Punishment_Id = punishmentMod.Punishment_Id,
                        Punishment_DateTime = punishmentMod.Punishment_DateTime,
                        Punishment_PersonPost_Id = _personPostDataGridViewPersonPostId,
                        Punishment_PunishmentType_Id = punishmentMod.Punishment_PunishmentType_Id,
                        Punishment_User_PersonPost_Id = punishmentMod.Punishment_User_PersonPost_Id,
                        Punishment_Description = punishmentMod.Punishment_Description


                    };


                    /* რედაქტირების ფორმა */
                    PunishmentEditForm = new PunishmentEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, punishment);
                    switch (PunishmentEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                            this.CareerSubCareerTabPage_Enter(this.CareerSubCareerTabPage, new EventArgs());
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
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PunishmentEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (PersonPostDataGridView.RowCount != 0)
            {
                if (this.PersonPostDataGridView.Rows[e.RowIndex].Cells["PersonPost_Post_BarCodePrefix"].Value.ToString().Equals("PD"))
                {
                    //CareerSubCareerEditGroupBox.Visible = false;
                    //CareerPartsTabControl.Visible = false;
                }
                else
                {
                    CareerSubCareerEditGroupBox.Visible = true;
                    CareerPartsTabControl.Visible = true;
                }

            }


            FillPunishmentGridView(Int32.Parse(this.PersonPostDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()));


            this._id = Int32.Parse(this.PersonPostDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString()); 

            _personPostDataGridViewPersonPostId = Int32.Parse(this.PersonPostDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        private void FillPunishmentGridView(long Id)
        {
            List<BM_Employee_ServiceReference.PunishmentModel> punishmentData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                /* ფილტრი */
                if (this._currentEmployeeId == 0) return;

                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PunishmentGridView.DataSource = null;
                this.PunishmentGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {

                    punishmentData = EmployeeServiceClient.GetPunishment(Id,null, ref ErrorMessage);
                }
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    throw new Exception(ErrorMessage);
                }

                // შევავსოთ ცხრილი
                this.PunishmentGridView.DataSource = punishmentData;



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillPunishmentGridView()" + ErrorMessage);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void PunishmentPrintButton_Click(object sender, EventArgs e)
        {
            PunishmentPrintForm punishmentPrintForm = new PunishmentPrintForm(this._id);
            punishmentPrintForm.ShowDialog(this);
        }






        #endregion

        //private void ClearMainAdditionalInfo()
        //{
        //    try
        //    {
        //        /* დავცალოთ დამატებითი ინფორმაცის პანელი */
        //        this.MainXEmployeeIdValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeIdentityValueTextBox.Text = System.String.Empty;
        //        this.MainXEmployeeFullNameValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeBirthDateValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeIsResidentValueCheckBox.Checked = false;
        //        this.MainXEmployeeCode1ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeCode2ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeAddress1ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeAddress2ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeePhone1ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeePhone2ValueLabel.Text = System.String.Empty;
        //        this.MainXEmployeeBankAccountValueLabel.Text = System.String.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + " Source: FillMainAdditionalInfo()");
        //    }
        //    finally
        //    {
        //    }
        //}
    }

}



