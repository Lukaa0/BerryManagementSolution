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

namespace BerryManagementApplication.Forms.Operations
{
    public partial class BerryProduceEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
                                                //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით


        private BM_Produce_ServiceReference.BreedProperty _breedProduce;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private bool? _choose;
        private bool _closeForMessageBox = false;

        public BerryProduceEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._breedProduce = new BM_Produce_ServiceReference.BreedProperty();
            this._formCloseSwitch = true;


        }

        public BerryProduceEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Produce_ServiceReference.BreedProperty breedProperty)
        {
            InitializeComponent();

            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._breedProduce = (breedProperty != null) ? breedProperty : new  BM_Produce_ServiceReference.BreedProperty();
            
            this._formCloseSwitch = true;

            

        }
        #region Public properties
        public BM_Produce_ServiceReference.BreedProperty BreedPropertyObject
        {
            get { return this._breedProduce; }
        }
        #endregion

        #region Public methods

        public int OperateToBreedProduce(DataChangeType inDataChangeType, ref BM_Produce_ServiceReference.BreedProperty BreedProperty, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (BreedProperty != null)
                {
                    using (BM_Produce_ServiceReference.BM_Produce_ServiceClient ServiceClient = new BM_Produce_ServiceReference.BM_Produce_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertBreedProperties(BreedProperty, ref inoutErrorMessage);
                                break;
                            //case DataChangeType.Update:
                            //    ServiceClient.UpdateRowBreedContainer(BreedProperty, ref inoutErrorMessage);
                            //    break;
                            //case DataChangeType.Delete:
                            //    ServiceClient.UpdateRowBreedContainer(BreedProperty, ref inoutErrorMessage);
                            //    break;
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
            BM_Produce_ServiceReference.BreedProperty BreedProperty = null;

            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;


                // ფილტრი


                if (string.IsNullOrEmpty(this.SugarTextBox.Text))
                    throw new Exception("არ არის მითითებული შაქრის პროცენტულობა!");
                if (string.IsNullOrEmpty(this.DensityTextBox.Text))
                    throw new Exception("არ არის მითითებული სიმკვრივე!");
                if (this.BreedComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული ჯიში!");

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;




                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */


                BreedProperty = new BM_Produce_ServiceReference.BreedProperty()
                {
                    //Row_Id = this._row.Row_Id,
                    //Row_Number = Int32.Parse(RowNumberTextBox.Text),
                    //Row_Subrow_Number = SubrowTextBox.Text,
                    //Sector_Number = Int32.Parse(SectrorNumberTextBox.Text)

                    BreedProperty_Id = this._breedProduce.BreedProperty_Id,
                    BreedProperty_Breed_Id = (this.BreedComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.BreedComboBox.SelectedValue) : 0,
                    BreedProperty_Breed_Name = this._breedProduce.BreedProperty_Breed_Name,
                    BreedProperty_DateTime = DateTime.Today,
                    BreedProperty_Density = System.Convert.ToDecimal(DensityTextBox.Text),
                    BreedProperty_Sugar = System.Convert.ToDecimal(SugarTextBox.Text)

                };

                //companyRowsModel = new BM_Structure_ServiceReference.CompanyRow()
                //{
                //    CompanyRow_Id = this._companyRowsModel.CompanyRow_Id,
                //    CompanyRow_Company_Id = (this.CompanyComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CompanyComboBox.SelectedValue) : 0,
                //    CompanyRow_Row_Id = this._row.Row_Id,
                //    CompanyRow_StartDate = this.RowStartdateTimePicker.Value,
                //    CompanyRow_EndDate = (this.EndDatecheckBox.Checked) ? this.RowEnddateTimePicker.Value : (DateTime?)null,
                //};
                //rowBreed = new BM_Structure_ServiceReference.RowBreed()
                //{
                //    RowBreed_Id = this._rowBreedsModel.RowBreed_Id,
                //    RowBreed_Breed_Id = (this.BreedComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.BreedComboBox.SelectedValue) : 0,
                //    RowBreed_Row_Id = this._row.Row_Id,
                //    RowBreed_PlantYear = System.Convert.ToInt32(this.PlantYearNumericUpDown.Value),
                //    RowBreed_TreeCount= System.Convert.ToInt32(this.TreeCountNumericUpDown.Value),
                //    RowBreed_StartDate = this.StartDateTimePicker.Value,
                //    RowBreed_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null
                //};


                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToBreedProduce(this._dataChangeType,ref BreedProperty, ref pErrorMessage);
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
                    this._breedProduce = BreedProperty; 
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

            //Companyrows = new BM_Structure_ServiceReference.CompanyRow()
            //{
            //    CompanyRow_Id = this._companyRowsModel.CompanyRow_Id,
            //    CompanyRow_Company_Id = this._companyRowsModel.CompanyRow_Company_Id,
            //    CompanyRow_Row_Id = this._companyRowsModel.CompanyRow_Row_Id,
            //    CompanyRow_StartDate = this._companyRowsModel.CompanyRow_StartDate,
            //    CompanyRow_EndDate = this._companyRowsModel.CompanyRow_EndDate
            //};



            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "რიგის მონაცემების";
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




                /*ჯიშების კომბო*/
                this.BreedComboBox.DataSource = breed;
                this.BreedComboBox.DisplayMember = "Breed_Name";
                this.BreedComboBox.ValueMember = "Breed_Id";
                this.BreedComboBox.SelectedIndex = -1;
                //if ((this.BreedComboBox.Items.Count > 0) && (this._rowBreedsModel.RowBreed_Breed_Id > 0))
                //    foreach (BM_Library_ServiceReference.Breed RowBreed in this.BreedComboBox.Items)
                //        if ((long)RowBreed.Breed_Id == this._rowBreedsModel.RowBreed_Breed_Id)
                //        {
                //            this.BreedComboBox.SelectedIndex = this.BreedComboBox.Items.IndexOf(RowBreed);
                //            break;
                //        }


                //this.SectrorNumberTextBox.Text = this._row.Sector_Number.ToString();
                //this.RowNumberTextBox.Text = this._row.Row_Number.ToString();

                //if (this._row.Row_Subrow_Number != null && this._row.Row_Subrow_Number.Equals(" "))
                //{
                //    this.SubrowTextBox.Text = string.Empty;
                //}
                //else
                //{
                //    this.SubrowTextBox.Text = this._row.Row_Subrow_Number;
                //}

             

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

        private void BreedComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
