namespace BerryManagementApplication.Forms.Operations
{
    partial class BerryProducePrintForm
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
            this.StartdateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.EnddateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SugarCheckBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SugarNumericUpDownEnd = new System.Windows.Forms.NumericUpDown();
            this.SugarNumericUpDownStart = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PersonPostEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DeFilterButton = new System.Windows.Forms.Button();
            this.FilterButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PrintPropertiesGridView = new ThetaControlsLibrary.DataGridViewEI();
            this.BreedProperty_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedProperty_Breed_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedProperty_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedProperty_Density = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedProperty_Sugar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BreedProperty_Breed_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SugarNumericUpDownEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SugarNumericUpDownStart)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PrintPropertiesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // StartdateTimePicker1
            // 
            this.StartdateTimePicker1.Location = new System.Drawing.Point(145, 65);
            this.StartdateTimePicker1.Name = "StartdateTimePicker1";
            this.StartdateTimePicker1.Size = new System.Drawing.Size(328, 22);
            this.StartdateTimePicker1.TabIndex = 0;
            // 
            // EnddateTimePicker2
            // 
            this.EnddateTimePicker2.Location = new System.Drawing.Point(145, 116);
            this.EnddateTimePicker2.Name = "EnddateTimePicker2";
            this.EnddateTimePicker2.Size = new System.Drawing.Size(328, 22);
            this.EnddateTimePicker2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "საწყისი";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.DeFilterButton);
            this.groupBox1.Controls.Add(this.FilterButton);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1018, 283);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ფილტრაცია";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SugarCheckBox);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.SugarNumericUpDownEnd);
            this.groupBox4.Controls.Add(this.SugarNumericUpDownStart);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(517, 21);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(489, 158);
            this.groupBox4.TabIndex = 98;
            this.groupBox4.TabStop = false;
            // 
            // SugarCheckBox
            // 
            this.SugarCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SugarCheckBox.Location = new System.Drawing.Point(7, 22);
            this.SugarCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SugarCheckBox.Name = "SugarCheckBox";
            this.SugarCheckBox.Size = new System.Drawing.Size(196, 23);
            this.SugarCheckBox.TabIndex = 98;
            this.SugarCheckBox.Tag = "-1";
            this.SugarCheckBox.Text = "შაქრის პროცენტულობა";
            this.SugarCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SugarCheckBox.UseVisualStyleBackColor = true;
            this.SugarCheckBox.CheckedChanged += new System.EventHandler(this.SugarCheckBox_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "საბოლოო";
            // 
            // SugarNumericUpDownEnd
            // 
            this.SugarNumericUpDownEnd.Location = new System.Drawing.Point(145, 111);
            this.SugarNumericUpDownEnd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SugarNumericUpDownEnd.Name = "SugarNumericUpDownEnd";
            this.SugarNumericUpDownEnd.Size = new System.Drawing.Size(328, 22);
            this.SugarNumericUpDownEnd.TabIndex = 96;
            // 
            // SugarNumericUpDownStart
            // 
            this.SugarNumericUpDownStart.Location = new System.Drawing.Point(145, 65);
            this.SugarNumericUpDownStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SugarNumericUpDownStart.Name = "SugarNumericUpDownStart";
            this.SugarNumericUpDownStart.Size = new System.Drawing.Size(328, 22);
            this.SugarNumericUpDownStart.TabIndex = 94;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 67);
            this.label3.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 17);
            this.label3.TabIndex = 93;
            this.label3.Text = "საწყისი";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PersonPostEndDateTitleCheckBox);
            this.groupBox3.Controls.Add(this.StartdateTimePicker1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.EnddateTimePicker2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(10, 21);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(489, 158);
            this.groupBox3.TabIndex = 97;
            this.groupBox3.TabStop = false;
            // 
            // PersonPostEndDateTitleCheckBox
            // 
            this.PersonPostEndDateTitleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.Location = new System.Drawing.Point(7, 22);
            this.PersonPostEndDateTitleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostEndDateTitleCheckBox.Name = "PersonPostEndDateTitleCheckBox";
            this.PersonPostEndDateTitleCheckBox.Size = new System.Drawing.Size(98, 23);
            this.PersonPostEndDateTitleCheckBox.TabIndex = 98;
            this.PersonPostEndDateTitleCheckBox.Tag = "-1";
            this.PersonPostEndDateTitleCheckBox.Text = "თარიღი";
            this.PersonPostEndDateTitleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.UseVisualStyleBackColor = true;
            this.PersonPostEndDateTitleCheckBox.CheckedChanged += new System.EventHandler(this.PersonPostEndDateTitleCheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "საბოლოო";
            // 
            // DeFilterButton
            // 
            this.DeFilterButton.Location = new System.Drawing.Point(761, 214);
            this.DeFilterButton.Name = "DeFilterButton";
            this.DeFilterButton.Size = new System.Drawing.Size(136, 45);
            this.DeFilterButton.TabIndex = 5;
            this.DeFilterButton.Text = "ფილტრის მოხსნა";
            this.DeFilterButton.UseVisualStyleBackColor = true;
            this.DeFilterButton.Click += new System.EventHandler(this.DeFilterButton_Click);
            // 
            // FilterButton
            // 
            this.FilterButton.Location = new System.Drawing.Point(584, 214);
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(136, 45);
            this.FilterButton.TabIndex = 4;
            this.FilterButton.Text = "გაფილტვრა";
            this.FilterButton.UseVisualStyleBackColor = true;
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PrintPropertiesGridView);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1018, 288);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // PrintPropertiesGridView
            // 
            this.PrintPropertiesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PrintPropertiesGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BreedProperty_Id,
            this.BreedProperty_Breed_Name,
            this.BreedProperty_DateTime,
            this.BreedProperty_Density,
            this.BreedProperty_Sugar,
            this.BreedProperty_Breed_Id});
            this.PrintPropertiesGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PrintPropertiesGridView.Location = new System.Drawing.Point(3, 18);
            this.PrintPropertiesGridView.Name = "PrintPropertiesGridView";
            this.PrintPropertiesGridView.RowTemplate.Height = 24;
            this.PrintPropertiesGridView.Size = new System.Drawing.Size(1012, 267);
            this.PrintPropertiesGridView.TabIndex = 1;
            // 
            // BreedProperty_Id
            // 
            this.BreedProperty_Id.DataPropertyName = "BreedProperty_Id";
            this.BreedProperty_Id.HeaderText = "BreedProperty_Id";
            this.BreedProperty_Id.Name = "BreedProperty_Id";
            this.BreedProperty_Id.Visible = false;
            // 
            // BreedProperty_Breed_Name
            // 
            this.BreedProperty_Breed_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreedProperty_Breed_Name.DataPropertyName = "BreedProperty_Breed_Name";
            this.BreedProperty_Breed_Name.HeaderText = "ჯიშის სახელი";
            this.BreedProperty_Breed_Name.Name = "BreedProperty_Breed_Name";
            // 
            // BreedProperty_DateTime
            // 
            this.BreedProperty_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreedProperty_DateTime.DataPropertyName = "BreedProperty_DateTime";
            this.BreedProperty_DateTime.HeaderText = "თარიღი";
            this.BreedProperty_DateTime.Name = "BreedProperty_DateTime";
            // 
            // BreedProperty_Density
            // 
            this.BreedProperty_Density.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreedProperty_Density.DataPropertyName = "BreedProperty_Density";
            this.BreedProperty_Density.HeaderText = "სიმკრივე";
            this.BreedProperty_Density.Name = "BreedProperty_Density";
            // 
            // BreedProperty_Sugar
            // 
            this.BreedProperty_Sugar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BreedProperty_Sugar.DataPropertyName = "BreedProperty_Sugar";
            this.BreedProperty_Sugar.HeaderText = "შაქრის პროცენტულობა";
            this.BreedProperty_Sugar.Name = "BreedProperty_Sugar";
            // 
            // BreedProperty_Breed_Id
            // 
            this.BreedProperty_Breed_Id.DataPropertyName = "BreedProperty_Breed_Id";
            this.BreedProperty_Breed_Id.HeaderText = "BreedProperty_Breed_Id";
            this.BreedProperty_Breed_Id.Name = "BreedProperty_Breed_Id";
            this.BreedProperty_Breed_Id.Visible = false;
            // 
            // BerryProducePrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 571);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BerryProducePrintForm";
            this.Text = "რიგის მონაცემების ფილტრაცია";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SugarNumericUpDownEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SugarNumericUpDownStart)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PrintPropertiesGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartdateTimePicker1;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button DeFilterButton;
        private System.Windows.Forms.Button FilterButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown SugarNumericUpDownEnd;
        private System.Windows.Forms.NumericUpDown SugarNumericUpDownStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox PersonPostEndDateTitleCheckBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox SugarCheckBox;
        private System.Windows.Forms.Label label6;
        private ThetaControlsLibrary.DataGridViewEI PrintPropertiesGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_Breed_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_DateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_Density;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_Sugar;
        private System.Windows.Forms.DataGridViewTextBoxColumn BreedProperty_Breed_Id;
    }
}