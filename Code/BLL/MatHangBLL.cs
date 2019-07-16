using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MatHangBLL
    {
        MatHangDAL dal = new MatHangDAL();
       
        public List<MatHang> getList()
        {
            return dal.getList();
        }

        public List<MatHang> getListHide()
        {
            return dal.getListHide();
        }
        public List<MatHang> getListTKMax()
        {
            return dal.getListTKMax();
        }
        public List<MatHang> getListTK0()
        {
            return dal.getListTK0();
        }

        public DataTable getListBanMax()
        {
            return dal.getListBanMax();
        }
        public List<MatHang> getListByString(string str)
        {
            return dal.getListByString(str);
        } 

        public List<MatHang> getListByStringDM(string str)
        {
            return dal.getListByStringDM(str);
        }
        public string getNameById(int id)
        {
            return dal.getNameById(id);
        }

        public int getIdByName(string name)
        {
            return dal.getIdByName(name);
        }
        public MatHang getDetailsById(int id)
        {
            return dal.getDetailsById(id);
        }

        public List<MatHang> getListByIdDM(int idDM)
        {
            return dal.getListByIdDM(idDM);
        }

        public float getGiaBanById(int id)
        {
            return dal.getGiaBanById(id);
        }

        public float getSoLuongById(int id)
        {
            return dal.getSoLuongById(id);
        }

        public float getGiaNhapById(int id)
        {
            return dal.getGiaNhapById(id);
        }

        public bool update(MatHang O)
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

        public int getListCount()
        {
            return dal.getListCount();
        }


        public bool add(MatHang M)
        {
            try
            {
                return dal.add(M);
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
