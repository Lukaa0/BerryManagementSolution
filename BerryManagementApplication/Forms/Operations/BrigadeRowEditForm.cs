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

namespace BerryManagementApplication.Forms.Operation
{
    public partial class BrigadeRowEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Operation_ServiceReference.TakeRow _takeRow;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private bool _activeCombo = false;

        private List<BM_Operation_ServiceReference.TakeRowModel> _choosedBrigade = new List<BM_Operation_ServiceReference.TakeRowModel>();
        private List<BM_Operation_ServiceReference.TakeRowModel> _choosedBrigade2 = new List<BM_Operation_ServiceReference.TakeRowModel>();
        private List<BM_Operation_ServiceReference.TakeRowModel> _AllRowsBrigade = new List<BM_Operation_ServiceReference.TakeRowModel>();
        private List<BM_Operation_ServiceReference.TakeRowModel> _newall = new List<BM_Operation_ServiceReference.TakeRowModel>();


        public BrigadeRowEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._takeRow = new BM_Operation_ServiceReference.TakeRow();
            this._formCloseSwitch = true;

            AllRowDataGridView.AutoGenerateColumns = false;
            BrigadeRowDataGridView.AutoGenerateColumns = false;


        }

        public BrigadeRowEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Operation_ServiceReference.TakeRow TakeRow)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._takeRow = (TakeRow != null) ? TakeRow : new BM_Operation_ServiceReference.TakeRow();
            this._formCloseSwitch = true;

            AllRowDataGridView.AutoGenerateColumns = false;
            BrigadeRowDataGridView.AutoGenerateColumns = false;
        }

        #region Public methods

        public int OperateToCompanyCar(DataChangeType inDataChangeType, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                //this._CompanyCar.TakeRow_Brigade_Id = (this.ComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.ComboBox.SelectedValue) : 0;
                if (this._takeRow != null)
                {
                    using (BM_Operation_ServiceReference.BM_Operation_ServiceClient ServiceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.UpdateTakeRowWith( this._takeRow, ref inoutErrorMessage);
                                break;
                            //case DataChangeType.Update:
                            //    ServiceClient.UpdateCompanyCar(Companycar, ref inoutErrorMessage);
                            //    break;
                            //case DataChangeType.Delete:
                            //    ServiceClient.DeleteCompanyCar(Companycar.CompanyCar_Id, ref inoutErrorMessage);
                            //    break;
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


        private void BrigadeRowEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Structure_ServiceReference.Brigade> Brigade = null;
            List<BM_Structure_ServiceReference.Row> Row = null;
            List<BM_Operation_ServiceReference.TakeRow> EmptyRows = null;
            List<BM_Operation_ServiceReference.TakeRow> FilledRows = null;
            string pErrorMessage = System.String.Empty;

            AllRowDataGridView.DataSource = null;
            BrigadeRowDataGridView.DataSource = null;

            try
            {


                /* კომბოების შევსება
                 * ================= */
                string errorMessage = string.Empty;

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient Service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    Brigade = Service.GetBrigades(null, null,ref errorMessage);
                    Row = Service.GetBrigadeRowDistribution(null, ref errorMessage);
                }


                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    var EmptyRow = serviceClient.GetTakeRowsModelByBrigadeId(ref errorMessage);
                    AllRowDataGridView.DataSource = EmptyRow;
                    var FilledRow = serviceClient.GetTakeRowsModel(_takeRow.TakeRow_Brigade_Id,null,true,ref errorMessage);
                    BrigadeRowDataGridView.DataSource = FilledRow;
                }
                if (!String.IsNullOrEmpty(errorMessage))
                {
                    _formCloseSwitch = false;
                    throw new Exception(errorMessage);
                }
                _formCloseSwitch = true;

                /*კომპანიის კომბო*/
                this.BrigadeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                this.BrigadeComboBox.DataSource = Brigade;
                this.BrigadeComboBox.DisplayMember = "Brigade_Name";
                this.BrigadeComboBox.ValueMember = "Brigade_Id";
                this.BrigadeComboBox.SelectedIndex = -1;
                if ((this.BrigadeComboBox.Items.Count > 0) && (this._takeRow.TakeRow_Brigade_Id > 0))
                    foreach (BM_Structure_ServiceReference.Brigade BrigadeM in this.BrigadeComboBox.Items)
                        if ((long)BrigadeM.Brigade_Id == this._takeRow.TakeRow_Brigade_Id)
                        {
                            this.BrigadeComboBox.SelectedIndex = this.BrigadeComboBox.Items.IndexOf(BrigadeM);
                            break;
                        }

                _activeCombo = true;
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

        private void BrigadeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_activeCombo)
                {

                    string errorMessage = string.Empty;
                    using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                    {
                        var EmptyRow = serviceClient.GetTakeRowsModelByBrigadeId(ref errorMessage);
                        AllRowDataGridView.DataSource = EmptyRow;
                        var FilledRow = serviceClient.GetTakeRowsModel(System.Convert.ToInt32(this.BrigadeComboBox.SelectedValue), null, true, ref errorMessage);
                        BrigadeRowDataGridView.DataSource = FilledRow;
                    }
                    if (!String.IsNullOrEmpty(errorMessage))
                    {
                        _formCloseSwitch = false;
                        throw new Exception(errorMessage);
                    }
                    _formCloseSwitch = true;
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: BrigadeComboBox_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void RollbackButton_Click(object sender, EventArgs e)
        {

        }

        private void PersonPostEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void BrigadeRowEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AddRowButton_Click(object sender, EventArgs e)
        {
            try
            {
                String errorMessage = string.Empty;
                _newall = new List<BM_Operation_ServiceReference.TakeRowModel>();


                BM_Operation_ServiceReference.TakeRowModel personPost = null;
                string rowBarkode;
                int countRow;
                countRow = this.AllRowDataGridView.Rows.Count;
                if (countRow > 0)
                {
                    for (int i = 0; i < countRow; i++)
                    {
                        //ცხრიში ასებული მონაცემების სიაში დამატება
                        _newall.Add((BM_Operation_ServiceReference.TakeRowModel)this.AllRowDataGridView.Rows[i].DataBoundItem);
                    }
                }

                //მონიშნული personpost ის წამოღება AllHarvesterDataGridView (ყველა მკრეფავის ჩამონათვალი) -დან
                foreach (DataGridViewRow gridrow in this.AllRowDataGridView.Rows)
                {
                    if (gridrow.Selected)
                    {
                        personPost = (BM_Operation_ServiceReference.TakeRowModel)gridrow.DataBoundItem;
                        var dt = AllRowDataGridView.DataSource;
                        //using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                        //{


                        //შემოწმება უკვე დაკავებული ხომ არ არის მკრეფავი
                        //if (serviceClient.CheckTakeRows((long)personPost.TakeRow_Brigade_Id, ref errorMessage))
                        //{
                        //არჩეული მკრეფავის ლისტში დამატება
                        _choosedBrigade.Add((BM_Operation_ServiceReference.TakeRowModel)gridrow.DataBoundItem);

                        personPost = (BM_Operation_ServiceReference.TakeRowModel)gridrow.DataBoundItem;

                        _newall.Remove(personPost);
                    }

                }
                AllRowDataGridView.DataSource = _newall;


                _newall = new List<BM_Operation_ServiceReference.TakeRowModel>();
                countRow = this.AllRowDataGridView.Rows.Count;
                if (countRow > 0)
                {
                    for (int i = 0; i < countRow; i++)
                    {
                        //ცხრიში ასებული მონაცემების სიაში დამატება
                        _newall.Add((BM_Operation_ServiceReference.TakeRowModel)this.AllRowDataGridView.Rows[i].DataBoundItem);
                    }
                }

                //შემოწმება არსებობს თუ არა HarvesterRowDataGridView (უკვე დაკავებული მკრეფავები) ცხრილში
                countRow = this.BrigadeRowDataGridView.Rows.Count;
                List<BM_Operation_ServiceReference.TakeRowModel> harvesterInPersonPost = new List<BM_Operation_ServiceReference.TakeRowModel>();

                if (countRow > 0)
                {
                    for (int i = 0; i < countRow; i++)
                    {
                        //ცხრიში ასებული მონაცემების სიაში დამატება
                        harvesterInPersonPost.Add((BM_Operation_ServiceReference.TakeRowModel)this.BrigadeRowDataGridView.Rows[i].DataBoundItem);
                    }
                }
                //სიების გაერთიანება
                harvesterInPersonPost.AddRange(_choosedBrigade);
                //ცხრილში სრული ახალი არჩეული და იქამდე არსებული მონაცემების გამოტანა
                this.BrigadeRowDataGridView.DataSource = harvesterInPersonPost;

                _choosedBrigade2 = _choosedBrigade;
                _choosedBrigade = new List<BM_Operation_ServiceReference.TakeRowModel>();

                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: AddRowButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }

        }

        private void RemoveRowButton_Click(object sender, EventArgs e)
        {
            //AllRowDataGridView.DataSource = null;

            //BM_Operation_ServiceReference.TakeRow personPost = null;

            //int countRow = this.BrigadeRowDataGridView.Rows.Count;
            //List<BM_Operation_ServiceReference.TakeRow> harvesterInPersonPost = new List<BM_Operation_ServiceReference.TakeRow>();
            //if (countRow > 0)
            //{
            //    for (int i = 0; i < countRow; i++)
            //    {
            //        //ცხრიში ასებული მონაცემების სიაში დამატება
            //        harvesterInPersonPost.Add((BM_Operation_ServiceReference.TakeRow)this.BrigadeRowDataGridView.Rows[i].DataBoundItem);
            //    }
            //}

            //_newall = new List<BM_Operation_ServiceReference.TakeRow>();
            //foreach (DataGridViewRow gridrow in this.BrigadeRowDataGridView.Rows)
            //{

            //    if (gridrow.Selected)
            //    {
            //        personPost = (BM_Operation_ServiceReference.TakeRow)gridrow.DataBoundItem;
            //        if (_choosedBrigade2.Contains(personPost))
            //        {
            //            _choosedBrigade2.Remove(personPost);
            //            harvesterInPersonPost.Remove(personPost);
            //        }
            //        else
            //        {
            //            harvesterInPersonPost.Remove(personPost);
            //            _choosedBrigade2.Add(personPost);
            //        }

            //        AllRowDataGridView.DataSource = _newall;
            //        this.BrigadeRowDataGridView.DataSource = harvesterInPersonPost;
            //    }
            //}

            try
            {
                String errorMessage = string.Empty;

                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    var EmptyRow = serviceClient.GetTakeRowsModelByBrigadeId(ref errorMessage);
                    AllRowDataGridView.DataSource = EmptyRow;
                    var FilledRow = serviceClient.GetTakeRowsModel(System.Convert.ToInt32(this.BrigadeComboBox.SelectedValue), null, true, ref errorMessage);
                    BrigadeRowDataGridView.DataSource = FilledRow;
                }

                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                _newall = new List<BM_Operation_ServiceReference.TakeRowModel>();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: RemoveRowButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close(); 
            }
           
        }

        private void CommitButton_Click(object sender, EventArgs e)
        {
            //BM_Structure_ServiceReference.CompanyCar companyCar = null;
            //string pErrorMessage = System.String.Empty;
            //int iResult = 0;

            //try
            //{

            //    /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
            //    //companyCar = new BM_Operation_ServiceReference.TakeRow()
            //    //{
            //    //    TakeRow_Row_Id = (this.CarComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CarComboBox.SelectedValue) : 0,
            //    //    TakeRow_In_TUser_PersonPost_Id = 14,
            //    //    TakeRow_In_DateTime = da


            //    //    TakeRow_Brigade_Id = (this.ComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.ComboBox.SelectedValue) : 0,
            //    //    CompanyCar_Car_Id = (this.CarComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CarComboBox.SelectedValue) : 0,
            //    //    CompanyCar_StartDate = this.StartDateTimePicker.Value,
            //    //    CompanyCar_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null,

            //    //};

            //    switch (this._actionMode)
            //    {
            //        case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
            //            break;
            //        case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
            //            iResult = this.OperateToCompanyCar(this._dataChangeType, ref pErrorMessage);
            //            break;
            //        default:
            //            iResult = -1;
            //            break;
            //    }

            //    if (iResult == 0)
            //    {
            //        /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
            //        //this._CompanyCar = companyCar;
            //        this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //    }
            //    else
            //    {
            //        /* ვაუქმებთ ოპერაციას */
            //        throw new Exception("ოპერაცია წარუმატებლად დასრულდა");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    /* ვაუქმებთ ოპერაციას და ვკრძალავთ ფორმის დახურვას */
            //    this._formCloseSwitch = false;
            //    System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CommitButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            //}
            //finally
            //{
            //}
            try
            {
                string ErrorMessage = string.Empty;

                DialogResult res = MessageBox.Show(" გსურთ ჯგუფისთვის რიგების მინიჭება ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {

                    BM_Operation_ServiceReference.TakeRow takeRow = null;
                    BM_Operation_ServiceReference.TakeRowModel takeRowModel = null;

                    foreach (DataGridViewRow gridrow in this.BrigadeRowDataGridView.Rows)
                    {
                        takeRowModel = (BM_Operation_ServiceReference.TakeRowModel)gridrow.DataBoundItem;
                        if (takeRowModel != null)
                        {
                            takeRow = new BM_Operation_ServiceReference.TakeRow()
                            {
                                TakeRow_Id = (long)takeRowModel.TakeRow_Id,
                                TakeRow_Brigade_Id = System.Convert.ToInt32(this.BrigadeComboBox.SelectedValue),
                                TakeRow_In_DateTime = takeRowModel.TakeRow_In_DateTime,
                                TakeRow_In_TakeRowInOut_Id = takeRowModel.TakeRow_In_TakeRowInOut_Id,
                                TakeRow_In_TUser_PersonPost_Id = (long)takeRowModel.TakeRow_In_TUser_PersonPost_Id,
                                TakeRow_Out_DateTime = takeRowModel.TakeRow_Out_DateTime,
                                TakeRow_Out_TakeRowInOut_Id = takeRowModel.TakeRow_Out_TakeRowInOut_Id,
                                TakeRow_Out_User_PersonPost_Id = takeRowModel.TakeRow_Out_User_PersonPost_Id,
                                TakeRow_Row_Id = (long)takeRowModel.TakeRow_Row_Id

                            };
                            using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                            {
                                serviceClient.UpdateTakeRow(takeRow, ref ErrorMessage);
                            }
                            if (!string.IsNullOrEmpty(ErrorMessage))
                            {
                                throw new Exception(ErrorMessage);
                            }
                        }

                    }
                    MessageBox.Show("მონაცემები განახლდა, რიგები მინიჭებულია");



                    using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                    {
                        var EmptyRow = serviceClient.GetTakeRowsModelByBrigadeId(ref ErrorMessage);
                        AllRowDataGridView.DataSource = EmptyRow;
                        var FilledRow = serviceClient.GetTakeRowsModel(System.Convert.ToInt32(this.BrigadeComboBox.SelectedValue), null, true, ref ErrorMessage);
                        BrigadeRowDataGridView.DataSource = FilledRow;
                    }
                    if (!string.IsNullOrEmpty(ErrorMessage))
                    {
                        throw new Exception(ErrorMessage);
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: CommitButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }


        }
    }
}
