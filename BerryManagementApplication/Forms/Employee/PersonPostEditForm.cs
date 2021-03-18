using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BerryManagementApplication.Enums;

namespace BerryManagementApplication.Forms.Employee
{
    public partial class PersonPostEditForm : Form
    {
        #region Private members
        private string _formTitle;

        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private bool _dischargeSubMode;         // რედაქტირების ქვერეჟიმი: თანამდებობიდან გათავისუფლება
        private long _PersonId;
        private string _employeeFullName;
        private BM_Employee_ServiceReference.PersonPost _personPostData;
        private bool _Discard = false;

        private bool _formCloseSwitch;
        #endregion
        #region Constructors
        public PersonPostEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode,long PersonID)
        {
            InitializeComponent();

            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._dischargeSubMode = false;
            this._PersonId = PersonID;
            this._employeeFullName = System.String.Empty;
            this._personPostData = new BM_Employee_ServiceReference.PersonPost();



            this._formCloseSwitch = true;
        }

        public PersonPostEditForm(DataChangeType inDataChangeType,
                              ActionMode inAtionMode,
                              long PersonID,
                              string inEmployeeFullName,                             
                             BM_Employee_ServiceReference.PersonPost personPost)
        {
            InitializeComponent();

            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._PersonId = PersonID;
            this._employeeFullName = (inEmployeeFullName != null) ? inEmployeeFullName.TrimEnd() : this._employeeFullName;
            this._personPostData = (personPost != null) ? personPost : new BM_Employee_ServiceReference.PersonPost();
           
            this._formCloseSwitch = true;
        }

        public PersonPostEditForm(DataChangeType inDataChangeType,
                              ActionMode inAtionMode,
                              long PersonID,
                              bool discard,
                              string inEmployeeFullName,
                             BM_Employee_ServiceReference.PersonPost personPost)
        {
            InitializeComponent();

            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._PersonId = PersonID;
            this._employeeFullName = (inEmployeeFullName != null) ? inEmployeeFullName.TrimEnd() : this._employeeFullName;
            this._personPostData = (personPost != null) ? personPost : new BM_Employee_ServiceReference.PersonPost();
            this._Discard = discard;
            this._formCloseSwitch = true;
        }
    #endregion

    #region Public Properties
    public BM_Employee_ServiceReference.PersonPost PersonPostObject
        {
            get { return this._personPostData; }
        }
        #endregion

        #region Public Methods
        /*  Careers ცხრილის რედაქტირების პროცედურა */
        public int OperateToCareers(DataChangeType inDataChangeType, ref BM_Employee_ServiceReference.PersonPost personPost, ref string inoutErrorMessage)
        {
            int iResult = 0;
            
            try
            {
                inoutErrorMessage = System.String.Empty;

                if (personPost != null)
                {
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                EmployeeServiceClient.InsertPersonPost(ref personPost,  ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                /* დავაფორმიროთ კარიერის დასრულების ინდიკაცია */

                                EmployeeServiceClient.UpdatePersonPost(personPost,this._PersonId,ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                               
                                    EmployeeServiceClient.DeletePersonPost(personPost, this._PersonId, ref inoutErrorMessage);
                                    break;
                            default:
                                throw new Exception("არასწორი ოპერაციის კოდი");
                        }
                    }
                }
                else
                    throw new Exception("კარიერის ობიექტი არავალიდურია");
            }
            catch (Exception ex)
            {
                inoutErrorMessage = ex.Message + " Source: OperateToCareers";
                iResult = -1;
            }
            finally
            {
            }
            return iResult;
        }
        #endregion

