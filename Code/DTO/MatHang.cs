using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MatHang
    {
        public int id { get; set; }
        public int idDM { get; set; }
        public string name { get; set; }
        public int soluong { get; set; }
        public float gianhap { get; set; }
        public float giaban { get; set; }
        public int hide { get; set; }

        public MatHang()
        {

        }

        public MatHang(int id, int idDM, string name, int soluong, float gianhap,float giaban,DateTime? hsd, int hide)
        {
            this.id = id;
            this.idDM = idDM;
            this.name = name;
            this.soluong = soluong;
            this.gianhap = gianhap;
            this.giaban = giaban;
            this.hide = hide;
        }
        public MatHang(DataRow row)
        {
            this.id = (int)row["id"];
            this.idDM = (int)row["idDM"];
            this.name = (string)row["name"];
            this.soluong = (int)row["soluong"];
            this.gianhap = (float)Convert.ToDouble(row["gianhap"].ToString());
            this.giaban = (float)Convert.ToDouble(row["giaban"].ToString());
            hide = (int)row["hide"];
        }
    }
}
