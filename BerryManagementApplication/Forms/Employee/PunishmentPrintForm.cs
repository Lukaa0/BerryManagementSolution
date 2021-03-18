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
    public partial class PunishmentPrintForm : Form
    {

        private long _idForGrid;
        public PunishmentPrintForm(long Id)
        {
            InitializeComponent();
            _idForGrid = Id;
            FillPrintPunishmentGridView(_idForGrid);
        }

        private void FillPrintPunishmentGridView(long Id)
        {
            List<BM_Employee_ServiceReference.PunishmentModel> punishmentData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PrintPunishmentGridView.DataSource = null;
                this.PrintPunishmentGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {

                    punishmentData = EmployeeServiceClient.GetPunishment(Id,null, ref ErrorMessage);
                }
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    throw new Exception(ErrorMessage);
                }

                // შევავსოთ ცხრილი
                this.PrintPunishmentGridView.DataSource = punishmentData;

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
            FillPrintPunishmentGridView(_idForGrid);
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            if (EnddateTimePicker2.Value < StartdateTimePicker1.Value)
            {
                MessageBox.Show("დაფიქსირდა შეცდომა, გთხოვთ გადაამოწმოთ თარიღები");
                return;
            }
                

            List<BM_Employee_ServiceReference.PunishmentModel> punishmentData = null;
            string ErrorMessage = System.String.Empty;

            try
            {
                // მოლოდინის კურსორი
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;

                // დავცალოთ ცხრილი
                this.PrintPunishmentGridView.DataSource = null;
                this.PrintPunishmentGridView.AutoGenerateColumns = false;

                // ამოვიღოთ მონაცემები და შევავსოთ ცხრილი
                using (BM_Employee_ServiceReference.BM_Employee_ServiceClient EmployeeServiceClient = new BM_Employee_ServiceReference.BM_Employee_ServiceClient())
                {

                    punishmentData = EmployeeServiceClient.GetPunishmentByDite(_idForGrid, StartdateTimePicker1.Value.AddDays(-1), EnddateTimePicker2.Value.AddDays(-1), ref ErrorMessage);
                }
                if (!string.IsNullOrEmpty(ErrorMessage))
                {
                    throw new Exception(ErrorMessage);
                }

                // შევავსოთ ცხრილი
                this.PrintPunishmentGridView.DataSource = punishmentData;

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
    }
}
