using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace PMS
{
    public partial class frmLogin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        clsQLNguoiDung qlND;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            qlND = new clsQLNguoiDung();
            try
            {
                //CauHinh
                //string strIP = ConfigurationManager.AppSettings["SERVER_IP"].ToString();

                List<NguoiDung> listNguoiDung = qlND.GetListNguoiDung();
                if (listNguoiDung == null)
                {
                    barStaticItemThongBao.Caption = "Network Connection Failure";
                    txtConectID.Visible = true;
                    txtConectPass.Visible = true;
                    lblConectID.Visible = true;
                    lblConectPass.Visible = true;
                    btnConect.Visible = true;
                }
                else
                {
                    barStaticItemThongBao.Caption = "Network Connection Successful";
                    txtConectID.Visible = false;
                    txtConectPass.Visible = false;
                    lblConectID.Visible = false;
                    lblConectPass.Visible = false;
                    btnConect.Visible = false;
                    //login();
                }
            }
            catch //(Exception ex)
            {
                barStaticItemThongBao.Caption = "Network Connection Failure";
                txtConectID.Visible = true;
                btnConect.Visible = true;
            }
        }
        public void login()
        {
            string ten = "admin";
            string mk = "123";
            List<NguoiDung> listNguoiDung = qlND.GetListNguoiDung().ToList();
            if (listNguoiDung.Count > 0)
            {
                NguoiDung nguoiDung = listNguoiDung.Where(i => i.TenDangNhap == ten && i.MatKhau == mk).SingleOrDefault();
                if (nguoiDung != null)
                {
                    if (nguoiDung.Active != null && (bool)nguoiDung.Active)
                    {
                        frmMainForm main = new frmMainForm { cvtNguoiDung = nguoiDung };
                        main.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản người dùng '" + nguoiDung.TenDangNhap + "' chưa được kích hoạt");
                    }
                }
                else
                    MessageBox.Show("Đăng nhập thất bại");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string ten = txtUser.Text.ToString();
            string mk = txtPass.Text.ToString();
            List<NguoiDung> listNguoiDung = qlND.GetListNguoiDung().ToList();
            if (listNguoiDung.Count > 0)
            {
                NguoiDung nguoiDung = listNguoiDung.Where(i => i.TenDangNhap == ten && i.MatKhau == mk).SingleOrDefault();
                if (nguoiDung != null)
                {
                    if (nguoiDung.Active != null && (bool)nguoiDung.Active)
                    {
                        frmMainForm main = new frmMainForm { cvtNguoiDung = nguoiDung };
                        main.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản người dùng '" + nguoiDung.TenDangNhap + "' chưa được kích hoạt");
                    }
                }
                else
                    MessageBox.Show("Đăng nhập thất bại");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnConect_Click(object sender, EventArgs e)
        {

            string User = ConfigurationManager.AppSettings["User"].ToString();
            string Pass = ConfigurationManager.AppSettings["Pass"].ToString();

            string Connection = string.Format("{0}User ID={1};Password={2}", ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString.ToString(), User, Pass);
            qlND = new clsQLNguoiDung(Connection);

            List<NguoiDung> listNguoiDung = qlND.GetListNguoiDung();
            if (listNguoiDung == null)
            {
                barStaticItemThongBao.Caption = "Network Connection Failure";
                txtConectID.Visible = true;
                txtConectPass.Visible = true;
                lblConectID.Visible = true;
                lblConectPass.Visible = true;
                btnConect.Visible = true;
            }
            else
            {
                barStaticItemThongBao.Caption = "Network Connection Successful";
                txtConectID.Visible = false;
                txtConectPass.Visible = false;
                lblConectID.Visible = false;
                lblConectPass.Visible = false;
                btnConect.Visible = false;

                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection appSet = config.AppSettings;
                appSet.Settings["User"].Value = txtConectID.Text.Trim();
                appSet.Settings["Pass"].Value = txtConectPass.Text.Trim();
                config.Save();
                //login();
            }
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}