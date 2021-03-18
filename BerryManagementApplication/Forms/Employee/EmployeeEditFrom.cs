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
    public partial class EmployeeEditFrom : Form
    {
        #region Private Members
        private string _formTitle;

        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private long _userId;
        private BM_Employee_ServiceReference.Person _employee;
        private ToolTip _toolTip;
        private bool _formCloseSwitch;
        #endregion


        #region Constructors
        public EmployeeEditFrom(DataChangeType DataChangeType, ActionMode ActionMode, long UserId)
        {
            InitializeComponent();

            this._dataChangeType = DataChangeType;
            this._actionMode = ActionMode;
            this._userId = UserId;
            this._employee = new BM_Employee_ServiceReference.Person();
            this._formCloseSwitch = true;
        }

        public EmployeeEditFrom(DataChangeType DataChangeType, ActionMode ActionMode, long UserId, BM_Employee_ServiceReference.Person Employee)
        {
            InitializeComponent();

            this._dataChangeType = DataChangeType;
            this._actionMode = ActionMode;
            this._userId = UserId;
            this._employee = (Employee != null) ? Employee : new BM_Employee_ServiceReference.Person();
            this._formCloseSwitch = true;
        }
        #endregion

        #region Public Properties
        public BM_Employee_ServiceReference.Person EmployeeObject
        {
            get { return this._employee; }
        }
        #endregion

        #region Private Methods
        /* კოორდინატების დაყენება მართვის მოწმობის კატეგორიების ჩეკბოქსებისთვის */
        //private void MoveDrivingCategoryCheckboxes(int inOffset)
        //{
        //    try
        //    {
        //        // საწყისი პოზიცია
        //        if (inOffset == 0)
        //            this.EmployeeDrivingACategoryCheckBox.Left = 1;
        //        // წანაცვლება მარჯვნივ (<<)
        //        if ((inOffset == 1) && (this.EmployeeDrivingACategoryCheckBox.Left < 0))
        //        {
        //            this.EmployeeDrivingACategoryCheckBox.Left += this.EmployeeDrivingACategoryCheckBox.Width - 1;
        //        }
        //        // წანაცვლება მარცხნივ (>>)
        //        if ((inOffset == -1) && (this.EmployeeDrivingSCategoryCheckBox.Left > 1))
        //        {
        //            this.EmployeeDrivingACategoryCheckBox.Left -= this.EmployeeDrivingACategoryCheckBox.Width - 1;
        //        }
        //        // ვასწორებთ დანარჩენ კონტროლებს
        //        this.EmployeeDrivingBCategoryCheckBox.Left = this.EmployeeDrivingACategoryCheckBox.Left + this.EmployeeDrivingACategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingCCategoryCheckBox.Left = this.EmployeeDrivingBCategoryCheckBox.Left + this.EmployeeDrivingBCategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingDCategoryCheckBox.Left = this.EmployeeDrivingCCategoryCheckBox.Left + this.EmployeeDrivingCCategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingBECategoryCheckBox.Left = this.EmployeeDrivingDCategoryCheckBox.Left + this.EmployeeDrivingDCategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingCECategoryCheckBox.Left = this.EmployeeDrivingBECategoryCheckBox.Left + this.EmployeeDrivingBECategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingDECategoryCheckBox.Left = this.EmployeeDrivingCECategoryCheckBox.Left + this.EmployeeDrivingCECategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingTCategoryCheckBox.Left = this.EmployeeDrivingDECategoryCheckBox.Left + this.EmployeeDrivingDECategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingA1CategoryCheckBox.Left = this.EmployeeDrivingTCategoryCheckBox.Left + this.EmployeeDrivingTCategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingB1CategoryCheckBox.Left = this.EmployeeDrivingA1CategoryCheckBox.Left + this.EmployeeDrivingA1CategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingC1CategoryCheckBox.Left = this.EmployeeDrivingB1CategoryCheckBox.Left + this.EmployeeDrivingB1CategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingD1CategoryCheckBox.Left = this.EmployeeDrivingC1CategoryCheckBox.Left + this.EmployeeDrivingC1CategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingC1ECategoryCheckBox.Left = this.EmployeeDrivingD1CategoryCheckBox.Left + this.EmployeeDrivingD1CategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingD1ECategoryCheckBox.Left = this.EmployeeDrivingC1ECategoryCheckBox.Left + this.EmployeeDrivingC1ECategoryCheckBox.Width - 1;
        //        this.EmployeeDrivingSCategoryCheckBox.Left = this.EmployeeDrivingD1ECategoryCheckBox.Left + this.EmployeeDrivingD1ECategoryCheckBox.Width - 1;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + "Source: MoveDrivingCategoryCheckboxes");
        //    }
        //    finally
        //    {
        //    }
        //}

        /* მართვის მოწმობის კონტროლების შევსება ინფორმაციით */
        //private void AssignDrivingLicenseDataToControls(string inDrivingLicenseData)
        //{
        //    string[] DrivingLicenseParts = null;
        //    int iCounter = 0;
        //    try
        //    {
        //        // დავანაწევროთ მონაცემები
        //        DrivingLicenseParts = inDrivingLicenseData.Split(new char[] { Classes.GlobalConstants.SEMICOLON_SEPARATOR });
        //        if (DrivingLicenseParts != null)
        //        {
        //            // Convert to upper case
        //            for (iCounter = DrivingLicenseParts.GetLowerBound(0) + 1; iCounter <= DrivingLicenseParts.GetUpperBound(0); iCounter++)
        //                DrivingLicenseParts[iCounter] = DrivingLicenseParts[iCounter].Trim().ToUpper();
        //            // ტექსტური ნაწილი
        //            this.EmployeeDrivingLicenseValueTextBox.Text = DrivingLicenseParts[0].Trim();
        //            // კატეგორიები
        //            foreach (object CheckBoxObject in this.EmployeeDrivingCategoriesPanel.Controls)
        //            {
        //                if (CheckBoxObject.GetType() == this.EmployeeDrivingACategoryCheckBox.GetType())
        //                    if (DrivingLicenseParts.Contains(((System.Windows.Forms.CheckBox)CheckBoxObject).Text.Trim().ToUpper()))
        //                        ((System.Windows.Forms.CheckBox)CheckBoxObject).Checked = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + "Source: AssignDrivingCategoryCheckboxes");
        //    }
        //    finally
        //    {
        //    }
        //}

        /* მონაცემების კონკატენაცია მართვის მოწმობის კონტროლებიდან */
        //private string GetDrivingLicenseDataString()
        //{
        //    string sResult = System.String.Empty;
        //    int iCounter = 0;

        //    try
        //    {
        //        // ტექსტური ნაწილი
        //        sResult = (this.EmployeeDrivingLicenseValueTextBox.Text.Trim().Length > 0) ? this.EmployeeDrivingLicenseValueTextBox.Text.Trim() : Classes.GlobalConstants.EMPTY_DRIVER_LICENSE;
        //        // კეტეგორიების ნაწილი
        //        for (iCounter = this.EmployeeDrivingCategoriesPanel.Controls.Count - 1; iCounter >= 0; iCounter--)
        //        {
        //            if (this.EmployeeDrivingCategoriesPanel.Controls[iCounter].GetType() == this.EmployeeDrivingACategoryCheckBox.GetType())
        //                if (((System.Windows.Forms.CheckBox)this.EmployeeDrivingCategoriesPanel.Controls[iCounter]).Checked)
        //                    sResult += Classes.GlobalConstants.SEMICOLON_SEPARATOR +
        //                               ((System.Windows.Forms.CheckBox)this.EmployeeDrivingCategoriesPanel.Controls[iCounter]).Text.Trim().ToUpper();
        //        }
        //        // გავასუფთაოთ დასაბრუნებელი ველი თუ არ გვაქვს ინფორმაცია
        //        sResult = (sResult == Classes.GlobalConstants.EMPTY_DRIVER_LICENSE) ? System.String.Empty : sResult.Trim();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message + "Source: GetDrivingLicenseDataString");
        //    }
        //    finally
        //    {
        //    }
        //    return sResult;
        //}

        private int OperateToEmployees(DataChangeType DataChangeType, ref BM_Employee_ServiceReference.Person Employee, ref string ErrorMessage)
        {
            int iResult = 0;

            try
            {
                ErrorMessage = System.String.Empty;

                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    switch (DataChangeType)
                    {
                        case DataChangeType.Insert:
                            EmployeeServiceClient.InsertEmployee(ref Employee,ref ErrorMessage);
                            break;
                        case DataChangeType.Update:
                            EmployeeServiceClient.UpdateEmployee(Employee, this._userId, ref ErrorMessage);
                            break;
                        case DataChangeType.Delete:
                            EmployeeServiceClient.DeletePerson(Employee, this._userId, ref ErrorMessage);
                            break;
                        default:
                            throw new Exception("არასწორი ოპერაციის კოდი");
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message + " Source: OperateToEmployees " + ErrorMessage;
                iResult = -1;
            }
            finally
            {
            }
            return iResult;
        }

        private void EmployeeEditForm_Load(object sender, EventArgs e)
        {
            string pErrorMessage = System.String.Empty;
            // HR_Employee_ServiceReference.Employee employee = null;
            //List<HR_Employee_ServiceReference.Name> names = null;
            List<BM_Library_ServiceReference.Bank> banks = null;
            List<BM_Library_ServiceReference.tf_MaritalStatus_Result> maritalStatuses = null;
            List<BM_Library_ServiceReference.Nationality> nationalities = null;
            List<BM_Library_ServiceReference.Citizenship> citizenships = null;
            List<BM_Library_ServiceReference.LegalForm> legalForm = null;
            List<BM_Library_ServiceReference.tf_LegalStatuseTypes_Result> legalStatus = null;
            List<BM_Library_ServiceReference.tf_SideTypes_Result> sideType = null;

            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "თანამშრომელი";
                switch (this._dataChangeType)
                {
                    case DataChangeType.Insert:
                        this._formTitle += " [დამატება]";
                        break;
                    case DataChangeType.Update:
                        this._formTitle += " [რედაქტირება]";
                        break;
                    case DataChangeType.Delete:
                        this._formTitle += " [წაშლა]";
                        System.Windows.Forms.DialogResult dglResult = System.Windows.Forms.MessageBox.Show("გთხოვთ დაადასტუროთ მოთხოვნა ჩანაწერის წაშლის შესახებ", this._formTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (dglResult)
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                if (OperateToEmployees(this._dataChangeType, ref this._employee, ref pErrorMessage) != 0)
                                    throw new Exception("შეცდომა ჩანაწერის წაშლის დროს");
                                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                                break;
                            default:
                                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                                break;
                        }
                        this.Close();
                        return;
                    default:
                        break;
                }
                // ფორმის სათაური
                this.Text = this._formTitle;

                // კომენტარების დამხმარე კოდებისათვის
                this._toolTip = new ToolTip();
                this._toolTip.SetToolTip(this.EmployeeCode1TitleLabel, "კოდი");

                // კატეგორიების ჩეკბოქსების პოზიციონირება
                //this.MoveDrivingCategoryCheckboxes(0);

                

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.EmployeeIDValueLabel.Text = (this._employee.Person_Id == 0) ? System.String.Empty : this._employee.Person_Id.ToString().Trim();
                this.EmployeeFirstNameTextBox.Text = (this._employee.Person_FirstName != null) ? this._employee.Person_FirstName : System.String.Empty;
                this.EmployeeLastNameTextBox.Text = (this._employee.Person_LastName != null) ? this._employee.Person_LastName : System.String.Empty;
                this.EmployeeCode1ValueMaskedTextBox.Text = (this._employee.Person_Code.HasValue) ? this._employee.Person_Code.Value.ToString().Trim() : System.String.Empty;
                //დასამატებლებია
                this.EmployeeIsResidentCheckBox.Checked = this._employee.Person_IsResident;
                this.EmployeeIdentityValueTextBox.Text = (this._employee.Person_Identity != null) ? this._employee.Person_Identity : System.String.Empty;
                this.EmployeeSexMaleRadioButton.Checked = this._employee.Person_GenderType_Id;
                this.EmployeeSexFemaleRadioButton.Checked = !this._employee.Person_GenderType_Id;
                this.EmployeeBirthDateValueDateTimePicker.Value = ((this._employee.Person_BirthDate != null) && (this._employee.Person_BirthDate != System.DateTime.MinValue)) ? (DateTime)this._employee.Person_BirthDate : this.EmployeeBirthDateValueDateTimePicker.Value;

                this.EmployeeAddress1ValueTextBox.Text = (this._employee.Person_Address1 != null) ? this._employee.Person_Address1 : System.String.Empty;
                this.EmployeeAddress2ValueTextBox.Text = (this._employee.Person_Address2 != null) ? this._employee.Person_Address2 : System.String.Empty;
                this.EmployeePhone1ValueTextBox.Text = (this._employee.Person_Phone1 != null) ? this._employee.Person_Phone1 : System.String.Empty;
                this.EmployeePhone2ValueTextBox.Text = (this._employee.Person_Phone2 != null) ? this._employee.Person_Phone2 : System.String.Empty;
                this.EmployeeBankAccountValueMaskedTextBox.Text = (this._employee.Person_BankAccount != null) ? this._employee.Person_BankAccount : System.String.Empty;
                this.EmployeeBankClientValueTextBox.Text = (this._employee.Person_BankClientName != null) ? this._employee.Person_BankClientName : System.String.Empty;
                //this.EmployeeMailAddressValueTextBox.Text = (this._employee.Person_MailAddress != null) ? this._employee.Person_MailAddress : System.String.Empty;
                /* გადავანაწილოთ მართვის მოწმობის მონაცემები კონტროლებში */
                //this.AssignDrivingLicenseDataToControls((this._employee.Person_DrivingLicense != null) ? this._employee.Person_DrivingLicense : System.String.Empty);

                // ამოვიღოთ საცნობარო მონაცემები კომბოების შესავსებად
                string errorMessage = null;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient BMLibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    nationalities = BMLibraryService.GetNationalities(null, null, null, ref errorMessage).ToList<BM_Library_ServiceReference.Nationality>();
                    citizenships = BMLibraryService.GetCitizenships(null, null,null,ref errorMessage).ToList<BM_Library_ServiceReference.Citizenship>();
                    maritalStatuses = BMLibraryService.GetMaritalStatus(null, null,ref errorMessage).ToList<BM_Library_ServiceReference.tf_MaritalStatus_Result>();
                    banks = BMLibraryService.SelectBanks(null,null,null,ref errorMessage).ToList<BM_Library_ServiceReference.Bank>();
                    legalForm = BMLibraryService.GetLegalForms(null, null, null, ref errorMessage).ToList<BM_Library_ServiceReference.LegalForm>();
                    legalStatus = BMLibraryService.GetLegalStatuseTypes(null, null, null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_LegalStatuseTypes_Result>();
                    sideType = BMLibraryService.GetSideTypes(null, null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_SideTypes_Result>();


                }

                // ეროვნება
                //this.EmployeeNationalityIdValueComboBox.DataSource = nationalities;
                //this.EmployeeNationalityIdValueComboBox.DisplayMember = "Nationality_Name";
                //this.EmployeeNationalityIdValueComboBox.ValueMember = "Nationality_Id";
                //this.EmployeeNationalityIdValueComboBox.SelectedIndex = -1;

                //if ((this.EmployeeNationalityIdValueComboBox.Items.Count > 0) && (this._employee.Person_Nationality_Id.HasValue))
                //    foreach (BM_Library_ServiceReference.Nationality nationality in this.EmployeeNationalityIdValueComboBox.Items)
                //        if ((long)nationality.Nationality_Id == this._employee.Person_Nationality_Id.Value)
                //        {
                //            this.EmployeeNationalityIdValueComboBox.SelectedIndex = this.EmployeeNationalityIdValueComboBox.Items.IndexOf(nationality);
                //            break;
                //        }

                // მოქალაქეობა
                this.EmployeeCitizenshipIdValueComboBox.DataSource = citizenships;
                this.EmployeeCitizenshipIdValueComboBox.DisplayMember = "Citizenship_Name";
                this.EmployeeCitizenshipIdValueComboBox.ValueMember = "Citizenship_Id";
                this.EmployeeCitizenshipIdValueComboBox.SelectedIndex = -1;

                if ((this.EmployeeCitizenshipIdValueComboBox.Items.Count > 0) && this._employee.Person_Citizenship_Id.HasValue)
                    foreach (BM_Library_ServiceReference.Citizenship cs in this.EmployeeCitizenshipIdValueComboBox.Items)
                        if ((long)cs.Citizenship_Id == this._employee.Person_Citizenship_Id.Value)
                        {
                            this.EmployeeCitizenshipIdValueComboBox.SelectedIndex = this.EmployeeCitizenshipIdValueComboBox.Items.IndexOf(cs);
                            break;
                        }
                // სამართლებლივი ფორმა
                this.EmployeeLegalFormValueComboBox.DataSource = legalForm;
                this.EmployeeLegalFormValueComboBox.DisplayMember = "LegalForm_Name";
                this.EmployeeLegalFormValueComboBox.ValueMember = "LegalForm_Id";
                this.EmployeeLegalFormValueComboBox.SelectedIndex = -1;

                if ((this.EmployeeLegalFormValueComboBox.Items.Count > 0) && this._employee.Person_LegalForm_Id.HasValue)
                    foreach (BM_Library_ServiceReference.LegalForm cs in this.EmployeeLegalFormValueComboBox.Items)
                        if ((long)cs.LegalForm_Id == this._employee.Person_LegalForm_Id.Value)
                        {
                            this.EmployeeLegalFormValueComboBox.SelectedIndex = this.EmployeeLegalFormValueComboBox.Items.IndexOf(cs);
                            break;
                        }


                //იურიდიული ფორმა
                //this.EmployeeLegalStatusValueComboBox.DataSource = legalStatus;
                //this.EmployeeLegalStatusValueComboBox.DisplayMember = "LegalStatuseType_Name";
                //this.EmployeeLegalStatusValueComboBox.ValueMember = "LegalStatuseType_Id";
                //this.EmployeeLegalStatusValueComboBox.SelectedIndex = -1;

                //if ((this.EmployeeLegalStatusValueComboBox.Items.Count > 0) && this._employee.Person_LegalStatuseType_Id.HasValue)
                //    foreach (BM_Library_ServiceReference.tf_LegalStatuseTypes_Result cs in this.EmployeeLegalStatusValueComboBox.Items)
                //        if ((long)cs.LegalStatuseType_Id == this._employee.Person_LegalStatuseType_Id.Value)
                //        {
                //            this.EmployeeLegalStatusValueComboBox.SelectedIndex = this.EmployeeLegalStatusValueComboBox.Items.IndexOf(cs);
                //            break;
                //        }

                //SideType
                this.EmployeeSideTypeValueComboBox.DataSource = sideType;
                this.EmployeeSideTypeValueComboBox.DisplayMember = "SideType_Name";
                this.EmployeeSideTypeValueComboBox.ValueMember = "SideType_Id";
                this.EmployeeSideTypeValueComboBox.SelectedIndex = -1;

                if ((this.EmployeeSideTypeValueComboBox.Items.Count > 0))
                    foreach (BM_Library_ServiceReference.tf_SideTypes_Result cs in this.EmployeeSideTypeValueComboBox.Items)
                        if (cs.SideType_Id == this._employee.Person_SideType_Id)
                        {
                            this.EmployeeSideTypeValueComboBox.SelectedIndex = this.EmployeeSideTypeValueComboBox.Items.IndexOf(cs);
                            break;
                        }

                // ოჯახური მდგომარეობის კომბო
                //this.EmployeeMaritalStatusValueComboBox.DataSource = maritalStatuses;
                //this.EmployeeMaritalStatusValueComboBox.DisplayMember = "MaritalStatus_Name";
                //this.EmployeeMaritalStatusValueComboBox.ValueMember = "MaritalStatus_Id";
                //this.EmployeeMaritalStatusValueComboBox.SelectedIndex = -1;

                //if ((this.EmployeeMaritalStatusValueComboBox.Items.Count > 0) && (this._employee.Person_MaritalStatus_Id.HasValue))
                //    foreach (BM_Library_ServiceReference.tf_MaritalStatus_Result maritalStatus in this.EmployeeMaritalStatusValueComboBox.Items)
                //        if ((long)maritalStatus.MaritalStatus_Id == this._employee.Person_MaritalStatus_Id.Value)
                //        {
                //            this.EmployeeMaritalStatusValueComboBox.SelectedIndex = this.EmployeeMaritalStatusValueComboBox.Items.IndexOf(maritalStatus);
                //            break;
                //        }

                // ბანკების კომბო
                this.EmployeeBankIdValueComboBox.DataSource = banks;
                this.EmployeeBankIdValueComboBox.DisplayMember = "Bank_Name";
                this.EmployeeBankIdValueComboBox.ValueMember = "Bank_Id";
                this.EmployeeBankIdValueComboBox.SelectedIndex = -1;

                if ((this.EmployeeBankIdValueComboBox.Items.Count > 0) && (this._employee.Person_Bank_Id.HasValue))
                    foreach (BM_Library_ServiceReference.Bank bank in this.EmployeeBankIdValueComboBox.Items)
                        if ((long)bank.Bank_Id == this._employee.Person_Bank_Id)
                        {
                            this.EmployeeBankIdValueComboBox.SelectedIndex = this.EmployeeBankIdValueComboBox.Items.IndexOf(bank);
                            break;
                        }

                // აუცილებელი სიგრძე და შაბლონი ბანკის ანგარიშისთვის
                this.EmployeeBankAccountValueMaskedTextBox.Mask = Classes.GlobalConstants.BANK_ACCOUNT_MASK;
                this.EmployeeBankAccountValueMaskedTextBox.AsciiOnly = true;

                this.EmployeeDescriptionValueTextBox.Text = (this._employee.Person_Description != null) ? this._employee.Person_Description : System.String.Empty;

                // თარიღის ქართული ფორმატი
                this.EmployeeBirthDateValueDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EmployeeBirthDateValueDateTimePicker.Format = DateTimePickerFormat.Custom;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        /* მართვის კატეგორიების მაჩვენებლის წანაცვლება მარცხნივ */
        //private void EmployeeDrivingCategoriesBackwardButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // წანაცვლება მარცხნივ
        //        this.MoveDrivingCategoryCheckboxes(-1);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeDrivingCategoriesForwardButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //    }
        //}

        

        /* გასვლა ეროვნების დამატებაზე */
        //private void EmployeeAddNationalityButton_Click(object sender, EventArgs e)
        //{
        //    List<BM_Library_ServiceReference.Nationality> nationalities = null;
        //    BM_Library_ServiceReference.Nationality result = null;

        //    try
        //    {
        //        Forms.Libraries.NationalityEditForm nationalityAddEditForm = new Forms.Libraries.NationalityEditForm();
        //        switch (nationalityAddEditForm.ShowDialog(this))
        //        {
        //            case System.Windows.Forms.DialogResult.OK:
        //                // დავაფიქსიროთ ახალი ნაციონალობა
        //                result = nationalityAddEditForm.NationalityObject;
        //                if (result != null && result.Nationality_Id > 0)
        //                    this._employee.Person_Nationality_Id = result.Nationality_Id;
        //                // განვაახლოთ კომბო და დავაყენოთ ახალი ნაციონალობა
        //                string errorMessage = null;
        //                using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
        //                {
        //                    nationalities = LibraryService.GetNationalities(null, null,null,ref errorMessage).ToList<BM_Library_ServiceReference.Nationality>();
        //                    this.EmployeeNationalityIdValueComboBox.DataSource = nationalities;
        //                    this.EmployeeNationalityIdValueComboBox.DisplayMember = "Nationality_Name";
        //                    this.EmployeeNationalityIdValueComboBox.ValueMember = "Nationality_Id";
        //                    this.EmployeeNationalityIdValueComboBox.SelectedIndex = -1;

        //                    if ((this.EmployeeNationalityIdValueComboBox.Items.Count > 0) && (this._employee.Person_Nationality_Id.HasValue))
        //                        foreach (BM_Library_ServiceReference.Nationality nationality in this.EmployeeNationalityIdValueComboBox.Items)
        //                            if ((long)nationality.Nationality_Id == this._employee.Person_Nationality_Id.Value)
        //                            {
        //                                this.EmployeeNationalityIdValueComboBox.SelectedIndex = this.EmployeeNationalityIdValueComboBox.Items.IndexOf(nationality);
        //                                break;
        //                            }
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeAddNationalityButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //    }
        //}

        /* გასვლა მოქალაქეობის დამატებაზე */
        private void EmployeeAddCitizenshipIdButton_Click(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.Citizenship> citizenships = null;
            BM_Library_ServiceReference.Citizenship result = null;

            try
            {
                Forms.Libraries.CitizenshipEditForm citizenshipAddEditForm = new Forms.Libraries.CitizenshipEditForm();
                switch (citizenshipAddEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        result = citizenshipAddEditForm.CitizenshipObject;
                        if (result != null && result.Citizenship_Id > 0)
                            this._employee.Person_Citizenship_Id = result.Citizenship_Id;

                        string errorMessage = null;
                        using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                        {
                            citizenships = LibraryService.GetCitizenships(null, null,null, ref errorMessage).ToList<BM_Library_ServiceReference.Citizenship>();
                            this.EmployeeCitizenshipIdValueComboBox.DataSource = citizenships;
                            this.EmployeeCitizenshipIdValueComboBox.DisplayMember = "Citizenship_Name";
                            this.EmployeeCitizenshipIdValueComboBox.ValueMember = "Citizenship_Id";
                            this.EmployeeCitizenshipIdValueComboBox.SelectedIndex = -1;

                            if ((this.EmployeeCitizenshipIdValueComboBox.Items.Count > 0) && this._employee.Person_Citizenship_Id.HasValue)
                                foreach (BM_Library_ServiceReference.Citizenship cs in this.EmployeeCitizenshipIdValueComboBox.Items)
                                    if ((long)cs.Citizenship_Id == this._employee.Person_Citizenship_Id.Value)
                                    {
                                        this.EmployeeCitizenshipIdValueComboBox.SelectedIndex = this.EmployeeCitizenshipIdValueComboBox.Items.IndexOf(cs);
                                        break;
                                    }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeAddCitizenshipIdButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        /* გასვლა ბანკის დამატებაზე */
        private void EmployeeAddBankButton_Click(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.Bank> banks = null;
            BM_Library_ServiceReference.Bank result = null;

            try
            {
                Forms.Libraries.BankEditForm bankAddEditForm = new Forms.Libraries.BankEditForm();
                switch (bankAddEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        result = bankAddEditForm.BankObject;
                        if (result != null && result.Bank_Id > 0)
                            this._employee.Person_Bank_Id = result.Bank_Id;
                        string errorMessage = null;
                        using (BM_Library_ServiceReference.BM_Library_ServiceClient hrLibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                        {
                            banks = hrLibraryService.SelectBanks(null, null, null,ref errorMessage).ToList<BM_Library_ServiceReference.Bank>();
                            this.EmployeeBankIdValueComboBox.DataSource = banks;
                            this.EmployeeBankIdValueComboBox.DisplayMember = "Bank_Name";
                            this.EmployeeBankIdValueComboBox.ValueMember = "Bank_Id";
                            this.EmployeeBankIdValueComboBox.SelectedIndex = -1;

                            if ((this.EmployeeBankIdValueComboBox.Items.Count > 0) && (this._employee.Person_Bank_Id.HasValue))
                                foreach (BM_Library_ServiceReference.Bank bank in this.EmployeeBankIdValueComboBox.Items)
                                    if ((long)bank.Bank_Id == this._employee.Person_Bank_Id)
                                    {
                                        this.EmployeeBankIdValueComboBox.SelectedIndex = this.EmployeeBankIdValueComboBox.Items.IndexOf(bank);
                                        break;
                                    }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeAddBankButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        /* გასვლა სამართლებლივი ფორმა */
        private void EmployeeAddLegalFormButton_Click(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.LegalForm> legalForm = null;
            BM_Library_ServiceReference.LegalForm result = null;

            try
            {
                Forms.Libraries.LegalFormEditForm legalFormAddEditForm = new Forms.Libraries.LegalFormEditForm();
                switch (legalFormAddEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        result = legalFormAddEditForm.LegalFormObject;
                        if (result != null && result.LegalForm_Id > 0)
                            this._employee.Person_Bank_Id = result.LegalForm_Id;
                        string errorMessage = null;
                        using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                        {
                            legalForm = LibraryService.GetLegalForms(null, null,null, ref errorMessage).ToList<BM_Library_ServiceReference.LegalForm>();
                            this.EmployeeLegalFormValueComboBox.DataSource = legalForm;
                            this.EmployeeLegalFormValueComboBox.DisplayMember = "LegalForm_Name";
                            this.EmployeeLegalFormValueComboBox.ValueMember = "LegalForm_Id";
                            this.EmployeeLegalFormValueComboBox.SelectedIndex = -1;

                            if ((this.EmployeeLegalFormValueComboBox.Items.Count > 0) && (this._employee.Person_LegalForm_Id.HasValue))
                                foreach (BM_Library_ServiceReference.LegalForm legalForms in this.EmployeeLegalFormValueComboBox.Items)
                                    if ((long)legalForms.LegalForm_Id == this._employee.Person_LegalForm_Id)
                                    {
                                        this.EmployeeLegalFormValueComboBox.SelectedIndex = this.EmployeeLegalFormValueComboBox.Items.IndexOf(legalForms);
                                        break;
                                    }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeAddBankButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


        private void CommitButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.Person pEmployee = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                /* შევამოწმოთ დაბადების თარიღის შევსების სისწორე */
                //if (System.String.IsNullOrEmpty(this.EmployeeFullNameValueLabel.Text))
                //    throw new Exception("არ არის შერჩეული პიროვნების სახელი");

                if ((this.EmployeeBirthDateValueDateTimePicker.Value <= this.EmployeeBirthDateValueDateTimePicker.MinDate) ||
                    (this.EmployeeBirthDateValueDateTimePicker.Value >= this.EmployeeBirthDateValueDateTimePicker.MaxDate))
                    throw new Exception("დაბადების დღის თარიღი არასწორადაა შერჩეული");


                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;

                pEmployee = new BM_Employee_ServiceReference.Person()
                {
                    Person_Id = this._employee.Person_Id,
                    Person_Code = (System.String.IsNullOrEmpty(this.EmployeeCode1ValueMaskedTextBox.Text.Trim())) ? (long?)null : System.Convert.ToInt32(this.EmployeeCode1ValueMaskedTextBox.Text.Trim()),
                    Person_FirstName= this.EmployeeFirstNameTextBox.Text.Trim(),
                    Person_LastName = this.EmployeeLastNameTextBox.Text.Trim(),
                    Person_SideType_Id = System.Convert.ToInt32(this.EmployeeSideTypeValueComboBox.SelectedValue) ,
                    Person_LegalForm_Id = (this.EmployeeLegalFormValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeLegalFormValueComboBox.SelectedValue) : (int?)null,
                    //Person_LegalStatuseType_Id = (this.EmployeeLegalStatusValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeLegalStatusValueComboBox.SelectedValue) : (int?)null,
                    Person_IsResident = this.EmployeeIsResidentCheckBox.Checked,
                    Person_Identity = this.EmployeeIdentityValueTextBox.Text.Trim(),
                    Person_GenderType_Id = this.EmployeeSexMaleRadioButton.Checked,
                    Person_BirthDate = (this.EmployeeBirthDateValueDateTimePicker.Value > this.EmployeeBirthDateValueDateTimePicker.MinDate && this.EmployeeBirthDateValueDateTimePicker.Value < this.EmployeeBirthDateValueDateTimePicker.MaxDate) ? this.EmployeeBirthDateValueDateTimePicker.Value : this._employee.Person_BirthDate,
                    Person_Address1 = this.EmployeeAddress1ValueTextBox.Text.Trim(),
                    Person_Address2 = this.EmployeeAddress2ValueTextBox.Text.Trim(),
                    Person_Phone1 = this.EmployeePhone1ValueTextBox.Text.Trim(),
                    Person_Phone2 = this.EmployeePhone2ValueTextBox.Text.Trim(),
                    Person_Bank_Id = (this.EmployeeBankIdValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeBankIdValueComboBox.SelectedValue) : (long?)null,
                    Person_BankAccount = this.EmployeeBankAccountValueMaskedTextBox.Text.Trim().ToUpper(),
                    Person_BankClientName = this.EmployeeBankClientValueTextBox.Text.Trim(),
                    //Person_MailAddress = this.EmployeeMailAddressValueTextBox.Text.Trim(),
                    //Person_MaritalStatus_Id = (this.EmployeeMaritalStatusValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeMaritalStatusValueComboBox.SelectedValue) : (int?)null,
                    //Person_DrivingLicense = this.GetDrivingLicenseDataString(),
                    //Person_Nationality_Id = (this.EmployeeNationalityIdValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeNationalityIdValueComboBox.SelectedValue) : (int?)null,
                    Person_Citizenship_Id = (this.EmployeeCitizenshipIdValueComboBox.SelectedValue != null) ? System.Convert.ToInt32(this.EmployeeCitizenshipIdValueComboBox.SelectedValue) : (int?)null,
                    Person_Description = this.EmployeeDescriptionValueTextBox.Text.Trim()
                };
                BM_Employee_ServiceReference.Person ha = pEmployee;
                BM_Employee_ServiceReference.Person hu = pEmployee;
                

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = OperateToEmployees(this._dataChangeType, ref pEmployee, ref pErrorMessage);
                        break;
                    default:
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება */
                    this._employee = pEmployee;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    throw new Exception("ოპერაცია წარუმატებლად დასრულდა\n" + pErrorMessage);
                }
            }
            catch (Exception ex)
            {
                /* ვაუქმებთ ოპერაციას და ვკრძალავთ ფორმის დახურვას */
                this._formCloseSwitch = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CommitButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            finally
            {
            }
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {
            try
            {
                // ჩავრთოთ ფორმის დახურვის ნებართვა და გავიდეთ ფორმიდან
                this._formCloseSwitch = true;
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RollbackButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void EmployeeEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = !this._formCloseSwitch;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EmployeeEditForm_FormClosing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion

        private void EmployeeFirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmployeeEditFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                e.Cancel = !this._formCloseSwitch;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentEditForm_FormClosing", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        //private void EmployeeDrivingCategoriesForwardButton_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // წანაცვლება მარჯვნივ
        //        this.MoveDrivingCategoryCheckboxes(1);
        //    }
        //    catch (Exception ex)
        //    {
        //        System.Windows.Forms.MessageBox.Show(ex.Message, "Source: EmployeeDrivingCategoriesForwardButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //    }
        //}
    }
}