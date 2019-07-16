using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MatHangDAL:Database
    {
        
        public List<MatHang> getList()
        {
            List<MatHang> dsMH1 = new List<MatHang>();
            string query = "SELECT * FROM dbo.MatHang WHERE hide = 0";
            DataTable data = ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH1.Add(mh);
            }

            return dsMH1;
        }

        public List<MatHang> getListHide()
        {
            List<MatHang> dsMH = new List<MatHang>();
            string query = "SELECT * FROM dbo.MatHang WHERE hide = 1";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH.Add(mh);
            }

            return dsMH;
        }


        public List<MatHang>  getListByString(string str)
        {
            List<MatHang> dsMH = new List<MatHang>();
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE name LIKE N'%{0}%' AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH.Add(mh);
            }

            return dsMH;
        }

        public List<MatHang> getListByStringDM(string str)
        {
            List<MatHang> dsMH = new List<MatHang>();
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE dbo.MatHang.idDM IN (SELECT dbo.DanhMuc.id FROM dbo.DanhMuc WHERE name LIKE N'%{0}%') AND hide = 0", str);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH.Add(mh);
            }

            return dsMH;
        }

        public List<MatHang> getListTKMax()
        {
            List<MatHang> dsMH1 = new List<MatHang>();
            string query = "SELECT * FROM dbo.MatHang WHERE hide = 0 ORDER BY soluong DESC";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH1.Add(mh);
            }

            return dsMH1;
        }

        public DataTable getListBanMax()
        {
            
            string query = "SELECT MH.id, MH.name,MH.soluong, MH.idDM, SUM(XH.soluong) AS soluongXH, SUM(XH.thanhtien) AS tienXH FROM dbo.XuatHang XH JOIN dbo.MatHang MH ON XH.idMH = MH.id WHERE MH.hide = 0  GROUP BY MH.id, MH.name,MH.soluong, MH.idDM ORDER BY SUM(XH.soluong) DESC";
            DataTable data = ExcuteQuery(query);

            return data;
        }

        public List<MatHang> getListTK0()
        {
            List<MatHang> dsMH1 = new List<MatHang>();
            string query = "SELECT * FROM dbo.MatHang WHERE hide = 0 AND soluong = 0";
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH1.Add(mh);
            }

            return dsMH1;
        }

        public string getNameById(int id)
        {
           
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);

          
            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                return mh.name; 
            }

            return "";
        }
        public MatHang getDetailsById(int id)
        {
            
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(data.Rows[0]);
                return mh;
            }

            return null;
        }

        public List<MatHang> getListByIdDM(int idDM)
        {
            List<MatHang> dsMH = new List<MatHang>();
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE idDM = {0}",idDM);
            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                MatHang mh = new MatHang(item);
                dsMH.Add(mh);
            }

            return dsMH;
        }

        public int getIdByName(string name)
        {
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE name = N'{0}'", name);
            DataTable data = ExcuteQuery(query);
            MatHang mh = new MatHang(data.Rows[0]);
            return mh.id;
        }
        public float getGiaBanById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            MatHang mh = new MatHang(data.Rows[0]);
            return mh.giaban;
        }

        public float getSoLuongById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            MatHang mh = new MatHang(data.Rows[0]);
            return mh.soluong;
        }

        public float getGiaNhapById(int id)
        {
            string query = string.Format("SELECT * FROM dbo.MatHang WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);
            MatHang mh = new MatHang(data.Rows[0]);

            return mh.gianhap;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.MatHang WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }

        public bool add(MatHang M)
        {
            string query = string.Format("INSERT INTO dbo.MatHang(idDM,name,gianhap,giaban) VALUES({0},N'{1}',{2},{3})",M.idDM,M.name,M.gianhap,M.giaban);
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

        public bool update(MatHang O)
        {
            string query = string.Format("UPDATE dbo.MatHang SET name = N'{0}', gianhap = {1}, giaban = {2} , soluong = {3} WHERE id = {4}",O.name,O.gianhap,O.giaban,O.soluong,O.id);
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
            string query = string.Format("UPDATE dbo.MatHang SET hide = {0} WHERE id = {1}", hide, id);

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
            string query = string.Format("DELETE FROM dbo.MatHang WHERE id = {0}",id);
            string query1 = string.Format("DELETE FROM dbo.NhapHang WHERE idMH = {0}", id);
            string query2 = string.Format("DELETE FROM dbo.XuatHang WHERE idMH = {0}", id);
            string query3 = string.Format("DELETE FROM dbo.KMInfo WHERE idMH = {0}", id);

            try
            {
                ExcuteNonQuery(query1);
                ExcuteNonQuery(query2);
                ExcuteNonQuery(query3);
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
