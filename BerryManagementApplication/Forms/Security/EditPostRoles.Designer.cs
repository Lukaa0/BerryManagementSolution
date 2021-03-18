namespace BerryManagementApplication.Forms.Security
{
    partial class EditPostRoles
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.PostIdDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StartdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EnddateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.RoleIdDataGridView = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostIdDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleIdDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.Controls.Add(this.PostIdDataGridView, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.StartdateTimePicker, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.EnddateTimePicker, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.RoleIdDataGridView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.EditButton, 3, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 166F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1116, 442);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // PostIdDataGridView
            // 
            this.PostIdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PostIdDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PostIdDataGridView.Location = new System.Drawing.Point(483, 23);
            this.PostIdDataGridView.Name = "PostIdDataGridView";
            this.PostIdDataGridView.RowTemplate.Height = 24;
            this.PostIdDataGridView.Size = new System.Drawing.Size(609, 154);
            this.PostIdDataGridView.TabIndex = 1;
            this.PostIdDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PostCellName);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(23, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(404, 60);
            this.label1.TabIndex = 2;
            this.label1.Text = "დაწყების თარიღი";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(23, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 60);
            this.label2.TabIndex = 3;
            this.label2.Text = "დასრულების თარიღი";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartdateTimePicker
            // 
            this.StartdateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StartdateTimePicker.Location = new System.Drawing.Point(483, 219);
            this.StartdateTimePicker.Margin = new System.Windows.Forms.Padding(3, 19, 3, 3);
            this.StartdateTimePicker.Name = "StartdateTimePicker";
            this.StartdateTimePicker.Size = new System.Drawing.Size(609, 22);
            this.StartdateTimePicker.TabIndex = 4;
            // 
            // EnddateTimePicker
            // 
            this.EnddateTimePicker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EnddateTimePicker.Location = new System.Drawing.Point(483, 299);
            this.EnddateTimePicker.Margin = new System.Windows.Forms.Padding(3, 19, 3, 3);
            this.EnddateTimePicker.Name = "EnddateTimePicker";
            this.EnddateTimePicker.Size = new System.Drawing.Size(609, 22);
            this.EnddateTimePicker.TabIndex = 5;
            // 
            // RoleIdDataGridView
            // 
            this.RoleIdDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RoleIdDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RoleIdDataGridView.Location = new System.Drawing.Point(23, 23);
            this.RoleIdDataGridView.Name = "RoleIdDataGridView";
            this.RoleIdDataGridView.RowTemplate.Height = 24;
            this.RoleIdDataGridView.Size = new System.Drawing.Size(404, 154);
            this.RoleIdDataGridView.TabIndex = 0;
            this.RoleIdDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.RoleCellClick);
            // 
            // EditButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.EditButton, 2);
            this.EditButton.Location = new System.Drawing.Point(680, 363);
            this.EditButton.Margin = new System.Windows.Forms.Padding(200, 3, 3, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(180, 45);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "განახლება";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // EditPostRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 442);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "EditPostRoles";
            this.Text = "EditPostRoles";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PostIdDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RoleIdDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView PostIdDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker StartdateTimePicker;
        private System.Windows.Forms.DateTimePicker EnddateTimePicker;
        private System.Windows.Forms.DataGridView RoleIdDataGridView;
        private System.Windows.Forms.Button EditButton;
    }
}