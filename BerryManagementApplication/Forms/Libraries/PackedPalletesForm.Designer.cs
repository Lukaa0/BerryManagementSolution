namespace BerryManagementApplication.Forms.Libraries
{
    partial class PackedPalletesForm
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
            this.GridgroupBox1 = new System.Windows.Forms.GroupBox();
            this.PalleteDataGridView = new System.Windows.Forms.DataGridView();
            this.ContainerWeight_Container_BarCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerWeight_Net = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerWeight_Gross = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContainerWeight_DateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtongroupBox2 = new System.Windows.Forms.GroupBox();
            this.PrintButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BreedsDataGridView = new System.Windows.Forms.DataGridView();
            this.Product_Breed_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_WeightsSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Product_ContainerCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridgroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PalleteDataGridView)).BeginInit();
            this.ButtongroupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BreedsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // GridgroupBox1
            // 
            this.GridgroupBox1.Controls.Add(this.PalleteDataGridView);
            this.GridgroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridgroupBox1.Location = new System.Drawing.Point(0, 0);
            this.GridgroupBox1.Name = "GridgroupBox1";
            this.GridgroupBox1.Size = new System.Drawing.Size(874, 536);
            this.GridgroupBox1.TabIndex = 0;
            this.GridgroupBox1.TabStop = false;
            // 
            // PalleteDataGridView
            // 
            this.PalleteDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PalleteDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContainerWeight_Container_BarCode,
            this.ContainerWeight_Net,
            this.ContainerWeight_Gross,
            this.ContainerWeight_DateTime});
            this.PalleteDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PalleteDataGridView.Location = new System.Drawing.Point(3, 18);
            this.PalleteDataGridView.Name = "PalleteDataGridView";
            this.PalleteDataGridView.RowTemplate.Height = 24;
            this.PalleteDataGridView.Size = new System.Drawing.Size(868, 515);
            this.PalleteDataGridView.TabIndex = 0;
            this.PalleteDataGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PalleteDataGridView_RowEnter);
            // 
            // ContainerWeight_Container_BarCode
            // 
            this.ContainerWeight_Container_BarCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContainerWeight_Container_BarCode.DataPropertyName = "ContainerWeight_Container_BarCode";
            this.ContainerWeight_Container_BarCode.HeaderText = "ბარკოდი";
            this.ContainerWeight_Container_BarCode.Name = "ContainerWeight_Container_BarCode";
            // 
            // ContainerWeight_Net
            // 
            this.ContainerWeight_Net.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContainerWeight_Net.DataPropertyName = "ContainerWeight_Net";
            this.ContainerWeight_Net.HeaderText = "ნეტო წონა";
            this.ContainerWeight_Net.Name = "ContainerWeight_Net";
            // 
            // ContainerWeight_Gross
            // 
            this.ContainerWeight_Gross.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContainerWeight_Gross.DataPropertyName = "ContainerWeight_Gross";
            this.ContainerWeight_Gross.HeaderText = "ბრუტო წონა";
            this.ContainerWeight_Gross.Name = "ContainerWeight_Gross";
            // 
            // ContainerWeight_DateTime
            // 
            this.ContainerWeight_DateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ContainerWeight_DateTime.DataPropertyName = "ContainerWeight_DateTime";
            this.ContainerWeight_DateTime.HeaderText = "შექმნის დრო";
            this.ContainerWeight_DateTime.Name = "ContainerWeight_DateTime";
            // 
            // ButtongroupBox2
            // 
            this.ButtongroupBox2.Controls.Add(this.PrintButton);
            this.ButtongroupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtongroupBox2.Location = new System.Drawing.Point(874, 0);
            this.ButtongroupBox2.Name = "ButtongroupBox2";
            this.ButtongroupBox2.Size = new System.Drawing.Size(234, 536);
            this.ButtongroupBox2.TabIndex = 1;
            this.ButtongroupBox2.TabStop = false;
            // 
            // PrintButton
            // 
            this.PrintButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.PrintButton.Location = new System.Drawing.Point(4, 22);
            this.PrintButton.Margin = new System.Windows.Forms.Padding(4);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(227, 39);
            this.PrintButton.TabIndex = 1;
            this.PrintButton.Tag = "101";
            this.PrintButton.Text = "ბეჭვდა";
            this.PrintButton.UseVisualStyleBackColor = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BreedsDataGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 289);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(874, 247);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // BreedsDataGridView
            // 
            this.BreedsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BreedsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Product_Breed_Name,
            this.Product_WeightsSum,
            this.Product_ContainerCount});
            this.BreedsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BreedsDataGridView.Location = new System.Drawing.Point(3, 18);
            this.BreedsDataGridView.Name = "BreedsDataGridView";
            this.BreedsDataGridView.RowTemplate.Height = 24;
            this.BreedsDataGridView.Size = new System.Drawing.Size(868, 226);
            this.BreedsDataGridView.TabIndex = 0;
            // 
            // Product_Breed_Name
            // 
            this.Product_Breed_Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_Breed_Name.DataPropertyName = "Product_Breed_Name";
            this.Product_Breed_Name.HeaderText = "ჯიში";
            this.Product_Breed_Name.Name = "Product_Breed_Name";
            // 
            // Product_WeightsSum
            // 
            this.Product_WeightsSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_WeightsSum.DataPropertyName = "Product_WeightsSum";
            this.Product_WeightsSum.HeaderText = "ნეტო წონა";
            this.Product_WeightsSum.Name = "Product_WeightsSum";
            // 
            // Product_ContainerCount
            // 
            this.Product_ContainerCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Product_ContainerCount.DataPropertyName = "Product_ContainerCount";
            this.Product_ContainerCount.HeaderText = "ყუთების რაოდენობა";
            this.Product_ContainerCount.Name = "Product_ContainerCount";
            // 
            // PackedPalletesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1108, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GridgroupBox1);
            this.Controls.Add(this.ButtongroupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "PackedPalletesForm";
            this.Text = "დასრულებული პალეტები";
            this.GridgroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PalleteDataGridView)).EndInit();
            this.ButtongroupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BreedsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GridgroupBox1;
        private System.Windows.Forms.DataGridView PalleteDataGridView;
        private System.Windows.Forms.GroupBox ButtongroupBox2;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerWeight_Container_BarCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerWeight_Net;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerWeight_Gross;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContainerWeight_DateTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView BreedsDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_Breed_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_WeightsSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Product_ContainerCount;
    }
}