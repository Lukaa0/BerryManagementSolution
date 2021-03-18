namespace BerryManagementApplication.Forms.Structure
{
    partial class CarEditForm
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
            this.CarNumberTextBox = new System.Windows.Forms.TextBox();
            this.CarNumberlabel = new System.Windows.Forms.Label();
            this.CommitButton = new System.Windows.Forms.Button();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.CarModelTextBox = new System.Windows.Forms.TextBox();
            this.CarModelLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CarSideTypeLabel = new System.Windows.Forms.Label();
            this.CarSideTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CarNumberTextBox
            // 
            this.CarNumberTextBox.Location = new System.Drawing.Point(109, 26);
            this.CarNumberTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CarNumberTextBox.Name = "CarNumberTextBox";
            this.CarNumberTextBox.Size = new System.Drawing.Size(328, 22);
            this.CarNumberTextBox.TabIndex = 39;
            // 
            // CarNumberlabel
            // 
            this.CarNumberlabel.AutoSize = true;
            this.CarNumberlabel.Location = new System.Drawing.Point(39, 29);
            this.CarNumberlabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CarNumberlabel.Name = "CarNumberlabel";
            this.CarNumberlabel.Size = new System.Drawing.Size(59, 17);
            this.CarNumberlabel.TabIndex = 44;
            this.CarNumberlabel.Text = "ნომერი";
            // 
            // CommitButton
            // 
            this.CommitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommitButton.Location = new System.Drawing.Point(153, 165);
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
            this.RollbackButton.Location = new System.Drawing.Point(312, 165);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(125, 36);
            this.RollbackButton.TabIndex = 42;
            this.RollbackButton.Text = "გაუქმება";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.RollbackButton_Click);
            // 
            // CarModelTextBox
            // 
            this.CarModelTextBox.Location = new System.Drawing.Point(109, 120);
            this.CarModelTextBox.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.CarModelTextBox.Name = "CarModelTextBox";
            this.CarModelTextBox.Size = new System.Drawing.Size(328, 22);
            this.CarModelTextBox.TabIndex = 40;
            // 
            // CarModelLabel
            // 
            this.CarModelLabel.AutoSize = true;
            this.CarModelLabel.Location = new System.Drawing.Point(29, 125);
            this.CarModelLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CarModelLabel.Name = "CarModelLabel";
            this.CarModelLabel.Size = new System.Drawing.Size(69, 17);
            this.CarModelLabel.TabIndex = 43;
            this.CarModelLabel.Text = "მოდელი";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(447, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 38);
            this.label1.TabIndex = 45;
            this.label1.Text = "*";
            // 
            // CarSideTypeLabel
            // 
            this.CarSideTypeLabel.AutoSize = true;
            this.CarSideTypeLabel.Location = new System.Drawing.Point(18, 78);
            this.CarSideTypeLabel.Margin = new System.Windows.Forms.Padding(7, 0, 7, 0);
            this.CarSideTypeLabel.Name = "CarSideTypeLabel";
            this.CarSideTypeLabel.Size = new System.Drawing.Size(80, 17);
            this.CarSideTypeLabel.TabIndex = 46;
            this.CarSideTypeLabel.Text = "შიდა/გარე";
            // 
            // CarSideTypeComboBox
            // 
            this.CarSideTypeComboBox.FormattingEnabled = true;
            this.CarSideTypeComboBox.Location = new System.Drawing.Point(109, 71);
            this.CarSideTypeComboBox.Name = "CarSideTypeComboBox";
            this.CarSideTypeComboBox.Size = new System.Drawing.Size(328, 24);
            this.CarSideTypeComboBox.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(447, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 38);
            this.label2.TabIndex = 48;
            this.label2.Text = "*";
            // 
            // CarEditForm
            // 
            this.AcceptButton = this.CommitButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 240);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CarSideTypeComboBox);
            this.Controls.Add(this.CarSideTypeLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarNumberTextBox);
            this.Controls.Add(this.CarNumberlabel);
            this.Controls.Add(this.CommitButton);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.CarModelTextBox);
            this.Controls.Add(this.CarModelLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CarEditForm";
            this.Text = "ბრიგადა";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CarEditForm_FormClosing);
            this.Load += new System.EventHandler(this.BrigadeEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CarNumberTextBox;
        private System.Windows.Forms.Label CarNumberlabel;
        private System.Windows.Forms.Button CommitButton;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.TextBox CarModelTextBox;
        private System.Windows.Forms.Label CarModelLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CarSideTypeLabel;
        private System.Windows.Forms.ComboBox CarSideTypeComboBox;
        private System.Windows.Forms.Label label2;
    }
}