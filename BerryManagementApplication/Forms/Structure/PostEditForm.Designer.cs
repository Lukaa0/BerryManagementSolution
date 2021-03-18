namespace BerryManagementApplication.Forms.Structure
{
    partial class PostEditForm
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
            this.BalanceSheetTypeComboBox = new System.Windows.Forms.ComboBox();
            this.RowLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PrefixTextBox = new System.Windows.Forms.TextBox();
            this.DescriptionTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RowNumberLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SectroNumberLabel = new System.Windows.Forms.Label();
            this.SubrowLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(223, 201);
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
            this.RollbackButton.Location = new System.Drawing.Point(382, 201);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // BalanceSheetTypeComboBox
            // 
            this.BalanceSheetTypeComboBox.FormattingEnabled = true;
            this.BalanceSheetTypeComboBox.Location = new System.Drawing.Point(178, 145);
            this.BalanceSheetTypeComboBox.Name = "BalanceSheetTypeComboBox";
            this.BalanceSheetTypeComboBox.Size = new System.Drawing.Size(328, 24);
            this.BalanceSheetTypeComboBox.TabIndex = 64;
            // 
            // RowLabel
            // 
            this.RowLabel.AutoSize = true;
            this.RowLabel.Location = new System.Drawing.Point(28, 148);
            this.RowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RowLabel.Name = "RowLabel";
            this.RowLabel.Size = new System.Drawing.Size(96, 17);
            this.RowLabel.TabIndex = 63;
            this.RowLabel.Text = "BalanceSheet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(512, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 61;
            this.label1.Text = "*";
            // 
            // PrefixTextBox
            // 
            this.PrefixTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.PrefixTextBox.Location = new System.Drawing.Point(179, 103);
            this.PrefixTextBox.Name = "PrefixTextBox";
            this.PrefixTextBox.Size = new System.Drawing.Size(328, 22);
            this.PrefixTextBox.TabIndex = 84;
            // 
            // DescriptionTextBox
            // 
            this.DescriptionTextBox.Location = new System.Drawing.Point(179, 59);
            this.DescriptionTextBox.Name = "DescriptionTextBox";
            this.DescriptionTextBox.Size = new System.Drawing.Size(328, 22);
            this.DescriptionTextBox.TabIndex = 83;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(178, 17);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(328, 22);
            this.NameTextBox.TabIndex = 82;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(512, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 81;
            this.label2.Text = "*";
            // 
            // RowNumberLabel
            // 
            this.RowNumberLabel.AutoSize = true;
            this.RowNumberLabel.Location = new System.Drawing.Point(28, 64);
            this.RowNumberLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RowNumberLabel.Name = "RowNumberLabel";
            this.RowNumberLabel.Size = new System.Drawing.Size(56, 17);
            this.RowNumberLabel.TabIndex = 80;
            this.RowNumberLabel.Text = "აღწერა";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(512, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 79;
            this.label4.Text = "*";
            // 
            // SectroNumberLabel
            // 
            this.SectroNumberLabel.AutoSize = true;
            this.SectroNumberLabel.Location = new System.Drawing.Point(16, 20);
            this.SectroNumberLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SectroNumberLabel.Name = "SectroNumberLabel";
            this.SectroNumberLabel.Size = new System.Drawing.Size(95, 17);
            this.SectroNumberLabel.TabIndex = 78;
            this.SectroNumberLabel.Text = "დასახელება";
            // 
            // SubrowLabel
            // 
            this.SubrowLabel.AutoSize = true;
            this.SubrowLabel.Location = new System.Drawing.Point(28, 106);
            this.SubrowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.SubrowLabel.Name = "SubrowLabel";
            this.SubrowLabel.Size = new System.Drawing.Size(74, 17);
            this.SubrowLabel.TabIndex = 77;
            this.SubrowLabel.Text = "პრეფიქსი";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(512, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 38);
            this.label3.TabIndex = 76;
            this.label3.Text = "*";
            // 
            // PostEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(557, 264);
            this.Controls.Add(this.PrefixTextBox);
            this.Controls.Add(this.DescriptionTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RowNumberLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SectroNumberLabel);
            this.Controls.Add(this.SubrowLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BalanceSheetTypeComboBox);
            this.Controls.Add(this.RowLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PostEditForm_FormClosing);
            this.Load += new System.EventHandler(this.RowBreedEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox BalanceSheetTypeComboBox;
        private System.Windows.Forms.Label RowLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PrefixTextBox;
        private System.Windows.Forms.TextBox DescriptionTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RowNumberLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label SectroNumberLabel;
        private System.Windows.Forms.Label SubrowLabel;
        private System.Windows.Forms.Label label3;
    }
}