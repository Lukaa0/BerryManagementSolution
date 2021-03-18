namespace BerryManagementApplication.Forms.Structure
{
    partial class PointEditForm
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
            this.CarComboBox = new System.Windows.Forms.ComboBox();
            this.AdresTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.RowNumberLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SectroNumberLabel = new System.Windows.Forms.Label();
            this.SubrowLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.isActive = new System.Windows.Forms.CheckBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PointTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CarCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(161, 274);
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
            this.RollbackButton.Location = new System.Drawing.Point(328, 274);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // CarComboBox
            // 
            this.CarComboBox.FormattingEnabled = true;
            this.CarComboBox.Location = new System.Drawing.Point(125, 102);
            this.CarComboBox.Name = "CarComboBox";
            this.CarComboBox.Size = new System.Drawing.Size(328, 24);
            this.CarComboBox.TabIndex = 64;
            // 
            // AdresTextBox
            // 
            this.AdresTextBox.Location = new System.Drawing.Point(125, 145);
            this.AdresTextBox.Name = "AdresTextBox";
            this.AdresTextBox.Size = new System.Drawing.Size(328, 22);
            this.AdresTextBox.TabIndex = 84;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(125, 17);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(328, 22);
            this.NameTextBox.TabIndex = 82;
            // 
            // RowNumberLabel
            // 
            this.RowNumberLabel.AutoSize = true;
            this.RowNumberLabel.Location = new System.Drawing.Point(33, 60);
            this.RowNumberLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RowNumberLabel.Name = "RowNumberLabel";
            this.RowNumberLabel.Size = new System.Drawing.Size(74, 17);
            this.RowNumberLabel.TabIndex = 80;
            this.RowNumberLabel.Text = "პრეფიქსი";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(460, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 79;
            this.label4.Text = "*";
            // 
            // SectroNumberLabel
            // 
            this.SectroNumberLabel.AutoSize = true;
            this.SectroNumberLabel.Location = new System.Drawing.Point(12, 20);
            this.SectroNumberLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SectroNumberLabel.Name = "SectroNumberLabel";
            this.SectroNumberLabel.Size = new System.Drawing.Size(95, 17);
            this.SectroNumberLabel.TabIndex = 78;
            this.SectroNumberLabel.Text = "დასახელება";
            // 
            // SubrowLabel
            // 
            this.SubrowLabel.AutoSize = true;
            this.SubrowLabel.Location = new System.Drawing.Point(22, 148);
            this.SubrowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SubrowLabel.Name = "SubrowLabel";
            this.SubrowLabel.Size = new System.Drawing.Size(85, 17);
            this.SubrowLabel.TabIndex = 77;
            this.SubrowLabel.Text = "მისამართი";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(460, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 38);
            this.label3.TabIndex = 76;
            this.label3.Text = "*";
            // 
            // isActive
            // 
            this.isActive.AutoSize = true;
            this.isActive.Location = new System.Drawing.Point(356, 227);
            this.isActive.Name = "isActive";
            this.isActive.Size = new System.Drawing.Size(97, 21);
            this.isActive.TabIndex = 85;
            this.isActive.Text = "აქტიურია";
            this.isActive.UseVisualStyleBackColor = true;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(125, 186);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(328, 22);
            this.DescriptionTextBox.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 186);
            this.label5.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 17);
            this.label5.TabIndex = 87;
            this.label5.Text = "აღწერა";
            // 
            // PointTypeComboBox
            // 
            this.PointTypeComboBox.FormattingEnabled = true;
            this.PointTypeComboBox.Location = new System.Drawing.Point(125, 57);
            this.PointTypeComboBox.Name = "PointTypeComboBox";
            this.PointTypeComboBox.Size = new System.Drawing.Size(328, 24);
            this.PointTypeComboBox.TabIndex = 89;
            // 
            // CarCheckBox
            // 
            this.CarCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CarCheckBox.Location = new System.Drawing.Point(-42, 103);
            this.CarCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.CarCheckBox.Name = "CarCheckBox";
            this.CarCheckBox.Size = new System.Drawing.Size(149, 23);
            this.CarCheckBox.TabIndex = 90;
            this.CarCheckBox.Tag = "-1";
            this.CarCheckBox.Text = "მანქანა";
            this.CarCheckBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CarCheckBox.UseVisualStyleBackColor = true;
            this.CarCheckBox.CheckedChanged += new System.EventHandler(this.CarCheckBox_CheckedChanged);
            // 
            // PointEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 333);
            this.Controls.Add(this.CarCheckBox);
            this.Controls.Add(this.PointTypeComboBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.isActive);
            this.Controls.Add(this.AdresTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.RowNumberLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SectroNumberLabel);
            this.Controls.Add(this.SubrowLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CarComboBox);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PointEditForm_FormClosing);
            this.Load += new System.EventHandler(this.RowBreedEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox CarComboBox;
        private System.Windows.Forms.TextBox AdresTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label RowNumberLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SectroNumberLabel;
        private System.Windows.Forms.Label SubrowLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox isActive;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox PointTypeComboBox;
        private System.Windows.Forms.CheckBox CarCheckBox;
    }
}