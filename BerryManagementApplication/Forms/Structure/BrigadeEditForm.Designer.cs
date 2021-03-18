namespace BerryManagementApplication.Forms.Structure
{
    partial class BrigadeEditForm
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
            this.BrigadeNameTextBox = new System.Windows.Forms.TextBox();
            this.BrigadeNamelabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.brigadeDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.BrigadeDescriptionlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BrigadeNameTextBox
            // 
            this.BrigadeNameTextBox.Location = new System.Drawing.Point(129, 26);
            this.BrigadeNameTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.BrigadeNameTextBox.Name = "BrigadeNameTextBox";
            this.BrigadeNameTextBox.Size = new System.Drawing.Size(328, 22);
            this.BrigadeNameTextBox.TabIndex = 39;
            // 
            // BrigadeNamelabel
            // 
            this.BrigadeNamelabel.AutoSize = true;
            this.BrigadeNamelabel.Location = new System.Drawing.Point(13, 30);
            this.BrigadeNamelabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BrigadeNamelabel.Name = "BrigadeNamelabel";
            this.BrigadeNamelabel.Size = new System.Drawing.Size(95, 17);
            this.BrigadeNamelabel.TabIndex = 44;
            this.BrigadeNamelabel.Text = "დასახელება";
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(173, 123);
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
            this.RollbackButton.Location = new System.Drawing.Point(332, 123);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // brigadeDescriptionTextBox
            // 
            this.brigadeDescriptionTextBox.Location = new System.Drawing.Point(129, 71);
            this.brigadeDescriptionTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.brigadeDescriptionTextBox.Name = "brigadeDescriptionTextBox";
            this.brigadeDescriptionTextBox.Size = new System.Drawing.Size(328, 22);
            this.brigadeDescriptionTextBox.TabIndex = 40;
            // 
            // BrigadeDescriptionlabel
            // 
            this.BrigadeDescriptionlabel.AutoSize = true;
            this.BrigadeDescriptionlabel.Location = new System.Drawing.Point(52, 74);
            this.BrigadeDescriptionlabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.BrigadeDescriptionlabel.Name = "BrigadeDescriptionlabel";
            this.BrigadeDescriptionlabel.Size = new System.Drawing.Size(56, 17);
            this.BrigadeDescriptionlabel.TabIndex = 43;
            this.BrigadeDescriptionlabel.Text = "აღწერა";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(467, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 45;
            this.label1.Text = "*";
            // 
            // BrigadeEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 183);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BrigadeNameTextBox);
            this.Controls.Add(this.BrigadeNamelabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.brigadeDescriptionTextBox);
            this.Controls.Add(this.BrigadeDescriptionlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BrigadeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ჯგუფი";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BrigadeEditForm_FormClosing);
            this.Load += new System.EventHandler(this.BrigadeEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox BrigadeNameTextBox;
        private System.Windows.Forms.Label BrigadeNamelabel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.TextBox brigadeDescriptionTextBox;
        private System.Windows.Forms.Label BrigadeDescriptionlabel;
        private System.Windows.Forms.Label label1;
    }
}