namespace BerryManagementApplication.Forms.Accounts

{
    partial class AccountsMainForm
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
            this.components = new System.ComponentModel.Container();
            this.PermissionsTimer = new System.Windows.Forms.Timer(this.components);
            this.RolesTimer = new System.Windows.Forms.Timer(this.components);
            this.UsersTimer = new System.Windows.Forms.Timer(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.RSTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TransportWaybillsListGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TransportWaybillsDataGridView = new System.Windows.Forms.DataGridView();
            this.TransportWaybill_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybillDetail_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_RS_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_RS_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_Car_point_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_Type_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_Start_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransportWaybill_End_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Correction = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TWDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W_NAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QUANTITY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.WayBillDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.GetWeightButton = new System.Windows.Forms.Button();
            this.NonTransportWaybillsListGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.NonTransportWaybillsGridView = new System.Windows.Forms.DataGridView();
            this.NonTransportWaybill_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybillDetail_State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_Type_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_TransportWaybill_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_CompanySeler_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_CompanyBuyer_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_RS_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_RS_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_CompanySeler_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_CompanyBuyer_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_Start_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NonTransportWaybill_End_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.NTWDetailsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountsTabControl = new System.Windows.Forms.TabControl();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.RSTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.TransportWaybillsListGroupBox.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TransportWaybillsDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TWDetailsDataGridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.NonTransportWaybillsListGroupBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NonTransportWaybillsGridView)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NTWDetailsDataGridView)).BeginInit();
            this.AccountsTabControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // PermissionsTimer
            // 
            this.PermissionsTimer.Interval = 500;
            // 
            // RolesTimer
            // 
            this.RolesTimer.Interval = 300;
            // 
            // UsersTimer
            // 
            this.UsersTimer.Interval = 300;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1301, 632);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // RSTabPage
            // 
            this.RSTabPage.Controls.Add(this.splitContainer2);
            this.RSTabPage.Location = new System.Drawing.Point(4, 29);
            this.RSTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.RSTabPage.Name = "RSTabPage";
            this.RSTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.RSTabPage.Size = new System.Drawing.Size(1301, 632);
            this.RSTabPage.TabIndex = 1;
            this.RSTabPage.Text = "Waybills";
            this.RSTabPage.UseVisualStyleBackColor = true;
            this.RSTabPage.Enter += new System.EventHandler(this.RolesTabPage_Enter);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(4, 4);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TransportWaybillsListGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.NonTransportWaybillsListGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(1293, 624);
            this.splitContainer2.SplitterDistance = 369;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // TransportWaybillsListGroupBox
            // 
            this.TransportWaybillsListGroupBox.Controls.Add(this.groupBox3);
            this.TransportWaybillsListGroupBox.Controls.Add(this.groupBox4);
            this.TransportWaybillsListGroupBox.Controls.Add(this.groupBox6);
            this.TransportWaybillsListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransportWaybillsListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.TransportWaybillsListGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.TransportWaybillsListGroupBox.Name = "TransportWaybillsListGroupBox";
            this.TransportWaybillsListGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.TransportWaybillsListGroupBox.Size = new System.Drawing.Size(1293, 369);
            this.TransportWaybillsListGroupBox.TabIndex = 1;
            this.TransportWaybillsListGroupBox.TabStop = false;
            this.TransportWaybillsListGroupBox.Text = "TransportWaybills";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TransportWaybillsDataGridView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(4, 93);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(741, 272);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // TransportWaybillsDataGridView
            // 
            this.TransportWaybillsDataGridView.AllowUserToAddRows = false;
            this.TransportWaybillsDataGridView.AllowUserToDeleteRows = false;
            this.TransportWaybillsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransportWaybillsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransportWaybill_Id,
            this.TransportWaybillDetail_State,
            this.TransportWaybill_RS_Id,
            this.TransportWaybill_RS_Number,
            this.TransportWaybill_Company_Name,
            this.TransportWaybill_Car_point_Name,
            this.TransportWaybill_Type_Id,
            this.TransportWaybill_Start_DateTime,
            this.TransportWaybill_End_DateTime,
            this.Correction});
            this.TransportWaybillsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransportWaybillsDataGridView.Location = new System.Drawing.Point(3, 21);
            this.TransportWaybillsDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.TransportWaybillsDataGridView.Name = "TransportWaybillsDataGridView";
            this.TransportWaybillsDataGridView.ReadOnly = true;
            this.TransportWaybillsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.TransportWaybillsDataGridView.Size = new System.Drawing.Size(735, 249);
            this.TransportWaybillsDataGridView.TabIndex = 4;
            this.TransportWaybillsDataGridView.Tag = "28";
            this.TransportWaybillsDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransportWaybillsDataGridView_CellClick);
            this.TransportWaybillsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransportWaybillsDataGridView_CellContentDoubleClick);
            this.TransportWaybillsDataGridView.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.TransportWaybillsDataGridView_CellPainting);
            this.TransportWaybillsDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.TransportWaybillsDataGridView_RowEnter);
            // 
            // TransportWaybill_Id
            // 
            this.TransportWaybill_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_Id.DataPropertyName = "TransportWaybill_Id";
            this.TransportWaybill_Id.HeaderText = "N";
            this.TransportWaybill_Id.Name = "TransportWaybill_Id";
            this.TransportWaybill_Id.ReadOnly = true;
            this.TransportWaybill_Id.Width = 50;
            // 
            // TransportWaybillDetail_State
            // 
            this.TransportWaybillDetail_State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybillDetail_State.DataPropertyName = "TransportWaybillDetail_State";
            this.TransportWaybillDetail_State.HeaderText = "State";
            this.TransportWaybillDetail_State.Name = "TransportWaybillDetail_State";
            this.TransportWaybillDetail_State.ReadOnly = true;
            this.TransportWaybillDetail_State.Width = 77;
            // 
            // TransportWaybill_RS_Id
            // 
            this.TransportWaybill_RS_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_RS_Id.DataPropertyName = "TransportWaybill_RS_Id";
            this.TransportWaybill_RS_Id.HeaderText = "TransportWaybill_RS_Id";
            this.TransportWaybill_RS_Id.Name = "TransportWaybill_RS_Id";
            this.TransportWaybill_RS_Id.ReadOnly = true;
            this.TransportWaybill_RS_Id.Width = 218;
            // 
            // TransportWaybill_RS_Number
            // 
            this.TransportWaybill_RS_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_RS_Number.DataPropertyName = "TransportWaybill_RS_Number";
            this.TransportWaybill_RS_Number.HeaderText = "TransportWaybill_RS_Number";
            this.TransportWaybill_RS_Number.Name = "TransportWaybill_RS_Number";
            this.TransportWaybill_RS_Number.ReadOnly = true;
            this.TransportWaybill_RS_Number.Width = 264;
            // 
            // TransportWaybill_Company_Name
            // 
            this.TransportWaybill_Company_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_Company_Name.DataPropertyName = "TransportWaybill_Company_Name";
            this.TransportWaybill_Company_Name.HeaderText = "კომპანია";
            this.TransportWaybill_Company_Name.Name = "TransportWaybill_Company_Name";
            this.TransportWaybill_Company_Name.ReadOnly = true;
            this.TransportWaybill_Company_Name.Width = 111;
            // 
            // TransportWaybill_Car_point_Name
            // 
            this.TransportWaybill_Car_point_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_Car_point_Name.DataPropertyName = "TransportWaybill_CarNumber";
            this.TransportWaybill_Car_point_Name.HeaderText = "მანქანა";
            this.TransportWaybill_Car_point_Name.Name = "TransportWaybill_Car_point_Name";
            this.TransportWaybill_Car_point_Name.ReadOnly = true;
            this.TransportWaybill_Car_point_Name.Width = 102;
            // 
            // TransportWaybill_Type_Id
            // 
            this.TransportWaybill_Type_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_Type_Id.DataPropertyName = "TransportWaybill_Type_Id";
            this.TransportWaybill_Type_Id.HeaderText = "TransportWaybill_Type_Id";
            this.TransportWaybill_Type_Id.Name = "TransportWaybill_Type_Id";
            this.TransportWaybill_Type_Id.ReadOnly = true;
            this.TransportWaybill_Type_Id.Visible = false;
            // 
            // TransportWaybill_Start_DateTime
            // 
            this.TransportWaybill_Start_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TransportWaybill_Start_DateTime.DataPropertyName = "TransportWaybill_Start_DateTime";
            this.TransportWaybill_Start_DateTime.HeaderText = "დაწყების თარიღი";
            this.TransportWaybill_Start_DateTime.Name = "TransportWaybill_Start_DateTime";
            this.TransportWaybill_Start_DateTime.ReadOnly = true;
            this.TransportWaybill_Start_DateTime.Width = 174;
            // 
            // TransportWaybill_End_DateTime
            // 
            this.TransportWaybill_End_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TransportWaybill_End_DateTime.DataPropertyName = "TransportWaybill_End_DateTime";
            this.TransportWaybill_End_DateTime.HeaderText = "დასრულების თარიღი";
            this.TransportWaybill_End_DateTime.Name = "TransportWaybill_End_DateTime";
            this.TransportWaybill_End_DateTime.ReadOnly = true;
            this.TransportWaybill_End_DateTime.Width = 5;
            // 
            // Correction
            // 
            this.Correction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Correction.DataPropertyName = "TransportWaybillDetail_State";
            this.Correction.HeaderText = "კორექტირება";
            this.Correction.Name = "Correction";
            this.Correction.ReadOnly = true;
            this.Correction.Width = 126;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.TWDetailsDataGridView);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(745, 93);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(544, 272);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "პროდუქტი";
            // 
            // TWDetailsDataGridView
            // 
            this.TWDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TWDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.W_NAME,
            this.QUANTITY});
            this.TWDetailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TWDetailsDataGridView.Location = new System.Drawing.Point(3, 21);
            this.TWDetailsDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TWDetailsDataGridView.Name = "TWDetailsDataGridView";
            this.TWDetailsDataGridView.RowTemplate.Height = 24;
            this.TWDetailsDataGridView.Size = new System.Drawing.Size(538, 249);
            this.TWDetailsDataGridView.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "იდენტიფიკატორი";
            this.ID.Name = "ID";
            // 
            // W_NAME
            // 
            this.W_NAME.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.W_NAME.DataPropertyName = "W_NAME";
            this.W_NAME.HeaderText = "სახელი";
            this.W_NAME.Name = "W_NAME";
            // 
            // QUANTITY
            // 
            this.QUANTITY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QUANTITY.DataPropertyName = "QUANTITY";
            this.QUANTITY.HeaderText = "რაოდენობა";
            this.QUANTITY.Name = "QUANTITY";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(4, 23);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(1285, 70);
            this.groupBox6.TabIndex = 11;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "ფილტრაცია";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tableLayoutPanel1.Controls.Add(this.WayBillDateTimePicker, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.GetWeightButton, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 21);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1279, 47);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // WayBillDateTimePicker
            // 
            this.WayBillDateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WayBillDateTimePicker.Location = new System.Drawing.Point(962, 11);
            this.WayBillDateTimePicker.Margin = new System.Windows.Forms.Padding(3, 7, 3, 2);
            this.WayBillDateTimePicker.Name = "WayBillDateTimePicker";
            this.WayBillDateTimePicker.Size = new System.Drawing.Size(249, 26);
            this.WayBillDateTimePicker.TabIndex = 3;
            // 
            // GetWeightButton
            // 
            this.GetWeightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GetWeightButton.Location = new System.Drawing.Point(1217, 6);
            this.GetWeightButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.GetWeightButton.Name = "GetWeightButton";
            this.GetWeightButton.Size = new System.Drawing.Size(57, 35);
            this.GetWeightButton.TabIndex = 4;
            this.GetWeightButton.Text = "ძებნა";
            this.GetWeightButton.UseVisualStyleBackColor = true;
            this.GetWeightButton.Click += new System.EventHandler(this.GetWeightButton_Click);
            // 
            // NonTransportWaybillsListGroupBox
            // 
            this.NonTransportWaybillsListGroupBox.Controls.Add(this.groupBox8);
            this.NonTransportWaybillsListGroupBox.Controls.Add(this.groupBox7);
            this.NonTransportWaybillsListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonTransportWaybillsListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.NonTransportWaybillsListGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.NonTransportWaybillsListGroupBox.Name = "NonTransportWaybillsListGroupBox";
            this.NonTransportWaybillsListGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.NonTransportWaybillsListGroupBox.Size = new System.Drawing.Size(1293, 250);
            this.NonTransportWaybillsListGroupBox.TabIndex = 0;
            this.NonTransportWaybillsListGroupBox.TabStop = false;
            this.NonTransportWaybillsListGroupBox.Text = "NonTransportWaybills";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.NonTransportWaybillsGridView);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(4, 23);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(741, 223);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            // 
            // NonTransportWaybillsGridView
            // 
            this.NonTransportWaybillsGridView.AllowUserToAddRows = false;
            this.NonTransportWaybillsGridView.AllowUserToDeleteRows = false;
            this.NonTransportWaybillsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NonTransportWaybillsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NonTransportWaybill_Id,
            this.NonTransportWaybillDetail_State,
            this.NonTransportWaybill_Type_Id,
            this.NonTransportWaybill_TransportWaybill_Id,
            this.NonTransportWaybill_CompanySeler_Id,
            this.NonTransportWaybill_CompanyBuyer_Id,
            this.NonTransportWaybill_RS_Id,
            this.NonTransportWaybill_RS_Number,
            this.NonTransportWaybill_CompanySeler_Name,
            this.NonTransportWaybill_CompanyBuyer_Name,
            this.NonTransportWaybill_Start_DateTime,
            this.NonTransportWaybill_End_DateTime});
            this.NonTransportWaybillsGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NonTransportWaybillsGridView.Location = new System.Drawing.Point(3, 21);
            this.NonTransportWaybillsGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NonTransportWaybillsGridView.Name = "NonTransportWaybillsGridView";
            this.NonTransportWaybillsGridView.ReadOnly = true;
            this.NonTransportWaybillsGridView.RowTemplate.Height = 24;
            this.NonTransportWaybillsGridView.Size = new System.Drawing.Size(735, 200);
            this.NonTransportWaybillsGridView.TabIndex = 10;
            this.NonTransportWaybillsGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NonTransportWaybillsGridView_CellContentDoubleClick);
            this.NonTransportWaybillsGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.NonTransportWaybillsGridView_RowEnter);
            // 
            // NonTransportWaybill_Id
            // 
            this.NonTransportWaybill_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_Id.DataPropertyName = "NonTransportWaybill_Id";
            this.NonTransportWaybill_Id.HeaderText = "N";
            this.NonTransportWaybill_Id.Name = "NonTransportWaybill_Id";
            this.NonTransportWaybill_Id.ReadOnly = true;
            // 
            // NonTransportWaybillDetail_State
            // 
            this.NonTransportWaybillDetail_State.DataPropertyName = "NonTransportWaybillDetail_State";
            this.NonTransportWaybillDetail_State.HeaderText = "State";
            this.NonTransportWaybillDetail_State.Name = "NonTransportWaybillDetail_State";
            this.NonTransportWaybillDetail_State.ReadOnly = true;
            // 
            // NonTransportWaybill_Type_Id
            // 
            this.NonTransportWaybill_Type_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_Type_Id.DataPropertyName = "NonTransportWaybill_Type_Id";
            this.NonTransportWaybill_Type_Id.HeaderText = "NonTransportWaybill_Type_Id";
            this.NonTransportWaybill_Type_Id.Name = "NonTransportWaybill_Type_Id";
            this.NonTransportWaybill_Type_Id.ReadOnly = true;
            this.NonTransportWaybill_Type_Id.Visible = false;
            // 
            // NonTransportWaybill_TransportWaybill_Id
            // 
            this.NonTransportWaybill_TransportWaybill_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_TransportWaybill_Id.DataPropertyName = "NonTransportWaybill_TransportWaybill_Id";
            this.NonTransportWaybill_TransportWaybill_Id.HeaderText = "NonTransportWaybill_TransportWaybill_Id";
            this.NonTransportWaybill_TransportWaybill_Id.Name = "NonTransportWaybill_TransportWaybill_Id";
            this.NonTransportWaybill_TransportWaybill_Id.ReadOnly = true;
            // 
            // NonTransportWaybill_CompanySeler_Id
            // 
            this.NonTransportWaybill_CompanySeler_Id.HeaderText = "NonTransportWaybill_CompanySeler_Id";
            this.NonTransportWaybill_CompanySeler_Id.Name = "NonTransportWaybill_CompanySeler_Id";
            this.NonTransportWaybill_CompanySeler_Id.ReadOnly = true;
            this.NonTransportWaybill_CompanySeler_Id.Visible = false;
            // 
            // NonTransportWaybill_CompanyBuyer_Id
            // 
            this.NonTransportWaybill_CompanyBuyer_Id.HeaderText = "NonTransportWaybill_CompanyBuyer_Id";
            this.NonTransportWaybill_CompanyBuyer_Id.Name = "NonTransportWaybill_CompanyBuyer_Id";
            this.NonTransportWaybill_CompanyBuyer_Id.ReadOnly = true;
            this.NonTransportWaybill_CompanyBuyer_Id.Visible = false;
            // 
            // NonTransportWaybill_RS_Id
            // 
            this.NonTransportWaybill_RS_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_RS_Id.DataPropertyName = "NonTransportWaybill_RS_Id";
            this.NonTransportWaybill_RS_Id.HeaderText = "NonTransportWaybill_RS_Id";
            this.NonTransportWaybill_RS_Id.Name = "NonTransportWaybill_RS_Id";
            this.NonTransportWaybill_RS_Id.ReadOnly = true;
            // 
            // NonTransportWaybill_RS_Number
            // 
            this.NonTransportWaybill_RS_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_RS_Number.DataPropertyName = "NonTransportWaybill_RS_Number";
            this.NonTransportWaybill_RS_Number.HeaderText = "NonTransportWaybill_RS_Number";
            this.NonTransportWaybill_RS_Number.Name = "NonTransportWaybill_RS_Number";
            this.NonTransportWaybill_RS_Number.ReadOnly = true;
            // 
            // NonTransportWaybill_CompanySeler_Name
            // 
            this.NonTransportWaybill_CompanySeler_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_CompanySeler_Name.DataPropertyName = "NonTransportWaybill__CompanySeler_Name";
            this.NonTransportWaybill_CompanySeler_Name.HeaderText = "გამყიდველი კომპანი";
            this.NonTransportWaybill_CompanySeler_Name.Name = "NonTransportWaybill_CompanySeler_Name";
            this.NonTransportWaybill_CompanySeler_Name.ReadOnly = true;
            // 
            // NonTransportWaybill_CompanyBuyer_Name
            // 
            this.NonTransportWaybill_CompanyBuyer_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_CompanyBuyer_Name.DataPropertyName = "NonTransportWaybill__CompanyBuyer_Name";
            this.NonTransportWaybill_CompanyBuyer_Name.HeaderText = "მყიდველი კომპანია";
            this.NonTransportWaybill_CompanyBuyer_Name.Name = "NonTransportWaybill_CompanyBuyer_Name";
            this.NonTransportWaybill_CompanyBuyer_Name.ReadOnly = true;
            // 
            // NonTransportWaybill_Start_DateTime
            // 
            this.NonTransportWaybill_Start_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_Start_DateTime.DataPropertyName = "NonTransportWaybill_Start_DateTime";
            this.NonTransportWaybill_Start_DateTime.HeaderText = "დაწყების თარიღი";
            this.NonTransportWaybill_Start_DateTime.Name = "NonTransportWaybill_Start_DateTime";
            this.NonTransportWaybill_Start_DateTime.ReadOnly = true;
            // 
            // NonTransportWaybill_End_DateTime
            // 
            this.NonTransportWaybill_End_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NonTransportWaybill_End_DateTime.DataPropertyName = "NonTransportWaybill_End_DateTime";
            this.NonTransportWaybill_End_DateTime.HeaderText = "დასრულების თარიღი";
            this.NonTransportWaybill_End_DateTime.Name = "NonTransportWaybill_End_DateTime";
            this.NonTransportWaybill_End_DateTime.ReadOnly = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.NTWDetailsDataGridView);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox7.Location = new System.Drawing.Point(745, 23);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(544, 223);
            this.groupBox7.TabIndex = 13;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "პროდუქტი";
            // 
            // NTWDetailsDataGridView
            // 
            this.NTWDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NTWDetailsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.NTWDetailsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NTWDetailsDataGridView.Location = new System.Drawing.Point(3, 21);
            this.NTWDetailsDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NTWDetailsDataGridView.Name = "NTWDetailsDataGridView";
            this.NTWDetailsDataGridView.RowTemplate.Height = 24;
            this.NTWDetailsDataGridView.Size = new System.Drawing.Size(538, 200);
            this.NTWDetailsDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "იდენტიფიკატორი";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "W_NAME";
            this.dataGridViewTextBoxColumn2.HeaderText = "სახელი";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "QUANTITY";
            this.dataGridViewTextBoxColumn3.HeaderText = "რაოდენობა";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // AccountsTabControl
            // 
            this.AccountsTabControl.Controls.Add(this.RSTabPage);
            this.AccountsTabControl.Controls.Add(this.tabPage1);
            this.AccountsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountsTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountsTabControl.Location = new System.Drawing.Point(0, 0);
            this.AccountsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.AccountsTabControl.Name = "AccountsTabControl";
            this.AccountsTabControl.SelectedIndex = 0;
            this.AccountsTabControl.Size = new System.Drawing.Size(1309, 665);
            this.AccountsTabControl.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 148);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(539, 25);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.Visible = false;
            // 
            // AccountsMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1309, 665);
            this.Controls.Add(this.AccountsTabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AccountsMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.RSTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.TransportWaybillsListGroupBox.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TransportWaybillsDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TWDetailsDataGridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.NonTransportWaybillsListGroupBox.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NonTransportWaybillsGridView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NTWDetailsDataGridView)).EndInit();
            this.AccountsTabControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer PermissionsTimer;
        private System.Windows.Forms.Timer RolesTimer;
        private System.Windows.Forms.Timer UsersTimer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage RSTabPage;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox TransportWaybillsListGroupBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView TransportWaybillsDataGridView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView TWDetailsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn W_NAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn QUANTITY;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker WayBillDateTimePicker;
        private System.Windows.Forms.Button GetWeightButton;
        private System.Windows.Forms.GroupBox NonTransportWaybillsListGroupBox;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView NonTransportWaybillsGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybillDetail_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_Type_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_TransportWaybill_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_CompanySeler_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_CompanyBuyer_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_RS_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_RS_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_CompanySeler_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_CompanyBuyer_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_Start_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NonTransportWaybill_End_DateTime;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView NTWDetailsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.TabControl AccountsTabControl;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybillDetail_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_RS_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_RS_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_Car_point_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_Type_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_Start_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransportWaybill_End_DateTime;
        private System.Windows.Forms.DataGridViewButtonColumn Correction;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}