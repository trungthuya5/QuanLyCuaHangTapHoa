using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhaCungCapDAL:Database
    {

        public List<NhaCungCap> getList()
        {

            string query = "SELECT * FROM dbo.NhaCungCap WHERE hide = 0";
            DataTable data = ExcuteQuery(query);
            List<NhaCungCap> dsNCC = new List<NhaCungCap>();

            foreach(DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                dsNCC.Add(ncc);
            }


            return dsNCC;
        }

        public List<NhaCungCap> getListHide()
        {

            string query = "SELECT * FROM dbo.NhaCungCap WHERE hide = 1";
            DataTable data = ExcuteQuery(query);
            List<NhaCungCap> dsNCC = new List<NhaCungCap>();

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                dsNCC.Add(ncc);
            }


            return dsNCC;
        }

        public List<NhaCungCap> getListByString(string str)
        {
            List<NhaCungCap> dsNCC = new List<NhaCungCap>();
            string query = string.Format("SELECT * FROM dbo.NhaCungCap WHERE name LIKE N'%{0}%' AND hide = 0", str);
            DataTable data = ExcuteQuery(query);
            

            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                dsNCC.Add(ncc);
            }


            return dsNCC;
        }

        public string getNameById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.NhaCungCap WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);


            foreach (DataRow item in data.Rows)
            {
                NhaCungCap ncc = new NhaCungCap(item);
                return ncc.name;
            }

            return "";
        }
        public NhaCungCap getDetailsById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.NhaCungCap WHERE id = {0}", id);

            DataTable data = ExcuteQuery(query);
            NhaCungCap ncc = new NhaCungCap(data.Rows[0]);
            return ncc;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.NhaCungCap WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }

        public bool add(NhaCungCap O)
        {
            string query = string.Format("INSERT INTO dbo.NhaCungCap(name,content,sdt,diachi) VALUES (N'{0}',N'{1}','{2}',N'{3}')", O.name, O.content, O.sdt, O.diachi);

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

        public bool update(NhaCungCap O)
        {
            string query = string.Format("UPDATE dbo.NhaCungCap SET name = N'{0}', content = N'{1}', sdt = '{2}',diachi = N'{3}' WHERE id = {4}", O.name, O.content, O.sdt, O.diachi, O.id);
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
            string query = string.Format("UPDATE dbo.NhaCungCap SET hide = {0} WHERE id = {1} ", hide, id);
            try
            {
                ExcuteNonQuery(query);
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool del(int id)
        {
            string query = string.Format("DELETE FROM dbo.NhaCungCap WHERE id = {0}", id);
            string query1 = string.Format("DELETE FROM dbo.NhapHang WHERE idNCC = {0}", id);

            try
            {
                ExcuteNonQuery(query1);
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
