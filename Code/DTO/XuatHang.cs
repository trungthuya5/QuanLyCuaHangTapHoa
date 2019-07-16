using System;
using System.Data;

namespace DTO
{
    public class XuatHang
    {
        public int id { get; set; }
        public int idMH { get; set; }
        public int idNV { get; set; }
        public int soluong { get; set; }
        public float thanhtien { get; set; }
        public string ngayxuat { get; set; }
        public int hide { get; set; }

        public XuatHang()
        {

        }
        public XuatHang(DataRow row)
        {
            id = (int)row["id"];
            idMH = (int)row["idMH"];
            idNV = (int)row["idNV"];
            soluong = (int)row["soluong"];
            thanhtien = (float)Convert.ToDouble(row["thanhtien"].ToString());
            ngayxuat = row["ngayxuat"].ToString();
            hide = (int)row["hide"];
        }
    }
}
