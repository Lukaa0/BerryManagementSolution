namespace BerryManagementApplication.Forms.Structure
{
    partial class CompanyCarEditForm
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
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.CompanyComboBox = new System.Windows.Forms.ComboBox();
            this.CompanyLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CarComboBox = new System.Windows.Forms.ComboBox();
            this.CarLabel = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PersonPostEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(208, 207);
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
            this.RollbackButton.Location = new System.Drawing.Point(367, 207);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(164, 156);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.EndDateTimePicker.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(498, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 72;
            this.label2.Text = "*";
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(164, 108);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.StartDateTimePicker.TabIndex = 71;
            // 
            // CompanyComboBox
            // 
            this.CompanyComboBox.FormattingEnabled = true;
            this.CompanyComboBox.Location = new System.Drawing.Point(164, 19);
            this.CompanyComboBox.Name = "CompanyComboBox";
            this.CompanyComboBox.Size = new System.Drawing.Size(328, 24);
            this.CompanyComboBox.TabIndex = 67;
            // 
            // CompanyLabel
            // 
            this.CompanyLabel.AutoSize = true;
            this.CompanyLabel.Location = new System.Drawing.Point(71, 26);
            this.CompanyLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CompanyLabel.Name = "CompanyLabel";
            this.CompanyLabel.Size = new System.Drawing.Size(67, 17);
            this.CompanyLabel.TabIndex = 66;
            this.CompanyLabel.Text = "კომპანია";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(498, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 65;
            this.label4.Text = "*";
            // 
            // CarComboBox
            // 
            this.CarComboBox.FormattingEnabled = true;
            this.CarComboBox.Location = new System.Drawing.Point(164, 62);
            this.CarComboBox.Name = "CarComboBox";
            this.CarComboBox.Size = new System.Drawing.Size(328, 24);
            this.CarComboBox.TabIndex = 64;
            // 
            // CarLabel
            // 
            this.CarLabel.AutoSize = true;
            this.CarLabel.Location = new System.Drawing.Point(79, 65);
            this.CarLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CarLabel.Name = "CarLabel";
            this.CarLabel.Size = new System.Drawing.Size(59, 17);
            this.CarLabel.TabIndex = 63;
            this.CarLabel.Text = "მანქანა";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(4, 108);
            this.StartDateLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(134, 17);
            this.StartDateLabel.TabIndex = 62;
            this.StartDateLabel.Text = "დაწყების თარიღი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(498, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 61;
            this.label1.Text = "*";
            // 
            // PersonPostEndDateTitleCheckBox
            // 
            this.PersonPostEndDateTitleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.Location = new System.Drawing.Point(-11, 159);
            this.PersonPostEndDateTitleCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.PersonPostEndDateTitleCheckBox.Name = "PersonPostEndDateTitleCheckBox";
            this.PersonPostEndDateTitleCheckBox.Size = new System.Drawing.Size(149, 23);
            this.PersonPostEndDateTitleCheckBox.TabIndex = 75;
            this.PersonPostEndDateTitleCheckBox.Tag = "-1";
            this.PersonPostEndDateTitleCheckBox.Text = "დასრულების თარიღი";
            this.PersonPostEndDateTitleCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.UseVisualStyleBackColor = true;
            this.PersonPostEndDateTitleCheckBox.CheckedChanged += new System.EventHandler(this.PersonPostEndDateTitleCheckBox_CheckedChanged);
            // 
            // CompanyCarEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 274);
            this.Controls.Add(this.PersonPostEndDateTitleCheckBox);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.CompanyComboBox);
            this.Controls.Add(this.CompanyLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CarComboBox);
            this.Controls.Add(this.CarLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CompanyCarEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CompanyCarEditForm_FormClosing);
            this.Load += new System.EventHandler(this.CompanyCarEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
        private System.Windows.Forms.ComboBox CompanyComboBox;
        private System.Windows.Forms.Label CompanyLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CarComboBox;
        private System.Windows.Forms.Label CarLabel;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PersonPostEndDateTitleCheckBox;
    }
}