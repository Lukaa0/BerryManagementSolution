namespace BerryManagementApplication.Forms.Template
{
    partial class DocumentTemplateEditForm
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
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.DocumentTemplateNameTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RollbackButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.FileLoadButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileNameLabel.Location = new System.Drawing.Point(170, 62);
            this.FileNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(494, 54);
            this.FileNameLabel.TabIndex = 26;
            // 
            // DocumentTemplateNameTextbox
            // 
            this.DocumentTemplateNameTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentTemplateNameTextbox.Location = new System.Drawing.Point(170, 23);
            this.DocumentTemplateNameTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.DocumentTemplateNameTextbox.Name = "DocumentTemplateNameTextbox";
            this.DocumentTemplateNameTextbox.Size = new System.Drawing.Size(494, 22);
            this.DocumentTemplateNameTextbox.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 26);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "შაბლონის დასახელება";
            // 
            // RollbackButton
            // 
            this.RollbackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RollbackButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RollbackButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RollbackButton.Location = new System.Drawing.Point(564, 130);
            this.RollbackButton.Margin = new System.Windows.Forms.Padding(4);
            this.RollbackButton.Name = "RollbackButton";
            this.RollbackButton.Size = new System.Drawing.Size(100, 33);
            this.RollbackButton.TabIndex = 3;
            this.RollbackButton.Text = "Cancel";
            this.RollbackButton.UseVisualStyleBackColor = true;
            this.RollbackButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(456, 130);
            this.OKButton.Margin = new System.Windows.Forms.Padding(4);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(100, 33);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // FileLoadButton
            // 
            this.FileLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.FileLoadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileLoadButton.Location = new System.Drawing.Point(11, 62);
            this.FileLoadButton.Margin = new System.Windows.Forms.Padding(4);
            this.FileLoadButton.Name = "FileLoadButton";
            this.FileLoadButton.Size = new System.Drawing.Size(148, 33);
            this.FileLoadButton.TabIndex = 27;
            this.FileLoadButton.Text = "ფაილის არჩევა";
            this.FileLoadButton.UseVisualStyleBackColor = true;
            this.FileLoadButton.Click += new System.EventHandler(this.FileLoadButton_Click);
            // 
            // DocumentTemplateEditForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.RollbackButton;
            this.ClientSize = new System.Drawing.Size(680, 178);
            this.Controls.Add(this.FileLoadButton);
            this.Controls.Add(this.FileNameLabel);
            this.Controls.Add(this.DocumentTemplateNameTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RollbackButton);
            this.Controls.Add(this.OKButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DocumentTemplateEditForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "როლის დამატება/შეცვლა";
            this.Load += new System.EventHandler(this.AddEditDocumentTemplate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.TextBox DocumentTemplateNameTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button RollbackButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button FileLoadButton;
    }
}