using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PMS.DataModel;
using PMS.App_Code;
using System.Data;
using System.Configuration;

namespace PMS.BL
{
    public class clsQLNguoiDung
    {
        string Connection = "";
        string User = ConfigurationManager.AppSettings["User"].ToString();
        string Pass = ConfigurationManager.AppSettings["Pass"].ToString();
        public clsQLNguoiDung()
        {
            // Connection = ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString.ToString();
            Connection = string.Format("{0}User ID={1};Password={2}", ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString.ToString(), User, Pass);
        }
        public clsQLNguoiDung(string ConnectionString)
        {
            Connection = ConnectionString;
        }
        #region DanhSachUser

        public  List<NguoiDung> GetListNguoiDung()
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.NguoiDungs;
            return q.ToList();
        }

        public  NguoiDung GetNguoiDungByID(int ID)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.NguoiDungs.Where(i => i.IDNguoiDung == ID);
            return q.SingleOrDefault();
        }

        public  NguoiDung GetNguoiDungByTenND(string tenND)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.NguoiDungs.Where(i => i.TenDangNhap == tenND);
            return q.SingleOrDefault();
        }

        public  List<NguoiDung> GetListNguoiDungByNhomND(int IDNhomND)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.NguoiDungs.Where(i => i.IDNhomND == IDNhomND);
            return q.ToList();
        }

        public  bool InsertNguoiDung(NguoiDung nguoiDung)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.NguoiDungs.InsertOnSubmit(nguoiDung);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public  bool UpdateNguoiDung(NguoiDung nguoiDung)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            NguoiDung NDOld = data.NguoiDungs.Where(i => i.IDNguoiDung == nguoiDung.IDNguoiDung).SingleOrDefault();
            NDOld.Active = nguoiDung.Active;
            NDOld.DiaChi = nguoiDung.DiaChi;
            NDOld.DienThoai = nguoiDung.DienThoai;
            NDOld.Email = nguoiDung.Email;
            NDOld.IDNhomND = nguoiDung.IDNhomND;
            NDOld.IsAdmin = nguoiDung.IsAdmin;
            NDOld.KhoRole = nguoiDung.KhoRole;
            NDOld.MatKhau = nguoiDung.MatKhau;
            NDOld.Mapb = nguoiDung.Mapb;
            NDOld.TenDangNhap = nguoiDung.TenDangNhap;
            NDOld.TenHienThi = nguoiDung.TenHienThi;
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public  bool DeleteNguoiDungByID(int IDNguoiDung)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            NguoiDung nguoiDung = data.NguoiDungs.Where(i => i.IDNguoiDung == IDNguoiDung).SingleOrDefault();
            data.NguoiDungs.DeleteOnSubmit(nguoiDung);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        public  DataTable GetMenu()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = from p in dataContext.ChucNangs orderby p.SapXep ascending select p;
            DataTable dt = GenericToDataTable.ConvertTo<ChucNang>(q.ToList());
            return dt;
        }


        // Lấy danh sách Menu được sử dụng của user đăng nhập
        public  DataTable GetMenuByUser(int IDNhomND)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = from p in dataContext.PQNhoms
                    join k in dataContext.ChucNangs on p.IDChucNang equals k.IDChucNang
                    where p.IDNhomND == IDNhomND && p.Xem == true
                    select p;
            DataTable dt = GenericToDataTable.ConvertTo<PQNhom>(q.ToList());
            return dt;
        }
        #endregion

        #region NhomND
        public  List<NhomND> GetListNhomND()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.NhomNDs;
            return q.ToList();
        }

        public  bool DeletePQNhomByIDNhom(int IDNhomND)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            List<PQNhom> listPQNhom = dataContext.PQNhoms.Where(i => i.IDNhomND == IDNhomND).ToList();
            if (listPQNhom.Count > 0 && listPQNhom != null)
            {
                dataContext.PQNhoms.DeleteAllOnSubmit(listPQNhom);
                try
                {
                    dataContext.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return true;
        }
        public  bool UpdateNhomND(NhomND nhomND)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            NhomND NDOld = data.NhomNDs.Where(i => i.IDNhomND == nhomND.IDNhomND).SingleOrDefault();
            NDOld.IsAdminGroup = nhomND.IsAdminGroup;
            NDOld.Madv = nhomND.Madv;
            NDOld.MoTa = nhomND.MoTa;
            NDOld.Parent = nhomND.Parent;
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public  NhomND GetNhomND(int id)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.NhomNDs.Where(item => item.IDNhomND == id).SingleOrDefault();
            return q;
        }
        public  bool DeleteNhomNDByID(int ID)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            NhomND listPQNhom = dataContext.NhomNDs.Where(i => i.IDNhomND == ID).SingleOrDefault();
            if (listPQNhom != null)
            {
                dataContext.NhomNDs.DeleteOnSubmit(listPQNhom);
                try
                {
                    dataContext.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
                return true;
        }

        public  bool InsertNhomND(NhomND nhomND)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.NhomNDs.InsertOnSubmit(nhomND);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region PQNhom
        public  List<sp_PQNhomResult> GetPQNhomByIDNhom(int IDNhom)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.sp_PQNhom(IDNhom);
            return q.ToList();
        }

        public  bool InsertAllPQNhom(List<PQNhom> listPQNhom)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.PQNhoms.InsertAllOnSubmit(listPQNhom);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public  bool InsertPQNhom(PQNhom pqNhom)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.PQNhoms.InsertOnSubmit(pqNhom);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        #endregion

        #region Comment

        public List<sp_GetDSCommentsResult> GetDSComments()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.sp_GetDSComments();
            return q.ToList();
        }
        #endregion
        #region Exercises

        public List<sp_GetDSExercisesResult> GetDSExercises()
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.sp_GetDSExercises();
            return q.ToList();
        }
        #endregion

        #region DanhSachPatient

        public List<BenhNhan> GetListBenhNhan()
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.BenhNhans;
            return q.ToList();
        }

        public BenhNhan GetBenhNhanByID(string ID)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.BenhNhans.Where(i => i.ID == ID);
            return q.SingleOrDefault();
        }

        public BenhNhan GetBenhNhanByTenND(string tenND)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            var q = data.BenhNhans.Where(i => i.TenBN == tenND);
            return q.SingleOrDefault();
        }


        public bool InsertBenhNhan(BenhNhan BenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.BenhNhans.InsertOnSubmit(BenhNhan);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateBenhNhan(BenhNhan BenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            BenhNhan NDOld = data.BenhNhans.Where(i => i.ID == BenhNhan.ID).SingleOrDefault();
            NDOld.DiaChi = BenhNhan.DiaChi;
            NDOld.ID = BenhNhan.ID;
            NDOld.NgayKhamLanDau = BenhNhan.NgayKhamLanDau;
            NDOld.NgaySinh = BenhNhan.NgaySinh;
            NDOld.SoDT = BenhNhan.SoDT;
            NDOld.TenBN = BenhNhan.TenBN;
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteBenhNhanByID(string IDBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            BenhNhan BenhNhan = data.BenhNhans.Where(i => i.ID == IDBenhNhan).SingleOrDefault();
            data.BenhNhans.DeleteOnSubmit(BenhNhan);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        public bool InsertCTBenhNhan(CTBenhNhan CTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhans.InsertOnSubmit(CTBenhNhan);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //
        public bool InsertListCTBenhNhanComplaint(List<CTBenhNhanComplaint> listCTBenhNhanComplaint)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanComplaints.InsertAllOnSubmit(listCTBenhNhanComplaint);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanComplaint(CTBenhNhanComplaint CTBenhNhanComplaint)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanComplaints.InsertOnSubmit(CTBenhNhanComplaint);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public List<CTBenhNhanComplaint> GetDSCTBenhNhanComplaintByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanComplaints.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        //
        public bool InsertListCTBenhNhanConditionDicsJoint(List<CTBenhNhanConditionDicsJoint> listCTBenhNhanDicsJoint)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditionDicsJoints.InsertAllOnSubmit(listCTBenhNhanDicsJoint);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanConditionDicsJoint(CTBenhNhanConditionDicsJoint CTBenhNhanDicsJoint)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditionDicsJoints.InsertOnSubmit(CTBenhNhanDicsJoint);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanConditionDicsJoint> GetDSCTBenhNhanConditionDicsJointByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanConditionDicsJoints.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        //
        public bool InsertListCTBenhNhanCondition(List<CTBenhNhanCondition> listCTBenhNhanCondition)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditions.InsertAllOnSubmit(listCTBenhNhanCondition);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanCondition(CTBenhNhanCondition CTBenhNhanCondition)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditions.InsertOnSubmit(CTBenhNhanCondition);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanCondition> GetDSCTBenhNhanConditionByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanConditions.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        //
        public bool InsertListCTBenhNhanConditionVertebral(List<CTBenhNhanConditionVertebral> listCTBenhNhanConditionVertebral)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditionVertebrals.InsertAllOnSubmit(listCTBenhNhanConditionVertebral);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanConditionVertebral(CTBenhNhanConditionVertebral CTBenhNhanConditionVertebral)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanConditionVertebrals.InsertOnSubmit(CTBenhNhanConditionVertebral);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanConditionVertebral> GetDSCTBenhNhanConditionVertebralByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanConditionVertebrals.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        //
        public bool InsertListCTBenhNhanExcercise(List<CTBenhNhanExcercise> listCTBenhNhanExcercise)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanExcercises.InsertAllOnSubmit(listCTBenhNhanExcercise);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanExcercise(CTBenhNhanExcercise CTBenhNhanExcercise)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanExcercises.InsertOnSubmit(CTBenhNhanExcercise);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanExcercise> GetDSCTBenhNhanExcerciseByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanExcercises.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        public List<sp_GetDSExcerciseByIDCTBNResult> GetDSExcerciseByIDCTBN(string IDCTBN)
        {
            DataClassesDataContext dataContext = new DataClassesDataContext(Connection);
            var q = dataContext.sp_GetDSExcerciseByIDCTBN(IDCTBN);
            return q.ToList();
        }
        //
        public bool InsertListCTBenhNhanMRIImage(List<CTBenhNhanMRIImage> listCTBenhNhanMRIImage)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanMRIImages.InsertAllOnSubmit(listCTBenhNhanMRIImage);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanMRIImage(CTBenhNhanMRIImage CTBenhNhanMRIImage)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanMRIImages.InsertOnSubmit(CTBenhNhanMRIImage);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanMRIImage> GetDSCTBenhNhanMRIImageByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanMRIImages.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
        public List<CTBenhNhan> GetCTBenhNhanByIDBenhNhan(string IDBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhans.Where(i=>i.IDBenhNhan==IDBenhNhan).ToList();
            
        }
        public List<CTBenhNhan> GetCTBenhNhanByIDCTBenhNhan(string IDCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhans.Where(i => i.IDCTBenhNhan == IDCTBenhNhan).ToList();

        }
        //
        public bool InsertListCTBenhNhanSnapShot(List<CTBenhNhanSnapShot> listCTBenhNhanSnapShot)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanSnapShots.InsertAllOnSubmit(listCTBenhNhanSnapShot);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool InsertCTBenhNhanSnapShot(CTBenhNhanSnapShot CTBenhNhanSnapShot)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            data.CTBenhNhanSnapShots.InsertOnSubmit(CTBenhNhanSnapShot);
            try
            {
                data.SubmitChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CTBenhNhanSnapShot> GetDSCTBenhNhanSnapShotByIDCTBenhNhan(String idCTBenhNhan)
        {
            DataClassesDataContext data = new DataClassesDataContext(Connection);
            return data.CTBenhNhanSnapShots.Where(i => i.IDCTBenhNhan == idCTBenhNhan).ToList();
        }
    }
}
