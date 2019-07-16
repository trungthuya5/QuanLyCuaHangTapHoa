using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhMucDAL:Database
    {
        
        DanhMuc DM = new DanhMuc();

        public List<DanhMuc> getList()
        {
            List<DanhMuc> dsDM = new List<DanhMuc>();
            string query = "SELECT * FROM dbo.DanhMuc WHERE hide = 0";
            DataTable data = ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                DanhMuc dm = new DanhMuc(item);
                dsDM.Add(dm);
            }
            return dsDM;
        }

        public List<DanhMuc> getListHide()
        {
            List<DanhMuc> dsDM = new List<DanhMuc>();
            string query = "SELECT * FROM dbo.DanhMuc WHERE hide = 1";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DanhMuc dm = new DanhMuc(item);
                dsDM.Add(dm);
            }
            return dsDM;
        }

        public List<DanhMuc> getListByString(string str)
        {
            List<DanhMuc> dsDM = new List<DanhMuc>();
            string query = string.Format("SELECT * FROM dbo.DanhMuc WHERE name LIKE N'%{0}%' AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DanhMuc dm = new DanhMuc(item);
                dsDM.Add(dm);
            }
            return dsDM;
        }



        public DanhMuc getDetailsById(int id)
        { 
            string query = string.Format("SELECT * FROM dbo.DanhMuc WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            DanhMuc dm = new DanhMuc(data.Rows[0]);
            return dm;
        }

        public string getNameById(int id)
        {
            List<DanhMuc> dsDM = new List<DanhMuc>();
            string query = string.Format("SELECT * FROM dbo.DanhMuc WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);

            DanhMuc dm;
            foreach (DataRow item in data.Rows)
            {
                 dm = new DanhMuc(item);
                return dm.name;
            }

            return "";
            
        }

        public int getIdByName(string name)
        {
            string query = string.Format("SELECT * FROM dbo.DanhMuc WHERE id = {0}", name);
            DataTable data = ExcuteQuery(query);
            DanhMuc dm = new DanhMuc(data.Rows[0]);
            return dm.id;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.DanhMuc WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }

        public bool add(DanhMuc O)
        {
            string query = string.Format("INSERT INTO dbo.DanhMuc(name,content) VALUES (N'{0}',N'{1}')", O.name, O.content);

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
            string query = string.Format("DELETE FROM dbo.DanhMuc WHERE id = {0}",id);
            string query1 = string.Format("DELETE FROM dbo.MatHang WHERE idDM = {0}", id);

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

        public bool update(DanhMuc O)
        {
            string query = string.Format("UPDATE dbo.DanhMuc SET name = N'{0}', content = N'{1}' WHERE id  = {2}", O.name, O.content, O.id);

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

        public bool hide(int hide,int id)
        {
            string query = string.Format("UPDATE dbo.DanhMuc SET hide = {0} WHERE id = {1}", hide,id);

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
