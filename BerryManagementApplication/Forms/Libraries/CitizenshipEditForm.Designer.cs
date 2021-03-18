namespace BerryManagementApplication.Forms.Libraries
{
    partial class CitizenshipEditForm
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
            this.CitizenshipNameKaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.CitizenshipNameEnTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CitizenshipNameKaTextBox
            // 
            this.CitizenshipNameKaTextBox.Location = new System.Drawing.Point(156, 18);
            this.CitizenshipNameKaTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CitizenshipNameKaTextBox.Name = "CitizenshipNameKaTextBox";
            this.CitizenshipNameKaTextBox.Size = new System.Drawing.Size(359, 22);
            this.CitizenshipNameKaTextBox.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 48;
            this.label4.Text = "დასახელება";
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(185, 106);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(125, 36);
            this.CommitButton.TabIndex = 46;
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(344, 106);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 47;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            // 
            // CitizenshipNameEnTextBox
            // 
            this.CitizenshipNameEnTextBox.Location = new System.Drawing.Point(156, 62);
            this.CitizenshipNameEnTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CitizenshipNameEnTextBox.Name = "CitizenshipNameEnTextBox";
            this.CitizenshipNameEnTextBox.Size = new System.Drawing.Size(359, 22);
            this.CitizenshipNameEnTextBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 50;
            this.label1.Text = "დასახელება (ინგ)";
            // 
            // CitizenshipEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CitizenshipNameEnTextBox);
            this.Controls.Add(this.CitizenshipNameKaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CitizenshipEditForm";
            this.Text = "მოქალაქეობა";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CitizenshipNameKaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.TextBox CitizenshipNameEnTextBox;
        private System.Windows.Forms.Label label1;
    }
}