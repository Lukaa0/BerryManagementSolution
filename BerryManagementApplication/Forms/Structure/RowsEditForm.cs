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
    public partial class RowsEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.Row _row;
        private BM_Structure_ServiceReference.RowBreedsModel _rowBreedsModel;
        private BM_Structure_ServiceReference.CompanyRowsModel _companyRowsModel;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private bool? _choose;
        private bool _closeForMessageBox = false;
        public RowsEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._row = new BM_Structure_ServiceReference.Row();
            this._formCloseSwitch = true;

            SectrorNumberTextBox.Maximum = Decimal.MaxValue;
            RowNumberTextBox.Maximum = Decimal.MaxValue;
            PlantYearNumericUpDown.Maximum = Decimal.MaxValue;
            TreeCountNumericUpDown.Maximum = Decimal.MaxValue;

        }

        public RowsEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Row Row,BM_Structure_ServiceReference.CompanyRowsModel companyeRow, BM_Structure_ServiceReference.RowBreedsModel rowBreeds, bool? Choos)
        {
            InitializeComponent();
            this._choose = Choos;
            
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._row = (Row != null) ? Row : new  BM_Structure_ServiceReference.Row();
            this._rowBreedsModel = (rowBreeds != null) ? rowBreeds : new BM_Structure_ServiceReference.RowBreedsModel();
            this._companyRowsModel = (companyeRow != null) ? companyeRow : new BM_Structure_ServiceReference.CompanyRowsModel();
            
            this._formCloseSwitch = true;

            SectrorNumberTextBox.Maximum = 10000;
            RowNumberTextBox.Maximum = 999;
            PlantYearNumericUpDown.Maximum = 3000;
            TreeCountNumericUpDown.Maximum = 3000;
        }
        #region Public properties
        public BM_Structure_ServiceReference.Row RowObject
        {
            get { return this._row; }
        }
        #endregion

        #region Public methods

        public int OperateToRow(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.Row Row, ref BM_Structure_ServiceReference.RowBreed RowBreed,ref BM_Structure_ServiceReference.CompanyRow companyrow ,ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Row != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertRowBreedContainer(RowBreed, companyrow, Row, ref inoutErrorMessage);

                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateRowBreedContainer(RowBreed, companyrow, Row, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.UpdateRowBreedContainer(RowBreed, companyrow, Row, ref inoutErrorMessage);
                                break;
                            default:
                                throw new Exception("არასწორი ოპერაციის კოდი");

                        }
                        if (!string.IsNullOrEmpty(inoutErrorMessage))
                        {
                            MessageBox.Show(inoutErrorMessage + "\n გადაამოწმეთ რიგის მონაცემები");
                            _closeForMessageBox = true; 
                        }
                    }
                }
                else
                    throw new Exception("დოკუმენტის ობიექტი არავალიდურია");
            }
            catch (Exception ex)
            {
                inoutErrorMessage = ex.Message + " Source: OperateToRow()";
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
            BM_Structure_ServiceReference.Row Row = null;
            BM_Structure_ServiceReference.CompanyRow companyRowsModel = null;
            BM_Structure_ServiceReference.RowBreed rowBreed = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                // ფილტრი
                if (this.SectrorNumberTextBox.Text == null)
                    throw new Exception("არ არის მითითებული სექტორის ნომერი!");
                if (this.RowNumberTextBox.Text == null)
                    throw new Exception("არ არის მითითებული რიგის ნომერი ნომერი!");
                if(!string.IsNullOrEmpty(this.SubrowTextBox.Text))
                {
                    if (this.SubrowTextBox.Text.Length != 1)
                        throw new Exception("ქვე რიგის მნიშვნელობა უნდა შეიცავდეს 1 სიმბოლოს");
                }
                else
                {
                    this.SubrowTextBox.Text = " ";
                }
                if (PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (this.StartDateTimePicker.Value >= this.EndDateTimePicker.Value)
                        throw new Exception("არასწორია თარიღი ჯიშებში!");
                }

                if (EndDatecheckBox.Checked)
                {
                    if (this.RowStartdateTimePicker.Value >= this.RowEnddateTimePicker.Value)
                        throw new Exception("არასწორია თარიღი რიგებში!");
                }
                if (this.CompanyComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული კომპანია!");

                if (this.BreedComboBox.SelectedItem == null)
                    throw new Exception("არ არის ჯიში!");

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;




                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                Row = new BM_Structure_ServiceReference.Row()
                {
                    Row_Id = this._row.Row_Id,
                    Row_Number = Int32.Parse(RowNumberTextBox.Text),
                    Row_Subrow_Number = SubrowTextBox.Text,
                    Sector_Number = Int32.Parse(SectrorNumberTextBox.Text)
                };

                companyRowsModel = new BM_Structure_ServiceReference.CompanyRow()
                {
                    CompanyRow_Id = this._companyRowsModel.CompanyRow_Id,
                    CompanyRow_Company_Id = (this.CompanyComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CompanyComboBox.SelectedValue) : 0,
                    CompanyRow_Row_Id = this._row.Row_Id,
                    CompanyRow_StartDate = this.RowStartdateTimePicker.Value,
                    CompanyRow_EndDate = (this.EndDatecheckBox.Checked) ? this.RowEnddateTimePicker.Value : (DateTime?)null,
                };
                rowBreed = new BM_Structure_ServiceReference.RowBreed()
                {
                    RowBreed_Id = this._rowBreedsModel.RowBreed_Id,
                    RowBreed_Breed_Id = (this.BreedComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.BreedComboBox.SelectedValue) : 0,
                    RowBreed_Row_Id = this._row.Row_Id,
                    RowBreed_PlantYear = System.Convert.ToInt32(this.PlantYearNumericUpDown.Value),
                    RowBreed_TreeCount= System.Convert.ToInt32(this.TreeCountNumericUpDown.Value),
                    RowBreed_StartDate = this.StartDateTimePicker.Value,
                    RowBreed_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null
                };


                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToRow(this._dataChangeType, ref Row, ref rowBreed, ref companyRowsModel, ref pErrorMessage);
                        //if (!string.IsNullOrEmpty(pErrorMessage))
                        //{
                        //    MessageBox.Show(pErrorMessage);
                        //}
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._row = Row;
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
                if (_closeForMessageBox)
                {
                    /* ფორმის დახურვის ნებართვა */
                    this._formCloseSwitch = false;
                }
            }
        }

        private void RowEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Structure_ServiceReference.Row> Row = null;
            List<BM_Structure_ServiceReference.CompanyeModel> companyes = null;
            List<BM_Structure_ServiceReference.Row> rows = null;
            List<BM_Library_ServiceReference.Breed> breed = null;
            
            BM_Structure_ServiceReference.RowBreed DeleteRowbreed = null;
            BM_Structure_ServiceReference.CompanyRow Companyrows = null;
            string pErrorMessage = System.String.Empty;

            Companyrows = new BM_Structure_ServiceReference.CompanyRow()
            {
                CompanyRow_Id = this._companyRowsModel.CompanyRow_Id,
                CompanyRow_Company_Id = this._companyRowsModel.CompanyRow_Company_Id,
                CompanyRow_Row_Id = this._companyRowsModel.CompanyRow_Row_Id,
                CompanyRow_StartDate = this._companyRowsModel.CompanyRow_StartDate,
                CompanyRow_EndDate = this._companyRowsModel.CompanyRow_EndDate
            };
            DeleteRowbreed = new BM_Structure_ServiceReference.RowBreed()
            {
                RowBreed_Id = this._rowBreedsModel.RowBreed_Id,
                RowBreed_Breed_Id = this._rowBreedsModel.RowBreed_Breed_Id,
                RowBreed_Row_Id = this._rowBreedsModel.RowBreed_Row_Id,
                RowBreed_PlantYear = this._rowBreedsModel.RowBreed_PlantYear,
                RowBreed_TreeCount = this._rowBreedsModel.RowBreed_TreeCount,
                RowBreed_StartDate = this._rowBreedsModel.RowBreed_StartDate,
                RowBreed_EndDate = this._rowBreedsModel.RowBreed_EndDate
            };


            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "რიგი";
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
                        //System.Windows.Forms.DialogResult dlgResult =
                        //    System.Windows.Forms.MessageBox.Show("გთხოვთ დაადასტუროთ მოთხოვნა ჩანაწერის წაშლის შესახებ",
                        //                                         this._formTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                        //switch (dlgResult)
                        //{
                        //    case System.Windows.Forms.DialogResult.OK:
                        //        if (this.OperateToRow(this._dataChangeType, ref this._row, ref DeleteRowbreed, ref Companyrows, ref pErrorMessage) != 0)
                        //            throw new Exception(pErrorMessage);
                        //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        //        break;
                        //    default:
                        //        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        //        break;
                        //}
                        //this.Close();
                        break;
                        //return;
                    default:
                        break;
                }
                this.Text = this._formTitle;
                /* კომბოების შევსება
                 * ================= */
                string errorMessage = string.Empty;
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient Service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    rows = Service.CheckGetRow(ref errorMessage);
                    
                    companyes = Service.GetCompany(null, null,ref errorMessage);


                }
                using(BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    breed = serviceClient.GetBreeds(null, null, ref errorMessage);
                }


                /*კომპანიის კომბო*/
                this.CompanyComboBox.DataSource = companyes;
                this.CompanyComboBox.DisplayMember = "Company_Name";
                this.CompanyComboBox.ValueMember = "Company_Id";
                this.CompanyComboBox.SelectedIndex = -1;
                if ((this.CompanyComboBox.Items.Count > 0) && (this._companyRowsModel.CompanyRow_Company_Id > 0))
                    foreach (BM_Structure_ServiceReference.CompanyeModel CompanyM in this.CompanyComboBox.Items)
                        if ((long)CompanyM.Company_Id == this._companyRowsModel.CompanyRow_Company_Id)
                        {
                            this.CompanyComboBox.SelectedIndex = this.CompanyComboBox.Items.IndexOf(CompanyM);
                            break;
                        }


                /*ჯიშების კომბო*/
                this.BreedComboBox.DataSource = breed;
                this.BreedComboBox.DisplayMember = "Breed_Name";
                this.BreedComboBox.ValueMember = "Breed_Id";
                this.BreedComboBox.SelectedIndex = -1;
                if ((this.BreedComboBox.Items.Count > 0) && (this._rowBreedsModel.RowBreed_Breed_Id > 0))
                    foreach (BM_Library_ServiceReference.Breed RowBreed in this.BreedComboBox.Items)
                        if ((long)RowBreed.Breed_Id == this._rowBreedsModel.RowBreed_Breed_Id)
                        {
                            this.BreedComboBox.SelectedIndex = this.BreedComboBox.Items.IndexOf(RowBreed);
                            break;
                        }


                this.SectrorNumberTextBox.Text = this._row.Sector_Number.ToString();
                this.RowNumberTextBox.Text = this._row.Row_Number.ToString();

                if (this._row.Row_Subrow_Number != null && this._row.Row_Subrow_Number.Equals(" "))
                {
                    this.SubrowTextBox.Text = string.Empty;
                }
                else
                {
                    this.SubrowTextBox.Text = this._row.Row_Subrow_Number;
                }

                




                this.PlantYearNumericUpDown.Value = this._rowBreedsModel.RowBreed_PlantYear;
                this.TreeCountNumericUpDown.Value = this._rowBreedsModel.RowBreed_TreeCount;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.StartDateTimePicker.Value = ((this._rowBreedsModel.RowBreed_StartDate != System.DateTime.MinValue) && (this._rowBreedsModel.RowBreed_StartDate != System.DateTime.MaxValue)) ? this._rowBreedsModel.RowBreed_StartDate : this.StartDateTimePicker.Value;
                this.EndDateTimePicker.Value = ((this._rowBreedsModel.RowBreed_EndDate.HasValue) && (this._rowBreedsModel.RowBreed_EndDate != System.DateTime.MinValue) && (this._rowBreedsModel.RowBreed_EndDate != System.DateTime.MaxValue)) ? this._rowBreedsModel.RowBreed_EndDate.Value : this.EndDateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._rowBreedsModel.RowBreed_EndDate.HasValue);
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.RowStartdateTimePicker.Value = ((this._companyRowsModel.CompanyRow_StartDate != System.DateTime.MinValue) && (this._companyRowsModel.CompanyRow_StartDate != System.DateTime.MaxValue)) ? this._companyRowsModel.CompanyRow_StartDate : this.RowStartdateTimePicker.Value;
                this.RowEnddateTimePicker.Value = ((this._companyRowsModel.CompanyRow_EndDate.HasValue) && (this._companyRowsModel.CompanyRow_EndDate != System.DateTime.MinValue) && (this._companyRowsModel.CompanyRow_EndDate != System.DateTime.MaxValue)) ? this._companyRowsModel.CompanyRow_EndDate.Value : this.RowEnddateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.EndDatecheckBox.Checked = (this._rowBreedsModel.RowBreed_EndDate.HasValue);
                this.RowEnddateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

                // თარიღის ქართული ფორმატი
                this.StartDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.EndDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EndDateTimePicker.Format = DateTimePickerFormat.Custom;

                this.RowStartdateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.RowStartdateTimePicker.Format = DateTimePickerFormat.Custom;
                this.RowEnddateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.RowEnddateTimePicker.Format = DateTimePickerFormat.Custom;

                if (this._choose == null)
                {
                    this.RowNumberTextBox.Enabled = false;
                    this.SectrorNumberTextBox.Enabled = false;
                    this.CompanyComboBox.Enabled = false;
                    this.SubrowTextBox.Enabled = false;
                    this.BreedComboBox.Enabled = false;

                    this.PlantYearNumericUpDown.Enabled = false;
                    this.TreeCountNumericUpDown.Enabled = false;
                   

                }
                else if ((bool)!this._choose)
                {
                   
                        this.RowNumberTextBox.Enabled = false;
                        this.SectrorNumberTextBox.Enabled = false;
                        this.CompanyComboBox.Enabled = false;
                        this.SubrowTextBox.Enabled = false;

                    
                    
                    this.RowStartdateTimePicker.Enabled = false;
                    this.EndDatecheckBox.Enabled = false;
                    this.RowEnddateTimePicker.Enabled = false;
                }
                

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: RowEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void EndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.RowEnddateTimePicker.Enabled = this.EndDatecheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: EndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RowsEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
