using BerryManagementApplication.Enums;
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

namespace BerryManagementApplication.Forms.Structure
{
    public partial class StructureMainForm : Form
    {

        private String _rowName;
        private long _rowId;
        private StructureMainForm frm;
        List<BM_Structure_ServiceReference.Row> _choosedRow = new List<BM_Structure_ServiceReference.Row>();

        private List<BM_Employee_ServiceReference.PersonPostModel> _choosedPersons = new List<BM_Employee_ServiceReference.PersonPostModel>();
        private List<BM_Employee_ServiceReference.PersonPostModel> _choosedPerson = new List<BM_Employee_ServiceReference.PersonPostModel>();
        private BM_Employee_ServiceReference.PersonPostModel person = new BM_Employee_ServiceReference.PersonPostModel();

        List<BM_Structure_ServiceReference.PointsModel> _choosedRowPoints = new List<BM_Structure_ServiceReference.PointsModel>();
        List<BM_Structure_ServiceReference.PointsModel> _choosedPoint = new List<BM_Structure_ServiceReference.PointsModel>();


        public StructureMainForm()
        {
            InitializeComponent();
            this.Text = "უსაფრთხოების მართვის პანელი";
            this.StartPosition = FormStartPosition.CenterScreen;
            if (Program.User.User_Role_ID == 13)
            {
                Classes.PermissionManagement.ManageControlsAccessByUserPermissions(this, Program.userPermissions.UserPermisions);
            }

            frm = this;
        }

        public void ActivateTabPage(string name)
        {
            this.StructureTabControl.TabPages.Remove(this.tabPage1);
            string tabPageName = name.Remove(name.IndexOf("ToolStripMenuItem")) + "TabPage";
            tabPageName = tabPageName[0].ToString().ToUpper() + tabPageName.Remove(0, 1);
            this.StructureTabControl.SelectedIndex = Classes.FindControl.GetTabPageIndex(this.StructureTabControl, tabPageName);
        }

      

        


        #region ბრიგადა Brigade
        private void BrigadesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.BrigadesDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.BrigadesDataGridView.DataSource = serviceClient.GetBrigades(null,null, ref errorMessage);
            }

