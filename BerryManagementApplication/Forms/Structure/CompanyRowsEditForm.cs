using BerryManagementApplication.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Structure
{
    public partial class CompanyRowsEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.CompanyRow _CompanyRow;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private BM_Structure_ServiceReference.CompanyeModel _CurrentCompanyModel=null;

        public CompanyRowsEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CompanyRow = new BM_Structure_ServiceReference.CompanyRow();
            this._formCloseSwitch = true;

            
            this.CompanyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public CompanyRowsEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.CompanyRow CompanyROw)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CompanyRow = (CompanyROw != null) ? CompanyROw : new  BM_Structure_ServiceReference.CompanyRow();
            this._formCloseSwitch = true;

            
            this.CompanyComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        #region Public properties
        public BM_Structure_ServiceReference.CompanyRow CompanyRowObject
        {
            get { return this._CompanyRow; }
        }
        #endregion

        #region Public methods

        public int OperateToCompanyRow(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.CompanyRow Companyrow, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Companyrow != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertCompanyRow( Companyrow, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateCompanyRow(Companyrow, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteCompanyRows(Companyrow.CompanyRow_Id, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperateToCompanyRow";
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
            BM_Structure_ServiceReference.CompanyRow companyRow = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.CompanyComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული კომპანია!");            
                if (PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (this.StartDateTimePicker.Value >= this.EndDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!");
                }

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;


                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                //companyRow = new BM_Structure_ServiceReference.CompanyRow()
                //{
                //    CompanyRow_Id = this._CompanyRow.CompanyRow_Id,
                //    CompanyRow_Company_Id= (this.CompanyComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CompanyComboBox.SelectedValue) : 0,
                //    CompanyRow_Row_Id= (this.RowComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.RowComboBox.SelectedValue) : 0,
                //    CompanyRow_StartDate = this.StartDateTimePicker.Value,
                //    CompanyRow_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null,

                //};

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCompanyRow(this._dataChangeType, ref companyRow, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._CompanyRow = companyRow;
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

        private void CompanyRowEditForm_Load(object sender, EventArgs e)
        {
           
            List<BM_Structure_ServiceReference.CompanyeModel> companyes = null;
            List<BM_Structure_ServiceReference.Row> rows = null;
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
                                if (this.OperateToCompanyRow(this._dataChangeType, ref this._CompanyRow, ref pErrorMessage) != 0)
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
                    rows = Service.CheckGetRow( ref errorMessage);
                    companyes = Service.GetCompany(null, null,ref errorMessage);


                }


                /*კომპანიის კომბო*/
                this.CompanyComboBox.DataSource = companyes;
                this.CompanyComboBox.DisplayMember = "Company_Name";
                this.CompanyComboBox.ValueMember = "Company_Id";
                this.CompanyComboBox.SelectedIndex = -1;
                if ((this.CompanyComboBox.Items.Count > 0) && (this._CompanyRow.CompanyRow_Company_Id>0))
                    foreach (BM_Structure_ServiceReference.Companye CompanyM in this.CompanyComboBox.Items)
                        if ((long)CompanyM.Company_Id == this._CompanyRow.CompanyRow_Company_Id)
                        {
                            this.CompanyComboBox.SelectedIndex = this.CompanyComboBox.Items.IndexOf(CompanyM);
                            break;
                        }

                /*რიგის გრიდი*/

                this.AllRowsDataGridView.DataSource = rows;

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.StartDateTimePicker.Value = ((this._CompanyRow.CompanyRow_StartDate != System.DateTime.MinValue) && (this._CompanyRow.CompanyRow_StartDate != System.DateTime.MaxValue)) ? this._CompanyRow.CompanyRow_StartDate : this.StartDateTimePicker.Value;
                this.EndDateTimePicker.Value = ((this._CompanyRow.CompanyRow_EndDate.HasValue) && (this._CompanyRow.CompanyRow_EndDate != System.DateTime.MinValue) && (this._CompanyRow.CompanyRow_EndDate != System.DateTime.MaxValue)) ? this._CompanyRow.CompanyRow_EndDate.Value : this.EndDateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._CompanyRow.CompanyRow_EndDate.HasValue);
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
               
                // თარიღის ქართული ფორმატი
                this.StartDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.EndDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EndDateTimePicker.Format = DateTimePickerFormat.Custom;



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: CompanyRowEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void CompanyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void CompanyComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void CompanyComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            try
            {
                string ErrorMessage = null;
                List<BM_Structure_ServiceReference.CompanyRowsModel> companyRowsList = null;

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    this._CurrentCompanyModel = service.GetCompany(System.Convert.ToInt32(this.CompanyComboBox.SelectedValue), null,ref ErrorMessage).FirstOrDefault<BM_Structure_ServiceReference.CompanyeModel>();
                    companyRowsList = service.GetCompanyRow(null, System.Convert.ToInt32(this.CompanyComboBox.SelectedValue),null, ref ErrorMessage);
                }
                this.CompanyRowsDataGridView.DataSource = companyRowsList;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void AddRowsButton_Click(object sender, EventArgs e) 
        { 

            String errorMessage = string.Empty;
            for (int i = this.AllRowsDataGridView.RowCount-1; i >= 0; i--)
            {
                
                DataGridViewRow row = AllRowsDataGridView.Rows[i];
                var be=row.Cells["AddSelected"].Value;

                try
                {
                    if ((string)row.Cells["AddSelected"].Value == "1")
                    {
                        //DataRow rowe = dataTable.NewRow();
                        BM_Structure_ServiceReference.Row rowModel = (BM_Structure_ServiceReference.Row)row.DataBoundItem;
                        BM_Structure_ServiceReference.CompanyRow NewCompanyRowModel = new BM_Structure_ServiceReference.CompanyRow()
                        {

                            CompanyRow_Row_Id = rowModel.Row_Id,
                            CompanyRow_Company_Id = this._CurrentCompanyModel.Company_Id,
                            CompanyRow_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null,
                            CompanyRow_StartDate = this.StartDateTimePicker.Value,
                        };
                       
                        using (BM_Structure_ServiceReference.BM_Structure_ServiceClient Service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                        {
                            Service.InsertCompanyRow(NewCompanyRowModel, ref errorMessage);

                        }
                       
                    
                       

                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            throw new Exception(errorMessage);
                        }
                    }
                }
                catch (Exception eh)
                {
                    System.Windows.Forms.MessageBox.Show(eh.Message);
                }
                
            }
            getData();

            List<BM_Structure_ServiceReference.Row> rows;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient Service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                rows = Service.CheckGetRow(ref errorMessage);
            }
            this.AllRowsDataGridView.DataSource = rows;
        }

        private void RemoveRowsButton_Click(object sender, EventArgs e)
        {
            for (int i = this.AllRowsDataGridView.RowCount - 1; i >= 0; i--)
            {
                DataGridViewRow row = CompanyRowsDataGridView.Rows[i];
                if (Convert.ToBoolean(row.Cells["RemoveSelected"].Value))
                {
                    BM_Structure_ServiceReference.CompanyRowsModel CompanyrowModel = (BM_Structure_ServiceReference.CompanyRowsModel)row.DataBoundItem;
                    BM_Structure_ServiceReference.Row RowModel = new BM_Structure_ServiceReference.Row()
                    {
                        Row_Id=CompanyrowModel.CompanyRow_Row_Id,
                        Row_Barkode= CompanyrowModel.CompanyRow_Row_Barkode,
                        Row_Number= CompanyrowModel.CompanyRow_Row_Number,
                        Row_Subrow_Number= CompanyrowModel.CompanyRow_Row_Subrow_Number,
                        Sector_Number= CompanyrowModel.CompanyRow_Sector_Number
                        
                    };
                    AllRowsDataGridView.Rows.Add(RowModel);
                    this.CompanyRowsDataGridView.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void CompanyRowsEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
