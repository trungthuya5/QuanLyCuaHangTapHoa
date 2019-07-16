using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhanVienDAL : Database
    {
        

        public NhanVien getAccountByUsername(string username, string password)
        {
            
            string query = string.Format("SELECT * FROM NhanVien WHERE username = N'{0}' AND password = N'{1}'",username,password);
            List<NhanVien> dsNV = new List<NhanVien>();

            DataTable data = ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                return nv;
            }

            return null;
        }

        public List<NhanVien> getList()
        {
            List<NhanVien> dsNV = new List<NhanVien>();

            
            string query = "SELECT * FROM dbo.NhanVien WHERE hide = 0";

            DataTable data = ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                dsNV.Add(nv);
            }

            return dsNV;
        }

        public List<NhanVien> getListHide()
        {
            List<NhanVien> dsNV = new List<NhanVien>();


            string query = "SELECT * FROM dbo.NhanVien WHERE hide = 1";

            DataTable data = ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                dsNV.Add(nv);
            }

            return dsNV;
        }

        public List<NhanVien> getListByString(string str)
        {
            List<NhanVien> dsNV = new List<NhanVien>();

            string query = string.Format("SELECT * FROM dbo.NhanVien WHERE name LIKE N'%{0}%' AND hide = 0", str);

            DataTable data = ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                NhanVien nv = new NhanVien(item);
                dsNV.Add(nv);
            }

            return dsNV;
        }

        public string getNameById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.NhanVien WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);


            foreach (DataRow item in data.Rows)
            {
                NhanVien mh = new NhanVien(item);
                return mh.name;
            }

            return "";
        }

        public NhanVien getDetailsByName(string name)
        {
            string query = string.Format("SELECT * FROM dbo.NhanVien WHERE name = {0}", name);
            DataTable data = ExcuteQuery(query);
            NhanVien nv = new NhanVien(data.Rows[0]);
            return nv;
        }

        public NhanVien getDetailsById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.NhanVien WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            NhanVien nv = new NhanVien(data.Rows[0]);
            return nv;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.NhanVien WHERE hide = 0");

            return (int)ExcuteScalar(query);
        }

        public bool add(NhanVien O)
        {
            string query = string.Format("INSERT INTO dbo.NhanVien(username,password,name,chucvu,gioitinh,diachi,sdt) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',{4},N'{5}','{6}')", O.username, O.password, O.name, O.chucvu, O.gioitinh, O.diachi, O.sdt);

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
            string query = string.Format("DELETE FROM dbo.NhanVien WHERE id = {0}", id);
            string query1 = string.Format("DELETE FROM dbo.NhapHang WHERE idNV = {0}", id);
            string query2 = string.Format("DELETE FROM dbo.XuatHang WHERE idNV = {0}", id);

            try
            {
                ExcuteNonQuery(query1);
                ExcuteNonQuery(query2);
                ExcuteNonQuery(query);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(NhanVien O)
        {
            string query = string.Format("UPDATE dbo.NhanVien SET username = N'{0}', password = N'{1}',name = N'{2}',chucvu = N'{3}', diachi = N'{4}', sdt = '{5}' WHERE id = {6}", O.username, O.password, O.name, O.chucvu, O.diachi, O.sdt, O.id);

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

        public bool hide(int hide,int id)
        {
            string query = string.Format("UPDATE dbo.NhanVien SET hide = {0} WHERE id = {1}",hide, id);

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
