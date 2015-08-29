namespace PMS
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barStaticItemThongBao = new DevExpress.XtraBars.BarStaticItem();
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPass = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnConect = new DevExpress.XtraEditors.SimpleButton();
            this.txtConectID = new DevExpress.XtraEditors.TextEdit();
            this.lblConectID = new DevExpress.XtraEditors.LabelControl();
            this.lblConectPass = new DevExpress.XtraEditors.LabelControl();
            this.txtConectPass = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConectID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConectPass.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItemThongBao);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 314);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(495, 31);
            // 
            // barStaticItemThongBao
            // 
            this.barStaticItemThongBao.Id = 1;
            this.barStaticItemThongBao.Name = "barStaticItemThongBao";
            this.barStaticItemThongBao.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barStaticItemThongBao});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 3;
            this.ribbon.Name = "ribbon";
            this.ribbon.Size = new System.Drawing.Size(495, 49);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Above;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(175, 195);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Sign in";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(175, 104);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 20);
            this.txtUser.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(147, 107);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 13);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "User";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(175, 151);
            this.txtPass.Name = "txtPass";
            this.txtPass.Properties.PasswordChar = '*';
            this.txtPass.Properties.UseSystemPasswordChar = true;
            this.txtPass.Size = new System.Drawing.Size(178, 20);
            this.txtPass.TabIndex = 9;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(124, 154);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Password";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(278, 195);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 11;
            this.btnClose.Text = "Exit";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnConect
            // 
            this.btnConect.Image = ((System.Drawing.Image)(resources.GetObject("btnConect.Image")));
            this.btnConect.Location = new System.Drawing.Point(324, 285);
            this.btnConect.Name = "btnConect";
            this.btnConect.Size = new System.Drawing.Size(159, 23);
            this.btnConect.TabIndex = 16;
            this.btnConect.Text = "Connect server";
            this.btnConect.Click += new System.EventHandler(this.btnConect_Click);
            // 
            // txtConectID
            // 
            this.txtConectID.EnterMoveNextControl = true;
            this.txtConectID.Location = new System.Drawing.Point(29, 288);
            this.txtConectID.Name = "txtConectID";
            this.txtConectID.Size = new System.Drawing.Size(104, 20);
            this.txtConectID.TabIndex = 15;
            // 
            // lblConectID
            // 
            this.lblConectID.Location = new System.Drawing.Point(12, 291);
            this.lblConectID.Name = "lblConectID";
            this.lblConectID.Size = new System.Drawing.Size(15, 13);
            this.lblConectID.TabIndex = 19;
            this.lblConectID.Text = "ID:";
            // 
            // lblConectPass
            // 
            this.lblConectPass.Location = new System.Drawing.Point(141, 290);
            this.lblConectPass.Name = "lblConectPass";
            this.lblConectPass.Size = new System.Drawing.Size(50, 13);
            this.lblConectPass.TabIndex = 21;
            this.lblConectPass.Text = "Password:";
            // 
            // txtConectPass
            // 
            this.txtConectPass.EnterMoveNextControl = true;
            this.txtConectPass.Location = new System.Drawing.Point(197, 287);
            this.txtConectPass.Name = "txtConectPass";
            this.txtConectPass.Size = new System.Drawing.Size(108, 20);
            this.txtConectPass.TabIndex = 20;
            // 
            // frmLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("frmLogin.Appearance.Image")));
            this.Appearance.Options.UseImage = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 345);
            this.Controls.Add(this.lblConectPass);
            this.Controls.Add(this.txtConectPass);
            this.Controls.Add(this.lblConectID);
            this.Controls.Add(this.btnConect);
            this.Controls.Add(this.txtConectID);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogin";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Login";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmLogin_FormClosing);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPass.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConectID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConectPass.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.BarStaticItem barStaticItemThongBao;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPass;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnConect;
        private DevExpress.XtraEditors.TextEdit txtConectID;
        private DevExpress.XtraEditors.LabelControl lblConectID;
        private DevExpress.XtraEditors.LabelControl lblConectPass;
        private DevExpress.XtraEditors.TextEdit txtConectPass;
    }
}