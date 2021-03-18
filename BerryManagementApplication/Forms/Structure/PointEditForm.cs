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
    public partial class PointEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.Point _point;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public PointEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._point = new BM_Structure_ServiceReference.Point();
            this._formCloseSwitch = true;


            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PointTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            

            this.CarComboBox.Enabled = this.CarCheckBox.Checked;
            this.AdresTextBox.Enabled = !this.CarCheckBox.Checked;
        }

        public PointEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Point Post)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._point = (Post != null) ? Post : new  BM_Structure_ServiceReference.Point();
            this._formCloseSwitch = true;

            if (Post.Point_Car_Id != 0)
            {
                this.CarCheckBox.Checked = true;
            }


            this.CarComboBox.Enabled = this.CarCheckBox.Checked;
            this.AdresTextBox.Enabled = !this.CarCheckBox.Checked;


            this.CarComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.PointTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        #region Public properties
        public BM_Structure_ServiceReference.Point PostObject
        {
            get { return this._point; }
        }
        #endregion

        #region Public methods

        public int OperatePoint(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.Point Point, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Point != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertPoint(Point, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdatePoint(Point, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeletePoint(Point, ref inoutErrorMessage);
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
                inoutErrorMessage = ex.Message + " Source: OperatePost";
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
            BM_Structure_ServiceReference.Point point = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი

                
                if (this.NameTextBox.Text == null)
                    throw new Exception("არ არის მითითებული სახელი!");
                if (this.PointTypeComboBox.SelectedItem == null)
                    throw new Exception("არ არის BalaceSheet!");
                if (this.CarCheckBox.Checked)
                {
                    if(this.CarComboBox.SelectedItem == null)
                        throw new Exception("არ არის მითითებული მანქანა");
                }
                else
                {
                    if (string.IsNullOrEmpty(AdresTextBox.Text))
                        throw new Exception("არ არის მითითებული მისამართი");
                }

                    /* ფორმის დახურვის ნებართვა */
                    this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                point = new BM_Structure_ServiceReference.Point()
                {

                    Point_Id = this._point.Point_Id,
                    Point_Address = AdresTextBox.Text,
                    Point_Car_Id = (this.CarCheckBox.Checked) ? System.Convert.ToInt32(this.CarComboBox.SelectedValue) : 0,
                    Point_Description = DescriptionTextBox.Text,
                    Point_IsActive = isActive.Checked,
                    Point_Name = NameTextBox.Text,
                    Point_PointType_Id = this.PointTypeComboBox.SelectedValue.ToString()

                };

                if (this.CarCheckBox.Checked)
                {
                    point.Point_Address = null;
                }

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperatePoint(this._dataChangeType, ref point, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._point = point;
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

        private void RowBreedEditForm_Load(object sender, EventArgs e)
        {

            List<BM_Structure_ServiceReference.CarModel> carModels = null;

            List<BM_Library_ServiceReference.tf_PointTypes_Result> tf_PointTypes = null;

            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "ადგილი";
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
                                if (this.OperatePoint(this._dataChangeType, ref this._point, ref pErrorMessage) != 0)
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



                using (BM_Structure_ServiceReference.BM_Structure_ServiceClient StructureService = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                {
                    carModels = StructureService.GetCar(null, ref errorMessage).ToList<BM_Structure_ServiceReference.CarModel>();
                    
                }

                using (BM_Library_ServiceReference.BM_Library_ServiceClient LibraryService = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    tf_PointTypes = LibraryService.GetPointTypes(null, null,null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_PointTypes_Result>();

                }


                /*car კომბო*/
                this.CarComboBox.DataSource = carModels;
                this.CarComboBox.DisplayMember = "Car_Model";
                this.CarComboBox.ValueMember = "Car_Id";
                this.CarComboBox.SelectedIndex = -1;
                if ((this.CarComboBox.Items.Count > 0) && (this._point.Point_Car_Id > 0))
                    foreach (BM_Structure_ServiceReference.CarModel Car in this.CarComboBox.Items)
                        if ((long)Car.Car_Id == this._point.Point_Car_Id)
                        {
                            this.CarComboBox.SelectedIndex = this.CarComboBox.Items.IndexOf(Car);
                            break;
                        }

                /*PointTypes კომბო*/
                this.PointTypeComboBox.DataSource = tf_PointTypes;
                this.PointTypeComboBox.DisplayMember = "PointType_Name";
                this.PointTypeComboBox.ValueMember = "PointType_Id";
                this.PointTypeComboBox.SelectedIndex = -1;
                if ((this.PointTypeComboBox.Items.Count > 0))
                    foreach (BM_Library_ServiceReference.tf_PointTypes_Result tf_SideTypese in this.PointTypeComboBox.Items)
                        if (tf_SideTypese.PointType_Id == this._point.Point_PointType_Id)
                        {
                            this.PointTypeComboBox.SelectedIndex = this.PointTypeComboBox.Items.IndexOf(tf_SideTypese);
                            break;
                        }


                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.NameTextBox.Text = this._point.Point_Name;
                this.DescriptionTextBox.Text = this._point.Point_Description;
                this.AdresTextBox.Text = this._point.Point_Address;
                this.isActive.Checked = this._point.Point_IsActive;


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: PointEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PointEditForm_FormClosing(object sender, FormClosingEventArgs e)
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

        private void CarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.CarComboBox.Enabled = this.CarCheckBox.Checked;
                this.AdresTextBox.Enabled = !this.CarCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
    }
}
