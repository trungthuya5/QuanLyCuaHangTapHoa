using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
           if(pnMenu.Width == 171)
            {
                //pnMenu.Visible = false;
                pnMenu.Width = 0;
                pnLogo.Visible = false;
            } else
            {
                pnMenu.Visible = true;
                pnMenu.Width = 171;
                pnLogo.Visible = true;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void pnMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMH_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            MatHang mathang = new MatHang();
            pnContainer.Controls.Add(mathang);
        }

        private void btnDB_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            Dashboard dashboard = new Dashboard();
            pnContainer.Controls.Add(dashboard);
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            ThongTin thongtin = new ThongTin();
            pnContainer.Controls.Add(thongtin);
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            DanhMucUC danhmuc = new DanhMucUC();
            pnContainer.Controls.Add(danhmuc);
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            KhuyenMai khuyenmai = new KhuyenMai();
            pnContainer.Controls.Add(khuyenmai);
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            NhaCungCap nhacungcap = new NhaCungCap();
            pnContainer.Controls.Add(nhacungcap);
        }

        private void btnTK_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            ThongKe thongke = new ThongKe();
            pnContainer.Controls.Add(thongke);
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            SanPham thongke = new SanPham();
            pnContainer.Controls.Add(thongke);
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            pnContainer.Controls.Clear();
            NhanVienUC thongke = new NhanVienUC();
            pnContainer.Controls.Add(thongke);
        }
    }
}
