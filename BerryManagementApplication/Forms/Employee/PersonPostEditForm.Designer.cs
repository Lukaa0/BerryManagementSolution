namespace BerryManagementApplication.Forms.Employee
{
    partial class PersonPostEditForm
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
            this.PersonPostMainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PersonPostFixedDataGroupBox = new System.Windows.Forms.GroupBox();
            this.EmployeeFullNameValueLabel = new System.Windows.Forms.Label();
            this.EmployeeFullNameTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostEditedDataGroupBox = new System.Windows.Forms.GroupBox();
            this.PersonPostEmployeeTypeTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostEmployeeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.PersonPostDismissalOrderValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonPostDismissalOrderTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostPostTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostPostValueComboBox = new System.Windows.Forms.ComboBox();
            this.PersonPostBrigadeValueComboBox = new System.Windows.Forms.ComboBox();
            this.PersonPostBrigadeTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.PersonPostDescriptionValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonPostEndDateValueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PersonPostStartDateValueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PersonPostStartDateTitleLabel = new System.Windows.Forms.Label();
            this.PersonPostDescriptionTitleLabel = new System.Windows.Forms.Label();
            this.CareerButtonsPanel = new System.Windows.Forms.Panel();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.PersonPostMainTableLayoutPanel.SuspendLayout();
            this.PersonPostFixedDataGroupBox.SuspendLayout();
            this.PersonPostEditedDataGroupBox.SuspendLayout();
            this.CareerButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersonPostMainTableLayoutPanel
            // 
            this.PersonPostMainTableLayoutPanel.AutoScroll = true;
            this.PersonPostMainTableLayoutPanel.ColumnCount = 1;
            this.PersonPostMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PersonPostMainTableLayoutPanel.Controls.Add(this.PersonPostFixedDataGroupBox, 0, 0);
            this.PersonPostMainTableLayoutPanel.Controls.Add(this.PersonPostEditedDataGroupBox, 0, 1);
            this.PersonPostMainTableLayoutPanel.Controls.Add(this.CareerButtonsPanel, 0, 2);
            this.PersonPostMainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPostMainTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.PersonPostMainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PersonPostMainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostMainTableLayoutPanel.Name = "PersonPostMainTableLayoutPanel";
            this.PersonPostMainTableLayoutPanel.RowCount = 3;
            this.PersonPostMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.PersonPostMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PersonPostMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.PersonPostMainTableLayoutPanel.Size = new System.Drawing.Size(612, 450);
            this.PersonPostMainTableLayoutPanel.TabIndex = 9;
            this.PersonPostMainTableLayoutPanel.Tag = "-1";
            // 
            // PersonPostFixedDataGroupBox
            // 
            this.PersonPostFixedDataGroupBox.Controls.Add(this.EmployeeFullNameValueLabel);
            this.PersonPostFixedDataGroupBox.Controls.Add(this.EmployeeFullNameTitleLabel);
            this.PersonPostFixedDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPostFixedDataGroupBox.Location = new System.Drawing.Point(5, 5);
            this.PersonPostFixedDataGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostFixedDataGroupBox.Name = "PersonPostFixedDataGroupBox";
            this.PersonPostFixedDataGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.PersonPostFixedDataGroupBox.Size = new System.Drawing.Size(602, 70);
            this.PersonPostFixedDataGroupBox.TabIndex = 0;
            this.PersonPostFixedDataGroupBox.TabStop = false;
            this.PersonPostFixedDataGroupBox.Tag = "-1";
            this.PersonPostFixedDataGroupBox.Text = "არარედაქტირებადი მონაცემები";
            // 
            // EmployeeFullNameValueLabel
            // 
            this.EmployeeFullNameValueLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EmployeeFullNameValueLabel.Location = new System.Drawing.Point(203, 27);
            this.EmployeeFullNameValueLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EmployeeFullNameValueLabel.Name = "EmployeeFullNameValueLabel";
            this.EmployeeFullNameValueLabel.Size = new System.Drawing.Size(387, 23);
            this.EmployeeFullNameValueLabel.TabIndex = 5;
            this.EmployeeFullNameValueLabel.Tag = "-1";
            this.EmployeeFullNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeFullNameTitleLabel
            // 
            this.EmployeeFullNameTitleLabel.Location = new System.Drawing.Point(4, 27);
            this.EmployeeFullNameTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EmployeeFullNameTitleLabel.Name = "EmployeeFullNameTitleLabel";
            this.EmployeeFullNameTitleLabel.Size = new System.Drawing.Size(192, 23);
            this.EmployeeFullNameTitleLabel.TabIndex = 4;
            this.EmployeeFullNameTitleLabel.Tag = "-1";
            this.EmployeeFullNameTitleLabel.Text = "სრული სახელი";
            this.EmployeeFullNameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostEditedDataGroupBox
            // 
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostEmployeeTypeTitleLabel);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostEmployeeTypeComboBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostDismissalOrderValueTextBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostDismissalOrderTitleLabel);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostPostTitleLabel);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostPostValueComboBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostBrigadeValueComboBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostBrigadeTitleLabel);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostEndDateTitleCheckBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostDescriptionValueTextBox);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostEndDateValueDateTimePicker);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostStartDateValueDateTimePicker);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostStartDateTitleLabel);
            this.PersonPostEditedDataGroupBox.Controls.Add(this.PersonPostDescriptionTitleLabel);
            this.PersonPostEditedDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonPostEditedDataGroupBox.Location = new System.Drawing.Point(5, 85);
            this.PersonPostEditedDataGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostEditedDataGroupBox.Name = "PersonPostEditedDataGroupBox";
            this.PersonPostEditedDataGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.PersonPostEditedDataGroupBox.Size = new System.Drawing.Size(602, 303);
            this.PersonPostEditedDataGroupBox.TabIndex = 1;
            this.PersonPostEditedDataGroupBox.TabStop = false;
            this.PersonPostEditedDataGroupBox.Tag = "-1";
            this.PersonPostEditedDataGroupBox.Text = "რედაქტირებადი მონაცემები";
            // 
            // PersonPostEmployeeTypeTitleLabel
            // 
            this.PersonPostEmployeeTypeTitleLabel.Location = new System.Drawing.Point(25, 110);
            this.PersonPostEmployeeTypeTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostEmployeeTypeTitleLabel.Name = "PersonPostEmployeeTypeTitleLabel";
            this.PersonPostEmployeeTypeTitleLabel.Size = new System.Drawing.Size(171, 23);
            this.PersonPostEmployeeTypeTitleLabel.TabIndex = 158;
            this.PersonPostEmployeeTypeTitleLabel.Tag = "-1";
            this.PersonPostEmployeeTypeTitleLabel.Text = "თანამშრომლის ტიპი";
            this.PersonPostEmployeeTypeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostEmployeeTypeComboBox
            // 
            this.PersonPostEmployeeTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonPostEmployeeTypeComboBox.FormattingEnabled = true;
            this.PersonPostEmployeeTypeComboBox.Location = new System.Drawing.Point(203, 110);
            this.PersonPostEmployeeTypeComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostEmployeeTypeComboBox.Name = "PersonPostEmployeeTypeComboBox";
            this.PersonPostEmployeeTypeComboBox.Size = new System.Drawing.Size(387, 24);
            this.PersonPostEmployeeTypeComboBox.TabIndex = 157;
            this.PersonPostEmployeeTypeComboBox.Tag = "-1";
            // 
            // PersonPostDismissalOrderValueTextBox
            // 
            this.PersonPostDismissalOrderValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonPostDismissalOrderValueTextBox.Location = new System.Drawing.Point(203, 257);
            this.PersonPostDismissalOrderValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostDismissalOrderValueTextBox.Name = "PersonPostDismissalOrderValueTextBox";
            this.PersonPostDismissalOrderValueTextBox.Size = new System.Drawing.Size(397, 22);
            this.PersonPostDismissalOrderValueTextBox.TabIndex = 10;
            this.PersonPostDismissalOrderValueTextBox.Tag = "-1";
            // 
            // PersonPostDismissalOrderTitleLabel
            // 
            this.PersonPostDismissalOrderTitleLabel.Location = new System.Drawing.Point(16, 250);
            this.PersonPostDismissalOrderTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostDismissalOrderTitleLabel.Name = "PersonPostDismissalOrderTitleLabel";
            this.PersonPostDismissalOrderTitleLabel.Size = new System.Drawing.Size(187, 34);
            this.PersonPostDismissalOrderTitleLabel.TabIndex = 156;
            this.PersonPostDismissalOrderTitleLabel.Tag = "-1";
            this.PersonPostDismissalOrderTitleLabel.Text = "გათავისუფლების ბრძანება";
            this.PersonPostDismissalOrderTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostPostTitleLabel
            // 
            this.PersonPostPostTitleLabel.Location = new System.Drawing.Point(25, 72);
            this.PersonPostPostTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostPostTitleLabel.Name = "PersonPostPostTitleLabel";
            this.PersonPostPostTitleLabel.Size = new System.Drawing.Size(171, 23);
            this.PersonPostPostTitleLabel.TabIndex = 39;
            this.PersonPostPostTitleLabel.Tag = "-1";
            this.PersonPostPostTitleLabel.Text = "თანამდებობა";
            this.PersonPostPostTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostPostValueComboBox
            // 
            this.PersonPostPostValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonPostPostValueComboBox.FormattingEnabled = true;
            this.PersonPostPostValueComboBox.Location = new System.Drawing.Point(203, 72);
            this.PersonPostPostValueComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostPostValueComboBox.Name = "PersonPostPostValueComboBox";
            this.PersonPostPostValueComboBox.Size = new System.Drawing.Size(387, 24);
            this.PersonPostPostValueComboBox.TabIndex = 2;
            this.PersonPostPostValueComboBox.Tag = "-1";
            // 
            // PersonPostBrigadeValueComboBox
            // 
            this.PersonPostBrigadeValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonPostBrigadeValueComboBox.FormattingEnabled = true;
            this.PersonPostBrigadeValueComboBox.Location = new System.Drawing.Point(203, 32);
            this.PersonPostBrigadeValueComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostBrigadeValueComboBox.Name = "PersonPostBrigadeValueComboBox";
            this.PersonPostBrigadeValueComboBox.Size = new System.Drawing.Size(387, 24);
            this.PersonPostBrigadeValueComboBox.TabIndex = 1;
            this.PersonPostBrigadeValueComboBox.Tag = "-1";
            // 
            // PersonPostBrigadeTitleLabel
            // 
            this.PersonPostBrigadeTitleLabel.Location = new System.Drawing.Point(29, 32);
            this.PersonPostBrigadeTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostBrigadeTitleLabel.Name = "PersonPostBrigadeTitleLabel";
            this.PersonPostBrigadeTitleLabel.Size = new System.Drawing.Size(171, 23);
            this.PersonPostBrigadeTitleLabel.TabIndex = 32;
            this.PersonPostBrigadeTitleLabel.Tag = "-1";
            this.PersonPostBrigadeTitleLabel.Text = "ჯგუფი";
            this.PersonPostBrigadeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostEndDateTitleCheckBox
            // 
            this.PersonPostEndDateTitleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.Location = new System.Drawing.Point(51, 181);
            this.PersonPostEndDateTitleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostEndDateTitleCheckBox.Name = "PersonPostEndDateTitleCheckBox";
            this.PersonPostEndDateTitleCheckBox.Size = new System.Drawing.Size(149, 23);
            this.PersonPostEndDateTitleCheckBox.TabIndex = 4;
            this.PersonPostEndDateTitleCheckBox.Tag = "-1";
            this.PersonPostEndDateTitleCheckBox.Text = "დასრულების თარიღი";
            this.PersonPostEndDateTitleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.UseVisualStyleBackColor = true;
            this.PersonPostEndDateTitleCheckBox.CheckedChanged += new System.EventHandler(this.PersonPostEndDateTitleCheckBox_CheckedChanged);
            // 
            // PersonPostDescriptionValueTextBox
            // 
            this.PersonPostDescriptionValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PersonPostDescriptionValueTextBox.Location = new System.Drawing.Point(203, 222);
            this.PersonPostDescriptionValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostDescriptionValueTextBox.Name = "PersonPostDescriptionValueTextBox";
            this.PersonPostDescriptionValueTextBox.Size = new System.Drawing.Size(397, 22);
            this.PersonPostDescriptionValueTextBox.TabIndex = 9;
            this.PersonPostDescriptionValueTextBox.Tag = "-1";
            // 
            // PersonPostEndDateValueDateTimePicker
            // 
            this.PersonPostEndDateValueDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.PersonPostEndDateValueDateTimePicker.Location = new System.Drawing.Point(203, 180);
            this.PersonPostEndDateValueDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostEndDateValueDateTimePicker.Name = "PersonPostEndDateValueDateTimePicker";
            this.PersonPostEndDateValueDateTimePicker.Size = new System.Drawing.Size(268, 22);
            this.PersonPostEndDateValueDateTimePicker.TabIndex = 5;
            this.PersonPostEndDateValueDateTimePicker.Tag = "-1";
            this.PersonPostEndDateValueDateTimePicker.Value = new System.DateTime(2019, 4, 13, 0, 0, 0, 0);
            // 
            // PersonPostStartDateValueDateTimePicker
            // 
            this.PersonPostStartDateValueDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.PersonPostStartDateValueDateTimePicker.Location = new System.Drawing.Point(203, 148);
            this.PersonPostStartDateValueDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.PersonPostStartDateValueDateTimePicker.Name = "PersonPostStartDateValueDateTimePicker";
            this.PersonPostStartDateValueDateTimePicker.Size = new System.Drawing.Size(268, 22);
            this.PersonPostStartDateValueDateTimePicker.TabIndex = 3;
            this.PersonPostStartDateValueDateTimePicker.Tag = "-1";
            this.PersonPostStartDateValueDateTimePicker.Value = new System.DateTime(2019, 4, 13, 0, 0, 0, 0);
            // 
            // PersonPostStartDateTitleLabel
            // 
            this.PersonPostStartDateTitleLabel.Location = new System.Drawing.Point(28, 150);
            this.PersonPostStartDateTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostStartDateTitleLabel.Name = "PersonPostStartDateTitleLabel";
            this.PersonPostStartDateTitleLabel.Size = new System.Drawing.Size(171, 23);
            this.PersonPostStartDateTitleLabel.TabIndex = 14;
            this.PersonPostStartDateTitleLabel.Tag = "-1";
            this.PersonPostStartDateTitleLabel.Text = "დაწყების თარიღი";
            this.PersonPostStartDateTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonPostDescriptionTitleLabel
            // 
            this.PersonPostDescriptionTitleLabel.Location = new System.Drawing.Point(31, 220);
            this.PersonPostDescriptionTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonPostDescriptionTitleLabel.Name = "PersonPostDescriptionTitleLabel";
            this.PersonPostDescriptionTitleLabel.Size = new System.Drawing.Size(171, 23);
            this.PersonPostDescriptionTitleLabel.TabIndex = 0;
            this.PersonPostDescriptionTitleLabel.Tag = "-1";
            this.PersonPostDescriptionTitleLabel.Text = "კომენტარი";
            this.PersonPostDescriptionTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CareerButtonsPanel
            // 
            this.CareerButtonsPanel.Controls.Add(this.CommitButton);
            this.CareerButtonsPanel.Controls.Add(this.RollbackButton);
            this.CareerButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CareerButtonsPanel.Location = new System.Drawing.Point(5, 398);
            this.CareerButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.CareerButtonsPanel.Name = "CareerButtonsPanel";
            this.CareerButtonsPanel.Size = new System.Drawing.Size(602, 47);
            this.CareerButtonsPanel.TabIndex = 2;
            this.CareerButtonsPanel.Tag = "-1";
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Location = new System.Drawing.Point(358, 10);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(5);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(100, 28);
            this.CommitButton.TabIndex = 12;
            this.CommitButton.Tag = "-1";
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Location = new System.Drawing.Point(485, 10);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(5);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(100, 28);
            this.RollbackButton.TabIndex = 13;
            this.RollbackButton.Tag = "-1";
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // PersonPostEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 450);
            this.Controls.Add(this.PersonPostMainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonPostEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonPostEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonPostEditForm_FormClosing);
            this.Load += new System.EventHandler(this.PersonPostEditForm_Load);
            this.PersonPostMainTableLayoutPanel.ResumeLayout(false);
            this.PersonPostFixedDataGroupBox.ResumeLayout(false);
            this.PersonPostEditedDataGroupBox.ResumeLayout(false);
            this.PersonPostEditedDataGroupBox.PerformLayout();
            this.CareerButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PersonPostMainTableLayoutPanel;
        private System.Windows.Forms.GroupBox PersonPostFixedDataGroupBox;
        private System.Windows.Forms.Label EmployeeFullNameValueLabel;
        private System.Windows.Forms.Label EmployeeFullNameTitleLabel;
        private System.Windows.Forms.GroupBox PersonPostEditedDataGroupBox;
        private System.Windows.Forms.TextBox PersonPostDismissalOrderValueTextBox;
        private System.Windows.Forms.Label PersonPostDismissalOrderTitleLabel;
        private System.Windows.Forms.Label PersonPostPostTitleLabel;
        private System.Windows.Forms.ComboBox PersonPostPostValueComboBox;
        private System.Windows.Forms.ComboBox PersonPostBrigadeValueComboBox;
        private System.Windows.Forms.Label PersonPostBrigadeTitleLabel;
        private System.Windows.Forms.CheckBox PersonPostEndDateTitleCheckBox;
        private System.Windows.Forms.TextBox PersonPostDescriptionValueTextBox;
        private System.Windows.Forms.DateTimePicker PersonPostEndDateValueDateTimePicker;
        private System.Windows.Forms.DateTimePicker PersonPostStartDateValueDateTimePicker;
        private System.Windows.Forms.Label PersonPostStartDateTitleLabel;
        private System.Windows.Forms.Label PersonPostDescriptionTitleLabel;
        private System.Windows.Forms.Panel CareerButtonsPanel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Label PersonPostEmployeeTypeTitleLabel;
        private System.Windows.Forms.ComboBox PersonPostEmployeeTypeComboBox;
    }
}