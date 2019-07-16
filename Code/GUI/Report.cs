using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }
        int id = 0;
        public Report(int id)
        {
            this.id = id;
            Load += Report_Load;
        }
        private void Report_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection
               ("Server=DESKTOP-454D525\\DUONG;Database=CHTapHoa;User Id=sa;pwd=25251325");
            string query = string.Format("SELECT MH.name as TenMH,NCC.name as TenNCC,nv.name as TenNV,nh.soluong,NH.thanhtien FROM dbo.NhapHang NH INNER JOIN dbo.NhanVien NV ON(NH.idNV = NV.id)INNER JOIN dbo.MatHang MH ON(NH.idMH = MH.id)INNER JOIN dbo.NhaCungCap NCC ON(NH.idNCC = NCC.id)WHERE NH.id >= {0}",id);
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "DataTable1");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ReportHDN.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = ds.Tables[0];

            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }


    }
}
