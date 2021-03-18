namespace BerryManagementApplication.Forms.Structure
{
    partial class StructureMainForm
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
            this.CarsTabPage = new System.Windows.Forms.TabPage();
            this.CarGroupBox = new System.Windows.Forms.GroupBox();
            this.CarDataGridView = new System.Windows.Forms.DataGridView();
            this.Car_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Car_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Car_Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Car_SideType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Car_SideType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargroupBox1 = new System.Windows.Forms.GroupBox();
            this.CarDeleteButton = new System.Windows.Forms.Button();
            this.CarEditButton = new System.Windows.Forms.Button();
            this.CarAddButton = new System.Windows.Forms.Button();
            this.CarDriversTabPage = new System.Windows.Forms.TabPage();
            this.CarDriversGroupBox = new System.Windows.Forms.GroupBox();
            this.CarDriversDataGridView = new System.Windows.Forms.DataGridView();
            this.CarDriver_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_Car_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_Car_Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_Car_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_Person_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_Person_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_PersonPost_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDriver_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarDrivergroupBox1 = new System.Windows.Forms.GroupBox();
            this.CarDriverDeleteButton = new System.Windows.Forms.Button();
            this.CarDriverEditButton = new System.Windows.Forms.Button();
            this.CarDriverAddButton = new System.Windows.Forms.Button();
            this.BrigadesTabPage = new System.Windows.Forms.TabPage();
            this.BrigadeGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.PersonBrigadeDgv = new ThetaControlsLibrary.DataGridViewEI();
            this.PersonPost_Person_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_EmployeeBarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Post_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_Brigade_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_BalanceSheetType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_EmployeeType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonPost_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrigadesDataGridView = new System.Windows.Forms.DataGridView();
            this.Brigade_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brigade_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Brigade_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrigadegroupBox1 = new System.Windows.Forms.GroupBox();
            this.BagesPrintButton = new System.Windows.Forms.Button();
            this.BrigadeDeleteButton = new System.Windows.Forms.Button();
            this.BrigadUpdateButton = new System.Windows.Forms.Button();
            this.BrigadeAddButton = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.StructureTabControl = new System.Windows.Forms.TabControl();
            this.CompanyCarsTabPage = new System.Windows.Forms.TabPage();
            this.CompanyCarsGroupBox = new System.Windows.Forms.GroupBox();
            this.CompanyCarsDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_Car_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_Car_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_Car_Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCar_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyCargroupBox1 = new System.Windows.Forms.GroupBox();
            this.CompanyCarDeleteButton = new System.Windows.Forms.Button();
            this.CompanyCarEditButton = new System.Windows.Forms.Button();
            this.CompanyCarAddButton = new System.Windows.Forms.Button();
            this.PostsTabPage = new System.Windows.Forms.TabPage();
            this.PostGroupBox = new System.Windows.Forms.GroupBox();
            this.PostDataGridView = new System.Windows.Forms.DataGridView();
            this.Post_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_BarCodePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_BalanceSheetType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post_BalanceSheetType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PostDeleteButton = new System.Windows.Forms.Button();
            this.PostEditButton = new System.Windows.Forms.Button();
            this.PostAddButton = new System.Windows.Forms.Button();
            this.PointsTabPage = new System.Windows.Forms.TabPage();
            this.PointGroupBox = new System.Windows.Forms.GroupBox();
            this.PointDataGridView = new System.Windows.Forms.DataGridView();
            this.Point_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Point_PointType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_PointType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_PointType_IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Point_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Car_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Car_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Car_Model = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Point_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.PointPrintButton = new System.Windows.Forms.Button();
            this.PointDeleteButton = new System.Windows.Forms.Button();
            this.PointEditButton = new System.Windows.Forms.Button();
            this.PointAddButton = new System.Windows.Forms.Button();
            this.InsideCompanyTabPage = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.InsideCompanyBreedDataGridView = new System.Windows.Forms.DataGridView();
            this.RowBreed_Breed_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowBreed_TreeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowBreed_PlantYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowBreed_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowBreed_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.InsideCompanyRowdataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyRow_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRowsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.InsideCompanyDataGridView = new System.Windows.Forms.DataGridView();
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
            this.Company_IBAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_RS_UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_RS_Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.InsideCompanyDeleteButton = new System.Windows.Forms.Button();
            this.InsideCompanyEditButton = new System.Windows.Forms.Button();
            this.InsideCompanyAddButton = new System.Windows.Forms.Button();
            this.CompanyesTabPage = new System.Windows.Forms.TabPage();
            this.CompanyGroupBox = new System.Windows.Forms.GroupBox();
            this.OutsideCompanyDataGridView = new System.Windows.Forms.DataGridView();
            this.Company_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Identity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_SideType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_SideType_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_CitizenshipId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Citizenship_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Citizenship_NameEn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Address1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Address2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Phone1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Company_Phone2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.OutsideCompanyDeleteButton = new System.Windows.Forms.Button();
            this.OutsideCompanyEditButton = new System.Windows.Forms.Button();
            this.OutsideCompanyAddButton = new System.Windows.Forms.Button();
            this.RowsTabPage = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.RowBreedgroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.RowBreeddataGridView = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.RowRowBreedAddButton = new System.Windows.Forms.Button();
            this.RowRowBreedDeleteButton = new System.Windows.Forms.Button();
            this.RowRowBreedEditButton = new System.Windows.Forms.Button();
            this.CompanyRowgroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.CompanyRowdataGridView = new System.Windows.Forms.DataGridView();
            this.CompanyRow_Company_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_StarDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompanyRow_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RowGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.RowDataGridView = new System.Windows.Forms.DataGridView();
            this.Row_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sector_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Subrow_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Row_Barkode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.RowAddButton = new System.Windows.Forms.Button();
            this.RowDeleteButton = new System.Windows.Forms.Button();
            this.RowEditButton = new System.Windows.Forms.Button();
            this.CarsTabPage.SuspendLayout();
            this.CarGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarDataGridView)).BeginInit();
            this.CargroupBox1.SuspendLayout();
            this.CarDriversTabPage.SuspendLayout();
            this.CarDriversGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CarDriversDataGridView)).BeginInit();
            this.CarDrivergroupBox1.SuspendLayout();
            this.BrigadesTabPage.SuspendLayout();
            this.BrigadeGroupBox.SuspendLayout();
            this.groupBox13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PersonBrigadeDgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrigadesDataGridView)).BeginInit();
            this.BrigadegroupBox1.SuspendLayout();
            this.StructureTabControl.SuspendLayout();
            this.CompanyCarsTabPage.SuspendLayout();
            this.CompanyCarsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyCarsDataGridView)).BeginInit();
            this.CompanyCargroupBox1.SuspendLayout();
            this.PostsTabPage.SuspendLayout();
            this.PostGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostDataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.PointsTabPage.SuspendLayout();
            this.PointGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PointDataGridView)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.InsideCompanyTabPage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyBreedDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyRowdataGridView)).BeginInit();
            this.CompanyRowsGroupBox.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyDataGridView)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.CompanyesTabPage.SuspendLayout();
            this.CompanyGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OutsideCompanyDataGridView)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.RowsTabPage.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.RowBreedgroupBox.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowBreeddataGridView)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.CompanyRowgroupBox.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyRowdataGridView)).BeginInit();
            this.RowGroupBox.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RowDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // CarsTabPage
            // 
            this.CarsTabPage.Controls.Add(this.CarGroupBox);
            this.CarsTabPage.Controls.Add(this.CargroupBox1);
            this.CarsTabPage.Location = new System.Drawing.Point(4, 29);
            this.CarsTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CarsTabPage.Name = "CarsTabPage";
            this.CarsTabPage.Size = new System.Drawing.Size(1260, 673);
            this.CarsTabPage.TabIndex = 2;
            this.CarsTabPage.Text = "მანქანები";
            this.CarsTabPage.UseVisualStyleBackColor = true;
            this.CarsTabPage.Enter += new System.EventHandler(this.CarsTabPage_Enter);
            // 
            // CarGroupBox
            // 
            this.CarGroupBox.Controls.Add(this.CarDataGridView);
            this.CarGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarGroupBox.Location = new System.Drawing.Point(0, 0);
            this.CarGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarGroupBox.Name = "CarGroupBox";
            this.CarGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarGroupBox.Size = new System.Drawing.Size(1097, 673);
            this.CarGroupBox.TabIndex = 11;
            this.CarGroupBox.TabStop = false;
            this.CarGroupBox.Text = "მანქანები";
            // 
            // CarDataGridView
            // 
            this.CarDataGridView.AllowUserToAddRows = false;
            this.CarDataGridView.AllowUserToDeleteRows = false;
            this.CarDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Car_Id,
            this.Car_Number,
            this.Car_Model,
            this.Car_SideType_Id,
            this.Car_SideType_Name});
            this.CarDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarDataGridView.Location = new System.Drawing.Point(3, 21);
            this.CarDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDataGridView.Name = "CarDataGridView";
            this.CarDataGridView.ReadOnly = true;
            this.CarDataGridView.RowTemplate.Height = 24;
            this.CarDataGridView.Size = new System.Drawing.Size(1091, 650);
            this.CarDataGridView.TabIndex = 0;
            this.CarDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CarDataGridView_CellDoubleClick);
            this.CarDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CarDataGridView_RowsAdded);
            this.CarDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.CarDataGridView_RowsRemoved);
            // 
            // Car_Id
            // 
            this.Car_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Car_Id.DataPropertyName = "Car_Id";
            this.Car_Id.HeaderText = "მანქანის ID";
            this.Car_Id.Name = "Car_Id";
            this.Car_Id.ReadOnly = true;
            this.Car_Id.Visible = false;
            // 
            // Car_Number
            // 
            this.Car_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Car_Number.DataPropertyName = "Car_Number";
            this.Car_Number.HeaderText = "ნომერი";
            this.Car_Number.Name = "Car_Number";
            this.Car_Number.ReadOnly = true;
            // 
            // Car_Model
            // 
            this.Car_Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Car_Model.DataPropertyName = "Car_Model";
            this.Car_Model.HeaderText = "მოდელი";
            this.Car_Model.Name = "Car_Model";
            this.Car_Model.ReadOnly = true;
            // 
            // Car_SideType_Id
            // 
            this.Car_SideType_Id.DataPropertyName = "Car_SideType_Id";
            this.Car_SideType_Id.HeaderText = "Car_SideType_Id";
            this.Car_SideType_Id.Name = "Car_SideType_Id";
            this.Car_SideType_Id.ReadOnly = true;
            this.Car_SideType_Id.Visible = false;
            // 
            // Car_SideType_Name
            // 
            this.Car_SideType_Name.DataPropertyName = "Car_SideType_Name";
            this.Car_SideType_Name.HeaderText = "SideType";
            this.Car_SideType_Name.Name = "Car_SideType_Name";
            this.Car_SideType_Name.ReadOnly = true;
            // 
            // CargroupBox1
            // 
            this.CargroupBox1.Controls.Add(this.CarDeleteButton);
            this.CargroupBox1.Controls.Add(this.CarEditButton);
            this.CargroupBox1.Controls.Add(this.CarAddButton);
            this.CargroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.CargroupBox1.Location = new System.Drawing.Point(1097, 0);
            this.CargroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CargroupBox1.Name = "CargroupBox1";
            this.CargroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CargroupBox1.Size = new System.Drawing.Size(163, 673);
            this.CargroupBox1.TabIndex = 10;
            this.CargroupBox1.TabStop = false;
            this.CargroupBox1.Text = "მოქმედებები";
            // 
            // CarDeleteButton
            // 
            this.CarDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.CarDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDeleteButton.Name = "CarDeleteButton";
            this.CarDeleteButton.Size = new System.Drawing.Size(157, 42);
            this.CarDeleteButton.TabIndex = 11;
            this.CarDeleteButton.Text = "წაშლა";
            this.CarDeleteButton.UseVisualStyleBackColor = true;
            this.CarDeleteButton.Click += new System.EventHandler(this.CarDeleteButton_Click);
            // 
            // CarEditButton
            // 
            this.CarEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarEditButton.Location = new System.Drawing.Point(3, 60);
            this.CarEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarEditButton.Name = "CarEditButton";
            this.CarEditButton.Size = new System.Drawing.Size(157, 39);
            this.CarEditButton.TabIndex = 10;
            this.CarEditButton.Text = "განახლება";
            this.CarEditButton.UseVisualStyleBackColor = true;
            this.CarEditButton.Click += new System.EventHandler(this.CarEditButton_Click);
            // 
            // CarAddButton
            // 
            this.CarAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarAddButton.Location = new System.Drawing.Point(3, 21);
            this.CarAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarAddButton.Name = "CarAddButton";
            this.CarAddButton.Size = new System.Drawing.Size(157, 39);
            this.CarAddButton.TabIndex = 7;
            this.CarAddButton.Text = "დამატება";
            this.CarAddButton.UseVisualStyleBackColor = true;
            this.CarAddButton.Click += new System.EventHandler(this.CarAddButton_Click);
            // 
            // CarDriversTabPage
            // 
            this.CarDriversTabPage.Controls.Add(this.CarDriversGroupBox);
            this.CarDriversTabPage.Controls.Add(this.CarDrivergroupBox1);
            this.CarDriversTabPage.Location = new System.Drawing.Point(4, 29);
            this.CarDriversTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CarDriversTabPage.Name = "CarDriversTabPage";
            this.CarDriversTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.CarDriversTabPage.Size = new System.Drawing.Size(1260, 673);
            this.CarDriversTabPage.TabIndex = 1;
            this.CarDriversTabPage.Text = "მძღოლები";
            this.CarDriversTabPage.UseVisualStyleBackColor = true;
            this.CarDriversTabPage.Enter += new System.EventHandler(this.CarDriversTabPage_Enter);
            // 
            // CarDriversGroupBox
            // 
            this.CarDriversGroupBox.Controls.Add(this.CarDriversDataGridView);
            this.CarDriversGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarDriversGroupBox.Location = new System.Drawing.Point(4, 4);
            this.CarDriversGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriversGroupBox.Name = "CarDriversGroupBox";
            this.CarDriversGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriversGroupBox.Size = new System.Drawing.Size(1089, 665);
            this.CarDriversGroupBox.TabIndex = 14;
            this.CarDriversGroupBox.TabStop = false;
            this.CarDriversGroupBox.Text = "მძღოლები";
            // 
            // CarDriversDataGridView
            // 
            this.CarDriversDataGridView.AllowUserToAddRows = false;
            this.CarDriversDataGridView.AllowUserToDeleteRows = false;
            this.CarDriversDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarDriversDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CarDriver_Id,
            this.CarDriver_Car_Id,
            this.CarDriver_Car_Model,
            this.CarDriver_Car_Number,
            this.CarDriver_Person_Id,
            this.CarDriver_Person_Name,
            this.CarDriver_PersonPost_Id,
            this.CarDriver_StartDate,
            this.CarDriver_EndDate});
            this.CarDriversDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CarDriversDataGridView.Location = new System.Drawing.Point(3, 21);
            this.CarDriversDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriversDataGridView.Name = "CarDriversDataGridView";
            this.CarDriversDataGridView.ReadOnly = true;
            this.CarDriversDataGridView.RowTemplate.Height = 24;
            this.CarDriversDataGridView.Size = new System.Drawing.Size(1083, 642);
            this.CarDriversDataGridView.TabIndex = 0;
            this.CarDriversDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CarDriversDataGridView_CellDoubleClick);
            this.CarDriversDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CarDriversDataGridView_RowsAdded);
            this.CarDriversDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.CarDriversDataGridView_RowsRemoved);
            // 
            // CarDriver_Id
            // 
            this.CarDriver_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Id.DataPropertyName = "CarDriver_Id";
            this.CarDriver_Id.HeaderText = "მძღოლის ID";
            this.CarDriver_Id.Name = "CarDriver_Id";
            this.CarDriver_Id.ReadOnly = true;
            this.CarDriver_Id.Visible = false;
            // 
            // CarDriver_Car_Id
            // 
            this.CarDriver_Car_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Car_Id.DataPropertyName = "CarDriver_Car_Id";
            this.CarDriver_Car_Id.HeaderText = "მანქანის ID";
            this.CarDriver_Car_Id.Name = "CarDriver_Car_Id";
            this.CarDriver_Car_Id.ReadOnly = true;
            this.CarDriver_Car_Id.Visible = false;
            // 
            // CarDriver_Car_Model
            // 
            this.CarDriver_Car_Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Car_Model.DataPropertyName = "CarDriver_Car_Model";
            this.CarDriver_Car_Model.HeaderText = "მანქანის მოდელი";
            this.CarDriver_Car_Model.Name = "CarDriver_Car_Model";
            this.CarDriver_Car_Model.ReadOnly = true;
            // 
            // CarDriver_Car_Number
            // 
            this.CarDriver_Car_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Car_Number.DataPropertyName = "CarDriver_Car_Number";
            this.CarDriver_Car_Number.HeaderText = "მანქანის ნომერი";
            this.CarDriver_Car_Number.Name = "CarDriver_Car_Number";
            this.CarDriver_Car_Number.ReadOnly = true;
            // 
            // CarDriver_Person_Id
            // 
            this.CarDriver_Person_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Person_Id.DataPropertyName = "CarDriver_Person_Id";
            this.CarDriver_Person_Id.HeaderText = "თანამშრომლის ID";
            this.CarDriver_Person_Id.Name = "CarDriver_Person_Id";
            this.CarDriver_Person_Id.ReadOnly = true;
            this.CarDriver_Person_Id.Visible = false;
            // 
            // CarDriver_Person_Name
            // 
            this.CarDriver_Person_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_Person_Name.DataPropertyName = "CarDriver_Person_Name";
            this.CarDriver_Person_Name.HeaderText = "სახელი და გვარი";
            this.CarDriver_Person_Name.Name = "CarDriver_Person_Name";
            this.CarDriver_Person_Name.ReadOnly = true;
            // 
            // CarDriver_PersonPost_Id
            // 
            this.CarDriver_PersonPost_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_PersonPost_Id.DataPropertyName = "CarDriver_PersonPost_Id";
            this.CarDriver_PersonPost_Id.HeaderText = "თანამდებობის ID";
            this.CarDriver_PersonPost_Id.Name = "CarDriver_PersonPost_Id";
            this.CarDriver_PersonPost_Id.ReadOnly = true;
            this.CarDriver_PersonPost_Id.Visible = false;
            // 
            // CarDriver_StartDate
            // 
            this.CarDriver_StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_StartDate.DataPropertyName = "CarDriver_StartDate";
            this.CarDriver_StartDate.HeaderText = "დაწყების თარიღი";
            this.CarDriver_StartDate.Name = "CarDriver_StartDate";
            this.CarDriver_StartDate.ReadOnly = true;
            // 
            // CarDriver_EndDate
            // 
            this.CarDriver_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CarDriver_EndDate.DataPropertyName = "CarDriver_EndDate";
            this.CarDriver_EndDate.HeaderText = "დასრულების თარიღი";
            this.CarDriver_EndDate.Name = "CarDriver_EndDate";
            this.CarDriver_EndDate.ReadOnly = true;
            // 
            // CarDrivergroupBox1
            // 
            this.CarDrivergroupBox1.Controls.Add(this.CarDriverDeleteButton);
            this.CarDrivergroupBox1.Controls.Add(this.CarDriverEditButton);
            this.CarDrivergroupBox1.Controls.Add(this.CarDriverAddButton);
            this.CarDrivergroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.CarDrivergroupBox1.Location = new System.Drawing.Point(1093, 4);
            this.CarDrivergroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDrivergroupBox1.Name = "CarDrivergroupBox1";
            this.CarDrivergroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDrivergroupBox1.Size = new System.Drawing.Size(163, 665);
            this.CarDrivergroupBox1.TabIndex = 13;
            this.CarDrivergroupBox1.TabStop = false;
            this.CarDrivergroupBox1.Text = "მოქმედებები";
            // 
            // CarDriverDeleteButton
            // 
            this.CarDriverDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarDriverDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.CarDriverDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriverDeleteButton.Name = "CarDriverDeleteButton";
            this.CarDriverDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.CarDriverDeleteButton.TabIndex = 14;
            this.CarDriverDeleteButton.Text = "წაშლა";
            this.CarDriverDeleteButton.UseVisualStyleBackColor = true;
            this.CarDriverDeleteButton.Click += new System.EventHandler(this.CarDriverDeleteButton_Click);
            // 
            // CarDriverEditButton
            // 
            this.CarDriverEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarDriverEditButton.Location = new System.Drawing.Point(3, 60);
            this.CarDriverEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriverEditButton.Name = "CarDriverEditButton";
            this.CarDriverEditButton.Size = new System.Drawing.Size(157, 39);
            this.CarDriverEditButton.TabIndex = 13;
            this.CarDriverEditButton.Text = "განახლება";
            this.CarDriverEditButton.UseVisualStyleBackColor = true;
            this.CarDriverEditButton.Click += new System.EventHandler(this.CarDriverEditButton_Click);
            // 
            // CarDriverAddButton
            // 
            this.CarDriverAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CarDriverAddButton.Location = new System.Drawing.Point(3, 21);
            this.CarDriverAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CarDriverAddButton.Name = "CarDriverAddButton";
            this.CarDriverAddButton.Size = new System.Drawing.Size(157, 39);
            this.CarDriverAddButton.TabIndex = 10;
            this.CarDriverAddButton.Text = "დამატება";
            this.CarDriverAddButton.UseVisualStyleBackColor = true;
            this.CarDriverAddButton.Click += new System.EventHandler(this.CarDriverAddButton_Click);
            // 
            // BrigadesTabPage
            // 
            this.BrigadesTabPage.Controls.Add(this.BrigadeGroupBox);
            this.BrigadesTabPage.Controls.Add(this.BrigadegroupBox1);
            this.BrigadesTabPage.Location = new System.Drawing.Point(4, 29);
            this.BrigadesTabPage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrigadesTabPage.Name = "BrigadesTabPage";
            this.BrigadesTabPage.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BrigadesTabPage.Size = new System.Drawing.Size(1260, 673);
            this.BrigadesTabPage.TabIndex = 0;
            this.BrigadesTabPage.Text = "ჯგუფები";
            this.BrigadesTabPage.UseVisualStyleBackColor = true;
            this.BrigadesTabPage.Enter += new System.EventHandler(this.BrigadesTabPage_Enter);
            // 
            // BrigadeGroupBox
            // 
            this.BrigadeGroupBox.Controls.Add(this.groupBox13);
            this.BrigadeGroupBox.Controls.Add(this.BrigadesDataGridView);
            this.BrigadeGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrigadeGroupBox.Location = new System.Drawing.Point(4, 4);
            this.BrigadeGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadeGroupBox.Name = "BrigadeGroupBox";
            this.BrigadeGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadeGroupBox.Size = new System.Drawing.Size(1089, 665);
            this.BrigadeGroupBox.TabIndex = 5;
            this.BrigadeGroupBox.TabStop = false;
            this.BrigadeGroupBox.Text = "ჯგუფები";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.PersonBrigadeDgv);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox13.Location = new System.Drawing.Point(3, 371);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(3, 5, 3, 2);
            this.groupBox13.Size = new System.Drawing.Size(1083, 292);
            this.groupBox13.TabIndex = 1;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "თანამშრომლები ჯგუფში";
            // 
            // PersonBrigadeDgv
            // 
            this.PersonBrigadeDgv.AllowUserToAddRows = false;
            this.PersonBrigadeDgv.AllowUserToDeleteRows = false;
            this.PersonBrigadeDgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonBrigadeDgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonPost_Person_FullName,
            this.PersonPost_EmployeeBarCode,
            this.PersonPost_Post_Name,
            this.PersonPost_Brigade_Name,
            this.PersonPost_BalanceSheetType_Name,
            this.PersonPost_EmployeeType_Name,
            this.PersonPost_StartDate,
            this.PersonPost_EndDate});
            this.PersonBrigadeDgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PersonBrigadeDgv.Location = new System.Drawing.Point(3, 24);
            this.PersonBrigadeDgv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PersonBrigadeDgv.Name = "PersonBrigadeDgv";
            this.PersonBrigadeDgv.ReadOnly = true;
            this.PersonBrigadeDgv.RowTemplate.Height = 24;
            this.PersonBrigadeDgv.Size = new System.Drawing.Size(1077, 266);
            this.PersonBrigadeDgv.TabIndex = 0;
            this.PersonBrigadeDgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonBrigadeDgv_RowEnter);
            // 
            // PersonPost_Person_FullName
            // 
            this.PersonPost_Person_FullName.DataPropertyName = "PersonPost_Person_FullName";
            this.PersonPost_Person_FullName.HeaderText = "სახელი/გვარი";
            this.PersonPost_Person_FullName.Name = "PersonPost_Person_FullName";
            this.PersonPost_Person_FullName.ReadOnly = true;
            this.PersonPost_Person_FullName.Width = 200;
            // 
            // PersonPost_EmployeeBarCode
            // 
            this.PersonPost_EmployeeBarCode.DataPropertyName = "PersonPost_EmployeeBarCode";
            this.PersonPost_EmployeeBarCode.HeaderText = "ბარკოდი";
            this.PersonPost_EmployeeBarCode.Name = "PersonPost_EmployeeBarCode";
            this.PersonPost_EmployeeBarCode.ReadOnly = true;
            // 
            // PersonPost_Post_Name
            // 
            this.PersonPost_Post_Name.DataPropertyName = "PersonPost_Post_Name";
            this.PersonPost_Post_Name.HeaderText = "პოსტის სახელი";
            this.PersonPost_Post_Name.Name = "PersonPost_Post_Name";
            this.PersonPost_Post_Name.ReadOnly = true;
            this.PersonPost_Post_Name.Width = 200;
            // 
            // PersonPost_Brigade_Name
            // 
            this.PersonPost_Brigade_Name.DataPropertyName = "PersonPost_Brigade_Name";
            this.PersonPost_Brigade_Name.HeaderText = "ბრიგადის სახელი";
            this.PersonPost_Brigade_Name.Name = "PersonPost_Brigade_Name";
            this.PersonPost_Brigade_Name.ReadOnly = true;
            this.PersonPost_Brigade_Name.Width = 200;
            // 
            // PersonPost_BalanceSheetType_Name
            // 
            this.PersonPost_BalanceSheetType_Name.DataPropertyName = "PersonPost_BalanceSheetType_Name";
            this.PersonPost_BalanceSheetType_Name.HeaderText = "ბალანსის ტიპი";
            this.PersonPost_BalanceSheetType_Name.Name = "PersonPost_BalanceSheetType_Name";
            this.PersonPost_BalanceSheetType_Name.ReadOnly = true;
            this.PersonPost_BalanceSheetType_Name.Width = 150;
            // 
            // PersonPost_EmployeeType_Name
            // 
            this.PersonPost_EmployeeType_Name.DataPropertyName = "PersonPost_EmployeeType_Name";
            this.PersonPost_EmployeeType_Name.HeaderText = "ტიპი";
            this.PersonPost_EmployeeType_Name.Name = "PersonPost_EmployeeType_Name";
            this.PersonPost_EmployeeType_Name.ReadOnly = true;
            this.PersonPost_EmployeeType_Name.Width = 150;
            // 
            // PersonPost_StartDate
            // 
            this.PersonPost_StartDate.DataPropertyName = "PersonPost_StartDate";
            this.PersonPost_StartDate.HeaderText = "პოსტის დაწყების თარიღი";
            this.PersonPost_StartDate.Name = "PersonPost_StartDate";
            this.PersonPost_StartDate.ReadOnly = true;
            this.PersonPost_StartDate.Width = 150;
            // 
            // PersonPost_EndDate
            // 
            this.PersonPost_EndDate.DataPropertyName = "PersonPost_EndDate";
            this.PersonPost_EndDate.HeaderText = "პოსტის დასრულების თარიღი";
            this.PersonPost_EndDate.Name = "PersonPost_EndDate";
            this.PersonPost_EndDate.ReadOnly = true;
            this.PersonPost_EndDate.Width = 150;
            // 
            // BrigadesDataGridView
            // 
            this.BrigadesDataGridView.AllowUserToAddRows = false;
            this.BrigadesDataGridView.AllowUserToDeleteRows = false;
            this.BrigadesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BrigadesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Brigade_Id,
            this.Brigade_Name,
            this.Brigade_Description});
            this.BrigadesDataGridView.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrigadesDataGridView.Location = new System.Drawing.Point(3, 21);
            this.BrigadesDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadesDataGridView.Name = "BrigadesDataGridView";
            this.BrigadesDataGridView.ReadOnly = true;
            this.BrigadesDataGridView.RowTemplate.Height = 24;
            this.BrigadesDataGridView.Size = new System.Drawing.Size(1083, 350);
            this.BrigadesDataGridView.TabIndex = 0;
            this.BrigadesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrigadesDataGridView_CellClick);
            this.BrigadesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrigadesDataGridView_CellDoubleClick);
            this.BrigadesDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.BrigadesDataGridView_RowEnter);
            this.BrigadesDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.BrigadesDataGridView_RowsAdded);
            this.BrigadesDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.BrigadesDataGridView_RowsRemoved);
            // 
            // Brigade_Id
            // 
            this.Brigade_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brigade_Id.DataPropertyName = "Brigade_Id";
            this.Brigade_Id.HeaderText = "ბრიგადის ID";
            this.Brigade_Id.Name = "Brigade_Id";
            this.Brigade_Id.ReadOnly = true;
            this.Brigade_Id.Visible = false;
            // 
            // Brigade_Name
            // 
            this.Brigade_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brigade_Name.DataPropertyName = "Brigade_Name";
            this.Brigade_Name.HeaderText = "სახელი";
            this.Brigade_Name.Name = "Brigade_Name";
            this.Brigade_Name.ReadOnly = true;
            // 
            // Brigade_Description
            // 
            this.Brigade_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Brigade_Description.DataPropertyName = "Brigade_Description";
            this.Brigade_Description.HeaderText = "აღწერა";
            this.Brigade_Description.Name = "Brigade_Description";
            this.Brigade_Description.ReadOnly = true;
            // 
            // BrigadegroupBox1
            // 
            this.BrigadegroupBox1.Controls.Add(this.BagesPrintButton);
            this.BrigadegroupBox1.Controls.Add(this.BrigadeDeleteButton);
            this.BrigadegroupBox1.Controls.Add(this.BrigadUpdateButton);
            this.BrigadegroupBox1.Controls.Add(this.BrigadeAddButton);
            this.BrigadegroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.BrigadegroupBox1.Location = new System.Drawing.Point(1093, 4);
            this.BrigadegroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadegroupBox1.Name = "BrigadegroupBox1";
            this.BrigadegroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadegroupBox1.Size = new System.Drawing.Size(163, 665);
            this.BrigadegroupBox1.TabIndex = 4;
            this.BrigadegroupBox1.TabStop = false;
            this.BrigadegroupBox1.Text = "მოქმედებები";
            // 
            // BagesPrintButton
            // 
            this.BagesPrintButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BagesPrintButton.Location = new System.Drawing.Point(3, 138);
            this.BagesPrintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BagesPrintButton.Name = "BagesPrintButton";
            this.BagesPrintButton.Size = new System.Drawing.Size(157, 69);
            this.BagesPrintButton.TabIndex = 6;
            this.BagesPrintButton.Text = "ბეიჯების ბეჭდვა";
            this.BagesPrintButton.UseVisualStyleBackColor = true;
            this.BagesPrintButton.Click += new System.EventHandler(this.BagesPrintButton_Click);
            // 
            // BrigadeDeleteButton
            // 
            this.BrigadeDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrigadeDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.BrigadeDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadeDeleteButton.Name = "BrigadeDeleteButton";
            this.BrigadeDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.BrigadeDeleteButton.TabIndex = 5;
            this.BrigadeDeleteButton.Text = "წაშლა";
            this.BrigadeDeleteButton.UseVisualStyleBackColor = true;
            this.BrigadeDeleteButton.Click += new System.EventHandler(this.BrigadeDeleteButton_Click);
            // 
            // BrigadUpdateButton
            // 
            this.BrigadUpdateButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrigadUpdateButton.Location = new System.Drawing.Point(3, 60);
            this.BrigadUpdateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadUpdateButton.Name = "BrigadUpdateButton";
            this.BrigadUpdateButton.Size = new System.Drawing.Size(157, 39);
            this.BrigadUpdateButton.TabIndex = 4;
            this.BrigadUpdateButton.Text = "განახლება";
            this.BrigadUpdateButton.UseVisualStyleBackColor = true;
            this.BrigadUpdateButton.Click += new System.EventHandler(this.BrigadUpdateButton_Click);
            // 
            // BrigadeAddButton
            // 
            this.BrigadeAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.BrigadeAddButton.Location = new System.Drawing.Point(3, 21);
            this.BrigadeAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BrigadeAddButton.Name = "BrigadeAddButton";
            this.BrigadeAddButton.Size = new System.Drawing.Size(157, 39);
            this.BrigadeAddButton.TabIndex = 1;
            this.BrigadeAddButton.Text = "დამატება";
            this.BrigadeAddButton.UseVisualStyleBackColor = true;
            this.BrigadeAddButton.Click += new System.EventHandler(this.BrigadeAddButton_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(1260, 673);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // StructureTabControl
            // 
            this.StructureTabControl.Controls.Add(this.tabPage1);
            this.StructureTabControl.Controls.Add(this.BrigadesTabPage);
            this.StructureTabControl.Controls.Add(this.CarDriversTabPage);
            this.StructureTabControl.Controls.Add(this.CarsTabPage);
            this.StructureTabControl.Controls.Add(this.CompanyCarsTabPage);
            this.StructureTabControl.Controls.Add(this.PostsTabPage);
            this.StructureTabControl.Controls.Add(this.PointsTabPage);
            this.StructureTabControl.Controls.Add(this.InsideCompanyTabPage);
            this.StructureTabControl.Controls.Add(this.CompanyesTabPage);
            this.StructureTabControl.Controls.Add(this.RowsTabPage);
            this.StructureTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StructureTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StructureTabControl.Location = new System.Drawing.Point(0, 0);
            this.StructureTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.StructureTabControl.Multiline = true;
            this.StructureTabControl.Name = "StructureTabControl";
            this.StructureTabControl.SelectedIndex = 0;
            this.StructureTabControl.Size = new System.Drawing.Size(1268, 706);
            this.StructureTabControl.TabIndex = 0;
            // 
            // CompanyCarsTabPage
            // 
            this.CompanyCarsTabPage.Controls.Add(this.CompanyCarsGroupBox);
            this.CompanyCarsTabPage.Controls.Add(this.CompanyCargroupBox1);
            this.CompanyCarsTabPage.Location = new System.Drawing.Point(4, 29);
            this.CompanyCarsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarsTabPage.Name = "CompanyCarsTabPage";
            this.CompanyCarsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarsTabPage.Size = new System.Drawing.Size(1260, 673);
            this.CompanyCarsTabPage.TabIndex = 4;
            this.CompanyCarsTabPage.Text = "კომპანიის მანქანები";
            this.CompanyCarsTabPage.UseVisualStyleBackColor = true;
            this.CompanyCarsTabPage.Enter += new System.EventHandler(this.CompanyCarsTabPage_Enter);
            // 
            // CompanyCarsGroupBox
            // 
            this.CompanyCarsGroupBox.Controls.Add(this.CompanyCarsDataGridView);
            this.CompanyCarsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyCarsGroupBox.Location = new System.Drawing.Point(3, 2);
            this.CompanyCarsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarsGroupBox.Name = "CompanyCarsGroupBox";
            this.CompanyCarsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarsGroupBox.Size = new System.Drawing.Size(1091, 669);
            this.CompanyCarsGroupBox.TabIndex = 14;
            this.CompanyCarsGroupBox.TabStop = false;
            this.CompanyCarsGroupBox.Text = "კომპანიის მანქანები";
            // 
            // CompanyCarsDataGridView
            // 
            this.CompanyCarsDataGridView.AllowUserToAddRows = false;
            this.CompanyCarsDataGridView.AllowUserToDeleteRows = false;
            this.CompanyCarsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyCarsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.CompanyCar_Company_Id,
            this.CompanyCar_Company_Name,
            this.CompanyCar_Car_Id,
            this.CompanyCar_Car_Number,
            this.CompanyCar_Car_Model,
            this.CompanyCar_StartDate,
            this.CompanyCar_EndDate});
            this.CompanyCarsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyCarsDataGridView.Location = new System.Drawing.Point(3, 21);
            this.CompanyCarsDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarsDataGridView.Name = "CompanyCarsDataGridView";
            this.CompanyCarsDataGridView.ReadOnly = true;
            this.CompanyCarsDataGridView.RowTemplate.Height = 24;
            this.CompanyCarsDataGridView.Size = new System.Drawing.Size(1085, 646);
            this.CompanyCarsDataGridView.TabIndex = 0;
            this.CompanyCarsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.CompanyCarsDataGridView_CellDoubleClick);
            this.CompanyCarsDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CompanyCarsDataGridView_RowsAdded);
            this.CompanyCarsDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.CompanyCarsDataGridView_RowsRemoved);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CompanyCar_Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "კომპანიის მანქანის ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // CompanyCar_Company_Id
            // 
            this.CompanyCar_Company_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_Company_Id.DataPropertyName = "CompanyCar_Company_Id";
            this.CompanyCar_Company_Id.HeaderText = "კომპანიის ID";
            this.CompanyCar_Company_Id.Name = "CompanyCar_Company_Id";
            this.CompanyCar_Company_Id.ReadOnly = true;
            this.CompanyCar_Company_Id.Visible = false;
            // 
            // CompanyCar_Company_Name
            // 
            this.CompanyCar_Company_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_Company_Name.DataPropertyName = "CompanyCar_Company_Name";
            this.CompanyCar_Company_Name.HeaderText = "კომპანია";
            this.CompanyCar_Company_Name.Name = "CompanyCar_Company_Name";
            this.CompanyCar_Company_Name.ReadOnly = true;
            // 
            // CompanyCar_Car_Id
            // 
            this.CompanyCar_Car_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_Car_Id.DataPropertyName = "CompanyCar_Car_Id";
            this.CompanyCar_Car_Id.HeaderText = "მანქანის ID";
            this.CompanyCar_Car_Id.Name = "CompanyCar_Car_Id";
            this.CompanyCar_Car_Id.ReadOnly = true;
            this.CompanyCar_Car_Id.Visible = false;
            // 
            // CompanyCar_Car_Number
            // 
            this.CompanyCar_Car_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_Car_Number.DataPropertyName = "CompanyCar_Car_Number";
            this.CompanyCar_Car_Number.HeaderText = "მანქანის ნომერი";
            this.CompanyCar_Car_Number.Name = "CompanyCar_Car_Number";
            this.CompanyCar_Car_Number.ReadOnly = true;
            // 
            // CompanyCar_Car_Model
            // 
            this.CompanyCar_Car_Model.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_Car_Model.DataPropertyName = "CompanyCar_Car_Model";
            this.CompanyCar_Car_Model.HeaderText = "მანქანის მოდელი";
            this.CompanyCar_Car_Model.Name = "CompanyCar_Car_Model";
            this.CompanyCar_Car_Model.ReadOnly = true;
            // 
            // CompanyCar_StartDate
            // 
            this.CompanyCar_StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_StartDate.DataPropertyName = "CompanyCar_StartDate";
            this.CompanyCar_StartDate.HeaderText = "დაწყების თარიღი";
            this.CompanyCar_StartDate.Name = "CompanyCar_StartDate";
            this.CompanyCar_StartDate.ReadOnly = true;
            // 
            // CompanyCar_EndDate
            // 
            this.CompanyCar_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyCar_EndDate.DataPropertyName = "CompanyCar_EndDate";
            this.CompanyCar_EndDate.HeaderText = "დასრულების თარიღი";
            this.CompanyCar_EndDate.Name = "CompanyCar_EndDate";
            this.CompanyCar_EndDate.ReadOnly = true;
            // 
            // CompanyCargroupBox1
            // 
            this.CompanyCargroupBox1.Controls.Add(this.CompanyCarDeleteButton);
            this.CompanyCargroupBox1.Controls.Add(this.CompanyCarEditButton);
            this.CompanyCargroupBox1.Controls.Add(this.CompanyCarAddButton);
            this.CompanyCargroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.CompanyCargroupBox1.Location = new System.Drawing.Point(1094, 2);
            this.CompanyCargroupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCargroupBox1.Name = "CompanyCargroupBox1";
            this.CompanyCargroupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCargroupBox1.Size = new System.Drawing.Size(163, 669);
            this.CompanyCargroupBox1.TabIndex = 13;
            this.CompanyCargroupBox1.TabStop = false;
            this.CompanyCargroupBox1.Text = "მოქმედებები";
            // 
            // CompanyCarDeleteButton
            // 
            this.CompanyCarDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyCarDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.CompanyCarDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarDeleteButton.Name = "CompanyCarDeleteButton";
            this.CompanyCarDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.CompanyCarDeleteButton.TabIndex = 14;
            this.CompanyCarDeleteButton.Text = "წაშლა";
            this.CompanyCarDeleteButton.UseVisualStyleBackColor = true;
            this.CompanyCarDeleteButton.Click += new System.EventHandler(this.CompanyCarDeleteButton_Click);
            // 
            // CompanyCarEditButton
            // 
            this.CompanyCarEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyCarEditButton.Location = new System.Drawing.Point(3, 60);
            this.CompanyCarEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarEditButton.Name = "CompanyCarEditButton";
            this.CompanyCarEditButton.Size = new System.Drawing.Size(157, 39);
            this.CompanyCarEditButton.TabIndex = 13;
            this.CompanyCarEditButton.Text = "განახლება";
            this.CompanyCarEditButton.UseVisualStyleBackColor = true;
            this.CompanyCarEditButton.Click += new System.EventHandler(this.CompanyCarEditButton_Click);
            // 
            // CompanyCarAddButton
            // 
            this.CompanyCarAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyCarAddButton.Location = new System.Drawing.Point(3, 21);
            this.CompanyCarAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyCarAddButton.Name = "CompanyCarAddButton";
            this.CompanyCarAddButton.Size = new System.Drawing.Size(157, 39);
            this.CompanyCarAddButton.TabIndex = 10;
            this.CompanyCarAddButton.Text = "დამატება";
            this.CompanyCarAddButton.UseVisualStyleBackColor = true;
            this.CompanyCarAddButton.Click += new System.EventHandler(this.CompanyCarAddButton_Click);
            // 
            // PostsTabPage
            // 
            this.PostsTabPage.Controls.Add(this.PostGroupBox);
            this.PostsTabPage.Controls.Add(this.groupBox3);
            this.PostsTabPage.Location = new System.Drawing.Point(4, 29);
            this.PostsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostsTabPage.Name = "PostsTabPage";
            this.PostsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostsTabPage.Size = new System.Drawing.Size(1260, 673);
            this.PostsTabPage.TabIndex = 5;
            this.PostsTabPage.Text = "თანამდებობები";
            this.PostsTabPage.UseVisualStyleBackColor = true;
            this.PostsTabPage.Enter += new System.EventHandler(this.PostsTabPage_Enter);
            // 
            // PostGroupBox
            // 
            this.PostGroupBox.Controls.Add(this.PostDataGridView);
            this.PostGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostGroupBox.Location = new System.Drawing.Point(3, 2);
            this.PostGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostGroupBox.Name = "PostGroupBox";
            this.PostGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostGroupBox.Size = new System.Drawing.Size(1091, 669);
            this.PostGroupBox.TabIndex = 19;
            this.PostGroupBox.TabStop = false;
            this.PostGroupBox.Text = "თანამდებობები";
            // 
            // PostDataGridView
            // 
            this.PostDataGridView.AllowUserToAddRows = false;
            this.PostDataGridView.AllowUserToDeleteRows = false;
            this.PostDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PostDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Post_Id,
            this.Post_Name,
            this.Post_Description,
            this.Post_BarCodePrefix,
            this.Post_BalanceSheetType_Id,
            this.Post_BalanceSheetType_Name});
            this.PostDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostDataGridView.Location = new System.Drawing.Point(3, 21);
            this.PostDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostDataGridView.Name = "PostDataGridView";
            this.PostDataGridView.ReadOnly = true;
            this.PostDataGridView.RowTemplate.Height = 24;
            this.PostDataGridView.Size = new System.Drawing.Size(1085, 646);
            this.PostDataGridView.TabIndex = 0;
            this.PostDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PostDataGridView_CellDoubleClick);
            // 
            // Post_Id
            // 
            this.Post_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Post_Id.DataPropertyName = "Post_Id";
            this.Post_Id.HeaderText = "თანამდებობის ID";
            this.Post_Id.Name = "Post_Id";
            this.Post_Id.ReadOnly = true;
            this.Post_Id.Visible = false;
            // 
            // Post_Name
            // 
            this.Post_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Post_Name.DataPropertyName = "Post_Name";
            this.Post_Name.HeaderText = "თანამდებობა";
            this.Post_Name.Name = "Post_Name";
            this.Post_Name.ReadOnly = true;
            // 
            // Post_Description
            // 
            this.Post_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Post_Description.DataPropertyName = "Post_Description";
            this.Post_Description.HeaderText = "აღწერა";
            this.Post_Description.Name = "Post_Description";
            this.Post_Description.ReadOnly = true;
            // 
            // Post_BarCodePrefix
            // 
            this.Post_BarCodePrefix.DataPropertyName = "Post_BarCodePrefix";
            this.Post_BarCodePrefix.HeaderText = "შტრიხკოდი პრეფიქსი";
            this.Post_BarCodePrefix.Name = "Post_BarCodePrefix";
            this.Post_BarCodePrefix.ReadOnly = true;
            // 
            // Post_BalanceSheetType_Id
            // 
            this.Post_BalanceSheetType_Id.DataPropertyName = "Post_BalanceSheetType_Id";
            this.Post_BalanceSheetType_Id.HeaderText = "Post_BalanceSheetType_Id";
            this.Post_BalanceSheetType_Id.Name = "Post_BalanceSheetType_Id";
            this.Post_BalanceSheetType_Id.ReadOnly = true;
            this.Post_BalanceSheetType_Id.Visible = false;
            // 
            // Post_BalanceSheetType_Name
            // 
            this.Post_BalanceSheetType_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Post_BalanceSheetType_Name.DataPropertyName = "BalanceSheetType_Name";
            this.Post_BalanceSheetType_Name.HeaderText = "Post_BalanceSheetType_Name";
            this.Post_BalanceSheetType_Name.Name = "Post_BalanceSheetType_Name";
            this.Post_BalanceSheetType_Name.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PostDeleteButton);
            this.groupBox3.Controls.Add(this.PostEditButton);
            this.groupBox3.Controls.Add(this.PostAddButton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(1094, 2);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(163, 669);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "მოქმედებები";
            // 
            // PostDeleteButton
            // 
            this.PostDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PostDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.PostDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostDeleteButton.Name = "PostDeleteButton";
            this.PostDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.PostDeleteButton.TabIndex = 5;
            this.PostDeleteButton.Text = "წაშლა";
            this.PostDeleteButton.UseVisualStyleBackColor = true;
            this.PostDeleteButton.Click += new System.EventHandler(this.PostDeleteButton_Click);
            // 
            // PostEditButton
            // 
            this.PostEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PostEditButton.Location = new System.Drawing.Point(3, 60);
            this.PostEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostEditButton.Name = "PostEditButton";
            this.PostEditButton.Size = new System.Drawing.Size(157, 39);
            this.PostEditButton.TabIndex = 4;
            this.PostEditButton.Text = "განახლება";
            this.PostEditButton.UseVisualStyleBackColor = true;
            this.PostEditButton.Click += new System.EventHandler(this.PostEditButton_Click);
            // 
            // PostAddButton
            // 
            this.PostAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PostAddButton.Location = new System.Drawing.Point(3, 21);
            this.PostAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PostAddButton.Name = "PostAddButton";
            this.PostAddButton.Size = new System.Drawing.Size(157, 39);
            this.PostAddButton.TabIndex = 1;
            this.PostAddButton.Text = "დამატება";
            this.PostAddButton.UseVisualStyleBackColor = true;
            this.PostAddButton.Click += new System.EventHandler(this.PostAddButton_Click);
            // 
            // PointsTabPage
            // 
            this.PointsTabPage.Controls.Add(this.PointGroupBox);
            this.PointsTabPage.Controls.Add(this.groupBox4);
            this.PointsTabPage.Location = new System.Drawing.Point(4, 29);
            this.PointsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointsTabPage.Name = "PointsTabPage";
            this.PointsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointsTabPage.Size = new System.Drawing.Size(1260, 673);
            this.PointsTabPage.TabIndex = 6;
            this.PointsTabPage.Text = "ადგილები";
            this.PointsTabPage.UseVisualStyleBackColor = true;
            this.PointsTabPage.Enter += new System.EventHandler(this.PointsTabPage_Enter);
            // 
            // PointGroupBox
            // 
            this.PointGroupBox.Controls.Add(this.PointDataGridView);
            this.PointGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PointGroupBox.Location = new System.Drawing.Point(3, 2);
            this.PointGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointGroupBox.Name = "PointGroupBox";
            this.PointGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointGroupBox.Size = new System.Drawing.Size(1091, 669);
            this.PointGroupBox.TabIndex = 20;
            this.PointGroupBox.TabStop = false;
            this.PointGroupBox.Text = "კომპანიის მანქანები";
            // 
            // PointDataGridView
            // 
            this.PointDataGridView.AllowUserToAddRows = false;
            this.PointDataGridView.AllowUserToDeleteRows = false;
            this.PointDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PointDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Point_Id,
            this.Point_Name,
            this.Point_IsActive,
            this.Point_PointType_Id,
            this.Point_PointType_Name,
            this.Point_PointType_IsActive,
            this.Point_BarCode,
            this.Point_Car_Id,
            this.Point_Car_Number,
            this.Point_Car_Model,
            this.Point_Address,
            this.Point_Description});
            this.PointDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PointDataGridView.Location = new System.Drawing.Point(3, 21);
            this.PointDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointDataGridView.Name = "PointDataGridView";
            this.PointDataGridView.ReadOnly = true;
            this.PointDataGridView.RowTemplate.Height = 24;
            this.PointDataGridView.Size = new System.Drawing.Size(1085, 646);
            this.PointDataGridView.TabIndex = 0;
            this.PointDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PointDataGridView_CellContentDoubleClick);
            this.PointDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PointDataGridView_RowEnter);
            // 
            // Point_Id
            // 
            this.Point_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Point_Id.DataPropertyName = "Point_Id";
            this.Point_Id.HeaderText = "ადგილის ID";
            this.Point_Id.Name = "Point_Id";
            this.Point_Id.ReadOnly = true;
            this.Point_Id.Visible = false;
            // 
            // Point_Name
            // 
            this.Point_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Point_Name.DataPropertyName = "Point_Name";
            this.Point_Name.HeaderText = "ადგილი";
            this.Point_Name.Name = "Point_Name";
            this.Point_Name.ReadOnly = true;
            // 
            // Point_IsActive
            // 
            this.Point_IsActive.DataPropertyName = "Point_IsActive";
            this.Point_IsActive.HeaderText = "აქტივობა";
            this.Point_IsActive.Name = "Point_IsActive";
            this.Point_IsActive.ReadOnly = true;
            this.Point_IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Point_IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Point_PointType_Id
            // 
            this.Point_PointType_Id.DataPropertyName = "Point_PointType_Id";
            this.Point_PointType_Id.HeaderText = "ადგილის ტიპის ID";
            this.Point_PointType_Id.Name = "Point_PointType_Id";
            this.Point_PointType_Id.ReadOnly = true;
            this.Point_PointType_Id.Visible = false;
            // 
            // Point_PointType_Name
            // 
            this.Point_PointType_Name.DataPropertyName = "Point_PointType_Name";
            this.Point_PointType_Name.HeaderText = "ადგილისი ტიპი";
            this.Point_PointType_Name.Name = "Point_PointType_Name";
            this.Point_PointType_Name.ReadOnly = true;
            this.Point_PointType_Name.Width = 150;
            // 
            // Point_PointType_IsActive
            // 
            this.Point_PointType_IsActive.DataPropertyName = "Point_PointType_IsActive";
            this.Point_PointType_IsActive.HeaderText = "ადგილის ტიპის აქტივობა";
            this.Point_PointType_IsActive.Name = "Point_PointType_IsActive";
            this.Point_PointType_IsActive.ReadOnly = true;
            this.Point_PointType_IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Point_PointType_IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Point_BarCode
            // 
            this.Point_BarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Point_BarCode.DataPropertyName = "Point_BarCode";
            this.Point_BarCode.HeaderText = "შტრიხკოდი";
            this.Point_BarCode.Name = "Point_BarCode";
            this.Point_BarCode.ReadOnly = true;
            // 
            // Point_Car_Id
            // 
            this.Point_Car_Id.DataPropertyName = "Point_Car_Id";
            this.Point_Car_Id.HeaderText = "მანქანის ID";
            this.Point_Car_Id.Name = "Point_Car_Id";
            this.Point_Car_Id.ReadOnly = true;
            this.Point_Car_Id.Visible = false;
            // 
            // Point_Car_Number
            // 
            this.Point_Car_Number.DataPropertyName = "Point_Car_Number";
            this.Point_Car_Number.HeaderText = "მანქანის ნომერი";
            this.Point_Car_Number.Name = "Point_Car_Number";
            this.Point_Car_Number.ReadOnly = true;
            this.Point_Car_Number.Width = 150;
            // 
            // Point_Car_Model
            // 
            this.Point_Car_Model.DataPropertyName = "Point_Car_Model";
            this.Point_Car_Model.HeaderText = "მანქანის მოდელი";
            this.Point_Car_Model.Name = "Point_Car_Model";
            this.Point_Car_Model.ReadOnly = true;
            this.Point_Car_Model.Width = 150;
            // 
            // Point_Address
            // 
            this.Point_Address.DataPropertyName = "Point_Address";
            this.Point_Address.HeaderText = "მისამართი";
            this.Point_Address.Name = "Point_Address";
            this.Point_Address.ReadOnly = true;
            this.Point_Address.Width = 150;
            // 
            // Point_Description
            // 
            this.Point_Description.DataPropertyName = "Point_Description";
            this.Point_Description.HeaderText = "აღწერა";
            this.Point_Description.Name = "Point_Description";
            this.Point_Description.ReadOnly = true;
            this.Point_Description.Width = 150;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.PointPrintButton);
            this.groupBox4.Controls.Add(this.PointDeleteButton);
            this.groupBox4.Controls.Add(this.PointEditButton);
            this.groupBox4.Controls.Add(this.PointAddButton);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(1094, 2);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(163, 669);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "მოქმედებები";
            // 
            // PointPrintButton
            // 
            this.PointPrintButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PointPrintButton.Location = new System.Drawing.Point(3, 138);
            this.PointPrintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointPrintButton.Name = "PointPrintButton";
            this.PointPrintButton.Size = new System.Drawing.Size(157, 42);
            this.PointPrintButton.TabIndex = 13;
            this.PointPrintButton.Text = "ბეჭდვა";
            this.PointPrintButton.UseVisualStyleBackColor = true;
            this.PointPrintButton.Click += new System.EventHandler(this.PointPrintButton_Click);
            // 
            // PointDeleteButton
            // 
            this.PointDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PointDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.PointDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointDeleteButton.Name = "PointDeleteButton";
            this.PointDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.PointDeleteButton.TabIndex = 5;
            this.PointDeleteButton.Text = "წაშლა";
            this.PointDeleteButton.UseVisualStyleBackColor = true;
            this.PointDeleteButton.Click += new System.EventHandler(this.PointDeleteButton_Click);
            // 
            // PointEditButton
            // 
            this.PointEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PointEditButton.Location = new System.Drawing.Point(3, 60);
            this.PointEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointEditButton.Name = "PointEditButton";
            this.PointEditButton.Size = new System.Drawing.Size(157, 39);
            this.PointEditButton.TabIndex = 4;
            this.PointEditButton.Text = "განახლება";
            this.PointEditButton.UseVisualStyleBackColor = true;
            this.PointEditButton.Click += new System.EventHandler(this.PointEditButton_Click);
            // 
            // PointAddButton
            // 
            this.PointAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PointAddButton.Location = new System.Drawing.Point(3, 21);
            this.PointAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PointAddButton.Name = "PointAddButton";
            this.PointAddButton.Size = new System.Drawing.Size(157, 39);
            this.PointAddButton.TabIndex = 1;
            this.PointAddButton.Text = "დამატება";
            this.PointAddButton.UseVisualStyleBackColor = true;
            this.PointAddButton.Click += new System.EventHandler(this.PointAddButton_Click);
            // 
            // InsideCompanyTabPage
            // 
            this.InsideCompanyTabPage.Controls.Add(this.groupBox8);
            this.InsideCompanyTabPage.Controls.Add(this.groupBox2);
            this.InsideCompanyTabPage.Controls.Add(this.CompanyRowsGroupBox);
            this.InsideCompanyTabPage.Location = new System.Drawing.Point(4, 29);
            this.InsideCompanyTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyTabPage.Name = "InsideCompanyTabPage";
            this.InsideCompanyTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyTabPage.Size = new System.Drawing.Size(1260, 673);
            this.InsideCompanyTabPage.TabIndex = 7;
            this.InsideCompanyTabPage.Text = "შიდა კომპანიები";
            this.InsideCompanyTabPage.UseVisualStyleBackColor = true;
            this.InsideCompanyTabPage.Enter += new System.EventHandler(this.InsideCompanyTabPage_Enter);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.InsideCompanyBreedDataGridView);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(722, 395);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(535, 276);
            this.groupBox8.TabIndex = 21;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "ჯიშები";
            // 
            // InsideCompanyBreedDataGridView
            // 
            this.InsideCompanyBreedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InsideCompanyBreedDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowBreed_Breed_Name,
            this.RowBreed_TreeCount,
            this.RowBreed_PlantYear,
            this.RowBreed_StartDate,
            this.RowBreed_EndDate});
            this.InsideCompanyBreedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InsideCompanyBreedDataGridView.Location = new System.Drawing.Point(3, 21);
            this.InsideCompanyBreedDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyBreedDataGridView.Name = "InsideCompanyBreedDataGridView";
            this.InsideCompanyBreedDataGridView.RowTemplate.Height = 24;
            this.InsideCompanyBreedDataGridView.Size = new System.Drawing.Size(529, 253);
            this.InsideCompanyBreedDataGridView.TabIndex = 0;
            // 
            // RowBreed_Breed_Name
            // 
            this.RowBreed_Breed_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowBreed_Breed_Name.DataPropertyName = "RowBreed_Breed_Name";
            this.RowBreed_Breed_Name.HeaderText = "ჯიში";
            this.RowBreed_Breed_Name.Name = "RowBreed_Breed_Name";
            // 
            // RowBreed_TreeCount
            // 
            this.RowBreed_TreeCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowBreed_TreeCount.DataPropertyName = "RowBreed_TreeCount";
            this.RowBreed_TreeCount.HeaderText = "ნერგების რაოდენობა";
            this.RowBreed_TreeCount.Name = "RowBreed_TreeCount";
            // 
            // RowBreed_PlantYear
            // 
            this.RowBreed_PlantYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowBreed_PlantYear.DataPropertyName = "RowBreed_PlantYear";
            this.RowBreed_PlantYear.HeaderText = "დარგვის წელი";
            this.RowBreed_PlantYear.Name = "RowBreed_PlantYear";
            // 
            // RowBreed_StartDate
            // 
            this.RowBreed_StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowBreed_StartDate.DataPropertyName = "RowBreed_StartDate";
            this.RowBreed_StartDate.HeaderText = "დაწყების თარიღი";
            this.RowBreed_StartDate.Name = "RowBreed_StartDate";
            // 
            // RowBreed_EndDate
            // 
            this.RowBreed_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.RowBreed_EndDate.DataPropertyName = "RowBreed_EndDate";
            this.RowBreed_EndDate.HeaderText = "დასრულების თარიღი";
            this.RowBreed_EndDate.Name = "RowBreed_EndDate";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.InsideCompanyRowdataGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(3, 395);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(719, 276);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "რიგები";
            // 
            // InsideCompanyRowdataGridView
            // 
            this.InsideCompanyRowdataGridView.AllowUserToAddRows = false;
            this.InsideCompanyRowdataGridView.AllowUserToDeleteRows = false;
            this.InsideCompanyRowdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InsideCompanyRowdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyRow_Id});
            this.InsideCompanyRowdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InsideCompanyRowdataGridView.Location = new System.Drawing.Point(3, 21);
            this.InsideCompanyRowdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyRowdataGridView.Name = "InsideCompanyRowdataGridView";
            this.InsideCompanyRowdataGridView.ReadOnly = true;
            this.InsideCompanyRowdataGridView.RowTemplate.Height = 24;
            this.InsideCompanyRowdataGridView.Size = new System.Drawing.Size(713, 253);
            this.InsideCompanyRowdataGridView.TabIndex = 0;
            this.InsideCompanyRowdataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.InsideCompanyRowdataGridView_RowEnter);
            // 
            // CompanyRow_Id
            // 
            this.CompanyRow_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_Id.DataPropertyName = "CompanyRow_Row_Barkode";
            this.CompanyRow_Id.HeaderText = "ბარკოდი";
            this.CompanyRow_Id.Name = "CompanyRow_Id";
            this.CompanyRow_Id.ReadOnly = true;
            // 
            // CompanyRowsGroupBox
            // 
            this.CompanyRowsGroupBox.Controls.Add(this.groupBox9);
            this.CompanyRowsGroupBox.Controls.Add(this.groupBox7);
            this.CompanyRowsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyRowsGroupBox.Location = new System.Drawing.Point(3, 2);
            this.CompanyRowsGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyRowsGroupBox.Name = "CompanyRowsGroupBox";
            this.CompanyRowsGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyRowsGroupBox.Size = new System.Drawing.Size(1254, 393);
            this.CompanyRowsGroupBox.TabIndex = 4;
            this.CompanyRowsGroupBox.TabStop = false;
            this.CompanyRowsGroupBox.Text = "შიდა კომპანიები";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.InsideCompanyDataGridView);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox9.Location = new System.Drawing.Point(3, 21);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox9.Size = new System.Drawing.Size(1085, 370);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            // 
            // InsideCompanyDataGridView
            // 
            this.InsideCompanyDataGridView.AllowUserToAddRows = false;
            this.InsideCompanyDataGridView.AllowUserToDeleteRows = false;
            this.InsideCompanyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InsideCompanyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.Company_IBAN,
            this.Company_RS_UserId,
            this.Company_RS_Password});
            this.InsideCompanyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InsideCompanyDataGridView.Location = new System.Drawing.Point(4, 23);
            this.InsideCompanyDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyDataGridView.Name = "InsideCompanyDataGridView";
            this.InsideCompanyDataGridView.ReadOnly = true;
            this.InsideCompanyDataGridView.RowTemplate.Height = 24;
            this.InsideCompanyDataGridView.Size = new System.Drawing.Size(1077, 343);
            this.InsideCompanyDataGridView.TabIndex = 17;
            this.InsideCompanyDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.InsideCompanyDataGridView_RowEnter);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Company_Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "კომპანიის ID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Company_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "სახელი";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Company_Identity";
            this.dataGridViewTextBoxColumn4.HeaderText = "კომპანიის კოდი";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 120;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Company_SideType_Id";
            this.dataGridViewTextBoxColumn5.HeaderText = "Company_SideType_Id";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Company_SideType_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "შიდა/გარე";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Company_CitizenshipId";
            this.dataGridViewTextBoxColumn7.HeaderText = "Company_CitizenshipId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Company_Citizenship_Name";
            this.dataGridViewTextBoxColumn8.HeaderText = "ქვეყანა";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 130;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Company_Citizenship_NameEn";
            this.dataGridViewTextBoxColumn9.HeaderText = "ქვეყანა (ინგ)";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 120;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Company_Address1";
            this.dataGridViewTextBoxColumn10.HeaderText = "მისამართი 1";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Company_Address2";
            this.dataGridViewTextBoxColumn11.HeaderText = "მისამართი 2";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Company_Phone1";
            this.dataGridViewTextBoxColumn12.HeaderText = "ტელეფონი 1";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Company_Phone2";
            this.dataGridViewTextBoxColumn13.HeaderText = "ტელეფონი 2";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // Company_IBAN
            // 
            this.Company_IBAN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_IBAN.DataPropertyName = "Company_IBAN";
            this.Company_IBAN.HeaderText = "ბანკის ნომერი";
            this.Company_IBAN.Name = "Company_IBAN";
            this.Company_IBAN.ReadOnly = true;
            // 
            // Company_RS_UserId
            // 
            this.Company_RS_UserId.DataPropertyName = "Company_RS_UserId";
            this.Company_RS_UserId.HeaderText = "უსერის იდ";
            this.Company_RS_UserId.Name = "Company_RS_UserId";
            this.Company_RS_UserId.ReadOnly = true;
            // 
            // Company_RS_Password
            // 
            this.Company_RS_Password.DataPropertyName = "Company_RS_Password";
            this.Company_RS_Password.HeaderText = "პაროლი";
            this.Company_RS_Password.Name = "Company_RS_Password";
            this.Company_RS_Password.ReadOnly = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.InsideCompanyDeleteButton);
            this.groupBox7.Controls.Add(this.InsideCompanyEditButton);
            this.groupBox7.Controls.Add(this.InsideCompanyAddButton);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox7.Location = new System.Drawing.Point(1088, 21);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(163, 370);
            this.groupBox7.TabIndex = 18;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "მოქმედებები";
            // 
            // InsideCompanyDeleteButton
            // 
            this.InsideCompanyDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsideCompanyDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.InsideCompanyDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyDeleteButton.Name = "InsideCompanyDeleteButton";
            this.InsideCompanyDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.InsideCompanyDeleteButton.TabIndex = 17;
            this.InsideCompanyDeleteButton.Text = "წაშლა";
            this.InsideCompanyDeleteButton.UseVisualStyleBackColor = true;
            this.InsideCompanyDeleteButton.Visible = false;
            this.InsideCompanyDeleteButton.Click += new System.EventHandler(this.InsideCompanyDeleteButton_Click);
            // 
            // InsideCompanyEditButton
            // 
            this.InsideCompanyEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsideCompanyEditButton.Location = new System.Drawing.Point(3, 60);
            this.InsideCompanyEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyEditButton.Name = "InsideCompanyEditButton";
            this.InsideCompanyEditButton.Size = new System.Drawing.Size(157, 39);
            this.InsideCompanyEditButton.TabIndex = 16;
            this.InsideCompanyEditButton.Text = "განახლება";
            this.InsideCompanyEditButton.UseVisualStyleBackColor = true;
            this.InsideCompanyEditButton.Click += new System.EventHandler(this.InsideCompanyEditButton_Click);
            // 
            // InsideCompanyAddButton
            // 
            this.InsideCompanyAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InsideCompanyAddButton.Location = new System.Drawing.Point(3, 21);
            this.InsideCompanyAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InsideCompanyAddButton.Name = "InsideCompanyAddButton";
            this.InsideCompanyAddButton.Size = new System.Drawing.Size(157, 39);
            this.InsideCompanyAddButton.TabIndex = 13;
            this.InsideCompanyAddButton.Text = "დამატება";
            this.InsideCompanyAddButton.UseVisualStyleBackColor = true;
            this.InsideCompanyAddButton.Click += new System.EventHandler(this.InsideCompanyAddButton_Click);
            // 
            // CompanyesTabPage
            // 
            this.CompanyesTabPage.Controls.Add(this.CompanyGroupBox);
            this.CompanyesTabPage.Controls.Add(this.groupBox5);
            this.CompanyesTabPage.Location = new System.Drawing.Point(4, 29);
            this.CompanyesTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyesTabPage.Name = "CompanyesTabPage";
            this.CompanyesTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyesTabPage.Size = new System.Drawing.Size(1260, 673);
            this.CompanyesTabPage.TabIndex = 8;
            this.CompanyesTabPage.Text = "გარე კომპანიები";
            this.CompanyesTabPage.UseVisualStyleBackColor = true;
            this.CompanyesTabPage.Enter += new System.EventHandler(this.OutsideCompanyesTabPage_Enter);
            // 
            // CompanyGroupBox
            // 
            this.CompanyGroupBox.Controls.Add(this.OutsideCompanyDataGridView);
            this.CompanyGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyGroupBox.Location = new System.Drawing.Point(3, 2);
            this.CompanyGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyGroupBox.Name = "CompanyGroupBox";
            this.CompanyGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyGroupBox.Size = new System.Drawing.Size(1091, 669);
            this.CompanyGroupBox.TabIndex = 18;
            this.CompanyGroupBox.TabStop = false;
            this.CompanyGroupBox.Text = "გარე კომპანიები";
            // 
            // OutsideCompanyDataGridView
            // 
            this.OutsideCompanyDataGridView.AllowUserToAddRows = false;
            this.OutsideCompanyDataGridView.AllowUserToDeleteRows = false;
            this.OutsideCompanyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.OutsideCompanyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Company_Id,
            this.Company_Name,
            this.Company_Identity,
            this.Company_SideType_Id,
            this.Company_SideType_Name,
            this.Company_CitizenshipId,
            this.Company_Citizenship_Name,
            this.Company_Citizenship_NameEn,
            this.Company_Address1,
            this.Company_Address2,
            this.Company_Phone1,
            this.Company_Phone2,
            this.Column1});
            this.OutsideCompanyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutsideCompanyDataGridView.Location = new System.Drawing.Point(3, 21);
            this.OutsideCompanyDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutsideCompanyDataGridView.Name = "OutsideCompanyDataGridView";
            this.OutsideCompanyDataGridView.ReadOnly = true;
            this.OutsideCompanyDataGridView.RowTemplate.Height = 24;
            this.OutsideCompanyDataGridView.Size = new System.Drawing.Size(1085, 646);
            this.OutsideCompanyDataGridView.TabIndex = 0;
            this.OutsideCompanyDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OutsideCompanyDataGridView_CellDoubleClick);
            this.OutsideCompanyDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.OutsideCompanyDataGridView_RowsAdded);
            this.OutsideCompanyDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.OutsideCompanyDataGridView_RowsRemoved);
            // 
            // Company_Id
            // 
            this.Company_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_Id.DataPropertyName = "Company_Id";
            this.Company_Id.HeaderText = "კომპანიის ID";
            this.Company_Id.Name = "Company_Id";
            this.Company_Id.ReadOnly = true;
            this.Company_Id.Visible = false;
            // 
            // Company_Name
            // 
            this.Company_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_Name.DataPropertyName = "Company_Name";
            this.Company_Name.FillWeight = 51.94805F;
            this.Company_Name.HeaderText = "სახელი";
            this.Company_Name.Name = "Company_Name";
            this.Company_Name.ReadOnly = true;
            // 
            // Company_Identity
            // 
            this.Company_Identity.DataPropertyName = "Company_Identity";
            this.Company_Identity.HeaderText = "კომპანიის კოდი";
            this.Company_Identity.Name = "Company_Identity";
            this.Company_Identity.ReadOnly = true;
            this.Company_Identity.Width = 120;
            // 
            // Company_SideType_Id
            // 
            this.Company_SideType_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_SideType_Id.DataPropertyName = "Company_SideType_Id";
            this.Company_SideType_Id.HeaderText = "Company_SideType_Id";
            this.Company_SideType_Id.Name = "Company_SideType_Id";
            this.Company_SideType_Id.ReadOnly = true;
            this.Company_SideType_Id.Visible = false;
            // 
            // Company_SideType_Name
            // 
            this.Company_SideType_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_SideType_Name.DataPropertyName = "Company_SideType_Name";
            this.Company_SideType_Name.HeaderText = "Company_SideType_Name";
            this.Company_SideType_Name.Name = "Company_SideType_Name";
            this.Company_SideType_Name.ReadOnly = true;
            this.Company_SideType_Name.Visible = false;
            // 
            // Company_CitizenshipId
            // 
            this.Company_CitizenshipId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Company_CitizenshipId.DataPropertyName = "Company_CitizenshipId";
            this.Company_CitizenshipId.HeaderText = "ქვეყანა იდ";
            this.Company_CitizenshipId.Name = "Company_CitizenshipId";
            this.Company_CitizenshipId.ReadOnly = true;
            this.Company_CitizenshipId.Visible = false;
            // 
            // Company_Citizenship_Name
            // 
            this.Company_Citizenship_Name.DataPropertyName = "Company_Citizenship_Name";
            this.Company_Citizenship_Name.FillWeight = 51.94805F;
            this.Company_Citizenship_Name.HeaderText = "ქვეყანა";
            this.Company_Citizenship_Name.Name = "Company_Citizenship_Name";
            this.Company_Citizenship_Name.ReadOnly = true;
            this.Company_Citizenship_Name.Width = 120;
            // 
            // Company_Citizenship_NameEn
            // 
            this.Company_Citizenship_NameEn.DataPropertyName = "Company_Citizenship_NameEn";
            this.Company_Citizenship_NameEn.FillWeight = 51.94805F;
            this.Company_Citizenship_NameEn.HeaderText = "ქვეყანა(ინგ)";
            this.Company_Citizenship_NameEn.Name = "Company_Citizenship_NameEn";
            this.Company_Citizenship_NameEn.ReadOnly = true;
            this.Company_Citizenship_NameEn.Width = 120;
            // 
            // Company_Address1
            // 
            this.Company_Address1.DataPropertyName = "Company_Address1";
            this.Company_Address1.FillWeight = 436.3636F;
            this.Company_Address1.HeaderText = "მისამართი 1";
            this.Company_Address1.Name = "Company_Address1";
            this.Company_Address1.ReadOnly = true;
            this.Company_Address1.Width = 120;
            // 
            // Company_Address2
            // 
            this.Company_Address2.DataPropertyName = "Company_Address2";
            this.Company_Address2.FillWeight = 51.94805F;
            this.Company_Address2.HeaderText = "მისამართი 2";
            this.Company_Address2.Name = "Company_Address2";
            this.Company_Address2.ReadOnly = true;
            this.Company_Address2.Width = 120;
            // 
            // Company_Phone1
            // 
            this.Company_Phone1.DataPropertyName = "Company_Phone1";
            this.Company_Phone1.FillWeight = 51.94805F;
            this.Company_Phone1.HeaderText = "ტელეფონი 1";
            this.Company_Phone1.Name = "Company_Phone1";
            this.Company_Phone1.ReadOnly = true;
            this.Company_Phone1.Width = 120;
            // 
            // Company_Phone2
            // 
            this.Company_Phone2.DataPropertyName = "Company_Phone2";
            this.Company_Phone2.FillWeight = 51.94805F;
            this.Company_Phone2.HeaderText = "ტელეფონი 2";
            this.Company_Phone2.Name = "Company_Phone2";
            this.Company_Phone2.ReadOnly = true;
            this.Company_Phone2.Width = 120;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "Company_IBAN";
            this.Column1.FillWeight = 51.94805F;
            this.Column1.HeaderText = "ბანკის კოდი";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.OutsideCompanyDeleteButton);
            this.groupBox5.Controls.Add(this.OutsideCompanyEditButton);
            this.groupBox5.Controls.Add(this.OutsideCompanyAddButton);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(1094, 2);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(163, 669);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "მოქმედებები";
            // 
            // OutsideCompanyDeleteButton
            // 
            this.OutsideCompanyDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutsideCompanyDeleteButton.Location = new System.Drawing.Point(3, 99);
            this.OutsideCompanyDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutsideCompanyDeleteButton.Name = "OutsideCompanyDeleteButton";
            this.OutsideCompanyDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.OutsideCompanyDeleteButton.TabIndex = 17;
            this.OutsideCompanyDeleteButton.Text = "წაშლა";
            this.OutsideCompanyDeleteButton.UseVisualStyleBackColor = true;
            this.OutsideCompanyDeleteButton.Visible = false;
            this.OutsideCompanyDeleteButton.Click += new System.EventHandler(this.OutsideCompanyDeleteButton_Click);
            // 
            // OutsideCompanyEditButton
            // 
            this.OutsideCompanyEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutsideCompanyEditButton.Location = new System.Drawing.Point(3, 60);
            this.OutsideCompanyEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutsideCompanyEditButton.Name = "OutsideCompanyEditButton";
            this.OutsideCompanyEditButton.Size = new System.Drawing.Size(157, 39);
            this.OutsideCompanyEditButton.TabIndex = 16;
            this.OutsideCompanyEditButton.Text = "განახლება";
            this.OutsideCompanyEditButton.UseVisualStyleBackColor = true;
            this.OutsideCompanyEditButton.Click += new System.EventHandler(this.OutsideCompanyEditButton_Click);
            // 
            // OutsideCompanyAddButton
            // 
            this.OutsideCompanyAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutsideCompanyAddButton.Location = new System.Drawing.Point(3, 21);
            this.OutsideCompanyAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutsideCompanyAddButton.Name = "OutsideCompanyAddButton";
            this.OutsideCompanyAddButton.Size = new System.Drawing.Size(157, 39);
            this.OutsideCompanyAddButton.TabIndex = 13;
            this.OutsideCompanyAddButton.Text = "დამატება";
            this.OutsideCompanyAddButton.UseVisualStyleBackColor = true;
            this.OutsideCompanyAddButton.Click += new System.EventHandler(this.OutsideCompanyAddButton_Click);
            // 
            // RowsTabPage
            // 
            this.RowsTabPage.Controls.Add(this.groupBox14);
            this.RowsTabPage.Controls.Add(this.RowGroupBox);
            this.RowsTabPage.Location = new System.Drawing.Point(4, 29);
            this.RowsTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowsTabPage.Name = "RowsTabPage";
            this.RowsTabPage.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowsTabPage.Size = new System.Drawing.Size(1260, 673);
            this.RowsTabPage.TabIndex = 9;
            this.RowsTabPage.Text = "რიგები";
            this.RowsTabPage.UseVisualStyleBackColor = true;
            this.RowsTabPage.Enter += new System.EventHandler(this.RowsTabPage_Enter);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.RowBreedgroupBox);
            this.groupBox14.Controls.Add(this.CompanyRowgroupBox);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox14.Location = new System.Drawing.Point(618, 2);
            this.groupBox14.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(3, 0, 3, 2);
            this.groupBox14.Size = new System.Drawing.Size(639, 669);
            this.groupBox14.TabIndex = 19;
            this.groupBox14.TabStop = false;
            // 
            // RowBreedgroupBox
            // 
            this.RowBreedgroupBox.Controls.Add(this.groupBox11);
            this.RowBreedgroupBox.Controls.Add(this.groupBox6);
            this.RowBreedgroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowBreedgroupBox.Location = new System.Drawing.Point(3, 393);
            this.RowBreedgroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowBreedgroupBox.Name = "RowBreedgroupBox";
            this.RowBreedgroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowBreedgroupBox.Size = new System.Drawing.Size(633, 274);
            this.RowBreedgroupBox.TabIndex = 18;
            this.RowBreedgroupBox.TabStop = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.RowBreeddataGridView);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(3, 21);
            this.groupBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox11.Size = new System.Drawing.Size(464, 251);
            this.groupBox11.TabIndex = 18;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "რიგის ჯიშები";
            // 
            // RowBreeddataGridView
            // 
            this.RowBreeddataGridView.AllowUserToAddRows = false;
            this.RowBreeddataGridView.AllowUserToDeleteRows = false;
            this.RowBreeddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RowBreeddataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.RowBreeddataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowBreeddataGridView.Location = new System.Drawing.Point(3, 21);
            this.RowBreeddataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowBreeddataGridView.Name = "RowBreeddataGridView";
            this.RowBreeddataGridView.ReadOnly = true;
            this.RowBreeddataGridView.RowTemplate.Height = 24;
            this.RowBreeddataGridView.Size = new System.Drawing.Size(458, 228);
            this.RowBreeddataGridView.TabIndex = 0;
            this.RowBreeddataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowBreeddataGridView_CellDoubleClick);
            this.RowBreeddataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.RowBreeddataGridView_RowsAdded);
            this.RowBreeddataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RowBreeddataGridView_RowsRemoved);
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.DataPropertyName = "RowBreed_Breed_Name";
            this.Column2.HeaderText = "სახელი";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "RowBreed_TreeCount";
            this.Column3.HeaderText = "ნერგების რაოდენობა";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 120;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "RowBreed_PlantYear";
            this.Column4.HeaderText = "ნერგის ასაკი";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "RowBreed_StartDate";
            this.Column5.HeaderText = "დაწყების თარიღი";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 230;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "RowBreed_EndDate";
            this.Column6.HeaderText = "დასრულების თარიღი";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 230;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.RowRowBreedAddButton);
            this.groupBox6.Controls.Add(this.RowRowBreedDeleteButton);
            this.groupBox6.Controls.Add(this.RowRowBreedEditButton);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(467, 21);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(163, 251);
            this.groupBox6.TabIndex = 17;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "მოქმედებები";
            // 
            // RowRowBreedAddButton
            // 
            this.RowRowBreedAddButton.Location = new System.Drawing.Point(5, 23);
            this.RowRowBreedAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowRowBreedAddButton.Name = "RowRowBreedAddButton";
            this.RowRowBreedAddButton.Size = new System.Drawing.Size(157, 39);
            this.RowRowBreedAddButton.TabIndex = 1;
            this.RowRowBreedAddButton.Text = "დამატება";
            this.RowRowBreedAddButton.UseVisualStyleBackColor = true;
            this.RowRowBreedAddButton.Click += new System.EventHandler(this.RowRowBreedAddButton_Click);
            // 
            // RowRowBreedDeleteButton
            // 
            this.RowRowBreedDeleteButton.Location = new System.Drawing.Point(5, 110);
            this.RowRowBreedDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowRowBreedDeleteButton.Name = "RowRowBreedDeleteButton";
            this.RowRowBreedDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.RowRowBreedDeleteButton.TabIndex = 3;
            this.RowRowBreedDeleteButton.Text = "წაშლა";
            this.RowRowBreedDeleteButton.UseVisualStyleBackColor = true;
            this.RowRowBreedDeleteButton.Click += new System.EventHandler(this.RowRowBreedDeleteButton_Click);
            // 
            // RowRowBreedEditButton
            // 
            this.RowRowBreedEditButton.Location = new System.Drawing.Point(5, 66);
            this.RowRowBreedEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowRowBreedEditButton.Name = "RowRowBreedEditButton";
            this.RowRowBreedEditButton.Size = new System.Drawing.Size(157, 39);
            this.RowRowBreedEditButton.TabIndex = 2;
            this.RowRowBreedEditButton.Text = "განახლება";
            this.RowRowBreedEditButton.UseVisualStyleBackColor = true;
            this.RowRowBreedEditButton.Click += new System.EventHandler(this.RowRowBreedEditButton_Click);
            // 
            // CompanyRowgroupBox
            // 
            this.CompanyRowgroupBox.Controls.Add(this.groupBox12);
            this.CompanyRowgroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyRowgroupBox.Location = new System.Drawing.Point(3, 19);
            this.CompanyRowgroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyRowgroupBox.Name = "CompanyRowgroupBox";
            this.CompanyRowgroupBox.Padding = new System.Windows.Forms.Padding(0, 2, 3, 2);
            this.CompanyRowgroupBox.Size = new System.Drawing.Size(633, 374);
            this.CompanyRowgroupBox.TabIndex = 17;
            this.CompanyRowgroupBox.TabStop = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.groupBox16);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox12.Location = new System.Drawing.Point(0, 21);
            this.groupBox12.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox12.Size = new System.Drawing.Size(630, 351);
            this.groupBox12.TabIndex = 1;
            this.groupBox12.TabStop = false;
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.CompanyRowdataGridView);
            this.groupBox16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox16.Location = new System.Drawing.Point(3, 21);
            this.groupBox16.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox16.Size = new System.Drawing.Size(624, 328);
            this.groupBox16.TabIndex = 19;
            this.groupBox16.TabStop = false;
            this.groupBox16.Text = "კომპანიის რიგები";
            // 
            // CompanyRowdataGridView
            // 
            this.CompanyRowdataGridView.AllowUserToAddRows = false;
            this.CompanyRowdataGridView.AllowUserToDeleteRows = false;
            this.CompanyRowdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompanyRowdataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CompanyRow_Company_Name,
            this.CompanyRow_StarDate,
            this.CompanyRow_EndDate});
            this.CompanyRowdataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CompanyRowdataGridView.Location = new System.Drawing.Point(3, 21);
            this.CompanyRowdataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CompanyRowdataGridView.Name = "CompanyRowdataGridView";
            this.CompanyRowdataGridView.ReadOnly = true;
            this.CompanyRowdataGridView.RowTemplate.Height = 24;
            this.CompanyRowdataGridView.Size = new System.Drawing.Size(618, 305);
            this.CompanyRowdataGridView.TabIndex = 0;
            // 
            // CompanyRow_Company_Name
            // 
            this.CompanyRow_Company_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CompanyRow_Company_Name.DataPropertyName = "CompanyRow_Company_Name";
            this.CompanyRow_Company_Name.HeaderText = "სახელი";
            this.CompanyRow_Company_Name.Name = "CompanyRow_Company_Name";
            this.CompanyRow_Company_Name.ReadOnly = true;
            // 
            // CompanyRow_StarDate
            // 
            this.CompanyRow_StarDate.DataPropertyName = "CompanyRow_StartDate";
            this.CompanyRow_StarDate.HeaderText = "დაწყების თარიღი";
            this.CompanyRow_StarDate.Name = "CompanyRow_StarDate";
            this.CompanyRow_StarDate.ReadOnly = true;
            this.CompanyRow_StarDate.Width = 230;
            // 
            // CompanyRow_EndDate
            // 
            this.CompanyRow_EndDate.DataPropertyName = "CompanyRow_EndDate";
            this.CompanyRow_EndDate.HeaderText = "დასრულების თარიღი";
            this.CompanyRow_EndDate.Name = "CompanyRow_EndDate";
            this.CompanyRow_EndDate.ReadOnly = true;
            this.CompanyRow_EndDate.Width = 230;
            // 
            // RowGroupBox
            // 
            this.RowGroupBox.Controls.Add(this.groupBox10);
            this.RowGroupBox.Controls.Add(this.groupBox1);
            this.RowGroupBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.RowGroupBox.Location = new System.Drawing.Point(3, 2);
            this.RowGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowGroupBox.Name = "RowGroupBox";
            this.RowGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowGroupBox.Size = new System.Drawing.Size(615, 669);
            this.RowGroupBox.TabIndex = 3;
            this.RowGroupBox.TabStop = false;
            this.RowGroupBox.Text = "რიგები";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.RowDataGridView);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(3, 21);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Size = new System.Drawing.Size(446, 646);
            this.groupBox10.TabIndex = 17;
            this.groupBox10.TabStop = false;
            // 
            // RowDataGridView
            // 
            this.RowDataGridView.AllowUserToAddRows = false;
            this.RowDataGridView.AllowUserToDeleteRows = false;
            this.RowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RowDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Row_Id,
            this.Sector_Number,
            this.Row_Number,
            this.Row_Subrow_Number,
            this.Row_Barkode});
            this.RowDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RowDataGridView.Location = new System.Drawing.Point(3, 21);
            this.RowDataGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowDataGridView.Name = "RowDataGridView";
            this.RowDataGridView.ReadOnly = true;
            this.RowDataGridView.RowTemplate.Height = 24;
            this.RowDataGridView.Size = new System.Drawing.Size(440, 623);
            this.RowDataGridView.TabIndex = 0;
            this.RowDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowDataGridView_CellClick);
            this.RowDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowsDsataGridView_CellDoubleClick);
            this.RowDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.RowDataGridView_RowEnter);
            this.RowDataGridView.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.RowsDsataGridView_RowsAdded);
            this.RowDataGridView.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.RowsDsataGridView_RowsRemoved);
            // 
            // Row_Id
            // 
            this.Row_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Id.DataPropertyName = "Row_Id";
            this.Row_Id.HeaderText = "რიგის ID";
            this.Row_Id.Name = "Row_Id";
            this.Row_Id.ReadOnly = true;
            this.Row_Id.Visible = false;
            // 
            // Sector_Number
            // 
            this.Sector_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Sector_Number.DataPropertyName = "Sector_Number";
            this.Sector_Number.HeaderText = "სექტორის ნომერი";
            this.Sector_Number.Name = "Sector_Number";
            this.Sector_Number.ReadOnly = true;
            this.Sector_Number.Visible = false;
            // 
            // Row_Number
            // 
            this.Row_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Number.DataPropertyName = "Row_Number";
            this.Row_Number.HeaderText = "რიგის ნომერი";
            this.Row_Number.Name = "Row_Number";
            this.Row_Number.ReadOnly = true;
            this.Row_Number.Visible = false;
            // 
            // Row_Subrow_Number
            // 
            this.Row_Subrow_Number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Subrow_Number.DataPropertyName = "Row_Subrow_Number";
            this.Row_Subrow_Number.HeaderText = "ქვერიგის ნომერი";
            this.Row_Subrow_Number.Name = "Row_Subrow_Number";
            this.Row_Subrow_Number.ReadOnly = true;
            this.Row_Subrow_Number.Visible = false;
            // 
            // Row_Barkode
            // 
            this.Row_Barkode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Row_Barkode.DataPropertyName = "Row_Barkode";
            this.Row_Barkode.HeaderText = "რიგი";
            this.Row_Barkode.Name = "Row_Barkode";
            this.Row_Barkode.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PrintButton);
            this.groupBox1.Controls.Add(this.RowAddButton);
            this.groupBox1.Controls.Add(this.RowDeleteButton);
            this.groupBox1.Controls.Add(this.RowEditButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(449, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(163, 646);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "მოქმედებები";
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(3, 150);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(157, 39);
            this.PrintButton.TabIndex = 4;
            this.PrintButton.Text = "ბეჭვდვა";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // RowAddButton
            // 
            this.RowAddButton.Location = new System.Drawing.Point(3, 23);
            this.RowAddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowAddButton.Name = "RowAddButton";
            this.RowAddButton.Size = new System.Drawing.Size(157, 39);
            this.RowAddButton.TabIndex = 1;
            this.RowAddButton.Text = "დამატება";
            this.RowAddButton.UseVisualStyleBackColor = true;
            this.RowAddButton.Click += new System.EventHandler(this.RowAddButton_Click);
            // 
            // RowDeleteButton
            // 
            this.RowDeleteButton.Location = new System.Drawing.Point(3, 110);
            this.RowDeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowDeleteButton.Name = "RowDeleteButton";
            this.RowDeleteButton.Size = new System.Drawing.Size(157, 39);
            this.RowDeleteButton.TabIndex = 3;
            this.RowDeleteButton.Text = "წაშლა";
            this.RowDeleteButton.UseVisualStyleBackColor = true;
            this.RowDeleteButton.Click += new System.EventHandler(this.RowDeleteButton_Click);
            // 
            // RowEditButton
            // 
            this.RowEditButton.Location = new System.Drawing.Point(3, 66);
            this.RowEditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RowEditButton.Name = "RowEditButton";
            this.RowEditButton.Size = new System.Drawing.Size(157, 39);
            this.RowEditButton.TabIndex = 2;
            this.RowEditButton.Text = "განახლება";
            this.RowEditButton.UseVisualStyleBackColor = true;
            this.RowEditButton.Click += new System.EventHandler(this.RowEditButton_Click);
            // 
            // StructureMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 706);
            this.Controls.Add(this.StructureTabControl);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "StructureMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.CarsTabPage.ResumeLayout(false);
            this.CarGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CarDataGridView)).EndInit();
            this.CargroupBox1.ResumeLayout(false);
            this.CarDriversTabPage.ResumeLayout(false);
            this.CarDriversGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CarDriversDataGridView)).EndInit();
            this.CarDrivergroupBox1.ResumeLayout(false);
            this.BrigadesTabPage.ResumeLayout(false);
            this.BrigadeGroupBox.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PersonBrigadeDgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BrigadesDataGridView)).EndInit();
            this.BrigadegroupBox1.ResumeLayout(false);
            this.StructureTabControl.ResumeLayout(false);
            this.CompanyCarsTabPage.ResumeLayout(false);
            this.CompanyCarsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyCarsDataGridView)).EndInit();
            this.CompanyCargroupBox1.ResumeLayout(false);
            this.PostsTabPage.ResumeLayout(false);
            this.PostGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PostDataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.PointsTabPage.ResumeLayout(false);
            this.PointGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PointDataGridView)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.InsideCompanyTabPage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyBreedDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyRowdataGridView)).EndInit();
            this.CompanyRowsGroupBox.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InsideCompanyDataGridView)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.CompanyesTabPage.ResumeLayout(false);
            this.CompanyGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OutsideCompanyDataGridView)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.RowsTabPage.ResumeLayout(false);
            this.groupBox14.ResumeLayout(false);
            this.RowBreedgroupBox.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RowBreeddataGridView)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.CompanyRowgroupBox.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox16.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyRowdataGridView)).EndInit();
            this.RowGroupBox.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RowDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer PermissionsTimer;
        private System.Windows.Forms.Timer RolesTimer;
        private System.Windows.Forms.Timer UsersTimer;
        private System.Windows.Forms.TabPage CarsTabPage;
        private System.Windows.Forms.TabPage CarDriversTabPage;
        private System.Windows.Forms.TabPage BrigadesTabPage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl StructureTabControl;
        private System.Windows.Forms.TabPage CompanyCarsTabPage;
        private System.Windows.Forms.TabPage RowsTabPage;
        private System.Windows.Forms.TabPage CompanyesTabPage;
        private System.Windows.Forms.TabPage InsideCompanyTabPage;
        private System.Windows.Forms.TabPage PointsTabPage;
        private System.Windows.Forms.TabPage PostsTabPage;
        private System.Windows.Forms.DataGridView BrigadesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brigade_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brigade_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Brigade_Description;
        private System.Windows.Forms.DataGridView CarDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car_Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car_SideType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Car_SideType_Name;
        private System.Windows.Forms.DataGridView CarDriversDataGridView;
        private System.Windows.Forms.GroupBox RowGroupBox;
        private System.Windows.Forms.DataGridView RowDataGridView;
        private System.Windows.Forms.DataGridView OutsideCompanyDataGridView;
        private System.Windows.Forms.DataGridView CompanyCarsDataGridView;
        private System.Windows.Forms.DataGridView PointDataGridView;
        private System.Windows.Forms.GroupBox CompanyRowsGroupBox;
        private System.Windows.Forms.DataGridView PostDataGridView;
        private System.Windows.Forms.Button BrigadeAddButton;
        private System.Windows.Forms.Button CarAddButton;
        private System.Windows.Forms.Button CarDriverAddButton;
        private System.Windows.Forms.Button CompanyCarAddButton;
        private System.Windows.Forms.GroupBox BrigadegroupBox1;
        private System.Windows.Forms.GroupBox CargroupBox1;
        private System.Windows.Forms.GroupBox CarDrivergroupBox1;
        private System.Windows.Forms.GroupBox CompanyCargroupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_Car_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_Car_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_Car_Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyCar_EndDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button RowAddButton;
        private System.Windows.Forms.Button RowDeleteButton;
        private System.Windows.Forms.Button RowEditButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button PostAddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_BarCodePrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_BalanceSheetType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post_BalanceSheetType_Name;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button PointAddButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button OutsideCompanyAddButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Car_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Car_Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Car_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Person_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_Person_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_PersonPost_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarDriver_EndDate;
        private System.Windows.Forms.GroupBox RowBreedgroupBox;
        private System.Windows.Forms.DataGridView RowBreeddataGridView;
        private System.Windows.Forms.GroupBox CompanyRowgroupBox;
        private System.Windows.Forms.DataGridView CompanyRowdataGridView;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button RowRowBreedAddButton;
        private System.Windows.Forms.Button RowRowBreedDeleteButton;
        private System.Windows.Forms.Button RowRowBreedEditButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sector_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Subrow_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Row_Barkode;
        private System.Windows.Forms.DataGridView InsideCompanyDataGridView;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button InsideCompanyAddButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView InsideCompanyRowdataGridView;
        private System.Windows.Forms.DataGridView InsideCompanyBreedDataGridView;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button InsideCompanyDeleteButton;
        private System.Windows.Forms.Button InsideCompanyEditButton;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox PointGroupBox;
        private System.Windows.Forms.Button PointDeleteButton;
        private System.Windows.Forms.Button PointEditButton;
        private System.Windows.Forms.GroupBox PostGroupBox;
        private System.Windows.Forms.Button PostDeleteButton;
        private System.Windows.Forms.Button PostEditButton;
        private System.Windows.Forms.GroupBox CompanyCarsGroupBox;
        private System.Windows.Forms.Button CompanyCarDeleteButton;
        private System.Windows.Forms.Button CompanyCarEditButton;
        private System.Windows.Forms.GroupBox CarGroupBox;
        private System.Windows.Forms.Button CarDeleteButton;
        private System.Windows.Forms.Button CarEditButton;
        private System.Windows.Forms.GroupBox CarDriversGroupBox;
        private System.Windows.Forms.Button CarDriverDeleteButton;
        private System.Windows.Forms.Button CarDriverEditButton;
        private System.Windows.Forms.GroupBox BrigadeGroupBox;
        private System.Windows.Forms.Button BrigadeDeleteButton;
        private System.Windows.Forms.Button BrigadUpdateButton;
        private System.Windows.Forms.GroupBox CompanyGroupBox;
        private System.Windows.Forms.Button OutsideCompanyDeleteButton;
        private System.Windows.Forms.Button OutsideCompanyEditButton;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_IBAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_RS_UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_RS_Password;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBreed_Breed_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBreed_TreeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBreed_PlantYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBreed_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowBreed_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Id;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.GroupBox groupBox13;
        private ThetaControlsLibrary.DataGridViewEI PersonBrigadeDgv;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_StarDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CompanyRow_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Identity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_SideType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_SideType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_CitizenshipId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Citizenship_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Citizenship_NameEn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Address1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Address2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Phone1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Company_Phone2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Point_IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_PointType_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_PointType_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Point_PointType_IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Car_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Car_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Car_Model;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Point_Description;
        private System.Windows.Forms.Button PointPrintButton;
        private System.Windows.Forms.Button BagesPrintButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Person_FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_EmployeeBarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Post_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_Brigade_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_BalanceSheetType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_EmployeeType_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonPost_EndDate;
    }
}