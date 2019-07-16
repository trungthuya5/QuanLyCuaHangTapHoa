using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhuyenMai
    {
        public int id { get; set; }
        public string content { get; set; }
        public float gia { get; set; }
        public int typegia { get; set; }
        public string starttime { get; set; }
        public string endtime { get; set; }
        public int hide { get; set; }

        public KhuyenMai()
        {

        }

        public KhuyenMai(int id, string content, float gia, int typegia, string starttime, string endtime, int hide)
        {
            this.id = id;
            this.content = content;
            this.gia = gia;
            this.typegia = typegia;
            this.starttime = starttime;
            this.endtime = endtime;
            this.hide = hide;
        }

        public KhuyenMai(DataRow row)
        {
            id = (int)row["id"];
            content = (string)row["content"];
            gia = (float)Convert.ToDouble(row["gia"].ToString());
            typegia = (int)row["typegia"];
            starttime = row["starttime"].ToString();
            endtime = row["endtime"].ToString();
            hide = (int)row["hide"];
        }
    }
}
