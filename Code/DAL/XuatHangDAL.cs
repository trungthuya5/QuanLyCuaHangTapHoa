using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class XuatHangDAL:Database
    {
       

        public List<XuatHang> getList()
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = "SELECT * FROM dbo.XuatHang WHERE hide = 0";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }

        public List<XuatHang> getListHide()
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = "SELECT * FROM dbo.XuatHang WHERE hide = 1";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }

        public List<XuatHang> getListByStringMH(string str)
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = string.Format("SELECT * FROM dbo.XuatHang WHERE dbo.XuatHang.idMH IN (SELECT dbo.MatHang.id FROM dbo.MatHang WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }

        public List<XuatHang> getListByStringNV(string str)
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = string.Format("SELECT * FROM dbo.XuatHang WHERE dbo.XuatHang.idNV IN (SELECT dbo.NhanVien.id FROM dbo.NhanVien WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }

        public List<XuatHang> getListByNameMH(string str)
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = string.Format("SELECT * FROM dbo.XuatHang WHERE dbo.XuatHang.idMH IN (SELECT dbo.MatHang.id FROM dbo.MatHang WHERE name = N'{0}')", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }

        public List<XuatHang> getListByNameNV(string str)
        {
            List<XuatHang> dsXH = new List<XuatHang>();
            string query = string.Format("SELECT * FROM dbo.XuatHang WHERE dbo.XuatHang.idNV IN (SELECT dbo.NhanVien.id FROM dbo.NhanVien WHERE name = N'{0}')", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                XuatHang nh = new XuatHang(item);
                dsXH.Add(nh);
            }
            return dsXH;
        }


        public XuatHang getDetailsById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.XuatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            XuatHang xh = new XuatHang(data.Rows[0]);
            return xh;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.XuatHang WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }

        public bool add(XuatHang O)
        {
            string query = string.Format("INSERT INTO dbo.XuatHang(idMH,idNV,soluong,thanhtien) VALUES ({0},{1},{2},{3})", O.idMH, O.idNV, O.soluong, O.thanhtien);

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

        public int getIdAndInsert(XuatHang O)
        {
            int check = 0;
            string query = string.Format("INSERT INTO dbo.XuatHang(idMH,idNV,soluong,thanhtien) output INSERTED.ID VALUES ({0},{1},{2},{3})", O.idMH, O.idNV, O.soluong, O.thanhtien);

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

        public bool update(XuatHang O)
        {
            string query = string.Format("UPDATE dbo.XuatHang SET soluong = {0} WHERE id = {1}", O.soluong,O.id);

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
            string query = string.Format("UPDATE dbo.XuatHang SET hide = {0} WHERE id = {1}", hide, id);

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
            string query = string.Format("DELETE FROM dbo.XuatHang WHERE id = {0}", id);

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
