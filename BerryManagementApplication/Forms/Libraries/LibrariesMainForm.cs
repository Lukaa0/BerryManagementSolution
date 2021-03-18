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
    public partial class LibrariesMainForm : Form
    {
        private bool _IsActive = true;
        private bool _IsActive2 = true;
        List<BM_Library_ServiceReference.Container> _choosedContainer = new List<BM_Library_ServiceReference.Container>();
        List<BM_Library_ServiceReference.Container> _choosedRowContainer = new List<BM_Library_ServiceReference.Container>();
        private List<BM_Library_ServiceReference.Container> _newall = new List<BM_Library_ServiceReference.Container>();
        private int _RowIndex;
        private int _ColumnIndex;
        public LibrariesMainForm()
        {
            InitializeComponent();
            this.Text = "ცნობარების მართვის პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;
            Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            ActiveCheckBox.Checked = true;
        }
        public void ActivateTabPage(string name)
        {
            this.LibrariesTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.LibrariesTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.LibrariesTabControl, tabPageName);
        }
        #region Banks ბანკები
        private void BanksTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.BanksDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.BanksDataGridView.DataSource = serviceClient.SelectBanks(null, null, null,ref errorMessage);
            }
        }

        private void BankUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.Bank bank = (BM_Library_ServiceReference.Bank)this.BanksDataGridView.CurrentRow.DataBoundItem;
            if (bank != null)
            {
                BankEditForm form = new BankEditForm(bank);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.BanksDataGridView.CurrentRow.Index;
                    this.BanksTabPage_Enter(null, null);
                    this.BanksDataGridView.CurrentCell = this.BanksDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }

        private void BankAddButton_Click(object sender, EventArgs e)
        {
            BankEditForm form = new BankEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.BanksTabPage_Enter(null, null);
                DataGridViewRow row = this.BanksDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.Bank)l.DataBoundItem).Bank_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.BanksDataGridView.CurrentCell = this.BanksDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }
        #endregion

        #region Nationalities ნაციონალობა
        private void NationalitiesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.NationalitiesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.NationalitiesDataGridView.DataSource = serviceClient.GetNationalities(null, null, null,ref errorMessage);
            }
        }

        private void NationalitiesAddButton_Click(object sender, EventArgs e)
        {
            NationalityEditForm form = new NationalityEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.NationalitiesTabPage_Enter(null, null);
                DataGridViewRow row = this.NationalitiesDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.Nationality)l.DataBoundItem).Nationality_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.NationalitiesDataGridView.CurrentCell = this.NationalitiesDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }

        private void NationalitiesUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.Nationality nationality = (BM_Library_ServiceReference.Nationality)this.NationalitiesDataGridView.CurrentRow.DataBoundItem;
            if (nationality != null)
            {
                NationalityEditForm form = new NationalityEditForm(nationality);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.NationalitiesDataGridView.CurrentRow.Index;
                    this.NationalitiesTabPage_Enter(null, null);
                    this.NationalitiesDataGridView.CurrentCell = this.NationalitiesDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }
        #endregion Nationalities ნაციონალობა

        #region Citizenships მოქალაქეობა
        private void CitizenshipsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.CitizenshipsDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.CitizenshipsDataGridView.DataSource = serviceClient.GetCitizenships(null, null, null,ref errorMessage);
            }
        }

        private void CitizenshipUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.Citizenship citizenship = (BM_Library_ServiceReference.Citizenship)this.CitizenshipsDataGridView.CurrentRow.DataBoundItem;
            if (citizenship != null)
            {
                CitizenshipEditForm form = new CitizenshipEditForm(citizenship);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.CitizenshipsDataGridView.CurrentRow.Index;
                    this.CitizenshipsTabPage_Enter(null, null);
                    this.CitizenshipsDataGridView.CurrentCell = this.CitizenshipsDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }

       

        private void CitizenshipAddButton_Click(object sender, EventArgs e)
        {
            CitizenshipEditForm form = new CitizenshipEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.CitizenshipsTabPage_Enter(null, null);
                DataGridViewRow row = this.CitizenshipsDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.Citizenship)l.DataBoundItem).Citizenship_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.CitizenshipsDataGridView.CurrentCell = this.CitizenshipsDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }
        #endregion Citizenships მოქალაქეობა

        #region Containers კონტეინერები
        private void ContainersTabPage_Enter(object sender, EventArgs e)
        {

        }

        private void ContainersAddButton_Click(object sender, EventArgs e)
        {

        }

        private void ContainersUpdateButton_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region დოკუმენტის სახეები
        private void DocumentTypeTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.DocumentTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.DocumentTypesDataGridView.DataSource = serviceClient.GetDocumentTyped(null, null, ref errorMessage);
            }
        }

        private void DocumentTypeAddButton_Click(object sender, EventArgs e)
        {
            DocumentTypeEditForm form = new DocumentTypeEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.DocumentTypeTabPage_Enter(null, null);
                DataGridViewRow row = this.DocumentTypesDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.DocumentType)l.DataBoundItem).DocumentType_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.DocumentTypesDataGridView.CurrentCell = this.DocumentTypesDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }

        private void DocumentTypeUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.DocumentType documentType = (BM_Library_ServiceReference.DocumentType)this.DocumentTypesDataGridView.CurrentRow.DataBoundItem;
            if (documentType != null)
            {
                DocumentTypeEditForm form = new DocumentTypeEditForm(documentType);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.DocumentTypesDataGridView.CurrentRow.Index;
                    this.DocumentTypeTabPage_Enter(null, null);
                    this.DocumentTypesDataGridView.CurrentCell = this.DocumentTypesDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }
        #endregion

        #region PunishmentTypes სასჯელის სახეები
        private void PunishmentTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.PunishmentTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.PunishmentTypesDataGridView.DataSource = serviceClient.GetPunishmentTypes(null, null,ref errorMessage);
            }
        }
        #endregion

        #region LegalForms სამართლებრივი ფორმა

        private void LegalFormsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.LegalFormDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.LegalFormDataGridView.DataSource = serviceClient.GetLegalForms(null, null,null, ref errorMessage);
            }
        }

        private void LegalFormAddButton_Click(object sender, EventArgs e)
        {

            LegalFormEditForm form = new LegalFormEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.LegalFormsTabPage_Enter(null, null);
                DataGridViewRow row = this.LegalFormDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.LegalForm)l.DataBoundItem).LegalForm_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.LegalFormDataGridView.CurrentCell = this.LegalFormDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }

        private void LegalFormUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.LegalForm legalForm = (BM_Library_ServiceReference.LegalForm)this.LegalFormDataGridView.CurrentRow.DataBoundItem;
            if (legalForm != null)
            {
                LegalFormEditForm form = new LegalFormEditForm(legalForm);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.LegalFormDataGridView.CurrentRow.Index;
                    this.LegalFormsTabPage_Enter(null, null);
                    this.LegalFormDataGridView.CurrentCell = this.LegalFormDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }
        #endregion

        #region Gender სქესი
        private void GenderTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.GenderDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.GenderDataGridView.DataSource = serviceClient.GetGenderTypes(null, null, ref errorMessage);
            }
        }
        #endregion

        #region MaritalStatus ოჯახური მდგომარეობა
        private void MaritalStatusTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.MaritalStatusdataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.MaritalStatusdataGridView.DataSource = serviceClient.GetMaritalStatus(null, null, ref errorMessage);
            }
        }

        #endregion

        #region Breeds ჯიშები
        private void BreedsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.BreedsDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.BreedsDataGridView.DataSource = serviceClient.GetBreeds(null, null, ref errorMessage);
            }
        }

        private void BreedsAddButton_Click(object sender, EventArgs e)
        {
            BreedEditForm form = new BreedEditForm();
            if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.BreedsTabPage_Enter(null, null);
                DataGridViewRow row = this.BreedsDataGridView.Rows.Cast<DataGridViewRow>().Where(
                    l => ((BM_Library_ServiceReference.Breed)l.DataBoundItem).Breed_Id == form.Id).SingleOrDefault();
                if (row != null)
                {
                    this.BreedsDataGridView.CurrentCell = this.BreedsDataGridView.Rows[row.Index].Cells[0];
                }
            }
        }

        private void BreedsUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Library_ServiceReference.Breed breed = (BM_Library_ServiceReference.Breed)this.BreedsDataGridView.CurrentRow.DataBoundItem;
            if (breed != null)
            {
                BreedEditForm form = new BreedEditForm(breed);
                if (form.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    int rowNumber = this.BreedsDataGridView.CurrentRow.Index;
                    this.BreedsTabPage_Enter(null, null);
                    this.BreedsDataGridView.CurrentCell = this.BreedsDataGridView.Rows[rowNumber].Cells[0];
                }
            }
        }

        #endregion


        #region ContainerTypes კონტეინერის სახეები
        private void ContainerTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.ContainerTypesDataGridView.AutoGenerateColumns = false;
            this.ContainerDataGridView.AutoGenerateColumns = false;
            List<BM_Library_ServiceReference.tf_ContainerTypes_Result> ContainerType = null;
            try
            {
                using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    ContainerType = serviceClient.GetContainerTypes(null, null, null, this._IsActive, ref errorMessage);

                    var test = serviceClient.GetPallete(ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
                this.ContainerTypesDataGridView.DataSource = ContainerType;


                /*SideType კომბო*/
                this.TypeComboBox.DataSource = ContainerType;
                this.TypeComboBox.DisplayMember = "ContainerType_Name";
                this.TypeComboBox.ValueMember = "ContainerType_Id";
                this.TypeComboBox.SelectedIndex = -1;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           
            checkBox1.Checked = true;



        }
        #endregion

        #region EmployeeTypes თანამშრომლის სახეები
        private void EmployeeTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.EmployeeTypesDataGridView.AutoGenerateColumns = false;
           
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.EmployeeTypesDataGridView.DataSource = serviceClient.GetEmployeeTypes(null, null, ref errorMessage);
            }
        }
        #endregion

        #region GetBalanceSheetTypes საბალანსო ანგარიში
        private void GetBalanceSheetTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.GetBalanceSheetTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.GetBalanceSheetTypesDataGridView.DataSource = serviceClient.GetBalanceSheetTypes(null, null, ref errorMessage);
            }
        }
        #endregion

        #region LegalStatuseTypes იურიდიული ფორმა
        private void LegalStatuseTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.LegalStatuseTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.LegalStatuseTypesDataGridView.DataSource = serviceClient.GetLegalStatuseTypes(null, null,null, ref errorMessage);
            }
        }
        #endregion

        #region PointTypes ლოკაციის სახეები
        private void PointTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.PointTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.PointTypesDataGridView.DataSource = serviceClient.GetPointTypes(null, null,null, ref errorMessage);
            }
        }

        #endregion

        #region ProductQualityes პროდუქტის ხარისხი
        private void ProductQualityesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.ProductQualityesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.ProductQualityesDataGridView.DataSource = serviceClient.GetProductQualityes(null, null, ref errorMessage);
            }
        }
        #endregion

        #region SalaryTypes ხელფასები
        private void SalaryTypesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.SalaryTypesDataGridView.AutoGenerateColumns = false;
            using (BM_Library_ServiceReference.BM_Library_ServiceClient serviceClient = new BM_Library_ServiceReference.BM_Library_ServiceClient())
            {
                this.SalaryTypesDataGridView.DataSource = serviceClient.GetSalaryTypes(null, null, ref errorMessage);
            }
        }
        #endregion



        private void ContainerTypesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.ContainerDataGridView.DataSource = null;

            List<BM_Library_ServiceReference.Container> CompanyLIst = null;
            string errorMessage = string.Empty;

            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {

                    BM_Library_ServiceReference.tf_ContainerTypes_Result CompanyType = (BM_Library_ServiceReference.tf_ContainerTypes_Result)this.ContainerTypesDataGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Library_ServiceReference.BM_Library_ServiceClient service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                    {

                        CompanyLIst = service.SelectContainers(null, CompanyType.ContainerType_Id, this._IsActive2, ref errorMessage);

                    }
                    this.ContainerDataGridView.DataSource = CompanyLIst;

                   

                }
                else
                {
                    if (this.ContainerTypesDataGridView.CurrentRow != null)
                    {
                        BM_Library_ServiceReference.tf_ContainerTypes_Result CompanyType = (BM_Library_ServiceReference.tf_ContainerTypes_Result)this.ContainerTypesDataGridView.CurrentRow.DataBoundItem;

                        using (BM_Library_ServiceReference.BM_Library_ServiceClient service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                        {

                            CompanyLIst = service.SelectContainers(null, CompanyType.ContainerType_Id, this._IsActive2, ref errorMessage);

                        }
                        this.ContainerDataGridView.DataSource = CompanyLIst;



                    }
                }
                this._RowIndex = e.RowIndex;
                this._ColumnIndex = e.ColumnIndex;

                BM_Library_ServiceReference.Container Container = new BM_Library_ServiceReference.Container();
                _choosedRowContainer = new List<BM_Library_ServiceReference.Container>();
                foreach (DataGridViewRow row in ContainerDataGridView.Rows)
                {
                    row.Selected = true;
                    Container = (BM_Library_ServiceReference.Container)row.DataBoundItem;
                    _choosedRowContainer.Add(Container);
                    break;
                    
                }

            }



        }

        private void GeneraitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TypeComboBox.SelectedValue.ToString()))
                {
                    throw new Exception("არ არის მითითებული ყუთის ტიპი!");
                }
                string errorMessage = null;
                using (BM_Library_ServiceReference.BM_Library_ServiceClient service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    var list = service.CreateContainers(TypeComboBox.SelectedValue.ToString(), Decimal.ToInt32(CountNumericUpDown.Value), ref errorMessage);
                }
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    throw new Exception(errorMessage);
                }
                this.ContainerTypesDataGridView_RowEnter(this.ContainerTypesDataGridView, new DataGridViewCellEventArgs(this._ColumnIndex, this._RowIndex));
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: GeneraitButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ActiveCheckBox.Checked)
            {
                this._IsActive = true;

                this.ContainerTypesTabPage_Enter(this.ContainerTypesTabPage, new EventArgs());
            }
            else
            {
                this._IsActive = false;
                this.ContainerTypesTabPage_Enter(this.ContainerTypesTabPage, new EventArgs());
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            
            string configText = Properties.Settings.Default.ContainerLabelTemplate;

            if(this._choosedContainer.Count != 0)
            {
                foreach (BM_Library_ServiceReference.Container con in this._choosedContainer)
                {
                    Classes.ZebraRawPrinterHelper.ZebraPrint(configText, con.Container_BarCode, "", "", "", "", "", "");

                }
            }
            else
            {
                foreach (BM_Library_ServiceReference.Container con in this._choosedRowContainer)
                {
                    Classes.ZebraRawPrinterHelper.ZebraPrint(configText, con.Container_BarCode, "", "", "", "", "", "");
                }
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
                    }

        private void ContainerDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _choosedContainer = new List<BM_Library_ServiceReference.Container>();
            BM_Library_ServiceReference.Container Container = new BM_Library_ServiceReference.Container();
            foreach (DataGridViewRow gridrow in this.ContainerDataGridView.Rows)
            {
                if (gridrow.Selected)
                {
                    Container = (BM_Library_ServiceReference.Container)gridrow.DataBoundItem;
                    //არჩეული რიგის ლისტში დამატება
                    _choosedContainer.Add(Container);

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this._IsActive2 = true;

                
                this.ContainerTypesDataGridView_RowEnter(this.ContainerTypesDataGridView,new DataGridViewCellEventArgs(this._ColumnIndex, this._RowIndex));
            }
            else
            {
                this._IsActive2 = false;
                this.ContainerTypesDataGridView_RowEnter(this.ContainerTypesDataGridView, new DataGridViewCellEventArgs(this._ColumnIndex, this._RowIndex));
            }
        }

        private void SortingButton_Click(object sender, EventArgs e)
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

            BM_Library_ServiceReference.Container Container = new BM_Library_ServiceReference.Container();
            _choosedRowContainer = new List<BM_Library_ServiceReference.Container>();
            foreach (DataGridViewRow row in ContainerDataGridView.Rows)
            {
                row.Selected = true;
                Container = (BM_Library_ServiceReference.Container)row.DataBoundItem;
                _choosedRowContainer.Add(Container);
                break;

            }


        }

        private void PackedPaletsButton_Click(object sender, EventArgs e)
        {
            PackedPalletesForm form = new PackedPalletesForm();
            form.Show();
        }
    }
}
