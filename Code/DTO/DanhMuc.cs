using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DanhMuc
    {
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public int hide { get; set; }

        public DanhMuc()
        {
            id = 0;
            name = "";
            content = "";
            hide = 0;
        }

        public DanhMuc(int id,string name, string content, int hide)
        {
            this.id = id;
            this.name = name;
            this.content = content;
            this.hide = hide;
        }

        public DanhMuc(DataRow row)
        {
            id = (int)row["id"];
            name = row["name"].ToString();
        
            var temp = row["content"];
            if(temp.ToString()!="")
            content = (string)row["content"];

            hide = (int)row["hide"];
        }
    }
}
