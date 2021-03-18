namespace BerryManagementApplication.Forms.Employee
{
    partial class PunishmentPrintForm
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
            this.StartdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.EnddateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeFilterButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrintPunishmentGridView = new ThetaControlsLibrary.DataGridViewEI();
            this.PunishmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punishment_PunishmentType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Punishment_PunishmentType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PunishmentCareerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PunishmentEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PunishmentDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PunishmentType_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPunishmentGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartdateTimePicker1
            // 
            this.StartdateTimePicker1.Location = new System.Drawing.Point(234, 31);
            this.StartdateTimePicker1.Name = "StartdateTimePicker1";
            this.StartdateTimePicker1.Size = new System.Drawing.Size(312, 22);
            this.StartdateTimePicker1.TabIndex = 0;
            // 
            // EnddateTimePicker2
            // 
            this.EnddateTimePicker2.Location = new System.Drawing.Point(234, 86);
            this.EnddateTimePicker2.Name = "EnddateTimePicker2";
            this.EnddateTimePicker2.Size = new System.Drawing.Size(312, 22);
            this.EnddateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "საწყისი თარიღი";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeFilterButton);
            this.groupBox1.Controls.Add(this.FilterButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.EnddateTimePicker2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StartdateTimePicker1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 150);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "გაფილტვრა დროის მიხედვით";
            // 
            // DeFilterButton
            // 
            this.DeFilterButton.Location = new System.Drawing.Point(600, 77);
            this.DeFilterButton.Name = "DeFilterButton";
            this.DeFilterButton.Size = new System.Drawing.Size(136, 45);
            this.DeFilterButton.TabIndex = 5;
            this.DeFilterButton.Text = "ფილტრის მოხსნა";
            this.DeFilterButton.UseVisualStyleBackColor = true;
            this.DeFilterButton.Click += new System.EventHandler(this.DeFilterButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(600, 21);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(136, 45);
            this.FilterButton.TabIndex = 4;
            this.FilterButton.Text = "გაფილტვრა";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "საბოლოო თარიღი";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PrintPunishmentGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 150);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(800, 300);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // PrintPunishmentGridView
            // 
            this.PrintPunishmentGridView.AllowUserToAddRows = false;
            this.PrintPunishmentGridView.AllowUserToResizeRows = false;
            this.PrintPunishmentGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrintPunishmentGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PunishmentId,
            this.Punishment_PunishmentType_Id,
            this.Punishment_PunishmentType_Name,
            this.PunishmentCareerId,
            this.PunishmentEndDate,
            this.PunishmentDescription,
            this.PunishmentType_Description});
            this.PrintPunishmentGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintPunishmentGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.PrintPunishmentGridView.Location = new System.Drawing.Point(3, 18);
            this.PrintPunishmentGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrintPunishmentGridView.Name = "PrintPunishmentGridView";
            this.PrintPunishmentGridView.Size = new System.Drawing.Size(794, 279);
            this.PrintPunishmentGridView.TabIndex = 1;
            this.PrintPunishmentGridView.Tag = "155";
            // 
            // PunishmentId
            // 
            this.PunishmentId.DataPropertyName = "Punishment_Id";
            this.PunishmentId.HeaderText = "ჩანაწერის იდენტიფიკატორი";
            this.PunishmentId.Name = "PunishmentId";
            this.PunishmentId.Visible = false;
            this.PunishmentId.Width = 188;
            // 
            // Punishment_PunishmentType_Id
            // 
            this.Punishment_PunishmentType_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Punishment_PunishmentType_Id.DataPropertyName = "Punishment_PunishmentType_Id";
            this.Punishment_PunishmentType_Id.HeaderText = "სასჯელის ტიპის იდენტიფიკატორი";
            this.Punishment_PunishmentType_Id.Name = "Punishment_PunishmentType_Id";
            this.Punishment_PunishmentType_Id.Visible = false;
            // 
            // Punishment_PunishmentType_Name
            // 
            this.Punishment_PunishmentType_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Punishment_PunishmentType_Name.DataPropertyName = "PunishmentType_Name";
            this.Punishment_PunishmentType_Name.HeaderText = "სასჯელის ტიპი";
            this.Punishment_PunishmentType_Name.Name = "Punishment_PunishmentType_Name";
            // 
            // PunishmentCareerId
            // 
            this.PunishmentCareerId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PunishmentCareerId.DataPropertyName = "Punishment_PersonPost_Id";
            this.PunishmentCareerId.HeaderText = "კარიერის იდენტიფიკატორი";
            this.PunishmentCareerId.Name = "PunishmentCareerId";
            this.PunishmentCareerId.Visible = false;
            // 
            // PunishmentEndDate
            // 
            this.PunishmentEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PunishmentEndDate.DataPropertyName = "Punishment_DateTime";
            this.PunishmentEndDate.HeaderText = "თარიღი";
            this.PunishmentEndDate.Name = "PunishmentEndDate";
            // 
            // PunishmentDescription
            // 
            this.PunishmentDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PunishmentDescription.DataPropertyName = "Punishment_User_PersonPost_Id";
            this.PunishmentDescription.HeaderText = "იუსერი";
            this.PunishmentDescription.Name = "PunishmentDescription";
            this.PunishmentDescription.Visible = false;
            // 
            // PunishmentType_Description
            // 
            this.PunishmentType_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PunishmentType_Description.DataPropertyName = "PunishmentType_Description";
            this.PunishmentType_Description.HeaderText = "კომენტარი";
            this.PunishmentType_Description.Name = "PunishmentType_Description";
            // 
            // PunishmentPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PunishmentPrintForm";
            this.Text = "სასჯელის ბეჭდვა";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrintPunishmentGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartdateTimePicker1;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeFilterButton;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ThetaControlsLibrary.DataGridViewEI PrintPunishmentGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PunishmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punishment_PunishmentType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Punishment_PunishmentType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PunishmentCareerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PunishmentEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PunishmentDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn PunishmentType_Description;
    }
}