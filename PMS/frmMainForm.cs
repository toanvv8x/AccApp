using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Diagnostics;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars;
using PMS.App_Code;
using PMS.DataModel;
using PMS.BL;


namespace PMS
{
    public partial class frmMainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        clsQLNguoiDung qlND;
        private NguoiDung _cvtNguoiDung;
        public NguoiDung cvtNguoiDung
        {
            get { return _cvtNguoiDung; }
            set
            {
                _cvtNguoiDung = value;
            }
        }

        #region common

        void NgayThangNamGio()
        {
            Timer t = new Timer { Interval = 1000 };
            t.Start();
            t.Tick += t_Tick;
        }
        string Thu, Ngay, Thang, Nam, Gio;
        void t_Tick(object sender, EventArgs e)
        {
            switch (DateTime.Now.DayOfWeek.ToString().ToLower())
            {
                case "monday":
                    Thu = "Monday";
                    break;
                case "tuesday":
                    Thu = "Tuesday";
                    break;
                case "wednesday":
                    Thu = "Wednesday";
                    break;
                case "thursday":
                    Thu = "Thursday";
                    break;
                case "friday":
                    Thu = "Friday";
                    break;
                case "saturday":
                    Thu = "Saturday";
                    break;
                default: Thu = "Sunday";
                    break;
            }
            Ngay = DateTime.Now.Day.ToString();
            Thang = DateTime.Now.Month.ToString();
            Nam = DateTime.Now.Year.ToString();
            Gio = DateTime.Now.ToLongTimeString();
            barStaticItem_time.Caption = String.Format("{0},  {1} - {2} - {3}, {4}", Thu, Thang, Ngay, Nam, Gio); ;
        }
        #endregion

        /// <summary>
        /// Tạo thêm tab mới
        /// </summary>
        /// <param name="tabControl">Tên TabControl để add thêm tabpage mới vào</param>
        /// <param name="Text">Tiêu đề tabpage mới</param>
        /// <param name="Name">Tên tabpage mới</param>
        /// <param name="form">Tên form con của tab mới</param>
        /// <param name="imageIndex">index của icon</param>
        void TabCreating(DevExpress.XtraTab.XtraTabControl tabControl, string Text, string Name, DevExpress.XtraEditors.XtraForm form, int imageIndex)
        {
            int index = KiemTraTonTai(tabControl, Name);
            if (index >= 0)
            {
                tabControl.SelectedTabPage = tabControl.TabPages[index];
                tabControl.SelectedTabPage.Text = Text;
            }
            else
            {
                DevExpress.XtraTab.XtraTabPage tabpage = new DevExpress.XtraTab.XtraTabPage { Text = Text, Name = Name, ImageIndex = imageIndex };
                tabControl.TabPages.Add(tabpage);
                tabControl.SelectedTabPage = tabpage;

                form.TopLevel = false;
                form.Parent = tabpage;
                form.Show();
                form.Dock = DockStyle.Fill;
            }
        }
        /// <summary>
        /// Kiểm tra tabpage có tồn tại hay không.
        /// </summary>
        /// <param name="tabControlName">Tên tabControl để kiểm tra.</param>
        /// <param name="tabName">Tên tabpage cần kiểm tra.</param>
        /// <returns></returns>
        static int KiemTraTonTai(DevExpress.XtraTab.XtraTabControl tabControlName, string tabName)
        {
            int re = -1;
            for (int i = 0; i < tabControlName.TabPages.Count; i++)
            {
                if (tabControlName.TabPages[i].Name == tabName)
                {
                    re = i;
                    break;
                }
            }
            return re;
        }


        public frmMainForm()
        {
            InitializeComponent();
            qlND = new clsQLNguoiDung();
        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

            NgayThangNamGio();
            TabCreating(xtraTabControl_ManHinhChinh, "System", "HeThong", FrmSystem, 0);
            frmSystem_AddPatient_v2 FrmHeThong_QLNhom = new frmSystem_AddPatient_v2();
            TabCreating(FrmSystem.xtraTabControl_HeThong, "Patient management", "QLNhomNguoiDung", FrmHeThong_QLNhom, -1);
            FrmHeThong_QLNhom.Dock = DockStyle.Fill;
            FrmSystem.xtraTabControl_HeThong.SelectedTabPage.Image = imageCollection1.Images[1];

        }

        private void frmMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {

            if (DevExpress.XtraEditors.XtraMessageBox.Show("Bạn có thật sự muốn thoát ra?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
            Process.Start(Application.ExecutablePath);
            Close();
        }

        frmSystem FrmSystem = new frmSystem();
        private void barBtnAddPatient_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabCreating(xtraTabControl_ManHinhChinh, "System", "HeThong", FrmSystem, 0);
            frmSystem_AddPatient_v2 FrmHeThong_QLNhom = new frmSystem_AddPatient_v2();
            TabCreating(FrmSystem.xtraTabControl_HeThong, "Patient management", "QLNhomNguoiDung", FrmHeThong_QLNhom, -1);
            FrmHeThong_QLNhom.Dock = DockStyle.Fill;
            FrmSystem.xtraTabControl_HeThong.SelectedTabPage.Image = imageCollection1.Images[1];
        }

        private void xtraTabControl_ManHinhChinh_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
            if (xtab.TabPages.Count == 1) return;
            int i = xtab.SelectedTabPageIndex;
            xtab.TabPages.RemoveAt(xtab.SelectedTabPageIndex);
            xtab.SelectedTabPageIndex = i - 1;
        }

        private void barBtnDSKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            TabCreating(xtraTabControl_ManHinhChinh, "System", "HeThong", FrmSystem, 0);
            frmSystem_ListPatient FrmHeThong_QLNhom = new frmSystem_ListPatient();
            TabCreating(FrmSystem.xtraTabControl_HeThong, "List of patients", "Listofpatients", FrmHeThong_QLNhom, -1);
            FrmHeThong_QLNhom.Dock = DockStyle.Fill;
            FrmSystem.xtraTabControl_HeThong.SelectedTabPage.Image = imageCollection1.Images[1];
        }
    }
}