using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NhaCungCap
    {
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public string sdt { get; set; }
        public string diachi { get; set; }
        public int hide { get; set; }

        public NhaCungCap()
        {

        }
        public NhaCungCap(int id, string name, string content, string sdt, string diachi, int hide)
        {
            this.id = id;
            this.name = name;
            this.content = content;
            this.sdt = sdt;
            this.diachi = diachi;
            this.hide = hide;
        }

        public NhaCungCap(DataRow row)
        {
            id = (int)row["id"];
            name = (string)row["name"];
            content = (string)row["content"];
            sdt = (string)row["sdt"];
            diachi = (string)row["diachi"];
            hide = (int)row["hide"];
        }
    }

    
}
