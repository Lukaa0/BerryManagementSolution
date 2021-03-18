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
    public partial class CarDriverEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.CarDriver _CarDriver;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public CarDriverEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CarDriver = new BM_Structure_ServiceReference.CarDriver();
            this._formCloseSwitch = true;

            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PersonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        public CarDriverEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.CarDriver carDriver)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._CarDriver = (carDriver != null) ? carDriver : new  BM_Structure_ServiceReference.CarDriver();
            this._formCloseSwitch = true;

            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PersonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #region Public properties
        public BM_Structure_ServiceReference.CarDriver CArDriverObject
        {
            get { return this._CarDriver; }
        }
        #endregion

        #region Public methods

        public int OperateToCarDriver(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.CarDriver carDriver, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (carDriver != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertCarDriver(carDriver, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateCarDriver(carDriver, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteCarDriver(carDriver.CarDriver_Id, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperateToCarDriver";
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
            BM_Structure_ServiceReference.CarDriver careDrivere = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                
                if (this.CarComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული მანქანა სახელი!");
                if (this.PersonComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული პიროვნება!");
               
                if (PersonPostEndDateTitleCheckBox.Checked)
                {
                    if (this.StartDateTimePicker.Value >= this.EndDateTimePicker.Value)
                        throw new Exception("არასწორი თარიღი!");
                }

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;


                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                careDrivere = new BM_Structure_ServiceReference.CarDriver()
                {
                    CarDriver_Id = this._CarDriver.CarDriver_Id,
                    CarDriver_Car_Id = (this.CarComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CarComboBox.SelectedValue) : 0,
                    CarDriver_Person_Id = (this.PersonComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PersonComboBox.SelectedValue) : 0,
                    CarDriver_EndDate = (PersonPostEndDateTitleCheckBox.Checked) ? this.EndDateTimePicker.Value : (DateTime?)null,
                    CarDriver_StartDate = this.StartDateTimePicker.Value,
                    

                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCarDriver(this._dataChangeType, ref careDrivere, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }
                if (!string.IsNullOrEmpty(pErrorMessage))
                {
                    MessageBox.Show(pErrorMessage);
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._CarDriver = careDrivere;
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

        private void CarDriverEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Structure_ServiceReference.CarModel> carModels = null;
            List<BM_Employee_ServiceReference.Person> people = null;
            List<BM_Structure_ServiceReference.Post> posts = null;
            BM_Structure_ServiceReference.Post Getposts = null;

            BM_Employee_ServiceReference.PersonPost personPosts = null;


            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "ბრიგადა";
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
                                if (this.OperateToCarDriver(this._dataChangeType, ref this._CarDriver, ref pErrorMessage) != 0)
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

                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient employee_ServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {
                    people = employee_ServiceClient.GetEmployeeData(null, ref errorMessage).ToList<BM_Employee_ServiceReference.Person>();
                    
                }

                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    carModels = StructureService.GetCar(null, ref errorMessage).ToList<BM_Structure_ServiceReference.CarModel>();
                    
                }

               

                /*car კომბო*/
                this.CarComboBox.DataSource = carModels;
                this.CarComboBox.DisplayMember = "Car_Number";
                this.CarComboBox.ValueMember = "Car_Id";
                this.CarComboBox.SelectedIndex = -1;
                if ((this.CarComboBox.Items.Count > 0) && (this._CarDriver.CarDriver_Car_Id > 0))
                    foreach (BM_Structure_ServiceReference.CarModel Car in this.CarComboBox.Items)
                        if ((long)Car.Car_Id == this._CarDriver.CarDriver_Car_Id)
                        {
                            this.CarComboBox.SelectedIndex = this.CarComboBox.Items.IndexOf(Car);
                            break;
                        }


                /*person კომბო*/
                this.PersonComboBox.DataSource = people;
                this.PersonComboBox.DisplayMember = "Person_FirstName";
                this.PersonComboBox.ValueMember = "Person_Id";
                this.PersonComboBox.SelectedIndex = -1;
                if ((this.PersonComboBox.Items.Count > 0) && (this._CarDriver.CarDriver_Person_Id > 0))
                    foreach (BM_Employee_ServiceReference.Person person in this.PersonComboBox.Items)
                        if ((long)person.Person_Id == this._CarDriver.CarDriver_Person_Id)
                        {
                            this.PersonComboBox.SelectedIndex = this.PersonComboBox.Items.IndexOf(person);
                            break;
                        }

                ///* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                //this.CarNumberTextBox.Text = this._Car.Car_Number;
                //this.CarModelTextBox.Text = this._Car.Car_Model;

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.StartDateTimePicker.Value = ((this._CarDriver.CarDriver_StartDate != System.DateTime.MinValue) && (this._CarDriver.CarDriver_StartDate != System.DateTime.MaxValue)) ? this._CarDriver.CarDriver_StartDate : this.StartDateTimePicker.Value;
                this.EndDateTimePicker.Value = ((this._CarDriver.CarDriver_EndDate.HasValue) && (this._CarDriver.CarDriver_EndDate != System.DateTime.MinValue) && (this._CarDriver.CarDriver_EndDate != System.DateTime.MaxValue)) ? this._CarDriver.CarDriver_EndDate.Value : this.EndDateTimePicker.Value;

                // დასრულების თარიღის კონტროლის მდგომარეობა
                this.PersonPostEndDateTitleCheckBox.Checked = (this._CarDriver.CarDriver_EndDate.HasValue);
                this.EndDateTimePicker.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

                // თარიღის ქართული ფორმატი
                this.StartDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.StartDateTimePicker.Format = DateTimePickerFormat.Custom;
                this.EndDateTimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
                this.EndDateTimePicker.Format = DateTimePickerFormat.Custom;




            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: BrigadeEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PersonLabel_Click(object sender, EventArgs e)
        {

        }

        private void CarDriverEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
