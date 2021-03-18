namespace BerryManagementApplication.Forms.Employee
{
    partial class VerifyPersonalNumber
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
            this.EmployeeSearchMainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.VerifyExitpanel = new System.Windows.Forms.Panel();
            this.CancButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.VerifyPersonalNumberPanel = new System.Windows.Forms.Panel();
            this.VerifyGroupBox = new System.Windows.Forms.GroupBox();
            this.VerifyValueTextBox = new System.Windows.Forms.TextBox();
            this.EmployeeSearchMainTableLayoutPanel.SuspendLayout();
            this.VerifyExitpanel.SuspendLayout();
            this.VerifyPersonalNumberPanel.SuspendLayout();
            this.VerifyGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EmployeeSearchMainTableLayoutPanel
            // 
            this.EmployeeSearchMainTableLayoutPanel.ColumnCount = 1;
            this.EmployeeSearchMainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EmployeeSearchMainTableLayoutPanel.Controls.Add(this.VerifyExitpanel, 0, 1);
            this.EmployeeSearchMainTableLayoutPanel.Controls.Add(this.VerifyPersonalNumberPanel, 0, 0);
            this.EmployeeSearchMainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeeSearchMainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.EmployeeSearchMainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(5);
            this.EmployeeSearchMainTableLayoutPanel.Name = "EmployeeSearchMainTableLayoutPanel";
            this.EmployeeSearchMainTableLayoutPanel.RowCount = 2;
            this.EmployeeSearchMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.EmployeeSearchMainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.EmployeeSearchMainTableLayoutPanel.Size = new System.Drawing.Size(355, 137);
            this.EmployeeSearchMainTableLayoutPanel.TabIndex = 2;
            this.EmployeeSearchMainTableLayoutPanel.Tag = "-1";
            // 
            // VerifyExitpanel
            // 
            this.VerifyExitpanel.Controls.Add(this.CancButton);
            this.VerifyExitpanel.Controls.Add(this.OkButton);
            this.VerifyExitpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerifyExitpanel.Location = new System.Drawing.Point(5, 72);
            this.VerifyExitpanel.Margin = new System.Windows.Forms.Padding(5);
            this.VerifyExitpanel.Name = "VerifyExitpanel";
            this.VerifyExitpanel.Size = new System.Drawing.Size(345, 60);
            this.VerifyExitpanel.TabIndex = 1;
            this.VerifyExitpanel.Tag = "-1";
            // 
            // CancButton
            // 
            this.CancButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Location = new System.Drawing.Point(198, 12);
            this.CancButton.Margin = new System.Windows.Forms.Padding(4);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(133, 34);
            this.CancButton.TabIndex = 7;
            this.CancButton.Tag = "-1";
            this.CancButton.Text = "გაუქმება";
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Location = new System.Drawing.Point(32, 12);
            this.OkButton.Margin = new System.Windows.Forms.Padding(4);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(133, 34);
            this.OkButton.TabIndex = 6;
            this.OkButton.Tag = "-1";
            this.OkButton.Text = "დასტური";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // VerifyPersonalNumberPanel
            // 
            this.VerifyPersonalNumberPanel.AutoScroll = true;
            this.VerifyPersonalNumberPanel.Controls.Add(this.VerifyGroupBox);
            this.VerifyPersonalNumberPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerifyPersonalNumberPanel.Location = new System.Drawing.Point(5, 5);
            this.VerifyPersonalNumberPanel.Margin = new System.Windows.Forms.Padding(5);
            this.VerifyPersonalNumberPanel.Name = "VerifyPersonalNumberPanel";
            this.VerifyPersonalNumberPanel.Size = new System.Drawing.Size(345, 57);
            this.VerifyPersonalNumberPanel.TabIndex = 2;
            this.VerifyPersonalNumberPanel.Tag = "-1";
            // 
            // VerifyGroupBox
            // 
            this.VerifyGroupBox.Controls.Add(this.VerifyValueTextBox);
            this.VerifyGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VerifyGroupBox.Location = new System.Drawing.Point(0, 0);
            this.VerifyGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.VerifyGroupBox.Name = "VerifyGroupBox";
            this.VerifyGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.VerifyGroupBox.Size = new System.Drawing.Size(345, 57);
            this.VerifyGroupBox.TabIndex = 5;
            this.VerifyGroupBox.TabStop = false;
            this.VerifyGroupBox.Tag = "-1";
            this.VerifyGroupBox.Text = "შეიყვანეთ პირადი ნომერი";
            // 
            // VerifyValueTextBox
            // 
            this.VerifyValueTextBox.Location = new System.Drawing.Point(13, 25);
            this.VerifyValueTextBox.Margin = new System.Windows.Forms.Padding(5);
            this.VerifyValueTextBox.Name = "VerifyValueTextBox";
            this.VerifyValueTextBox.Size = new System.Drawing.Size(300, 22);
            this.VerifyValueTextBox.TabIndex = 0;
            this.VerifyValueTextBox.Tag = "-1";
            // 
            // VerifyPersonalNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 137);
            this.Controls.Add(this.EmployeeSearchMainTableLayoutPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VerifyPersonalNumber";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VerifyPersonalNumber";
            this.Activated += new System.EventHandler(this.VerifyPersonalNumber_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VerifyPersonalNumber_FormClosing);
            this.EmployeeSearchMainTableLayoutPanel.ResumeLayout(false);
            this.VerifyExitpanel.ResumeLayout(false);
            this.VerifyPersonalNumberPanel.ResumeLayout(false);
            this.VerifyGroupBox.ResumeLayout(false);
            this.VerifyGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel EmployeeSearchMainTableLayoutPanel;
        private System.Windows.Forms.Panel VerifyExitpanel;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel VerifyPersonalNumberPanel;
        private System.Windows.Forms.GroupBox VerifyGroupBox;
        private System.Windows.Forms.TextBox VerifyValueTextBox;
    }
}