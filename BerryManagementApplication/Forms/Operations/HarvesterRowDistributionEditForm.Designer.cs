namespace BerryManagementApplication.Forms.Operations
{
    partial class HarvesterRowDistributionEditForm
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
            this.RowLabel = new System.Windows.Forms.Label();
            this.AddHarverserButton = new System.Windows.Forms.Button();
            this.RemoveHarvesterButton = new System.Windows.Forms.Button();
            this.AllHarvesterGroupBox = new System.Windows.Forms.GroupBox();
            this.AllHarvesterDataGridView = new System.Windows.Forms.DataGridView();
            this.PersonPost_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersoPost_EmployeeBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_BalanceSheetType_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_BalanceSheetType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersoPost_EmployeeType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_EmployeeType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Person_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Person_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CareerEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Post_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Post_BarCodePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Brigade_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Brigade_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_DismissalOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HarvesterRowGroupBox = new System.Windows.Forms.GroupBox();
            this.HarvesterRowDataGridView = new System.Windows.Forms.DataGridView();
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
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllHarvesterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AllHarvesterDataGridView)).BeginInit();
            this.HarvesterRowGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HarvesterRowDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(654, 387);
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
            this.RollbackButton.Location = new System.Drawing.Point(813, 387);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // RowLabel
            // 
            this.RowLabel.AutoSize = true;
            this.RowLabel.Location = new System.Drawing.Point(391, 52);
            this.RowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RowLabel.Name = "RowLabel";
            this.RowLabel.Size = new System.Drawing.Size(42, 17);
            this.RowLabel.TabIndex = 66;
            this.RowLabel.Text = "რიგი";
            // 
            // AddHarverserButton
            // 
            this.AddHarverserButton.Location = new System.Drawing.Point(382, 182);
            this.AddHarverserButton.Name = "AddHarverserButton";
            this.AddHarverserButton.Size = new System.Drawing.Size(75, 23);
            this.AddHarverserButton.TabIndex = 78;
            this.AddHarverserButton.Text = ">>";
            this.AddHarverserButton.UseVisualStyleBackColor = true;
            this.AddHarverserButton.Click += new System.EventHandler(this.AddRowsButton_Click);
            // 
            // RemoveHarvesterButton
            // 
            this.RemoveHarvesterButton.Location = new System.Drawing.Point(385, 282);
            this.RemoveHarvesterButton.Name = "RemoveHarvesterButton";
            this.RemoveHarvesterButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveHarvesterButton.TabIndex = 79;
            this.RemoveHarvesterButton.Text = "<<";
            this.RemoveHarvesterButton.UseVisualStyleBackColor = true;
            this.RemoveHarvesterButton.Click += new System.EventHandler(this.RemoveRowsButton_Click);
            // 
            // AllHarvesterGroupBox
            // 
            this.AllHarvesterGroupBox.Controls.Add(this.AllHarvesterDataGridView);
            this.AllHarvesterGroupBox.Location = new System.Drawing.Point(12, 114);
            this.AllHarvesterGroupBox.Name = "AllHarvesterGroupBox";
            this.AllHarvesterGroupBox.Size = new System.Drawing.Size(347, 252);
            this.AllHarvesterGroupBox.TabIndex = 80;
            this.AllHarvesterGroupBox.TabStop = false;
            this.AllHarvesterGroupBox.Text = "ყველა მკრეფავი";
            // 
            // AllHarvesterDataGridView
            // 
            this.AllHarvesterDataGridView.AllowUserToAddRows = false;
            this.AllHarvesterDataGridView.AllowUserToDeleteRows = false;
            this.AllHarvesterDataGridView.AllowUserToResizeRows = false;
            this.AllHarvesterDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllHarvesterDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonPost_Id,
            this.PersoPost_EmployeeBarCode,
            this.PersonPost_BalanceSheetType_ID,
            this.PersonPost_BalanceSheetType_Name,
            this.PersoPost_EmployeeType_Id,
            this.PersonPost_EmployeeType_Name,
            this.PersonPost_Person_ID,
            this.PersonPost_Person_FullName,
            this.CareerEndDate,
            this.PersonPost_Post_ID,
            this.PersonPost_Post_BarCodePrefix,
            this.PersonPost_Brigade_Id,
            this.PersonPost_Brigade_Name,
            this.PersonPost_StartDate,
            this.PersonPost_EndDate,
            this.PersonPost_DismissalOrder,
            this.PersonPost_Description});
            this.AllHarvesterDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AllHarvesterDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AllHarvesterDataGridView.Location = new System.Drawing.Point(3, 18);
            this.AllHarvesterDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.AllHarvesterDataGridView.Name = "AllHarvesterDataGridView";
            this.AllHarvesterDataGridView.ReadOnly = true;
            this.AllHarvesterDataGridView.Size = new System.Drawing.Size(341, 231);
            this.AllHarvesterDataGridView.TabIndex = 1;
            this.AllHarvesterDataGridView.Tag = "155";
            this.AllHarvesterDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AllHarvesterDataGridView_CellContentClick);
            // 
            // PersonPost_Id
            // 
            this.PersonPost_Id.DataPropertyName = "PersonPost_Id";
            this.PersonPost_Id.HeaderText = "იდენტიფიკატორი";
            this.PersonPost_Id.Name = "PersonPost_Id";
            this.PersonPost_Id.ReadOnly = true;
            this.PersonPost_Id.Visible = false;
            // 
            // PersoPost_EmployeeBarCode
            // 
            this.PersoPost_EmployeeBarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PersoPost_EmployeeBarCode.DataPropertyName = "PersonPost_EmployeeBarCode";
            this.PersoPost_EmployeeBarCode.HeaderText = "თანამშრომლის კოდი";
            this.PersoPost_EmployeeBarCode.Name = "PersoPost_EmployeeBarCode";
            this.PersoPost_EmployeeBarCode.ReadOnly = true;
            this.PersoPost_EmployeeBarCode.Visible = false;
            // 
            // PersonPost_BalanceSheetType_ID
            // 
            this.PersonPost_BalanceSheetType_ID.DataPropertyName = "PersonPost_BalanceSheetType_ID";
            this.PersonPost_BalanceSheetType_ID.HeaderText = "ბალანსის ცხრილი ID";
            this.PersonPost_BalanceSheetType_ID.Name = "PersonPost_BalanceSheetType_ID";
            this.PersonPost_BalanceSheetType_ID.ReadOnly = true;
            this.PersonPost_BalanceSheetType_ID.Visible = false;
            this.PersonPost_BalanceSheetType_ID.Width = 150;
            // 
            // PersonPost_BalanceSheetType_Name
            // 
            this.PersonPost_BalanceSheetType_Name.DataPropertyName = "PersonPost_BalanceSheetType_Name";
            this.PersonPost_BalanceSheetType_Name.HeaderText = "ბალანსის ცხილი";
            this.PersonPost_BalanceSheetType_Name.Name = "PersonPost_BalanceSheetType_Name";
            this.PersonPost_BalanceSheetType_Name.ReadOnly = true;
            this.PersonPost_BalanceSheetType_Name.Visible = false;
            // 
            // PersoPost_EmployeeType_Id
            // 
            this.PersoPost_EmployeeType_Id.DataPropertyName = "PersoPost_EmployeeType_Id";
            this.PersoPost_EmployeeType_Id.HeaderText = "თანამშრომლის ტიპი ID";
            this.PersoPost_EmployeeType_Id.Name = "PersoPost_EmployeeType_Id";
            this.PersoPost_EmployeeType_Id.ReadOnly = true;
            this.PersoPost_EmployeeType_Id.Visible = false;
            // 
            // PersonPost_EmployeeType_Name
            // 
            this.PersonPost_EmployeeType_Name.DataPropertyName = "PersonPost_EmployeeType_Name";
            this.PersonPost_EmployeeType_Name.HeaderText = "თანამშრომლის ტიპი";
            this.PersonPost_EmployeeType_Name.Name = "PersonPost_EmployeeType_Name";
            this.PersonPost_EmployeeType_Name.ReadOnly = true;
            this.PersonPost_EmployeeType_Name.Visible = false;
            this.PersonPost_EmployeeType_Name.Width = 150;
            // 
            // PersonPost_Person_ID
            // 
            this.PersonPost_Person_ID.DataPropertyName = "PersonPost_Person_ID";
            this.PersonPost_Person_ID.HeaderText = "თანამშრომის ID";
            this.PersonPost_Person_ID.Name = "PersonPost_Person_ID";
            this.PersonPost_Person_ID.ReadOnly = true;
            this.PersonPost_Person_ID.Visible = false;
            this.PersonPost_Person_ID.Width = 150;
            // 
            // PersonPost_Person_FullName
            // 
            this.PersonPost_Person_FullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PersonPost_Person_FullName.DataPropertyName = "PersonPost_Person_FullName";
            this.PersonPost_Person_FullName.HeaderText = "სახელი გვარი";
            this.PersonPost_Person_FullName.Name = "PersonPost_Person_FullName";
            this.PersonPost_Person_FullName.ReadOnly = true;
            // 
            // CareerEndDate
            // 
            this.CareerEndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CareerEndDate.DataPropertyName = "PersonPost_Post_Name";
            this.CareerEndDate.HeaderText = "თანამდებობა";
            this.CareerEndDate.Name = "CareerEndDate";
            this.CareerEndDate.ReadOnly = true;
            this.CareerEndDate.Visible = false;
            // 
            // PersonPost_Post_ID
            // 
            this.PersonPost_Post_ID.DataPropertyName = "PersonPost_Post_ID";
            this.PersonPost_Post_ID.HeaderText = "თანამდებობი ID";
            this.PersonPost_Post_ID.Name = "PersonPost_Post_ID";
            this.PersonPost_Post_ID.ReadOnly = true;
            this.PersonPost_Post_ID.Visible = false;
            // 
            // PersonPost_Post_BarCodePrefix
            // 
            this.PersonPost_Post_BarCodePrefix.DataPropertyName = "PersonPost_Post_BarCodePrefix";
            this.PersonPost_Post_BarCodePrefix.HeaderText = "პრეფიქსი";
            this.PersonPost_Post_BarCodePrefix.Name = "PersonPost_Post_BarCodePrefix";
            this.PersonPost_Post_BarCodePrefix.ReadOnly = true;
            this.PersonPost_Post_BarCodePrefix.Visible = false;
            this.PersonPost_Post_BarCodePrefix.Width = 80;
            // 
            // PersonPost_Brigade_Id
            // 
            this.PersonPost_Brigade_Id.DataPropertyName = "PersonPost_Brigade_Id";
            this.PersonPost_Brigade_Id.HeaderText = "ბრიგადის ID";
            this.PersonPost_Brigade_Id.Name = "PersonPost_Brigade_Id";
            this.PersonPost_Brigade_Id.ReadOnly = true;
            this.PersonPost_Brigade_Id.Visible = false;
            this.PersonPost_Brigade_Id.Width = 150;
            // 
            // PersonPost_Brigade_Name
            // 
            this.PersonPost_Brigade_Name.DataPropertyName = "PersonPost_Brigade_Name";
            this.PersonPost_Brigade_Name.HeaderText = "ბრიგადა";
            this.PersonPost_Brigade_Name.Name = "PersonPost_Brigade_Name";
            this.PersonPost_Brigade_Name.ReadOnly = true;
            this.PersonPost_Brigade_Name.Visible = false;
            // 
            // PersonPost_StartDate
            // 
            this.PersonPost_StartDate.DataPropertyName = "PersonPost_StartDate";
            this.PersonPost_StartDate.HeaderText = "დაწყების თარიღე";
            this.PersonPost_StartDate.Name = "PersonPost_StartDate";
            this.PersonPost_StartDate.ReadOnly = true;
            this.PersonPost_StartDate.Visible = false;
            // 
            // PersonPost_EndDate
            // 
            this.PersonPost_EndDate.DataPropertyName = "PersonPost_EndDate";
            this.PersonPost_EndDate.HeaderText = "დასრულების თარიღი";
            this.PersonPost_EndDate.Name = "PersonPost_EndDate";
            this.PersonPost_EndDate.ReadOnly = true;
            this.PersonPost_EndDate.Visible = false;
            // 
            // PersonPost_DismissalOrder
            // 
            this.PersonPost_DismissalOrder.DataPropertyName = "PersonPost_DismissalOrder";
            this.PersonPost_DismissalOrder.HeaderText = "ბრძანება";
            this.PersonPost_DismissalOrder.Name = "PersonPost_DismissalOrder";
            this.PersonPost_DismissalOrder.ReadOnly = true;
            this.PersonPost_DismissalOrder.Visible = false;
            // 
            // PersonPost_Description
            // 
            this.PersonPost_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PersonPost_Description.DataPropertyName = "PersonPost_Description";
            this.PersonPost_Description.HeaderText = "კომენტარი";
            this.PersonPost_Description.Name = "PersonPost_Description";
            this.PersonPost_Description.ReadOnly = true;
            this.PersonPost_Description.Visible = false;
            // 
            // HarvesterRowGroupBox
            // 
            this.HarvesterRowGroupBox.Controls.Add(this.HarvesterRowDataGridView);
            this.HarvesterRowGroupBox.Location = new System.Drawing.Point(485, 114);
            this.HarvesterRowGroupBox.Name = "HarvesterRowGroupBox";
            this.HarvesterRowGroupBox.Size = new System.Drawing.Size(408, 252);
            this.HarvesterRowGroupBox.TabIndex = 81;
            this.HarvesterRowGroupBox.TabStop = false;
            this.HarvesterRowGroupBox.Text = "არჩეული მკრეფავები";
            // 
            // HarvesterRowDataGridView
            // 
            this.HarvesterRowDataGridView.AllowUserToAddRows = false;
            this.HarvesterRowDataGridView.AllowUserToDeleteRows = false;
            this.HarvesterRowDataGridView.AllowUserToResizeRows = false;
            this.HarvesterRowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.HarvesterRowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.HarvesterRowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HarvesterRowDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.HarvesterRowDataGridView.Location = new System.Drawing.Point(3, 18);
            this.HarvesterRowDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.HarvesterRowDataGridView.Name = "HarvesterRowDataGridView";
            this.HarvesterRowDataGridView.ReadOnly = true;
            this.HarvesterRowDataGridView.Size = new System.Drawing.Size(402, 231);
            this.HarvesterRowDataGridView.TabIndex = 2;
            this.HarvesterRowDataGridView.Tag = "155";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "PersonPost_Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "იდენტიფიკატორი";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PersonPost_EmployeeBarCode";
            this.dataGridViewTextBoxColumn2.HeaderText = "თანამშრომლის კოდი";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PersonPost_BalanceSheetType_ID";
            this.dataGridViewTextBoxColumn3.HeaderText = "ბალანსის ცხრილი ID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 150;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "PersonPost_BalanceSheetType_Name";
            this.dataGridViewTextBoxColumn4.HeaderText = "ბალანსის ცხილი";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "PersoPost_EmployeeType_Id";
            this.dataGridViewTextBoxColumn5.HeaderText = "თანამშრომლის ტიპი ID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "PersonPost_EmployeeType_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "თანამშრომლის ტიპი";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            this.dataGridViewTextBoxColumn6.Width = 150;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "PersonPost_Person_ID";
            this.dataGridViewTextBoxColumn7.HeaderText = "თანამშრომის ID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 150;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PersonPost_Person_FullName";
            this.dataGridViewTextBoxColumn8.HeaderText = "სახელი გვარი";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PersonPost_Post_Name";
            this.dataGridViewTextBoxColumn9.HeaderText = "თანამდებობა";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "PersonPost_Post_ID";
            this.dataGridViewTextBoxColumn10.HeaderText = "თანამდებობი ID";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "PersonPost_Post_BarCodePrefix";
            this.dataGridViewTextBoxColumn11.HeaderText = "პრეფიქსი";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "PersonPost_Brigade_Id";
            this.dataGridViewTextBoxColumn12.HeaderText = "ბრიგადის ID";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Visible = false;
            this.dataGridViewTextBoxColumn12.Width = 150;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "PersonPost_Brigade_Name";
            this.dataGridViewTextBoxColumn13.HeaderText = "ბრიგადა";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Visible = false;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "PersonPost_StartDate";
            this.dataGridViewTextBoxColumn14.HeaderText = "დაწყების თარიღე";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Visible = false;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "PersonPost_EndDate";
            this.dataGridViewTextBoxColumn15.HeaderText = "დასრულების თარიღი";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "PersonPost_DismissalOrder";
            this.dataGridViewTextBoxColumn16.HeaderText = "ბრძანება";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Visible = false;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "PersonPost_Description";
            this.dataGridViewTextBoxColumn17.HeaderText = "კომენტარი";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Visible = false;
            // 
            // HarvesterRowDistributionEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 438);
            this.Controls.Add(this.HarvesterRowGroupBox);
            this.Controls.Add(this.AllHarvesterGroupBox);
            this.Controls.Add(this.RemoveHarvesterButton);
            this.Controls.Add(this.AddHarverserButton);
            this.Controls.Add(this.RowLabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HarvesterRowDistributionEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HarvesterRowDistributionEditForm_FormClosing);
            this.Load += new System.EventHandler(this.CompanyRowEditForm_Load);
            this.AllHarvesterGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AllHarvesterDataGridView)).EndInit();
            this.HarvesterRowGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.HarvesterRowDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Label RowLabel;
        private System.Windows.Forms.Button AddHarverserButton;
        private System.Windows.Forms.Button RemoveHarvesterButton;
        private System.Windows.Forms.GroupBox AllHarvesterGroupBox;
        private System.Windows.Forms.DataGridView AllHarvesterDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersoPost_EmployeeBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_BalanceSheetType_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_BalanceSheetType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersoPost_EmployeeType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_EmployeeType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Person_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Person_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CareerEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Post_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Post_BarCodePrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Brigade_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Brigade_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_DismissalOrder;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Description;
        private System.Windows.Forms.GroupBox HarvesterRowGroupBox;
        private System.Windows.Forms.DataGridView HarvesterRowDataGridView;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
    }
}