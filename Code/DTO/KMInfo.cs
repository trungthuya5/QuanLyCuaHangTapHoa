using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KMInfo
    {
        public int id { get; set; }
        public int idMH { get; set; }
        public int idKM { get; set; }

        public KMInfo()
        {

        }
        public KMInfo(DataRow row)
        {
            id = (int)row["id"];
            idMH = (int)row["idMH"];
            idKM = (int)row["idKM"];
        }
    }


}
