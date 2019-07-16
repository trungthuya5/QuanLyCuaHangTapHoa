using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhanVien
    {
        public int id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string chucvu { get; set; }
        public int gioitinh { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public int hide { get; set; }

        public NhanVien()
        {

        }

        public NhanVien(int id,string name,string username, string password,string chucvu,int gioitinh,string diachi, string sdt, int hide)
        {
            this.id = id;
            this.name = name;
            this.username = username;
            this.password = password;
            this.chucvu = chucvu;
            this.gioitinh = gioitinh;
            this.diachi = diachi;
            this.sdt = sdt;
            this.hide = hide;
            
        }
        public NhanVien(DataRow row)
        {
            id = (int)row["id"];
            name = row["name"].ToString();
            username = row["username"].ToString();
            password = row["password"].ToString();
            chucvu = row["chucvu"].ToString();
            gioitinh = (int)row["gioitinh"];
            diachi = row["diachi"].ToString();
            sdt = row["sdt"].ToString();
            hide = (int)row["hide"];
        }
    }
}
