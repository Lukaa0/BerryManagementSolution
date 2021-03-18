namespace BerryPackagingApplication
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.IdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.HarvestDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxIdOldColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrossColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NetColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BoxIdNewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.BoxLabelOld = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BrutWeightLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.WeightButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.NetWeightLabel = new System.Windows.Forms.Label();
            this.PackagingTabPage = new System.Windows.Forms.TabControl();
            this.PaleteTabPage = new System.Windows.Forms.TabPage();
            this.WeightTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ContainerGroupBox = new System.Windows.Forms.GroupBox();
            this.ContainerDataGridView = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.SortingButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CountNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.GeneraitButton = new System.Windows.Forms.Button();
            this.Container_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Container_IsActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Container_ContainerType_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaleteButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Scale = new BerryPackagingApplication.Controls.ScaleControler();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.PackagingTabPage.SuspendLayout();
            this.PaleteTabPage.SuspendLayout();
            this.WeightTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ContainerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ContainerDataGridView)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 263);
            this.panel1.TabIndex = 0;
            // 
            // IdColumn
            // 
            this.IdColumn.DataPropertyName = "Id";
            this.IdColumn.HeaderText = "";
            this.IdColumn.Name = "IdColumn";
            this.IdColumn.ReadOnly = true;
            this.IdColumn.Visible = false;
            // 
            // ButtonColumn
            // 
            this.ButtonColumn.HeaderText = "ბეჭდვა";
            this.ButtonColumn.Name = "ButtonColumn";
            this.ButtonColumn.ReadOnly = true;
            this.ButtonColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ButtonColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ButtonColumn.Text = "დაბეჭდე";
            this.ButtonColumn.UseColumnTextForButtonValue = true;
            // 
            // HarvestDateColumn
            // 
            this.HarvestDateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.HarvestDateColumn.DataPropertyName = "HarvestDate";
            this.HarvestDateColumn.HeaderText = "კრეფის დრო";
            this.HarvestDateColumn.Name = "HarvestDateColumn";
            this.HarvestDateColumn.ReadOnly = true;
            // 
            // BoxIdOldColumn
            // 
            this.BoxIdOldColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BoxIdOldColumn.DataPropertyName = "BoxIdOld";
            this.BoxIdOldColumn.HeaderText = "ყუთი ძველი";
            this.BoxIdOldColumn.Name = "BoxIdOldColumn";
            this.BoxIdOldColumn.ReadOnly = true;
            // 
            // TimeColumn
            // 
            this.TimeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TimeColumn.DataPropertyName = "Time";
            this.TimeColumn.HeaderText = "შეფუთვის დრო";
            this.TimeColumn.Name = "TimeColumn";
            this.TimeColumn.ReadOnly = true;
            // 
            // GrossColumn
            // 
            this.GrossColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GrossColumn.DataPropertyName = "Gross";
            this.GrossColumn.HeaderText = "წონა ბრუტო";
            this.GrossColumn.Name = "GrossColumn";
            this.GrossColumn.ReadOnly = true;
            // 
            // NetColumn
            // 
            this.NetColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NetColumn.DataPropertyName = "Net";
            this.NetColumn.HeaderText = "წონა ნეტო";
            this.NetColumn.Name = "NetColumn";
            this.NetColumn.ReadOnly = true;
            // 
            // BoxIdNewColumn
            // 
            this.BoxIdNewColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BoxIdNewColumn.DataPropertyName = "BoxIdNew";
            this.BoxIdNewColumn.HeaderText = "ყუთი ახალი";
            this.BoxIdNewColumn.Name = "BoxIdNewColumn";
            this.BoxIdNewColumn.ReadOnly = true;
            // 
            // BreedNameColumn
            // 
            this.BreedNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreedNameColumn.DataPropertyName = "BreedName";
            this.BreedNameColumn.HeaderText = "ჯიში";
            this.BreedNameColumn.Name = "BreedNameColumn";
            this.BreedNameColumn.ReadOnly = true;
            // 
            // DGridView
            // 
            this.DGridView.AllowUserToAddRows = false;
            this.DGridView.AllowUserToDeleteRows = false;
            this.DGridView.AllowUserToResizeColumns = false;
            this.DGridView.AllowUserToResizeRows = false;
            this.DGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BreedNameColumn,
            this.BoxIdNewColumn,
            this.NetColumn,
            this.GrossColumn,
            this.TimeColumn,
            this.BoxIdOldColumn,
            this.HarvestDateColumn,
            this.ButtonColumn,
            this.IdColumn});
            this.DGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGridView.Location = new System.Drawing.Point(3, 266);
            this.DGridView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DGridView.Name = "DGridView";
            this.DGridView.ReadOnly = true;
            this.DGridView.RowTemplate.Height = 24;
            this.DGridView.Size = new System.Drawing.Size(925, 226);
            this.DGridView.TabIndex = 1;
            this.DGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvButtonClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Scale);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(513, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(412, 263);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "სასწორის მართვა";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.NetWeightLabel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.WeightButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.BrutWeightLabel, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.BoxLabelOld, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ClearButton, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 43);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 216);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // ClearButton
            // 
            this.ClearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearButton.ForeColor = System.Drawing.Color.Red;
            this.ClearButton.Location = new System.Drawing.Point(255, 57);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(44, 48);
            this.ClearButton.TabIndex = 9;
            this.ClearButton.Text = "R";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // BoxLabelOld
            // 
            this.BoxLabelOld.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BoxLabelOld.Location = new System.Drawing.Point(4, 58);
            this.BoxLabelOld.Margin = new System.Windows.Forms.Padding(4);
            this.BoxLabelOld.Name = "BoxLabelOld";
            this.BoxLabelOld.Size = new System.Drawing.Size(244, 46);
            this.BoxLabelOld.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(306, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 54);
            this.label2.TabIndex = 6;
            this.label2.Text = "წონა ბრუტო";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BrutWeightLabel
            // 
            this.BrutWeightLabel.AutoSize = true;
            this.BrutWeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrutWeightLabel.Location = new System.Drawing.Point(306, 54);
            this.BrutWeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BrutWeightLabel.Name = "BrutWeightLabel";
            this.BrutWeightLabel.Size = new System.Drawing.Size(93, 54);
            this.BrutWeightLabel.TabIndex = 8;
            this.BrutWeightLabel.Text = "---";
            this.BrutWeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "ყუთი";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WeightButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.WeightButton, 4);
            this.WeightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WeightButton.Location = new System.Drawing.Point(4, 112);
            this.WeightButton.Margin = new System.Windows.Forms.Padding(4);
            this.WeightButton.Name = "WeightButton";
            this.WeightButton.Size = new System.Drawing.Size(497, 100);
            this.WeightButton.TabIndex = 5;
            this.WeightButton.Text = "წონის დაფიქსირება";
            this.WeightButton.UseVisualStyleBackColor = true;
            this.WeightButton.Click += new System.EventHandler(this.WeightButton_Click);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(407, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 54);
            this.label3.TabIndex = 7;
            this.label3.Text = "წონა ნეტო";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NetWeightLabel
            // 
            this.NetWeightLabel.AutoSize = true;
            this.NetWeightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetWeightLabel.Location = new System.Drawing.Point(407, 54);
            this.NetWeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NetWeightLabel.Name = "NetWeightLabel";
            this.NetWeightLabel.Size = new System.Drawing.Size(94, 54);
            this.NetWeightLabel.TabIndex = 0;
            this.NetWeightLabel.Text = "---";
            this.NetWeightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PackagingTabPage
            // 
            this.PackagingTabPage.Controls.Add(this.WeightTabPage);
            this.PackagingTabPage.Controls.Add(this.PaleteTabPage);
            this.PackagingTabPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PackagingTabPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PackagingTabPage.Location = new System.Drawing.Point(0, 0);
            this.PackagingTabPage.Name = "PackagingTabPage";
            this.PackagingTabPage.SelectedIndex = 0;
            this.PackagingTabPage.Size = new System.Drawing.Size(939, 537);
            this.PackagingTabPage.TabIndex = 1;
            // 
            // PaleteTabPage
            // 
            this.PaleteTabPage.Controls.Add(this.ContainerGroupBox);
            this.PaleteTabPage.Controls.Add(this.groupBox3);
            this.PaleteTabPage.Location = new System.Drawing.Point(4, 38);
            this.PaleteTabPage.Name = "PaleteTabPage";
            this.PaleteTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PaleteTabPage.Size = new System.Drawing.Size(931, 495);
            this.PaleteTabPage.TabIndex = 1;
            this.PaleteTabPage.Text = "პალეტები";
            this.PaleteTabPage.UseVisualStyleBackColor = true;
            this.PaleteTabPage.Enter += new System.EventHandler(this.PaleteTabPage_Enter);
            // 
            // WeightTabPage
            // 
            this.WeightTabPage.Controls.Add(this.DGridView);
            this.WeightTabPage.Controls.Add(this.panel1);
            this.WeightTabPage.Location = new System.Drawing.Point(4, 38);
            this.WeightTabPage.Name = "WeightTabPage";
            this.WeightTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.WeightTabPage.Size = new System.Drawing.Size(931, 495);
            this.WeightTabPage.TabIndex = 0;
            this.WeightTabPage.Text = "სასწორი";
            this.WeightTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(513, 263);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "დაფასოება და აწონვა";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ActiveCheckBox);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.CountNumericUpDown);
            this.groupBox3.Controls.Add(this.GeneraitButton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(925, 175);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "გენერირება";
            // 
            // ContainerGroupBox
            // 
            this.ContainerGroupBox.Controls.Add(this.ContainerDataGridView);
            this.ContainerGroupBox.Controls.Add(this.panel5);
            this.ContainerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerGroupBox.Location = new System.Drawing.Point(3, 178);
            this.ContainerGroupBox.Name = "ContainerGroupBox";
            this.ContainerGroupBox.Size = new System.Drawing.Size(925, 314);
            this.ContainerGroupBox.TabIndex = 18;
            this.ContainerGroupBox.TabStop = false;
            this.ContainerGroupBox.Text = "ყუთი";
            // 
            // ContainerDataGridView
            // 
            this.ContainerDataGridView.AllowUserToDeleteRows = false;
            this.ContainerDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContainerDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Container_BarCode,
            this.Container_IsActive,
            this.Container_ContainerType_Id,
            this.PaleteButton});
            this.ContainerDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContainerDataGridView.Location = new System.Drawing.Point(3, 30);
            this.ContainerDataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.ContainerDataGridView.Name = "ContainerDataGridView";
            this.ContainerDataGridView.ReadOnly = true;
            this.ContainerDataGridView.Size = new System.Drawing.Size(677, 281);
            this.ContainerDataGridView.TabIndex = 16;
            this.ContainerDataGridView.Tag = "89";
            this.ContainerDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ContainerDataGridView_CellContentClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.SortingButton);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(680, 30);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(242, 281);
            this.panel5.TabIndex = 17;
            this.panel5.Tag = "100";
            // 
            // SortingButton
            // 
            this.SortingButton.Location = new System.Drawing.Point(3, 3);
            this.SortingButton.Name = "SortingButton";
            this.SortingButton.Size = new System.Drawing.Size(231, 39);
            this.SortingButton.TabIndex = 9;
            this.SortingButton.Text = "სორტირება";
            this.SortingButton.UseVisualStyleBackColor = true;
            this.SortingButton.Click += new System.EventHandler(this.SortingButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 48);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 33);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "აქტიური";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ActiveCheckBox
            // 
            this.ActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ActiveCheckBox.AutoSize = true;
            this.ActiveCheckBox.Location = new System.Drawing.Point(426, 79);
            this.ActiveCheckBox.Name = "ActiveCheckBox";
            this.ActiveCheckBox.Size = new System.Drawing.Size(136, 33);
            this.ActiveCheckBox.TabIndex = 14;
            this.ActiveCheckBox.Text = "აქტიური";
            this.ActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(153, 29);
            this.label4.TabIndex = 13;
            this.label4.Text = "რაოდენობა";
            // 
            // CountNumericUpDown
            // 
            this.CountNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CountNumericUpDown.Location = new System.Drawing.Point(248, 78);
            this.CountNumericUpDown.Name = "CountNumericUpDown";
            this.CountNumericUpDown.Size = new System.Drawing.Size(138, 34);
            this.CountNumericUpDown.TabIndex = 11;
            // 
            // GeneraitButton
            // 
            this.GeneraitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GeneraitButton.Location = new System.Drawing.Point(602, 79);
            this.GeneraitButton.Margin = new System.Windows.Forms.Padding(4);
            this.GeneraitButton.Name = "GeneraitButton";
            this.GeneraitButton.Size = new System.Drawing.Size(238, 36);
            this.GeneraitButton.TabIndex = 9;
            this.GeneraitButton.Tag = "102";
            this.GeneraitButton.Text = "გენერირება";
            this.GeneraitButton.UseVisualStyleBackColor = true;
            this.GeneraitButton.Click += new System.EventHandler(this.GeneraitButton_Click);
            // 
            // Container_BarCode
            // 
            this.Container_BarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Container_BarCode.DataPropertyName = "Container_BarCode";
            this.Container_BarCode.HeaderText = "ყუთები";
            this.Container_BarCode.Name = "Container_BarCode";
            this.Container_BarCode.ReadOnly = true;
            // 
            // Container_IsActive
            // 
            this.Container_IsActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Container_IsActive.DataPropertyName = "Container_IsActive";
            this.Container_IsActive.FalseValue = "0";
            this.Container_IsActive.HeaderText = "ყუთი აქტივობა";
            this.Container_IsActive.Name = "Container_IsActive";
            this.Container_IsActive.ReadOnly = true;
            this.Container_IsActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Container_IsActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Container_IsActive.TrueValue = "1";
            // 
            // Container_ContainerType_Id
            // 
            this.Container_ContainerType_Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Container_ContainerType_Id.DataPropertyName = "Container_ContainerType_Id";
            this.Container_ContainerType_Id.HeaderText = "ყუთის სახე";
            this.Container_ContainerType_Id.Name = "Container_ContainerType_Id";
            this.Container_ContainerType_Id.ReadOnly = true;
            // 
            // PaleteButton
            // 
            this.PaleteButton.HeaderText = "ბეჭდვა";
            this.PaleteButton.Name = "PaleteButton";
            this.PaleteButton.ReadOnly = true;
            this.PaleteButton.Text = "ბეჭდვა";
            this.PaleteButton.UseColumnTextForButtonValue = true;
            // 
            // Scale
            // 
            this.Scale.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Scale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scale.Location = new System.Drawing.Point(5, 45);
            this.Scale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Scale.Name = "Scale";
            this.Scale.scaleCom = "COM1";
            this.Scale.Size = new System.Drawing.Size(402, 212);
            this.Scale.TabIndex = 0;
            this.Scale.Weight = "UNSTABLE";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 537);
            this.Controls.Add(this.PackagingTabPage);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "სასწორი";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.PackagingTabPage.ResumeLayout(false);
            this.PaleteTabPage.ResumeLayout(false);
            this.WeightTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ContainerGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ContainerDataGridView)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CountNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.ScaleControler Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColumn;
        private System.Windows.Forms.DataGridViewButtonColumn ButtonColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HarvestDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxIdOldColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrossColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NetColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BoxIdNewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedNameColumn;
        private System.Windows.Forms.DataGridView DGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NetWeightLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button WeightButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BrutWeightLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BoxLabelOld;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TabControl PackagingTabPage;
        private System.Windows.Forms.TabPage WeightTabPage;
        private System.Windows.Forms.TabPage PaleteTabPage;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox ContainerGroupBox;
        private System.Windows.Forms.DataGridView ContainerDataGridView;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button SortingButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox ActiveCheckBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown CountNumericUpDown;
        private System.Windows.Forms.Button GeneraitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Container_BarCode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Container_IsActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn Container_ContainerType_Id;
        private System.Windows.Forms.DataGridViewButtonColumn PaleteButton;
    }
}