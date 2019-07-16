using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Dashboard : UserControl
    {
        public object UIParent { get; set;}
        public Dashboard()
        {
            InitializeComponent();
        }
        
        public Function Fn;
        public Function Ex;
        private void panel1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Dock = DockStyle.Fill;
            pnDMH.Click += Show;
            pnKMH.Click += Show;
            pnMHH.Click += Show;
            pnNCCH.Click += Show;
            pnNHH.Click += Show;
            pnNVH.Click += Show;
            pnXHH.Click += Show;

            if (UIParent is Form)
            {
                MainForm frm = UIParent as MainForm;
                if(frm.idNV != 1)
                {
                    pnNVH.Hide();
                }

                NhanVienBLL bll = new NhanVienBLL();
                NhanVien nv = bll.getDetailsById(frm.idNV);

                label23.Text = nv.username;
                label24.Text = nv.name;
                label25.Text = nv.chucvu;
                if (nv.gioitinh == 0)
                    label26.Text = "Nữ";
                else
                    label26.Text = "Nam";
                label27.Text = nv.sdt;
            }

            DanhMucBLL dmb = new DanhMucBLL();
            lbDM.Text = "Tổng: " + dmb.getListCount();
            KhuyenMaiBLL kmb = new KhuyenMaiBLL();
            lbKM.Text = "Tổng: " + kmb.getListCount();
            MatHangBLL mhb = new MatHangBLL();
            lbMH.Text = "Tổng: " + mhb.getListCount();
            NhaCungCapBLL nccb = new NhaCungCapBLL();
            lbNCC.Text = "Tổng: " + nccb.getListCount();
            NhanVienBLL nvb = new NhanVienBLL();
            lbNV.Text = "Tổng: " + nvb.getListCount();
            NhapHangBLL nhb = new NhapHangBLL();
            lbNH.Text = "Tổng: " + nhb.getListCount();
            XuatHangBLL xhb = new XuatHangBLL();
            lbXH.Text = "Tổng: " + xhb.getListCount();


            
        }

        void Show(object sender, EventArgs e)
        {
            Panel pn = sender as Panel;
            if(pn == pnDMH)
            {
                Fn = Function.DANH_MUC;
                Ex = Function.DANH_MUC;
            }
            else if(pn == pnKMH)
            {
                Fn = Function.KHUYEN_MAI;
                Fn = Function.KHUYEN_MAI;
            }
            else if (pn == pnMHH)
            {
                Fn = Function.MAT_HANG;
                Ex = Function.MAT_HANG;
            }
            else if (pn == pnNCCH)
            {
                Fn = Function.NHA_CUNG_CAP;
                Ex = Function.NHA_CUNG_CAP;
            }
            else if (pn == pnNHH)
            {
                Fn = Function.NHAP;
                Ex = Function.NHAP;
            }
            else if (pn == pnXHH)
            {
                Fn = Function.XUAT;
                Ex = Function.XUAT;
            }
            else if (pn == pnNVH)
            {
                Fn = Function.NHAN_VIEN;
                Ex = Function.NHAN_VIEN;
            }

            if (UIParent is Form)
            {
                MainForm frm = UIParent as MainForm;
                frm.Fn = Fn;
                frm.Ex = Ex;
                this.Hide();
                frm.loadData();
            }
        }

        private void btnDMK_Click(object sender, EventArgs e)
        {
            if(txtPassOld.Text == "")
            {
                MessageBox.Show("Mật khẩu cũ trống?");
                txtPassOld.Focus();
                return;
            }
            if (txtPassNew1.Text == "")
            {
                MessageBox.Show("Mật khẩu mới không được để trống?");
                txtPassNew1.Focus();
                return;
            }
            if (txtPassNew2.Text == "")
            {
                MessageBox.Show("Mật khẩu nhập lại trống?");
                txtPassNew2.Focus();
                return;
            }

            if(txtPassNew1.Text != txtPassNew2.Text)
            {
                MessageBox.Show("Mật khẩu mới khác nhau");
                txtPassNew1.Focus();
                return;
            }

            if (UIParent is Form)
            {
                MainForm frm = UIParent as MainForm;
                frm.Fn = Function.MAT_HANG;
                NhanVienBLL bll = new NhanVienBLL();
                NhanVien nv = bll.getDetailsById(frm.idNV);
                if (MD5.md5(txtPassOld.Text) != nv.password)
                {
                    MessageBox.Show("Mật khẩu cũ không đúng");
                    txtPassOld.Focus();
                    return;
                }

                nv.password = MD5.md5(txtPassNew1.Text);
                try
                {
                    if(bll.update(nv))
                    {
                        MessageBox.Show("Thay đổi mật khẩu thành công");
                        txtPassNew1.Text = txtPassNew2.Text = txtPassOld.Text = "";
                    }
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }



        }
    }
}
