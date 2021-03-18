namespace BerryManagementApplication.Forms.Report
{
    partial class TemplatesViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TemplatesViewerForm));
            this.DocumentTemplatesDataGridView = new System.Windows.Forms.DataGridView();
            this.DocumentTemplateTitleDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTemplatesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DocumentTemplatesDataGridView
            // 
            this.DocumentTemplatesDataGridView.AllowUserToAddRows = false;
            this.DocumentTemplatesDataGridView.AllowUserToDeleteRows = false;
            this.DocumentTemplatesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DocumentTemplatesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentTemplateTitleDescription});
            this.DocumentTemplatesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DocumentTemplatesDataGridView.Location = new System.Drawing.Point(0, 0);
            this.DocumentTemplatesDataGridView.Name = "DocumentTemplatesDataGridView";
            this.DocumentTemplatesDataGridView.ReadOnly = true;
            this.DocumentTemplatesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DocumentTemplatesDataGridView.Size = new System.Drawing.Size(570, 337);
            this.DocumentTemplatesDataGridView.TabIndex = 155;
            this.DocumentTemplatesDataGridView.Tag = "129";
            this.DocumentTemplatesDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DocumentTemplatesDataGridView_CellDoubleClick);
            // 
            // DocumentTemplateTitleDescription
            // 
            this.DocumentTemplateTitleDescription.DataPropertyName = "DocumentTemplateTitleDescription";
            this.DocumentTemplateTitleDescription.HeaderText = "დოკუმენტის შაბლონი";
            this.DocumentTemplateTitleDescription.Name = "DocumentTemplateTitleDescription";
            this.DocumentTemplateTitleDescription.ReadOnly = true;
            this.DocumentTemplateTitleDescription.Width = 500;
            // 
            // TemplatesViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 337);
            this.Controls.Add(this.DocumentTemplatesDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TemplatesViewerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "შაბლონის არჩევა";
            this.Load += new System.EventHandler(this.TemplatesViewerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTemplatesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DocumentTemplatesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentTemplateTitleDescription;
    }
}