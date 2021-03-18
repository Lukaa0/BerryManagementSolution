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

namespace BerryManagementApplication.Forms.Structure
{
    public partial class CompanyEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.Companye _Company;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;

        private long _SideTypeID;
        public CompanyEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._Company = new BM_Structure_ServiceReference.Companye();
            this._formCloseSwitch = true;

            this.CitizenshipComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SideTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public CompanyEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Companye Company, long SideTypeID)
        {
            InitializeComponent();

            this.SideTypeComboBox.Enabled = false;
            this._SideTypeID = SideTypeID;
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._Company = (Company != null) ? Company : new  BM_Structure_ServiceReference.Companye();
            this._formCloseSwitch = true;

            this.CitizenshipComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.SideTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #region Public properties
        public BM_Structure_ServiceReference.Companye CompanyCObject
        {
            get { return this._Company; }
        }
        #endregion

        #region Public methods

        public int OperateToCompany(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.Companye Company, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Company != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertCompany( Company, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateCompany(Company, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteCompany(Company.Company_Id, ref inoutErrorMessage);
                                break;
                            default:
                                throw new Exception("არასწორი ოპერაციის კოდი");
                        }
                    }
                    if (!string.IsNullOrEmpty(inoutErrorMessage))
                    {
                        MessageBox.Show(inoutErrorMessage);
                    }
                }
                else
                    throw new Exception("დოკუმენტის ობიექტი არავალიდურია");
            }
            catch (Exception ex)
            {
                inoutErrorMessage = ex.Message + " Source: OperateToCompany";
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
            BM_Structure_ServiceReference.Companye company = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი

           
                if (this.SideTypeComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული SideType!");
                if (this.CitizenshipComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული მოქალაქეობა!");
                if(this.CompanyNameTextBox.Text.Trim() == string.Empty)
                    throw new Exception("არ არის მითითებული სახელი!");
                if (this.CompanyIdentityTextBox.Text.Trim() == string.Empty)
                    throw new Exception("არ არის მითითებული იდენტიფიკატორი!");
                if (this.Adress1TextBox.Text.Trim() == string.Empty)
                    throw new Exception("არ არის მითითებული მისამართი 1!");
                if (this.CompanyIdentityTextBox.Text.Trim() != string.Empty && this.BanktextBox1.Text.Length != 22)
                    throw new Exception("ბანკის კოდი უნდა შეიცავდეს 22 სიმბოლოს");


                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                company = new BM_Structure_ServiceReference.Companye()
                {
                    Company_Id = this._Company.Company_Id,
                    Company_Identity = this.CompanyIdentityTextBox.Text.Trim(),
                    Company_Name = this.CompanyNameTextBox.Text.Trim(),
                    Company_CitizenshipId = (this.CitizenshipComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CitizenshipComboBox.SelectedValue) : 0,
                    Company_SideType_Id = (this.SideTypeComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.SideTypeComboBox.SelectedValue) : 0,
                    Company_Address1 = this.Adress1TextBox.Text.Trim(),
                    Company_Address2 = this.Adress2TextBox.Text.Trim(),
                    Company_Phone1 = this.Number1TextBox.Text.Trim(),
                    Company_Phone2 = this.Number2TextBox.Text.Trim(),
                    Company_IBAN = this.BanktextBox1.Text.Trim(),
                    Company_RS_Password = this.PasswordtextBox2.Text.Trim(),
                    Company_RS_UserId = this.UserIdtextBox1.Text.Trim(),
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCompany(this._dataChangeType, ref company, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._Company = company;
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

        private void CompanyEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.Citizenship> Citizenship = null;
            List<BM_Library_ServiceReference.tf_SideTypes_Result> SideType = null;
            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "კომპანია";
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
                                if (this.OperateToCompany(this._dataChangeType, ref this._Company, ref pErrorMessage) != 0)
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
                string errorMessage = string.Empty;

                using (BM_Library_ServiceReference.BM_Library_ServiceClient Service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    Citizenship = Service.GetCitizenships(null,null,null, ref errorMessage).ToList<BM_Library_ServiceReference.Citizenship>();
                    SideType = Service.GetSideTypes(null,null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_SideTypes_Result>();

                }


                /*მოქალაქეობის კომბო*/
                this.CitizenshipComboBox.DataSource = Citizenship;
                this.CitizenshipComboBox.DisplayMember = "Citizenship_Name";
                this.CitizenshipComboBox.ValueMember = "Citizenship_Id";
                this.CitizenshipComboBox.SelectedIndex = -1;
                if ((this.CitizenshipComboBox.Items.Count > 0) && (this._Company.Company_CitizenshipId>0))
                    foreach (BM_Library_ServiceReference.Citizenship citizenship in this.CitizenshipComboBox.Items)
                        if ((long)citizenship.Citizenship_Id == this._Company.Company_CitizenshipId)
                        {
                            this.CitizenshipComboBox.SelectedIndex = this.CitizenshipComboBox.Items.IndexOf(citizenship);
                            break;
                        }

                /*sideType კომბო*/
                this.SideTypeComboBox.DataSource = SideType;
                this.SideTypeComboBox.DisplayMember = "SideType_Name";
                this.SideTypeComboBox.ValueMember = "SideType_Id";
                this.SideTypeComboBox.SelectedIndex = -1;
                if ((this.SideTypeComboBox.Items.Count > 0) && (this._Company.Company_SideType_Id > -2))
                {
                    foreach (BM_Library_ServiceReference.tf_SideTypes_Result SideTyp in this.SideTypeComboBox.Items)
                        if ((long)SideTyp.SideType_Id == this._SideTypeID)
                        {
                            this.SideTypeComboBox.SelectedIndex = this.SideTypeComboBox.Items.IndexOf(SideTyp);
                            break;
                        }
                }

                if (this._SideTypeID == -1)
                {
                    this.UserIdtextBox1.Enabled = false;
                    this.PasswordtextBox2.Enabled = false;
                }
                else
                {
                    this.UserIdtextBox1.Text = this._Company.Company_RS_UserId;
                    this.PasswordtextBox2.Text = this._Company.Company_RS_Password;
                }
                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */

                this.Adress1TextBox.Text = this._Company.Company_Address1;
                this.Adress2TextBox.Text = this._Company.Company_Address2;
                this.CompanyIdentityTextBox.Text = this._Company.Company_Identity;
                this.CompanyNameTextBox.Text = this._Company.Company_Name;
                this.Number1TextBox.Text = this._Company.Company_Phone1;
                this.Number2TextBox.Text = this._Company.Company_Phone2;
                this.BanktextBox1.Text = this._Company.Company_IBAN;




            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: CompanyCarEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
            finally
            {
            }
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {
            this._formCloseSwitch = true;
            this.Close();
        }

        private void CompanyEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}
