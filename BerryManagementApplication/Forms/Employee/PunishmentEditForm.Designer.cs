namespace BerryManagementApplication.Forms.Employee
{
    partial class PunishmentEditForm
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
            this.PunishmentComboBox = new System.Windows.Forms.ComboBox();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PunishmentComentTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(238, 183);
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
            this.RollbackButton.Location = new System.Drawing.Point(397, 183);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // PunishmentComboBox
            // 
            this.PunishmentComboBox.FormattingEnabled = true;
            this.PunishmentComboBox.Location = new System.Drawing.Point(175, 61);
            this.PunishmentComboBox.Name = "PunishmentComboBox";
            this.PunishmentComboBox.Size = new System.Drawing.Size(312, 24);
            this.PunishmentComboBox.TabIndex = 64;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Location = new System.Drawing.Point(7, 61);
            this.TypeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(136, 17);
            this.TypeLabel.TabIndex = 63;
            this.TypeLabel.Text = "დანაშაულის ტიპი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(492, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 61;
            this.label1.Text = "*";
            // 
            // PunishmentComentTextBox
            // 
            this.PunishmentComentTextBox.Location = new System.Drawing.Point(175, 113);
            this.PunishmentComentTextBox.Name = "PunishmentComentTextBox";
            this.PunishmentComentTextBox.Size = new System.Drawing.Size(312, 22);
            this.PunishmentComentTextBox.TabIndex = 65;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 118);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "კომენტარი";
            // 
            // PunishmentEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 238);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PunishmentComentTextBox);
            this.Controls.Add(this.PunishmentComboBox);
            this.Controls.Add(this.TypeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PunishmentEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PunishmentEditForm_FormClosing);
            this.Load += new System.EventHandler(this.PunishmentEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.ComboBox PunishmentComboBox;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PunishmentComentTextBox;
        private System.Windows.Forms.Label label2;
    }
}