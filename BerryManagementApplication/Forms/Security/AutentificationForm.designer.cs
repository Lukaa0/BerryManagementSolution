namespace BerryManagementApplication.Forms.Security
{
    partial class AutentificationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutentificationForm));
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(153, 15);
            this.UserNameTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(180, 22);
            this.UserNameTextBox.TabIndex = 1;
            this.UserNameTextBox.Text = "PF-00000000001";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 16);
            this.label4.TabIndex = 38;
            this.label4.Text = "მომხმარებელი";
            // 
            // CommitButton
            // 
            this.CommitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CommitButton.Location = new System.Drawing.Point(84, 91);
            this.CommitButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CommitButton.Name = "CommitButton";
            this.CommitButton.Size = new System.Drawing.Size(105, 35);
            this.CommitButton.TabIndex = 3;
            this.CommitButton.Text = "შესვლა";
            this.CommitButton.UseVisualStyleBackColor = true;
            this.CommitButton.Click += new System.EventHandler(this.CommitButton_Click);
            // 
            // RollbackButton
            // 
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(220, 91);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(105, 34);
            this.RollbackButton.TabIndex = 4;
            this.RollbackButton.Text = "შეეშვი";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(153, 53);
            this.PasswordTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(180, 22);
            this.PasswordTextBox.TabIndex = 2;
            this.PasswordTextBox.Text = "123";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "პაროლი";
            // 
            // AutentificationForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RollbackButton;
            this.ClientSize = new System.Drawing.Size(341, 131);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AutentificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "აუტენტიფიკაცია";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label label2;
    }
}