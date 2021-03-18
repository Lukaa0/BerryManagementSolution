namespace BerryManagementApplication.Forms.Template
{
    partial class TemplatesMainForm
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
            this.TemplatesTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DocumentTemplatesTabPage = new System.Windows.Forms.TabPage();
            this.DocumentTemplatesGroupBox = new System.Windows.Forms.GroupBox();
            this.DocumentTemplatesDataGridView = new System.Windows.Forms.DataGridView();
            this.DocumentTemplateTitleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DocumentTemplateDeleteButton = new System.Windows.Forms.Button();
            this.DocumentTemplateEditButton = new System.Windows.Forms.Button();
            this.DocumentTemplateAddButton = new System.Windows.Forms.Button();
            this.DocumentTemplateViewButton = new System.Windows.Forms.Button();
            this.TemplatesTabControl.SuspendLayout();
            this.DocumentTemplatesTabPage.SuspendLayout();
            this.DocumentTemplatesGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTemplatesDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TemplatesTabControl
            // 
            this.TemplatesTabControl.Controls.Add(this.tabPage1);
            this.TemplatesTabControl.Controls.Add(this.DocumentTemplatesTabPage);
            this.TemplatesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TemplatesTabControl.Location = new System.Drawing.Point(0, 0);
            this.TemplatesTabControl.Name = "TemplatesTabControl";
            this.TemplatesTabControl.SelectedIndex = 0;
            this.TemplatesTabControl.Size = new System.Drawing.Size(623, 354);
            this.TemplatesTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(615, 328);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // DocumentTemplatesTabPage
            // 
            this.DocumentTemplatesTabPage.Controls.Add(this.DocumentTemplatesGroupBox);
            this.DocumentTemplatesTabPage.Controls.Add(this.groupBox1);
            this.DocumentTemplatesTabPage.Location = new System.Drawing.Point(4, 22);
            this.DocumentTemplatesTabPage.Name = "DocumentTemplatesTabPage";
            this.DocumentTemplatesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.DocumentTemplatesTabPage.Size = new System.Drawing.Size(615, 328);
            this.DocumentTemplatesTabPage.TabIndex = 1;
            this.DocumentTemplatesTabPage.Text = "დოკუმენტების შაბლონები";
            this.DocumentTemplatesTabPage.UseVisualStyleBackColor = true;
            this.DocumentTemplatesTabPage.Enter += new System.EventHandler(this.DocumentTemplatesTabPage_Enter);
            // 
            // DocumentTemplatesGroupBox
            // 
            this.DocumentTemplatesGroupBox.Controls.Add(this.DocumentTemplatesDataGridView);
            this.DocumentTemplatesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentTemplatesGroupBox.Location = new System.Drawing.Point(3, 3);
            this.DocumentTemplatesGroupBox.Name = "DocumentTemplatesGroupBox";
            this.DocumentTemplatesGroupBox.Size = new System.Drawing.Size(486, 322);
            this.DocumentTemplatesGroupBox.TabIndex = 8;
            this.DocumentTemplatesGroupBox.TabStop = false;
            this.DocumentTemplatesGroupBox.Text = "დოკუმენტების შაბლონების სია";
            // 
            // DocumentTemplatesDataGridView
            // 
            this.DocumentTemplatesDataGridView.AllowUserToAddRows = false;
            this.DocumentTemplatesDataGridView.AllowUserToDeleteRows = false;
            this.DocumentTemplatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocumentTemplatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentTemplateTitleDescription});
            this.DocumentTemplatesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentTemplatesDataGridView.Location = new System.Drawing.Point(3, 16);
            this.DocumentTemplatesDataGridView.Name = "DocumentTemplatesDataGridView";
            this.DocumentTemplatesDataGridView.ReadOnly = true;
            this.DocumentTemplatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DocumentTemplatesDataGridView.Size = new System.Drawing.Size(480, 303);
            this.DocumentTemplatesDataGridView.TabIndex = 154;
            this.DocumentTemplatesDataGridView.Tag = "129";
            // 
            // DocumentTemplateTitleDescription
            // 
            this.DocumentTemplateTitleDescription.DataPropertyName = "DocumentTemplateTitleDescription";
            this.DocumentTemplateTitleDescription.HeaderText = "დოკუმენტის შაბლონი";
            this.DocumentTemplateTitleDescription.Name = "DocumentTemplateTitleDescription";
            this.DocumentTemplateTitleDescription.ReadOnly = true;
            this.DocumentTemplateTitleDescription.Width = 500;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DocumentTemplateDeleteButton);
            this.groupBox1.Controls.Add(this.DocumentTemplateEditButton);
            this.groupBox1.Controls.Add(this.DocumentTemplateAddButton);
            this.groupBox1.Controls.Add(this.DocumentTemplateViewButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(489, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 322);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "129";
            this.groupBox1.Text = "მოქმედებები";
            // 
            // DocumentTemplateDeleteButton
            // 
            this.DocumentTemplateDeleteButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocumentTemplateDeleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentTemplateDeleteButton.Location = new System.Drawing.Point(3, 121);
            this.DocumentTemplateDeleteButton.Margin = new System.Windows.Forms.Padding(4);
            this.DocumentTemplateDeleteButton.Name = "DocumentTemplateDeleteButton";
            this.DocumentTemplateDeleteButton.Size = new System.Drawing.Size(117, 35);
            this.DocumentTemplateDeleteButton.TabIndex = 14;
            this.DocumentTemplateDeleteButton.Tag = "132";
            this.DocumentTemplateDeleteButton.Text = "წაშლა";
            this.DocumentTemplateDeleteButton.UseVisualStyleBackColor = true;
            this.DocumentTemplateDeleteButton.Click += new System.EventHandler(this.DocumentTemplateDeleteButton_Click);
            // 
            // DocumentTemplateEditButton
            // 
            this.DocumentTemplateEditButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocumentTemplateEditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentTemplateEditButton.Location = new System.Drawing.Point(3, 86);
            this.DocumentTemplateEditButton.Margin = new System.Windows.Forms.Padding(4);
            this.DocumentTemplateEditButton.Name = "DocumentTemplateEditButton";
            this.DocumentTemplateEditButton.Size = new System.Drawing.Size(117, 35);
            this.DocumentTemplateEditButton.TabIndex = 13;
            this.DocumentTemplateEditButton.Tag = "131";
            this.DocumentTemplateEditButton.Text = "შეცვლა";
            this.DocumentTemplateEditButton.UseVisualStyleBackColor = true;
            this.DocumentTemplateEditButton.Click += new System.EventHandler(this.DocumentTemplateEditButton_Click);
            // 
            // DocumentTemplateAddButton
            // 
            this.DocumentTemplateAddButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocumentTemplateAddButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentTemplateAddButton.Location = new System.Drawing.Point(3, 51);
            this.DocumentTemplateAddButton.Margin = new System.Windows.Forms.Padding(4);
            this.DocumentTemplateAddButton.Name = "DocumentTemplateAddButton";
            this.DocumentTemplateAddButton.Size = new System.Drawing.Size(117, 35);
            this.DocumentTemplateAddButton.TabIndex = 10;
            this.DocumentTemplateAddButton.Tag = "130";
            this.DocumentTemplateAddButton.Text = "დამატება";
            this.DocumentTemplateAddButton.UseVisualStyleBackColor = true;
            this.DocumentTemplateAddButton.Click += new System.EventHandler(this.DocumentTemplateAddButton_Click);
            // 
            // DocumentTemplateViewButton
            // 
            this.DocumentTemplateViewButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.DocumentTemplateViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentTemplateViewButton.Location = new System.Drawing.Point(3, 16);
            this.DocumentTemplateViewButton.Margin = new System.Windows.Forms.Padding(4);
            this.DocumentTemplateViewButton.Name = "DocumentTemplateViewButton";
            this.DocumentTemplateViewButton.Size = new System.Drawing.Size(117, 35);
            this.DocumentTemplateViewButton.TabIndex = 9;
            this.DocumentTemplateViewButton.Tag = "129";
            this.DocumentTemplateViewButton.Text = "ნახვა";
            this.DocumentTemplateViewButton.UseVisualStyleBackColor = true;
            this.DocumentTemplateViewButton.Click += new System.EventHandler(this.DocumentTemplateViewButton_Click);
            // 
            // TemplatesMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 354);
            this.Controls.Add(this.TemplatesTabControl);
            this.Name = "TemplatesMainForm";
            this.Text = "TemplatesMainForm";
            this.TemplatesTabControl.ResumeLayout(false);
            this.DocumentTemplatesTabPage.ResumeLayout(false);
            this.DocumentTemplatesGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTemplatesDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TemplatesTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage DocumentTemplatesTabPage;
        private System.Windows.Forms.GroupBox DocumentTemplatesGroupBox;
        private System.Windows.Forms.DataGridView DocumentTemplatesDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentTemplateTitleDescription;
        private System.Windows.Forms.Button DocumentTemplateAddButton;
        private System.Windows.Forms.Button DocumentTemplateViewButton;
        private System.Windows.Forms.Button DocumentTemplateDeleteButton;
        private System.Windows.Forms.Button DocumentTemplateEditButton;
    }
}