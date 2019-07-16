using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhapHang
    {
        public int id { get; set;}
        public int idMH { get; set; }
        public int idNCC { get; set; }
        public int idNV { get; set; }
        public int soluong { get; set; }
        public float thanhtien { get; set; }
        public string ngaynhap { get; set; }
        public int hide { get; set; }

        public NhapHang()
        {

        }

        public NhapHang(DataRow row)
        {
            id = (int)row["id"];
            idMH = (int)row["idMH"];
            idNCC = (int)row["idNCC"];
            idNV = (int)row["idNV"];
            soluong = (int)row["soluong"];
            thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            ngaynhap = row["ngaynhap"].ToString();
            hide = (int)row["hide"];
        }
    }
}
