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
    public partial class PersonDocumentEditForm : Form
    {
        #region Private members
        private string _formTitle;

        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private string _employeeFullName;
        private BM_Employee_ServiceReference.PersonDocument _personDocument;
        private bool _formCloseSwitch;
        #endregion

        #region Constructors
        public PersonDocumentEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;

            this._employeeFullName = System.String.Empty;
            this._personDocument = new BM_Employee_ServiceReference.PersonDocument();
            this._formCloseSwitch = true;
        }
        public PersonDocumentEditForm(DataChangeType inDataChangeType,ActionMode inAtionMode,string inEmployeeFullName,BM_Employee_ServiceReference.PersonDocument inPersonDocument)
        {
            InitializeComponent();

            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;

            this._employeeFullName = inEmployeeFullName;
            this._personDocument = (inPersonDocument != null) ? inPersonDocument : new BM_Employee_ServiceReference.PersonDocument();
            this._formCloseSwitch = true;
        }
        #endregion

        #region Public properties

        public BM_Employee_ServiceReference.PersonDocument PersonDocumentObject
        {
            get { return this._personDocument; }
        }
        #endregion

        #region Public methods
        public int OperateToPersonDocuments(DataChangeType inDataChangeType, ref BM_Employee_ServiceReference.PersonDocument inPersonDocument, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (inPersonDocument != null)
                {
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                EmployeeServiceClient.InsertPersonDocument(ref inPersonDocument , ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                EmployeeServiceClient.UpdatePersonDocument(inPersonDocument, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                EmployeeServiceClient.DeletePersonDocument(inPersonDocument,  ref inoutErrorMessage);
                                break;
                            default:
                                throw new Exception("არასწორი ოპერაციის კოდი");
                        }
                    }
                }
                else
                    throw new Exception("დოკუმენტის ობიექტი არავალიდურია");
            }
            catch (Exception ex)
            {
                inoutErrorMessage = ex.Message + " Source: OperateToPersonDocuments";
                iResult = -1;
            }
            finally
            {
            }
            return iResult;
        }
        #endregion

        #region Private methods
        private void PersonDocumentEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.DocumentType> documentTypeData = null;
            List<BM_Library_ServiceReference.Citizenship> citizenshipData = null;
            string pErrorMessage = System.String.Empty;

            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "პერსონალური დოკუმენტი";
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
                        System.Windows.Forms.DialogResult dlgResult =
                            System.Windows.Forms.MessageBox.Show("გთხოვთ დაადასტუროთ მოთხოვნა ჩანაწერის წაშლის შესახებ",
                                                                 this._formTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (dlgResult)
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                if (this.OperateToPersonDocuments(this._dataChangeType, ref this._personDocument, ref pErrorMessage) != 0)
                                    throw new Exception(pErrorMessage);
                                this.DialogResult = System.Windows.Forms.DialogResult.OK;
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
                this.Text = this._formTitle;

                /* კომბოების შევსება
                 * ================= */
               
                using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryServiceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    string errorMessage=string.Empty;
                    // დოკუმენტის ტიპები
                    documentTypeData = LibraryServiceClient.GetDocumentTyped(null,null,ref errorMessage).ToList();
                    // დოკუმენტის ტიპების კომბო
                    this.PersonDocumentTypeValueComboBox.DataSource = documentTypeData;
                    this.PersonDocumentTypeValueComboBox.DisplayMember = "DocumentType_Name";
                    this.PersonDocumentTypeValueComboBox.ValueMember = "DocumentType_Id";
                    this.PersonDocumentTypeValueComboBox.SelectedIndex = -1;
                    if (documentTypeData != null && this._personDocument.PersonDocument_DocumentType_Id > 0)
                        foreach (BM_Library_ServiceReference.DocumentType dT in documentTypeData)
                            if ((dT.DocumentType_Id == this._personDocument.PersonDocument_DocumentType_Id) && this.PersonDocumentTypeValueComboBox.Items.Contains(dT))
                            {
                                this.PersonDocumentTypeValueComboBox.SelectedIndex = this.PersonDocumentTypeValueComboBox.Items.IndexOf(dT);
                                break;
                            }

                    // მოქალაქეობა
                    
                    citizenshipData = LibraryServiceClient.GetCitizenships(null, null,null,ref errorMessage).ToList();
                    // მოქალაქეობის კომბო
                    this.PersonDocumentCitizenshipValueComboBox.DataSource = citizenshipData;
                    this.PersonDocumentCitizenshipValueComboBox.DisplayMember = "Citizenship_Name";
                    this.PersonDocumentCitizenshipValueComboBox.ValueMember = "Citizenship_Id";
                    this.PersonDocumentCitizenshipValueComboBox.SelectedIndex = -1;
                    if (citizenshipData != null && this._personDocument.PersonDocument_Citizenship_Id > 0)
                        foreach (BM_Library_ServiceReference.Citizenship cs in citizenshipData)
                            if ((cs.Citizenship_Id == this._personDocument.PersonDocument_Citizenship_Id) && this.PersonDocumentCitizenshipValueComboBox.Items.Contains(cs))
                            {
                                this.PersonDocumentCitizenshipValueComboBox.SelectedIndex = this.PersonDocumentCitizenshipValueComboBox.Items.IndexOf(cs);
                                break;
                            }
                }

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.EmployeeFullNameValueLabel.Text = this._employeeFullName;
                this.PersonDocumentPersonFirstNameValueTextBox.Text = this._personDocument.PersonDocument_FirstName;
                this.PersonDocumentPersonLastNameValueTextBox.Text = this._personDocument.PersonDocument_LastName;
                this.PersonDocumentStartDateValueDateTimePicker.Value = (this._personDocument.PersonDocument_StartDate != System.DateTime.MinValue && this._personDocument.PersonDocument_StartDate != System.DateTime.MaxValue) ? this._personDocument.PersonDocument_StartDate : DateTime.Today;
                this.PersonDocumentEndDateValueDateTimePicker.Value = (this._personDocument.PersonDocument_EndDate.HasValue) ? this._personDocument.PersonDocument_EndDate.Value : DateTime.Today;
                this.PersonDocumentEndDateTitleCheckBox.Checked = (this._personDocument.PersonDocument_EndDate.HasValue);
                this.PersonDocumentEndDateValueDateTimePicker.Enabled = this.PersonDocumentEndDateTitleCheckBox.Checked;
                this.PersonDocumentDocumentNumberValueTextBox.Text = this._personDocument.PersonDocument_Number;
                this.PersonDocumentDocumentIssuerValueTextBox.Text = this._personDocument.PersonDocument_Isuer;
                this.PersonDocumentDescriptionValueTextBox.Text = this._personDocument.PersonDocument_Description;

                // თარიღის ქართული ფორმატი
                this.PersonDocumentStartDateValueDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.PersonDocumentStartDateValueDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.PersonDocumentEndDateValueDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.PersonDocumentEndDateValueDateTimePicker.Format = DateTimePickerFormat.Custom;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: PersonDocumentEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            finally
            {
            }
        }

        private void PersonDocumentAddDocumentTypeButton_Click(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.DocumentType> documentTypeData = null;
            BM_Library_ServiceReference.DocumentType newDocumentType = null;
            Libraries.DocumentTypeEditForm documentTypeEditor = null;

            try
            {
                documentTypeEditor = new Libraries.DocumentTypeEditForm();
                switch (documentTypeEditor.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        // წამოვიღოთ ახალი დოკუმენტის ტიპი
                        newDocumentType = documentTypeEditor.DocumentTypeObject;
                        if (newDocumentType != null)
                        {
                            // შევავსოთ დოკუმენტის ტიპების კომბო თავიდან და გავაკეთოთ პოზიციონირება ახალ ტიპზე
                            using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryServiceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                            {
                                string errorMessage = string.Empty;
                                // დოკუმენტის ტიპები
                                documentTypeData = LibraryServiceClient.GetDocumentTyped(null, null,ref errorMessage).ToList();
                                // დოკუმენტის ტიპების კომბო
                                this.PersonDocumentTypeValueComboBox.DataSource = documentTypeData;
                                this.PersonDocumentTypeValueComboBox.DisplayMember = "DocumentType_Name";
                                this.PersonDocumentTypeValueComboBox.ValueMember = "DocumentType_Id";
                                this.PersonDocumentTypeValueComboBox.SelectedIndex = -1;
                                if (documentTypeData != null && newDocumentType.DocumentType_Id > 0)
                                    foreach (BM_Library_ServiceReference.DocumentType dT in documentTypeData)
                                        if ((dT.DocumentType_Id == newDocumentType.DocumentType_Id) && this.PersonDocumentTypeValueComboBox.Items.Contains(dT))
                                        {
                                            this.PersonDocumentTypeValueComboBox.SelectedIndex = this.PersonDocumentTypeValueComboBox.Items.IndexOf(dT);
                                            break;
                                        }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentAddDocumentTypeButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentAddCitizenshipButton_Click(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.Citizenship> citizenshipData = null;
            BM_Library_ServiceReference.Citizenship newCitizenship = null;
            Libraries.CitizenshipEditForm citizenshipEditor = null;

            try
            {
                citizenshipEditor = new Libraries.CitizenshipEditForm();
                switch (citizenshipEditor.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        // წამოვიღოთ ახალი მოქალაქეობა
                        newCitizenship = citizenshipEditor.CitizenshipObject;
                        if (newCitizenship != null)
                        {
                            using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryServiceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                            {
                                string errorMessage = string.Empty;
                                // მოქალაქეობა
                                citizenshipData = LibraryServiceClient.GetCitizenships(null, null,null, ref errorMessage).ToList();
                                // მოქალაქეობის კომბო
                                this.PersonDocumentCitizenshipValueComboBox.DataSource = citizenshipData;
                                this.PersonDocumentCitizenshipValueComboBox.DisplayMember = "Citizenship_Name";
                                this.PersonDocumentCitizenshipValueComboBox.ValueMember = "Citizenship_Id";
                                this.PersonDocumentCitizenshipValueComboBox.SelectedIndex = -1;
                                if (citizenshipData != null && newCitizenship.Citizenship_Id > 0)
                                    foreach (BM_Library_ServiceReference.Citizenship cs in citizenshipData)
                                        if ((cs.Citizenship_Id == newCitizenship.Citizenship_Id) && this.PersonDocumentCitizenshipValueComboBox.Items.Contains(cs))
                                        {
                                            this.PersonDocumentCitizenshipValueComboBox.SelectedIndex = this.PersonDocumentCitizenshipValueComboBox.Items.IndexOf(cs);
                                            break;
                                        }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentAddCitizenshipButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonDocumentEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.PersonDocumentEndDateValueDateTimePicker.Enabled = this.PersonDocumentEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonDocument pPersonDocument = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.PersonDocumentTypeValueComboBox.SelectedItem == null)
                {
                    //this._formCloseSwitch = false;
                    throw new Exception("არ არის მითითებული დოკუმენტის ტიპი!");
                }

                if (this.PersonDocumentCitizenshipValueComboBox.SelectedItem == null)
                {
                    //this._formCloseSwitch = false;
                    throw new Exception("არ არის მითითებული მოქალაქეობა!"); 
                }
                if (this.PersonDocumentDocumentNumberValueTextBox.Text.Trim() == System.String.Empty)
                {
                    //this._formCloseSwitch = false;
                    throw new Exception("არ არის მითითებული დოკუმენტის ნომერი!");
                }
                    
                if (this.PersonDocumentDocumentIssuerValueTextBox.Text.Trim() == System.String.Empty)
                {
                    //this._formCloseSwitch = false;
                    throw new Exception("არ არის მითითებული დოკუმენტის გამცემი!");
                }
                    
                if (this.PersonDocumentEndDateTitleCheckBox.Checked) 
                {
                    //this._formCloseSwitch = false;
                    if (PersonDocumentEndDateValueDateTimePicker.Value <= PersonDocumentStartDateValueDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!"); 
                }


                this._formCloseSwitch = true;







                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                pPersonDocument = new BM_Employee_ServiceReference.PersonDocument()
                {
                    PersonDocument_Id = this._personDocument.PersonDocument_Id,
                    PersonDocument_Person_Id = this._personDocument.PersonDocument_Person_Id,
                    PersonDocument_DocumentType_Id = (this.PersonDocumentTypeValueComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonDocumentTypeValueComboBox.SelectedValue) : 0,
                    PersonDocument_StartDate = this.PersonDocumentStartDateValueDateTimePicker.Value,
                    PersonDocument_EndDate = (PersonDocumentEndDateTitleCheckBox.Checked) ? this.PersonDocumentEndDateValueDateTimePicker.Value : (DateTime?)null,
                    PersonDocument_Number = this.PersonDocumentDocumentNumberValueTextBox.Text.Trim(),
                    PersonDocument_Isuer = this.PersonDocumentDocumentIssuerValueTextBox.Text.Trim(),
                    PersonDocument_FirstName = this.PersonDocumentPersonFirstNameValueTextBox.Text.Trim(),
                    PersonDocument_LastName = this.PersonDocumentPersonLastNameValueTextBox.Text.Trim(),
                    PersonDocument_Citizenship_Id = (this.PersonDocumentCitizenshipValueComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonDocumentCitizenshipValueComboBox.SelectedValue) : 0,
                    PersonDocument_Description = this.PersonDocumentDescriptionValueTextBox.Text.Trim()
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToPersonDocuments(this._dataChangeType, ref pPersonDocument, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._personDocument = pPersonDocument;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    /* ვაუქმებთ ოპერაციას */
                    throw new Exception("ოპერაცია წარუმატებლად დასრულდა");
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

        private void PersonDocumentEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
        #endregion
        //

    }
}
