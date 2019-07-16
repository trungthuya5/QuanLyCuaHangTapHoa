using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhuyenMaiBLL
    {
        KhuyenMaiDAL dal = new KhuyenMaiDAL();
        public List<KhuyenMai> getList()
        {
            return dal.getList();
        }

        public List<KhuyenMai> getListHide()
        {
            return dal.getListHide();
        }

        public List<KhuyenMai> getListByString(string str)
        {
            return dal.getListByString(str);
        }

        public KhuyenMai getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public KhuyenMai getDetailsByIdMH(int idMH)
        {
            return dal.getDetailsByIdMH(idMH);
        }

        public int getListCount()
        {
            return dal.getListCount();
        }

        public bool add(KhuyenMai O)
        {
            try
            {
                return dal.add(O);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool update(KhuyenMai O)
        {
            try
            {
                return dal.update(O);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool hide(int hide, int id)
        {
            try
            {
                return dal.hide(hide, id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool del(int id)
        {
            try
            {
                return dal.del(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool addKM(KMInfo O)
        {
            try
            {
                return dal.addKM(O);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool delKM(int id)
        {
            try
            {
                return dal.delKM(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public KMInfo getKMInfo(int idMH)
        {
            return dal.getKMInfo(idMH);
        }
    }
}
