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
using PMS.Report;
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
using DevExpress.XtraReports.UI;
using DevExpress.XtraPrinting.Preview;
using DevExpress.XtraPrinting.Preview.Native;
using DevExpress.XtraPrinting;
using DevExpress.XtraRichEdit;

namespace PMS
{
    public partial class frmSystem_ListPatient_History : DevExpress.XtraEditors.XtraForm
    {
        clsQLNguoiDung qlND;
        private string _MaBN;
        public string MaBN
        {
            get { return _MaBN; }
            set
            {
                _MaBN = value;
            }
        }
        public frmSystem_ListPatient_History()
        {
            InitializeComponent();
            qlND = new clsQLNguoiDung();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {

            var rowHandle = gridView_CuocGoi.FocusedRowHandle;
            // Get the value for the given column - convert to the type you're expecting
            string IDBenhNhan = gridView_CuocGoi.GetRowCellValue(rowHandle, "IDBenhNhan").ToString();
            string IDCTBenhNhan = gridView_CuocGoi.GetRowCellValue(rowHandle, "IDCTBenhNhan").ToString();
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
            if (listComplaint.Count > 0)
            {
                cTBenhNhanComplaint.DataSource = listComplaint;
            }
            else
            {
                cTBenhNhanComplaint.Visible = false;
            }

            DetailReportBand cTBenhNhanMRIImage = rptAll.Bands["DetailReport_MRI"] as DetailReportBand;
            if (listMRIImage.Count > 0)
            {
                cTBenhNhanMRIImage.DataSource = listMRIImage;
            }
            else
            {
                cTBenhNhanMRIImage.Visible = false;
            }

            DetailReportBand cTBenhNhanDicsJoint = rptAll.Bands["DetailReport_DiscAndJoint"] as DetailReportBand;
            if (listConditionDicsJoint.Count > 0)
            {
                cTBenhNhanDicsJoint.DataSource = listConditionDicsJoint;
            }
            else
            {
                cTBenhNhanDicsJoint.Visible = false;
            }

            //List<CTBenhNhanCondition> listCondition = qlND.GetDSCTBenhNhanConditionByIDCTBenhNhan(lblCTBenhNhan.Text);
            ////DetailReportBand cTBenhNhanAnkle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
            ////cTBenhNhanAnkle.DataSource = cTBenhNhanConditions;
            //List<CTBenhNhanCondition> listCondition = new List<CTBenhNhanCondition>();
            //listCondition.Add(cTBenhNhanConditions);
            DetailReportBand DetailReport_Ankle = rptAll.Bands["DetailReport_Ankle"] as DetailReportBand;
            DetailReportBand DetailReport_Elbow = rptAll.Bands["DetailReport_Elbow"] as DetailReportBand;
            DetailReportBand DetailReport_Foot = rptAll.Bands["DetailReport_Foot"] as DetailReportBand;
            DetailReportBand DetailReport_Hip = rptAll.Bands["DetailReport_Hip"] as DetailReportBand;
            DetailReportBand DetailReport_Knee = rptAll.Bands["DetailReport_Knee"] as DetailReportBand;
            DetailReportBand DetailReport_Posture = rptAll.Bands["DetailReport_Posture"] as DetailReportBand;
            DetailReportBand DetailReport_Sacroiliac = rptAll.Bands["DetailReport_Sacroiliac"] as DetailReportBand;
            DetailReportBand DetailReport_Scoliosis = rptAll.Bands["DetailReport_Scoliosis"] as DetailReportBand;
            DetailReportBand DetailReport_Shoulder = rptAll.Bands["DetailReport_Shoulder"] as DetailReportBand;
            DetailReportBand DetailReport_Wrist = rptAll.Bands["DetailReport_Wrist"] as DetailReportBand;
            if (listCondition.Count > 0)
            {
                if ((bool)listCondition[0].Ankle)
                {
                    DetailReport_Ankle.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Ankle.Visible = false;
                }

                if ((bool)listCondition[0].Elbow)
                {
                    DetailReport_Elbow.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Elbow.Visible = false;
                }

                if ((bool)listCondition[0].FootPlantar || (bool)listCondition[0].FootPronation || (bool)listCondition[0].FootSupination)
                {
                    DetailReport_Foot.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Foot.Visible = false;
                }

                if ((bool)listCondition[0].Hip)
                {
                    DetailReport_Hip.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Hip.Visible = false;
                }

                if ((bool)listCondition[0].KneeACL || (bool)listCondition[0].KneeDegeneration || (bool)listCondition[0].KneeMCL || (bool)listCondition[0].KneeMeniscus)
                {
                    DetailReport_Knee.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Knee.Visible = false;
                }

                if ((bool)listCondition[0].PostureHyperLordosis || (bool)listCondition[0].PostureKyphosis)
                {
                    DetailReport_Posture.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Posture.Visible = false;
                }

                if ((bool)listCondition[0].SacroiliacDegeneration || (bool)listCondition[0].SacroiliacInbalance || (bool)listCondition[0].SacroiliacInflammation || (bool)listCondition[0].SacroiliacNormail)
                {
                    DetailReport_Sacroiliac.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Sacroiliac.Visible = false;
                }

                if ((bool)listCondition[0].ScoliosisCervico || (bool)listCondition[0].ScoliosisCervival || (bool)listCondition[0].ScoliosisLumbar || (bool)listCondition[0].ScoliosisThoracic || (bool)listCondition[0].ScoliosisThoracolumbar)
                {
                    DetailReport_Scoliosis.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Scoliosis.Visible = false;
                }

                if ((bool)listCondition[0].ShoulderACJoint || (bool)listCondition[0].ShoulderAdhesive || (bool)listCondition[0].ShoulderBursitis || (bool)listCondition[0].ShoulderImpingement || (bool)listCondition[0].ShoulderRotator)
                {
                    DetailReport_Shoulder.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Shoulder.Visible = false;
                }

                if ((bool)listCondition[0].Wrist)
                {
                    DetailReport_Wrist.DataSource = listCondition;
                }
                else
                {
                    DetailReport_Wrist.Visible = false;
                }
            }
            else
            {
                DetailReport_Ankle.Visible = false;
                DetailReport_Elbow.Visible = false;
                DetailReport_Foot.Visible = false;
                DetailReport_Hip.Visible = false;
                DetailReport_Knee.Visible = false;
                DetailReport_Posture.Visible = false;
                DetailReport_Sacroiliac.Visible = false;
                DetailReport_Scoliosis.Visible = false;
                DetailReport_Shoulder.Visible = false;
                DetailReport_Wrist.Visible = false;
            }
            DetailReportBand cTBenhNhanVertebral = rptAll.Bands["DetailReport_Vertebral"] as DetailReportBand;
            if (listConditionVertebral.Count > 0)
            {
                cTBenhNhanVertebral.DataSource = listConditionVertebral;
            }
            else
            {
                cTBenhNhanVertebral.Visible = false;
            }

            DetailReportBand cTBenhNhanSnap = rptAll.Bands["DetailReport_Snap"] as DetailReportBand;
            if (listSnapShot.Count > 0)
            {
                cTBenhNhanSnap.DataSource = listSnapShot;
            }
            else
            {
                cTBenhNhanSnap.Visible = false;
            }


            DetailReportBand DetailReport_Excercises = rptAll.Bands["DetailReport_Excercises"] as DetailReportBand;
            if (listEx.Count > 0)
            {
                DetailReport_Excercises.DataSource = listEx;
            }
            else
            {
                DetailReport_Excercises.Visible = false;
            }


            if (cTBenhNhan.Comment.Trim().Length > 0)
            {
                rptAll.parComment.Value = cTBenhNhan.Comment.ToString();
                rptAll.parComment.Visible = false;
            }
            else
            {
                DetailReportBand DetailReport_Comment = rptAll.Bands["DetailReport_Comment"] as DetailReportBand;
                DetailReport_Comment.Visible = false;
                rptAll.parComment.Value = cTBenhNhan.Comment.ToString();
                rptAll.parComment.Visible = false;
            }

            string phone = ConfigurationManager.AppSettings["Phone"].ToString();
            string address = ConfigurationManager.AppSettings["Address"].ToString();
            rptAll.parPhone.Value = phone;
            rptAll.parPhone.Visible = false;
            rptAll.parDiaChi.Value = address;
            rptAll.parDiaChi.Visible = false;

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

        private void frmSystem_ListPatient_History_Load(object sender, EventArgs e)
        {
            List<CTBenhNhan> listCTBenhNhan = qlND.GetCTBenhNhanByIDBenhNhan(MaBN);
            gridControl_GoiDien.DataSource = listCTBenhNhan;
        }
    }
}