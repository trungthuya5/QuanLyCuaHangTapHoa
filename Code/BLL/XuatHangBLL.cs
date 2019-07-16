using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class XuatHangBLL
    {
        XuatHangDAL dal = new XuatHangDAL();
        public List<XuatHang> getList()
        {
            return dal.getList();
        }

        public List<XuatHang> getListHide()
        {
            return dal.getListHide();
        }

        public List<XuatHang> getListByStringMH(string str)
        {
            return dal.getListByStringMH(str);
        }

        public List<XuatHang> getListByStringNV(string str)
        {
            return dal.getListByStringNV(str);
        }

        public List<XuatHang> getListByNameNV(string str)
        {
            return dal.getListByNameNV(str);
        }

        public List<XuatHang> getListByNameMH(string str)
        {
            return dal.getListByNameMH(str);
        }

        public XuatHang getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public int getListCount()
        {  
            return dal.getListCount();
        }

        public bool add(XuatHang O)
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

        public int getIdAndInsert(XuatHang O)
        {
            return dal.getIdAndInsert(O);
        }

        public bool update(XuatHang O)
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
