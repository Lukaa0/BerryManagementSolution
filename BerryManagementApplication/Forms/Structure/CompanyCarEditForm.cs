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
    public partial class CompanyCarEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.CompanyCar _CompanyCar;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public CompanyCarEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CompanyCar = new BM_Structure_ServiceReference.CompanyCar();
            this._formCloseSwitch = true;

            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CompanyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public CompanyCarEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.CompanyCar CompanyCar)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CompanyCar = (CompanyCar != null) ? CompanyCar : new  BM_Structure_ServiceReference.CompanyCar();
            this._formCloseSwitch = true;

            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.CompanyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #region Public properties
        public BM_Structure_ServiceReference.CompanyCar CompanyCarObject
        {
            get { return this._CompanyCar; }
        }
        #endregion

        #region Public methods

        public int OperateToCompanyCar(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.CompanyCar Companycar, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Companycar != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertCompanyCar( Companycar, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateCompanyCar(Companycar, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteCompanyCar(Companycar.CompanyCar_Id, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperateToCompanyCar";
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
            BM_Structure_ServiceReference.CompanyCar companyCar = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                
                
                if (this.CompanyComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული კომპანია!");
                if (this.CarComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული მანქანა!");
                if (PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (this.StartDateTimePicker.Value >= this.EndDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!");
                }


                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                companyCar = new BM_Structure_ServiceReference.CompanyCar()
                {
                    CompanyCar_Id = this._CompanyCar.CompanyCar_Id,
                    CompanyCar_Company_Id= (this.CompanyComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CompanyComboBox.SelectedValue) : 0,
                    CompanyCar_Car_Id= (this.CarComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CarComboBox.SelectedValue) : 0,
                    CompanyCar_StartDate = this.StartDateTimePicker.Value,
                    CompanyCar_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null,

                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCompanyCar(this._dataChangeType, ref companyCar, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._CompanyCar = companyCar;
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

        private void CompanyCarEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Structure_ServiceReference.CompanyeModel> CompanyData = null;
            List<BM_Structure_ServiceReference.CarModel> CarData = null;
            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "ბრიგადა";
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
                                if (this.OperateToCompanyCar(this._dataChangeType, ref this._CompanyCar, ref pErrorMessage) != 0)
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

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient Service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    CompanyData = Service.GetCompany(null, null,ref errorMessage);
                    CarData = Service.GetCar(null, ref errorMessage).ToList<BM_Structure_ServiceReference.CarModel>();

                }


                /*კომპანიის კომბო*/
                this.CompanyComboBox.DataSource = CompanyData;
                this.CompanyComboBox.DisplayMember = "Company_Name";
                this.CompanyComboBox.ValueMember = "Company_Id";
                this.CompanyComboBox.SelectedIndex = -1;
                if ((this.CompanyComboBox.Items.Count > 0) && (this._CompanyCar.CompanyCar_Company_Id>0))
                    foreach (BM_Structure_ServiceReference.CompanyeModel CompanyM in this.CompanyComboBox.Items)
                        if ((long)CompanyM.Company_Id == this._CompanyCar.CompanyCar_Company_Id)
                        {
                            this.CompanyComboBox.SelectedIndex = this.CompanyComboBox.Items.IndexOf(CompanyM);
                            break;
                        }

                /*მანქანის კომბო*/
                this.CarComboBox.DataSource = CarData;
                this.CarComboBox.DisplayMember = "Car_Model";
                this.CarComboBox.ValueMember = "Car_Id";
                this.CarComboBox.SelectedIndex = -1;
                if ((this.CarComboBox.Items.Count > 0) && (this._CompanyCar.CompanyCar_Car_Id > 0))
                    foreach (BM_Structure_ServiceReference.CarModel CarM in this.CarComboBox.Items)
                        if ((long)CarM.Car_Id == this._CompanyCar.CompanyCar_Car_Id)
                        {
                            this.CarComboBox.SelectedIndex = this.CarComboBox.Items.IndexOf(CarM);
                            break;
                        }


                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.StartDateTimePicker.Value = ((this._CompanyCar.CompanyCar_StartDate != System.DateTime.MinValue) && (this._CompanyCar.CompanyCar_StartDate != System.DateTime.MaxValue)) ? this._CompanyCar.CompanyCar_StartDate : this.StartDateTimePicker.Value;
                this.EndDateTimePicker.Value = ((this._CompanyCar.CompanyCar_EndDate.HasValue) && (this._CompanyCar.CompanyCar_EndDate != System.DateTime.MinValue) && (this._CompanyCar.CompanyCar_EndDate != System.DateTime.MaxValue)) ? this._CompanyCar.CompanyCar_EndDate.Value : this.EndDateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._CompanyCar.CompanyCar_EndDate.HasValue);
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
               
                // თარიღის ქართული ფორმატი
                this.StartDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.EndDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EndDateTimePicker.Format = DateTimePickerFormat.Custom;



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

        private void PersonPostEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyCarEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
