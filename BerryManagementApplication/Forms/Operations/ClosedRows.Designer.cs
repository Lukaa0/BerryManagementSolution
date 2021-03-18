namespace BerryManagementApplication.Forms.Operations
{
    partial class ClosedRows
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
            this.TakeRowRowDataGridView = new ThetaControlsLibrary.DataGridViewEI();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeFilterButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.TimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Brigade_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_In_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Out_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TakeRowRowDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TakeRowRowDataGridView
            // 
            this.TakeRowRowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TakeRowRowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Brigade_Name,
            this.Row_Barcode,
            this.TakeRow_In_DateTime,
            this.TakeRow_Out_DateTime});
            this.TakeRowRowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TakeRowRowDataGridView.Location = new System.Drawing.Point(3, 18);
            this.TakeRowRowDataGridView.Name = "TakeRowRowDataGridView";
            this.TakeRowRowDataGridView.RowTemplate.Height = 24;
            this.TakeRowRowDataGridView.Size = new System.Drawing.Size(977, 272);
            this.TakeRowRowDataGridView.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeFilterButton);
            this.groupBox1.Controls.Add(this.FilterButton);
            this.groupBox1.Controls.Add(this.TimePicker);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(983, 145);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // DeFilterButton
            // 
            this.DeFilterButton.Location = new System.Drawing.Point(745, 58);
            this.DeFilterButton.Name = "DeFilterButton";
            this.DeFilterButton.Size = new System.Drawing.Size(136, 45);
            this.DeFilterButton.TabIndex = 6;
            this.DeFilterButton.Text = "ფილტრის მოხსნა";
            this.DeFilterButton.UseVisualStyleBackColor = true;
            this.DeFilterButton.Click += new System.EventHandler(this.DeFilterButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(567, 58);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(136, 45);
            this.FilterButton.TabIndex = 5;
            this.FilterButton.Text = "გაფილტვრა";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // TimePicker
            // 
            this.TimePicker.Location = new System.Drawing.Point(200, 71);
            this.TimePicker.Name = "TimePicker";
            this.TimePicker.Size = new System.Drawing.Size(328, 22);
            this.TimePicker.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "თარიღი";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TakeRowRowDataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(983, 293);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "რიგები";
            // 
            // Brigade_Name
            // 
            this.Brigade_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brigade_Name.DataPropertyName = "Brigade_Name";
            this.Brigade_Name.HeaderText = "ჯგუფის სახელი";
            this.Brigade_Name.Name = "Brigade_Name";
            // 
            // Row_Barcode
            // 
            this.Row_Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Barcode.DataPropertyName = "Row_Barcode";
            this.Row_Barcode.HeaderText = "რიგის კოდი";
            this.Row_Barcode.Name = "Row_Barcode";
            // 
            // TakeRow_In_DateTime
            // 
            this.TakeRow_In_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TakeRow_In_DateTime.DataPropertyName = "TakeRow_In_DateTime";
            this.TakeRow_In_DateTime.HeaderText = "რიგის გახსნის დრო";
            this.TakeRow_In_DateTime.Name = "TakeRow_In_DateTime";
            // 
            // TakeRow_Out_DateTime
            // 
            this.TakeRow_Out_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TakeRow_Out_DateTime.DataPropertyName = "TakeRow_Out_DateTime";
            this.TakeRow_Out_DateTime.HeaderText = "რიგის დახურვის დრო";
            this.TakeRow_Out_DateTime.Name = "TakeRow_Out_DateTime";
            // 
            // ClosedRows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 438);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClosedRows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "დახურული რიგები";
            ((System.ComponentModel.ISupportInitialize)(this.TakeRowRowDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ThetaControlsLibrary.DataGridViewEI TakeRowRowDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker TimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Button DeFilterButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brigade_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_In_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Out_DateTime;
    }
}