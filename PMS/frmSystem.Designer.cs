namespace PMS
{
    partial class frmSystem
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
            this.xtraTabControl_HeThong = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_HeThong)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl_HeThong
            // 
            this.xtraTabControl_HeThong.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            this.xtraTabControl_HeThong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_HeThong.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Left;
            this.xtraTabControl_HeThong.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_HeThong.Name = "xtraTabControl_HeThong";
            this.xtraTabControl_HeThong.Size = new System.Drawing.Size(938, 452);
            this.xtraTabControl_HeThong.TabIndex = 1;
            this.xtraTabControl_HeThong.CloseButtonClick += new System.EventHandler(this.xtraTabControl_HeThong_CloseButtonClick);
            // 
            // frmSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(938, 452);
            this.Controls.Add(this.xtraTabControl_HeThong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSystem";
            this.Text = "FrmSystem";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_HeThong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraTab.XtraTabControl xtraTabControl_HeThong;

    }
}