        private void CommitButton_Click(object sender, EventArgs e)
        {
            BM_Employee_ServiceReference.PersonPost personPostModel = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.PersonPostBrigadeValueComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული ბრიგადა ტიპი!");
                if (this.PersonPostEmployeeTypeComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული თანამშრომლის ტიპი!");
                if (this.PersonPostPostValueComboBox.Text.Trim() == System.String.Empty)
                    throw new Exception("არ არის მითითებული თანამდებობა!");
                if (this.PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (PersonPostEndDateValueDateTimePicker.Value <= PersonPostStartDateValueDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!");
                }

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                BM_Structure_ServiceReference.Post post = null;
                string errorMessage = null;
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    post = StructureService.GetPosts(System.Convert.ToInt32(this.PersonPostPostValueComboBox.SelectedValue), null,ref errorMessage).FirstOrDefault();
                    
                }


                personPostModel = new BM_Employee_ServiceReference.PersonPost()
                {
                    PersonPost_Id = this._personPostData.PersonPost_Id,
                    PersonPost_BalanceSheetType_Id = post.Post_BalanceSheetType_Id,
                    PersonPost_EmployeeType_Id = (this.PersonPostEmployeeTypeComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonPostEmployeeTypeComboBox.SelectedValue) : 0,
                    PersonPost_Post_Id = (this.PersonPostPostValueComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonPostPostValueComboBox.SelectedValue) : 0,
                    PersonPost_Person_Id = this._PersonId,
                    PersonPost_Post_BarCodePrefix = post.Post_BarCodePrefix,
                    PersonPost_Brigade_Id = (this.PersonPostBrigadeValueComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonPostBrigadeValueComboBox.SelectedValue) : 0,
                    PersonPost_Description = this.PersonPostDescriptionValueTextBox.Text.Trim(),
                    PersonPost_DismissalOrder = this.PersonPostDismissalOrderValueTextBox.Text.Trim(),
                    PersonPost_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.PersonPostEndDateValueDateTimePicker.Value : (DateTime?)null,
                    PersonPost_StartDate = this.PersonPostStartDateValueDateTimePicker.Value,
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCareers(this._dataChangeType, ref personPostModel, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._personPostData = personPostModel;
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

        private void PersonPostEditForm_Load(object sender, EventArgs e)
        {
            string pErrorMessage = System.String.Empty;

            List<BM_Library_ServiceReference.tf_GetBalanceSheetTypes_Result>  BalanceSheetTypes= null;
            List<BM_Employee_ServiceReference.PersonPost> PersonPost = null;
            List<BM_Structure_ServiceReference.Post> Post = null;
            List<BM_Library_ServiceReference.tf_EmployeeTypes_Result> tf_EmployeeTypes = null;
            List<BM_Structure_ServiceReference.Brigade> brigades=null;

            if (this._Discard)
            {
                this.PersonPostBrigadeValueComboBox.Enabled = false;
                this.PersonPostDescriptionValueTextBox.Enabled = false;
                this.PersonPostEmployeeTypeComboBox.Enabled = false;
                this.PersonPostPostValueComboBox.Enabled = false;
                this.PersonPostStartDateValueDateTimePicker.Enabled = false;
            }

            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "თანამდებობა";
                switch (this._dataChangeType)
                {
                    case DataChangeType.Insert:
                        this._formTitle += " [დამატება]";
                        break;
                    case DataChangeType.Update:
                        this._formTitle += (this._dischargeSubMode) ? " [გათავისუფლება]" : " [რედაქტირება]";
                        break;
                    case DataChangeType.Delete:
                        this._formTitle += " [წაშლა]";
                        System.Windows.Forms.DialogResult dlgResult =
                            System.Windows.Forms.MessageBox.Show("გთხოვთ დაადასტუროთ მოთხოვნა ჩანაწერის წაშლის შესახებ",
                                                                 this._formTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        switch (dlgResult)
                        {
                            case System.Windows.Forms.DialogResult.OK:
                                if (OperateToCareers(this._dataChangeType, ref this._personPostData, ref pErrorMessage) != 0)
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

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.EmployeeFullNameValueLabel.Text = (this._employeeFullName != null) ? this._employeeFullName : System.String.Empty;
                this.PersonPostStartDateValueDateTimePicker.Value = ((this._personPostData.PersonPost_StartDate != System.DateTime.MinValue) && (this._personPostData.PersonPost_StartDate != System.DateTime.MaxValue)) ? this._personPostData.PersonPost_StartDate : DateTime.Today;
                this.PersonPostEndDateValueDateTimePicker.Value = ((this._personPostData.PersonPost_EndDate.HasValue) && (this._personPostData.PersonPost_EndDate != System.DateTime.MinValue) && (this._personPostData.PersonPost_EndDate != System.DateTime.MaxValue)) ? this._personPostData.PersonPost_EndDate.Value : DateTime.Today;
                
                this.PersonPostDescriptionValueTextBox.Text = (!System.String.IsNullOrEmpty(this._personPostData.PersonPost_Description)) ? this._personPostData.PersonPost_Description.Trim() : System.String.Empty;
                this.PersonPostDismissalOrderValueTextBox.Text = (!System.String.IsNullOrEmpty(this._personPostData.PersonPost_DismissalOrder)) ? this._personPostData.PersonPost_DismissalOrder.Trim() : System.String.Empty;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._personPostData.PersonPost_EndDate.HasValue) || this._dischargeSubMode;
                this.PersonPostEndDateValueDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

                // თარიღის ქართული ფორმატი
                this.PersonPostStartDateValueDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.PersonPostStartDateValueDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.PersonPostEndDateValueDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.PersonPostEndDateValueDateTimePicker.Format = DateTimePickerFormat.Custom;


                /* კომბოების შევსება
                 * ================= */
                string errorMessage = string.Empty;

                using(BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    BalanceSheetTypes = LibraryService.GetBalanceSheetTypes(null, null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_GetBalanceSheetTypes_Result>();
                    tf_EmployeeTypes = LibraryService.GetEmployeeTypes(null, null, ref errorMessage).ToList();

                }
                using(BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeService = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    PersonPost = EmployeeService.GetPersonPostData(null,null,null,null, ref errorMessage).ToList<BM_Employee_ServiceReference.PersonPost>();
                }

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    Post = StructureService.GetPosts(null, null, ref errorMessage).ToList();
                    brigades = StructureService.GetBrigades(null, null, ref errorMessage).ToList();
                }


               
                /*ბრიგადას კომბო*/
                this.PersonPostBrigadeValueComboBox.DataSource = brigades;
                this.PersonPostBrigadeValueComboBox.DisplayMember = "Brigade_Name";
                this.PersonPostBrigadeValueComboBox.ValueMember = "Brigade_Id";
                this.PersonPostBrigadeValueComboBox.SelectedIndex = -1;
                if ((this.PersonPostBrigadeValueComboBox.Items.Count > 0) && (this._personPostData.PersonPost_Brigade_Id.HasValue))
                    foreach (BM_Structure_ServiceReference.Brigade brigade in this.PersonPostBrigadeValueComboBox.Items)
                        if ((long)brigade.Brigade_Id == this._personPostData.PersonPost_Brigade_Id)
                        {
                            this.PersonPostBrigadeValueComboBox.SelectedIndex = this.PersonPostBrigadeValueComboBox.Items.IndexOf(brigade);
                            break;
                        }

                /*თანამდებობის კომბო*/
                this.PersonPostPostValueComboBox.DataSource = Post;
                this.PersonPostPostValueComboBox.DisplayMember = "Post_Name";
                this.PersonPostPostValueComboBox.ValueMember = "Post_Id";
                this.PersonPostPostValueComboBox.SelectedIndex = -1;
                if ((this.PersonPostPostValueComboBox.Items.Count > 0) && (this._personPostData.PersonPost_Post_Id >0))
                    foreach (BM_Structure_ServiceReference.Post post in this.PersonPostPostValueComboBox.Items)
                        if ((long)post.Post_Id == this._personPostData.PersonPost_Post_Id)
                        {
                            this.PersonPostPostValueComboBox.SelectedIndex = this.PersonPostPostValueComboBox.Items.IndexOf(post);
                            break;
                        }

                /*თანამშრომლის ტიპი კომბო*/
                this.PersonPostEmployeeTypeComboBox.DataSource = tf_EmployeeTypes;
                this.PersonPostEmployeeTypeComboBox.DisplayMember = "EmployeeType_Name";
                this.PersonPostEmployeeTypeComboBox.ValueMember = "EmployeeType_Id";
                this.PersonPostEmployeeTypeComboBox.SelectedIndex = -1;
                if ((this.PersonPostEmployeeTypeComboBox.Items.Count > 0) && (this._personPostData.PersonPost_EmployeeType_Id > 0))
                    foreach (BM_Library_ServiceReference.tf_EmployeeTypes_Result tf_Employee in this.PersonPostEmployeeTypeComboBox.Items)
                        if ((long)tf_Employee.EmployeeType_Id == this._personPostData.PersonPost_EmployeeType_Id)
                        {
                            this.PersonPostEmployeeTypeComboBox.SelectedIndex = this.PersonPostEmployeeTypeComboBox.Items.IndexOf(tf_Employee);
                            break;
                        }

                


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: CareerEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            finally
            {
            }
        }

        private void PersonPostEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.PersonPostEndDateValueDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PersonPostEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

        //
    }
}
