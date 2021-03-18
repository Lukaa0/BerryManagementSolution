using BerryManagementApplication.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Operations
{
    public partial class HarvesterRowDistributionEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Operation_ServiceReference.HarvesterRowDistribution _HarvesterRow;
        private BM_Structure_ServiceReference.Row _row;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private BM_Structure_ServiceReference.CompanyeModel _CurrentCompanyModel=null;
        private List<BM_Employee_ServiceReference.PersonPostModel> _personPostsModel = null;
        private List<BM_Employee_ServiceReference.PersonPostModel> _HarvesterPersonPost = null;
       
        private List<BM_Employee_ServiceReference.PersonPostModel> _choosedHarvesterForRowAdd = new List<BM_Employee_ServiceReference.PersonPostModel>();
        private List<BM_Employee_ServiceReference.PersonPostModel> _choosedHarvesterForRowRemove = new List<BM_Employee_ServiceReference.PersonPostModel>();

        private long _brigadeId;


        public HarvesterRowDistributionEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._HarvesterRow = new BM_Operation_ServiceReference.HarvesterRowDistribution();
            this._formCloseSwitch = true;
            AllHarvesterDataGridView.AutoGenerateColumns = false;

            //this.RowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        public HarvesterRowDistributionEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Row Row , long brigadeId)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            //this._HarvesterRow = (HarvesterRow != null) ? HarvesterRow : new  BM_Operation_ServiceReference.HarvesterRowDistribution();
            this._row = (Row != null) ? Row : new BM_Structure_ServiceReference.Row();
            this._brigadeId = brigadeId;
            this._formCloseSwitch = true;

            AllHarvesterDataGridView.AutoGenerateColumns = false;


            //this.RowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        #region Public properties
        public BM_Operation_ServiceReference.HarvesterRowDistribution HarvesterRowObject
        {
            get { return this._HarvesterRow; }
        }
        #endregion

        #region Public methods

        public int OperateToCompanyRow(DataChangeType inDataChangeType, long UserPersonPostID, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;


                int AddcountRow = this._choosedHarvesterForRowAdd.Count;
                if (AddcountRow > 0)
                {
                    BM_Operation_ServiceReference.HarvesterRowDistributionInOut harvesterRowDistribution = null;
                    BM_Employee_ServiceReference.PersonPostModel personPostModel = null;
                    for (int i = 0; i < AddcountRow; i++)
                    {
                        personPostModel = this._choosedHarvesterForRowAdd[i];
                        harvesterRowDistribution = new BM_Operation_ServiceReference.HarvesterRowDistributionInOut
                        {
                            Id = Guid.NewGuid(),
                            HarvesterPersonPostId = personPostModel.PersonPost_Id,
                            Time = DateTime.Now,
                            RowId = _row.Row_Id,
                            IsComplete = false,
                            UserPersonPostId = UserPersonPostID,
                            Direction = true
                        };

                        using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                        {
                            serviceClient.FixHarvesterRowDistributionInOut(harvesterRowDistribution, ref inoutErrorMessage);
                        }
                    }

                }

                int RemovecountRow = this._choosedHarvesterForRowRemove.Count;
                if (RemovecountRow > 0)
                {
                    BM_Operation_ServiceReference.HarvesterRowDistributionInOut harvesterRowDistribution = null;
                    BM_Employee_ServiceReference.PersonPostModel personPostModel = null;
                    for (int i = 0; i < RemovecountRow; i++)
                    {
                        personPostModel = this._choosedHarvesterForRowRemove[i];
                        harvesterRowDistribution = new BM_Operation_ServiceReference.HarvesterRowDistributionInOut
                        {
                            Id = Guid.NewGuid(),
                            HarvesterPersonPostId = personPostModel.PersonPost_Id,
                            Time = DateTime.Now,
                            RowId = _row.Row_Id,
                            UserPersonPostId = UserPersonPostID,
                            IsComplete = false,
                            Direction = false


                        };

                        using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                        {
                            serviceClient.FixHarvesterRowDistributionInOut(harvesterRowDistribution, ref inoutErrorMessage);
                        }
                    }

                }
                if (!string.IsNullOrEmpty(inoutErrorMessage))
                    {
                        MessageBox.Show(inoutErrorMessage);
                    }
               
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
            BM_Operation_ServiceReference.HarvesterRowDistribution HarvesterRow = null;
            
            string pErrorMessage = System.String.Empty;
            int iResult = 0;
            long UserPersonPostID;
            using (BM_Employee_ServiceReference.BM_Employee_ServiceClient serviceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
            {
                UserPersonPostID = serviceClient.GetPersonPostData(null, Program.User.User_Person_ID, null, null, ref pErrorMessage).FirstOrDefault().PersonPost_Id;
            }
      
            try
            {
                ///* ფორმის დახურვის ნებართვა */
                //this._formCloseSwitch = false;

                //// ფილტრი
                //if (this.RowComboBox.SelectedItem == null)
                //    throw new Exception("არ არის მითითებული რიგი!");

                ///* ფორმის დახურვის ნებართვა */
                //this._formCloseSwitch = true;



                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCompanyRow(this._dataChangeType, UserPersonPostID, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._HarvesterRow = HarvesterRow;
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
           
           
            List<BM_Operation_ServiceReference.TakeRow> rows = null;
           
            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "მკრეფავის განაწილება";
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
                                //if (this.OperateToCompanyRow(this._dataChangeType, ref this._HarvesterRow, ref pErrorMessage) != 0)
                                //    throw new Exception(pErrorMessage);
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



                RowLabel.Text = RowLabel.Text + " " + _row.Row_Barkode;

                //using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                //{
                //    this.RowComboBox.DataSource = serviceClient.GetRowsWithBrigade(ref errorMessage);
                //}

                ////
                ///*რიგის კომბო*/

                //this.RowComboBox.DisplayMember = "Row_Barcode";
                //this.RowComboBox.ValueMember = "TakeRow_Row_Id";
                //this.RowComboBox.SelectedIndex = -1;
                //if ((this.RowComboBox.Items.Count > 0) && (this._HarvesterRow.HarvesterRowDistribution_Row_Id>0))
                //    foreach (BM_Operation_ServiceReference.TakeRowModel RowM in this.RowComboBox.Items)
                //        if ((long)RowM.TakeRow_Row_Id == this._HarvesterRow.HarvesterRowDistribution_Row_Id)
                //        {
                //            this.RowComboBox.SelectedIndex = this.RowComboBox.Items.IndexOf(RowM);
                //            break;
                //        }



                /*რიგის გრიდი*/


                getData();

                


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
                string errorMessage = null;
               

                  using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        _personPostsModel = service.GetPersonPostModelForRows(_brigadeId, ref errorMessage);
                    //_HarvesterPersonPost = service.GetHarvesterInRowPersonPost(System.Convert.ToInt32(this.RowComboBox.SelectedValue), ref errorMessage);
                }

                    this.AllHarvesterDataGridView.DataSource = _personPostsModel;
                    this.HarvesterRowDataGridView.DataSource = _HarvesterPersonPost;
            
             
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void AddRowsButton_Click(object sender, EventArgs e) 
        { 

            String errorMessage = string.Empty;
            
            
            BM_Employee_ServiceReference.PersonPostModel personPost = null;
            string rowBarkode;
            //მონიშნული personpost ის წამოღება AllHarvesterDataGridView (ყველა მკრეფავის ჩამონათვალი) -დან
            foreach (DataGridViewRow gridrow in this.AllHarvesterDataGridView.Rows) 
            {
                if (gridrow.Selected)
                {
                    personPost = (BM_Employee_ServiceReference.PersonPostModel)gridrow.DataBoundItem;
                    using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                    {
                        //შემოწმება უკვე დაკავებული ხომ არ არის მკრეფავი
                        if(serviceClient.CheckHarvesterInRowPersonPost(personPost.PersonPost_Id,ref errorMessage))
                        {
                            //არჩეული მკრეფავის ლისტში დამატება
                            _choosedHarvesterForRowAdd.Add((BM_Employee_ServiceReference.PersonPostModel)gridrow.DataBoundItem);
                        }
                        else
                        {
                            //შეტყობინების გამოტანა უკვე დაკავებული მკრეფავის შესახებ
                            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                            {
                                rowBarkode = service.GetHarvesterInDistributionModel(personPost.PersonPost_Id, ref errorMessage).FirstOrDefault().Row_Barkode;
                            }
                            MessageBox.Show("მკრეფავი უკვე დაკავებულია" + rowBarkode + "რიგშო");
                        }
                    }
                    
                }
            }

            //შემოწმება არსებობს თუ არა HarvesterRowDataGridView (უკვე დაკავებული მკრეფავები) ცხრილში
            int countRow = this.HarvesterRowDataGridView.Rows.Count;
            List<BM_Employee_ServiceReference.PersonPostModel> harvesterInPersonPost = new List<BM_Employee_ServiceReference.PersonPostModel>();
            if (countRow > 0)
            {
                for(int i=0; i<countRow; i++)
                {
                    //ცხრიში ასებული მონაცემების სიაში დამატება
                    harvesterInPersonPost.Add((BM_Employee_ServiceReference.PersonPostModel)this.HarvesterRowDataGridView.Rows[i].DataBoundItem);
                }
            }
            //სიების გაერთიანება
            harvesterInPersonPost.AddRange(_choosedHarvesterForRowAdd);
            //ცხრილში სრული ახალი არჩეული და იქამდე არსებული მონაცემების გამოტანა
            this.HarvesterRowDataGridView.DataSource = harvesterInPersonPost;
  
        }

        private void RemoveRowsButton_Click(object sender, EventArgs e)
        {
            String errorMessage = string.Empty;

            List<BM_Employee_ServiceReference.PersonPostModel> harvesterPersonPost = new List<BM_Employee_ServiceReference.PersonPostModel>();
            BM_Employee_ServiceReference.PersonPostModel personPost = null;
           
            int countRow = this.HarvesterRowDataGridView.Rows.Count;
            List<BM_Employee_ServiceReference.PersonPostModel> harvesterInPersonPost = new List<BM_Employee_ServiceReference.PersonPostModel>();
            if (countRow > 0)
            {
                for (int i = 0; i < countRow; i++)
                {
                    //ცხრიში ასებული მონაცემების სიაში დამატება
                    harvesterInPersonPost.Add((BM_Employee_ServiceReference.PersonPostModel)this.HarvesterRowDataGridView.Rows[i].DataBoundItem);
                }
            }


            foreach (DataGridViewRow gridrow in this.HarvesterRowDataGridView.Rows)
            {

                if (gridrow.Selected)
                {
                    personPost = (BM_Employee_ServiceReference.PersonPostModel)gridrow.DataBoundItem;
                    if (_choosedHarvesterForRowAdd.Contains(personPost))
                    {
                        _choosedHarvesterForRowAdd.Remove(personPost);
                        harvesterInPersonPost.Remove(personPost);
                    }
                    else
                    {
                        harvesterInPersonPost.Remove(personPost);
                        _choosedHarvesterForRowRemove.Add(personPost);
                    }
                    
                }
            }
            this.HarvesterRowDataGridView.DataSource = harvesterInPersonPost;
           
        }

        private void AllHarvesterDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void HarvesterRowDistributionEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
