using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL dal = new NhanVienDAL();

        public NhanVien getAccountbyUsername(string username, string password)
        {
            
            return dal.getAccountByUsername(username,password);
        }

        public string getNameById(int id)
        {
            return dal.getNameById(id);
        }

        public NhanVien getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public NhanVien getDetailsByName(string name)
        {
            return dal.getDetailsByName(name);
        }

        public List<NhanVien> getList()
        {
            return dal.getList();
        }

        public List<NhanVien> getListByString(string str)
        {
            return dal.getListByString(str);
        }

        public List<NhanVien> getListHide()
        {
            return dal.getListHide();
        }

        public int getListCount()
        {
            return dal.getListCount();
        }

        public bool add(NhanVien O)
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

        public bool update(NhanVien O)
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
