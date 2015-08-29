using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using DevExpress.XtraBars;
using System.Diagnostics;
using PMS.BL;
using PMS.DataModel;
using System.IO;
using PMS.App_Code;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System.Collections;
using System.Data.Linq;


namespace PMS
{
    public partial class frmSystem_ListPatient : DevExpress.XtraEditors.XtraForm
    {
        clsQLNguoiDung qlND;
        public frmSystem_ListPatient()
        {
            InitializeComponent();
            qlND = new clsQLNguoiDung();
        }

        private void gridControl_DSKhachHang_DoubleClick(object sender, EventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView1.FocusedRowHandle;

            // Get the value for the given column - convert to the type you're expecting
            string maBN = gridView1.GetRowCellValue(rowHandle, "ID").ToString();

            frmSystem_ListPatient_History child = new frmSystem_ListPatient_History { MaBN = maBN };

            //child.AddItemCallback = new AddItemDelegate(this.AddItemCallbackFn);
            child.ShowDialog();
        }

        private void frmSystem_ListPatient_Load(object sender, EventArgs e)
        {
            List<BenhNhan> listBenhNhan = qlND.GetListBenhNhan();
            gridControl_DSKhachHang.DataSource = listBenhNhan;
        }

        private void repositoryItembtnHistory_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView1.FocusedRowHandle;

            // Get the value for the given column - convert to the type you're expecting
            string maBN = gridView1.GetRowCellValue(rowHandle, "ID").ToString();

            frmSystem_ListPatient_History child = new frmSystem_ListPatient_History { MaBN = maBN };

            //child.AddItemCallback = new AddItemDelegate(this.AddItemCallbackFn);
            child.ShowDialog();
        }

        private void repositoryItembtnAddNew_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView1.FocusedRowHandle;

            // Get the value for the given column - convert to the type you're expecting
            string maBN = gridView1.GetRowCellValue(rowHandle, "ID").ToString();
            BenhNhan bn = new BenhNhan();
            bn.ID = maBN;
            bn.NgayKhamLanDau = (DateTime)(gridView1.GetRowCellValue(rowHandle, "NgayKhamLanDau"));
            bn.TenBN = gridView1.GetRowCellValue(rowHandle, "TenBN").ToString();
            frmSystem_ListPatient_AddNew_v2 child = new frmSystem_ListPatient_AddNew_v2 { BN = bn };

            //child.AddItemCallback = new AddItemDelegate(this.AddItemCallbackFn);
            child.ShowDialog();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            List<BenhNhan> listBenhNhan = qlND.GetListBenhNhan();
            gridControl_DSKhachHang.DataSource = null;
            gridControl_DSKhachHang.DataSource = listBenhNhan;
        }

        private void xtraTabControl_DSKhachHang_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
            if (xtab.TabPages.Count == 1) return;
            int i = xtab.SelectedTabPageIndex;
            xtab.TabPages.RemoveAt(xtab.SelectedTabPageIndex);
            xtab.SelectedTabPageIndex = i - 1;
        }
    }
}