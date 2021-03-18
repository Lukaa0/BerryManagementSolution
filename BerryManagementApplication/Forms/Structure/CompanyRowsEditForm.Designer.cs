namespace BerryManagementApplication.Forms.Structure
{
    partial class CompanyRowsEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CompanyComboBox = new System.Windows.Forms.ComboBox();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.PersonPostEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.AllRowsDataGridView = new System.Windows.Forms.DataGridView();
            this.AddSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Row_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sector_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Subrow_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Barkode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRowsDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.CompanyRow_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Row_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Row_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Row_Subrow_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Row_Barkode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_Sector_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddRowsButton = new System.Windows.Forms.Button();
            this.RemoveRowsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AllRowsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyRowsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(756, 410);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(125, 36);
            this.CommitButton.TabIndex = 41;
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(921, 410);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(395, 108);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.EndDateTimePicker.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(729, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 72;
            this.label2.Text = "*";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(395, 65);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.StartDateTimePicker.TabIndex = 71;
            // 
            // CompanyComboBox
            // 
            this.CompanyComboBox.FormattingEnabled = true;
            this.CompanyComboBox.Location = new System.Drawing.Point(395, 21);
            this.CompanyComboBox.Name = "CompanyComboBox";
            this.CompanyComboBox.Size = new System.Drawing.Size(328, 24);
            this.CompanyComboBox.TabIndex = 1;
            this.CompanyComboBox.SelectedIndexChanged += new System.EventHandler(this.CompanyComboBox_SelectedIndexChanged);
            this.CompanyComboBox.SelectionChangeCommitted += new System.EventHandler(this.CompanyComboBox_SelectionChangeCommitted);
            this.CompanyComboBox.SelectedValueChanged += new System.EventHandler(this.CompanyComboBox_SelectedValueChanged);
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Location = new System.Drawing.Point(318, 24);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(67, 17);
            this.CompanyLabel.TabIndex = 66;
            this.CompanyLabel.Text = "კომპანია";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(729, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 65;
            this.label4.Text = "*";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(251, 70);
            this.StartDateLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(134, 17);
            this.StartDateLabel.TabIndex = 62;
            this.StartDateLabel.Text = "დაწყების თარიღი";
            // 
            // PersonPostEndDateTitleCheckBox
            // 
            this.PersonPostEndDateTitleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.Location = new System.Drawing.Point(236, 107);
            this.PersonPostEndDateTitleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostEndDateTitleCheckBox.Name = "PersonPostEndDateTitleCheckBox";
            this.PersonPostEndDateTitleCheckBox.Size = new System.Drawing.Size(149, 23);
            this.PersonPostEndDateTitleCheckBox.TabIndex = 75;
            this.PersonPostEndDateTitleCheckBox.Tag = "-1";
            this.PersonPostEndDateTitleCheckBox.Text = "დასრულების თარიღი";
            this.PersonPostEndDateTitleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.UseVisualStyleBackColor = true;
            this.PersonPostEndDateTitleCheckBox.CheckedChanged += new System.EventHandler(this.PersonPostEndDateTitleCheckBox_CheckedChanged);
            // 
            // AllRowsDataGridView
            // 
            this.AllRowsDataGridView.AllowUserToAddRows = false;
            this.AllRowsDataGridView.AllowUserToDeleteRows = false;
            this.AllRowsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllRowsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AddSelected,
            this.Row_Id,
            this.Sector_Number,
            this.Row_Number,
            this.Row_Subrow_Number,
            this.Row_Barkode});
            this.AllRowsDataGridView.Location = new System.Drawing.Point(11, 157);
            this.AllRowsDataGridView.Name = "AllRowsDataGridView";
            this.AllRowsDataGridView.ReadOnly = true;
            this.AllRowsDataGridView.RowTemplate.Height = 24;
            this.AllRowsDataGridView.Size = new System.Drawing.Size(374, 223);
            this.AllRowsDataGridView.TabIndex = 76;
            // 
            // AddSelected
            // 
            this.AddSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AddSelected.DataPropertyName = "AddSelected";
            this.AddSelected.FalseValue = "";
            this.AddSelected.HeaderText = "მონიშვნა";
            this.AddSelected.Name = "AddSelected";
            this.AddSelected.ReadOnly = true;
            this.AddSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.AddSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.AddSelected.TrueValue = "1";
            this.AddSelected.Visible = false;
            // 
            // Row_Id
            // 
            this.Row_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Id.HeaderText = "Row_Id";
            this.Row_Id.Name = "Row_Id";
            this.Row_Id.ReadOnly = true;
            this.Row_Id.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Row_Id.Visible = false;
            // 
            // Sector_Number
            // 
            this.Sector_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sector_Number.DataPropertyName = "Sector_Number";
            this.Sector_Number.HeaderText = "Sector_Number";
            this.Sector_Number.Name = "Sector_Number";
            this.Sector_Number.ReadOnly = true;
            this.Sector_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sector_Number.Visible = false;
            // 
            // Row_Number
            // 
            this.Row_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Number.DataPropertyName = "Row_Number";
            this.Row_Number.HeaderText = "Row_Number";
            this.Row_Number.Name = "Row_Number";
            this.Row_Number.ReadOnly = true;
            this.Row_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Row_Number.Visible = false;
            // 
            // Row_Subrow_Number
            // 
            this.Row_Subrow_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Subrow_Number.DataPropertyName = "Row_Subrow_Number";
            this.Row_Subrow_Number.HeaderText = "Row_Subrow_Number";
            this.Row_Subrow_Number.Name = "Row_Subrow_Number";
            this.Row_Subrow_Number.ReadOnly = true;
            this.Row_Subrow_Number.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Row_Subrow_Number.Visible = false;
            // 
            // Row_Barkode
            // 
            this.Row_Barkode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Barkode.DataPropertyName = "Row_Barkode";
            this.Row_Barkode.HeaderText = "რიგის ბარკოდი";
            this.Row_Barkode.Name = "Row_Barkode";
            this.Row_Barkode.ReadOnly = true;
            this.Row_Barkode.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // CompanyRowsDataGridView
            // 
            this.CompanyRowsDataGridView.AllowUserToAddRows = false;
            this.CompanyRowsDataGridView.AllowUserToDeleteRows = false;
            this.CompanyRowsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyRowsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RemoveSelected,
            this.CompanyRow_Id,
            this.CompanyRow_Company_Id,
            this.CompanyRow_Company_Name,
            this.CompanyRow_Row_Id,
            this.CompanyRow_Row_Number,
            this.CompanyRow_Row_Subrow_Number,
            this.CompanyRow_Row_Barkode,
            this.CompanyRow_Sector_Number,
            this.CompanyRow_StartDate,
            this.CompanyRow_EndDate});
            this.CompanyRowsDataGridView.Location = new System.Drawing.Point(476, 157);
            this.CompanyRowsDataGridView.Name = "CompanyRowsDataGridView";
            this.CompanyRowsDataGridView.ReadOnly = true;
            this.CompanyRowsDataGridView.RowTemplate.Height = 24;
            this.CompanyRowsDataGridView.Size = new System.Drawing.Size(570, 223);
            this.CompanyRowsDataGridView.TabIndex = 77;
            // 
            // RemoveSelected
            // 
            this.RemoveSelected.DataPropertyName = "RemoveSelected";
            this.RemoveSelected.FalseValue = "";
            this.RemoveSelected.FillWeight = 126.9036F;
            this.RemoveSelected.HeaderText = "მონიშვნა";
            this.RemoveSelected.Name = "RemoveSelected";
            this.RemoveSelected.ReadOnly = true;
            this.RemoveSelected.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.RemoveSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RemoveSelected.TrueValue = "";
            this.RemoveSelected.Visible = false;
            this.RemoveSelected.Width = 90;
            // 
            // CompanyRow_Id
            // 
            this.CompanyRow_Id.DataPropertyName = "CompanyRow_Id";
            this.CompanyRow_Id.HeaderText = "CompanyRow_Id";
            this.CompanyRow_Id.Name = "CompanyRow_Id";
            this.CompanyRow_Id.ReadOnly = true;
            this.CompanyRow_Id.Visible = false;
            // 
            // CompanyRow_Company_Id
            // 
            this.CompanyRow_Company_Id.DataPropertyName = "CompanyRow_Company_Id";
            this.CompanyRow_Company_Id.HeaderText = "CompanyRow_Company_Id";
            this.CompanyRow_Company_Id.Name = "CompanyRow_Company_Id";
            this.CompanyRow_Company_Id.ReadOnly = true;
            this.CompanyRow_Company_Id.Visible = false;
            // 
            // CompanyRow_Company_Name
            // 
            this.CompanyRow_Company_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_Company_Name.DataPropertyName = "CompanyRow_Company_Name";
            this.CompanyRow_Company_Name.FillWeight = 93.27411F;
            this.CompanyRow_Company_Name.HeaderText = "სახელი";
            this.CompanyRow_Company_Name.Name = "CompanyRow_Company_Name";
            this.CompanyRow_Company_Name.ReadOnly = true;
            // 
            // CompanyRow_Row_Id
            // 
            this.CompanyRow_Row_Id.DataPropertyName = "CompanyRow_Row_Id";
            this.CompanyRow_Row_Id.HeaderText = "CompanyRow_Row_Id";
            this.CompanyRow_Row_Id.Name = "CompanyRow_Row_Id";
            this.CompanyRow_Row_Id.ReadOnly = true;
            this.CompanyRow_Row_Id.Visible = false;
            // 
            // CompanyRow_Row_Number
            // 
            this.CompanyRow_Row_Number.DataPropertyName = "CompanyRow_Row_Number";
            this.CompanyRow_Row_Number.HeaderText = "CompanyRow_Row_Number";
            this.CompanyRow_Row_Number.Name = "CompanyRow_Row_Number";
            this.CompanyRow_Row_Number.ReadOnly = true;
            this.CompanyRow_Row_Number.Visible = false;
            // 
            // CompanyRow_Row_Subrow_Number
            // 
            this.CompanyRow_Row_Subrow_Number.DataPropertyName = "CompanyRow_Row_Subrow_Number";
            this.CompanyRow_Row_Subrow_Number.HeaderText = "CompanyRow_Row_Subrow_Number";
            this.CompanyRow_Row_Subrow_Number.Name = "CompanyRow_Row_Subrow_Number";
            this.CompanyRow_Row_Subrow_Number.ReadOnly = true;
            this.CompanyRow_Row_Subrow_Number.Visible = false;
            // 
            // CompanyRow_Row_Barkode
            // 
            this.CompanyRow_Row_Barkode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_Row_Barkode.DataPropertyName = "CompanyRow_Row_Barkode";
            this.CompanyRow_Row_Barkode.FillWeight = 93.27411F;
            this.CompanyRow_Row_Barkode.HeaderText = "ბარკოდი";
            this.CompanyRow_Row_Barkode.Name = "CompanyRow_Row_Barkode";
            this.CompanyRow_Row_Barkode.ReadOnly = true;
            // 
            // CompanyRow_Sector_Number
            // 
            this.CompanyRow_Sector_Number.DataPropertyName = "CompanyRow_Sector_Number";
            this.CompanyRow_Sector_Number.HeaderText = "CompanyRow_Sector_Number";
            this.CompanyRow_Sector_Number.Name = "CompanyRow_Sector_Number";
            this.CompanyRow_Sector_Number.ReadOnly = true;
            this.CompanyRow_Sector_Number.Visible = false;
            // 
            // CompanyRow_StartDate
            // 
            this.CompanyRow_StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_StartDate.DataPropertyName = "CompanyRow_StartDate";
            this.CompanyRow_StartDate.FillWeight = 93.27411F;
            this.CompanyRow_StartDate.HeaderText = "დაწყება";
            this.CompanyRow_StartDate.Name = "CompanyRow_StartDate";
            this.CompanyRow_StartDate.ReadOnly = true;
            // 
            // CompanyRow_EndDate
            // 
            this.CompanyRow_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_EndDate.DataPropertyName = "CompanyRow_EndDate";
            this.CompanyRow_EndDate.FillWeight = 93.27411F;
            this.CompanyRow_EndDate.HeaderText = "დასრულება";
            this.CompanyRow_EndDate.Name = "CompanyRow_EndDate";
            this.CompanyRow_EndDate.ReadOnly = true;
            // 
            // AddRowsButton
            // 
            this.AddRowsButton.Location = new System.Drawing.Point(395, 218);
            this.AddRowsButton.Name = "AddRowsButton";
            this.AddRowsButton.Size = new System.Drawing.Size(75, 23);
            this.AddRowsButton.TabIndex = 78;
            this.AddRowsButton.Text = ">>";
            this.AddRowsButton.UseVisualStyleBackColor = true;
            this.AddRowsButton.Click += new System.EventHandler(this.AddRowsButton_Click);
            // 
            // RemoveRowsButton
            // 
            this.RemoveRowsButton.Location = new System.Drawing.Point(395, 270);
            this.RemoveRowsButton.Name = "RemoveRowsButton";
            this.RemoveRowsButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveRowsButton.TabIndex = 79;
            this.RemoveRowsButton.Text = "<<";
            this.RemoveRowsButton.UseVisualStyleBackColor = true;
            this.RemoveRowsButton.Click += new System.EventHandler(this.RemoveRowsButton_Click);
            // 
            // CompanyRowsEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 479);
            this.Controls.Add(this.RemoveRowsButton);
            this.Controls.Add(this.AddRowsButton);
            this.Controls.Add(this.CompanyRowsDataGridView);
            this.Controls.Add(this.AllRowsDataGridView);
            this.Controls.Add(this.PersonPostEndDateTitleCheckBox);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.CompanyComboBox);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyRowsEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyRowsEditForm_FormClosing);
            this.Load += new System.EventHandler(this.CompanyRowEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AllRowsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyRowsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.ComboBox CompanyComboBox;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.CheckBox PersonPostEndDateTitleCheckBox;
        private System.Windows.Forms.DataGridView AllRowsDataGridView;
        private System.Windows.Forms.DataGridView CompanyRowsDataGridView;
        private System.Windows.Forms.Button AddRowsButton;
        private System.Windows.Forms.Button RemoveRowsButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn AddSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sector_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Subrow_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Barkode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RemoveSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Row_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Row_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Row_Subrow_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Row_Barkode;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Sector_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_EndDate;
    }
}