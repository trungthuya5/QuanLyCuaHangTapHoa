using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhaCungCapBLL
    {
        NhaCungCapDAL dal = new NhaCungCapDAL();
       
        public List<NhaCungCap> getList()
        {
            return dal.getList();
        }

        public List<NhaCungCap> getListHide()
        {
            return dal.getListHide();
        }

        public List<NhaCungCap> getListByString(string str)
        {
            return dal.getListByString(str);
        }

        public NhaCungCap getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public string getNameById(int id)
        {
            return dal.getNameById(id);
        }

        public int getListCount()
        {
            return dal.getListCount();
        }

        public bool add(NhaCungCap O)
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

        public bool update(NhaCungCap O)
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
    }
}
