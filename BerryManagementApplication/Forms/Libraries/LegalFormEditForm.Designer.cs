namespace BerryManagementApplication.Forms.Libraries
{
    partial class LegalFormEditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.LegalFormNameEnTextBox = new System.Windows.Forms.TextBox();
            this.LegalFormNameKaTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 61);
            this.label1.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 56;
            this.label1.Text = "დასახელება (ინგ)";
            // 
            // LegalFormNameEnTextBox
            // 
            this.LegalFormNameEnTextBox.Location = new System.Drawing.Point(148, 59);
            this.LegalFormNameEnTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.LegalFormNameEnTextBox.Name = "LegalFormNameEnTextBox";
            this.LegalFormNameEnTextBox.Size = new System.Drawing.Size(359, 22);
            this.LegalFormNameEnTextBox.TabIndex = 55;
            // 
            // LegalFormNameKaTextBox
            // 
            this.LegalFormNameKaTextBox.Location = new System.Drawing.Point(148, 15);
            this.LegalFormNameKaTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.LegalFormNameKaTextBox.Name = "LegalFormNameKaTextBox";
            this.LegalFormNameKaTextBox.Size = new System.Drawing.Size(359, 22);
            this.LegalFormNameKaTextBox.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 17);
            this.label4.TabIndex = 54;
            this.label4.Text = "დასახელება";
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(177, 103);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(125, 36);
            this.CommitButton.TabIndex = 52;
            this.CommitButton.Text = "დასტური";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(336, 103);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 53;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            // 
            // LegalFormEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 156);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LegalFormNameEnTextBox);
            this.Controls.Add(this.LegalFormNameKaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LegalFormEditForm";
            this.Text = "სამართლებლივი ფორმა";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LegalFormNameEnTextBox;
        private System.Windows.Forms.TextBox LegalFormNameKaTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
    }
}