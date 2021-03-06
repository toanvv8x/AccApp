﻿using System;
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
using PMS.Report;
using System.Data.OleDb;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Preview.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
namespace PMS
{
    public partial class frmSystem_ListPatient_AddNew : DevExpress.XtraEditors.XtraForm
    {
        clsQLNguoiDung qlND;
        private BenhNhan _BN;
        public BenhNhan BN
        {
            get { return _BN; }
            set
            {
                _BN = value;
            }
        }
        public frmSystem_ListPatient_AddNew()
        {
            InitializeComponent();
            qlND = new clsQLNguoiDung();
        }

        private void btnDeleteComment_Click(object sender, System.EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, System.EventArgs e)
        {

            openFileDialog1.Title = "Open File";
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "JPG,JPEG|*.jpg|PNG|*png";
            openFileDialog1.FileName = "";

            try
            {
                openFileDialog1.InitialDirectory = "C:\\";
            }
            catch
            {
                // skip it 
            }
            //Cach2
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Random rnd = new Random();
                List<CTBenhNhanSnapShot> listSnap = CloneSnapShot();
                //if (txtFileName.Text != string.Empty)
                //{
                foreach (String filename in @openFileDialog1.FileNames)
                {
                    int id = rnd.Next(5200);
                    CTBenhNhanSnapShot snapshot = new CTBenhNhanSnapShot();
                    FileStream FS = new FileStream(@filename, FileMode.Open, FileAccess.Read);
                    byte[] img = new byte[FS.Length];
                    FS.Read(img, 0, Convert.ToInt32(FS.Length));
                    snapshot.URL = img;
                    snapshot.ID = id;
                    //id = id++;
                    listSnap.Add(snapshot);
                }
                grid_SnapShot.DataSource = listSnap;
                //UploadFile(txtFileName.Text);
                //ImportData();
                //}
                //else
                //    MessageBox.Show("Chọn file upload.", "Chưa có file");
                ////ThanhCong
                //List<sp_GetDSTraThuongNPPTrongThangResult> list = qlNPP.GetDSTraThuongNPPTrongThang(Thang, Nam, IDKhuVuc);
                //if (list.Count > 0 && list != null)
                //{
                //    AddItemCallback(list);
                //    this.Close();
                //}
            }
            //Cach1
            //openFileDialog1.ShowDialog();

            //if (openFileDialog1.FileName == "")
            //    return;
            //else
            //    txtFileName.Text = openFileDialog1.FileName;
        }

        private List<CTBenhNhanSnapShot> CloneSnapShot()
        {
            List<CTBenhNhanSnapShot> listSnapShot = new List<CTBenhNhanSnapShot>();
            for (int i = 0; i < gridView_SnapShot.DataRowCount; i++)
            {
                CTBenhNhanSnapShot snapshot = new CTBenhNhanSnapShot();
                //FileStream fs = new FileStream("Image", FileMode.Create, FileAccess.Write);
                //fs.Write(rawData, 0, fileSize);

                Binary imageBytes = (Binary)(gridView_SnapShot.GetRowCellValue(i, "URL"));
                snapshot.URL = imageBytes;
                snapshot.ID = int.Parse(gridView_SnapShot.GetRowCellValue(i, "ID").ToString());
                listSnapShot.Add(snapshot);
            }
            return listSnapShot;
        }
        private void btnImport_Click(object sender, System.EventArgs e)
        {
            Random rnd = new Random();
            List<CTBenhNhanSnapShot> listSnap = CloneSnapShot();
            if (txtFileName.Text != string.Empty)
            {
                CTBenhNhanSnapShot snapshot = new CTBenhNhanSnapShot();
                foreach (String filename in @openFileDialog1.FileNames)
                {
                    int id = rnd.Next(5200);
                    FileStream FS = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    byte[] img = new byte[FS.Length];
                    FS.Read(img, 0, Convert.ToInt32(FS.Length));
                    snapshot.URL = img;
                    snapshot.ID = id;
                    listSnap.Add(snapshot);
                }
                grid_SnapShot.DataSource = listSnap;
                //UploadFile(txtFileName.Text);
                //ImportData();
            }
            else
                MessageBox.Show("Chọn file upload.", "Chưa có file");
            ////ThanhCong
            //List<sp_GetDSTraThuongNPPTrongThangResult> list = qlNPP.GetDSTraThuongNPPTrongThang(Thang, Nam, IDKhuVuc);
            //if (list.Count > 0 && list != null)
            //{
            //    AddItemCallback(list);
            //    this.Close();
            //}
        }

