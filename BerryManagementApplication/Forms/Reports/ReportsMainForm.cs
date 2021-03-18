using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace BerryManagementApplication.Forms.Reports
{
    public partial class ReportsMainForm : Form
    {

        private List<BM_Employee_ServiceReference.ReportModel> list = new List<BM_Employee_ServiceReference.ReportModel>();
        private List<BM_Employee_ServiceReference.PunishmentCountModel> _punObject = new List<BM_Employee_ServiceReference.PunishmentCountModel>();
        private List<BM_Employee_ServiceReference.RecPunishmentCountModel> _givenPunOjcet = new List<BM_Employee_ServiceReference.RecPunishmentCountModel>();
        private List<BM_Employee_ServiceReference.RecPunishmentCountModel> _recomPunOjcet = new List<BM_Employee_ServiceReference.RecPunishmentCountModel>();

        private ReportsMainForm frm;

        public ReportsMainForm()
        {
            InitializeComponent();
            this.Text = "რეპორტების პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            if (Program.User.User_Role_ID != 13)
            {
                Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            }

            frm = this;

        }


        public void ActivateTabPage(string name)
        {
            this.ReportsTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.ReportsTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.ReportsTabControl, tabPageName);
        }

        //serializaciisatvis
        public static byte[] StrToByteArray(string str)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetBytes(str);
        }

        #region Harvester

        private void HarvesterTabPage_Enter(object sender, EventArgs e)
        {
            //GetWeightButtonClick();
            
        }

        private void GetWeightButton_Click(object sender, EventArgs e)
        {
            GetWeightButtonClick();
        }

        private void GetWeightButtonClick()
        {
            try
            {
                if (HarvStartDateTimePicker.Value <= HarvEndDateTimePicker.Value)
                {
                    FillHarvesterGrid(HarvStartDateTimePicker.Value.Date, HarvEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FillHarvesterGrid(DateTime? start, DateTime? end)
        {

            try
            {
                this.MainFindResultsDataGridView.DataSource = null;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;


                string errorMessage = string.Empty;

                DataTable dt = new DataTable();
                byte[] bytes = null;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    bytes = EmployeeServiceClient.GetHarvesterReportWhole(start, end, ref errorMessage);
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }


                //Now deserialise
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream(bytes);
                dt = (DataTable)bformatter.Deserialize(stream);
                stream.Close();

                this.MainFindResultsDataGridView.DataSource = dt;

                if (dt.Columns.Count != 0)
                {
                    this.MainFindResultsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.MainFindResultsDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int columnCount = this.MainFindResultsDataGridView.Columns.Count - 1;
                    this.MainFindResultsDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillHarvesterGrid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }


        #endregion

        #region Receiver

        private void RecieverTabPage_Enter(object sender, EventArgs e)
        {
            //RecieverButtonClick();
        }

        private void RecieverButton_Click(object sender, EventArgs e)
        {
            RecieverButtonClick();
        }

        private void RecieverButtonClick()
        {
            try
            {
                if (RecieverEndDateTimePicker.Value >= RecieverStartDateTimePicker.Value)
                {
                    FillRecieverDataGridView(RecieverStartDateTimePicker.Value.Date, RecieverEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void FillRecieverDataGridView(DateTime? start, DateTime? end)
        {
            try
            {
                this.RecieverDataGridView.DataSource = null;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string errorMessage = string.Empty;

                DataTable dt = new DataTable();
                byte[] bytes = null;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    bytes = EmployeeServiceClient.GetRecieverReportWhole(start, end, ref errorMessage);
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                //Now deserialise
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream(bytes);
                dt = (DataTable)bformatter.Deserialize(stream);
                stream.Close();

                this.RecieverDataGridView.DataSource = dt;

                if (dt.Columns.Count != 0)
                {
                    this.RecieverDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.RecieverDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int columnCount = this.RecieverDataGridView.Columns.Count - 1;
                    this.RecieverDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillRecieverDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


        }



        #endregion

        #region controlior

        private void ControliorTabPage_Enter(object sender, EventArgs e)
        {
            //ControliorButtonClick();
        }

        private void ControliorButton_Click(object sender, EventArgs e)
        {
            ControliorButtonClick();
        }

        private void ControliorButtonClick()
        {
            try
            {
                if (ControliorStartDateTimePicker.Value <= ControliorEndDateTimePicker.Value)
                {
                    FillControliorDataGridView(ControliorStartDateTimePicker.Value.Date, ControliorEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillControliorDataGridView(DateTime? start, DateTime? end)
        {
            try
            {
                this.ControliorDataGridView.DataSource = null;
                string errorMessage = string.Empty;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataTable dt = new DataTable();
                byte[] bytes = null;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    bytes = EmployeeServiceClient.GetControliorReportWhole(start, end, ref errorMessage);
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                //Now deserialise
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream(bytes);
                dt = (DataTable)bformatter.Deserialize(stream);
                stream.Close();

                this.ControliorDataGridView.DataSource = dt;
                if (dt.Columns.Count != 0)
                {

                    this.ControliorDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.ControliorDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int columnCount = this.ControliorDataGridView.Columns.Count - 1;
                    this.ControliorDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillControliorDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


        }
        #endregion

        #region packager
        private void PackagerButton_Click(object sender, EventArgs e)
        {
            PackagerButtonClick();
        }

        private void PackagerTabPage_Enter(object sender, EventArgs e)
        {
            //PackagerButtonClick();
        }

        private void PackagerButtonClick()
        {
            try
            {
                if (PackagerStartdateTimePicker.Value <= PackagerEndDateTimePicker.Value)
                {
                    FillPackagerDataGridView(PackagerStartdateTimePicker.Value.Date, PackagerEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillPackagerDataGridView(DateTime? start, DateTime? end)
        {
            try
            {
                this.PackagerDataGridView.DataSource = null;

                string errorMessage = string.Empty;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                DataTable dt = new DataTable();
                byte[] bytes = null;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    bytes = EmployeeServiceClient.GetPackagerReportWhole(start, end, ref errorMessage);
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                //Now deserialise
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream(bytes);
                dt = (DataTable)bformatter.Deserialize(stream);
                stream.Close();

                this.PackagerDataGridView.DataSource = dt;
                if (dt.Columns.Count != 0)
                {
                    this.PackagerDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.PackagerDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int columnCount = this.PackagerDataGridView.Columns.Count - 1;
                    this.PackagerDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillPackagerDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }


        }
        #endregion

        #region day

        private void DayTabPage_Enter(object sender, EventArgs e)
        {
            //DayButtonClick();
            PalleteDataGridView.RowTemplate.Height = 30;
        }

        private void DayButton_Click(object sender, EventArgs e)
        {
            DayButtonClick();

            
        }

        private void PalleteDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.RowIndex != -1 && e.RowIndex != 0)
            {
                PrintButton_Click();
            }
        }

        private void PrintButton_Click()
        {
            if (this.PalleteDataGridView.RowCount > 0)
            {
                BM_Operation_ServiceReference.PalleteModel containerWeight =
                    (BM_Operation_ServiceReference.PalleteModel)this.PalleteDataGridView.CurrentRow.DataBoundItem;
                List<BM_Library_ServiceReference.RS_ProductModel> products = (List<BM_Library_ServiceReference.RS_ProductModel>)this.BreedsDataGridView.DataSource;
                List<Classes.PalleteLabel.Product> productItems = new List<Classes.PalleteLabel.Product>();
                foreach (BM_Library_ServiceReference.RS_ProductModel product in products)
                {
                    Classes.PalleteLabel.Product productItem = new Classes.PalleteLabel.Product();
                    productItem.ProductBoxCount = product.Product_ContainerCount.ToString();
                    productItem.ProductName = product.Product_Breed_Name;
                    productItem.ProductWeight = product.Product_WeightsSum.ToString();
                    productItems.Add(productItem);
                }
                Classes.PalleteLabel palleteLabel = new Classes.PalleteLabel()
                {
                    PalleteBarcode = containerWeight.ContainerWeight_Container_BarCode,
                    PalleteBoxCount = containerWeight.Container_Count.ToString(),
                    PalleteDatetime = containerWeight.ContainerWeight_DateTime.ToString(@"dd MMM yyyy HH:mm"),
                    PalleteWeightGross = containerWeight.ContainerWeight_Gross.ToString(),
                    PalleteWeightNet = containerWeight.ContainerWeight_Net.ToString(),
                    PalleteProducts = productItems
                };
                List<Classes.PalleteLabel> palleteLabels = new List<Classes.PalleteLabel>();
                palleteLabels.Add(palleteLabel);
                Report.TemplatesViewerForm templatesViewerForm = new Report.TemplatesViewerForm(palleteLabels);
                templatesViewerForm.ShowDialog(this);
            }
        }

        private void DayButtonClick()
        {
            try
            {
                if (DayStartDateTimePicker.Value <= DayEndDateTimePicker.Value)
                {
                    FillDayDataGridView(DayStartDateTimePicker.Value.Date, DayEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillDayDataGridView(DateTime start, DateTime end)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string errorMessage = null;
                this.PalleteDataGridView.AutoGenerateColumns = false;


                List<BM_Operation_ServiceReference.PalleteModel> model = new List<BM_Operation_ServiceReference.PalleteModel>();

                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    model = serviceClient.GetContainerWeightsByChars("CB", start, end, ref errorMessage);
                }

                var query = from pal in model
                            group pal by 1 into g
                            select new BM_Operation_ServiceReference.PalleteModel
                            {
                                ContainerWeight_Gross = g.Select(o => o.ContainerWeight_Gross).Sum(),
                                ContainerWeight_Net = g.Select(o => o.ContainerWeight_Net).Sum(),
                                Container_Count = g.Select(o => o.Container_Count).Sum(),
                            };
                List<BM_Operation_ServiceReference.PalleteModel> sum = query.ToList();

                List<BM_Operation_ServiceReference.PalleteModel> sortedList = (model.OrderBy(u => u.ContainerWeight_Container_BarCode)).ToList();

                if(sortedList.Count != 0)
                {
                    sortedList.Insert(0, new BM_Operation_ServiceReference.PalleteModel
                    {
                        ContainerWeight_Container_BarCode = "პალეტების რაოდენობა - " + sortedList.Count,
                        ContainerWeight_Gross = sum.FirstOrDefault().ContainerWeight_Gross,
                        ContainerWeight_Net = sum.FirstOrDefault().ContainerWeight_Net,
                        Container_Count = sum.FirstOrDefault().Container_Count,
                    });
                }
                else
                {
                    MessageBox.Show("ამ პერიოდში პალეტები არ დამზადებულა");
                }

                this.PalleteDataGridView.DataSource = sortedList;

                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }



        private void PalleteDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int productOwnerStatus = 2;
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                this.BreedsDataGridView.DataSource = null;
                this.BreedsDataGridView.AutoGenerateColumns = false;
                this.PalleteDataGridView.AutoGenerateColumns = false;
                this.ContainerDataGridView.DataSource = null;
                this.ContainerDataGridView.AutoGenerateColumns = false;
                string errorMessage = string.Empty;
                //List<BM_Library_ServiceReference.RS_ProductModel> esd = null;
                List<BM_Operation_ServiceReference.ContainerModel> pack = null;
                if (sender != null)
                {
                    if (e.RowIndex >= 0)
                    {
                        BM_Operation_ServiceReference.PalleteModel conWeight = (BM_Operation_ServiceReference.PalleteModel)this.PalleteDataGridView.Rows[e.RowIndex].DataBoundItem;
                        if (!conWeight.ContainerWeight_Container_BarCode.ToString().Equals("ჯამი"))
                        {
                            //using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                            //{
                            //    esd = serviceClient.GetRS_ProductModelByContainers(conWeight.ContainerWeight_Container_BarCode, productOwnerStatus, ref errorMessage);
                            //}
                            using (BM_Operation_ServiceReference.BM_Operation_ServiceClient service = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                            {
                                pack = service.GetContainerModelByPalette(conWeight.ContainerWeight_Container_BarCode, ref errorMessage);
                            }
                            if (!string.IsNullOrEmpty(errorMessage))
                                throw new Exception(errorMessage);
                        }

                        //if (esd != null)
                        //{
                        //    var sortedBreed = esd.OrderBy(u => u.Product_Breed_Name);
                        //    this.BreedsDataGridView.DataSource = sortedBreed.ToList();
                        //}
                        if (pack != null)
                        {
                            var sortedPack = pack.OrderBy(u => u.ContainerPack_Container_BarCode);
                            this.ContainerDataGridView.DataSource = sortedPack.ToList();

                             var groupBreed = (from sort in sortedPack
                                                group sort by sort.BreedName into g
                                                select new BM_Library_ServiceReference.RS_ProductModel()
                                                {
                                                    Product_Breed_Name = g.Key,
                                                    Product_ContainerCount = g.Count(),
                                                    Product_WeightsSum = (decimal)g.Sum(c => c.ContainerPack_NetWeight)
                                                }).ToList();

                            this.BreedsDataGridView.DataSource = groupBreed;

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }



        #endregion

        #region brigadere 

        private void BrigadireTabPage_Enter(object sender, EventArgs e)
        {
            //BrigadireButtonClick();
        }

        private void BrigadireButton_Click(object sender, EventArgs e)
        {
            BrigadireButtonClick();
        }

        private void BrigadireButtonClick()
        {
            try
            {
                if (BrigadireStartDateTimePicker.Value <= BrigadireEndDateTimePicker.Value)
                {
                    FillBrigadireDataGridView(BrigadireStartDateTimePicker.Value.Date, BrigadireEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillBrigadireDataGridView(DateTime start, DateTime end)
        {
            try
            {
                this.BrigadireDataGridView.DataSource = null;

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                list = new List<BM_Employee_ServiceReference.ReportModel>();
                _givenPunOjcet = new List<BM_Employee_ServiceReference.RecPunishmentCountModel>();
                _punObject = new List<BM_Employee_ServiceReference.PunishmentCountModel>();

                string errorMessage = string.Empty;

                DataTable dt = new DataTable();
                byte[] bytes = null;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    bytes = EmployeeServiceClient.GetBrigadireReportWhole(start, end, ref errorMessage);
                }

                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
                //Now deserialise
                BinaryFormatter bformatter = new BinaryFormatter();

                MemoryStream stream = new MemoryStream(bytes);
                dt = (DataTable)bformatter.Deserialize(stream);
                

                this.BrigadireDataGridView.DataSource = dt;
                stream.Close();
                if (dt.Columns.Count != 0)
                {
                    this.BrigadireDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    this.BrigadireDataGridView.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    int columnCount = this.BrigadireDataGridView.Columns.Count - 1;
                    this.BrigadireDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillBrigadireDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion

        #region General

        private void GeneralTabPage_Enter(object sender, EventArgs e)
        {
            //GeneralButtonClick();
        }

        private void GeneralButton_Click(object sender, EventArgs e)
        {
            GeneralButtonClick();
        }

        private void GeneralButtonClick()
        {
            try
            {
                if (GeneralStartDateTimePicker.Value <= GeneralEndDateTimePicker.Value)
                {
                    FillGeneralDataGridView(GeneralStartDateTimePicker.Value.Date, GeneralEndDateTimePicker.Value.AddDays(+1).Date);
                }
                else
                {
                    throw new Exception("შეამოწმეთ თარიღი");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillGeneralDataGridView(DateTime start, DateTime end)
        {
            try
            {
                this.GeneralDataGridView.DataSource = null;
                this.GeneralDataGridView.Columns.Clear();
                

                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                List<BM_Employee_ServiceReference.GeneralReportModel> listi = new List<BM_Employee_ServiceReference.GeneralReportModel>();

                string errorMessage = string.Empty;

                // მონაცემების მოძიება
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    listi = EmployeeServiceClient.GetGeneralReport(start, end, ref errorMessage);
                }
                if (listi.Count != 0)
                {

                    var pivotTable = listi.ToPivotTable(
                      item => item.CompanyName,
                      item => item.BreedName,
                      items => items.Any() ? items.Sum(x => x.Sum) : 0);

                    pivotTable.Columns.Add("ჯამი");


                    DataColumnCollection dataColumns = pivotTable.Columns;
                    DataRow nawRow = pivotTable.NewRow();
                    nawRow.SetField(0, "ჯამი");
                    for (int i = 1; i < nawRow.ItemArray.Length; i++)
                    {
                        nawRow.SetField(i, 0);
                    }
                    foreach (DataRow row in pivotTable.Rows)
                    {
                        decimal sum = 0;
                        for (int i = 1; i < row.ItemArray.Length; i++)
                        {
                            decimal l = 0;
                            if (decimal.TryParse(row[i].ToString(), out l))
                            {
                                if (i != row.ItemArray.Length - 1)
                                {
                                    sum = sum + l;
                                }
                                decimal ll = decimal.Parse(nawRow.ItemArray[i].ToString()) + l;
                                nawRow.SetField(i, ll);
                            }
                            row.SetField("ჯამი", sum);
                        }
                    }
                    pivotTable.Rows.Add(nawRow);

                    this.GeneralDataGridView.DataSource = pivotTable;

                    if (pivotTable.Columns.Count != 0)
                    {
                        GeneralDataGridView.Columns.Add("Date", "პერიოდი");

                        this.GeneralDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        int columnCount = this.GeneralDataGridView.Columns.Count - 1;
                        this.GeneralDataGridView.Columns[columnCount].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                        GeneralDataGridView.Columns[0].HeaderText = "ჯიშის სახელი";

                        foreach (DataGridViewRow row in GeneralDataGridView.Rows)
                        {
                            row.Cells["Date"].Value = GeneralStartDateTimePicker.Value.Date.ToString(@"dd MMM yyyy") + " - " + GeneralEndDateTimePicker.Value.Date.ToString(@"dd MMM yyyy");
                        }
                    }
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: FillGeneralDataGridView", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void GeneralDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == ((DataGridView)sender).ColumnCount - 2) ||
            (e.RowIndex == ((DataGridView)sender).RowCount - 1))
            {
                e.CellStyle.BackColor = Color.Yellow;
            }
            if ((e.ColumnIndex == ((DataGridView)sender).ColumnCount - 1) &&
            (e.RowIndex == ((DataGridView)sender).RowCount - 1))
            {
                e.CellStyle.BackColor = Color.White;
            }
            if ((e.ColumnIndex == ((DataGridView)sender).ColumnCount - 2) &&
                (e.RowIndex == ((DataGridView)sender).RowCount - 1))
            {
                e.CellStyle.BackColor = Color.LightGreen;
            }
        }

        #endregion

        #region HardvesterRowDistribucuin
        private void HardvesterRowDistribucuinTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = "";
                this.takeRows_HarvestersDataGridViewEI.AutoGenerateColumns = false;
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = 
                    new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    List<BM_Structure_ServiceReference.Brigade> brigades = serviceClient.GetBrigades(null, null, ref errorMessage);
                    brigades.Add(new BM_Structure_ServiceReference.Brigade());
                    brigades = brigades.OrderBy(b => b.Brigade_Name).ToList();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception(errorMessage);
                    }
                    this.HarvesterRowDistributionFilterGroupsComboBox.DataSource = brigades;
                    this.HarvesterRowDistributionFilterGroupsComboBox.ValueMember = "Brigade_Id";
                    this.HarvesterRowDistributionFilterGroupsComboBox.DisplayMember = "Brigade_Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void HarvesterRowDistributionFilterButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string errorMessage = "";
                long? brigadeId = long.Parse(this.HarvesterRowDistributionFilterGroupsComboBox.SelectedValue.ToString());
                brigadeId = brigadeId == 0 ? null : brigadeId;
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient =
                    new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    List<BM_Operation_ServiceReference.TakeRows_Harvesters> takeRows_Harvesters = serviceClient.GetTakeRows_Harvesters(
                        brigadeId, ref errorMessage).OrderBy(t => t.BrigadeName).ThenBy(b => b.RowBarCode).ToList();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                       throw new Exception(errorMessage);
                    }
                    this.takeRows_HarvestersDataGridViewEI.DataSource = takeRows_Harvesters;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }
        #endregion HardvesterRowDistribucuin

        #region ContainerPosition

        private void ContainersPositionTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = "";
                this.ContainersPositionataGridViewEI.AutoGenerateColumns = false;
                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient =
                    new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    List<BM_Structure_ServiceReference.PointsModel> points = serviceClient.GetPoint(null, ref errorMessage);
                    points.Add(new BM_Structure_ServiceReference.PointsModel());
                    points = points.OrderBy(p => p.Point_Name).ToList();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception(errorMessage);
                    }
                    this.ContainersPositionComboBox.DataSource = points;
                    this.ContainersPositionComboBox.ValueMember = "Point_Id";
                    this.ContainersPositionComboBox.DisplayMember = "Point_Name";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ContainersPositionutton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                string errorMessage = "";
                long? pointId = long.Parse(this.ContainersPositionComboBox.SelectedValue.ToString());
                pointId = pointId == 0 ? null : pointId;
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient =
                    new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    List<BM_Operation_ServiceReference.ContainerLocationModel> containerLocations = serviceClient.GetContainersLocationss(
                        pointId, ref errorMessage).OrderBy(c => c.PointName).ThenBy(c => c.ContainerBarCode).ToList();
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        throw new Exception(errorMessage);
                    }
                    this.ContainersPositionataGridViewEI.DataSource = containerLocations;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void ContainersPositionataGridViewEI_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if ((e.ColumnIndex == 1) && (e.RowIndex > -1))
            {
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("CT-20"))
                {
                    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightCyan;
                }
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("CS-20"))
                {
                    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("CL-20"))
                {
                    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                }
                if (((DataGridView)sender).Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("CB-20"))
                {
                    ((DataGridView)sender).Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSalmon;
                }
            }
        }


        #endregion
    }
}
       