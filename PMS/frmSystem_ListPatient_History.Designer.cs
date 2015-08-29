namespace PMS
{
    partial class frmSystem_ListPatient_History
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSystem_ListPatient_History));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.gridControl_GoiDien = new DevExpress.XtraGrid.GridControl();
            this.gridView_CuocGoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Print = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.NgayKham = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TreatmentTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TimeWeek = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TreatmentTimeTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDCTBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.IDBenhNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CuocGoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl_GoiDien
            // 
            this.gridControl_GoiDien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl_GoiDien.Location = new System.Drawing.Point(0, 0);
            this.gridControl_GoiDien.MainView = this.gridView_CuocGoi;
            this.gridControl_GoiDien.Name = "gridControl_GoiDien";
            this.gridControl_GoiDien.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl_GoiDien.Size = new System.Drawing.Size(626, 382);
            this.gridControl_GoiDien.TabIndex = 70;
            this.gridControl_GoiDien.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_CuocGoi});
            // 
            // gridView_CuocGoi
            // 
            this.gridView_CuocGoi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Print,
            this.NgayKham,
            this.TreatmentTime,
            this.TimeWeek,
            this.TreatmentTimeTotal,
            this.IDCTBenhNhan,
            this.IDBenhNhan});
            this.gridView_CuocGoi.GridControl = this.gridControl_GoiDien;
            this.gridView_CuocGoi.Name = "gridView_CuocGoi";
            // 
            // Print
            // 
            this.Print.Caption = "Print";
            this.Print.ColumnEdit = this.repositoryItemButtonEdit1;
            this.Print.MaxWidth = 45;
            this.Print.MinWidth = 45;
            this.Print.Name = "Print";
            this.Print.Visible = true;
            this.Print.VisibleIndex = 0;
            this.Print.Width = 45;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("repositoryItemButtonEdit1.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButtonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit1_ButtonClick);
            // 
            // NgayKham
            // 
            this.NgayKham.Caption = "Datetime";
            this.NgayKham.FieldName = "NgayKham";
            this.NgayKham.MaxWidth = 140;
            this.NgayKham.Name = "NgayKham";
            this.NgayKham.Visible = true;
            this.NgayKham.VisibleIndex = 1;
            this.NgayKham.Width = 140;
            // 
            // TreatmentTime
            // 
            this.TreatmentTime.Caption = "TimeWeek";
            this.TreatmentTime.FieldName = "TreatmentTime";
            this.TreatmentTime.MaxWidth = 140;
            this.TreatmentTime.Name = "TreatmentTime";
            this.TreatmentTime.Visible = true;
            this.TreatmentTime.VisibleIndex = 2;
            this.TreatmentTime.Width = 140;
            // 
            // TimeWeek
            // 
            this.TimeWeek.Caption = "TimeMonth";
            this.TimeWeek.FieldName = "TreatmentTimeFor";
            this.TimeWeek.MaxWidth = 140;
            this.TimeWeek.Name = "TimeWeek";
            this.TimeWeek.Visible = true;
            this.TimeWeek.VisibleIndex = 3;
            this.TimeWeek.Width = 140;
            // 
            // TreatmentTimeTotal
            // 
            this.TreatmentTimeTotal.AppearanceCell.Options.UseTextOptions = true;
            this.TreatmentTimeTotal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.TreatmentTimeTotal.Caption = "Total";
            this.TreatmentTimeTotal.FieldName = "TreatmentTimeTotal";
            this.TreatmentTimeTotal.Name = "TreatmentTimeTotal";
            this.TreatmentTimeTotal.Visible = true;
            this.TreatmentTimeTotal.VisibleIndex = 4;
            this.TreatmentTimeTotal.Width = 143;
            // 
            // IDCTBenhNhan
            // 
            this.IDCTBenhNhan.Caption = "IDCTBenhNhan";
            this.IDCTBenhNhan.FieldName = "IDCTBenhNhan";
            this.IDCTBenhNhan.Name = "IDCTBenhNhan";
            // 
            // IDBenhNhan
            // 
            this.IDBenhNhan.Caption = "IDBenhNhan";
            this.IDBenhNhan.FieldName = "IDBenhNhan";
            this.IDBenhNhan.Name = "IDBenhNhan";
            // 
            // frmSystem_ListPatient_History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 382);
            this.Controls.Add(this.gridControl_GoiDien);
            this.Name = "frmSystem_ListPatient_History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medical history";
            this.Load += new System.EventHandler(this.frmSystem_ListPatient_History_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_GoiDien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_CuocGoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl_GoiDien;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_CuocGoi;
        private DevExpress.XtraGrid.Columns.GridColumn Print;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn NgayKham;
        private DevExpress.XtraGrid.Columns.GridColumn TreatmentTime;
        private DevExpress.XtraGrid.Columns.GridColumn TimeWeek;
        private DevExpress.XtraGrid.Columns.GridColumn TreatmentTimeTotal;
        private DevExpress.XtraGrid.Columns.GridColumn IDCTBenhNhan;
        private DevExpress.XtraGrid.Columns.GridColumn IDBenhNhan;
    }
}