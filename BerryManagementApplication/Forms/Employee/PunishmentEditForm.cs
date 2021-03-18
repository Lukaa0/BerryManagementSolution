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

namespace BerryManagementApplication.Forms.Employee
{
    public partial class PunishmentEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Employee_ServiceReference.Punishment _punishmnet;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        private long _personId;
        public PunishmentEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, long PersonID)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._punishmnet = new BM_Employee_ServiceReference.Punishment();
            this._formCloseSwitch = true;

            this.PunishmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            

            this._personId = PersonID;


        }

        public PunishmentEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Employee_ServiceReference.Punishment Punishment)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._punishmnet = (Punishment != null) ? Punishment : new BM_Employee_ServiceReference.Punishment();
            this._formCloseSwitch = true;

            this._personId = Punishment.Punishment_PersonPost_Id;

            this.PunishmentComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        #region Public properties
        public BM_Employee_ServiceReference.Punishment PunishmentObject
        {
            get { return this._punishmnet; }
        }
        #endregion

        #region Public methods

        public int OperateToPunishment(DataChangeType inDataChangeType, ref BM_Employee_ServiceReference.Punishment Punishments, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Punishments != null)
                {
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient ServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertPunishment(Punishments, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdatePunishment(Punishments, ref inoutErrorMessage);
                                break;
                            //case DataChangeType.Delete:
                            //    ServiceClient.DeleteCompanyCar(Punishment.CompanyCar_Id, ref inoutErrorMessage);
                            //    break;
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
                inoutErrorMessage = ex.Message + " Source: OperateToPunishment";
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
            BM_Employee_ServiceReference.Punishment punishment = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.PunishmentComboBox.SelectedItem == null)
                    throw new Exception("არ არის სასჯელი!");
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;

                DateTime dateTimeForCheck = new DateTime();

                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                punishment = new BM_Employee_ServiceReference.Punishment()
                {
                    Punishment_Id = _punishmnet.Punishment_Id,
                    Punishment_DateTime = (_punishmnet.Punishment_DateTime != dateTimeForCheck) ? _punishmnet.Punishment_DateTime : DateTime.Now,
                    Punishment_PersonPost_Id  = this._personId,
                    Punishment_PunishmentType_Id = (this.PunishmentComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.PunishmentComboBox.SelectedValue) : 0,
                    Punishment_User_PersonPost_Id = Security.AutentificationForm._personPost,
                    Punishment_Description = PunishmentComentTextBox.Text
                    
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperateToPunishment(this._dataChangeType, ref punishment, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._punishmnet = punishment;
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

        private void PunishmentEditForm_Load(object sender, EventArgs e)
        {
            List<BM_Library_ServiceReference.tf_PunishmentTypes_Result> PunishmentTypeData = null;
            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "დანაშაული";
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
                                if (this.OperateToPunishment(this._dataChangeType, ref this._punishmnet, ref pErrorMessage) != 0)
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

                using (BM_Library_ServiceReference.BM_Library_ServiceClient Service = new BM_Library_ServiceReference.BM_Library_ServiceClient())
                {
                    PunishmentTypeData = Service.GetPunishmentTypes(null,null, ref errorMessage);
                }

                /*PunishmentType კომბო*/
                this.PunishmentComboBox.DataSource = PunishmentTypeData;
                this.PunishmentComboBox.DisplayMember = "PunishmentType_Name";
                this.PunishmentComboBox.ValueMember = "PunishmentType_Id";
                this.PunishmentComboBox.SelectedIndex = -1;
                if ((this.PunishmentComboBox.Items.Count > 0) && (this._punishmnet.Punishment_PersonPost_Id > 0))
                    foreach (BM_Library_ServiceReference.tf_PunishmentTypes_Result punishmnetType in this.PunishmentComboBox.Items)
                        if ((long)punishmnetType.PunishmentType_Id == this._punishmnet.Punishment_PunishmentType_Id)
                        {
                            this.PunishmentComboBox.SelectedIndex = this.PunishmentComboBox.Items.IndexOf(punishmnetType);
                            break;
                        }

                PunishmentComentTextBox.Text = _punishmnet.Punishment_Description;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: PunishmentEdit_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PunishmentEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
