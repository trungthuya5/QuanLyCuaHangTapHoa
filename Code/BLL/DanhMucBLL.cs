using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DanhMucBLL
    {
        DanhMucDAL dal = new DanhMucDAL();

        public List<DanhMuc> getList()
        {
            return dal.getList();
        }

        public List<DanhMuc> getListHide()
        {
            return dal.getListHide();
        }
        public List<DanhMuc> getListByString(string str)
        {
            return dal.getListByString(str);
        }

        public DanhMuc getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public int getIdByName(string name)
        {
            return dal.getIdByName(name);
        }

        public string getNameById(int id)
        {
            return dal.getNameById(id);
        }

        public int getListCount()
        {
            return dal.getListCount();
        }

        public bool add(DanhMuc O)
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

        public bool update(DanhMuc O)
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

        public bool hide(int hide,int id)
        {
            try
            {
                return dal.hide(hide,id);
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
