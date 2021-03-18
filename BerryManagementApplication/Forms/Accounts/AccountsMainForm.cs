using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Accounts
{
    public partial class AccountsMainForm : Form
    {
        //private BM_Security_ServiceReference.User _User;
        //private BM_Security_ServiceReference.Role _Role;
        bool TreeviewIsGenerating = false;
        bool EditingPermissions = false;
        //private long? lastID;

        private String _rowName, _rowPostName, _rowRoletName;
        private long _rowId, _passworRowId, _userId;
        private AccountsMainForm frm;

        private BM_RS_ServiceReference.TransportWaybill waybil;

        public AccountsMainForm()
        {
            InitializeComponent();
            this.Text = "უსაფრთხოების მართვის პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;
            if (Program.User.User_Role_ID != 13)
            {
                Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            }

            frm = this;
        }

        private void TransportWaybillsDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BM_Structure_ServiceReference.Point Point = new BM_Structure_ServiceReference.Point();
            Forms.Structure.PointEditForm RowBreedEditForm = null;

            try
            {

                ///* რედაქტირების ფორმა */
                //RowBreedEditForm = new PointEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData, Point);
                //switch (RowBreedEditForm.ShowDialog(this))
                //{
                //    case System.Windows.Forms.DialogResult.OK:
                //        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                //        this.PointsTabPage_Enter(this.PointsTabPage, new EventArgs());
                //        break;
                //    case System.Windows.Forms.DialogResult.Cancel:
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source:PointAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }


        }

        private void NonTransportWaybillsGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            BM_Structure_ServiceReference.Point Point = new BM_Structure_ServiceReference.Point();
            Forms.Structure.PointEditForm RowBreedEditForm = null;

            try
            {

                ///* რედაქტირების ფორმა */
                //RowBreedEditForm = new PointEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData, Point);
                //switch (RowBreedEditForm.ShowDialog(this))
                //{
                //    case System.Windows.Forms.DialogResult.OK:
                //        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                //        this.PointsTabPage_Enter(this.PointsTabPage, new EventArgs());
                //        break;
                //    case System.Windows.Forms.DialogResult.Cancel:
                //        break;
                //    default:
                //        break;
                //}
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source:PointAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


        public void ActivateTabPage(string name)
        {
            this.AccountsTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.AccountsTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.AccountsTabControl, tabPageName);
        }

        #region RS



        private void RolesTabPage_Enter(object sender, EventArgs e)
        {

            
            
            //GetTransportWaybillModel(WayBillDateTimePicker.Value.Date);

            //ChangeColorTransportGrid();

        }
        private void GetWeightButton_Click(object sender, EventArgs e)
        {
            GetTransportWaybillModel(WayBillDateTimePicker.Value.Date);
            ChangeColorTransportGrid();
        }


        private void ChangeColorTransportGrid()
        {
            foreach (DataGridViewRow row in TransportWaybillsDataGridView.Rows)
            {
                if (row.Cells["TransportWaybill_RS_Id"].Value == null || row.Cells["TransportWaybill_RS_Number"].Value == null)
                {
                    //MessageBox.Show(row.Index.ToString());
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.OrangeRed;
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (long.Parse(row.Cells["TransportWaybillDetail_State"].Value.ToString()) == 0)
                {
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.Green;
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                if (long.Parse(row.Cells["TransportWaybillDetail_State"].Value.ToString()) == 1)
                {
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightPink;
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (long.Parse(row.Cells["TransportWaybillDetail_State"].Value.ToString()) > 1)
                {
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                    this.TransportWaybillsDataGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }


        private void ChangeColorNonTransportGrid()
        {
            foreach (DataGridViewRow row in this.NonTransportWaybillsGridView.Rows)
            {
                if (row.Cells["NonTransportWaybill_RS_Id"].Value == null || row.Cells["NonTransportWaybill_RS_Number"].Value == null)
                {
                    //MessageBox.Show(row.Index.ToString());
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.OrangeRed;
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                if (long.Parse(row.Cells["NonTransportWaybillDetail_State"].Value.ToString()) == 0)
                {
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.Green;
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                if (long.Parse(row.Cells["NonTransportWaybillDetail_State"].Value.ToString()) == 1)
                {
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightYellow;
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
                else if (long.Parse(row.Cells["NonTransportWaybillDetail_State"].Value.ToString()) > 1)
                {
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.BackColor = Color.LightGreen;
                    this.NonTransportWaybillsGridView.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                }
            }
        }

        private void TransportWaybillsDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            
        }

        private void TransportWaybillsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string errorMessage = null;
            if (e.ColumnIndex == this.TransportWaybillsDataGridView.Columns["Correction"].Index && e.RowIndex != -1)
            {
                long id = long.Parse(this.TransportWaybillsDataGridView.Rows[e.RowIndex].Cells["TransportWaybill_Id"].Value.ToString());
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceReference = 
                    new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    if (long.Parse(this.TransportWaybillsDataGridView.Rows[e.RowIndex].Cells["TransportWaybillDetail_State"].Value.ToString()) > 0)
                    {
                        if (MessageBox.Show(this,
                            "დარწმუნებული ხართ რომ ამ ზედნადების კორექტირება საჭიროა?",
                            "ყურადღება!!!",
                            MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            serviceReference.CorrectWaybill(id, ref errorMessage);
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                MessageBox.Show(errorMessage);
                            }
                            else
                            {
                                int currentRow = e.RowIndex;
                                this.GetWeightButton_Click(null, null);
                                ((DataGridView)sender).CurrentCell = ((DataGridView)sender).Rows[currentRow].Cells[0];
                            }
                        }
                    }
                }
                //ProductRepackAndWeight productRepackAndWeight = this._LocalDatabase.GetContainerWeight(Id, ref errorMessage);
                //this.Print(productRepackAndWeight, ref errorMessage);
                //if (!string.IsNullOrEmpty(errorMessage))
                //{
                //    MessageBox.Show(errorMessage);
                //}
            }
        }

        /// <summary>
        /// მეთოდი რომელიც ქმნის TransportWaybill ცხრილს
        /// </summary>
        public void GetTransportWaybillModel(DateTime day)
        {
            TransportWaybillsDataGridView.AutoGenerateColumns = false;

            string errorMessage = null;
            TransportWaybillsDataGridView.DataSource = null;
            try
            {
                using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient =
                new BM_RS_ServiceReference.BM_RS_ServiceClient())
            {
                TransportWaybillsDataGridView.DataSource = serviceClient.GetTransportWaybillModel(day, day.AddDays(+1), ref errorMessage);
            }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                        throw new Exception(errorMessage);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void GetNonTransportWaybillModel(long Id)
        {
            NonTransportWaybillsGridView.AutoGenerateColumns = false;

            string errorMessage = null;
            NonTransportWaybillsGridView.DataSource = null;
            try
            {
                using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient =
                new BM_RS_ServiceReference.BM_RS_ServiceClient())
                {
                    NonTransportWaybillsGridView.DataSource = serviceClient.GetNonTransportWaybillModel(Id, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ChangeColorNonTransportGrid();

        }


        private void NonTransportWaybillsGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            BM_RS_ServiceReference.WaybillContainerWAYBILLGOODS[] goods = null;
            string errorMessage = null;
            this.NTWDetailsDataGridView.AutoGenerateColumns = false;
            this.NTWDetailsDataGridView.DataSource = null;
            try
            {
                if (sender != null)
                {
                    if (e.RowIndex >= 0)
                    {
                        BM_RS_ServiceReference.NonTransportWaybillModel obj = (BM_RS_ServiceReference.NonTransportWaybillModel)this.NonTransportWaybillsGridView.Rows[e.RowIndex].DataBoundItem;


                        using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient =
                        new BM_RS_ServiceReference.BM_RS_ServiceClient())
                        {
                             goods = serviceClient.GetNonTransportWaybillDetailsProduct(obj.NonTransportWaybill_Id, ref errorMessage);
                        }
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            throw new Exception(errorMessage);
                        }
                        this.NTWDetailsDataGridView.DataSource = goods;
                    }
                }
                else
                {
                    if (this.TransportWaybillsDataGridView.CurrentRow != null)
                    {
                        BM_RS_ServiceReference.NonTransportWaybillModel obj = (BM_RS_ServiceReference.NonTransportWaybillModel)this.NonTransportWaybillsGridView.CurrentRow.DataBoundItem;

                        using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient =
                        new BM_RS_ServiceReference.BM_RS_ServiceClient())
                        {
                            this.NTWDetailsDataGridView.DataSource = serviceClient.GetNonTransportWaybillDetailsProduct(obj.NonTransportWaybill_Id, ref errorMessage);
                        }
                        if (!string.IsNullOrEmpty(errorMessage))
                        {
                            throw new Exception(errorMessage);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TransportWaybillsDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

            string errorMessage = null;
            this.NonTransportWaybillsGridView.DataSource = null;
            this.TWDetailsDataGridView.DataSource = null;
            this.TWDetailsDataGridView.AutoGenerateColumns = false;
            this.TWDetailsDataGridView.DataSource = null;
            this.NTWDetailsDataGridView.DataSource = null;
            try
            {
                if (sender != null)
                {
                    if (e.RowIndex >= 0)
                    {
                        BM_RS_ServiceReference.TransportWaybillModel obj = (BM_RS_ServiceReference.TransportWaybillModel)this.TransportWaybillsDataGridView.Rows[e.RowIndex].DataBoundItem;

                        if (obj != null)
                        {
                            waybil = new BM_RS_ServiceReference.TransportWaybill()
                            {
                                TransportWaybill_Company_Id = obj.TransportWaybill_Company_Id,
                                TransportWaybill_Car_Id = obj.TransportWaybill_Car_Id,
                                TransportWaybill_Car_Point_Id = obj.TransportWaybill_Car_Point_Id,
                                TransportWaybill_Destination_Point_Id = obj.TransportWaybill_Destination_Point_Id,
                                TransportWaybill_End_DateTime = obj.TransportWaybill_End_DateTime,
                                TransportWaybill_Id = obj.TransportWaybill_Id,
                                TransportWaybill_RS_Id = obj.TransportWaybill_RS_Id,
                                TransportWaybill_RS_Number = obj.TransportWaybill_RS_Number,
                                TransportWaybill_Start_DateTime = obj.TransportWaybill_Start_DateTime,
                                TransportWaybill_Start_Point_Id = obj.TransportWaybill_Start_Point_Id,
                                TransportWaybill_Type_Id = obj.TransportWaybill_Type_Id,

                            };

                            using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient = new BM_RS_ServiceReference.BM_RS_ServiceClient())
                            {
                               // this.dataGridView1.DataSource = serviceClient.GetTransportWaybillGoods(waybil, 0, 1, true, ref errorMessage);
                                this.TWDetailsDataGridView.DataSource = serviceClient.GetTransportWaybillDetailsProduct(obj.TransportWaybill_Id, ref errorMessage);
                            }
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                throw new Exception(errorMessage);
                            }

                            GetNonTransportWaybillModel(obj.TransportWaybill_Id);
                        }
                    }
                }
                else
                {
                    if (this.TransportWaybillsDataGridView.CurrentRow != null)
                    {
                        BM_RS_ServiceReference.TransportWaybillModel obj = (BM_RS_ServiceReference.TransportWaybillModel)this.TransportWaybillsDataGridView.CurrentRow.DataBoundItem;

                        if (obj != null)
                        {
                            waybil = new BM_RS_ServiceReference.TransportWaybill()
                            {
                                TransportWaybill_Company_Id = obj.TransportWaybill_Company_Id,
                                TransportWaybill_Car_Id = obj.TransportWaybill_Car_Id,
                                TransportWaybill_Car_Point_Id = obj.TransportWaybill_Car_Point_Id,
                                TransportWaybill_Destination_Point_Id = obj.TransportWaybill_Destination_Point_Id,
                                TransportWaybill_End_DateTime = obj.TransportWaybill_End_DateTime,
                                TransportWaybill_Id = obj.TransportWaybill_Id,
                                TransportWaybill_RS_Id = obj.TransportWaybill_RS_Id,
                                TransportWaybill_RS_Number = obj.TransportWaybill_RS_Number,
                                TransportWaybill_Start_DateTime = obj.TransportWaybill_Start_DateTime,
                                TransportWaybill_Start_Point_Id = obj.TransportWaybill_Start_Point_Id,
                                TransportWaybill_Type_Id = obj.TransportWaybill_Type_Id,

                            };

                            using (BM_RS_ServiceReference.BM_RS_ServiceClient serviceClient = new BM_RS_ServiceReference.BM_RS_ServiceClient())
                            {
                                this.dataGridView1.DataSource = serviceClient.GetTransportWaybillGoods(waybil, 0, 1, true, ref errorMessage);
                                this.TWDetailsDataGridView.DataSource = serviceClient.GetTransportWaybillDetailsProduct(obj.TransportWaybill_Id, ref errorMessage);
                            }
                            if (!string.IsNullOrEmpty(errorMessage))
                            {
                                throw new Exception(errorMessage);
                            }

                            GetNonTransportWaybillModel(obj.TransportWaybill_Id);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            //List<BM_RS_ServiceReference.NonTransportWaybillModel> nonTranportWaybillModels = null;
            //string errorMessage = string.Empty;
            //if (sender != null)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        BM_RS_ServiceReference.TransportWaybillModel transportWaybillModel = (BM_RS_ServiceReference.TransportWaybillModel)this.TransportWaybillsDataGridView.Rows[e.RowIndex].DataBoundItem;

            //        using (BM_RS_ServiceReference.BM_RS_ServiceClient service = new BM_RS_ServiceReference.BM_RS_ServiceClient())
            //        {

            //            nonTranportWaybillModels = service.GetNonTransportWayBillModels(null, null, transportWaybillModel.TransportWaybill_Id, null, false, null, false, ref errorMessage).ToList();

            //        }
            //        this.NonTransportWaybillsGridView.DataSource = nonTranportWaybillModels;



            //    }
            //    else
            //    {
            //        if (this.TransportWaybillsDataGridView.CurrentRow != null)
            //        {
            //            BM_RS_ServiceReference.TransportWaybill transportWaybillModel = (BM_RS_ServiceReference.TransportWaybill)this.TransportWaybillsDataGridView.CurrentRow.DataBoundItem;

            //            using (BM_RS_ServiceReference.BM_RS_ServiceClient service = new BM_RS_ServiceReference.BM_RS_ServiceClient())
            //            {
            //                nonTranportWaybillModels = service.GetNonTransportWayBillModels(null, null, transportWaybillModel.TransportWaybill_Id, null, false, null, false, ref errorMessage).ToList();

            //            }
            //            this.NonTransportWaybillsGridView.DataSource = nonTranportWaybillModels;

            //        }
            //    }

            //}








            #endregion RS




        }
    }
}