            person = (BM_Employee_ServiceReference.PersonPostModel)this.PersonBrigadeDgv.CurrentRow.DataBoundItem;
            _choosedPerson.Add(person);

        }

        private void BrigadesDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.PersonBrigadeDgv.DataSource = null;

            
            List<BM_Employee_ServiceReference.PersonPostModel> personPostModel = null;
            string errorMessage = string.Empty;
            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {
                    BM_Structure_ServiceReference.Brigade brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadesDataGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        personPostModel = service.GetPersonPostsByBrigadeId(brigade.Brigade_Id, ref errorMessage);
                    }

                    this.PersonBrigadeDgv.AutoGenerateColumns = false;


                    this.PersonBrigadeDgv.DataSource = personPostModel;
                    
                }
                else
                {
                    if (this.PersonBrigadeDgv.CurrentRow != null)
                    {
                        BM_Structure_ServiceReference.Brigade brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadesDataGridView.Rows[e.RowIndex].DataBoundItem;

                        using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                        {
                            personPostModel = service.GetPersonPostsByBrigadeId(brigade.Brigade_Id, ref errorMessage);
                        }

                        this.PersonBrigadeDgv.DataSource = personPostModel;
                    }
                }

            }

        }


        private void BrigadesDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.PersonBrigadeDgv.DataSource = null;

            

            List<BM_Employee_ServiceReference.PersonPostModel> personPostModel = null;

            string errorMessage = string.Empty;
            try
            {
                BM_Structure_ServiceReference.Brigade brigade = (BM_Structure_ServiceReference.Brigade)this.BrigadesDataGridView.CurrentRow.DataBoundItem;

                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient service = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    personPostModel = service.GetPersonPostsByBrigadeId(brigade.Brigade_Id, ref errorMessage);
                }

                this.PersonBrigadeDgv.AutoGenerateColumns = false;


                this.PersonBrigadeDgv.DataSource = personPostModel;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadesDataGridView_CellClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void BrigadeAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Brigade brigadee = new BM_Structure_ServiceReference.Brigade();
            Forms.Structure.BrigadeEditForm brigadeEditForm = null;
            try
            {
                /* რედაქტირების ფორმა */
                brigadeEditForm = new BrigadeEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,
                                                                      brigadee);
                switch (brigadeEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                        
                        this.BrigadesTabPage_Enter(this.BrigadesTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
                //
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadeAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void BrigadUpdateButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Brigade brigadee = new BM_Structure_ServiceReference.Brigade();
            Forms.Structure.BrigadeEditForm brigadeEditForm = null;

           
            try
            {
               
                

                /* მიმდინარე ობიექტი */
                brigadee = (BM_Structure_ServiceReference.Brigade)this.BrigadesDataGridView.CurrentRow.DataBoundItem;
                if (brigadee != null)
                {


                    /* რედაქტირების ფორმა */
                    brigadeEditForm = new BrigadeEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          brigadee);
                    switch (brigadeEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                           
                            this.BrigadesTabPage_Enter(this.BrigadesTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: BrigadUpdateButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void BrigadeDeleteButton_Click(object sender, EventArgs e)
        {
            
            BM_Structure_ServiceReference.Brigade brigadeDataModel = null;
            Forms.Structure.BrigadeEditForm brigadeEditForm = null;
            string EmployeeFullName = System.String.Empty;

            try
            {

                /* მიმდინარე ობიექტი */
                brigadeDataModel = (BM_Structure_ServiceReference.Brigade)this.BrigadesDataGridView.CurrentRow.DataBoundItem;

                /* რედაქტირების ფორმა */
                brigadeEditForm = new BrigadeEditForm(DataChangeType.Delete,ActionMode.WriteAndReturnData,brigadeDataModel);
                    switch (brigadeEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                           
                            this.BrigadesTabPage_Enter(this.BrigadesTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
              
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


    private void BrigadesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.BrigadeAddButton.Enabled = true;
                this.BrigadUpdateButton.Enabled = (this.BrigadesDataGridView.RowCount > 0);
                this.BrigadeDeleteButton.Enabled = (this.BrigadesDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void BrigadesDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.BrigadeAddButton.Enabled = true;
                this.BrigadUpdateButton.Enabled = (this.BrigadesDataGridView.RowCount > 0);
                this.BrigadeDeleteButton.Enabled = (this.BrigadesDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void BrigadesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.BrigadUpdateButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonDocumentsDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion

        #region მანქანა

        private void CarsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.CarDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.CarDataGridView.DataSource = serviceClient.GetCar(null, ref errorMessage);
            }
        }

        private void CarAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Car Caree = new BM_Structure_ServiceReference.Car();
            Forms.Structure.CarEditForm carEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                carEditForm = new CarEditForm(DataChangeType.Insert,ActionMode.WriteAndReturnData,Caree);
                switch (carEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.CarsTabPage_Enter(this.CarsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        
    }

        private void CarEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Car caree = new BM_Structure_ServiceReference.Car();
            BM_Structure_ServiceReference.CarModel carModel = new BM_Structure_ServiceReference.CarModel();
            Forms.Structure.CarEditForm carEditForm = null;


            try
            {

                /* მიმდინარე ობიექტი */
                carModel = (BM_Structure_ServiceReference.CarModel)this.CarDataGridView.CurrentRow.DataBoundItem;
                if (carModel != null)
                {
                    caree = new BM_Structure_ServiceReference.Car()
                    {
                        Car_Id = carModel.Car_Id,
                        Car_Model=carModel.Car_Model,
                        Car_Number=carModel.Car_Number,
                        Car_SideType_Id=carModel.Car_SideType_Id

                    };


                    /* რედაქტირების ფორმა */
                    carEditForm = new CarEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          caree);
                    switch (carEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CarsTabPage_Enter(this.CarsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CarModel carDataModel = null;
            BM_Structure_ServiceReference.Car caree = null;
            Forms.Structure.CarEditForm carEditForm = null;
            string EmployeeFullName = System.String.Empty;

            try
            {

                /* მიმდინარე ობიექტი */
                carDataModel = (BM_Structure_ServiceReference.CarModel)this.CarDataGridView.CurrentRow.DataBoundItem;
                if (carDataModel != null)
                {
                    caree = new BM_Structure_ServiceReference.Car()
                    {
                        Car_Id=carDataModel.Car_Id,
                        Car_Model=carDataModel.Car_Model,
                        Car_Number=carDataModel.Car_Number,
                        Car_SideType_Id=carDataModel.Car_SideType_Id
                    };
                        /* რედაქტირების ფორმა */
                        carEditForm = new CarEditForm(DataChangeType.Delete, ActionMode.WriteAndReturnData, caree);
                    switch (carEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CarsTabPage_Enter(this.CarsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private void CarDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.CarEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.CarAddButton.Enabled = true;
                this.CarEditButton.Enabled = (this.CarDataGridView.RowCount > 0);
                this.CarDeleteButton.Enabled = (this.CarDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.CarAddButton.Enabled = true;
                this.CarEditButton.Enabled = (this.CarDataGridView.RowCount > 0);
                this.CarDeleteButton.Enabled = (this.CarDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion

        #region მძღოლები
        private void CarDriversTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.CarDriversDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.CarDriversDataGridView.DataSource = serviceClient.GetCarDrivers(null, ref errorMessage);
            }
        }
        private void CarDriverAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CarDriver CarDriver = new BM_Structure_ServiceReference.CarDriver();
            Forms.Structure.CarDriverEditForm CarDriverEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                CarDriverEditForm = new CarDriverEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,

                                                                      CarDriver);
                switch (CarDriverEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.CarDriversTabPage_Enter(this.CarDriversTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriverAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void CarDriverEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CarDriver CarDriver = new BM_Structure_ServiceReference.CarDriver();
            BM_Structure_ServiceReference.CarDriversModel carDriversModel = new BM_Structure_ServiceReference.CarDriversModel();
            
            Forms.Structure.CarDriverEditForm CarDrivwrEditor = null;


            try
            {



                /* მიმდინარე ობიექტი */
                carDriversModel = (BM_Structure_ServiceReference.CarDriversModel)this.CarDriversDataGridView.CurrentRow.DataBoundItem;
                if (carDriversModel != null)
                {
                    CarDriver = new BM_Structure_ServiceReference.CarDriver()
                    {
                        CarDriver_Id = carDriversModel.CarDriver_Id,
                        CarDriver_Car_Id = carDriversModel.CarDriver_Car_Id,
                        CarDriver_PersonPost_Id = carDriversModel.CarDriver_PersonPost_Id,
                        CarDriver_EndDate = carDriversModel.CarDriver_EndDate,
                        CarDriver_StartDate = carDriversModel.CarDriver_StartDate,
                        CarDriver_Person_Id = carDriversModel.CarDriver_Person_Id

                    };


                    /* რედაქტირების ფორმა */
                    CarDrivwrEditor = new CarDriverEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          CarDriver);
                    switch (CarDrivwrEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CarDriversTabPage_Enter(this.CarDriversTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriverEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDriverDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CarDriver CarDriver = new BM_Structure_ServiceReference.CarDriver();
            BM_Structure_ServiceReference.CarDriversModel CarDriverModel = new BM_Structure_ServiceReference.CarDriversModel();
            Forms.Structure.CarDriverEditForm CarDrivwrEditor = null;


            try
            {



                /* მიმდინარე ობიექტი */
                CarDriverModel = (BM_Structure_ServiceReference.CarDriversModel)this.CarDriversDataGridView.CurrentRow.DataBoundItem;
                if (CarDriverModel != null)
                {
                    CarDriver = new BM_Structure_ServiceReference.CarDriver()
                    {
                        CarDriver_Id = CarDriverModel.CarDriver_Id,
                        CarDriver_Car_Id = CarDriverModel.CarDriver_Car_Id,
                        CarDriver_PersonPost_Id = CarDriverModel.CarDriver_PersonPost_Id,
                        CarDriver_EndDate = CarDriverModel.CarDriver_EndDate,
                        CarDriver_StartDate = CarDriverModel.CarDriver_StartDate,
                        CarDriver_Person_Id = CarDriverModel.CarDriver_Person_Id

                    };


                    /* რედაქტირების ფორმა */
                    CarDrivwrEditor = new CarDriverEditForm(DataChangeType.Delete,
                                                                          ActionMode.WriteAndReturnData,
                                                                          CarDriver);
                    switch (CarDrivwrEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CarDriversTabPage_Enter(this.CarDriversTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriverEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


        private void CarDriversDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.CarDriverEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDriversDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.CarDriverAddButton.Enabled = true;
                this.CarDriverEditButton.Enabled = (this.CarDriversDataGridView.RowCount > 0);
                this.CarDriverDeleteButton.Enabled = (this.CarDriversDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CarDriversDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.CarDriverAddButton.Enabled = true;
                this.CarDriverEditButton.Enabled = (this.CarDriversDataGridView.RowCount > 0);
                this.CarDriverDeleteButton.Enabled = (this.CarDriversDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarDriversDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        #endregion

        #region კომპანიის მანქანა

        private void CompanyCarsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.CompanyCarsDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.CompanyCarsDataGridView.DataSource = serviceClient.GetCompanyCar(null, ref errorMessage);
            }
        }

        private void CompanyCarAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CompanyCar companyCar = new BM_Structure_ServiceReference.CompanyCar();
            Forms.Structure.CompanyCarEditForm companyCarEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                companyCarEditForm = new CompanyCarEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,

                                                                      companyCar);
                switch (companyCarEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.CompanyCarsTabPage_Enter(this.CompanyCarsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CarAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyCarEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CompanyCar companyCar = new BM_Structure_ServiceReference.CompanyCar();
            BM_Structure_ServiceReference.CompanyCarModel companyCarModel = new BM_Structure_ServiceReference.CompanyCarModel();
            Forms.Structure.CompanyCarEditForm companyCarEditForm = null;


            try
            {



                /* მიმდინარე ობიექტი */
                companyCarModel = (BM_Structure_ServiceReference.CompanyCarModel)this.CompanyCarsDataGridView.CurrentRow.DataBoundItem;
                if (companyCarModel != null)
                {
                    companyCar = new BM_Structure_ServiceReference.CompanyCar()
                    {
                        CompanyCar_Id = companyCarModel.CompanyCar_Id,
                        CompanyCar_Car_Id = companyCarModel.CompanyCar_Car_Id,
                        CompanyCar_Company_Id = companyCarModel.CompanyCar_Company_Id,
                        CompanyCar_EndDate = companyCarModel.CompanyCar_EndDate,
                        CompanyCar_StartDate= companyCarModel.CompanyCar_StartDate

                    };


                    /* რედაქტირების ფორმა */
                    companyCarEditForm = new CompanyCarEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          companyCar);
                    switch (companyCarEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CompanyCarsTabPage_Enter(this.CompanyCarsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyCarEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyCarDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.CompanyCar companyCar = new BM_Structure_ServiceReference.CompanyCar();
            BM_Structure_ServiceReference.CompanyCarModel companyCarModel = new BM_Structure_ServiceReference.CompanyCarModel();
            Forms.Structure.CompanyCarEditForm companyCarEditForm = null;


            try
            {



                /* მიმდინარე ობიექტი */
                companyCarModel = (BM_Structure_ServiceReference.CompanyCarModel)this.CompanyCarsDataGridView.CurrentRow.DataBoundItem;
                if (companyCarModel != null)
                {
                    companyCar = new BM_Structure_ServiceReference.CompanyCar()
                    {
                        CompanyCar_Id = companyCarModel.CompanyCar_Id,
                        CompanyCar_Car_Id = companyCarModel.CompanyCar_Car_Id,
                        CompanyCar_Company_Id = companyCarModel.CompanyCar_Company_Id,
                        CompanyCar_EndDate = companyCarModel.CompanyCar_EndDate,
                        CompanyCar_StartDate = companyCarModel.CompanyCar_StartDate

                    };
                    /* რედაქტირების ფორმა */
                    companyCarEditForm = new CompanyCarEditForm(DataChangeType.Delete, ActionMode.WriteAndReturnData, companyCar);
                    switch (companyCarEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.CompanyCarsTabPage_Enter(this.CompanyCarsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyCarDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }


        private void CompanyCarsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.CompanyCarEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyCarsDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyCarsDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.CompanyCarAddButton.Enabled = true;
                this.CompanyCarEditButton.Enabled = (this.CompanyCarsDataGridView.RowCount > 0);
                this.CompanyCarDeleteButton.Enabled = (this.CompanyCarsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyCarsDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyCarsDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.CompanyCarAddButton.Enabled = true;
                this.CompanyCarEditButton.Enabled = (this.CompanyCarsDataGridView.RowCount > 0);
                this.CompanyCarDeleteButton.Enabled = (this.CompanyCarsDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyCarsDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion

        #region შიდა კომპანიები

        private void InsideCompanyTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.InsideCompanyDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.InsideCompanyDataGridView.DataSource = serviceClient.GetCompany(null, 1,ref errorMessage);
            }
        }

        private void InsideCompanyAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            Forms.Structure.CompanyEditForm CompanyEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                CompanyEditForm = new CompanyEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,

                                                                      Company, 1);
                switch (CompanyEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.InsideCompanyTabPage_Enter(this.InsideCompanyTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void InsideCompanyEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            BM_Structure_ServiceReference.CompanyeModel CompanyModel = new BM_Structure_ServiceReference.CompanyeModel();
            Forms.Structure.CompanyEditForm CompanyEditor = null;


            try
            {

                /* მიმდინარე ობიექტი */
                CompanyModel = (BM_Structure_ServiceReference.CompanyeModel)this.InsideCompanyDataGridView.CurrentRow.DataBoundItem;
                if (CompanyModel != null)
                {
                    Company = new BM_Structure_ServiceReference.Companye()
                    {
                        Company_Id = CompanyModel.Company_Id,
                        Company_Identity = CompanyModel.Company_Identity,
                        Company_CitizenshipId = CompanyModel.Company_CitizenshipId,
                        Company_Name = CompanyModel.Company_Name,
                        Company_Address1 = CompanyModel.Company_Address1,
                        Company_Address2 = CompanyModel.Company_Address2,
                        Company_Phone1 = CompanyModel.Company_Phone1,
                        Company_Phone2 = CompanyModel.Company_Phone2,
                        Company_SideType_Id = CompanyModel.Company_SideType_Id,
                        Company_IBAN = CompanyModel.Company_IBAN,
                        Company_RS_Password = CompanyModel.Company_RS_Password,
                        Company_RS_UserId = CompanyModel.Company_RS_UserId


                    };

                    /* რედაქტირების ფორმა */
                    CompanyEditor = new CompanyEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          Company, 1);
                    switch (CompanyEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.InsideCompanyTabPage_Enter(this.InsideCompanyTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void InsideCompanyDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            BM_Structure_ServiceReference.CompanyeModel CompanyModel = new BM_Structure_ServiceReference.CompanyeModel();
            Forms.Structure.CompanyEditForm CompanyEditor = null;


            try
            {



                /* მიმდინარე ობიექტი */
                CompanyModel = (BM_Structure_ServiceReference.CompanyeModel)this.InsideCompanyDataGridView.CurrentRow.DataBoundItem;
                if (CompanyModel != null)
                {
                    Company = new BM_Structure_ServiceReference.Companye()
                    {
                        Company_Id = CompanyModel.Company_Id,
                        Company_Identity = CompanyModel.Company_Identity,
                        Company_CitizenshipId = CompanyModel.Company_CitizenshipId,
                        Company_Name = CompanyModel.Company_Name,
                        Company_Address1 = CompanyModel.Company_Address1,
                        Company_Address2 = CompanyModel.Company_Address2,
                        Company_Phone1 = CompanyModel.Company_Phone1,
                        Company_Phone2 = CompanyModel.Company_Phone2,
                        Company_SideType_Id = CompanyModel.Company_SideType_Id
                    };



                    /* რედაქტირების ფორმა */
                    CompanyEditor = new CompanyEditForm(DataChangeType.Delete,
                                                                          ActionMode.WriteAndReturnData,
                                                                          Company, 1);
                    switch (CompanyEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.InsideCompanyTabPage_Enter(this.InsideCompanyTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void InsideCompanyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.InsideCompanyEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyRowsDsataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyRowsDsataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.InsideCompanyAddButton.Enabled = true;
                this.InsideCompanyEditButton.Enabled = (this.InsideCompanyDataGridView.RowCount > 0);
                this.InsideCompanyDeleteButton.Enabled = (this.InsideCompanyDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyRowsDsataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CompanyRowsDsataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.InsideCompanyAddButton.Enabled = true;
                this.InsideCompanyEditButton.Enabled = (this.InsideCompanyDataGridView.RowCount > 0);
                this.InsideCompanyDeleteButton.Enabled = (this.InsideCompanyDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyRowsDsataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion

        #region Rows

        private void RowsTabPage_Enter(object sender, EventArgs e)
        {
            try
            {
                string errorMessage = null;
                this.RowDataGridView.AutoGenerateColumns = false;

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    this.RowDataGridView.DataSource = serviceClient.GetRows(null, null, ref errorMessage).OrderBy(r => r.Row_Barkode).ToList();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RowAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel= new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
            Forms.Structure.RowsEditForm RowEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                RowEditForm = new RowsEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData,Row,companyRowsModel,rowBreedsModel,true);
                switch (RowEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void RowEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();

            Forms.Structure.RowsEditForm RowEditor = null;


            try
            {
                /* მიმდინარე ობიექტი */
                Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;
                if (Row != null)
                {
                    //Row = new BM_Structure_ServiceReference.Row()
                    //{
                    //    Row_Id = Row.Row_Id,
                    //    Row_Barkode = Row.Row_Barkode,
                    //    Row_Number = Row.Row_Number,
                    //    Row_Subrow_Number = Row.Row_Subrow_Number,
                    //    Sector_Number = Row.Sector_Number

                    //};

                    companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                    if (RowBreeddataGridView.Rows.Count == 0)
                    {

                        rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
                    }
                    else
                    {
                        rowBreedsModel = (BM_Structure_ServiceReference.RowBreedsModel)this.RowBreeddataGridView.CurrentRow.DataBoundItem;

                    }

                    /* რედაქტირების ფორმა */
                    RowEditor = new RowsEditForm(DataChangeType.Update,ActionMode.WriteAndReturnData, Row,companyRowsModel,rowBreedsModel,true);
                    switch (RowEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowDeleteButton_Click(object sender, EventArgs e)
        {
            
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();

            Forms.Structure.RowsEditForm RowEditor = null;

            try
            {

                /* მიმდინარე ობიექტი */
                Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;
                if (Row != null)
                {
                   
                    //Row = new BM_Structure_ServiceReference.Row()
                    //{
                    //    Row_Id = Row.Row_Id,
                    //    Row_Barkode = Row.Row_Barkode,
                    //    Row_Number = Row.Row_Number,
                    //    Row_Subrow_Number = Row.Row_Subrow_Number,
                    //    Sector_Number = Row.Sector_Number
                    //};
                    companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                    if (RowBreeddataGridView.Rows.Count == 0)
                    {

                        rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
                    }
                    else
                    {
                        rowBreedsModel = (BM_Structure_ServiceReference.RowBreedsModel)this.RowBreeddataGridView.CurrentRow.DataBoundItem;

                    }

                    /* რედაქტირების ფორმა */
                    RowEditor = new RowsEditForm(DataChangeType.Delete,ActionMode.WriteAndReturnData, Row, companyRowsModel, rowBreedsModel,null);
                    switch (RowEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */
                            this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowsDsataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.RowEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowsDsataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowsDsataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.RowAddButton.Enabled = true;
                this.RowEditButton.Enabled = (this.RowDataGridView.RowCount > 0);
                this.RowDeleteButton.Enabled = (this.RowDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowsDsataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowsDsataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.RowAddButton.Enabled = true;
                this.RowEditButton.Enabled = (this.RowDataGridView.RowCount > 0);
                this.RowDeleteButton.Enabled = (this.RowDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowsDsataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

       
        private void RowDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CompanyRowdataGridView.DataSource = null;
            this.RowBreeddataGridView.DataSource = null;


            this.CompanyRowdataGridView.AutoGenerateColumns = false;
            this.RowBreeddataGridView.DataSource = null;

            List<BM_Structure_ServiceReference.RowBreedsModel> rowBreedsModel = null;
            List<BM_Structure_ServiceReference.CompanyRowsModel> companyRowsModels = null;
            string errorMessage = string.Empty;
            try
            {
                BM_Structure_ServiceReference.Row Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    rowBreedsModel = service.GetRowBreeds(null, Row.Row_Id, null, ref errorMessage);
                    companyRowsModels = service.GetCompanyRow(null, null, Row.Row_Id, ref errorMessage);

                }
                this.CompanyRowdataGridView.DataSource = companyRowsModels;
                this.RowBreeddataGridView.DataSource = rowBreedsModel;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowDataGridView_CellContentClick", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void RowDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.CompanyRowdataGridView.DataSource = null;
            this.RowBreeddataGridView.DataSource = null;
            List<BM_Structure_ServiceReference.RowBreedsModel> rowBreedsModel = null;
            List<BM_Structure_ServiceReference.CompanyRowsModel> companyRowsModels = null;
            string errorMessage = string.Empty;
            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {
                    BM_Structure_ServiceReference.Row Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        rowBreedsModel = service.GetRowBreeds(null, Row.Row_Id, null, ref errorMessage);
                        companyRowsModels = service.GetCompanyRow(null, null, Row.Row_Id, ref errorMessage);

                    }
                    this.CompanyRowdataGridView.AutoGenerateColumns = false;
                    this.RowBreeddataGridView.AutoGenerateColumns = false;
                    this.CompanyRowdataGridView.DataSource = companyRowsModels;
                    this.RowBreeddataGridView.DataSource = rowBreedsModel;
                }
                else
                {
                    if (this.RowDataGridView.CurrentRow != null)
                    {
                        BM_Structure_ServiceReference.Row Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;

                        using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                        {
                            rowBreedsModel = service.GetRowBreeds(null, Row.Row_Id, null, ref errorMessage);
                            companyRowsModels = service.GetCompanyRow(null, null, Row.Row_Id, ref errorMessage);

                        }
                        this.CompanyRowdataGridView.DataSource = companyRowsModels;
                        this.RowBreeddataGridView.DataSource = rowBreedsModel;
                    }
                }

                _choosedRow = new List<BM_Structure_ServiceReference.Row>();
                BM_Structure_ServiceReference.Row Rowe = new BM_Structure_ServiceReference.Row();
                foreach (DataGridViewRow gridrow in this.RowDataGridView.Rows)
                {
                    if (gridrow.Selected)
                    {
                        Rowe = (BM_Structure_ServiceReference.Row)gridrow.DataBoundItem;

                        //არჩეული რიგის ლისტში დამატება
                        _choosedRow.Add(Rowe);




                    }
                }

            }
        }
       
        private void RowBreeddataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.RowRowBreedEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowBreeddataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowBreeddataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.RowRowBreedAddButton.Enabled = true;
                this.RowRowBreedEditButton.Enabled = (this.RowBreeddataGridView.RowCount > 0);
                this.RowRowBreedDeleteButton.Enabled = (this.RowBreeddataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowBreeddataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowBreeddataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.RowRowBreedAddButton.Enabled = true;
                this.RowRowBreedEditButton.Enabled = (this.RowBreeddataGridView.RowCount > 0);
                this.RowRowBreedDeleteButton.Enabled = (this.RowBreeddataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowBreeddataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void RowRowBreedAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
            Forms.Structure.RowsEditForm RowEditForm = null;


            try
            {
                Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;
                companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                /* რედაქტირების ფორმა */
                RowEditForm = new RowsEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, Row, companyRowsModel, rowBreedsModel,false);
                switch (RowEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void RowRowBreedEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();

            Forms.Structure.RowsEditForm RowEditor = null;


            try
            {
                /* მიმდინარე ობიექტი */
                Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;
                if (Row != null)
                {
                 


                    companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                    if (RowBreeddataGridView.Rows.Count == 0)
                    {

                        rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
                    }
                    else
                    {
                        rowBreedsModel = (BM_Structure_ServiceReference.RowBreedsModel)this.RowBreeddataGridView.CurrentRow.DataBoundItem;

                    }

                    /* რედაქტირების ფორმა */
                    RowEditor = new RowsEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, Row, companyRowsModel, rowBreedsModel, false);
                    switch (RowEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private void PrintButton_Click(object sender, EventArgs e)
        {
            string configText = Properties.Settings.Default.RowLabelTemplate;
            
            foreach (BM_Structure_ServiceReference.Row row in this._choosedRow)
            {
                Classes.ZebraRawPrinterHelper.ZebraPrint(configText, row.Row_Barkode, "", "", "", "", "", "");

            }
        }
        private void RowRowBreedDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Row Row = new BM_Structure_ServiceReference.Row();
            BM_Structure_ServiceReference.CompanyRowsModel companyRowsModel = new BM_Structure_ServiceReference.CompanyRowsModel();
            BM_Structure_ServiceReference.RowBreedsModel rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();

            Forms.Structure.RowsEditForm RowEditor = null;

            try
            {

                /* მიმდინარე ობიექტი */
                Row = (BM_Structure_ServiceReference.Row)this.RowDataGridView.CurrentRow.DataBoundItem;
                if (Row != null)
                {
                    //Row = new BM_Structure_ServiceReference.Row()
                    //{
                    //    Row_Id = Row.Row_Id,
                    //    Row_Barkode = Row.Row_Barkode,
                    //    Row_Number = Row.Row_Number,
                    //    Row_Subrow_Number = Row.Row_Subrow_Number,
                    //    Sector_Number = Row.Sector_Number
                    //};

                    companyRowsModel = (BM_Structure_ServiceReference.CompanyRowsModel)this.CompanyRowdataGridView.CurrentRow.DataBoundItem;
                    if (RowBreeddataGridView.Rows.Count == 0)
                    {

                        rowBreedsModel = new BM_Structure_ServiceReference.RowBreedsModel();
                    }
                    else
                    {
                        rowBreedsModel = (BM_Structure_ServiceReference.RowBreedsModel)this.RowBreeddataGridView.CurrentRow.DataBoundItem;

                    }
                    /* რედაქტირების ფორმა */
                    RowEditor = new RowsEditForm(DataChangeType.Delete, ActionMode.WriteAndReturnData, Row, companyRowsModel, rowBreedsModel, null);
                    switch (RowEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.RowsTabPage_Enter(this.RowsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: RowDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }




        #endregion

        #region Post

        private void PostsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.PostDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.PostDataGridView.DataSource = serviceClient.GetPostModel(null, null, ref errorMessage);
            }

        }

        private void PostAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Post Post = new BM_Structure_ServiceReference.Post();
            Forms.Structure.PostEditForm RowBreedEditForm = null;

            try
            {

                /* რედაქტირების ფორმა */
                RowBreedEditForm = new PostEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData, Post);
                switch (RowBreedEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.PostsTabPage_Enter(this.PostsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source:PostAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }


        }

        private void PostEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Post post = new BM_Structure_ServiceReference.Post();
            BM_Structure_ServiceReference.PostModel postModel = new BM_Structure_ServiceReference.PostModel();
            Forms.Structure.PostEditForm PostEditForm = null;


            try
            {
                /* მიმდინარე ობიექტი */
                postModel = (BM_Structure_ServiceReference.PostModel)this.PostDataGridView.CurrentRow.DataBoundItem;
                if (postModel != null)
                {
                    post = new BM_Structure_ServiceReference.Post()
                    {
                       Post_Id = postModel.Post_Id,
                       Post_BalanceSheetType_Id = postModel.Post_BalanceSheetType_Id,
                       Post_BarCodePrefix = postModel.Post_BarCodePrefix.ToUpper(),
                       Post_Description = postModel.Post_Description,
                       Post_Name = postModel.Post_Name
                       

                    };


                    /* რედაქტირების ფორმა */
                    PostEditForm = new PostEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, post);
                    switch (PostEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.PostsTabPage_Enter(this.PostsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PostEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PostDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Post post = new BM_Structure_ServiceReference.Post();
            BM_Structure_ServiceReference.PostModel postModel = new BM_Structure_ServiceReference.PostModel();
            Forms.Structure.PostEditForm PostEditForm = null;


            try
            {
                /* მიმდინარე ობიექტი */
                postModel = (BM_Structure_ServiceReference.PostModel)this.PostDataGridView.CurrentRow.DataBoundItem;
                if (postModel != null)
                {
                    post = new BM_Structure_ServiceReference.Post()
                    {
                        Post_Id = postModel.Post_Id,
                        Post_BalanceSheetType_Id = postModel.Post_BalanceSheetType_Id,
                        Post_BarCodePrefix = postModel.Post_BarCodePrefix.ToUpper(),
                        Post_Description = postModel.Post_Description,
                        Post_Name = postModel.Post_Name

                    };


                    /* რედაქტირების ფორმა */
                    PostEditForm = new PostEditForm(DataChangeType.Delete, ActionMode.WriteAndReturnData, post);
                    switch (PostEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.PostsTabPage_Enter(this.PostsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PostDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PostDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.PostEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PostDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion


        #region Point
        private void PointsTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.PointDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.PointDataGridView.DataSource = serviceClient.GetPoint(null, ref errorMessage);
            }

            BM_Structure_ServiceReference.PointsModel Point = new BM_Structure_ServiceReference.PointsModel();
            _choosedRowPoints = new List<BM_Structure_ServiceReference.PointsModel>();
            foreach (DataGridViewRow row in PointDataGridView.Rows)
            {
                row.Selected = true;
                Point = (BM_Structure_ServiceReference.PointsModel)row.DataBoundItem;
                _choosedRowPoints.Add(Point);
                break;

            }

        }

        private void PointAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Point Point = new BM_Structure_ServiceReference.Point();
            Forms.Structure.PointEditForm RowBreedEditForm = null;

            try
            {

                /* რედაქტირების ფორმა */
                RowBreedEditForm = new PointEditForm(DataChangeType.Insert, ActionMode.WriteAndReturnData, Point);
                switch (RowBreedEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.PointsTabPage_Enter(this.PointsTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source:PointAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }


        }

        private void PointEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Point point = new BM_Structure_ServiceReference.Point();
            BM_Structure_ServiceReference.PointsModel pointModel = new BM_Structure_ServiceReference.PointsModel();
            Forms.Structure.PointEditForm PointEditForm = null;


            try
            {
                /* მიმდინარე ობიექტი */
                pointModel = (BM_Structure_ServiceReference.PointsModel)this.PointDataGridView.CurrentRow.DataBoundItem;
                if (pointModel != null)
                {
                    point = new BM_Structure_ServiceReference.Point()
                    {
                        Point_Id = pointModel.Point_Id,
                        Point_Address = pointModel.Point_Address,
                        Point_BarCode = pointModel.Point_BarCode,
                        Point_Car_Id = pointModel.Point_Car_Id,
                        Point_Description = pointModel.Point_Description,
                        Point_IsActive = pointModel.Point_IsActive,
                        Point_Name = pointModel.Point_Name,
                        Point_PointType_Id = pointModel.Point_PointType_Id
                    };


                    /* რედაქტირების ფორმა */
                    PointEditForm = new PointEditForm(DataChangeType.Update, ActionMode.WriteAndReturnData, point);
                    switch (PointEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.PointsTabPage_Enter(this.PointsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PointEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void PointDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Point point = new BM_Structure_ServiceReference.Point();
            BM_Structure_ServiceReference.PointsModel pointModel = new BM_Structure_ServiceReference.PointsModel();
            Forms.Structure.PointEditForm PointEditForm = null;


            try
            {
                /* მიმდინარე ობიექტი */
                pointModel = (BM_Structure_ServiceReference.PointsModel)this.PointDataGridView.CurrentRow.DataBoundItem;
                if (pointModel != null)
                {
                    point = new BM_Structure_ServiceReference.Point()
                    {
                        Point_Id = pointModel.Point_Id,
                        Point_Address = pointModel.Point_Address,
                        Point_BarCode = pointModel.Point_BarCode,
                        Point_Car_Id = pointModel.Point_Car_Id,
                        Point_Description = pointModel.Point_Description,
                        Point_IsActive = pointModel.Point_IsActive,
                        Point_Name = pointModel.Point_Name,
                        Point_PointType_Id = pointModel.Point_PointType_Id
                    };


                    /* რედაქტირების ფორმა */
                    PointEditForm = new PointEditForm(DataChangeType.Delete, ActionMode.WriteAndReturnData, point);
                    switch (PointEditForm.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.PointsTabPage_Enter(this.PointsTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PointEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }

        }

        private void PointDataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.PointEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PostDataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        #endregion


        #region გარე კომპანიები

        private void OutsideCompanyesTabPage_Enter(object sender, EventArgs e)
        {
            string errorMessage = null;
            this.OutsideCompanyDataGridView.AutoGenerateColumns = false;
            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient serviceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
            {
                this.OutsideCompanyDataGridView.DataSource = serviceClient.GetCompany(null,-1, ref errorMessage);
            }
        }

        private void OutsideCompanyAddButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            Forms.Structure.CompanyEditForm CompanyEditForm = null;


            try
            {


                /* რედაქტირების ფორმა */
                CompanyEditForm = new CompanyEditForm(DataChangeType.Insert,
                                                                      ActionMode.WriteAndReturnData,

                                                                      Company,-1);
                switch (CompanyEditForm.ShowDialog(this))
                {
                    case System.Windows.Forms.DialogResult.OK:
                        /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                        this.OutsideCompanyesTabPage_Enter(this.CompanyesTabPage, new EventArgs());
                        break;
                    case System.Windows.Forms.DialogResult.Cancel:
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyAddButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void OutsideCompanyEditButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            BM_Structure_ServiceReference.CompanyeModel CompanyModel = new BM_Structure_ServiceReference.CompanyeModel();
            Forms.Structure.CompanyEditForm CompanyEditor = null;


            try
            {

                /* მიმდინარე ობიექტი */
                CompanyModel = (BM_Structure_ServiceReference.CompanyeModel)this.OutsideCompanyDataGridView.CurrentRow.DataBoundItem;
                if (CompanyModel != null)
                {
                    Company = new BM_Structure_ServiceReference.Companye()
                    {
                        Company_Id = CompanyModel.Company_Id,
                        Company_Identity = CompanyModel.Company_Identity,
                        Company_CitizenshipId = CompanyModel.Company_CitizenshipId,
                        Company_Name = CompanyModel.Company_Name,
                        Company_Address1 = CompanyModel.Company_Address1,
                        Company_Address2 = CompanyModel.Company_Address2,
                        Company_Phone1 = CompanyModel.Company_Phone1,
                        Company_Phone2 = CompanyModel.Company_Phone2,
                        Company_SideType_Id = CompanyModel.Company_SideType_Id
                    };

                    /* რედაქტირების ფორმა */
                    CompanyEditor = new CompanyEditForm(DataChangeType.Update,
                                                                          ActionMode.WriteAndReturnData,
                                                                          Company,-1);
                    switch (CompanyEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.OutsideCompanyesTabPage_Enter(this.CompanyesTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyEditButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void OutsideCompanyDeleteButton_Click(object sender, EventArgs e)
        {
            BM_Structure_ServiceReference.Companye Company = new BM_Structure_ServiceReference.Companye();
            BM_Structure_ServiceReference.CompanyeModel CompanyModel = new BM_Structure_ServiceReference.CompanyeModel();
            Forms.Structure.CompanyEditForm CompanyEditor = null;


            try
            {



                /* მიმდინარე ობიექტი */
                CompanyModel = (BM_Structure_ServiceReference.CompanyeModel)this.OutsideCompanyDataGridView.CurrentRow.DataBoundItem;
                if (CompanyModel != null)
                {
                    Company = new BM_Structure_ServiceReference.Companye()
                    {
                        Company_Id = CompanyModel.Company_Id,
                        Company_Identity = CompanyModel.Company_Identity,
                        Company_CitizenshipId = CompanyModel.Company_CitizenshipId,
                        Company_Name = CompanyModel.Company_Name,
                        Company_Address1 = CompanyModel.Company_Address1,
                        Company_Address2 = CompanyModel.Company_Address2,
                        Company_Phone1 = CompanyModel.Company_Phone1,
                        Company_Phone2 = CompanyModel.Company_Phone2,
                        Company_SideType_Id = CompanyModel.Company_SideType_Id
                    };



                    /* რედაქტირების ფორმა */
                    CompanyEditor = new CompanyEditForm(DataChangeType.Delete,
                                                                          ActionMode.WriteAndReturnData,
                                                                          Company,-1);
                    switch (CompanyEditor.ShowDialog(this))
                    {
                        case System.Windows.Forms.DialogResult.OK:
                            /* ჩავრთოთ ცხრილის განახლების ინდიკაცია და განვაახლოთ ცხრილი */

                            this.OutsideCompanyesTabPage_Enter(this.CompanyesTabPage, new EventArgs());
                            break;
                        case System.Windows.Forms.DialogResult.Cancel:
                            break;
                        default:
                            break;
                    }
                }
                else
                    throw new Exception("რედაქტირებისათვის განკუთვნილი ობიექტი ცარიელია");
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyDeleteButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private void OutsideCompanyDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // გავდივართ ჩანაწერის რედაქტირებაზე
                this.OutsideCompanyEditButton.PerformClick();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyRowsDsataGridView_CellDoubleClick", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void OutsideCompanyDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                this.OutsideCompanyAddButton.Enabled = true;
                this.OutsideCompanyEditButton.Enabled = (this.OutsideCompanyDataGridView.RowCount > 0);
                this.OutsideCompanyDeleteButton.Enabled = (this.OutsideCompanyDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyDataGridView_RowsAdded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void OutsideCompanyDataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            try
            {
                this.OutsideCompanyAddButton.Enabled = true;
                this.OutsideCompanyEditButton.Enabled = (this.OutsideCompanyDataGridView.RowCount > 0);
                this.OutsideCompanyDeleteButton.Enabled = (this.OutsideCompanyDataGridView.RowCount > 0);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: CompanyDataGridView_RowsRemoved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }








        #endregion

        private void InsideCompanyDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.InsideCompanyRowdataGridView.DataSource = null;
                this.InsideCompanyBreedDataGridView.DataSource = null;

                this.InsideCompanyRowdataGridView.AutoGenerateColumns = false;
                this.InsideCompanyBreedDataGridView.AutoGenerateColumns = false;


                List<BM_Structure_ServiceReference.CompanyRowsModel> companyRowsModels = null;
                string errorMessage = string.Empty;
                if (sender != null)
                {
                    if (e.RowIndex >= 0)
                    {
                        BM_Structure_ServiceReference.CompanyeModel Company = (BM_Structure_ServiceReference.CompanyeModel)this.InsideCompanyDataGridView.Rows[e.RowIndex].DataBoundItem;

                        using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                        {
                            companyRowsModels = service.GetCompanyRow(null, Company.Company_Id, null, ref errorMessage);
                        }
                        this.InsideCompanyRowdataGridView.DataSource = companyRowsModels;

                        //InsideCompanyRowdataGridView.Columns[0].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[1].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[2].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[3].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[5].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[6].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[7].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[8].Visible = false;
                        //InsideCompanyRowdataGridView.Columns[9].Visible = false;

                        //InsideCompanyRowdataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        //InsideCompanyRowdataGridView.Columns[4].HeaderText = "ბარკოდი";

                    }
                    else
                    {
                        if (this.RowDataGridView.CurrentRow != null)
                        {
                            BM_Structure_ServiceReference.Companye Company = (BM_Structure_ServiceReference.Companye)this.InsideCompanyDataGridView.CurrentRow.DataBoundItem;

                            using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                            {
                                companyRowsModels = service.GetCompanyRow(null, Company.Company_Id, null, ref errorMessage);

                            }
                            this.InsideCompanyRowdataGridView.DataSource = companyRowsModels;

                        }
                    }


                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void InsideCompanyRowdataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
            this.InsideCompanyBreedDataGridView.DataSource = null;
            List<BM_Structure_ServiceReference.RowBreedsModel> rowBreedsModel = null;
            
            string errorMessage = string.Empty;
            if (sender != null)
            {
                if (e.RowIndex >= 0)
                {
                    BM_Structure_ServiceReference.CompanyRowsModel Row = (BM_Structure_ServiceReference.CompanyRowsModel)this.InsideCompanyRowdataGridView.Rows[e.RowIndex].DataBoundItem;

                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        rowBreedsModel = service.GetRowBreeds(null, Row.CompanyRow_Row_Id, null, ref errorMessage);
                        

                    }
                    
                    this.InsideCompanyBreedDataGridView.DataSource = rowBreedsModel;


                    //InsideCompanyBreedDataGridView.Columns[0].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[2].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[3].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[5].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[6].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[7].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[8].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[9].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[10].Visible = false;
                    //InsideCompanyBreedDataGridView.Columns[11].Visible = false;

                    //InsideCompanyBreedDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //InsideCompanyBreedDataGridView.Columns[1].HeaderText = "ჯიში";

                    //InsideCompanyBreedDataGridView.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    //InsideCompanyBreedDataGridView.Columns[4].HeaderText = "ასაკი";

                }
                else
                {
                    if (this.RowDataGridView.CurrentRow != null)
                    {
                        BM_Structure_ServiceReference.CompanyRowsModel Row = (BM_Structure_ServiceReference.CompanyRowsModel)this.InsideCompanyRowdataGridView.CurrentRow.DataBoundItem;

                        using (BM_Structure_ServiceReference.BM_Structure_ServiceClient service = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                        {
                            rowBreedsModel = service.GetRowBreeds(null, Row.CompanyRow_Row_Id, null, ref errorMessage);
                            
                        }
                        
                        this.InsideCompanyBreedDataGridView.DataSource = rowBreedsModel;

                    }
                }



            }
        }
        

        private void PointPrintButton_Click(object sender, EventArgs e)
        {
            string configText = Properties.Settings.Default.CarLabelTemplate;

            if (this._choosedPoint.Count != 0)
            {
                foreach (BM_Structure_ServiceReference.PointsModel point in this._choosedPoint)
                {
                    Classes.ZebraRawPrinterHelper.ZebraPrint(configText, point.Point_BarCode, point.Point_Car_Number, "", "", "", "", "");
                }
            }
            else
            {
                foreach (BM_Structure_ServiceReference.PointsModel point in this._choosedRowPoints)
                {
                    Classes.ZebraRawPrinterHelper.ZebraPrint(configText, point.Point_BarCode, point.Point_Car_Number, "", "", "", "", "");
                }
            }
        }


        private void PointDataGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _choosedPoint = new List<BM_Structure_ServiceReference.PointsModel>();
            BM_Structure_ServiceReference.PointsModel point = new BM_Structure_ServiceReference.PointsModel();
            foreach (DataGridViewRow gridrow in this.PointDataGridView.Rows)
            {
                if (gridrow.Selected)
                {
                    point = (BM_Structure_ServiceReference.PointsModel)gridrow.DataBoundItem;
                    //არჩეული რიგის ლისტში დამატება
                    _choosedPoint.Add(point);

                }
            }
        }

        private void BagesPrintButton_Click(object sender, EventArgs e)
        {
            List<Classes.EmployeeLabel> employeeLabels = new List<Classes.EmployeeLabel>();

            if (_choosedPersons.Count == 0)
                _choosedPersons = _choosedPerson;

            foreach (BM_Employee_ServiceReference.PersonPostModel personPostModel in _choosedPersons)
            {
                Classes.EmployeeLabel employeeLabel = new Classes.EmployeeLabel();
                employeeLabel.Employee = new BM_Employee_ServiceReference.EmployeeLabel();
                employeeLabel.Employee.Barcode = personPostModel.PersonPost_EmployeeBarCode;
                employeeLabel.Employee.BrigadeName = personPostModel.PersonPost_Brigade_Name;
                employeeLabel.Employee.FirstName = personPostModel.PersonPost_Person_FullName.Split(' ')[0];
                employeeLabel.Employee.LastName = personPostModel.PersonPost_Person_FullName.Split(' ')[1];
                employeeLabel.Employee.PostName = personPostModel.PersonPost_Post_Name;
                employeeLabels.Add(employeeLabel);
            }
            Report.TemplatesViewerForm templatesViewerForm = new Report.TemplatesViewerForm(employeeLabels);
            templatesViewerForm.ShowDialog(this);
        }

        private void PersonBrigadeDgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _choosedPersons = new List<BM_Employee_ServiceReference.PersonPostModel>();
            person = new BM_Employee_ServiceReference.PersonPostModel();

            //if (sender != null)
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        person = (BM_Employee_ServiceReference.PersonPostModel)this.PersonBrigadeDgv.Rows[e.RowIndex].DataBoundItem;
            //    }
            //}
            //else
            //{
            //    if (this.PersonBrigadeDgv.CurrentRow != null)
            //    {
            //        person = (BM_Employee_ServiceReference.PersonPostModel)this.PersonBrigadeDgv.CurrentRow.DataBoundItem;
            //    }
            //}

            //_choosedPersons.Add(person);

            foreach (DataGridViewRow gridrow in this.PersonBrigadeDgv.Rows)
            {
                if (gridrow.Selected)
                {
                    person = (BM_Employee_ServiceReference.PersonPostModel)gridrow.DataBoundItem;
                    //არჩეული რიგის ლისტში დამატება
                    _choosedPersons.Add(person);
                }
            }

        }
    }
}
        