        /// <summary>
        /// Upload any file to the web service; this function may be
        /// used in any application where it is necessary to upload
        /// a file through a web service
        /// </summary>
        /// <param name="filename">Pass the file path to upload</param>
        private void UploadFile(string filename)
        {
            try
            {
                // get the exact file name from the path
                String strFile = System.IO.Path.GetFileName(filename);

                // create an instance fo the web service
                //TestUploader.Uploader.FileUploader srv = new TestUploader.Uploader.FileUploader();

                // get the file information form the selected file
                FileInfo fInfo = new FileInfo(filename);

                // get the length of the file to see if it is possible
                // to upload it (with the standard 4 MB limit)
                long numBytes = fInfo.Length;
                double dLen = Convert.ToDouble(fInfo.Length / 1000000);

                // Default limit of 4 MB on web server
                // have to change the web.config to if
                // you want to allow larger uploads
                if (dLen < 10)
                {
                    // set up a file stream and binary reader for the 
                    // selected file
                    FileStream fStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fStream);

                    // convert the file to a byte array
                    byte[] data = br.ReadBytes((int)numBytes);
                    br.Close();

                    // pass the byte array (file) and file name to the web service
                    string sTmp = Common.UploadFile(data, strFile);
                    fStream.Close();
                    fStream.Dispose();

                    // this will always say OK unless an error occurs,
                    // if an error occurs, the service returns the error message
                    MessageBox.Show("File Upload Status: " + sTmp, "File Upload");
                }
                else
                {
                    // Display message if the file was too large to upload
                    MessageBox.Show("File upload chỉ giới hạn 10MB.", "File Size");
                }
            }
            catch (Exception ex)
            {
                // display an error message to the user
                MessageBox.Show(ex.Message.ToString(), "Upload Error");
            }
        }
        private void ImportData()
        {
            string fileSheet = "Sheet1";
            var fullFileName = txtFileName.Text; ;
            if (!File.Exists(fullFileName))
            {
                System.Windows.Forms.MessageBox.Show("Không tìm thấy file");
                return;
            }
            //string strConnectionString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;", fullFileName);
            string strConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0 Xml;HDR=YES;'", fullFileName);
            OleDbConnection olecon = new OleDbConnection(strConnectionString);
            olecon.Open();
            OleDbCommand cmd = olecon.CreateCommand();
            cmd.CommandText = "SELECT * FROM [" + fileSheet + "$]";
            DataTable dtExcel = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dtExcel);
            //GetDataImport(dtExcel);
        }
        string ImageDir = @"Exercises\";

        Hashtable Images = new Hashtable();



        string GetFileName(string color)
        {

            if (color == null || color == string.Empty)

                return string.Empty;

            return color + ".jpg";

        }
        private void gridView8_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            //if (e.Column.FieldName == "Images" && e.IsGetData)
            //{
            //    int dataSourceIndex = e.ListSourceRowIndex;
            //    GridView view = sender as GridView;
            //    string colorName = (string)view.GetRowCellValue(dataSourceIndex, "Images");

            //    string fileName = GetFileName(colorName).ToLower();

            //    if (!Images.ContainsKey(fileName))
            //    {

            //        Image img = null;

            //        try
            //        {

            //            string filePath = DevExpress.Utils.FilesHelper.FindingFileName(Application.StartupPath, ImageDir + fileName, false);

            //            img = Image.FromFile(filePath);

            //        }

            //        catch
            //        {

            //        }

            //        Images.Add(fileName, img);

            //    }

            //    e.Value = Images[fileName];

            //}
        }

        //Delegate

        public delegate void AddItemDelegate(CTBenhNhanExcercise CTBenhNhan);
        private void AddItemCallback(CTBenhNhanExcercise CTBenhNhan)
        {
            //insert Chon
            for (int i = 0; i < gridView_Excercise.DataRowCount; i++)
            {
                int ID = int.Parse(gridView_Excercise.GetRowCellValue(i, "ID").ToString());
                if (ID == CTBenhNhan.IDExcercises)
                {
                    gridView_Excercise.SetRowCellValue(i, "Hold", CTBenhNhan.Hold);
                    gridView_Excercise.SetRowCellValue(i, "Do", CTBenhNhan.Do);
                    gridView_Excercise.SetRowCellValue(i, "Repeat", CTBenhNhan.Repeat);
                    gridView_Excercise.SetRowCellValue(i, "Prints", true);
                }
            }
        }
        private void repositoryItemchkPrint_CheckedChanged(object sender, EventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView_Excercise.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            bool print = bool.Parse(gridView_Excercise.GetRowCellValue(rowHandle, "Prints").ToString());
            if (!print)
            {
                // Get the value for the given column - convert to the type you're expecting
                string ID = gridView_Excercise.GetRowCellValue(rowHandle, "ID").ToString();
                Exercise ex = new Exercise();
                ex.ID = int.Parse(ID);
                ex.TenExercises = gridView_Excercise.GetRowCellValue(rowHandle, "TenExercises").ToString();
                ex.URLImage = gridView_Excercise.GetRowCellValue(rowHandle, "URLImage").ToString();

                gridView_Excercise.SetRowCellValue(rowHandle, "Prints", true);

                //frm_ListPatient_AddPatient_ExerciseOptions child = new frm_ListPatient_AddPatient_ExerciseOptions { EX = ex };
                //child.AddItemCallback = new AddItemDelegate(this.AddItemCallback);
                //child.ShowDialog();
            }
            else
            {
                gridView_Excercise.SetRowCellValue(rowHandle, "Hold", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Do", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Repeat", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Prints", false);
            }
        }

        private void btnDeleteSnapShot_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var rowHandle = gridView_SnapShot.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            //gridView6.Columns.Removesa(rowHandle);
            List<CTBenhNhanSnapShot> listSnap = CloneSnapShot();
            listSnap = listSnap.Where(i => i.ID != int.Parse(gridView_SnapShot.GetRowCellValue(rowHandle, "ID").ToString())).ToList();
            grid_SnapShot.DataSource = null;
            grid_SnapShot.DataSource = listSnap;

        }

        private void btnAddComment_Click(object sender, EventArgs e)
        {
            //insert Chon
            for (int i = 0; i < gridView_Comment.DataRowCount; i++)
            {
                bool Selects = bool.Parse(gridView_Comment.GetRowCellValue(i, "Selects").ToString());
                if (Selects)
                {
                    txtComment.Text = txtComment.Text + gridView_Comment.GetRowCellValue(i, "ChiTiet").ToString() + "\n";
                    gridView_Comment.SetRowCellValue(i, "Selects", false);
                }
            }
        }

        private void btnClearComment_Click(object sender, EventArgs e)
        {
            txtComment.Text = string.Empty;
        }

        private void spin_TreamentWeek_EditValueChanged(object sender, EventArgs e)
        {
            lblTotalTreament.Text = ((spin_TreamentWeek.Value * 4) * spin_TreamentMonth.Value).ToString();
        }

        private void spin_TreamentMonth_EditValueChanged(object sender, EventArgs e)
        {
            lblTotalTreament.Text = ((spin_TreamentWeek.Value * 4) * spin_TreamentMonth.Value).ToString();
        }

        private void gridLUEComplaint_CustomDisplayText(object sender, DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //GridCheckMarksSelection gridCheckMark = sender is GridLookUpEdit ? (sender as GridLookUpEdit).Properties.Tag as GridCheckMarksSelection : (sender as RepositoryItemGridLookUpEdit).Tag as GridCheckMarksSelection;
            //if (gridCheckMark == null) return;
            //foreach (DataRowView rv in gridCheckMark.Selection)
            //{
            //    if (sb.ToString().Length > 0) { sb.Append(", "); }
            //    sb.Append(rv["Ten"].ToString());
            //}
            //e.DisplayText = sb.ToString();
        }


        private void btnSavePrint_Click(object sender, System.EventArgs e)
        {
            try
            {
                //if (CheckValidatePatient())
                //{
                //    BenhNhan bn = GetInfBenhNhan();
                //    qlND.InsertBenhNhan(bn);

                    CTBenhNhan ctbn = GetInfCTBenhNhan();
                    qlND.InsertCTBenhNhan(ctbn);

                    List<CTBenhNhanComplaint> listComplaint = GetInfCTBenhNhanComplaint();
                    qlND.InsertListCTBenhNhanComplaint(listComplaint);

                    List<CTBenhNhanConditionDicsJoint> listDiscJoint = GetInfCTBenhNhanConditionDicsJoint();
                    qlND.InsertListCTBenhNhanConditionDicsJoint(listDiscJoint);

                    CTBenhNhanCondition cTBenhNhanConditions = GetInfCTBenhNhanCondition();
                    qlND.InsertCTBenhNhanCondition(cTBenhNhanConditions);

                    List<CTBenhNhanConditionVertebral> listCTBenhNhanConditionVertebral = GetInfCTBenhNhanConditionVertebral();
                    qlND.InsertListCTBenhNhanConditionVertebral(listCTBenhNhanConditionVertebral);

                    List<CTBenhNhanExcercise> ListCTBenhNhanExcercises = GetInfCTBenhNhanExcercise();
                    qlND.InsertListCTBenhNhanExcercise(ListCTBenhNhanExcercises);

                    List<CTBenhNhanMRIImage> listCTBenhNhanMRIImage = GetInfCTBenhNhanMRIImage();
                    qlND.InsertListCTBenhNhanMRIImage(listCTBenhNhanMRIImage);

                    List<CTBenhNhanSnapShot> listCTBenhNhanSnapShot = GetInfCTBenhNhanSnapShot();
                    qlND.InsertListCTBenhNhanSnapShot(listCTBenhNhanSnapShot);

                    PrintPatient(txtFileNumberPatient.Text, lblCTBenhNhan.Text);
                //}
            }
            catch (Exception)
            {
                MessageBox.Show("Save error");
            }
        }
        private bool CheckValidatePatient()
        {
            string IDnumber = txtFileNumberPatient.Text;
            if (string.IsNullOrEmpty(IDnumber))
            {
                MessageBox.Show("File number patient not empty");
                return false;
            }
            else if (qlND.GetBenhNhanByID(IDnumber) != null)
            {
                MessageBox.Show("File number is availble");
                return false;
            }
            return true;

        }
        #region InsertCTBenhNhan
        public BenhNhan GetInfBenhNhan()
        {
            BenhNhan bn = new BenhNhan();
            bn.ID = txtFileNumberPatient.Text;
            bn.DiaChi = string.Empty;
            bn.NgayKhamLanDau = (DateTime)datDateOfFirst.EditValue;
            bn.NgaySinh = DateTime.Now;
            bn.SoDT = string.Empty;
            bn.TenBN = txtNamePatient.Text;
            return bn;
        }

        Random random = new Random();
        public CTBenhNhan GetInfCTBenhNhan()
        {
            CTBenhNhan ctBN = new CTBenhNhan();
            ctBN.IDCTBenhNhan = txtFileNumberPatient.Text + random.Next(5200);
            lblCTBenhNhan.Text = ctBN.IDCTBenhNhan;
            ctBN.Comment = txtComment.Text;
            ctBN.IDBenhNhan = txtFileNumberPatient.Text;
            ctBN.NgayKham = DateTime.Now;
            ctBN.NoiKham = "HN";
            ctBN.TreatmentTime = spin_TreamentWeek.Text;
            ctBN.TreatmentTimeFor = spin_TreamentMonth.Text;
            ctBN.TreatmentTimeTotal = int.Parse(lblTotalTreament.Text);
            return ctBN;
        }
        public List<CTBenhNhanComplaint> GetInfCTBenhNhanComplaint()
        {

            List<CTBenhNhanComplaint> listComplaint = new List<CTBenhNhanComplaint>();
            for (int i = 0; i < gridView_Complaint.DataRowCount; i++)
            {
                bool flag = (bool)(gridView_Complaint.GetRowCellValue(i, "Select"));
                if (flag)
                {
                    CTBenhNhanComplaint cp = new CTBenhNhanComplaint();
                    cp.IDComplaint = (int)(gridView_Complaint.GetRowCellValue(i, "Ma"));
                    cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                    cp.TenComplaint = gridView_Complaint.GetRowCellValue(i, "Ten").ToString();
                    listComplaint.Add(cp);
                }
            }
            return listComplaint;
        }
        public List<CTBenhNhanMRIImage> GetInfCTBenhNhanMRIImage()
        {

            List<CTBenhNhanMRIImage> listMRIImage = new List<CTBenhNhanMRIImage>();
            for (int i = 0; i < gridView_MRI.DataRowCount; i++)
            {
                bool flag = (bool)(gridView_MRI.GetRowCellValue(i, "Select"));
                if (flag)
                {
                    CTBenhNhanMRIImage cp = new CTBenhNhanMRIImage();
                    cp.IDMRIImage = (int)(gridView_MRI.GetRowCellValue(i, "Ma"));
                    cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                    cp.TenMRIImage = gridView_MRI.GetRowCellValue(i, "Ten").ToString();
                    listMRIImage.Add(cp);
                }
            }
            return listMRIImage;
        }
        public List<CTBenhNhanConditionDicsJoint> GetInfCTBenhNhanConditionDicsJoint()
        {

            List<CTBenhNhanConditionDicsJoint> listConditionDicsJoint = new List<CTBenhNhanConditionDicsJoint>();
            for (int i = 0; i < gridView_DiscJoint.DataRowCount; i++)
            {
                CTBenhNhanConditionDicsJoint cp = new CTBenhNhanConditionDicsJoint();
                cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                cp.Bulging = (bool)(gridView_DiscJoint.GetRowCellValue(i, "Bulging"));
                cp.Degenerated = (bool)(gridView_DiscJoint.GetRowCellValue(i, "Degenerated"));
                cp.DiscJoint = gridView_DiscJoint.GetRowCellValue(i, "Ten").ToString();
                cp.FacetSyndrome = (bool)(gridView_DiscJoint.GetRowCellValue(i, "FacetSynrome"));
                cp.Herniated = (bool)(gridView_DiscJoint.GetRowCellValue(i, "Herniated"));
                cp.Spondyjo = (bool)(gridView_DiscJoint.GetRowCellValue(i, "Spondylo"));
                cp.Stenosis = (bool)(gridView_DiscJoint.GetRowCellValue(i, "Stenois"));
                if ((bool)cp.Bulging || (bool)cp.Degenerated || (bool)cp.FacetSyndrome || (bool)cp.Herniated || (bool)cp.Spondyjo || (bool)cp.Stenosis)
                {
                    listConditionDicsJoint.Add(cp);
                }
            }
            return listConditionDicsJoint;
        }
        public CTBenhNhanCondition GetInfCTBenhNhanCondition()
        {
            CTBenhNhanCondition bnCon = new CTBenhNhanCondition();
            bnCon.Ankle = chkAnkleSprain.Checked;
            bnCon.Elbow = chkLateral.Checked;
            bnCon.FootPlantar = chkPlantar.Checked;
            bnCon.FootPronation = chkPronation.Checked;
            bnCon.FootSupination = chkSupination.Checked;
            bnCon.Hip = chkDegenerationHip.Checked;
            bnCon.IDCTBenhNhan = lblCTBenhNhan.Text;
            bnCon.KneeACL = chkALC.Checked;
            bnCon.KneeDegeneration = chkDegenerationKnee.Checked;
            bnCon.KneeMCL = chkMLC.Checked;
            bnCon.KneeMeniscus = chkMeniscus.Checked;
            bnCon.PostureHyperLordosis = chkHyper.Checked;
            bnCon.PostureKyphosis = chkKyphosis.Checked;
            bnCon.SacroiliacDegeneration = chkDegenerated.Checked;
            bnCon.SacroiliacInbalance = chkImbalance.Checked;
            bnCon.SacroiliacInflammation = chkInflammation.Checked;
            bnCon.SacroiliacNormail = chkNormal.Checked;
            bnCon.ScoliosisCervico = chkCervivo.Checked;
            bnCon.ScoliosisCervival = chkCervival.Checked;
            bnCon.ScoliosisLumbar = chkLumber.Checked;
            bnCon.ScoliosisThoracic = chkThoracic.Checked;
            bnCon.ScoliosisThoracolumbar = chkThoracolumbar.Checked;
            bnCon.ShoulderACJoint = chkShoulderACJoint.Checked;
            bnCon.ShoulderAdhesive = chkShoulderAdhesive.Checked;
            bnCon.ShoulderBursitis = chkBursitis.Checked;
            bnCon.ShoulderImpingement = chkShoulderImpingement.Checked;
            bnCon.ShoulderRotator = chkShoulderRotatorCuff.Checked;
            bnCon.Wrist = chkWrist.Checked;
            return bnCon;
        }
        public List<CTBenhNhanConditionVertebral> GetInfCTBenhNhanConditionVertebral()
        {

            List<CTBenhNhanConditionVertebral> listConditionDicsJoint = new List<CTBenhNhanConditionVertebral>();
            for (int i = 0; i < gridView_DiscJoint.DataRowCount; i++)
            {
                CTBenhNhanConditionVertebral cp = new CTBenhNhanConditionVertebral();
                cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                cp.Degenerative = (bool)(gridView_Vertebral.GetRowCellValue(i, "DegenerativeStenosis"));
                cp.Mild = (bool)(gridView_Vertebral.GetRowCellValue(i, "MidDegeneration"));
                cp.Vertebrae = gridView_Vertebral.GetRowCellValue(i, "Ten").ToString();
                cp.Severe = (bool)(gridView_Vertebral.GetRowCellValue(i, "SevereDegeneration"));
                cp.Subluxation = (bool)(gridView_Vertebral.GetRowCellValue(i, "Subluxation"));
                cp.Moderate = (bool)(gridView_Vertebral.GetRowCellValue(i, "ModerateDegeneration"));
                if ((bool)cp.Degenerative || (bool)cp.Mild || (bool)cp.Severe || (bool)cp.Subluxation || (bool)cp.Moderate)
                {
                    listConditionDicsJoint.Add(cp);
                }
            }
            return listConditionDicsJoint;
        }
        public List<CTBenhNhanExcercise> GetInfCTBenhNhanExcercise()
        {
            List<CTBenhNhanExcercise> listExcercise = new List<CTBenhNhanExcercise>();
            for (int i = 0; i < gridView_Excercise.DataRowCount; i++)
            {
                bool flag = (bool)(gridView_Excercise.GetRowCellValue(i, "Prints"));
                if (flag)
                {
                    CTBenhNhanExcercise cp = new CTBenhNhanExcercise();
                    cp.IDExcercises = (int)(gridView_Excercise.GetRowCellValue(i, "ID"));
                    cp.Do = (int)gridView_Excercise.GetRowCellValue(i, "Do");
                    cp.Hold = (int)gridView_Excercise.GetRowCellValue(i, "Hold");
                    cp.Repeat = (int)gridView_Excercise.GetRowCellValue(i, "Repeat");
                    cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                    listExcercise.Add(cp);
                }
            }
            return listExcercise;
        }
        public List<CTBenhNhanSnapShot> GetInfCTBenhNhanSnapShot()
        {
            List<CTBenhNhanSnapShot> listSnapShot = new List<CTBenhNhanSnapShot>();
            for (int i = 0; i < gridView_SnapShot.DataRowCount; i++)
            {
                CTBenhNhanSnapShot snapshot = new CTBenhNhanSnapShot();
                //FileStream fs = new FileStream("Image", FileMode.Create, FileAccess.Write);
                //fs.Write(rawData, 0, fileSize);

                Binary imageBytes = (Binary)(gridView_SnapShot.GetRowCellValue(i, "URL"));
                snapshot.URL = imageBytes;
                snapshot.IDCTBenhNhan = lblCTBenhNhan.Text;
                listSnapShot.Add(snapshot);
            }
            return listSnapShot;
        }
        public void PrintPatient(string IDBenhNhan, string IDCTBenhNhan)
        {

            //var rowHandle = gridView_CuocGoi.FocusedRowHandle;
            //// Get the value for the given column - convert to the type you're expecting
            //string IDBenhNhan = gridView_CuocGoi.GetRowCellValue(rowHandle, "IDBenhNhan").ToString();
            //string IDCTBenhNhan = gridView_CuocGoi.GetRowCellValue(rowHandle, "IDCTBenhNhan").ToString();
            //LoadList
            List<CTBenhNhanComplaint> listComplaint = qlND.GetDSCTBenhNhanComplaintByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanMRIImage> listMRIImage = qlND.GetDSCTBenhNhanMRIImageByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanCondition> listCondition = qlND.GetDSCTBenhNhanConditionByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanConditionDicsJoint> listConditionDicsJoint = qlND.GetDSCTBenhNhanConditionDicsJointByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanConditionVertebral> listConditionVertebral = qlND.GetDSCTBenhNhanConditionVertebralByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanExcercise> listExcercise = qlND.GetDSCTBenhNhanExcerciseByIDCTBenhNhan(IDCTBenhNhan);
            List<CTBenhNhanSnapShot> listSnapShot = qlND.GetDSCTBenhNhanSnapShotByIDCTBenhNhan(IDCTBenhNhan);
            CTBenhNhan cTBenhNhan = qlND.GetCTBenhNhanByIDCTBenhNhan(IDCTBenhNhan).SingleOrDefault();
            BenhNhan benhNhan = qlND.GetBenhNhanByID(IDBenhNhan);
            List<sp_GetDSExcerciseByIDCTBNResult> listEx = qlND.GetDSExcerciseByIDCTBN(IDCTBenhNhan);

            rptPatientMedical rptAll = new rptPatientMedical();

            //rptAll.parThangNam.Value = string.Format("DANH SÁCH CUỘC GỌI TỪ KHÁCH HÀNG THÁNG {0}/{1}", thang, nam);
            //rptAll.parThangNam.Visible = false;

            //rptAll.DataSource = list;
            //BindToBand
            DetailReportBand cTBenhNhanComplaint = rptAll.Bands["DetailReport_Complant"] as DetailReportBand;
            cTBenhNhanComplaint.DataSource = listComplaint;
            DetailReportBand cTBenhNhanMRIImage = rptAll.Bands["DetailReport_MRI"] as DetailReportBand;
            cTBenhNhanMRIImage.DataSource = listMRIImage;
            DetailReportBand cTBenhNhanDicsJoint = rptAll.Bands["DetailReport_DiscAndJoint"] as DetailReportBand;
            cTBenhNhanDicsJoint.DataSource = listConditionDicsJoint;

            DetailReportBand cTBenhNhanAnkle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
            cTBenhNhanAnkle.DataSource = listCondition;
            DetailReportBand DetailReport_Ankle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
            DetailReport_Ankle.DataSource = listCondition;
            DetailReportBand DetailReport_Elbow = rptAll.Bands["DetailReport_Elbow"] as DetailReportBand;
            DetailReport_Elbow.DataSource = listCondition;
            DetailReportBand DetailReport_Foot = rptAll.Bands["DetailReport_Foot"] as DetailReportBand;
            DetailReport_Foot.DataSource = listCondition;
            DetailReportBand DetailReport_Hip = rptAll.Bands["DetailReport_Hip"] as DetailReportBand;
            DetailReport_Hip.DataSource = listCondition;
            DetailReportBand DetailReport_Knee = rptAll.Bands["DetailReport_Knee"] as DetailReportBand;
            DetailReport_Knee.DataSource = listCondition;
            DetailReportBand DetailReport_Posture = rptAll.Bands["DetailReport_Posture"] as DetailReportBand;
            DetailReport_Posture.DataSource = listCondition;
            DetailReportBand DetailReport_Sacroiliac = rptAll.Bands["DetailReport_Sacroiliac"] as DetailReportBand;
            DetailReport_Sacroiliac.DataSource = listCondition;
            DetailReportBand DetailReport_Scoliosis = rptAll.Bands["DetailReport_Scoliosis"] as DetailReportBand;
            DetailReport_Scoliosis.DataSource = listCondition;
            DetailReportBand DetailReport_Shoulder = rptAll.Bands["DetailReport_Shoulder"] as DetailReportBand;
            DetailReport_Shoulder.DataSource = listCondition;
            DetailReportBand DetailReport_Wrist = rptAll.Bands["DetailReport_Wrist"] as DetailReportBand;
            DetailReport_Wrist.DataSource = listCondition;

            DetailReportBand cTBenhNhanVertebral = rptAll.Bands["DetailReport_Vertebral"] as DetailReportBand;
            cTBenhNhanVertebral.DataSource = listConditionVertebral;
            DetailReportBand cTBenhNhanSnap = rptAll.Bands["DetailReport_Snap"] as DetailReportBand;
            cTBenhNhanSnap.DataSource = listSnapShot;
            DetailReportBand DetailReport_Excercises = rptAll.Bands["DetailReport_Excercises"] as DetailReportBand;
            DetailReport_Excercises.DataSource = listEx;
            //DetailReportBand cTBenhNhanComment = rptAll.Bands["DetailReport_Comment"] as DetailReportBand;
            //cTBenhNhanComment.DataSource = cTBenhNhan.Comment;


            rptAll.parComment.Value = cTBenhNhan.Comment.ToString();
            rptAll.parComment.Visible = false;
            rptAll.parDate.Value = cTBenhNhan.NgayKham.ToString();
            rptAll.parDate.Visible = false;
            rptAll.parFileNumber.Value = benhNhan.ID.ToString();
            rptAll.parFileNumber.Visible = false;
            rptAll.parName.Value = benhNhan.TenBN.ToString();
            rptAll.parName.Visible = false;
            rptAll.parTreamentFor.Value = cTBenhNhan.TreatmentTimeFor.ToString();
            rptAll.parTreamentFor.Visible = false;
            rptAll.parTreamentTime.Value = cTBenhNhan.TreatmentTime.ToString();
            rptAll.parTreamentTime.Visible = false;
            rptAll.parTreamentTotal.Value = cTBenhNhan.TreatmentTimeFor.ToString();
            rptAll.parTreamentTotal.Visible = false;


            ReportPrintTool tool = new ReportPrintTool(rptAll);
            //tool.PreviewForm.Shown += new EventHandler(PreviewForm_Shown);
            tool.ShowPreviewDialog();
        }
        #endregion

        private void frmSystem_ListPatient_AddNew_Load(object sender, EventArgs e)
        {
            txtFileNumberPatient.Text = BN.ID;
            txtNamePatient.Text = BN.TenBN;
            datDateOfFirst.EditValue = BN.NgayKhamLanDau;

            txtTime.Text = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString();
            datDateTime.EditValue = DateTime.Now;
            //datDateOfFirst.EditValue = DateTime.Now;


            labelControl30.Text = "AC Joint" + Environment.NewLine + "Adhesions";
            labelControl29.Text = "Rotator Cuff" + Environment.NewLine + "Tear";
            labelControl28.Text = "Impingement" + Environment.NewLine + "Syndrome";
            labelControl27.Text = "Adhesive" + Environment.NewLine + "Caspulitis";
            labelControl32.Text = "Carpal Tunnel" + Environment.NewLine + "Syndrome";

            //Bind to gridview
            List<Complaint> listComplaint = Common.GetDSComplaint();
            grid_Complaint.DataSource = listComplaint;

            gridLUEComplaint.Properties.DataSource = listComplaint;
            gridLUEComplaint.Properties.View.OptionsSelection.MultiSelect = true;

            List<MRIImage> listMRIImage = Common.GetDSMRIImage();
            grid_MRIImage.DataSource = listMRIImage;
            List<DiscAndJoint> listDiscAndJoint = Common.GetDSDiscAndJoint();
            grid_DiscJoint.DataSource = listDiscAndJoint;
            List<Vertebral> listVertebral = Common.GetDSVertebral();
            grid_Vertebrae.DataSource = listVertebral;
            List<sp_GetDSCommentsResult> listComments = qlND.GetDSComments();
            grid_Comments.DataSource = listComments;
            List<sp_GetDSExercisesResult> listExercises = qlND.GetDSExercises();
            grid_Exercises.DataSource = listExercises;
        }
    }
}