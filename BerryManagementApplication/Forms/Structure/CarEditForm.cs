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
    public partial class CarEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.Car _Car;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public CarEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._Car = new BM_Structure_ServiceReference.Car();
            this._formCloseSwitch = true;


            this.CarSideTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public CarEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Car car)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._Car = (car != null) ? car : new  BM_Structure_ServiceReference.Car();
            this._formCloseSwitch = true;

            this.CarSideTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #region Public properties
        public BM_Structure_ServiceReference.Car BrigadeObject
        {
            get { return this._Car; }
        }
        #endregion

        #region Public methods

        public int OperateToCar(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.Car car, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (car != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertCar( car, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdateCar(car, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeleteCar(car.Car_Id, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperateToCar";
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
            BM_Structure_ServiceReference.Car caree = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                
                if (this.CarNumberTextBox.Text.Trim() == System.String.Empty)
                    throw new Exception("არ არის მითითებული ბრიგადის სახელი!");
                if (this.CarSideTypeComboBox.SelectedItem == null)
                    throw new Exception("არ არის მითითებული SideType ტიპი!");

                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                caree = new BM_Structure_ServiceReference.Car()
                {
                    Car_Id = this._Car.Car_Id,
                    Car_Number = this.CarNumberTextBox.Text.Trim(),
                    Car_Model=this.CarModelTextBox.Text.Trim(),
                    Car_SideType_Id= (this.CarSideTypeComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.CarSideTypeComboBox.SelectedValue) : 0,

                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToCar(this._dataChangeType, ref caree, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._Car = caree;
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

        private void BrigadeEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.tf_SideTypes_Result> SideTypes = null;
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
                                if (this.OperateToCar(this._dataChangeType, ref this._Car, ref pErrorMessage) != 0)
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

                using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    SideTypes = LibraryService.GetSideTypes(null, null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_SideTypes_Result>();

                }


                /*SideType კომბო*/
                this.CarSideTypeComboBox.DataSource = SideTypes;
                this.CarSideTypeComboBox.DisplayMember = "SideType_Name";
                this.CarSideTypeComboBox.ValueMember = "SideType_Id";
                this.CarSideTypeComboBox.SelectedIndex = -1;
                if ((this.CarSideTypeComboBox.Items.Count > 0) && (this._Car.Car_SideType_Id>0))
                    foreach (BM_Library_ServiceReference.tf_SideTypes_Result tf_SideTypese in this.CarSideTypeComboBox.Items)
                        if ((long)tf_SideTypese.SideType_Id == this._Car.Car_SideType_Id)
                        {
                            this.CarSideTypeComboBox.SelectedIndex = this.CarSideTypeComboBox.Items.IndexOf(tf_SideTypese);
                            break;
                        }

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.CarNumberTextBox.Text = this._Car.Car_Number;
                this.CarModelTextBox.Text = this._Car.Car_Model;
               

                
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

        private void CarEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
