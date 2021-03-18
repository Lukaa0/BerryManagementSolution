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
    public partial class VerifyPersonalNumber : Form
    {
        #region Private members
        private bool _formCloseSwitch;
        private int _numberOfSamePersonalIDs;
        private string _personalID;
        #endregion


        #region Constructors
        public VerifyPersonalNumber()
        {
            // ინიციალიზაცია
            InitializeComponent();
            this._formCloseSwitch = true;
            this._numberOfSamePersonalIDs = 0;
            this._personalID = System.String.Empty;

        }
        #endregion

        #region Public properties
        public string VerifiedPersonalID
        {
            get { return this._personalID; }
        }

        public int NumberOfSamePersonalIDs
        {
            get { return this._numberOfSamePersonalIDs; }
        }
        #endregion

        #region Private methods
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                this._personalID = this.VerifyValueTextBox.Text.Trim();
                string errorMessage = null;
                int i;

                if (int.TryParse(this._personalID, out i) || this._personalID.Length != 11)
                {
                    DialogResult res = MessageBox.Show("თქვენს მიერ შეყვანილი პირადი ნომერი - " + _personalID + " არ არის 11 ნიშნიანი ან შეიცავს ასოებს. გავაგრძელოთ მონაცემების შეყვანა ?", "ყურადღებით !!!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


                    if (res == DialogResult.OK)
                    {
                        this._formCloseSwitch = true;
                    }
                    if (res == DialogResult.Cancel)
                    {
                        this._formCloseSwitch = false;
                        return;
                    }
                }

                if (!System.String.IsNullOrEmpty(this.VerifyValueTextBox.Text.Trim()))
                {
                    using (BM_Employee_ServiceReference.BM_Employee_ServiceClient employeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                    {
                        this._numberOfSamePersonalIDs = employeeServiceClient.GetNumberOfEmployeeSameIdentities(this.VerifyValueTextBox.Text.Trim(),ref errorMessage);
                    }
                }
                else
                {
                    throw new Exception("არ არის შეყვანილი პერსონალური ნომერი");
                }
            }
            catch (Exception ex)
            {
                /* ვაუქმებთ ოპერაციას და ვკრძალავთ ფორმის დახურვას */
                this._formCloseSwitch = false;
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: AcceptButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void CancButton_Click(object sender, EventArgs e)
        {
            try
            {
                // ჩავრთოთ ფორმის დახურვის ნებართვა და გავიდეთ ფორმიდან
                this._formCloseSwitch = true;
                this._personalID = System.String.Empty;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Source: CancelButton_Click", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }
        private void VerifyPersonalNumber_Activated(object sender, EventArgs e)
        {
            this.VerifyValueTextBox.Focus();
        }

        private void VerifyPersonalNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            e.Cancel = !this._formCloseSwitch;
        }
        #endregion


    }
}
