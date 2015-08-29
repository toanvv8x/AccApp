namespace PMS
{
    partial class frmSystem_ListPatient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystem_ListPatient));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl_DSKhachHang = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItembtnAddNew = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.ID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenBN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenKhongDau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItembtnHistory = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.linqServerModeSource1 = new DevExpress.Data.Linq.LinqServerModeSource();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.btnReload = new DevExpress.XtraEditors.SimpleButton();
            this.xtraTabControl_DSKhachHang = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage_DanhSachKH = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.pLinqServerModeSource1 = new DevExpress.Data.PLinq.PLinqServerModeSource();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DSKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnAddNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_DSKhachHang)).BeginInit();
            this.xtraTabControl_DSKhachHang.SuspendLayout();
            this.xtraTabPage_DanhSachKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pLinqServerModeSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_DSKhachHang
            // 
            this.gridControl_DSKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_DSKhachHang.Location = new System.Drawing.Point(0, 0);
            this.gridControl_DSKhachHang.MainView = this.gridView1;
            this.gridControl_DSKhachHang.Name = "gridControl_DSKhachHang";
            this.gridControl_DSKhachHang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItembtnAddNew,
            this.repositoryItembtnHistory});
            this.gridControl_DSKhachHang.Size = new System.Drawing.Size(912, 312);
            this.gridControl_DSKhachHang.TabIndex = 1;
            this.gridControl_DSKhachHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.ID,
            this.TenBN,
            this.TenKhongDau,
            this.gridColumn2});
            this.gridView1.GridControl = this.gridControl_DSKhachHang;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.IndicatorWidth = 45;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupExpandCollapseButtons = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Add new";
            this.gridColumn1.ColumnEdit = this.repositoryItembtnAddNew;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 50;
            // 
            // repositoryItembtnAddNew
            // 
            this.repositoryItembtnAddNew.AutoHeight = false;
            this.repositoryItembtnAddNew.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItembtnAddNew.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItembtnAddNew.Name = "repositoryItembtnAddNew";
            this.repositoryItembtnAddNew.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItembtnAddNew.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItembtnAddNew_ButtonClick);
            // 
            // ID
            // 
            this.ID.Caption = "File number";
            this.ID.FieldName = "ID";
            this.ID.MinWidth = 90;
            this.ID.Name = "ID";
            this.ID.Visible = true;
            this.ID.VisibleIndex = 2;
            this.ID.Width = 90;
            // 
            // TenBN
            // 
            this.TenBN.Caption = "Name";
            this.TenBN.FieldName = "TenBN";
            this.TenBN.MinWidth = 250;
            this.TenBN.Name = "TenBN";
            this.TenBN.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "MaKH", "{0}")});
            this.TenBN.Visible = true;
            this.TenBN.VisibleIndex = 3;
            this.TenBN.Width = 250;
            // 
            // TenKhongDau
            // 
            this.TenKhongDau.Caption = "Date of first visit";
            this.TenKhongDau.FieldName = "NgayKhamLanDau";
            this.TenKhongDau.MinWidth = 160;
            this.TenKhongDau.Name = "TenKhongDau";
            this.TenKhongDau.Visible = true;
            this.TenKhongDau.VisibleIndex = 4;
            this.TenKhongDau.Width = 160;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "History";
            this.gridColumn2.ColumnEdit = this.repositoryItembtnHistory;
            this.gridColumn2.MinWidth = 30;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 45;
            // 
            // repositoryItembtnHistory
            // 
            this.repositoryItembtnHistory.AutoHeight = false;
            this.repositoryItembtnHistory.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItembtnHistory.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.repositoryItembtnHistory.Name = "repositoryItembtnHistory";
            this.repositoryItembtnHistory.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItembtnHistory.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItembtnHistory_ButtonClick);
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(2, 21);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.btnReload);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.gridControl_DSKhachHang);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(912, 363);
            this.splitContainerControl1.SplitterPosition = 46;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(30, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(122, 42);
            this.btnReload.TabIndex = 0;
            this.btnReload.Text = "Reload list";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // xtraTabControl_DSKhachHang
            // 
            this.xtraTabControl_DSKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl_DSKhachHang.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl_DSKhachHang.Name = "xtraTabControl_DSKhachHang";
            this.xtraTabControl_DSKhachHang.SelectedTabPage = this.xtraTabPage_DanhSachKH;
            this.xtraTabControl_DSKhachHang.Size = new System.Drawing.Size(922, 414);
            this.xtraTabControl_DSKhachHang.TabIndex = 1;
            this.xtraTabControl_DSKhachHang.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage_DanhSachKH});
            this.xtraTabControl_DSKhachHang.CloseButtonClick += new System.EventHandler(this.xtraTabControl_DSKhachHang_CloseButtonClick);
            // 
            // xtraTabPage_DanhSachKH
            // 
            this.xtraTabPage_DanhSachKH.Controls.Add(this.groupControl1);
            this.xtraTabPage_DanhSachKH.Name = "xtraTabPage_DanhSachKH";
            this.xtraTabPage_DanhSachKH.Size = new System.Drawing.Size(916, 386);
            this.xtraTabPage_DanhSachKH.Text = "List of patients";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.splitContainerControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(916, 386);
            this.groupControl1.TabIndex = 0;
            // 
            // frmSystem_ListPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 414);
            this.Controls.Add(this.xtraTabControl_DSKhachHang);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSystem_ListPatient";
            this.Text = "frmSystem_ListPatient";
            this.Load += new System.EventHandler(this.frmSystem_ListPatient_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_DSKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnAddNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItembtnHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linqServerModeSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl_DSKhachHang)).EndInit();
            this.xtraTabControl_DSKhachHang.ResumeLayout(false);
            this.xtraTabPage_DanhSachKH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pLinqServerModeSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_DSKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn ID;
        private DevExpress.XtraGrid.Columns.GridColumn TenBN;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn TenKhongDau;
        private DevExpress.Data.Linq.LinqServerModeSource linqServerModeSource1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl_DSKhachHang;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage_DanhSachKH;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.Data.PLinq.PLinqServerModeSource pLinqServerModeSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItembtnAddNew;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItembtnHistory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.SimpleButton btnReload;
    }
}