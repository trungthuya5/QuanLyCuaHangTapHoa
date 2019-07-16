using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhapHangDAL:Database
    {
       
        NhapHang DM = new NhapHang();

        public List<NhapHang> getList()
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = "SELECT * FROM dbo.NhapHang WHERE hide = 0";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListHide()
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = "SELECT * FROM dbo.NhapHang WHERE hide = 1";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByStringMH(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idMH IN (SELECT dbo.MatHang.id FROM dbo.MatHang WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByStringNCC(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idNCC IN (SELECT dbo.NhaCungCap.id FROM dbo.NhaCungCap WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByStringNV(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idNV IN (SELECT dbo.NhanVien.id FROM dbo.NhanVien WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByNameMH(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idMH IN (SELECT dbo.MatHang.id FROM dbo.MatHang WHERE name = N'{0}')", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByNameNCC(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idNCC IN (SELECT dbo.NhaCungCap.id FROM dbo.NhaCungCap WHERE name = N'{0}') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public List<NhapHang> getListByNameNV(string str)
        {
            List<NhapHang> dsNH = new List<NhapHang>();
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE dbo.NhapHang.idNV IN (SELECT dbo.NhanVien.id FROM dbo.NhanVien WHERE name = N'{0}')", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                NhapHang nh = new NhapHang(item);
                dsNH.Add(nh);
            }
            return dsNH;
        }

        public NhapHang getDetailsById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.NhapHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            NhapHang dm = new NhapHang(data.Rows[0]);
            return dm;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.NhapHang WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }


        public bool add(NhapHang O)
        {
            string query = string.Format("INSERT INTO dbo.NhapHang(idMH,idNCC,idNV,soluong,thanhtien) VALUES ({0},{1},{2},{3},{4})", O.idMH,O.idNCC,O.idNV,O.soluong,O.thanhtien);

            try
            {
                ExcuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int getIdAndInsert(NhapHang O)
        {
            int check = 0;
            string query = string.Format("INSERT INTO dbo.NhapHang(idMH,idNCC,idNV,soluong,thanhtien) output INSERTED.ID VALUES ({0},{1},{2},{3},{4})", O.idMH, O.idNCC, O.idNV, O.soluong, O.thanhtien);

            try
            {
                 check = (int)ExcuteScalar(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return check;
        }
        

        public bool update(NhapHang O)
        {
            string query = string.Format("UPDATE dbo.NhapHang SET soluong = {0} WHERE id = {1}", O.soluong, O.id);

            try
            {
                ExcuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool hide(int hide, int id)
        {
            string query = string.Format("UPDATE dbo.NhapHang SET hide = {0} WHERE id = {1}", hide, id);

            try
            {
                ExcuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool del(int id)
        {
            string query = string.Format("DELETE FROM dbo.NhapHang WHERE id = {0}", id);

            try
            {
                ExcuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
