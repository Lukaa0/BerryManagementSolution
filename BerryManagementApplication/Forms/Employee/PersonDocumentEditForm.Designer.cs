namespace BerryManagementApplication.Forms.Employee
{
    partial class PersonDocumentEditForm
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
            this.PersonDocumentMainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.PersonDocumentFixedDataGroupBox = new System.Windows.Forms.GroupBox();
            this.EmployeeFullNameValueLabel = new System.Windows.Forms.Label();
            this.EmployeeFullNameTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentEditedDataGroupBox = new System.Windows.Forms.GroupBox();
            this.PersonDocumentPersonLastNameValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonDocumentPersonLastNameTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentPersonFirstNameValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonDocumentPersonFirstNameTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentAddCitizenshipButton = new System.Windows.Forms.Button();
            this.PersonDocumentAddDocumentTypeButton = new System.Windows.Forms.Button();
            this.PersonDocumentDocumentIssuerValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonDocumentDocumentIssuerTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.PersonDocumentCitizenshipValueComboBox = new System.Windows.Forms.ComboBox();
            this.PersonDocumentCitizenshipTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentTypeValueComboBox = new System.Windows.Forms.ComboBox();
            this.PersonDocumentDocumentNumberValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonDocumentTypeTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentDocumentNumberTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentDescriptionValueTextBox = new System.Windows.Forms.TextBox();
            this.PersonDocumentEndDateValueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PersonDocumentStartDateValueDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.PersonDocumentStartDateTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumentDescriptionTitleLabel = new System.Windows.Forms.Label();
            this.PersonDocumenButtonsPanel = new System.Windows.Forms.Panel();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.PersonDocumentMainTableLayoutPanel.SuspendLayout();
            this.PersonDocumentFixedDataGroupBox.SuspendLayout();
            this.PersonDocumentEditedDataGroupBox.SuspendLayout();
            this.PersonDocumenButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PersonDocumentMainTableLayoutPanel
            // 
            this.PersonDocumentMainTableLayoutPanel.AutoScroll = true;
            this.PersonDocumentMainTableLayoutPanel.ColumnCount = 1;
            this.PersonDocumentMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PersonDocumentMainTableLayoutPanel.Controls.Add(this.PersonDocumentFixedDataGroupBox, 0, 0);
            this.PersonDocumentMainTableLayoutPanel.Controls.Add(this.PersonDocumentEditedDataGroupBox, 0, 1);
            this.PersonDocumentMainTableLayoutPanel.Controls.Add(this.PersonDocumenButtonsPanel, 0, 2);
            this.PersonDocumentMainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonDocumentMainTableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.PersonDocumentMainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.PersonDocumentMainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentMainTableLayoutPanel.Name = "PersonDocumentMainTableLayoutPanel";
            this.PersonDocumentMainTableLayoutPanel.RowCount = 3;
            this.PersonDocumentMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.PersonDocumentMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.PersonDocumentMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.PersonDocumentMainTableLayoutPanel.Size = new System.Drawing.Size(539, 463);
            this.PersonDocumentMainTableLayoutPanel.TabIndex = 9;
            this.PersonDocumentMainTableLayoutPanel.Tag = "-1";
            // 
            // PersonDocumentFixedDataGroupBox
            // 
            this.PersonDocumentFixedDataGroupBox.Controls.Add(this.EmployeeFullNameValueLabel);
            this.PersonDocumentFixedDataGroupBox.Controls.Add(this.EmployeeFullNameTitleLabel);
            this.PersonDocumentFixedDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonDocumentFixedDataGroupBox.Location = new System.Drawing.Point(5, 5);
            this.PersonDocumentFixedDataGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentFixedDataGroupBox.Name = "PersonDocumentFixedDataGroupBox";
            this.PersonDocumentFixedDataGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.PersonDocumentFixedDataGroupBox.Size = new System.Drawing.Size(529, 55);
            this.PersonDocumentFixedDataGroupBox.TabIndex = 0;
            this.PersonDocumentFixedDataGroupBox.TabStop = false;
            this.PersonDocumentFixedDataGroupBox.Tag = "-1";
            this.PersonDocumentFixedDataGroupBox.Text = "არარედაქტირებადი მონაცემები";
            // 
            // EmployeeFullNameValueLabel
            // 
            this.EmployeeFullNameValueLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmployeeFullNameValueLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.EmployeeFullNameValueLabel.Location = new System.Drawing.Point(139, 20);
            this.EmployeeFullNameValueLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EmployeeFullNameValueLabel.Name = "EmployeeFullNameValueLabel";
            this.EmployeeFullNameValueLabel.Size = new System.Drawing.Size(373, 23);
            this.EmployeeFullNameValueLabel.TabIndex = 5;
            this.EmployeeFullNameValueLabel.Tag = "-1";
            this.EmployeeFullNameValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EmployeeFullNameTitleLabel
            // 
            this.EmployeeFullNameTitleLabel.Location = new System.Drawing.Point(12, 20);
            this.EmployeeFullNameTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.EmployeeFullNameTitleLabel.Name = "EmployeeFullNameTitleLabel";
            this.EmployeeFullNameTitleLabel.Size = new System.Drawing.Size(116, 23);
            this.EmployeeFullNameTitleLabel.TabIndex = 4;
            this.EmployeeFullNameTitleLabel.Tag = "-1";
            this.EmployeeFullNameTitleLabel.Text = "სრული სახელი";
            this.EmployeeFullNameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentEditedDataGroupBox
            // 
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentPersonLastNameValueTextBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentPersonLastNameTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentPersonFirstNameValueTextBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentPersonFirstNameTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentAddCitizenshipButton);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentAddDocumentTypeButton);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDocumentIssuerValueTextBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDocumentIssuerTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentEndDateTitleCheckBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentCitizenshipValueComboBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentCitizenshipTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentTypeValueComboBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDocumentNumberValueTextBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentTypeTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDocumentNumberTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDescriptionValueTextBox);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentEndDateValueDateTimePicker);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentStartDateValueDateTimePicker);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentStartDateTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Controls.Add(this.PersonDocumentDescriptionTitleLabel);
            this.PersonDocumentEditedDataGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonDocumentEditedDataGroupBox.Location = new System.Drawing.Point(5, 70);
            this.PersonDocumentEditedDataGroupBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentEditedDataGroupBox.Name = "PersonDocumentEditedDataGroupBox";
            this.PersonDocumentEditedDataGroupBox.Padding = new System.Windows.Forms.Padding(5);
            this.PersonDocumentEditedDataGroupBox.Size = new System.Drawing.Size(529, 331);
            this.PersonDocumentEditedDataGroupBox.TabIndex = 1;
            this.PersonDocumentEditedDataGroupBox.TabStop = false;
            this.PersonDocumentEditedDataGroupBox.Tag = "-1";
            this.PersonDocumentEditedDataGroupBox.Text = "რედაქტირებადი მონაცემები";
            // 
            // PersonDocumentPersonLastNameValueTextBox
            // 
            this.PersonDocumentPersonLastNameValueTextBox.Location = new System.Drawing.Point(197, 260);
            this.PersonDocumentPersonLastNameValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentPersonLastNameValueTextBox.Name = "PersonDocumentPersonLastNameValueTextBox";
            this.PersonDocumentPersonLastNameValueTextBox.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentPersonLastNameValueTextBox.TabIndex = 44;
            this.PersonDocumentPersonLastNameValueTextBox.Tag = "-1";
            // 
            // PersonDocumentPersonLastNameTitleLabel
            // 
            this.PersonDocumentPersonLastNameTitleLabel.Location = new System.Drawing.Point(27, 260);
            this.PersonDocumentPersonLastNameTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentPersonLastNameTitleLabel.Name = "PersonDocumentPersonLastNameTitleLabel";
            this.PersonDocumentPersonLastNameTitleLabel.Size = new System.Drawing.Size(159, 23);
            this.PersonDocumentPersonLastNameTitleLabel.TabIndex = 43;
            this.PersonDocumentPersonLastNameTitleLabel.Tag = "-1";
            this.PersonDocumentPersonLastNameTitleLabel.Text = "გვარი";
            this.PersonDocumentPersonLastNameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentPersonFirstNameValueTextBox
            // 
            this.PersonDocumentPersonFirstNameValueTextBox.Location = new System.Drawing.Point(199, 228);
            this.PersonDocumentPersonFirstNameValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentPersonFirstNameValueTextBox.Name = "PersonDocumentPersonFirstNameValueTextBox";
            this.PersonDocumentPersonFirstNameValueTextBox.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentPersonFirstNameValueTextBox.TabIndex = 42;
            this.PersonDocumentPersonFirstNameValueTextBox.Tag = "-1";
            // 
            // PersonDocumentPersonFirstNameTitleLabel
            // 
            this.PersonDocumentPersonFirstNameTitleLabel.Location = new System.Drawing.Point(27, 228);
            this.PersonDocumentPersonFirstNameTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentPersonFirstNameTitleLabel.Name = "PersonDocumentPersonFirstNameTitleLabel";
            this.PersonDocumentPersonFirstNameTitleLabel.Size = new System.Drawing.Size(159, 23);
            this.PersonDocumentPersonFirstNameTitleLabel.TabIndex = 41;
            this.PersonDocumentPersonFirstNameTitleLabel.Tag = "-1";
            this.PersonDocumentPersonFirstNameTitleLabel.Text = "სახელი";
            this.PersonDocumentPersonFirstNameTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentAddCitizenshipButton
            // 
            this.PersonDocumentAddCitizenshipButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PersonDocumentAddCitizenshipButton.Location = new System.Drawing.Point(428, 57);
            this.PersonDocumentAddCitizenshipButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonDocumentAddCitizenshipButton.Name = "PersonDocumentAddCitizenshipButton";
            this.PersonDocumentAddCitizenshipButton.Size = new System.Drawing.Size(28, 26);
            this.PersonDocumentAddCitizenshipButton.TabIndex = 40;
            this.PersonDocumentAddCitizenshipButton.TabStop = false;
            this.PersonDocumentAddCitizenshipButton.Tag = "14";
            this.PersonDocumentAddCitizenshipButton.Text = "...";
            this.PersonDocumentAddCitizenshipButton.UseVisualStyleBackColor = true;
            this.PersonDocumentAddCitizenshipButton.Click += new System.EventHandler(this.PersonDocumentAddCitizenshipButton_Click);
            // 
            // PersonDocumentAddDocumentTypeButton
            // 
            this.PersonDocumentAddDocumentTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PersonDocumentAddDocumentTypeButton.Location = new System.Drawing.Point(428, 22);
            this.PersonDocumentAddDocumentTypeButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonDocumentAddDocumentTypeButton.Name = "PersonDocumentAddDocumentTypeButton";
            this.PersonDocumentAddDocumentTypeButton.Size = new System.Drawing.Size(28, 26);
            this.PersonDocumentAddDocumentTypeButton.TabIndex = 39;
            this.PersonDocumentAddDocumentTypeButton.TabStop = false;
            this.PersonDocumentAddDocumentTypeButton.Tag = "14";
            this.PersonDocumentAddDocumentTypeButton.Text = "...";
            this.PersonDocumentAddDocumentTypeButton.UseVisualStyleBackColor = true;
            this.PersonDocumentAddDocumentTypeButton.Click += new System.EventHandler(this.PersonDocumentAddDocumentTypeButton_Click);
            // 
            // PersonDocumentDocumentIssuerValueTextBox
            // 
            this.PersonDocumentDocumentIssuerValueTextBox.Location = new System.Drawing.Point(199, 193);
            this.PersonDocumentDocumentIssuerValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentDocumentIssuerValueTextBox.Name = "PersonDocumentDocumentIssuerValueTextBox";
            this.PersonDocumentDocumentIssuerValueTextBox.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentDocumentIssuerValueTextBox.TabIndex = 38;
            this.PersonDocumentDocumentIssuerValueTextBox.Tag = "-1";
            // 
            // PersonDocumentDocumentIssuerTitleLabel
            // 
            this.PersonDocumentDocumentIssuerTitleLabel.Location = new System.Drawing.Point(59, 193);
            this.PersonDocumentDocumentIssuerTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentDocumentIssuerTitleLabel.Name = "PersonDocumentDocumentIssuerTitleLabel";
            this.PersonDocumentDocumentIssuerTitleLabel.Size = new System.Drawing.Size(109, 34);
            this.PersonDocumentDocumentIssuerTitleLabel.TabIndex = 37;
            this.PersonDocumentDocumentIssuerTitleLabel.Tag = "-1";
            this.PersonDocumentDocumentIssuerTitleLabel.Text = "დოკუმენტის გამცემი";
            this.PersonDocumentDocumentIssuerTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentEndDateTitleCheckBox
            // 
            this.PersonDocumentEndDateTitleCheckBox.AutoSize = true;
            this.PersonDocumentEndDateTitleCheckBox.Location = new System.Drawing.Point(28, 128);
            this.PersonDocumentEndDateTitleCheckBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonDocumentEndDateTitleCheckBox.Name = "PersonDocumentEndDateTitleCheckBox";
            this.PersonDocumentEndDateTitleCheckBox.Size = new System.Drawing.Size(151, 21);
            this.PersonDocumentEndDateTitleCheckBox.TabIndex = 36;
            this.PersonDocumentEndDateTitleCheckBox.Tag = "-1";
            this.PersonDocumentEndDateTitleCheckBox.Text = "მოქმედების ვადა";
            this.PersonDocumentEndDateTitleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonDocumentEndDateTitleCheckBox.UseVisualStyleBackColor = true;
            this.PersonDocumentEndDateTitleCheckBox.CheckedChanged += new System.EventHandler(this.PersonDocumentEndDateTitleCheckBox_CheckedChanged);
            // 
            // PersonDocumentCitizenshipValueComboBox
            // 
            this.PersonDocumentCitizenshipValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonDocumentCitizenshipValueComboBox.FormattingEnabled = true;
            this.PersonDocumentCitizenshipValueComboBox.Location = new System.Drawing.Point(197, 57);
            this.PersonDocumentCitizenshipValueComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonDocumentCitizenshipValueComboBox.Name = "PersonDocumentCitizenshipValueComboBox";
            this.PersonDocumentCitizenshipValueComboBox.Size = new System.Drawing.Size(225, 24);
            this.PersonDocumentCitizenshipValueComboBox.TabIndex = 1;
            this.PersonDocumentCitizenshipValueComboBox.Tag = "-1";
            // 
            // PersonDocumentCitizenshipTitleLabel
            // 
            this.PersonDocumentCitizenshipTitleLabel.Location = new System.Drawing.Point(27, 57);
            this.PersonDocumentCitizenshipTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentCitizenshipTitleLabel.Name = "PersonDocumentCitizenshipTitleLabel";
            this.PersonDocumentCitizenshipTitleLabel.Size = new System.Drawing.Size(160, 23);
            this.PersonDocumentCitizenshipTitleLabel.TabIndex = 31;
            this.PersonDocumentCitizenshipTitleLabel.Tag = "-1";
            this.PersonDocumentCitizenshipTitleLabel.Text = "მოქალაქეობა";
            this.PersonDocumentCitizenshipTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentTypeValueComboBox
            // 
            this.PersonDocumentTypeValueComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PersonDocumentTypeValueComboBox.FormattingEnabled = true;
            this.PersonDocumentTypeValueComboBox.Location = new System.Drawing.Point(197, 23);
            this.PersonDocumentTypeValueComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonDocumentTypeValueComboBox.Name = "PersonDocumentTypeValueComboBox";
            this.PersonDocumentTypeValueComboBox.Size = new System.Drawing.Size(225, 24);
            this.PersonDocumentTypeValueComboBox.TabIndex = 0;
            this.PersonDocumentTypeValueComboBox.Tag = "-1";
            // 
            // PersonDocumentDocumentNumberValueTextBox
            // 
            this.PersonDocumentDocumentNumberValueTextBox.Location = new System.Drawing.Point(199, 158);
            this.PersonDocumentDocumentNumberValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentDocumentNumberValueTextBox.Name = "PersonDocumentDocumentNumberValueTextBox";
            this.PersonDocumentDocumentNumberValueTextBox.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentDocumentNumberValueTextBox.TabIndex = 4;
            this.PersonDocumentDocumentNumberValueTextBox.Tag = "-1";
            // 
            // PersonDocumentTypeTitleLabel
            // 
            this.PersonDocumentTypeTitleLabel.Location = new System.Drawing.Point(27, 23);
            this.PersonDocumentTypeTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentTypeTitleLabel.Name = "PersonDocumentTypeTitleLabel";
            this.PersonDocumentTypeTitleLabel.Size = new System.Drawing.Size(160, 23);
            this.PersonDocumentTypeTitleLabel.TabIndex = 6;
            this.PersonDocumentTypeTitleLabel.Tag = "-1";
            this.PersonDocumentTypeTitleLabel.Text = "დოკუმენტის ტიპი";
            this.PersonDocumentTypeTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentDocumentNumberTitleLabel
            // 
            this.PersonDocumentDocumentNumberTitleLabel.Location = new System.Drawing.Point(27, 158);
            this.PersonDocumentDocumentNumberTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentDocumentNumberTitleLabel.Name = "PersonDocumentDocumentNumberTitleLabel";
            this.PersonDocumentDocumentNumberTitleLabel.Size = new System.Drawing.Size(159, 23);
            this.PersonDocumentDocumentNumberTitleLabel.TabIndex = 29;
            this.PersonDocumentDocumentNumberTitleLabel.Tag = "-1";
            this.PersonDocumentDocumentNumberTitleLabel.Text = "დოკუმენტის ნომერი";
            this.PersonDocumentDocumentNumberTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentDescriptionValueTextBox
            // 
            this.PersonDocumentDescriptionValueTextBox.Location = new System.Drawing.Point(199, 292);
            this.PersonDocumentDescriptionValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentDescriptionValueTextBox.Name = "PersonDocumentDescriptionValueTextBox";
            this.PersonDocumentDescriptionValueTextBox.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentDescriptionValueTextBox.TabIndex = 5;
            this.PersonDocumentDescriptionValueTextBox.Tag = "-1";
            // 
            // PersonDocumentEndDateValueDateTimePicker
            // 
            this.PersonDocumentEndDateValueDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.PersonDocumentEndDateValueDateTimePicker.Location = new System.Drawing.Point(199, 124);
            this.PersonDocumentEndDateValueDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentEndDateValueDateTimePicker.Name = "PersonDocumentEndDateValueDateTimePicker";
            this.PersonDocumentEndDateValueDateTimePicker.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentEndDateValueDateTimePicker.TabIndex = 3;
            this.PersonDocumentEndDateValueDateTimePicker.Tag = "-1";
            this.PersonDocumentEndDateValueDateTimePicker.Value = new System.DateTime(2019, 4, 13, 0, 0, 0, 0);
            // 
            // PersonDocumentStartDateValueDateTimePicker
            // 
            this.PersonDocumentStartDateValueDateTimePicker.CustomFormat = "dd/mm/yyyy";
            this.PersonDocumentStartDateValueDateTimePicker.Location = new System.Drawing.Point(199, 91);
            this.PersonDocumentStartDateValueDateTimePicker.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumentStartDateValueDateTimePicker.Name = "PersonDocumentStartDateValueDateTimePicker";
            this.PersonDocumentStartDateValueDateTimePicker.Size = new System.Drawing.Size(225, 22);
            this.PersonDocumentStartDateValueDateTimePicker.TabIndex = 2;
            this.PersonDocumentStartDateValueDateTimePicker.Tag = "-1";
            this.PersonDocumentStartDateValueDateTimePicker.Value = new System.DateTime(2019, 4, 13, 0, 0, 0, 0);
            // 
            // PersonDocumentStartDateTitleLabel
            // 
            this.PersonDocumentStartDateTitleLabel.Location = new System.Drawing.Point(11, 94);
            this.PersonDocumentStartDateTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentStartDateTitleLabel.Name = "PersonDocumentStartDateTitleLabel";
            this.PersonDocumentStartDateTitleLabel.Size = new System.Drawing.Size(176, 23);
            this.PersonDocumentStartDateTitleLabel.TabIndex = 14;
            this.PersonDocumentStartDateTitleLabel.Tag = "-1";
            this.PersonDocumentStartDateTitleLabel.Text = "დამზადების თარიღი";
            this.PersonDocumentStartDateTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumentDescriptionTitleLabel
            // 
            this.PersonDocumentDescriptionTitleLabel.Location = new System.Drawing.Point(27, 292);
            this.PersonDocumentDescriptionTitleLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PersonDocumentDescriptionTitleLabel.Name = "PersonDocumentDescriptionTitleLabel";
            this.PersonDocumentDescriptionTitleLabel.Size = new System.Drawing.Size(159, 23);
            this.PersonDocumentDescriptionTitleLabel.TabIndex = 0;
            this.PersonDocumentDescriptionTitleLabel.Tag = "-1";
            this.PersonDocumentDescriptionTitleLabel.Text = "კომენტარი";
            this.PersonDocumentDescriptionTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonDocumenButtonsPanel
            // 
            this.PersonDocumenButtonsPanel.Controls.Add(this.CommitButton);
            this.PersonDocumenButtonsPanel.Controls.Add(this.RollbackButton);
            this.PersonDocumenButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonDocumenButtonsPanel.Location = new System.Drawing.Point(5, 411);
            this.PersonDocumenButtonsPanel.Margin = new System.Windows.Forms.Padding(5);
            this.PersonDocumenButtonsPanel.Name = "PersonDocumenButtonsPanel";
            this.PersonDocumenButtonsPanel.Size = new System.Drawing.Size(529, 47);
            this.PersonDocumenButtonsPanel.TabIndex = 2;
            this.PersonDocumenButtonsPanel.Tag = "-1";
            // 
            // CommitButton
            // 
            this.CommitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.CommitButton.Location = new System.Drawing.Point(286, 10);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(5);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(100, 28);
            this.CommitButton.TabIndex = 7;
            this.CommitButton.Tag = "-1";
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Location = new System.Drawing.Point(409, 10);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(5);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(100, 28);
            this.RollbackButton.TabIndex = 8;
            this.RollbackButton.Tag = "-1";
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // PersonDocumentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 463);
            this.Controls.Add(this.PersonDocumentMainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonDocumentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonDocumentEditForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PersonDocumentEditForm_FormClosing);
            this.Load += new System.EventHandler(this.PersonDocumentEditForm_Load);
            this.PersonDocumentMainTableLayoutPanel.ResumeLayout(false);
            this.PersonDocumentFixedDataGroupBox.ResumeLayout(false);
            this.PersonDocumentEditedDataGroupBox.ResumeLayout(false);
            this.PersonDocumentEditedDataGroupBox.PerformLayout();
            this.PersonDocumenButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel PersonDocumentMainTableLayoutPanel;
        private System.Windows.Forms.GroupBox PersonDocumentFixedDataGroupBox;
        private System.Windows.Forms.Label EmployeeFullNameValueLabel;
        private System.Windows.Forms.Label EmployeeFullNameTitleLabel;
        private System.Windows.Forms.GroupBox PersonDocumentEditedDataGroupBox;
        private System.Windows.Forms.TextBox PersonDocumentPersonFirstNameValueTextBox;
        private System.Windows.Forms.Label PersonDocumentPersonFirstNameTitleLabel;
        private System.Windows.Forms.Button PersonDocumentAddCitizenshipButton;
        private System.Windows.Forms.Button PersonDocumentAddDocumentTypeButton;
        private System.Windows.Forms.TextBox PersonDocumentDocumentIssuerValueTextBox;
        private System.Windows.Forms.Label PersonDocumentDocumentIssuerTitleLabel;
        private System.Windows.Forms.CheckBox PersonDocumentEndDateTitleCheckBox;
        private System.Windows.Forms.ComboBox PersonDocumentCitizenshipValueComboBox;
        private System.Windows.Forms.Label PersonDocumentCitizenshipTitleLabel;
        private System.Windows.Forms.ComboBox PersonDocumentTypeValueComboBox;
        private System.Windows.Forms.TextBox PersonDocumentDocumentNumberValueTextBox;
        private System.Windows.Forms.Label PersonDocumentTypeTitleLabel;
        private System.Windows.Forms.Label PersonDocumentDocumentNumberTitleLabel;
        private System.Windows.Forms.TextBox PersonDocumentDescriptionValueTextBox;
        private System.Windows.Forms.DateTimePicker PersonDocumentEndDateValueDateTimePicker;
        private System.Windows.Forms.DateTimePicker PersonDocumentStartDateValueDateTimePicker;
        private System.Windows.Forms.Label PersonDocumentStartDateTitleLabel;
        private System.Windows.Forms.Label PersonDocumentDescriptionTitleLabel;
        private System.Windows.Forms.Panel PersonDocumenButtonsPanel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.TextBox PersonDocumentPersonLastNameValueTextBox;
        private System.Windows.Forms.Label PersonDocumentPersonLastNameTitleLabel;
    }
}