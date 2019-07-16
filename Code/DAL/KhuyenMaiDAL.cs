using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhuyenMaiDAL:Database
    {
        List<KhuyenMai> dsKM = new List<KhuyenMai>();

        public List<KhuyenMai> getList()
        {
            string query = "SELECT * FROM dbo.KhuyenMai WHERE hide = 0";

            DataTable data = ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                KhuyenMai km = new KhuyenMai(item);
                dsKM.Add(km);
            }
 
            return dsKM;
        }

        public List<KhuyenMai> getListHide()
        {
            string query = "SELECT * FROM dbo.KhuyenMai WHERE hide = 1";

            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhuyenMai km = new KhuyenMai(item);
                dsKM.Add(km);
            }

            return dsKM;
        }

        public List<KhuyenMai> getListByString(string str)
        {
            string query = string.Format("SELECT * FROM dbo.KhuyenMai WHERE content LIKE N'%{0}%' AND hide = 0", str);

            DataTable data = ExcuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                KhuyenMai km = new KhuyenMai(item);
                dsKM.Add(km);
            }

            return dsKM;
        }

        public KhuyenMai getDetailsById(int id)
        {

            string query = string.Format("SELECT * FROM dbo.KhuyenMai WHERE id = {0}", id);
            DataTable data = ExcuteQuery(query);

            KhuyenMai km = new KhuyenMai(data.Rows[0]);
            return km;
        }

        public KhuyenMai getDetailsByIdMH(int idMH)
        {

            string query = string.Format("SELECT KM.* FROM dbo.KMInfo KMI, dbo.KhuyenMai KM WHERE KMI.idMH = {0} AND KM.id = KMI.idKM", idMH);
            DataTable data = ExcuteQuery(query);

            foreach(DataRow item in data.Rows)
            {
                KhuyenMai km = new KhuyenMai(item);
                return km;
            }

            return null;
        }

        public int getListCount()
        {
            string query = string.Format("SELECT count(*) FROM dbo.KhuyenMai WHERE hide = 0 ");

            return (int)ExcuteScalar(query);
        }

        public bool add(KhuyenMai O)
        {
            string query = string.Format("INSERT INTO dbo.KhuyenMai(content,gia,typegia,starttime,endtime) VALUES(N'{0}',{1},{2},N'{3}',N'{4}')", O.content,O.gia,O.typegia,O.starttime,O.endtime);
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

        public bool update(KhuyenMai O)
        {
            System.Windows.Forms.MessageBox.Show(O.starttime);
            string query = string.Format("UPDATE dbo.KhuyenMai SET content = N'{0}', gia = {1}, typegia = {2}, starttime = N'{3}', endtime = N'{4}' WHERE id = {5}", O.content, O.gia, O.typegia, O.starttime, O.endtime, O.id);
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
            string query = string.Format("UPDATE dbo.KhuyenMai SET hide = {0} WHERE id = {1}", hide,  id);

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
            string query = string.Format("DELETE FROM dbo.KhuyenMai WHERE id = {0}", id);
            string query1 = string.Format("DELETE FROM dbo.KMInfo WHERE idKM = {0}", id);

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

        public bool addKM(KMInfo O)
        {
            string query = string.Format("INSERT INTO dbo.KMInfo(idKM, idMH) VALUES({0},{1})",O.idKM, O.idMH);

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

        public bool delKM(int id)
        {
            string query = string.Format("DELETE FROM dbo.KMInfo WHERE idMH = {0}",id);

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

        public KMInfo getKMInfo(int idMH)
        {
            string query = string.Format("SELECT * FROM dbo.KMInfo WHERE idMH = {0}",idMH);

            DataTable data = ExcuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                KMInfo km = new KMInfo(item);
                return km;
            }

            return null;
        }
    }
}
