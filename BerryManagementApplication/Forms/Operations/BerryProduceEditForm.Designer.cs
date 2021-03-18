namespace BerryManagementApplication.Forms.Operations
{
    partial class BerryProduceEditForm
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
            this.BreedComboBox = new System.Windows.Forms.ComboBox();
            this.BreedLabel = new System.Windows.Forms.Label();
            this.SubrowLabel = new System.Windows.Forms.Label();
            this.DensityTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SugarTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(142, 187);
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
            this.RollbackButton.Location = new System.Drawing.Point(300, 187);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // BreedComboBox
            // 
            this.BreedComboBox.FormattingEnabled = true;
            this.BreedComboBox.Location = new System.Drawing.Point(97, 22);
            this.BreedComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BreedComboBox.Name = "BreedComboBox";
            this.BreedComboBox.Size = new System.Drawing.Size(328, 24);
            this.BreedComboBox.TabIndex = 82;
            this.BreedComboBox.SelectedIndexChanged += new System.EventHandler(this.BreedComboBox_SelectedIndexChanged);
            // 
            // BreedLabel
            // 
            this.BreedLabel.AutoSize = true;
            this.BreedLabel.Location = new System.Drawing.Point(43, 25);
            this.BreedLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BreedLabel.Name = "BreedLabel";
            this.BreedLabel.Size = new System.Drawing.Size(42, 17);
            this.BreedLabel.TabIndex = 81;
            this.BreedLabel.Text = "ჯიში";
            // 
            // SubrowLabel
            // 
            this.SubrowLabel.AutoSize = true;
            this.SubrowLabel.Location = new System.Drawing.Point(16, 121);
            this.SubrowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SubrowLabel.Name = "SubrowLabel";
            this.SubrowLabel.Size = new System.Drawing.Size(69, 17);
            this.SubrowLabel.TabIndex = 62;
            this.SubrowLabel.Text = "სიმკრივე";
            // 
            // DensityTextBox
            // 
            this.DensityTextBox.Location = new System.Drawing.Point(97, 118);
            this.DensityTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DensityTextBox.Name = "DensityTextBox";
            this.DensityTextBox.Size = new System.Drawing.Size(328, 22);
            this.DensityTextBox.TabIndex = 75;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 90;
            this.label1.Text = "შაქარის %";
            // 
            // SugarTextBox
            // 
            this.SugarTextBox.Location = new System.Drawing.Point(97, 71);
            this.SugarTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SugarTextBox.Name = "SugarTextBox";
            this.SugarTextBox.Size = new System.Drawing.Size(328, 22);
            this.SugarTextBox.TabIndex = 91;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(431, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 92;
            this.label4.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(431, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 93;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(431, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 38);
            this.label3.TabIndex = 94;
            this.label3.Text = "*";
            // 
            // BerryProduceEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 238);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SugarTextBox);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.SubrowLabel);
            this.Controls.Add(this.DensityTextBox);
            this.Controls.Add(this.BreedComboBox);
            this.Controls.Add(this.BreedLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BerryProduceEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RowsEditForm_FormClosing);
            this.Load += new System.EventHandler(this.RowEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox BreedComboBox;
        private System.Windows.Forms.Label BreedLabel;
        private System.Windows.Forms.Label SubrowLabel;
        private System.Windows.Forms.TextBox DensityTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SugarTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}