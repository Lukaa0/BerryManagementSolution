using BerryManagementApplication.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BerryManagementApplication.Forms.Operations
{
    public partial class ClosedRows : Form
    {


        public ClosedRows()
        {
            InitializeComponent();

            FillTakeRowRowDataGridView(DateTime.Today);


            this.TimePicker.CustomFormat = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            this.TimePicker.Format = DateTimePickerFormat.Custom;
        }

        private void FillTakeRowRowDataGridView(DateTime day)
        {
            string ErrorMessage = System.String.Empty;

            try
            {
                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.TakeRowRowDataGridView.AutoGenerateColumns = false;

                using (BM_Operation_ServiceReference.BM_Operation_ServiceClient serviceClient = new BM_Operation_ServiceReference.BM_Operation_ServiceClient())
                {
                    this.TakeRowRowDataGridView.DataSource = serviceClient.GetClosedTakeRowsModel(day, day.AddDays(+1), ref ErrorMessage);
                }
                if (!string.IsNullOrEmpty(ErrorMessage))
                    throw new Exception(ErrorMessage);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + " Source: FillTakeRowRowDataGridView()" + ErrorMessage);
            }
            finally
            {
                // აღვადგინოთ კურსორი
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void DeFilterButton_Click(object sender, EventArgs e)
        {
            FillTakeRowRowDataGridView(DateTime.Today);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            FillTakeRowRowDataGridView(TimePicker.Value.AddDays(-1));
        }
    }
}
