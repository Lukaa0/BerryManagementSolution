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
    public partial class PostEditForm : Form
    {
        
        private DataChangeType _dataChangeType; // ოპერაციის კოდი: 1-დამატება, 2-რედაქტირება, 3-წაშლა
        private ActionMode _actionMode;         // სამუშაო რეჟიმი: 1-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე,
        //                                                          2-რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით
        private BM_Structure_ServiceReference.Post _post;
        private string _formTitle;
        private bool _formCloseSwitch;
        private bool _Discard = false;
        public PostEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._post = new BM_Structure_ServiceReference.Post();
            this._formCloseSwitch = true;

            this.BalanceSheetTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public PostEditForm(DataChangeType inDataChangeType, ActionMode inAtionMode, BM_Structure_ServiceReference.Post Post)
        {
            InitializeComponent();
           
            this._dataChangeType = inDataChangeType;
            this._actionMode = inAtionMode;
            this._post = (Post != null) ? Post : new  BM_Structure_ServiceReference.Post();
            this._formCloseSwitch = true;

            this.BalanceSheetTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        #region Public properties
        public BM_Structure_ServiceReference.Post PostObject
        {
            get { return this._post; }
        }
        #endregion

        #region Public methods

        public int OperatePost(DataChangeType inDataChangeType, ref BM_Structure_ServiceReference.Post Post, ref string inoutErrorMessage)
        {
            int iResult = 0;

            try
            {
                // ავარიული შეტყობინების ინიციალიზაცია
                inoutErrorMessage = System.String.Empty;

                if (Post != null)
                {
                    using (BM_Structure_ServiceReference.BM_Structure_ServiceClient ServiceClient = new BM_Structure_ServiceReference.BM_Structure_ServiceClient())
                    {
                        switch (inDataChangeType)
                        {
                            case DataChangeType.Insert:
                                ServiceClient.InsertPost(Post, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Update:
                                ServiceClient.UpdatePost(Post, ref inoutErrorMessage);
                                break;
                            case DataChangeType.Delete:
                                ServiceClient.DeletePost(Post.Post_Id, ref inoutErrorMessage);
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
            BM_Structure_ServiceReference.Post post = null;
            string pErrorMessage = System.String.Empty;
            int iResult = 0;

            try
            {
                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = false;

                // ფილტრი
                if (this.BalanceSheetTypeComboBox.SelectedItem == null)
                    throw new Exception("არ არის BalaceSheet!");
                if (this.NameTextBox.Text == null)
                    throw new Exception("არ არის მითითებული სახელი!");
                if (this.DescriptionTextBox.Text == null)
                    throw new Exception("არ არის მითითებული აღწერა!");
                if (this.PrefixTextBox.Text == null)
                    throw new Exception("არ არის მითითებული პრეფიქსი!");


                /* ფორმის დახურვის ნებართვა */
                this._formCloseSwitch = true;



                /* დავაფორმიროთ პარამეტრად გადასაცემი მოდიფიცირებული ობიექტი */
                post = new BM_Structure_ServiceReference.Post()
                {
                    Post_Id = this._post.Post_Id,
                    Post_BalanceSheetType_Id = (this.BalanceSheetTypeComboBox.SelectedItem != null) ? System.Convert.ToInt32(this.BalanceSheetTypeComboBox.SelectedValue) : 0,
                    Post_BarCodePrefix = PrefixTextBox.Text.ToUpper(),
                    Post_Description = DescriptionTextBox.Text,
                    Post_Name = NameTextBox.Text
                };

                switch (this._actionMode)
                {
                    case ActionMode.ReturnDataOnly: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერის გარეშე */
                        break;
                    case ActionMode.WriteAndReturnData: /* რედაქტირებული მონაცემების დაბრუნება ბაზაში გადაწერით */
                        iResult = this.OperatePost(this._dataChangeType, ref post, ref pErrorMessage);
                        break;
                    default:
                        iResult = -1;
                        break;
                }

                if (iResult == 0)
                {
                    /* წარმატება. დავაფიქსიროთ მოდიფიცირებული ობიექტი */
                    this._post = post;
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

            List<BM_Library_ServiceReference.tf_GetBalanceSheetTypes_Result> tf_SideTypes = null;



            string pErrorMessage = System.String.Empty;
     
            try
            {
                /* ვაფორმირებთ ფორმის სათაურს */
                this._formTitle = "თანამდებობა";
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
                                if (this.OperatePost(this._dataChangeType, ref this._post, ref pErrorMessage) != 0)
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
                    tf_SideTypes = LibraryService.GetBalanceSheetTypes(null, null, ref errorMessage).ToList<BM_Library_ServiceReference.tf_GetBalanceSheetTypes_Result>();

                }


                /*SideType კომბო*/
                this.BalanceSheetTypeComboBox.DataSource = tf_SideTypes;
                this.BalanceSheetTypeComboBox.DisplayMember = "BalanceSheetType_Name";
                this.BalanceSheetTypeComboBox.ValueMember = "BalanceSheetType_Id";
                this.BalanceSheetTypeComboBox.SelectedIndex = -1;
                if ((this.BalanceSheetTypeComboBox.Items.Count > 0) && (this._post.Post_BalanceSheetType_Id > 0))
                    foreach (BM_Library_ServiceReference.tf_GetBalanceSheetTypes_Result tf_SideTypese in this.BalanceSheetTypeComboBox.Items)
                        if ((long)tf_SideTypese.BalanceSheetType_Id == this._post.Post_BalanceSheetType_Id)
                        {
                            this.BalanceSheetTypeComboBox.SelectedIndex = this.BalanceSheetTypeComboBox.Items.IndexOf(tf_SideTypese);
                            break;
                        }

                /* გადაგვაქვს შემოსული ინფორმაცია კონტროლებში */
                this.NameTextBox.Text = this._post.Post_Name;
                this.DescriptionTextBox.Text = this._post.Post_Description;
                this.PrefixTextBox.Text = this._post.Post_BarCodePrefix;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: PostEditForm_Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PostEditForm_FormClosing(object sender, FormClosingEventArgs e)
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
