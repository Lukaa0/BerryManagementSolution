namespace BerryManagementApplication.Forms.Accounts
{
    partial class WaybillForm
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
            this.DateComboBox = new System.Windows.Forms.ComboBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DateComboBox
            // 
            this.DateComboBox.FormattingEnabled = true;
            this.DateComboBox.Location = new System.Drawing.Point(553, 12);
            this.DateComboBox.Name = "DateComboBox";
            this.DateComboBox.Size = new System.Drawing.Size(208, 24);
            this.DateComboBox.TabIndex = 0;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(82, 65);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(150, 22);
            this.IDTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "ზედნადების N                           ";
            // 
            // WaybillForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.DateComboBox);
            this.Name = "WaybillForm";
            this.Text = "WaybillForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox DateComboBox;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.Label label1;
    }
}