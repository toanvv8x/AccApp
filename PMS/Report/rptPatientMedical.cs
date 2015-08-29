using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data.Linq;
using System.IO;

namespace PMS.Report
{
    public partial class rptPatientMedical : DevExpress.XtraReports.UI.XtraReport
    {
        public rptPatientMedical()
        {
            InitializeComponent();
        }

        private void rptPatientMedical_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            xrLblDate.Text = string.Format("{0}", parDate.Value);
            xrLblComment.Text = string.Format("{0}", parComment.Value);
            xrLblName.Text = string.Format("{0}", parName.Value);
            xrLblFileNumber.Text = string.Format("{0}", parFileNumber.Value);
            xrLblTimeFor.Text = string.Format("Time per week {0} for {1} months", parTreamentTime.Value, parTreamentFor.Value);
            xrlblTotal.Text = string.Format("Total treatment {0}", parTreamentTotal.Value);
        }

        private void xrPictureBox2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Snap.GetCurrentColumnValue("URL") != null && !string.IsNullOrEmpty(DetailReport_Snap.GetCurrentColumnValue("URL").ToString()))
            {
                Binary bi=(Binary)(DetailReport_Snap.GetCurrentColumnValue("URL"));
                MemoryStream ms = new MemoryStream(bi.ToArray());
                xrPictureBox2.Image = Image.FromStream(ms);
                //xrPictureBox2.Image = ByteToImage(bi.ToArray());
            }
        }

        private void xrPictureBox3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Excercises.GetCurrentColumnValue("img") != null && !string.IsNullOrEmpty(DetailReport_Excercises.GetCurrentColumnValue("img").ToString()))
            {
                Binary bi = (Binary)(DetailReport_Excercises.GetCurrentColumnValue("img"));
                MemoryStream ms = new MemoryStream(bi.ToArray());
                xrPictureBox3.Image = Image.FromStream(ms);
                //xrPictureBox2.Image = ByteToImage(bi.ToArray());
            }
        }
        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;

        }

        private void xrLabel9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Ankle.GetCurrentColumnValue("Ankle") != null && !string.IsNullOrEmpty(DetailReport_Ankle.GetCurrentColumnValue("Ankle").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Ankle.GetCurrentColumnValue("Ankle").ToString());
                if (LyDoGoi)
                {
                    xrLabel9.Text = "YES";
                }
                else
                    xrLabel9.Text = "";
            }
            else
            {
                xrLabel9.Text = "";
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("Degenerated") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("Degenerated").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("Degenerated").ToString());
                if (LyDoGoi)
                {
                    xrTableCell4.Text = "YES";
                }
                else
                    xrTableCell4.Text = "";
            }
            else
            {
                xrTableCell4.Text = "";
            }
        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("Bulging") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("Bulging").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("Bulging").ToString());
                if (LyDoGoi)
                {
                    xrTableCell5.Text = "YES";
                }
                else
                    xrTableCell5.Text = "";
            }
            else
            {
                xrTableCell5.Text = "";
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("Herniated") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("Herniated").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("Herniated").ToString());
                if (LyDoGoi)
                {
                    xrTableCell6.Text = "YES";
                }
                else
                    xrTableCell6.Text = "";
            }
            else
            {
                xrTableCell6.Text = "";
            }
        }

        private void xrTableCell7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("Spondyjo") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("Spondyjo").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("Spondyjo").ToString());
                if (LyDoGoi)
                {
                    xrTableCell7.Text = "YES";
                }
                else
                    xrTableCell7.Text = "";
            }
            else
            {
                xrTableCell7.Text = "";
            }
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("Stenosis") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("Stenosis").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("Stenosis").ToString());
                if (LyDoGoi)
                {
                    xrTableCell8.Text = "YES";
                }
                else
                    xrTableCell8.Text = "";
            }
            else
            {
                xrTableCell8.Text = "";
            }
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_DiscAndJoint.GetCurrentColumnValue("FacetSyndrome") != null && !string.IsNullOrEmpty(DetailReport_DiscAndJoint.GetCurrentColumnValue("FacetSyndrome").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_DiscAndJoint.GetCurrentColumnValue("FacetSyndrome").ToString());
                if (LyDoGoi)
                {
                    xrTableCell9.Text = "YES";
                }
                else
                    xrTableCell9.Text = "";
            }
            else
            {
                xrTableCell9.Text = "";
            }
        }

        private void xrLabel14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Elbow.GetCurrentColumnValue("Elbow") != null && !string.IsNullOrEmpty(DetailReport_Elbow.GetCurrentColumnValue("Elbow").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Elbow.GetCurrentColumnValue("Elbow").ToString());
                if (LyDoGoi)
                {
                    xrLabel14.Text = "YES";
                }
                else
                    xrLabel14.Text = "";
            }
            else
            {
                xrLabel14.Text = "";
            }
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Foot.GetCurrentColumnValue("FootPronation") != null && !string.IsNullOrEmpty(DetailReport_Foot.GetCurrentColumnValue("FootPronation").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Foot.GetCurrentColumnValue("FootPronation").ToString());
                if (LyDoGoi)
                {
                    xrTableCell10.Text = "YES";
                }
                else
                    xrTableCell10.Text = "";
            }
            else
            {
                xrTableCell10.Text = "";
            }
        }

        private void xrTableCell17_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Foot.GetCurrentColumnValue("FootSupination") != null && !string.IsNullOrEmpty(DetailReport_Foot.GetCurrentColumnValue("FootSupination").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Foot.GetCurrentColumnValue("FootSupination").ToString());
                if (LyDoGoi)
                {
                    xrTableCell17.Text = "YES";
                }
                else
                    xrTableCell17.Text = "";
            }
            else
            {
                xrTableCell17.Text = "";
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Foot.GetCurrentColumnValue("FootPlantar") != null && !string.IsNullOrEmpty(DetailReport_Foot.GetCurrentColumnValue("FootPlantar").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Foot.GetCurrentColumnValue("FootPlantar").ToString());
                if (LyDoGoi)
                {
                    xrTableCell18.Text = "YES";
                }
                else
                    xrTableCell18.Text = "";
            }
            else
            {
                xrTableCell18.Text = "";
            }
        }

        private void xrLabel18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Hip.GetCurrentColumnValue("Hip") != null && !string.IsNullOrEmpty(DetailReport_Hip.GetCurrentColumnValue("Hip").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Hip.GetCurrentColumnValue("Hip").ToString());
                if (LyDoGoi)
                {
                    xrLabel18.Text = "YES";
                }
                else
                    xrLabel18.Text = "";
            }
            else
            {
                xrLabel18.Text = "";
            }
        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Knee.GetCurrentColumnValue("KneeMeniscus") != null && !string.IsNullOrEmpty(DetailReport_Knee.GetCurrentColumnValue("KneeMeniscus").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Knee.GetCurrentColumnValue("KneeMeniscus").ToString());
                if (LyDoGoi)
                {
                    xrTableCell26.Text = "YES";
                }
                else
                    xrTableCell26.Text = "";
            }
            else
            {
                xrTableCell26.Text = "";
            }
        }

        private void xrTableCell27_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Knee.GetCurrentColumnValue("KneeACL") != null && !string.IsNullOrEmpty(DetailReport_Knee.GetCurrentColumnValue("KneeACL").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Knee.GetCurrentColumnValue("KneeACL").ToString());
                if (LyDoGoi)
                {
                    xrTableCell27.Text = "YES";
                }
                else
                    xrTableCell27.Text = "";
            }
            else
            {
                xrTableCell27.Text = "";
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Knee.GetCurrentColumnValue("KneeMCL") != null && !string.IsNullOrEmpty(DetailReport_Knee.GetCurrentColumnValue("KneeMCL").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Knee.GetCurrentColumnValue("KneeMCL").ToString());
                if (LyDoGoi)
                {
                    xrTableCell28.Text = "YES";
                }
                else
                    xrTableCell28.Text = "";
            }
            else
            {
                xrTableCell28.Text = "";
            }
        }

        private void xrTableCell29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Knee.GetCurrentColumnValue("KneeDegeneration") != null && !string.IsNullOrEmpty(DetailReport_Knee.GetCurrentColumnValue("KneeDegeneration").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Knee.GetCurrentColumnValue("KneeDegeneration").ToString());
                if (LyDoGoi)
                {
                    xrTableCell29.Text = "YES";
                }
                else
                    xrTableCell29.Text = "";
            }
            else
            {
                xrTableCell29.Text = "";
            }
        }

        private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Posture.GetCurrentColumnValue("PostureKyphosis") != null && !string.IsNullOrEmpty(DetailReport_Posture.GetCurrentColumnValue("PostureKyphosis").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Posture.GetCurrentColumnValue("PostureKyphosis").ToString());
                if (LyDoGoi)
                {
                    xrTableCell32.Text = "YES";
                }
                else
                    xrTableCell32.Text = "";
            }
            else
            {
                xrTableCell32.Text = "";
            }
        }

        private void xrTableCell34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Posture.GetCurrentColumnValue("PostureHyperLordosis") != null && !string.IsNullOrEmpty(DetailReport_Posture.GetCurrentColumnValue("PostureHyperLordosis").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Posture.GetCurrentColumnValue("PostureHyperLordosis").ToString());
                if (LyDoGoi)
                {
                    xrTableCell34.Text = "YES";
                }
                else
                    xrTableCell34.Text = "";
            }
            else
            {
                xrTableCell34.Text = "";
            }
        }

        private void xrTableCell38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacNormail") != null && !string.IsNullOrEmpty(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacNormail").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacNormail").ToString());
                if (LyDoGoi)
                {
                    xrTableCell38.Text = "YES";
                }
                else
                    xrTableCell38.Text = "";
            }
            else
            {
                xrTableCell38.Text = "";
            }
        }

        private void xrTableCell39_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInbalance") != null && !string.IsNullOrEmpty(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInbalance").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInbalance").ToString());
                if (LyDoGoi)
                {
                    xrTableCell39.Text = "YES";
                }
                else
                    xrTableCell39.Text = "";
            }
            else
            {
                xrTableCell39.Text = "";
            }
        }

        private void xrTableCell40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInflammation") != null && !string.IsNullOrEmpty(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInflammation").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacInflammation").ToString());
                if (LyDoGoi)
                {
                    xrTableCell40.Text = "YES";
                }
                else
                    xrTableCell40.Text = "";
            }
            else
            {
                xrTableCell40.Text = "";
            }
        }

        private void xrTableCell41_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacDegeneration") != null && !string.IsNullOrEmpty(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacDegeneration").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Sacroiliac.GetCurrentColumnValue("SacroiliacDegeneration").ToString());
                if (LyDoGoi)
                {
                    xrTableCell41.Text = "YES";
                }
                else
                    xrTableCell41.Text = "";
            }
            else
            {
                xrTableCell41.Text = "";
            }
        }

        private void xrTableCell47_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervival") != null && !string.IsNullOrEmpty(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervival").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervival").ToString());
                if (LyDoGoi)
                {
                    xrTableCell47.Text = "YES";
                }
                else
                    xrTableCell47.Text = "";
            }
            else
            {
                xrTableCell47.Text = "";
            }
        }

        private void xrTableCell49_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracic") != null && !string.IsNullOrEmpty(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracic").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracic").ToString());
                if (LyDoGoi)
                {
                    xrTableCell49.Text = "YES";
                }
                else
                    xrTableCell49.Text = "";
            }
            else
            {
                xrTableCell49.Text = "";
            }
        }

        private void xrTableCell48_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervico") != null && !string.IsNullOrEmpty(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervico").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisCervico").ToString());
                if (LyDoGoi)
                {
                    xrTableCell48.Text = "YES";
                }
                else
                    xrTableCell48.Text = "";
            }
            else
            {
                xrTableCell48.Text = "";
            }
        }

        private void xrTableCell50_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracolumbar") != null && !string.IsNullOrEmpty(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracolumbar").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisThoracolumbar").ToString());
                if (LyDoGoi)
                {
                    xrTableCell50.Text = "YES";
                }
                else
                    xrTableCell50.Text = "";
            }
            else
            {
                xrTableCell50.Text = "";
            }
        }

        private void xrTableCell51_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisLumbar") != null && !string.IsNullOrEmpty(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisLumbar").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Scoliosis.GetCurrentColumnValue("ScoliosisLumbar").ToString());
                if (LyDoGoi)
                {
                    xrTableCell51.Text = "YES";
                }
                else
                    xrTableCell51.Text = "";
            }
            else
            {
                xrTableCell51.Text = "";
            }
        }

        private void xrTableCell57_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Shoulder.GetCurrentColumnValue("ShoulderBursitis") != null && !string.IsNullOrEmpty(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderBursitis").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderBursitis").ToString());
                if (LyDoGoi)
                {
                    xrTableCell57.Text = "YES";
                }
                else
                    xrTableCell57.Text = "";
            }
            else
            {
                xrTableCell57.Text = "";
            }
        }

        private void xrTableCell58_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Shoulder.GetCurrentColumnValue("ShoulderACJoint") != null && !string.IsNullOrEmpty(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderACJoint").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderACJoint").ToString());
                if (LyDoGoi)
                {
                    xrTableCell58.Text = "YES";
                }
                else
                    xrTableCell58.Text = "";
            }
            else
            {
                xrTableCell58.Text = "";
            }
        }

        private void xrTableCell59_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Shoulder.GetCurrentColumnValue("ShoulderRotator") != null && !string.IsNullOrEmpty(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderRotator").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderRotator").ToString());
                if (LyDoGoi)
                {
                    xrTableCell59.Text = "YES";
                }
                else
                    xrTableCell59.Text = "";
            }
            else
            {
                xrTableCell59.Text = "";
            }
        }

        private void xrTableCell60_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Shoulder.GetCurrentColumnValue("ShoulderImpingement") != null && !string.IsNullOrEmpty(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderImpingement").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderImpingement").ToString());
                if (LyDoGoi)
                {
                    xrTableCell60.Text = "YES";
                }
                else
                    xrTableCell60.Text = "";
            }
            else
            {
                xrTableCell60.Text = "";
            }
        }

        private void xrTableCell61_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Shoulder.GetCurrentColumnValue("ShoulderAdhesive") != null && !string.IsNullOrEmpty(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderAdhesive").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Shoulder.GetCurrentColumnValue("ShoulderAdhesive").ToString());
                if (LyDoGoi)
                {
                    xrTableCell61.Text = "YES";
                }
                else
                    xrTableCell61.Text = "";
            }
            else
            {
                xrTableCell61.Text = "";
            }
        }

        private void xrTableCell69_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Vertebral.GetCurrentColumnValue("Subluxation") != null && !string.IsNullOrEmpty(DetailReport_Vertebral.GetCurrentColumnValue("Subluxation").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Vertebral.GetCurrentColumnValue("Subluxation").ToString());
                if (LyDoGoi)
                {
                    xrTableCell69.Text = "YES";
                }
                else
                    xrTableCell69.Text = "";
            }
            else
            {
                xrTableCell69.Text = "";
            }
        }

        private void xrTableCell70_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (DetailReport_Vertebral.GetCurrentColumnValue("Mild") != null && !string.IsNullOrEmpty(DetailReport_Vertebral.GetCurrentColumnValue("Mild").ToString()))
            //{
            //    bool LyDoGoi = bool.Parse(DetailReport_Vertebral.GetCurrentColumnValue("Mild").ToString());
            //    if (LyDoGoi)
            //    {
            //        xrTableCell70.Text = "YES";
            //    }
            //    else
            //        xrTableCell70.Text = "";
            //}
            //else
            //{
            //    xrTableCell70.Text = "";
            //}
        }

        private void xrTableCell71_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (DetailReport_Vertebral.GetCurrentColumnValue("Moderate") != null && !string.IsNullOrEmpty(DetailReport_Vertebral.GetCurrentColumnValue("Moderate").ToString()))
            //{
            //    bool LyDoGoi = bool.Parse(DetailReport_Vertebral.GetCurrentColumnValue("Moderate").ToString());
            //    if (LyDoGoi)
            //    {
            //        xrTableCell71.Text = "YES";
            //    }
            //    else
            //        xrTableCell71.Text = "";
            //}
            //else
            //{
            //    xrTableCell71.Text = "";
            //}
        }

        private void xrTableCell72_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (DetailReport_Vertebral.GetCurrentColumnValue("Severe") != null && !string.IsNullOrEmpty(DetailReport_Vertebral.GetCurrentColumnValue("Severe").ToString()))
            //{
            //    bool LyDoGoi = bool.Parse(DetailReport_Vertebral.GetCurrentColumnValue("Severe").ToString());
            //    if (LyDoGoi)
            //    {
            //        xrTableCell72.Text = "YES";
            //    }
            //    else
            //        xrTableCell72.Text = "";
            //}
            //else
            //{
            //    xrTableCell72.Text = "";
            //}
        }

        private void xrTableCell73_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Vertebral.GetCurrentColumnValue("Degenerative") != null && !string.IsNullOrEmpty(DetailReport_Vertebral.GetCurrentColumnValue("Degenerative").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Vertebral.GetCurrentColumnValue("Degenerative").ToString());
                if (LyDoGoi)
                {
                    xrTableCell73.Text = "YES";
                }
                else
                    xrTableCell73.Text = "";
            }
            else
            {
                xrTableCell73.Text = "";
            }
        }

        private void xrLabel27_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Wrist.GetCurrentColumnValue("Wrist") != null && !string.IsNullOrEmpty(DetailReport_Wrist.GetCurrentColumnValue("Wrist").ToString()))
            {
                bool LyDoGoi = bool.Parse(DetailReport_Wrist.GetCurrentColumnValue("Wrist").ToString());
                if (LyDoGoi)
                {
                    xrLabel27.Text = "YES";
                }
                else
                    xrLabel27.Text = "";
            }
            else
            {
                xrLabel27.Text = "";
            }
        }

        private void xrRichText2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (DetailReport_Excercises.GetCurrentColumnValue("Range") != null && !string.IsNullOrEmpty(DetailReport_Excercises.GetCurrentColumnValue("Range").ToString()))
            {
                string range = DetailReport_Excercises.GetCurrentColumnValue("Range").ToString();
                string resistance = DetailReport_Excercises.GetCurrentColumnValue("Resistance").ToString();
                if (DetailReport_Excercises.GetCurrentColumnValue("Direction") != null && !string.IsNullOrEmpty(DetailReport_Excercises.GetCurrentColumnValue("Direction").ToString()))
                {
                    string direction = DetailReport_Excercises.GetCurrentColumnValue("Direction").ToString();
                    xrRichText2.Text = string.Format("Range: {0}. - Resistance: {1}. - Direction: {2}", range, resistance, direction);
                }
                else
                {
                    xrRichText2.Text = string.Format("Range: {0}. - Resistance: {1}.", range, resistance);
                }

            }
            else
            {
                xrRichText2.Text = "";
            }
        }

    }
}
