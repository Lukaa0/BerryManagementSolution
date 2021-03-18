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
    public partial class RowBreedEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.RowBreed _rowBreed;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public RowBreedEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._rowBreed = new BM_Structure_ServiceReference.RowBreed();
            this._formCloseSwitch = true;

            this.RowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BreedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public RowBreedEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.RowBreed RowBreed)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._rowBreed = (RowBreed != null) ? RowBreed : new  BM_Structure_ServiceReference.RowBreed();
            this._formCloseSwitch = true;

            this.RowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.BreedComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        #region Public properties
        public BM_Structure_ServiceReference.RowBreed RowBreedObject
        {
            get { return this._rowBreed; }
        }
        #endregion

        #region Public methods

        public int OperateToRowBreed(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.RowBreed Rowbreed, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Rowbreed != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertRowBreed(Rowbreed, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateRowBreed(Rowbreed, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteRowBreeds(Rowbreed.RowBreed_Id, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperateToRowBreed";
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
            BM_Structure_ServiceReference.RowBreed rowBreed = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.BreedComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული ჯიში!");
                if (this.RowComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული რიგი!");
                if (PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (this.StartDateTimePicker.Value <= this.EndDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!");
                }


                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                rowBreed = new BM_Structure_ServiceReference.RowBreed()
                {
                    RowBreed_Id = this._rowBreed.RowBreed_Id,
                    RowBreed_Breed_Id = (this.BreedComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.BreedComboBox.SelectedValue) : 0,
                    RowBreed_Row_Id = (this.RowComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.RowComboBox.SelectedValue) : 0,
                    RowBreed_StartDate = this.StartDateTimePicker.Value,
                    RowBreed_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToRowBreed(this._dataChangeType, ref rowBreed, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._rowBreed = rowBreed;
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

        private void RowBreedEditForm_Load(object sender, EventArgs e)
        {

            List<BM_Structure_ServiceReference.Row> RowData = null;
            List<BM_Library_ServiceReference.Breed> BreedData = null;


            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "რიგების სახეობა";
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
                                if (this.OperateToRowBreed(this._dataChangeType, ref this._rowBreed, ref pErrorMessage) != 0)
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
                    RowData = Service.GetRows(null,null, ref errorMessage).ToList<BM_Structure_ServiceReference.Row>();
                   
                }
                using (BM_Library_ServiceReference.BM_Library_ServiceClient ServiceL = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    BreedData = ServiceL.GetBreeds(null,null, ref errorMessage).ToList<BM_Library_ServiceReference.Breed>();
                }


                /*breed კომბო*/
                this.BreedComboBox.DataSource = BreedData;
                this.BreedComboBox.DisplayMember = "Breed_Name";
                this.BreedComboBox.ValueMember = "Breed_Id";
                this.BreedComboBox.SelectedIndex = -1;
                if ((this.BreedComboBox.Items.Count > 0) && (this._rowBreed.RowBreed_Breed_Id > 0))
                    foreach (BM_Library_ServiceReference.Breed CompanyM in this.BreedComboBox.Items)
                        if ((long)CompanyM.Breed_Id == this._rowBreed.RowBreed_Breed_Id)
                        {
                            this.BreedComboBox.SelectedIndex = this.BreedComboBox.Items.IndexOf(CompanyM);
                            break;
                        }


                /*rows კომბო*/
                this.RowComboBox.DataSource = RowData;
                this.RowComboBox.DisplayMember = "Row_Barkode";
                this.RowComboBox.ValueMember = "Row_Id";
                this.RowComboBox.SelectedIndex = -1;
                if ((this.RowComboBox.Items.Count > 0) && (this._rowBreed.RowBreed_Row_Id > 0))
                    foreach (BM_Structure_ServiceReference.Row CarM in this.RowComboBox.Items)
                        if ((long)CarM.Row_Id== this._rowBreed.RowBreed_Row_Id)
                        {
                            this.RowComboBox.SelectedIndex = this.RowComboBox.Items.IndexOf(CarM);
                            break;
                        }


                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.StartDateTimePicker.Value = ((this._rowBreed.RowBreed_StartDate != System.DateTime.MinValue) && (this._rowBreed.RowBreed_StartDate != System.DateTime.MaxValue)) ? this._rowBreed.RowBreed_StartDate : this.StartDateTimePicker.Value;
                this.EndDateTimePicker.Value = ((this._rowBreed.RowBreed_EndDate.HasValue) && (this._rowBreed.RowBreed_EndDate != System.DateTime.MinValue) && (this._rowBreed.RowBreed_EndDate != System.DateTime.MaxValue)) ? this._rowBreed.RowBreed_EndDate.Value : this.EndDateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._rowBreed.RowBreed_EndDate.HasValue);
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
               
                // თარიღის ქართული ფორმატი
                this.StartDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.EndDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EndDateTimePicker.Format = DateTimePickerFormat.Custom;



            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: RowBreedEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void RowBreedEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
