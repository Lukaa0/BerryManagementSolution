using System;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using BerryPackagingApplication.BM_Operarion_ServiceRefernce;
using System.Collections.Generic;

namespace BerryPackagingApplication
{
    public partial class MainForm : Form
    {
        DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
        private DbServices.LocalDatabase _LocalDatabase;
        private bool _IsActive2 = true;
        private List<BM_Library_ServiceReference.Container> _newall = new List<BM_Library_ServiceReference.Container>();
        List<BM_Library_ServiceReference.Container> _choosedContainer = new List<BM_Library_ServiceReference.Container>();
        List<BM_Library_ServiceReference.Container> _choosedRowContainer = new List<BM_Library_ServiceReference.Container>();



        public MainForm()
        {
            string errorMessage = null;
            InitializeComponent();
            this.Text = Program.User.User_Person_FirstName + " " + Program.User.User_Person_LastName;
            this.DGridView.AutoGenerateColumns = false;
            _LocalDatabase = new DbServices.LocalDatabase(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }

            this.ActiveCheckBox.Checked = true;

#if DEBUG
            this.Scale.testMode();
#else
            this.Scale.Start();
#endif
            BoxLabelOld.Text = "";


        }
       
        private void DgvButtonClick(object sender, DataGridViewCellEventArgs e)
        {
            string errorMessage = null;
            if (e.ColumnIndex == this.DGridView.Columns["ButtonColumn"].Index && e.RowIndex != -1)
            {
                Guid Id = new Guid(this.DGridView.Rows[e.RowIndex].Cells[this.DGridView.Columns["IdColumn"].Index].Value.ToString());
                ProductRepackAndWeight productRepackAndWeight = this._LocalDatabase.GetContainerWeight(Id, ref errorMessage);
                this.Print(productRepackAndWeight, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
            }
        }

        private void WeightButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Enabled = false;
                string errorMessage = null;
                string code = BoxLabelOld.Text;
                BoxLabelOld.Text = "";
                decimal weight = 0m;
                decimal.TryParse(Scale.Weight.Replace(" ", string.Empty), out weight);
                if ((code.Length != 14) || (!code.Contains("CT-"))||
                    (weight == 0m))
                {
                    MessageBox.Show("შეამოწმეთ ტარის კოდი და წონა");
                    return;
                }

                bool check = DbServices.Services.CheckContainer(code);
                if (check == false)
                {
                    MessageBox.Show("ესეთი ყუთი საამქროში ვერ მოიძებნა");
                    return;
                }

                ProductRepackAndWeight productRepackAndWeight = CreateProductRepackAndWeight(code, weight);
                productRepackAndWeight = DbServices.Services.GetProductRepackAndWeight(productRepackAndWeight, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
                this._LocalDatabase.InsertContainerWeightTable(productRepackAndWeight, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
                this.DGridView.DataSource = null;
                this.DGridView.DataSource = this._LocalDatabase.LoadContainerWeightTable(ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                    return;
                }
                this.Print(productRepackAndWeight, ref errorMessage);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    MessageBox.Show(errorMessage);
                }
                new Message().ShowDialog(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Enabled = true;
                focusTexBox();
            }
        }

        public void focusTexBox()
        {
            this.BoxLabelOld.Select();
        }

        private void Print(ProductRepackAndWeight productRepackAndWeight, ref string errorMessage)
        {
            try
            {
                int useByDays = Properties.Settings.Default.UseByDays;
                DateTime useBy = ((DateTime)productRepackAndWeight.HarvestDate).AddDays(useByDays);
                string ConfigText = Properties.Settings.Default.ZPL;
                string printerName = Properties.Settings.Default.DefaultPrinterName;
                StaticClasses.ZebraRawPrinterHelper.ZebraPrint(ConfigText, 
                    productRepackAndWeight.ContainerBarCode, 
                    ((DateTime)productRepackAndWeight.HarvestDate).ToString(@"dd MMM yyyy HH:mm"),
                    productRepackAndWeight.Time.ToString(@"dd MMM yyyy HH:mm"), 
                    ((decimal)productRepackAndWeight.Net).ToString("0.000" +
                    ""), 
                    productRepackAndWeight.Gross.ToString("0.000"),
                    productRepackAndWeight.BreedName,
                    useBy.ToString(@"dd MMM yyyy"),
                    printerName);
            }
            catch (Exception ex)
            {
                if (System.String.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "დაბეჭდვა ვერ მოხერხდა: Print()\n" + ex.Message;
                }
                else
                {
                    errorMessage = errorMessage + "\nდაბეჭდვა ვერ მოხერხდა: \nPrint()\n" + ex.Message;
                }
            }
        }

        private ProductRepackAndWeight CreateProductRepackAndWeight(string code, decimal weight)
        {
            ProductRepackAndWeight result = new ProductRepackAndWeight();
            result.Id = Guid.NewGuid();
            result.Time = DateTime.Now;
            result.IsComplite = false;
            result.UserPersonPostId = Program.User.User_PersonPost_ID;
            result.Gross = weight;
            result.OldContainerBarCode = code;
            return result;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.DGridView.DataSource = this._LocalDatabase.LoadContainerWeightTable(ref errorMessage);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                MessageBox.Show(errorMessage);
                return;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            BoxLabelOld.Text = string.Empty;
            BoxLabelOld.Focus();
        }

        #region pallete

        private void GeneraitButton_Click(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = null;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    var list = service.CreateContainers("CB", Decimal.ToInt32(CountNumericUpDown.Value), ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }

                fillGrid();
                sort();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: GeneraitButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PaleteTabPage_Enter(object sender, EventArgs e)
        {
            this.ContainerDataGridView.AutoGenerateColumns = false;
            ContainerDataGridView.RowTemplate.Height = 30;

            checkBox1.Checked = true;

            fillGrid();
            sort();
            
        }
        private void fillGrid()
        {
            try
            {
                this.ContainerDataGridView.DataSource = null;

                List<BM_Library_ServiceReference.Container> CompanyLIst = null;
                string errorMessage = string.Empty;


                using (BM_Library_ServiceReference.BM_Library_ServiceClient service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {

                    CompanyLIst = service.SelectContainers(null, "CB", this._IsActive2, ref errorMessage);

                }
                this.ContainerDataGridView.DataSource = CompanyLIst;
                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this._IsActive2 = true;

                fillGrid();
                sort();
            }
            else
            {
                this._IsActive2 = false;
                fillGrid();
                sort();
            }
        }

        private void SortingButton_Click(object sender, EventArgs e)
        {
            sort();

        }
        private void sort()
        {
            long countRow = this.ContainerDataGridView.Rows.Count;
            this._newall = new List<BM_Library_ServiceReference.Container>();
            if (countRow > 0)
            {
                for (int i = 0; i < countRow; i++)
                {
                    //ცხრიში ასებული მონაცემების სიაში დამატება
                    _newall.Add((BM_Library_ServiceReference.Container)this.ContainerDataGridView.Rows[i].DataBoundItem);
                }
                this._newall.Reverse();

                ContainerDataGridView.DataSource = null;
                ContainerDataGridView.DataSource = this._newall;
            }
        }

        private void ContainerDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex != -1)
            {
                var choosed = (BM_Library_ServiceReference.Container)this.ContainerDataGridView.CurrentRow.DataBoundItem;
                string configText = Properties.Settings.Default.PalleteZpl;
                StaticClasses.ZebraRawPrinterHelper.ZebraPrint(configText, choosed.Container_BarCode, "", "", "", "", "", "");
            }

        }

        #endregion
    }

}