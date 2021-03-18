namespace BerryManagementApplication.Forms.Operation
{
    partial class BrigadeRowEditForm
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
            this.BrigadeComboBox = new System.Windows.Forms.ComboBox();
            this.BrigadeLabel = new System.Windows.Forms.Label();
            this.BrigadeRowGroupBox = new System.Windows.Forms.GroupBox();
            this.BrigadeRowDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllRowGroupBox = new System.Windows.Forms.GroupBox();
            this.AllRowDataGridView = new System.Windows.Forms.DataGridView();
            this.RemoveRowButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.Brigade_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Row_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Brigade_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Barcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_In_TakeRowInOut_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_In_TUser_PersonPost_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_In_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Out_TakeRowInOut_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Out_User_PersonPost_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TakeRow_Out_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrigadeRowGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BrigadeRowDataGridView)).BeginInit();
            this.AllRowGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllRowDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(554, 402);
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
            this.RollbackButton.Location = new System.Drawing.Point(713, 402);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // BrigadeComboBox
            // 
            this.BrigadeComboBox.FormattingEnabled = true;
            this.BrigadeComboBox.Location = new System.Drawing.Point(326, 40);
            this.BrigadeComboBox.Name = "BrigadeComboBox";
            this.BrigadeComboBox.Size = new System.Drawing.Size(359, 24);
            this.BrigadeComboBox.TabIndex = 67;
            this.BrigadeComboBox.SelectedIndexChanged += new System.EventHandler(this.BrigadeComboBox_SelectedIndexChanged);
            // 
            // BrigadeLabel
            // 
            this.BrigadeLabel.AutoSize = true;
            this.BrigadeLabel.Location = new System.Drawing.Point(199, 43);
            this.BrigadeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BrigadeLabel.Name = "BrigadeLabel";
            this.BrigadeLabel.Size = new System.Drawing.Size(57, 17);
            this.BrigadeLabel.TabIndex = 66;
            this.BrigadeLabel.Text = "ჯგუფი";
            // 
            // BrigadeRowGroupBox
            // 
            this.BrigadeRowGroupBox.Controls.Add(this.BrigadeRowDataGridView);
            this.BrigadeRowGroupBox.Location = new System.Drawing.Point(554, 118);
            this.BrigadeRowGroupBox.Name = "BrigadeRowGroupBox";
            this.BrigadeRowGroupBox.Size = new System.Drawing.Size(519, 252);
            this.BrigadeRowGroupBox.TabIndex = 85;
            this.BrigadeRowGroupBox.TabStop = false;
            this.BrigadeRowGroupBox.Text = "არჩეული რიგები";
            // 
            // BrigadeRowDataGridView
            // 
            this.BrigadeRowDataGridView.AllowUserToAddRows = false;
            this.BrigadeRowDataGridView.AllowUserToDeleteRows = false;
            this.BrigadeRowDataGridView.AllowUserToResizeRows = false;
            this.BrigadeRowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrigadeRowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11});
            this.BrigadeRowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrigadeRowDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.BrigadeRowDataGridView.Location = new System.Drawing.Point(3, 18);
            this.BrigadeRowDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.BrigadeRowDataGridView.Name = "BrigadeRowDataGridView";
            this.BrigadeRowDataGridView.ReadOnly = true;
            this.BrigadeRowDataGridView.Size = new System.Drawing.Size(513, 231);
            this.BrigadeRowDataGridView.TabIndex = 2;
            this.BrigadeRowDataGridView.Tag = "155";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Brigade_Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "ჯგუფის სახელი";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TakeRow_Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "TakeRow_Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TakeRow_Row_Id ";
            this.dataGridViewTextBoxColumn3.HeaderText = "TakeRow_Row_Id ";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TakeRow_Brigade_Id";
            this.dataGridViewTextBoxColumn4.HeaderText = "TakeRow_Brigade_Id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Row_Barcode";
            this.dataGridViewTextBoxColumn5.HeaderText = "რიგის ბარკოდი";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TakeRow_In_TakeRowInOut_Id";
            this.dataGridViewTextBoxColumn6.HeaderText = "TakeRow_In_TakeRowInOut_Id";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TakeRow_In_TUser_PersonPost_Id";
            this.dataGridViewTextBoxColumn7.HeaderText = "TakeRow_In_TUser_PersonPost_Id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TakeRow_In_DateTime";
            this.dataGridViewTextBoxColumn8.HeaderText = "რიგის გახსნის დრო";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "TakeRow_Out_TakeRowInOut_Id";
            this.dataGridViewTextBoxColumn9.HeaderText = "TakeRow_Out_TakeRowInOut_Id";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "TakeRow_Out_User_PersonPost_Id";
            this.dataGridViewTextBoxColumn10.HeaderText = "TakeRow_Out_User_PersonPost_Id";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "TakeRow_Out_DateTime";
            this.dataGridViewTextBoxColumn11.HeaderText = "TakeRow_Out_DateTime";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // AllRowGroupBox
            // 
            this.AllRowGroupBox.Controls.Add(this.AllRowDataGridView);
            this.AllRowGroupBox.Location = new System.Drawing.Point(27, 118);
            this.AllRowGroupBox.Name = "AllRowGroupBox";
            this.AllRowGroupBox.Size = new System.Drawing.Size(422, 252);
            this.AllRowGroupBox.TabIndex = 84;
            this.AllRowGroupBox.TabStop = false;
            this.AllRowGroupBox.Text = "ასარჩევი რიგები";
            // 
            // AllRowDataGridView
            // 
            this.AllRowDataGridView.AllowUserToAddRows = false;
            this.AllRowDataGridView.AllowUserToDeleteRows = false;
            this.AllRowDataGridView.AllowUserToResizeRows = false;
            this.AllRowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllRowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Brigade_Name,
            this.TakeRow_Id,
            this.TakeRow_Row_Id,
            this.TakeRow_Brigade_Id,
            this.Row_Barcode,
            this.TakeRow_In_TakeRowInOut_Id,
            this.TakeRow_In_TUser_PersonPost_Id,
            this.TakeRow_In_DateTime,
            this.TakeRow_Out_TakeRowInOut_Id,
            this.TakeRow_Out_User_PersonPost_Id,
            this.TakeRow_Out_DateTime});
            this.AllRowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllRowDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AllRowDataGridView.Location = new System.Drawing.Point(3, 18);
            this.AllRowDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AllRowDataGridView.Name = "AllRowDataGridView";
            this.AllRowDataGridView.ReadOnly = true;
            this.AllRowDataGridView.Size = new System.Drawing.Size(416, 231);
            this.AllRowDataGridView.TabIndex = 1;
            this.AllRowDataGridView.Tag = "155";
            // 
            // RemoveRowButton
            // 
            this.RemoveRowButton.Location = new System.Drawing.Point(458, 288);
            this.RemoveRowButton.Name = "RemoveRowButton";
            this.RemoveRowButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveRowButton.TabIndex = 83;
            this.RemoveRowButton.Text = "<<";
            this.RemoveRowButton.UseVisualStyleBackColor = true;
            this.RemoveRowButton.Click += new System.EventHandler(this.RemoveRowButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(455, 188);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(75, 23);
            this.AddRowButton.TabIndex = 82;
            this.AddRowButton.Text = ">>";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // Brigade_Name
            // 
            this.Brigade_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brigade_Name.DataPropertyName = "Brigade_Name";
            this.Brigade_Name.HeaderText = "ჯგუფის სახელი";
            this.Brigade_Name.Name = "Brigade_Name";
            this.Brigade_Name.ReadOnly = true;
            this.Brigade_Name.Visible = false;
            // 
            // TakeRow_Id
            // 
            this.TakeRow_Id.DataPropertyName = "TakeRow_Id";
            this.TakeRow_Id.HeaderText = "TakeRow_Id";
            this.TakeRow_Id.Name = "TakeRow_Id";
            this.TakeRow_Id.ReadOnly = true;
            this.TakeRow_Id.Visible = false;
            // 
            // TakeRow_Row_Id
            // 
            this.TakeRow_Row_Id.DataPropertyName = "TakeRow_Row_Id ";
            this.TakeRow_Row_Id.HeaderText = "TakeRow_Row_Id ";
            this.TakeRow_Row_Id.Name = "TakeRow_Row_Id";
            this.TakeRow_Row_Id.ReadOnly = true;
            this.TakeRow_Row_Id.Visible = false;
            // 
            // TakeRow_Brigade_Id
            // 
            this.TakeRow_Brigade_Id.DataPropertyName = "TakeRow_Brigade_Id";
            this.TakeRow_Brigade_Id.HeaderText = "TakeRow_Brigade_Id";
            this.TakeRow_Brigade_Id.Name = "TakeRow_Brigade_Id";
            this.TakeRow_Brigade_Id.ReadOnly = true;
            this.TakeRow_Brigade_Id.Visible = false;
            // 
            // Row_Barcode
            // 
            this.Row_Barcode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Barcode.DataPropertyName = "Row_Barcode";
            this.Row_Barcode.HeaderText = "რიგის ბარკოდი";
            this.Row_Barcode.Name = "Row_Barcode";
            this.Row_Barcode.ReadOnly = true;
            // 
            // TakeRow_In_TakeRowInOut_Id
            // 
            this.TakeRow_In_TakeRowInOut_Id.DataPropertyName = "TakeRow_In_TakeRowInOut_Id";
            this.TakeRow_In_TakeRowInOut_Id.HeaderText = "TakeRow_In_TakeRowInOut_Id";
            this.TakeRow_In_TakeRowInOut_Id.Name = "TakeRow_In_TakeRowInOut_Id";
            this.TakeRow_In_TakeRowInOut_Id.ReadOnly = true;
            this.TakeRow_In_TakeRowInOut_Id.Visible = false;
            // 
            // TakeRow_In_TUser_PersonPost_Id
            // 
            this.TakeRow_In_TUser_PersonPost_Id.DataPropertyName = "TakeRow_In_TUser_PersonPost_Id";
            this.TakeRow_In_TUser_PersonPost_Id.HeaderText = "TakeRow_In_TUser_PersonPost_Id";
            this.TakeRow_In_TUser_PersonPost_Id.Name = "TakeRow_In_TUser_PersonPost_Id";
            this.TakeRow_In_TUser_PersonPost_Id.ReadOnly = true;
            this.TakeRow_In_TUser_PersonPost_Id.Visible = false;
            // 
            // TakeRow_In_DateTime
            // 
            this.TakeRow_In_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TakeRow_In_DateTime.DataPropertyName = "TakeRow_In_DateTime";
            this.TakeRow_In_DateTime.HeaderText = "რიგის გახსნის დრო";
            this.TakeRow_In_DateTime.Name = "TakeRow_In_DateTime";
            this.TakeRow_In_DateTime.ReadOnly = true;
            // 
            // TakeRow_Out_TakeRowInOut_Id
            // 
            this.TakeRow_Out_TakeRowInOut_Id.DataPropertyName = "TakeRow_Out_TakeRowInOut_Id";
            this.TakeRow_Out_TakeRowInOut_Id.HeaderText = "TakeRow_Out_TakeRowInOut_Id";
            this.TakeRow_Out_TakeRowInOut_Id.Name = "TakeRow_Out_TakeRowInOut_Id";
            this.TakeRow_Out_TakeRowInOut_Id.ReadOnly = true;
            this.TakeRow_Out_TakeRowInOut_Id.Visible = false;
            // 
            // TakeRow_Out_User_PersonPost_Id
            // 
            this.TakeRow_Out_User_PersonPost_Id.DataPropertyName = "TakeRow_Out_User_PersonPost_Id";
            this.TakeRow_Out_User_PersonPost_Id.HeaderText = "TakeRow_Out_User_PersonPost_Id";
            this.TakeRow_Out_User_PersonPost_Id.Name = "TakeRow_Out_User_PersonPost_Id";
            this.TakeRow_Out_User_PersonPost_Id.ReadOnly = true;
            this.TakeRow_Out_User_PersonPost_Id.Visible = false;
            // 
            // TakeRow_Out_DateTime
            // 
            this.TakeRow_Out_DateTime.DataPropertyName = "TakeRow_Out_DateTime";
            this.TakeRow_Out_DateTime.HeaderText = "TakeRow_Out_DateTime";
            this.TakeRow_Out_DateTime.Name = "TakeRow_Out_DateTime";
            this.TakeRow_Out_DateTime.ReadOnly = true;
            this.TakeRow_Out_DateTime.Visible = false;
            // 
            // BrigadeRowEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 453);
            this.Controls.Add(this.BrigadeRowGroupBox);
            this.Controls.Add(this.AllRowGroupBox);
            this.Controls.Add(this.RemoveRowButton);
            this.Controls.Add(this.AddRowButton);
            this.Controls.Add(this.BrigadeComboBox);
            this.Controls.Add(this.BrigadeLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrigadeRowEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ჯგუფის გადანაწილება";
            this.Load += new System.EventHandler(this.BrigadeRowEditForm_Load);
            this.BrigadeRowGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BrigadeRowDataGridView)).EndInit();
            this.AllRowGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllRowDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox BrigadeComboBox;
        private System.Windows.Forms.Label BrigadeLabel;
        private System.Windows.Forms.GroupBox BrigadeRowGroupBox;
        private System.Windows.Forms.GroupBox AllRowGroupBox;
        private System.Windows.Forms.DataGridView AllRowDataGridView;
        private System.Windows.Forms.Button RemoveRowButton;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.DataGridView BrigadeRowDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brigade_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Row_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Brigade_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Barcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_In_TakeRowInOut_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_In_TUser_PersonPost_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_In_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Out_TakeRowInOut_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Out_User_PersonPost_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TakeRow_Out_DateTime;
    }
}