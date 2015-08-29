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
using PMS.Report;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Preview.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraLayout;

namespace PMS
{
    public partial class frmSystem_AddPatient_v2 : DevExpress.XtraEditors.XtraForm
    {
        clsQLNguoiDung qlND;
        public frmSystem_AddPatient_v2()
        {
            InitializeComponent();
            ResizeForm();
            qlND = new clsQLNguoiDung();
        }

        void NgayThangNamGio()
        {
            Timer t = new Timer { Interval = 1000 };
            t.Start();
            t.Tick += t_Tick;
        }
        string Gio;
        void t_Tick(object sender, EventArgs e)
        {
            Gio = DateTime.Now.ToLongTimeString();
            txtTime.Text = String.Format("{0}", Gio); ;
        }

        private void frmSystem_AddPatient_Load(object sender, EventArgs e)
        {
            txtFileNumberPatient.Properties.MaxLength = 6;
            txtFileNumberPatient.Properties.Mask.EditMask = "\\d+";
            txtFileNumberPatient.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            //txtTime.Text = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString();
            NgayThangNamGio();
            datDateTime.EditValue = DateTime.Now;
            datDateOfFirst.EditValue = DateTime.Now;


            labelControl30.Text = "AC Joint" + Environment.NewLine + "Adhesions";
            labelControl29.Text = "Rotator Cuff" + Environment.NewLine + "Tear";
            labelControl28.Text = "Impingement" + Environment.NewLine + "Syndrome";
            labelControl27.Text = "Adhesive" + Environment.NewLine + "Caspulitis";
            labelControl32.Text = "Carpal Tunnel" + Environment.NewLine + "Syndrome";

            //Bind to gridview
            List<Complaint> listComplaint = Common.GetDSComplaint();
            grid_Complaint.DataSource = listComplaint;


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

        public delegate void AddItemDelegate(CTBenhNhanExcercise CTBenhNhan, bool check);
        private void AddItemCallback(CTBenhNhanExcercise CTBenhNhan, bool check)
        {
            //insert Chon (bool)(gridView_Excercise.GetRowCellValue(i, "Prints"));
            if (check)
            {
                for (int i = 0; i < gridView_Excercise.DataRowCount; i++)
                {
                    int ID = int.Parse(gridView_Excercise.GetRowCellValue(i, "ID").ToString());
                    if (ID == CTBenhNhan.IDExcercises)
                    {
                        gridView_Excercise.SetRowCellValue(i, "Hold", CTBenhNhan.Hold);
                        gridView_Excercise.SetRowCellValue(i, "Do", CTBenhNhan.Do);
                        gridView_Excercise.SetRowCellValue(i, "Repeat", CTBenhNhan.Repeat);
                        if (gridView_Excercise.GetRowCellValue(i, "Move") != null)
                        {
                            gridView_Excercise.SetRowCellValue(i, "Resistance", CTBenhNhan.Resistance);
                            gridView_Excercise.SetRowCellValue(i, "Range", CTBenhNhan.Range);
                            gridView_Excercise.SetRowCellValue(i, "Direction", CTBenhNhan.Direction);
                        }
                        gridView_Excercise.SetRowCellValue(i, "Prints", true);
                    }
                }
            }
            else
            {
                for (int i = 0; i < gridView_Excercise.DataRowCount; i++)
                {
                    int ID = int.Parse(gridView_Excercise.GetRowCellValue(i, "ID").ToString());
                    if (ID == CTBenhNhan.IDExcercises)
                    {
                        gridView_Excercise.SetRowCellValue(i, "Prints", check);
                    }
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
                ex.URLImage = gridView_Excercise.GetRowCellValue(rowHandle, "img").ToString();
                if (gridView_Excercise.GetRowCellValue(rowHandle, "Move") != null)
                    ex.Move = (int)gridView_Excercise.GetRowCellValue(rowHandle, "Move");
                else
                    ex.Move = 0;
                gridView_Excercise.SetRowCellValue(rowHandle, "Prints", true);

                frm_AddPatient_ExerciseOptions child = new frm_AddPatient_ExerciseOptions { EX = ex };
                child.AddItemCallback = new AddItemDelegate(this.AddItemCallback);
                child.ShowDialog();
            }
            else
            {
                gridView_Excercise.SetRowCellValue(rowHandle, "Hold", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Do", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Repeat", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Range", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Resistance", null);
                gridView_Excercise.SetRowCellValue(rowHandle, "Direction", null);
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

        //private void btnAddComment_Click(object sender, EventArgs e)
        //{
        //    insert Chon
        //    for (int i = 0; i < gridView_Comment.DataRowCount; i++)
        //    {
        //        bool Selects = bool.Parse(gridView_Comment.GetRowCellValue(i, "Selects").ToString());
        //        if (Selects)
        //        {
        //            txtComment.Text = txtComment.Text + gridView_Comment.GetRowCellValue(i, "ChiTiet").ToString() + "\n";
        //            gridView_Comment.SetRowCellValue(i, "Selects", false);
        //        }
        //    }
        //}

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
                if (CheckValidatePatient())
                {
                    BenhNhan bn = GetInfBenhNhan();
                    qlND.InsertBenhNhan(bn);

                    CTBenhNhan ctbn = GetInfCTBenhNhan();
                    qlND.InsertCTBenhNhan(ctbn);

                    List<CTBenhNhanComplaint> listComplaint = GetInfCTBenhNhanComplaint();

                    List<CTBenhNhanConditionDicsJoint> listDiscJoint = GetInfCTBenhNhanConditionDicsJoint();

                    CTBenhNhanCondition cTBenhNhanConditions = GetInfCTBenhNhanCondition();

                    List<CTBenhNhanConditionVertebral> listCTBenhNhanConditionVertebral = GetInfCTBenhNhanConditionVertebral();

                    List<CTBenhNhanExcercise> ListCTBenhNhanExcercises = GetInfCTBenhNhanExcercise();
                    qlND.InsertListCTBenhNhanExcercise(ListCTBenhNhanExcercises);

                    List<CTBenhNhanMRIImage> listCTBenhNhanMRIImage = GetInfCTBenhNhanMRIImage();

                    List<CTBenhNhanSnapShot> listCTBenhNhanSnapShot = GetInfCTBenhNhanSnapShot();

                    //PrintPatient(txtFileNumberPatient.Text, lblCTBenhNhan.Text);
                    //Print
                    rptPatientMedical rptAll = new rptPatientMedical();

                    //rptAll.parThangNam.Value = string.Format("DANH SÁCH CUỘC GỌI TỪ KHÁCH HÀNG THÁNG {0}/{1}", thang, nam);
                    //rptAll.parThangNam.Visible = false;

                    //rptAll.DataSource = list;
                    //BindToBand
                    DetailReportBand cTBenhNhanComplaint = rptAll.Bands["DetailReport_Complant"] as DetailReportBand;
                    if (listComplaint.Count > 0)
                    {
                        cTBenhNhanComplaint.DataSource = listComplaint;
                    }
                    else
                    {
                        cTBenhNhanComplaint.Visible = false;
                    }

                    DetailReportBand cTBenhNhanMRIImage = rptAll.Bands["DetailReport_MRI"] as DetailReportBand;
                    if (listCTBenhNhanMRIImage.Count > 0)
                    {
                        cTBenhNhanMRIImage.DataSource = listCTBenhNhanMRIImage;
                    }
                    else
                    {
                        cTBenhNhanMRIImage.Visible = false;
                    }

                    DetailReportBand cTBenhNhanDicsJoint = rptAll.Bands["DetailReport_DiscAndJoint"] as DetailReportBand;
                    if (listDiscJoint.Count > 0)
                    {
                        cTBenhNhanDicsJoint.DataSource = listDiscJoint;
                    }
                    else
                    {
                        cTBenhNhanDicsJoint.Visible = false;
                    }

                    //List<CTBenhNhanCondition> listCondition = qlND.GetDSCTBenhNhanConditionByIDCTBenhNhan(lblCTBenhNhan.Text);
                    ////DetailReportBand cTBenhNhanAnkle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
                    ////cTBenhNhanAnkle.DataSource = cTBenhNhanConditions;
                    List<CTBenhNhanCondition> listCondition = new List<CTBenhNhanCondition>();
                    listCondition.Add(cTBenhNhanConditions);

                    DetailReportBand DetailReport_Ankle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
                    if ((bool)listCondition[0].Ankle)
                    {
                        DetailReport_Ankle.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Ankle.Visible = false;
                    }

                    DetailReportBand DetailReport_Elbow = rptAll.Bands["DetailReport_Elbow"] as DetailReportBand;
                    if ((bool)listCondition[0].Elbow)
                    {
                        DetailReport_Elbow.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Elbow.Visible = false;
                    }

                    DetailReportBand DetailReport_Foot = rptAll.Bands["DetailReport_Foot"] as DetailReportBand;
                    if ((bool)listCondition[0].FootPlantar || (bool)listCondition[0].FootPronation || (bool)listCondition[0].FootSupination)
                    {
                        DetailReport_Foot.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Foot.Visible = false;
                    }

                    DetailReportBand DetailReport_Hip = rptAll.Bands["DetailReport_Hip"] as DetailReportBand;
                    if ((bool)listCondition[0].Hip)
                    {
                        DetailReport_Hip.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Hip.Visible = false;
                    }

                    DetailReportBand DetailReport_Knee = rptAll.Bands["DetailReport_Knee"] as DetailReportBand;
                    if ((bool)listCondition[0].KneeACL || (bool)listCondition[0].KneeDegeneration || (bool)listCondition[0].KneeMCL || (bool)listCondition[0].KneeMeniscus)
                    {
                        DetailReport_Knee.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Knee.Visible = false;
                    }

                    DetailReportBand DetailReport_Posture = rptAll.Bands["DetailReport_Posture"] as DetailReportBand;
                    if ((bool)listCondition[0].PostureHyperLordosis || (bool)listCondition[0].PostureKyphosis)
                    {
                        DetailReport_Posture.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Posture.Visible = false;
                    }

                    DetailReportBand DetailReport_Sacroiliac = rptAll.Bands["DetailReport_Sacroiliac"] as DetailReportBand;
                    if ((bool)listCondition[0].SacroiliacDegeneration || (bool)listCondition[0].SacroiliacInbalance || (bool)listCondition[0].SacroiliacInflammation || (bool)listCondition[0].SacroiliacNormail)
                    {
                        DetailReport_Sacroiliac.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Sacroiliac.Visible = false;
                    }

                    DetailReportBand DetailReport_Scoliosis = rptAll.Bands["DetailReport_Scoliosis"] as DetailReportBand;
                    if ((bool)listCondition[0].ScoliosisCervico || (bool)listCondition[0].ScoliosisCervival || (bool)listCondition[0].ScoliosisLumbar || (bool)listCondition[0].ScoliosisThoracic || (bool)listCondition[0].ScoliosisThoracolumbar)
                    {
                        DetailReport_Scoliosis.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Scoliosis.Visible = false;
                    }

                    DetailReportBand DetailReport_Shoulder = rptAll.Bands["DetailReport_Shoulder"] as DetailReportBand;
                    if ((bool)listCondition[0].ShoulderACJoint || (bool)listCondition[0].ShoulderAdhesive || (bool)listCondition[0].ShoulderBursitis || (bool)listCondition[0].ShoulderImpingement || (bool)listCondition[0].ShoulderRotator)
                    {
                        DetailReport_Shoulder.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Shoulder.Visible = false;
                    }

                    DetailReportBand DetailReport_Wrist = rptAll.Bands["DetailReport_Wrist"] as DetailReportBand;
                    if ((bool)listCondition[0].Wrist)
                    {
                        DetailReport_Wrist.DataSource = listCondition;
                    }
                    else
                    {
                        DetailReport_Wrist.Visible = false;
                    }

                    DetailReportBand cTBenhNhanVertebral = rptAll.Bands["DetailReport_Vertebral"] as DetailReportBand;
                    if (listCTBenhNhanConditionVertebral.Count > 0)
                    {
                        cTBenhNhanVertebral.DataSource = listCTBenhNhanConditionVertebral;
                    }
                    else
                    {
                        cTBenhNhanVertebral.Visible = false;
                    }

                    DetailReportBand cTBenhNhanSnap = rptAll.Bands["DetailReport_Snap"] as DetailReportBand;
                    if (listCTBenhNhanSnapShot.Count > 0)
                    {
                        cTBenhNhanSnap.DataSource = listCTBenhNhanSnapShot;
                    }
                    else
                    {
                        cTBenhNhanSnap.Visible = false;
                    }


                    List<sp_GetDSExcerciseByIDCTBNResult> listEx2 = qlND.GetDSExcerciseByIDCTBN(lblCTBenhNhan.Text);
                    DetailReportBand DetailReport_Excercises = rptAll.Bands["DetailReport_Excercises"] as DetailReportBand;
                    if (listEx2.Count > 0)
                    {
                        DetailReport_Excercises.DataSource = listEx2;
                    }
                    else
                    {
                        DetailReport_Excercises.Visible = false;
                    }


                    if (ctbn.Comment.Trim().Length > 0)
                    {
                        rptAll.parComment.Value = ctbn.Comment.ToString();
                        rptAll.parComment.Visible = false;
                    }
                    else
                    {
                        DetailReportBand DetailReport_Comment = rptAll.Bands["DetailReport_Comment"] as DetailReportBand;
                        DetailReport_Comment.Visible = false;
                        rptAll.parComment.Value = ctbn.Comment.ToString();
                        rptAll.parComment.Visible = false;
                    }

                    string phone = ConfigurationManager.AppSettings["Phone"].ToString();
                    string address = ConfigurationManager.AppSettings["Address"].ToString();
                    rptAll.parPhone.Value = phone;
                    rptAll.parPhone.Visible = false;
                    rptAll.parDiaChi.Value = address;
                    rptAll.parDiaChi.Visible = false;

                    rptAll.parDate.Value = ctbn.NgayKham.ToString();
                    rptAll.parDate.Visible = false;
                    rptAll.parFileNumber.Value = bn.ID.ToString();
                    rptAll.parFileNumber.Visible = false;
                    rptAll.parName.Value = bn.TenBN.ToString();
                    rptAll.parName.Visible = false;
                    rptAll.parTreamentFor.Value = ctbn.TreatmentTimeFor.ToString();
                    rptAll.parTreamentFor.Visible = false;
                    rptAll.parTreamentTime.Value = ctbn.TreatmentTime.ToString();
                    rptAll.parTreamentTime.Visible = false;
                    rptAll.parTreamentTotal.Value = ctbn.TreatmentTimeTotal.ToString();
                    rptAll.parTreamentTotal.Visible = false;


                    ReportPrintTool tool = new ReportPrintTool(rptAll);
                    //tool.PreviewForm.Shown += new EventHandler(PreviewForm_Shown);
                    tool.ShowPreviewDialog();
                    //insert

                    qlND.InsertListCTBenhNhanMRIImage(listCTBenhNhanMRIImage);
                    qlND.InsertListCTBenhNhanSnapShot(listCTBenhNhanSnapShot);
                    qlND.InsertListCTBenhNhanConditionVertebral(listCTBenhNhanConditionVertebral);
                    qlND.InsertCTBenhNhanCondition(cTBenhNhanConditions);
                    qlND.InsertListCTBenhNhanConditionDicsJoint(listDiscJoint);
                    qlND.InsertListCTBenhNhanComplaint(listComplaint);
                    //
                    ClearDataWhenSaveDone();
                }
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
            ctBN.Comment = AddComment();// txtComment.Text;
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
            if (!string.IsNullOrEmpty(txtComplaintOther.Text.Trim()))
            {
                CTBenhNhanComplaint cp = new CTBenhNhanComplaint();
                cp.IDComplaint = 0;
                cp.IDCTBenhNhan = lblCTBenhNhan.Text;
                cp.TenComplaint = txtComplaintOther.Text.Trim();
                listComplaint.Add(cp);
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
                cp.Moderate = (bool)(gridView_Vertebral.GetRowCellValue(i, "ModerateDegeneration"));
                cp.Subluxation = (bool)(gridView_Vertebral.GetRowCellValue(i, "Subluxation"));
                if ((bool)cp.Subluxation)
                {
                    cp.Innervation = gridView_Vertebral.GetRowCellValue(i, "Innervation").ToString();
                    cp.Possible = gridView_Vertebral.GetRowCellValue(i, "Possible").ToString();
                }
                if ((bool)(cp.Mild))
                    cp.LevelDegeneration = "Mild";
                else if ((bool)(cp.Moderate))
                    cp.LevelDegeneration = "Moderrate";
                else if ((bool)(cp.Severe))
                    cp.LevelDegeneration = "Severe";
                else
                    cp.LevelDegeneration = "None";
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
                    if (gridView_Excercise.GetRowCellValue(i, "Move") != null)
                    {
                        cp.Resistance = gridView_Excercise.GetRowCellValue(i, "Resistance").ToString();
                        cp.Range = gridView_Excercise.GetRowCellValue(i, "Range").ToString();
                        cp.Direction = gridView_Excercise.GetRowCellValue(i, "Direction").ToString();
                    }
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

            //DetailReportBand cTBenhNhanAnkle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
            //cTBenhNhanAnkle.DataSource = listCondition;
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


        private void ClearDataWhenSaveDone()
        {
            //Bind to gridview
            List<Complaint> listComplaint = Common.GetDSComplaint();
            grid_Complaint.DataSource = null;
            grid_Complaint.DataSource = listComplaint;


            List<MRIImage> listMRIImage = Common.GetDSMRIImage();
            grid_MRIImage.DataSource = null;
            grid_MRIImage.DataSource = listMRIImage;
            List<DiscAndJoint> listDiscAndJoint = Common.GetDSDiscAndJoint();
            grid_DiscJoint.DataSource = null;
            grid_DiscJoint.DataSource = listDiscAndJoint;
            List<Vertebral> listVertebral = Common.GetDSVertebral();
            grid_Vertebrae.DataSource = null;
            grid_Vertebrae.DataSource = listVertebral;
            List<sp_GetDSCommentsResult> listComments = qlND.GetDSComments();
            grid_Comments.DataSource = null;
            grid_Comments.DataSource = listComments;
            List<sp_GetDSExercisesResult> listExercises = qlND.GetDSExercises();
            grid_Exercises.DataSource = null;
            grid_Exercises.DataSource = listExercises;
            //---------
            grid_SnapShot.DataSource = null;
            txtComment.Text = "";
            txtComplaintOther.Text = "";
            txtFileNumberPatient.Text = "";
            txtNamePatient.Text = "";
            //txtTime.Text = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString();
            chkAnkleSprain.Checked = false;
            chkLateral.Checked = false;
            chkPlantar.Checked = false;
            chkPronation.Checked = false;
            chkSupination.Checked = false;
            chkDegenerationHip.Checked = false;
            lblCTBenhNhan.Text = "";
            chkALC.Checked = false;
            chkDegenerationKnee.Checked = false;
            chkMLC.Checked = false;
            chkMeniscus.Checked = false;
            chkHyper.Checked = false;
            chkKyphosis.Checked = false;
            chkDegenerated.Checked = false;
            chkImbalance.Checked = false;
            chkInflammation.Checked = false;
            chkNormal.Checked = false;
            chkCervivo.Checked = false;
            chkCervival.Checked = false;
            chkLumber.Checked = false;
            chkThoracic.Checked = false;
            chkThoracolumbar.Checked = false;
            chkShoulderACJoint.Checked = false;
            chkShoulderAdhesive.Checked = false;
            chkBursitis.Checked = false;
            chkShoulderImpingement.Checked = false;
            chkShoulderRotatorCuff.Checked = false;
            chkWrist.Checked = false;
        }
        public string AddComment()
        {
            //insert Chon
            string content = "";
            for (int i = 0; i < gridView_Comment.DataRowCount; i++)
            {
                bool Selects = bool.Parse(gridView_Comment.GetRowCellValue(i, "Selects").ToString());
                if (Selects)
                {
                    content = content + gridView_Comment.GetRowCellValue(i, "ChiTiet").ToString() + "\n";
                    //gridView_Comment.SetRowCellValue(i, "Selects", false);
                }
            }
            if (!string.IsNullOrEmpty(txtComment.Text.Trim()))
                content = content + txtComment.Text.Trim();
            return content;
        }

        private void repositoryItemChkMod_CheckedChanged(object sender, EventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView_Vertebral.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            //bool print = bool.Parse(gridView_Excercise.GetRowCellValue(rowHandle, "Prints").ToString());

            bool Moderate = (bool)(gridView_Vertebral.GetRowCellValue(rowHandle, "ModerateDegeneration"));
            if (!Moderate)
            {
                gridView_Vertebral.SetRowCellValue(rowHandle, "SevereDegeneration", false);
                gridView_Vertebral.SetRowCellValue(rowHandle, "MidDegeneration", false);
            }
        }

        private void repositoryItemChkMid_CheckedChanged(object sender, EventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView_Vertebral.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            //bool print = bool.Parse(gridView_Excercise.GetRowCellValue(rowHandle, "Prints").ToString());

            bool Mid = (bool)(gridView_Vertebral.GetRowCellValue(rowHandle, "MidDegeneration"));
            if (!Mid)
            {
                gridView_Vertebral.SetRowCellValue(rowHandle, "SevereDegeneration", false);
                gridView_Vertebral.SetRowCellValue(rowHandle, "ModerateDegeneration", false);
            }
        }

        private void repositoryItemChkSer_CheckedChanged(object sender, EventArgs e)
        {
            // Get your currently selected grid row
            var rowHandle = gridView_Vertebral.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            //bool print = bool.Parse(gridView_Excercise.GetRowCellValue(rowHandle, "Prints").ToString());

            bool Ser = (bool)(gridView_Vertebral.GetRowCellValue(rowHandle, "SevereDegeneration"));
            if (!Ser)
            {
                gridView_Vertebral.SetRowCellValue(rowHandle, "ModerateDegeneration", false);
                gridView_Vertebral.SetRowCellValue(rowHandle, "MidDegeneration", false);
            }
        }


        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != grid_Exercises) return;

            ToolTipControlInfo info = null;
            //Get the view at the current mouse position
            GridView view = grid_Exercises.GetViewAt(e.ControlMousePosition) as GridView;
            if (view == null) return;
            //Get the view's element information that resides at the current position
            GridHitInfo hi = view.CalcHitInfo(e.ControlMousePosition);
            //Display a hint for row indicator cells
            if (hi.HitTest == GridHitTest.RowIndicator)
            {
                //An object that uniquely identifies a row indicator cell
                object o = hi.HitTest.ToString() + hi.RowHandle.ToString();
                string text = gridView_Excercise.GetRowCellValue(int.Parse(hi.RowHandle.ToString()), "Note").ToString();
                info = new ToolTipControlInfo(o, text);
            }
            //Supply tooltip information if applicable, otherwise preserve default tooltip (if any)
            if (info != null)
                e.Info = info;
        }
        private void ResizeForm()
        {
            layoutControlItem_infPatient.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_infPatient.MaxSize = new System.Drawing.Size(875, 106);
            layoutControlItem_infPatient.MinSize = new System.Drawing.Size(875, 106);

            layoutControlItem_Complant.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Complant.MaxSize = new System.Drawing.Size(875, 295);
            layoutControlItem_Complant.MinSize = new System.Drawing.Size(875, 295);

            layoutControlItem_MIR.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_MIR.MaxSize = new System.Drawing.Size(875, 310);
            layoutControlItem_MIR.MinSize = new System.Drawing.Size(875, 310);

            layoutControlItem_Ankle.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Ankle.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Ankle.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Comments.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Comments.MaxSize = new System.Drawing.Size(875, 390);
            layoutControlItem_Comments.MinSize = new System.Drawing.Size(875, 390);

            layoutControlItem_Elbow.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Elbow.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Elbow.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Exercises.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Exercises.MaxSize = new System.Drawing.Size(875, 760);
            layoutControlItem_Exercises.MinSize = new System.Drawing.Size(875, 760);

            layoutControlItem_Hip.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Hip.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Hip.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Posture.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Posture.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Posture.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Sacroiliac.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Sacroiliac.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Sacroiliac.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Scoliosis.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Scoliosis.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Scoliosis.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Shoulder.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Shoulder.MaxSize = new System.Drawing.Size(875, 90);
            layoutControlItem_Shoulder.MinSize = new System.Drawing.Size(875, 90);

            layoutControlItem_Snap.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Snap.MaxSize = new System.Drawing.Size(875, 270);
            layoutControlItem_Snap.MinSize = new System.Drawing.Size(875, 270);

            layoutControlItem_Treament.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Treament.MaxSize = new System.Drawing.Size(875, 80);
            layoutControlItem_Treament.MinSize = new System.Drawing.Size(875, 80);

            layoutControlItem_Vertebral.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Vertebral.MaxSize = new System.Drawing.Size(875, 580);
            layoutControlItem_Vertebral.MinSize = new System.Drawing.Size(875, 580);

            layoutControlItem_Wrist.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Wrist.MaxSize = new System.Drawing.Size(875, 90);
            layoutControlItem_Wrist.MinSize = new System.Drawing.Size(875, 90);

            layoutControlItem_Foot.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Foot.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Foot.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Knee.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Knee.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Knee.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Save2.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Save2.MaxSize = new System.Drawing.Size(875, 60);
            layoutControlItem_Save2.MinSize = new System.Drawing.Size(875, 60);

            layoutControlItem_Disc.SizeConstraintsType = SizeConstraintsType.Custom;
            layoutControlItem_Disc.MaxSize = new System.Drawing.Size(875, 565);
            layoutControlItem_Disc.MinSize = new System.Drawing.Size(875, 565);
        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            DevExpress.XtraTab.XtraTabControl xtab = (DevExpress.XtraTab.XtraTabControl)sender;
            if (xtab.TabPages.Count == 1) return;
            int i = xtab.SelectedTabPageIndex;
            xtab.TabPages.RemoveAt(xtab.SelectedTabPageIndex);
            xtab.SelectedTabPageIndex = i - 1;
        }
    }
}