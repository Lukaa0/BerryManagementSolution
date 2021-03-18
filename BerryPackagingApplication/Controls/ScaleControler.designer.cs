namespace BerryPackagingApplication.Controls
{
    partial class ScaleControler
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.display = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ZeroButton = new System.Windows.Forms.Button();
            this.TareButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.display, 2);
            this.display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.display.Location = new System.Drawing.Point(2, 0);
            this.display.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(98, 24);
            this.display.TabIndex = 4;
            this.display.Text = "-----";
            this.display.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ZeroButton
            // 
            this.ZeroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ZeroButton.Location = new System.Drawing.Point(2, 26);
            this.ZeroButton.Margin = new System.Windows.Forms.Padding(2);
            this.ZeroButton.Name = "ZeroButton";
            this.ZeroButton.Size = new System.Drawing.Size(47, 21);
            this.ZeroButton.TabIndex = 5;
            this.ZeroButton.Text = "ZERO";
            this.ZeroButton.UseVisualStyleBackColor = true;
            this.ZeroButton.Click += new System.EventHandler(this.ZeroButton_Click);
            // 
            // TareButton
            // 
            this.TareButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TareButton.Location = new System.Drawing.Point(53, 26);
            this.TareButton.Margin = new System.Windows.Forms.Padding(2);
            this.TareButton.Name = "TareButton";
            this.TareButton.Size = new System.Drawing.Size(47, 21);
            this.TareButton.TabIndex = 6;
            this.TareButton.Text = "TARE";
            this.TareButton.UseVisualStyleBackColor = true;
            this.TareButton.Click += new System.EventHandler(this.TareButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.TareButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.display, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ZeroButton, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(102, 49);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // ScaleControler
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScaleControler";
            this.Size = new System.Drawing.Size(102, 49);
            this.FontChanged += new System.EventHandler(this.ScaleControler_FontChanged);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label display;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ZeroButton;
        private System.Windows.Forms.Button TareButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
