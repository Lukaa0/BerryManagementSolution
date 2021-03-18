using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Operations
{
    public partial class BerryProducePrintForm : Form
    {
        private decimal? _startSugar = null;
        private decimal? _endSugar = null;
        private DateTime? _starTime = null;
        private DateTime? _endTime = null;


        public BerryProducePrintForm()
        {
            InitializeComponent();
            
            FillPrintPropertiesGridView();


            this.EnddateTimePicker2.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            this.StartdateTimePicker1.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;

            this.SugarNumericUpDownStart.Enabled = this.SugarCheckBox.Checked;
            this.SugarNumericUpDownEnd.Enabled = this.SugarCheckBox.Checked;

        }

        private void FillPrintPropertiesGridView()
        {
            string ErrorMessage = System.String.Empty;

            try
            {
                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PrintPropertiesGridView.AutoGenerateColumns = false;

                    using (BM_Produce_ServiceReference.BM_Produce_ServiceClient serviceClient = new BM_Produce_ServiceReference.BM_Produce_ServiceClient())
                    {
                        this.PrintPropertiesGridView.DataSource = serviceClient.GetBreedProperty(null, null, null, null, null, null,null, ref ErrorMessage);
                    }
                    if (!string.IsNullOrEmpty(ErrorMessage))
                        throw new Exception(ErrorMessage);


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillPrintPunishmentGridView()" + ErrorMessage);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void DeFilterButton_Click(object sender, EventArgs e)
        {
            FillPrintPropertiesGridView();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            string ErrorMessage = System.String.Empty;


            if (PersonPostEndDateTitleCheckBox.Checked)
            {
                if (EnddateTimePicker2.Value < StartdateTimePicker1.Value)
                {
                    MessageBox.Show("დაფიქსირდა შეცდომა, გთხოვთ გადაამოწმოთ თარიღები \n მონაცემები ვერ განახლდება");
                    return;

                }
                else
                {
                    this._starTime = StartdateTimePicker1.Value.AddDays(-1);
                    this._endTime = EnddateTimePicker2.Value;
                }
            }
            else
            {
                this._starTime = null;
                this._endTime = null;
            }
            if (SugarCheckBox.Checked)
            {
                if (SugarNumericUpDownStart.Value > SugarNumericUpDownEnd.Value)
                {
                    MessageBox.Show("დაფიქსირდა შეცდომა, გთხოვთ გადაამოწმოთ შაქრის პროცენტულობა \n მონაცემები ვერ განახლდება ");
                    return;
                }
                else
                {
                    this._startSugar = SugarNumericUpDownStart.Value;
                    this._endSugar = SugarNumericUpDownEnd.Value;
                }
            }
            else
            {
                this._startSugar = null;
                this._endSugar = null;
            }

            

            try
            {
                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PrintPropertiesGridView.AutoGenerateColumns = false;

                using (BM_Produce_ServiceReference.BM_Produce_ServiceClient serviceClient = new BM_Produce_ServiceReference.BM_Produce_ServiceClient())
                {
                    this.PrintPropertiesGridView.DataSource = serviceClient.GetBreedProperty(null, null, this._starTime, this._endTime, this._startSugar, this._endSugar, null, ref ErrorMessage);
                }
                if (!string.IsNullOrEmpty(ErrorMessage))
                    throw new Exception(ErrorMessage);


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FilterButton_Click()" + ErrorMessage);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }





        }

        private void PersonPostEndDateTitleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.EnddateTimePicker2.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
                this.StartdateTimePicker1.Enabled = this.PersonPostEndDateTitleCheckBox.Checked;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, " Source: PersonPostEndDateTitleCheckBox_CheckedChanged", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
            }
        }

        private void SugarCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.SugarNumericUpDownStart.Enabled = this.SugarCheckBox.Checked;
                this.SugarNumericUpDownEnd.Enabled = this.SugarCheckBox.Checked;
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
