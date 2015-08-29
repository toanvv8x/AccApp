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
using System.Collections;

namespace PMS
{
    public partial class frm_AddPatient_ExerciseOptions : DevExpress.XtraEditors.XtraForm
    {
        clsQLNguoiDung qlND;
        public frmSystem_AddPatient_v2.AddItemDelegate AddItemCallback;
        private Exercise _EX;
        public Exercise EX
        {
            get { return _EX; }
            set
            {
                _EX = value;
            }
        }
        public frm_AddPatient_ExerciseOptions()
        {
            InitializeComponent();
            qlND = new clsQLNguoiDung();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CTBenhNhanExcercise ctEX = new CTBenhNhanExcercise();
            ctEX.IDExcercises = EX.ID;
            AddItemCallback(ctEX, false);
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            CTBenhNhanExcercise ctEX = new CTBenhNhanExcercise();
            ctEX.IDExcercises = EX.ID;
            ctEX.Repeat = int.Parse(txtRepeat.Text);
            ctEX.Do = int.Parse(txtDo.Text);
            ctEX.Hold = int.Parse(txtHold.Text);
            if (EX.Move == 1)
            {
                ctEX.Direction = cboDirection.EditValue.ToString();
                ctEX.Range = cboRange.EditValue.ToString();
                ctEX.Resistance = cboResistance.EditValue.ToString();
            }
            if (EX.Move == 2)
            {
                ctEX.Direction = "";
                ctEX.Range = cboRange.EditValue.ToString();
                ctEX.Resistance = cboResistance.EditValue.ToString();
            }
            AddItemCallback(ctEX, true);
            this.Close();
        }
        private const int CS_NOCLOSE = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                return cp;
            }
        }

        private void frm_AddPatient_ExerciseOptions_Load(object sender, EventArgs e)
        {
            if (EX.Move == 1 || EX.Move == 2)
            {
                groupBox2.Enabled = true;
                if (EX.Move == 2)
                    cboDirection.Enabled = false;
            }
        }
    }
}