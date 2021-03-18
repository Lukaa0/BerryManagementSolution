namespace BerryManagementApplication.Forms.Security
{
    partial class SecurityMainForm
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
            this.SecurityTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.UsersTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.UsersDataGridView = new System.Windows.Forms.DataGridView();
            this.UsersActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.UserIsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordResetButton = new System.Windows.Forms.Button();
            this.RestoreUserButton = new System.Windows.Forms.Button();
            this.DeleteUserButton = new System.Windows.Forms.Button();
            this.EditUserButton = new System.Windows.Forms.Button();
            this.AddUserButton = new System.Windows.Forms.Button();
            this.RolesTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.RolesListGroupBox = new System.Windows.Forms.GroupBox();
            this.RolesDataGridView = new System.Windows.Forms.DataGridView();
            this.Role_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Role_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RolesActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.DeleteRoleButton = new System.Windows.Forms.Button();
            this.EditRoleButton = new System.Windows.Forms.Button();
            this.AddRoleButton = new System.Windows.Forms.Button();
            this.UsersInRoleListGroupBox = new System.Windows.Forms.GroupBox();
            this.PostRoledataGridView = new System.Windows.Forms.DataGridView();
            this.PostRole_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostRole_Role_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostRole_Post_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostRole_StartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostRole_EndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RoleUserActionsGroupBox = new System.Windows.Forms.GroupBox();
            this.RemovePostRoleButton = new System.Windows.Forms.Button();
            this.UpdatePostRoleButton = new System.Windows.Forms.Button();
            this.PostRoleAddButton = new System.Windows.Forms.Button();
            this.PermissionsTabPage = new System.Windows.Forms.TabPage();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.RolesGroupBox = new System.Windows.Forms.GroupBox();
            this.RolesForPermissionDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.PermissionsInRoleGroupBox = new System.Windows.Forms.GroupBox();
            this.PermissionsTreeView = new ThetaControlsLibrary.DisabledTreeView();
            this.PermissionsactionsGroupBox = new System.Windows.Forms.GroupBox();
            this.CancelSavePermissionButton = new System.Windows.Forms.Button();
            this.ChangePermissionButton = new System.Windows.Forms.Button();
            this.PermissionsTimer = new System.Windows.Forms.Timer(this.components);
            this.RolesTimer = new System.Windows.Forms.Timer(this.components);
            this.UsersTimer = new System.Windows.Forms.Timer(this.components);
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Person_FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Person_LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_Role_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User_PaswordIsReset = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SecurityTabControl.SuspendLayout();
            this.UsersTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).BeginInit();
            this.UsersActionsGroupBox.SuspendLayout();
            this.RolesTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.RolesListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RolesDataGridView)).BeginInit();
            this.RolesActionsGroupBox.SuspendLayout();
            this.UsersInRoleListGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostRoledataGridView)).BeginInit();
            this.RoleUserActionsGroupBox.SuspendLayout();
            this.PermissionsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.RolesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RolesForPermissionDataGridView)).BeginInit();
            this.PermissionsInRoleGroupBox.SuspendLayout();
            this.PermissionsactionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SecurityTabControl
            // 
            this.SecurityTabControl.Controls.Add(this.tabPage1);
            this.SecurityTabControl.Controls.Add(this.UsersTabPage);
            this.SecurityTabControl.Controls.Add(this.RolesTabPage);
            this.SecurityTabControl.Controls.Add(this.PermissionsTabPage);
            this.SecurityTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SecurityTabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SecurityTabControl.Location = new System.Drawing.Point(0, 0);
            this.SecurityTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.SecurityTabControl.Name = "SecurityTabControl";
            this.SecurityTabControl.SelectedIndex = 0;
            this.SecurityTabControl.Size = new System.Drawing.Size(1231, 585);
            this.SecurityTabControl.TabIndex = 0;
            this.SecurityTabControl.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.SecurityTabControl_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1223, 552);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // UsersTabPage
            // 
            this.UsersTabPage.Controls.Add(this.tableLayoutPanel1);
            this.UsersTabPage.Location = new System.Drawing.Point(4, 29);
            this.UsersTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.UsersTabPage.Name = "UsersTabPage";
            this.UsersTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.UsersTabPage.Size = new System.Drawing.Size(1223, 552);
            this.UsersTabPage.TabIndex = 0;
            this.UsersTabPage.Text = "მომხმარებლები";
            this.UsersTabPage.UseVisualStyleBackColor = true;
            this.UsersTabPage.Enter += new System.EventHandler(this.UsersTabPage_Enter);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 213F));
            this.tableLayoutPanel1.Controls.Add(this.UsersDataGridView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.UsersActionsGroupBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1215, 544);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // UsersDataGridView
            // 
            this.UsersDataGridView.AllowUserToAddRows = false;
            this.UsersDataGridView.AllowUserToDeleteRows = false;
            this.UsersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UsersDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.User_Person_FirstName,
            this.User_Person_LastName,
            this.User_Role_Name,
            this.User_PaswordIsReset});
            this.UsersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersDataGridView.Location = new System.Drawing.Point(4, 4);
            this.UsersDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.UsersDataGridView.Name = "UsersDataGridView";
            this.UsersDataGridView.ReadOnly = true;
            this.UsersDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UsersDataGridView.Size = new System.Drawing.Size(994, 536);
            this.UsersDataGridView.TabIndex = 4;
            this.UsersDataGridView.Tag = "22";
            this.UsersDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserDataCellClick);
            this.UsersDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.UserDataCellClick);
            this.UsersDataGridView.SelectionChanged += new System.EventHandler(this.UsersDataGridView_SelectionChanged);
            // 
            // UsersActionsGroupBox
            // 
            this.UsersActionsGroupBox.Controls.Add(this.UserIsActiveCheckBox);
            this.UsersActionsGroupBox.Controls.Add(this.PasswordResetButton);
            this.UsersActionsGroupBox.Controls.Add(this.RestoreUserButton);
            this.UsersActionsGroupBox.Controls.Add(this.DeleteUserButton);
            this.UsersActionsGroupBox.Controls.Add(this.EditUserButton);
            this.UsersActionsGroupBox.Controls.Add(this.AddUserButton);
            this.UsersActionsGroupBox.Location = new System.Drawing.Point(1006, 4);
            this.UsersActionsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsersActionsGroupBox.Name = "UsersActionsGroupBox";
            this.UsersActionsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.UsersActionsGroupBox.Size = new System.Drawing.Size(200, 333);
            this.UsersActionsGroupBox.TabIndex = 0;
            this.UsersActionsGroupBox.TabStop = false;
            this.UsersActionsGroupBox.Tag = "19";
            this.UsersActionsGroupBox.Text = "მოქმედებები";
            // 
            // UserIsActiveCheckBox
            // 
            this.UserIsActiveCheckBox.Checked = true;
            this.UserIsActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UserIsActiveCheckBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UserIsActiveCheckBox.Location = new System.Drawing.Point(4, 72);
            this.UserIsActiveCheckBox.Margin = new System.Windows.Forms.Padding(5);
            this.UserIsActiveCheckBox.Name = "UserIsActiveCheckBox";
            this.UserIsActiveCheckBox.Size = new System.Drawing.Size(192, 89);
            this.UserIsActiveCheckBox.TabIndex = 18;
            this.UserIsActiveCheckBox.Tag = "-1";
            this.UserIsActiveCheckBox.Text = "გამოჩნდეს მხოლოდ აქტიური მომხმარებლები";
            this.UserIsActiveCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UserIsActiveCheckBox.ThreeState = true;
            this.UserIsActiveCheckBox.UseVisualStyleBackColor = true;
            this.UserIsActiveCheckBox.Visible = false;
            this.UserIsActiveCheckBox.CheckStateChanged += new System.EventHandler(this.UserIsActiveCheckBox_CheckStateChanged);
            // 
            // PasswordResetButton
            // 
            this.PasswordResetButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PasswordResetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordResetButton.Location = new System.Drawing.Point(4, 23);
            this.PasswordResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.PasswordResetButton.Name = "PasswordResetButton";
            this.PasswordResetButton.Size = new System.Drawing.Size(192, 46);
            this.PasswordResetButton.TabIndex = 17;
            this.PasswordResetButton.Tag = "27";
            this.PasswordResetButton.Text = "პაროლის შეცვლა";
            this.PasswordResetButton.UseVisualStyleBackColor = true;
            this.PasswordResetButton.Click += new System.EventHandler(this.PasswordResetButton_Click);
            // 
            // RestoreUserButton
            // 
            this.RestoreUserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.RestoreUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RestoreUserButton.Location = new System.Drawing.Point(4, 161);
            this.RestoreUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.RestoreUserButton.Name = "RestoreUserButton";
            this.RestoreUserButton.Size = new System.Drawing.Size(192, 42);
            this.RestoreUserButton.TabIndex = 16;
            this.RestoreUserButton.Tag = "26";
            this.RestoreUserButton.Text = "აღდგენა";
            this.RestoreUserButton.UseVisualStyleBackColor = true;
            this.RestoreUserButton.Visible = false;
            this.RestoreUserButton.Click += new System.EventHandler(this.RestoreUserButton_Click);
            // 
            // DeleteUserButton
            // 
            this.DeleteUserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DeleteUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteUserButton.Location = new System.Drawing.Point(4, 203);
            this.DeleteUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.DeleteUserButton.Name = "DeleteUserButton";
            this.DeleteUserButton.Size = new System.Drawing.Size(192, 42);
            this.DeleteUserButton.TabIndex = 15;
            this.DeleteUserButton.Tag = "25";
            this.DeleteUserButton.Text = "წაშლა";
            this.DeleteUserButton.UseVisualStyleBackColor = true;
            this.DeleteUserButton.Visible = false;
            this.DeleteUserButton.Click += new System.EventHandler(this.DeleteUserButton_Click);
            // 
            // EditUserButton
            // 
            this.EditUserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.EditUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditUserButton.Location = new System.Drawing.Point(4, 245);
            this.EditUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(192, 42);
            this.EditUserButton.TabIndex = 14;
            this.EditUserButton.Tag = "24";
            this.EditUserButton.Text = "შეცვლა";
            this.EditUserButton.UseVisualStyleBackColor = true;
            this.EditUserButton.Visible = false;
            this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // AddUserButton
            // 
            this.AddUserButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AddUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserButton.Location = new System.Drawing.Point(4, 287);
            this.AddUserButton.Margin = new System.Windows.Forms.Padding(4);
            this.AddUserButton.Name = "AddUserButton";
            this.AddUserButton.Size = new System.Drawing.Size(192, 42);
            this.AddUserButton.TabIndex = 13;
            this.AddUserButton.Tag = "23";
            this.AddUserButton.Text = "დამატება";
            this.AddUserButton.UseVisualStyleBackColor = true;
            this.AddUserButton.Visible = false;
            this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
            // 
            // RolesTabPage
            // 
            this.RolesTabPage.Controls.Add(this.splitContainer2);
            this.RolesTabPage.Location = new System.Drawing.Point(4, 29);
            this.RolesTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.RolesTabPage.Name = "RolesTabPage";
            this.RolesTabPage.Padding = new System.Windows.Forms.Padding(4);
            this.RolesTabPage.Size = new System.Drawing.Size(1223, 552);
            this.RolesTabPage.TabIndex = 1;
            this.RolesTabPage.Text = "როლები";
            this.RolesTabPage.UseVisualStyleBackColor = true;
            this.RolesTabPage.Enter += new System.EventHandler(this.RolesTabPage_Enter);
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
            this.splitContainer2.Panel1.Controls.Add(this.RolesListGroupBox);
            this.splitContainer2.Panel1.Controls.Add(this.RolesActionsGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.UsersInRoleListGroupBox);
            this.splitContainer2.Panel2.Controls.Add(this.RoleUserActionsGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(1215, 544);
            this.splitContainer2.SplitterDistance = 326;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // RolesListGroupBox
            // 
            this.RolesListGroupBox.Controls.Add(this.RolesDataGridView);
            this.RolesListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.RolesListGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RolesListGroupBox.Name = "RolesListGroupBox";
            this.RolesListGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RolesListGroupBox.Size = new System.Drawing.Size(1015, 326);
            this.RolesListGroupBox.TabIndex = 1;
            this.RolesListGroupBox.TabStop = false;
            this.RolesListGroupBox.Text = "როლების სია";
            // 
            // RolesDataGridView
            // 
            this.RolesDataGridView.AllowUserToAddRows = false;
            this.RolesDataGridView.AllowUserToDeleteRows = false;
            this.RolesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RolesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Role_Id,
            this.Role_Name,
            this.Role_Description});
            this.RolesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesDataGridView.Location = new System.Drawing.Point(4, 23);
            this.RolesDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.RolesDataGridView.Name = "RolesDataGridView";
            this.RolesDataGridView.ReadOnly = true;
            this.RolesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RolesDataGridView.Size = new System.Drawing.Size(1007, 299);
            this.RolesDataGridView.TabIndex = 4;
            this.RolesDataGridView.Tag = "28";
            // 
            // Role_Id
            // 
            this.Role_Id.DataPropertyName = "Role_Id";
            this.Role_Id.HeaderText = "N";
            this.Role_Id.Name = "Role_Id";
            this.Role_Id.ReadOnly = true;
            this.Role_Id.Visible = false;
            this.Role_Id.Width = 70;
            // 
            // Role_Name
            // 
            this.Role_Name.DataPropertyName = "Role_Name";
            this.Role_Name.HeaderText = "როლის სახელი";
            this.Role_Name.Name = "Role_Name";
            this.Role_Name.ReadOnly = true;
            this.Role_Name.Width = 350;
            // 
            // Role_Description
            // 
            this.Role_Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Role_Description.DataPropertyName = "Role_Description";
            this.Role_Description.HeaderText = "როლის აღწერა";
            this.Role_Description.Name = "Role_Description";
            this.Role_Description.ReadOnly = true;
            // 
            // RolesActionsGroupBox
            // 
            this.RolesActionsGroupBox.Controls.Add(this.DeleteRoleButton);
            this.RolesActionsGroupBox.Controls.Add(this.EditRoleButton);
            this.RolesActionsGroupBox.Controls.Add(this.AddRoleButton);
            this.RolesActionsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.RolesActionsGroupBox.Location = new System.Drawing.Point(1015, 0);
            this.RolesActionsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RolesActionsGroupBox.Name = "RolesActionsGroupBox";
            this.RolesActionsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RolesActionsGroupBox.Size = new System.Drawing.Size(200, 326);
            this.RolesActionsGroupBox.TabIndex = 0;
            this.RolesActionsGroupBox.TabStop = false;
            this.RolesActionsGroupBox.Tag = "28";
            this.RolesActionsGroupBox.Text = "მოქმედებები როლებზე";
            // 
            // DeleteRoleButton
            // 
            this.DeleteRoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DeleteRoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteRoleButton.Location = new System.Drawing.Point(4, 109);
            this.DeleteRoleButton.Margin = new System.Windows.Forms.Padding(5);
            this.DeleteRoleButton.Name = "DeleteRoleButton";
            this.DeleteRoleButton.Size = new System.Drawing.Size(192, 43);
            this.DeleteRoleButton.TabIndex = 9;
            this.DeleteRoleButton.Tag = "31";
            this.DeleteRoleButton.Text = "წაშლა";
            this.DeleteRoleButton.UseVisualStyleBackColor = true;
            this.DeleteRoleButton.Click += new System.EventHandler(this.DeleteRoleButton_Click);
            // 
            // EditRoleButton
            // 
            this.EditRoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.EditRoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditRoleButton.Location = new System.Drawing.Point(4, 66);
            this.EditRoleButton.Margin = new System.Windows.Forms.Padding(5);
            this.EditRoleButton.Name = "EditRoleButton";
            this.EditRoleButton.Size = new System.Drawing.Size(192, 43);
            this.EditRoleButton.TabIndex = 8;
            this.EditRoleButton.Tag = "30";
            this.EditRoleButton.Text = "შეცვლა";
            this.EditRoleButton.UseVisualStyleBackColor = true;
            this.EditRoleButton.Click += new System.EventHandler(this.EditRoleButton_Click);
            // 
            // AddRoleButton
            // 
            this.AddRoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddRoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddRoleButton.Location = new System.Drawing.Point(4, 23);
            this.AddRoleButton.Margin = new System.Windows.Forms.Padding(5);
            this.AddRoleButton.Name = "AddRoleButton";
            this.AddRoleButton.Size = new System.Drawing.Size(192, 43);
            this.AddRoleButton.TabIndex = 7;
            this.AddRoleButton.Tag = "29";
            this.AddRoleButton.Text = "დამატება";
            this.AddRoleButton.UseVisualStyleBackColor = true;
            this.AddRoleButton.Click += new System.EventHandler(this.AddRoleButton_Click);
            // 
            // UsersInRoleListGroupBox
            // 
            this.UsersInRoleListGroupBox.Controls.Add(this.PostRoledataGridView);
            this.UsersInRoleListGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UsersInRoleListGroupBox.Location = new System.Drawing.Point(0, 0);
            this.UsersInRoleListGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.UsersInRoleListGroupBox.Name = "UsersInRoleListGroupBox";
            this.UsersInRoleListGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.UsersInRoleListGroupBox.Size = new System.Drawing.Size(1015, 213);
            this.UsersInRoleListGroupBox.TabIndex = 0;
            this.UsersInRoleListGroupBox.TabStop = false;
            this.UsersInRoleListGroupBox.Text = "PostRole";
            // 
            // PostRoledataGridView
            // 
            this.PostRoledataGridView.AllowUserToAddRows = false;
            this.PostRoledataGridView.AllowUserToDeleteRows = false;
            this.PostRoledataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PostRoledataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PostRole_Id,
            this.PostRole_Role_Name,
            this.PostRole_Post_Name,
            this.PostRole_StartDate,
            this.PostRole_EndDate});
            this.PostRoledataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostRoledataGridView.Location = new System.Drawing.Point(4, 23);
            this.PostRoledataGridView.Name = "PostRoledataGridView";
            this.PostRoledataGridView.ReadOnly = true;
            this.PostRoledataGridView.RowTemplate.Height = 24;
            this.PostRoledataGridView.Size = new System.Drawing.Size(1007, 186);
            this.PostRoledataGridView.TabIndex = 10;
            this.PostRoledataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PostRoleCellName);
            // 
            // PostRole_Id
            // 
            this.PostRole_Id.DataPropertyName = "PostRole_Id";
            this.PostRole_Id.HeaderText = "იდი";
            this.PostRole_Id.Name = "PostRole_Id";
            this.PostRole_Id.ReadOnly = true;
            this.PostRole_Id.Visible = false;
            // 
            // PostRole_Role_Name
            // 
            this.PostRole_Role_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PostRole_Role_Name.DataPropertyName = "PostRole_Role_Name";
            this.PostRole_Role_Name.HeaderText = "როლი";
            this.PostRole_Role_Name.Name = "PostRole_Role_Name";
            this.PostRole_Role_Name.ReadOnly = true;
            // 
            // PostRole_Post_Name
            // 
            this.PostRole_Post_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PostRole_Post_Name.DataPropertyName = "PostRole_Post_Name";
            this.PostRole_Post_Name.HeaderText = "პოსტი";
            this.PostRole_Post_Name.Name = "PostRole_Post_Name";
            this.PostRole_Post_Name.ReadOnly = true;
            // 
            // PostRole_StartDate
            // 
            this.PostRole_StartDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PostRole_StartDate.DataPropertyName = "PostRole_Start";
            this.PostRole_StartDate.HeaderText = "დაწყების თარიღი";
            this.PostRole_StartDate.Name = "PostRole_StartDate";
            this.PostRole_StartDate.ReadOnly = true;
            // 
            // PostRole_EndDate
            // 
            this.PostRole_EndDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PostRole_EndDate.DataPropertyName = "PostRole_End";
            this.PostRole_EndDate.HeaderText = "დასრულების თარიღი";
            this.PostRole_EndDate.Name = "PostRole_EndDate";
            this.PostRole_EndDate.ReadOnly = true;
            // 
            // RoleUserActionsGroupBox
            // 
            this.RoleUserActionsGroupBox.Controls.Add(this.RemovePostRoleButton);
            this.RoleUserActionsGroupBox.Controls.Add(this.UpdatePostRoleButton);
            this.RoleUserActionsGroupBox.Controls.Add(this.PostRoleAddButton);
            this.RoleUserActionsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.RoleUserActionsGroupBox.Location = new System.Drawing.Point(1015, 0);
            this.RoleUserActionsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RoleUserActionsGroupBox.Name = "RoleUserActionsGroupBox";
            this.RoleUserActionsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RoleUserActionsGroupBox.Size = new System.Drawing.Size(200, 213);
            this.RoleUserActionsGroupBox.TabIndex = 0;
            this.RoleUserActionsGroupBox.TabStop = false;
            this.RoleUserActionsGroupBox.Tag = "28";
            this.RoleUserActionsGroupBox.Text = "მოქმედებები";
            // 
            // RemovePostRoleButton
            // 
            this.RemovePostRoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.RemovePostRoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemovePostRoleButton.Location = new System.Drawing.Point(4, 142);
            this.RemovePostRoleButton.Margin = new System.Windows.Forms.Padding(5);
            this.RemovePostRoleButton.Name = "RemovePostRoleButton";
            this.RemovePostRoleButton.Size = new System.Drawing.Size(192, 57);
            this.RemovePostRoleButton.TabIndex = 7;
            this.RemovePostRoleButton.Tag = "30";
            this.RemovePostRoleButton.Text = "ამოშლა როლიდან";
            this.RemovePostRoleButton.UseVisualStyleBackColor = true;
            this.RemovePostRoleButton.Click += new System.EventHandler(this.RemoveUserFromRoleButton_Click);
            // 
            // UpdatePostRoleButton
            // 
            this.UpdatePostRoleButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.UpdatePostRoleButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpdatePostRoleButton.Location = new System.Drawing.Point(4, 85);
            this.UpdatePostRoleButton.Margin = new System.Windows.Forms.Padding(5);
            this.UpdatePostRoleButton.Name = "UpdatePostRoleButton";
            this.UpdatePostRoleButton.Size = new System.Drawing.Size(192, 57);
            this.UpdatePostRoleButton.TabIndex = 8;
            this.UpdatePostRoleButton.Tag = "30";
            this.UpdatePostRoleButton.Text = "როლის რედაქტირება";
            this.UpdatePostRoleButton.UseVisualStyleBackColor = true;
            this.UpdatePostRoleButton.Click += new System.EventHandler(this.UpdatePostRole_Click);
            // 
            // PostRoleAddButton
            // 
            this.PostRoleAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.PostRoleAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostRoleAddButton.Location = new System.Drawing.Point(4, 23);
            this.PostRoleAddButton.Margin = new System.Windows.Forms.Padding(5);
            this.PostRoleAddButton.Name = "PostRoleAddButton";
            this.PostRoleAddButton.Size = new System.Drawing.Size(192, 62);
            this.PostRoleAddButton.TabIndex = 5;
            this.PostRoleAddButton.Tag = "30";
            this.PostRoleAddButton.Text = "დამატება როლში";
            this.PostRoleAddButton.UseVisualStyleBackColor = true;
            this.PostRoleAddButton.Click += new System.EventHandler(this.UserAddInRoleButton_Click);
            // 
            // PermissionsTabPage
            // 
            this.PermissionsTabPage.Controls.Add(this.splitContainer7);
            this.PermissionsTabPage.Location = new System.Drawing.Point(4, 29);
            this.PermissionsTabPage.Margin = new System.Windows.Forms.Padding(4);
            this.PermissionsTabPage.Name = "PermissionsTabPage";
            this.PermissionsTabPage.Size = new System.Drawing.Size(1223, 552);
            this.PermissionsTabPage.TabIndex = 2;
            this.PermissionsTabPage.Text = "უფლებები";
            this.PermissionsTabPage.UseVisualStyleBackColor = true;
            this.PermissionsTabPage.Enter += new System.EventHandler(this.PermissionsTabPage_Enter);
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(0, 0);
            this.splitContainer7.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.RolesGroupBox);
            this.splitContainer7.Panel1.Controls.Add(this.splitter1);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.PermissionsInRoleGroupBox);
            this.splitContainer7.Panel2.Controls.Add(this.PermissionsactionsGroupBox);
            this.splitContainer7.Size = new System.Drawing.Size(1223, 552);
            this.splitContainer7.SplitterDistance = 217;
            this.splitContainer7.SplitterWidth = 5;
            this.splitContainer7.TabIndex = 6;
            // 
            // RolesGroupBox
            // 
            this.RolesGroupBox.Controls.Add(this.RolesForPermissionDataGridView);
            this.RolesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesGroupBox.Location = new System.Drawing.Point(4, 0);
            this.RolesGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.RolesGroupBox.Name = "RolesGroupBox";
            this.RolesGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.RolesGroupBox.Size = new System.Drawing.Size(1219, 217);
            this.RolesGroupBox.TabIndex = 4;
            this.RolesGroupBox.TabStop = false;
            this.RolesGroupBox.Text = "როლების სია";
            // 
            // RolesForPermissionDataGridView
            // 
            this.RolesForPermissionDataGridView.AllowUserToAddRows = false;
            this.RolesForPermissionDataGridView.AllowUserToDeleteRows = false;
            this.RolesForPermissionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RolesForPermissionDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.RolesForPermissionDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RolesForPermissionDataGridView.Location = new System.Drawing.Point(4, 23);
            this.RolesForPermissionDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.RolesForPermissionDataGridView.Name = "RolesForPermissionDataGridView";
            this.RolesForPermissionDataGridView.ReadOnly = true;
            this.RolesForPermissionDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RolesForPermissionDataGridView.Size = new System.Drawing.Size(1211, 190);
            this.RolesForPermissionDataGridView.TabIndex = 4;
            this.RolesForPermissionDataGridView.Tag = "32";
            this.RolesForPermissionDataGridView.SelectionChanged += new System.EventHandler(this.RolesForPermissionDataGridView_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Role_Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "N";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Role_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "როლის სახელი";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Role_Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "როლის აღწერა";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 217);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // PermissionsInRoleGroupBox
            // 
            this.PermissionsInRoleGroupBox.Controls.Add(this.PermissionsTreeView);
            this.PermissionsInRoleGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PermissionsInRoleGroupBox.Location = new System.Drawing.Point(0, 0);
            this.PermissionsInRoleGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.PermissionsInRoleGroupBox.Name = "PermissionsInRoleGroupBox";
            this.PermissionsInRoleGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.PermissionsInRoleGroupBox.Size = new System.Drawing.Size(1023, 330);
            this.PermissionsInRoleGroupBox.TabIndex = 2;
            this.PermissionsInRoleGroupBox.TabStop = false;
            this.PermissionsInRoleGroupBox.Text = "უფლებები არჩეულ როლში";
            // 
            // PermissionsTreeView
            // 
            this.PermissionsTreeView.CheckBoxes = true;
            this.PermissionsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PermissionsTreeView.Location = new System.Drawing.Point(4, 23);
            this.PermissionsTreeView.Margin = new System.Windows.Forms.Padding(4);
            this.PermissionsTreeView.Name = "PermissionsTreeView";
            this.PermissionsTreeView.Size = new System.Drawing.Size(1015, 303);
            this.PermissionsTreeView.TabIndex = 7;
            this.PermissionsTreeView.Tag = "32";
            this.PermissionsTreeView.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.PermissionsTreeView_BeforeCheck);
            this.PermissionsTreeView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.PermissionsTreeView_AfterCheck);
            // 
            // PermissionsactionsGroupBox
            // 
            this.PermissionsactionsGroupBox.Controls.Add(this.CancelSavePermissionButton);
            this.PermissionsactionsGroupBox.Controls.Add(this.ChangePermissionButton);
            this.PermissionsactionsGroupBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.PermissionsactionsGroupBox.Location = new System.Drawing.Point(1023, 0);
            this.PermissionsactionsGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.PermissionsactionsGroupBox.Name = "PermissionsactionsGroupBox";
            this.PermissionsactionsGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.PermissionsactionsGroupBox.Size = new System.Drawing.Size(200, 330);
            this.PermissionsactionsGroupBox.TabIndex = 7;
            this.PermissionsactionsGroupBox.TabStop = false;
            this.PermissionsactionsGroupBox.Tag = "32";
            this.PermissionsactionsGroupBox.Text = "მოქმედებები";
            // 
            // CancelSavePermissionButton
            // 
            this.CancelSavePermissionButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.CancelSavePermissionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelSavePermissionButton.Location = new System.Drawing.Point(4, 88);
            this.CancelSavePermissionButton.Margin = new System.Windows.Forms.Padding(5);
            this.CancelSavePermissionButton.Name = "CancelSavePermissionButton";
            this.CancelSavePermissionButton.Size = new System.Drawing.Size(192, 65);
            this.CancelSavePermissionButton.TabIndex = 6;
            this.CancelSavePermissionButton.Tag = "33";
            this.CancelSavePermissionButton.Text = "გაუქმება";
            this.CancelSavePermissionButton.UseVisualStyleBackColor = true;
            this.CancelSavePermissionButton.Visible = false;
            this.CancelSavePermissionButton.Click += new System.EventHandler(this.CancelSavePermissionButton_Click);
            // 
            // ChangePermissionButton
            // 
            this.ChangePermissionButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ChangePermissionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChangePermissionButton.Location = new System.Drawing.Point(4, 23);
            this.ChangePermissionButton.Margin = new System.Windows.Forms.Padding(5);
            this.ChangePermissionButton.Name = "ChangePermissionButton";
            this.ChangePermissionButton.Size = new System.Drawing.Size(192, 65);
            this.ChangePermissionButton.TabIndex = 5;
            this.ChangePermissionButton.Tag = "33";
            this.ChangePermissionButton.Text = "უფლებების შეცვლა";
            this.ChangePermissionButton.UseVisualStyleBackColor = true;
            this.ChangePermissionButton.Click += new System.EventHandler(this.ChangePermissionButton_Click);
            // 
            // PermissionsTimer
            // 
            this.PermissionsTimer.Interval = 500;
            this.PermissionsTimer.Tick += new System.EventHandler(this.PermissionsTimer_Tick);
            // 
            // RolesTimer
            // 
            this.RolesTimer.Interval = 300;
            this.RolesTimer.Tick += new System.EventHandler(this.RolesTimer_Tick);
            // 
            // UsersTimer
            // 
            this.UsersTimer.Interval = 300;
            this.UsersTimer.Tick += new System.EventHandler(this.UsersTimer_Tick);
            // 
            // UserId
            // 
            this.UserId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserId.DataPropertyName = "User_Person_Id";
            this.UserId.HeaderText = "N";
            this.UserId.Name = "UserId";
            this.UserId.ReadOnly = true;
            this.UserId.Visible = false;
            // 
            // User_Person_FirstName
            // 
            this.User_Person_FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_Person_FirstName.DataPropertyName = "User_Person_FirstName";
            this.User_Person_FirstName.HeaderText = "მომხმარებლის სახელი";
            this.User_Person_FirstName.Name = "User_Person_FirstName";
            this.User_Person_FirstName.ReadOnly = true;
            // 
            // User_Person_LastName
            // 
            this.User_Person_LastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_Person_LastName.DataPropertyName = "User_Person_LastName";
            this.User_Person_LastName.HeaderText = "გვარი";
            this.User_Person_LastName.Name = "User_Person_LastName";
            this.User_Person_LastName.ReadOnly = true;
            // 
            // User_Role_Name
            // 
            this.User_Role_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_Role_Name.DataPropertyName = "User_Role_Name";
            this.User_Role_Name.HeaderText = "როლის სახელი";
            this.User_Role_Name.Name = "User_Role_Name";
            this.User_Role_Name.ReadOnly = true;
            // 
            // User_PaswordIsReset
            // 
            this.User_PaswordIsReset.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.User_PaswordIsReset.DataPropertyName = "User_PasswordIsReset";
            this.User_PaswordIsReset.FalseValue = "False";
            this.User_PaswordIsReset.HeaderText = "პაროლი დასარესტარტებელია";
            this.User_PaswordIsReset.Name = "User_PaswordIsReset";
            this.User_PaswordIsReset.ReadOnly = true;
            this.User_PaswordIsReset.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.User_PaswordIsReset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.User_PaswordIsReset.TrueValue = "Trrue";
            // 
            // SecurityMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1231, 585);
            this.Controls.Add(this.SecurityTabControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SecurityMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HRSecMainForm_FormClosing);
            this.SecurityTabControl.ResumeLayout(false);
            this.UsersTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.UsersDataGridView)).EndInit();
            this.UsersActionsGroupBox.ResumeLayout(false);
            this.RolesTabPage.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.RolesListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RolesDataGridView)).EndInit();
            this.RolesActionsGroupBox.ResumeLayout(false);
            this.UsersInRoleListGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PostRoledataGridView)).EndInit();
            this.RoleUserActionsGroupBox.ResumeLayout(false);
            this.PermissionsTabPage.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.RolesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RolesForPermissionDataGridView)).EndInit();
            this.PermissionsInRoleGroupBox.ResumeLayout(false);
            this.PermissionsactionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SecurityTabControl;
        private System.Windows.Forms.TabPage UsersTabPage;
        private System.Windows.Forms.TabPage RolesTabPage;
        private System.Windows.Forms.TabPage PermissionsTabPage;
        private System.Windows.Forms.GroupBox UsersActionsGroupBox;
        private System.Windows.Forms.DataGridView UsersDataGridView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox RolesActionsGroupBox;
        private System.Windows.Forms.GroupBox UsersInRoleListGroupBox;
        private System.Windows.Forms.GroupBox RoleUserActionsGroupBox;
        private System.Windows.Forms.Button PostRoleAddButton;
        private System.Windows.Forms.Button ChangePermissionButton;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.GroupBox RolesGroupBox;
        private System.Windows.Forms.DataGridView RolesForPermissionDataGridView;
        private System.Windows.Forms.GroupBox PermissionsInRoleGroupBox;
        private System.Windows.Forms.GroupBox PermissionsactionsGroupBox;
        private ThetaControlsLibrary.DisabledTreeView PermissionsTreeView;
        private System.Windows.Forms.Button CancelSavePermissionButton;
        private System.Windows.Forms.Timer PermissionsTimer;
        private System.Windows.Forms.Timer RolesTimer;
        private System.Windows.Forms.Timer UsersTimer;
        private System.Windows.Forms.Button PasswordResetButton;
        private System.Windows.Forms.Button RestoreUserButton;
        private System.Windows.Forms.Button DeleteUserButton;
        private System.Windows.Forms.Button EditUserButton;
        private System.Windows.Forms.Button AddUserButton;
        private System.Windows.Forms.Button DeleteRoleButton;
        private System.Windows.Forms.Button EditRoleButton;
        private System.Windows.Forms.Button AddRoleButton;
        private System.Windows.Forms.Button RemovePostRoleButton;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox UserIsActiveCheckBox;
        private System.Windows.Forms.GroupBox RolesListGroupBox;
        private System.Windows.Forms.DataGridView RolesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button UpdatePostRoleButton;
        private System.Windows.Forms.DataGridView PostRoledataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Role_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRole_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRole_Role_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRole_Post_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRole_StartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn PostRole_EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Person_FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Person_LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn User_Role_Name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn User_PaswordIsReset;
    }
}