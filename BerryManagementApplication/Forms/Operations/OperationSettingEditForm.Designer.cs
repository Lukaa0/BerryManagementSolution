namespace BerryManagementApplication.Forms.Operations
{
    partial class OperationSettingEditForm
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
            this.OperationSettingValueTextBox = new System.Windows.Forms.TextBox();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OperationSettingValueTextBox
            // 
            this.OperationSettingValueTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OperationSettingValueTextBox.Location = new System.Drawing.Point(172, 145);
            this.OperationSettingValueTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.OperationSettingValueTextBox.Name = "OperationSettingValueTextBox";
            this.OperationSettingValueTextBox.Size = new System.Drawing.Size(225, 26);
            this.OperationSettingValueTextBox.TabIndex = 45;
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(114, 206);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(125, 36);
            this.CommitButton.TabIndex = 47;
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(272, 206);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 48;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DescriptionLabel.Location = new System.Drawing.Point(35, 11);
            this.DescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(336, 112);
            this.DescriptionLabel.TabIndex = 50;
            this.DescriptionLabel.Text = "label2";
            this.DescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "მნიშვნელობა";
            // 
            // OperationSettingEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(453, 271);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.OperationSettingValueTextBox);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "OperationSettingEditForm";
            this.Text = "კონფიგურაციის შეცვლა";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OperationSettingValueTextBox;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label label1;
    }
}