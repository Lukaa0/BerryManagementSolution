namespace BerryManagementApplication.Forms.Structure
{
    partial class RowBreedEditForm
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
            this.label4 = new System.Windows.Forms.Label();
            this.RowComboBox = new System.Windows.Forms.ComboBox();
            this.RowLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartDateLabel = new System.Windows.Forms.Label();
            this.PersonPostEndDateTitleCheckBox = new System.Windows.Forms.CheckBox();
            this.EndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.StartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(195, 198);
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
            this.RollbackButton.Location = new System.Drawing.Point(354, 198);
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
            this.BreedComboBox.Location = new System.Drawing.Point(151, 63);
            this.BreedComboBox.Name = "BreedComboBox";
            this.BreedComboBox.Size = new System.Drawing.Size(328, 24);
            this.BreedComboBox.TabIndex = 67;
            // 
            // BreedLabel
            // 
            this.BreedLabel.AutoSize = true;
            this.BreedLabel.Location = new System.Drawing.Point(94, 66);
            this.BreedLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BreedLabel.Name = "BreedLabel";
            this.BreedLabel.Size = new System.Drawing.Size(42, 17);
            this.BreedLabel.TabIndex = 66;
            this.BreedLabel.Text = "ჯიში";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(485, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 38);
            this.label4.TabIndex = 65;
            this.label4.Text = "*";
            // 
            // RowComboBox
            // 
            this.RowComboBox.FormattingEnabled = true;
            this.RowComboBox.Location = new System.Drawing.Point(151, 18);
            this.RowComboBox.Name = "RowComboBox";
            this.RowComboBox.Size = new System.Drawing.Size(328, 24);
            this.RowComboBox.TabIndex = 64;
            // 
            // RowLabel
            // 
            this.RowLabel.AutoSize = true;
            this.RowLabel.Location = new System.Drawing.Point(94, 21);
            this.RowLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.RowLabel.Name = "RowLabel";
            this.RowLabel.Size = new System.Drawing.Size(42, 17);
            this.RowLabel.TabIndex = 63;
            this.RowLabel.Text = "რიგი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(485, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 61;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(485, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 72;
            this.label2.Text = "*";
            // 
            // StartDateLabel
            // 
            this.StartDateLabel.AutoSize = true;
            this.StartDateLabel.Location = new System.Drawing.Point(2, 108);
            this.StartDateLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.StartDateLabel.Name = "StartDateLabel";
            this.StartDateLabel.Size = new System.Drawing.Size(134, 17);
            this.StartDateLabel.TabIndex = 62;
            this.StartDateLabel.Text = "დაწყების თარიღი";
            // 
            // PersonPostEndDateTitleCheckBox
            // 
            this.PersonPostEndDateTitleCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PersonPostEndDateTitleCheckBox.Location = new System.Drawing.Point(-13, 149);
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
            // EndDateTimePicker
            // 
            this.EndDateTimePicker.Location = new System.Drawing.Point(151, 150);
            this.EndDateTimePicker.Name = "EndDateTimePicker";
            this.EndDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.EndDateTimePicker.TabIndex = 74;
            // 
            // StartDateTimePicker
            // 
            this.StartDateTimePicker.Location = new System.Drawing.Point(151, 108);
            this.StartDateTimePicker.Name = "StartDateTimePicker";
            this.StartDateTimePicker.Size = new System.Drawing.Size(328, 22);
            this.StartDateTimePicker.TabIndex = 71;
            // 
            // RowBreedEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 258);
            this.Controls.Add(this.PersonPostEndDateTitleCheckBox);
            this.Controls.Add(this.EndDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartDateTimePicker);
            this.Controls.Add(this.BreedComboBox);
            this.Controls.Add(this.BreedLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RowComboBox);
            this.Controls.Add(this.RowLabel);
            this.Controls.Add(this.StartDateLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RowBreedEditForm";
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RowBreedEditForm_FormClosing);
            this.Load += new System.EventHandler(this.RowBreedEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox BreedComboBox;
        private System.Windows.Forms.Label BreedLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox RowComboBox;
        private System.Windows.Forms.Label RowLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label StartDateLabel;
        private System.Windows.Forms.CheckBox PersonPostEndDateTitleCheckBox;
        private System.Windows.Forms.DateTimePicker EndDateTimePicker;
        private System.Windows.Forms.DateTimePicker StartDateTimePicker;
    }
}