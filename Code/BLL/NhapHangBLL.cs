using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NhapHangBLL
    {
        NhapHangDAL dal = new NhapHangDAL();
        public List<NhapHang> getList()
        {
            return dal.getList();
        }

        public List<NhapHang> getListHide()
        {
            return dal.getListHide();
        }

        public List<NhapHang> getListByStringMH(string str)
        {
            return dal.getListByStringMH(str);
        }

        public List<NhapHang> getListByStringNCC(string str)
        {
            return dal.getListByStringMH(str);
        }

        public List<NhapHang> getListByStringNV(string str)
        {
            return dal.getListByStringMH(str);
        }

        public List<NhapHang> getListByNameNCC(string str)
        {
            return dal.getListByNameNCC(str);
        }

        public List<NhapHang> getListByNameNV(string str)
        {
            return dal.getListByNameNV(str);
        }

        public List<NhapHang> getListByNameMH(string str)
        {
            return dal.getListByNameMH(str);
        }

        public NhapHang getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public int getListCount()
        {
            return dal.getListCount();
        }

        public bool add(NhapHang O)
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

        public int getIdAndInsert(NhapHang O)
        {
            return dal.getIdAndInsert(O);
        }

        public bool update(NhapHang O)
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
