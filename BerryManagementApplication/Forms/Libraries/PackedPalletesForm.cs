using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Libraries
{
    public partial class PackedPalletesForm : Form
    {
        public PackedPalletesForm()
        {
            InitializeComponent();
            PalleteDataGridView.MultiSelect = false;
            fillGrid();
        }
        private void fillGrid()
        {
            try
            {
                string errorMessage = null;
                this.PalleteDataGridView.AutoGenerateColumns = false;
                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    this.PalleteDataGridView.DataSource = serviceClient.GetContainerWeightsByChars("CB", null, null, ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (this.PalleteDataGridView.RowCount > 0)
            {
                BM_Operation_ServiceReference.PalleteModel containerWeight = 
                    (BM_Operation_ServiceReference.PalleteModel)this.PalleteDataGridView.CurrentRow.DataBoundItem;
                List<BM_Library_ServiceReference.RS_ProductModel> products = (List < BM_Library_ServiceReference.RS_ProductModel > )this.BreedsDataGridView.DataSource;
                int boxCount = 0;
                List<Classes.PalleteLabel.Product> productItems = new List<Classes.PalleteLabel.Product>();
                foreach (BM_Library_ServiceReference.RS_ProductModel product in products)
                {
                    boxCount = boxCount + product.Product_ContainerCount;
                    Classes.PalleteLabel.Product productItem = new Classes.PalleteLabel.Product();
                    productItem.ProductBoxCount = product.Product_ContainerCount.ToString();
                    productItem.ProductName = product.Product_Breed_Name;
                    productItem.ProductWeight = product.Product_WeightsSum.ToString();
                    productItems.Add(productItem);
                }
                Classes.PalleteLabel palleteLabel = new Classes.PalleteLabel()
                {
                    PalleteBarcode = containerWeight.ContainerWeight_Container_BarCode,
                    PalleteBoxCount = boxCount.ToString(),
                    PalleteDatetime = containerWeight.ContainerWeight_DateTime.ToString(@"MM\/dd\/yyyy hh:mm"),
                    PalleteWeightGross  = containerWeight.ContainerWeight_Gross.ToString(),
                    PalleteWeightNet = containerWeight.ContainerWeight_Net.ToString(),
                    PalleteProducts = productItems
                };
                List<Classes.PalleteLabel> palleteLabels = new List<Classes.PalleteLabel>();
                palleteLabels.Add(palleteLabel);
                Report.TemplatesViewerForm templatesViewerForm = new Report.TemplatesViewerForm(palleteLabels);
                templatesViewerForm.ShowDialog(this);
            }
        }

        private void PalleteDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int productOwnerStatus = 1;
            try
            {
                this.BreedsDataGridView.DataSource = null;
                this.BreedsDataGridView.AutoGenerateColumns = false;
                string errorMessage = string.Empty;
                List<BM_Library_ServiceReference.RS_ProductModel> esd = null;
                if (sender != null)
                {
                    if (e.RowIndex >= 0)
                    {
                        BM_Operation_ServiceReference.PalleteModel conWeight = (BM_Operation_ServiceReference.PalleteModel)this.PalleteDataGridView.Rows[e.RowIndex].DataBoundItem;

                        this.PalleteDataGridView.AutoGenerateColumns = false;
                        using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                        {
                            esd = serviceClient.GetRS_ProductModelByContainers(conWeight.ContainerWeight_Container_BarCode, productOwnerStatus, ref errorMessage);
                        }
                        if (!string.IsNullOrEmpty(errorMessage))
                            throw new Exception(errorMessage);

                        this.BreedsDataGridView.DataSource = esd;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
