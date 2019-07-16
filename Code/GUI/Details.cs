using BLL;
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
    public partial class Details : Form
    {
        Function Fn;
        int id;
        public Details(Function Fn, int id)
        {
            InitializeComponent();
            this.Fn = Fn;
            this.id = id;


        }

        private void Details_Load(object sender, EventArgs e)
        {
            SuKien();

            tbcUpdate.Controls.Clear();
            // Mặt hàng
            if (Fn == Function.MAT_HANG)
            {
                tbcUpdate.Controls.Add(tpMH);

                MatHangBLL bll = new MatHangBLL();
                MatHang mh = bll.getDetailsById(id);
                DanhMucBLL bll1 = new DanhMucBLL();
                KhuyenMaiBLL kmb = new KhuyenMaiBLL();
                KMInfo km = kmb.getKMInfo(mh.id);
                if(km == null)
                {
                    btnXoaLK.Enabled = false;
                }

                txtIdM.Text = mh.id.ToString();
                txtIdDMM.Text = bll1.getNameById(mh.idDM);
                txtNameM.Text = mh.name;
                txtSoLuongM.Text = mh.soluong.ToString();
                txtGiaBanM.Text = mh.giaban.ToString();
                txtGiaNhapM.Text = mh.gianhap.ToString();
                txtGiaNhapM.ReadOnly = txtGiaBanM.ReadOnly = txtSoLuongM.ReadOnly = txtIdM.ReadOnly = txtIdDMM.ReadOnly = txtNameM.ReadOnly = true;
                Width = 609;
                Height = 421;
            }
            // Danh mục
            else if (Fn == Function.DANH_MUC)
            {
                tbcUpdate.Controls.Add(tpDM);
                DanhMucBLL bll = new DanhMucBLL();
                DanhMuc dm = bll.getDetailsById(id);

                txtIdDM.Text = dm.id.ToString();
                txtNameDM.Text = dm.name;
                txtContentDM.Text = dm.content;

                txtIdDM.ReadOnly = txtNameDM.ReadOnly = txtContentDM.ReadOnly = true;
                Width = 426;
                Height = 419;
            }
            // Nhân viên
            else if (Fn == Function.NHAN_VIEN)
            {
                tbcUpdate.Controls.Add(tpNV);

                NhanVienBLL bll = new NhanVienBLL();
                NhanVien nv = bll.getDetailsById(id);

                txtIdNV.Text = nv.id.ToString();
                txtUsernameNV.Text = nv.username;
                txtPasswordNV.Text = nv.password;
                txtNameNV.Text = nv.name;
                txtChucVuNV.Text = nv.chucvu;
                if (nv.gioitinh == 0)
                    txtGioiTinhNV.Text = "Nữ";
                else
                    txtGioiTinhNV.Text = "Nam";

                txtDiaChiNV.Text = nv.diachi;
                txtSdtNV.Text = nv.sdt;

                txtIdNV.ReadOnly = txtUsernameNV.ReadOnly = txtPasswordNV.ReadOnly = txtNameNV.ReadOnly = txtChucVuNV.ReadOnly = txtGioiTinhNV.ReadOnly = txtDiaChiNV.ReadOnly = txtSdtNV.ReadOnly = true;
                Width = 631;
                Height = 428;
            }
            // Nhà cung cấp
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                tbcUpdate.Controls.Add(tpNCC);

                NhaCungCapBLL bll = new NhaCungCapBLL();
                NhaCungCap ncc = bll.getDetailsById(id);

                txtIdNCC.Text = ncc.id.ToString();
                txtNameNCC.Text = ncc.name;
                txtContentNCC.Text = ncc.content;
                txtSdtNCC.Text = ncc.sdt;
                txtDiaChiNCC.Text = ncc.diachi;

                txtIdNCC.ReadOnly = txtNameNCC.ReadOnly = txtContentNCC.ReadOnly = txtSdtNCC.ReadOnly = txtDiaChiNCC.ReadOnly = true;
                Width = 480;
                Height = 428;
            }
            // Khuyến mãi
            else if (Fn == Function.KHUYEN_MAI)
            {
                tbcUpdate.Controls.Add(tpKM);
                
                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                KhuyenMai km = bll.getDetailsById(id);

                txtIdKM.Text = km.id.ToString();
                txtContentKM.Text = km.content;
                txtGiaKM.Text = km.gia.ToString();

                if (km.typegia == 0)
                    txtTypeGiaKM.Text = "Phần trăm";
                else
                    txtTypeGiaKM.Text = "Nghìn đồng";
                txtBatDauKM.Text = km.starttime.Substring(0, km.starttime.LastIndexOf(" 12:00:00 AM"));
                txtKetThucKM.Text = km.endtime.Substring(0, km.endtime.LastIndexOf(" 12:00:00 AM"));

                txtTypeGiaKM.ReadOnly = txtIdKM.ReadOnly = txtContentKM.ReadOnly = txtGiaKM.ReadOnly = txtGiaKM.ReadOnly = txtBatDauKM.ReadOnly = txtKetThucKM.ReadOnly = true;
                Width = 580;
                Height = 421;
            }
            // Nhập hàng
            else if (Fn == Function.NHAP)
            {
                tbcUpdate.Controls.Add(tpNH);

                NhapHangBLL bll = new NhapHangBLL();
                NhapHang nh = bll.getDetailsById(id);

                txtIdNH.Text = nh.id.ToString();
                txtIdMHNH.Text = nh.idMH.ToString();
                txtIdNVNH.Text = nh.idNV.ToString();
                txtIdNCCNH.Text = nh.idNCC.ToString();
                txtSoLuongNH.Text = nh.soluong.ToString();
                txtThanhTienNH.Text = nh.thanhtien.ToString();

                txtIdNH.ReadOnly = txtIdMHNH.ReadOnly = txtIdNVNH.ReadOnly = txtIdNCCNH.ReadOnly = txtSoLuongNH.ReadOnly = txtThanhTienNH.ReadOnly = true;
                Width = 613;
                Height = 421;
            }
            // Xuất hàng
            else if (Fn == Function.XUAT)
            {
                tbcUpdate.Controls.Add(tpXH);

                XuatHangBLL bll = new XuatHangBLL();
                XuatHang xh = bll.getDetailsById(id);

                txtIdXH.Text = xh.id.ToString();
                txtIdNVXH.Text = xh.idNV.ToString();
                txtIdMHXH.Text = xh.idMH.ToString();
                txtSoLuongXH.Text = xh.soluong.ToString();
                txtThanhTienXH.Text = xh.thanhtien.ToString();
                txtNgayXuat.Text = xh.ngayxuat;

                txtIdXH.ReadOnly = txtIdNVXH.ReadOnly = txtIdMHXH.ReadOnly = txtSoLuongXH.ReadOnly = txtThanhTienXH.ReadOnly = txtNgayXuat.ReadOnly = true;
                Width = 613;
                Height = 421;
            }

        }

        void SuKien()
        {
            btnDongM.Click += Dong_Click;
            btnDongDM.Click += Dong_Click;
            btnDongKM.Click += Dong_Click;
            btnDongNCC.Click += Dong_Click;
            btnDongNV.Click += Dong_Click;
            btnDongNH.Click += Dong_Click;
            btnDongXH.Click += Dong_Click;


            btnSuaM.Click += SuaXem;
            btnSuaDM.Click += SuaXem;
            btnSuaKM.Click += SuaXem;
            btnSuaNCC.Click += SuaXem;
            btnSuaNV.Click += SuaXem;
            btnSuaNH.Click += SuaXem;
            btnSuaXH.Click += SuaXem;

            btnLuuM.Click += Luu_Click;
            btnLuuDM.Click += Luu_Click;
            btnLuuKM.Click += Luu_Click;
            btnLuuNCC.Click += Luu_Click;
            btnLuuNV.Click += Luu_Click;
            btnLuuNH.Click += Luu_Click;
            btnLuuXH.Click += Luu_Click;

            btnLuuM.Visible = false;
            btnLuuDM.Visible = false;
            btnLuuKM.Visible = false;
            btnLuuNCC.Visible = false;
            btnLuuNV.Visible = false;
            btnLuuNH.Visible = false;
            btnLuuXH.Visible = false;


        }

        void SuaXem(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Text == "Sửa")
            {
                btn.Text = "Xem";
                btnLuuNCC.Visible =  btnLuuM.Visible = btnLuuDM.Visible = btnLuuKM.Visible = btnLuuKM.Visible = btnLuuNV.Visible = btnLuuXH.Visible = btnLuuNH.Visible = true;
                //Mặt Hàng
                txtGiaNhapM.ReadOnly = txtGiaBanM.ReadOnly = txtNameM.ReadOnly = false;
                //Danh mục
                txtNameDM.ReadOnly = txtContentDM.ReadOnly = false;
                //Nhân viên
                txtNameNV.ReadOnly = txtDiaChiNV.ReadOnly = txtSdtNV.ReadOnly = false;
                //Nhà cung cấp
                txtNameNCC.ReadOnly = txtContentNCC.ReadOnly = txtSdtNCC.ReadOnly = txtDiaChiNCC.ReadOnly = false;
                //Khuyến mãi
                txtContentKM.ReadOnly = txtGiaKM.ReadOnly = txtGiaKM.ReadOnly = txtBatDauKM.ReadOnly = txtKetThucKM.ReadOnly = false;
                //Nhập hàng
                txtSoLuongNH.ReadOnly = false;
                //xuất hàng
                txtSoLuongXH.ReadOnly = false;
            }
            else
            {
                btn.Text = "Sửa";
                btnLuuM.Visible = btnLuuDM.Visible = btnLuuKM.Visible = btnLuuKM.Visible = btnLuuNV.Visible = btnLuuXH.Visible = btnLuuNCC.Visible = btnLuuNH.Visible = false;
                //Mặt Hàng
                txtGiaNhapM.ReadOnly = txtGiaBanM.ReadOnly = txtNameM.ReadOnly = true;
                //Danh mục
                txtNameDM.ReadOnly = txtContentDM.ReadOnly = true;
                //Nhân viên
                txtNameNV.ReadOnly = txtDiaChiNV.ReadOnly = txtSdtNV.ReadOnly = true;
                //Nhà cung cấp
                txtNameNCC.ReadOnly = txtContentNCC.ReadOnly = txtSdtNCC.ReadOnly = txtDiaChiNCC.ReadOnly = true;
                //Khuyến mãi
                txtContentKM.ReadOnly = txtGiaKM.ReadOnly = txtGiaKM.ReadOnly = txtBatDauKM.ReadOnly = txtKetThucKM.ReadOnly = true;
                //Nhập hàng
                txtSoLuongNH.ReadOnly = true;
                //xuất hàng
                txtSoLuongXH.ReadOnly = true;
            }
        }

        void Dong_Click(object sender, EventArgs e)
        {
            Close();
        }

        void Luu_Click(object sender, EventArgs e)
        {
            // Mặt hàng
            if (Fn == Function.MAT_HANG)
            {
                MatHangBLL bll = new MatHangBLL();
                MatHang mh = bll.getDetailsById(id);

                mh.name = txtNameM.Text;
                if (mh.name == "")
                {
                    MessageBox.Show("Tên mặt hàng không được bỏ trống");
                    txtNameM.Focus();
                    return;
                }

                float i;
                bool isNum = float.TryParse(txtGiaBanM.Text, out i);
                if (isNum)
                {
                    mh.giaban = i;
                    if (mh.giaban < 0)
                    {
                        MessageBox.Show("Giá bán không được nhỏ hơn 0");
                        txtGiaBanM.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai giá bán");
                    txtGiaBanM.Focus();
                    return;
                }

                isNum = float.TryParse(txtGiaNhapM.Text, out i);
                if (isNum)
                {
                    mh.gianhap = i;
                    if (mh.gianhap < 0)
                    {
                        MessageBox.Show("Giá nhập không được nhỏ hơn 0");
                        txtGiaNhapM.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai giá nhập");
                    txtGiaNhapM.Focus();
                    return;
                }


                if (mh.giaban < mh.gianhap)
                {
                    MessageBox.Show("Giá bán phải lớn giá nhập.");
                    txtGiaBanM.Focus();
                    return;
                }

                try
                {

                    if (bll.update(mh))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Danh mục
            else if (Fn == Function.DANH_MUC)
            {
                DanhMucBLL bll = new DanhMucBLL();
                DanhMuc dm = bll.getDetailsById(id);

                dm.name = txtNameDM.Text;
                if (dm.name == "")
                {
                    MessageBox.Show("Tên danh mục không được bỏ trống");
                    txtNameDM.Focus();
                    return;
                }

                dm.content = txtContentDM.Text;
                if (dm.content == "")
                {
                    MessageBox.Show("Mô tả không được bỏ trống");
                    txtContentDM.Focus();
                    return;
                }

                try
                {

                    if (bll.update(dm))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            // Nhân viên
            else if (Fn == Function.NHAN_VIEN)
            {
                NhanVienBLL bll = new NhanVienBLL();
                NhanVien nv = bll.getDetailsById(id);

                nv.name = txtNameNV.Text;
                if (nv.name == "")
                {
                    MessageBox.Show("Tên nhân viên không được để trống");
                    txtNameNV.Focus();
                    return;
                }

                nv.diachi = txtDiaChiNV.Text;
                if (nv.diachi == "")
                {
                    MessageBox.Show("Địa chỉ không được để trống");
                    txtDiaChiNV.Focus();
                    return;
                }

                nv.chucvu = txtChucVuNV.Text;
                if (nv.chucvu == "")
                {
                    MessageBox.Show("Chức vụ không được để trống");
                    txtDiaChiNV.Focus();
                    return;
                }

                double i;
                bool isNum = double.TryParse(txtSdtNV.Text, out i);
                if (isNum)
                    nv.sdt = txtSdtNV.Text;
                else
                {
                    MessageBox.Show("Nhập không đúng số điện thoại!");
                    txtSdtNV.Focus();
                    return;
                }

                try
                {
                    if (bll.update(nv))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            // Nhà cung cấp
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                NhaCungCapBLL bll = new NhaCungCapBLL();
                NhaCungCap ncc = bll.getDetailsById(id);

                ncc.name = txtNameNCC.Text;
                if (ncc.name == "")
                {
                    MessageBox.Show("Tên nhà cung cấp không được bỏ trống");
                    txtNameNCC.Focus();
                    return;
                }

                ncc.content = txtContentNCC.Text;
                if (ncc.content == "")
                {
                    MessageBox.Show("Mô tả không được bỏ trống");
                    txtContentNCC.Focus();
                    return;
                }

                ncc.diachi = txtDiaChiNCC.Text;
                if (ncc.diachi == "")
                {
                    MessageBox.Show("Địa chỉ không được bỏ trống");
                    txtDiaChiNCC.Focus();
                    return;
                }

                double i;

                bool isNum = double.TryParse(txtSdtNCC.Text, out i);
                if (isNum)
                    ncc.sdt = txtSdtNCC.Text;
                else
                {
                    MessageBox.Show("Nhập không đúng số điện thoại!");
                    txtSdtNCC.Focus();
                    return;
                }

                try
                {

                    if (bll.update(ncc))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Khuyến mãi
            else if (Fn == Function.KHUYEN_MAI)
            {
                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                KhuyenMai km = bll.getDetailsById(id);

                km.content = txtContentKM.Text;
                if (km.content == "")
                {
                    MessageBox.Show("Mô tả không được bỏ trống");
                    txtContentKM.Focus();
                    return;
                }



                km.starttime = txtBatDauKM.Text;
                km.endtime = txtKetThucKM.Text;

                DateTime start = Convert.ToDateTime(txtBatDauKM.Text);
                DateTime end = Convert.ToDateTime(txtKetThucKM.Text);

                //if (DateTime.Now > start)
                //{
                //    MessageBox.Show("Ngày bắt đầu nhỏ hơn ngày hiện tại?");
                //    txtBatDauKM.Focus();
                //    return;
                //}

                if (end < start)
                {
                    MessageBox.Show("Ngày bắt đầu lớn hơn ngày kết thúc?!");
                    txtKetThucKM.Focus();
                    return;
                }
                float i;
                bool isNum = float.TryParse(txtGiaKM.Text, out i);
                if (isNum)
                {
                    km.gia = i;
                    if (km.typegia == 0)
                    {
                        if (km.gia < 0 || km.gia > 100)
                        {
                            MessageBox.Show("Giới hạn % từ 0 đến 100!");
                            txtGiaKM.Focus();
                            return;
                        }
                    }


                }
                else
                {
                    MessageBox.Show("Nhập không đúng định dạng số!");
                    txtGiaKM.Focus();
                    return;
                }

                try
                {

                    if (bll.update(km))
                    {
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            // Nhập hàng
            else if (Fn == Function.NHAP)
            {
                NhapHangBLL bll = new NhapHangBLL();
                NhapHang nh = bll.getDetailsById(id);
                MatHangBLL bll1 = new MatHangBLL();
                MatHang mh = bll1.getDetailsById(nh.idMH);

                int i;
                bool isNum = int.TryParse(txtSoLuongNH.Text, out i);
                if (isNum)
                {
                    mh.soluong -= nh.soluong;
                    mh.soluong += i;
                    nh.soluong = i;
                }
                else
                {
                    MessageBox.Show("Nhập không đúng định dạng số");
                    txtSoLuongNH.Focus();
                    return;
                }

                try
                {

                    if (bll.update(nh))
                    {
                        bll1.update(mh);
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            // Xuất hàng
            else if (Fn == Function.XUAT)
            {
                XuatHangBLL bll = new XuatHangBLL();
                XuatHang xh = bll.getDetailsById(id);

                MatHangBLL bll1 = new MatHangBLL();
                MatHang mh = bll1.getDetailsById(xh.idMH);

                int i;
                bool isNum = int.TryParse(txtSoLuongXH.Text, out i);
                if (isNum)
                {
                    if (mh.soluong < i)
                    {
                        MessageBox.Show("Số lượng bán không được lớn hơn tồn kho {" + mh.soluong + "}");
                        return;
                    }

                    mh.soluong += xh.soluong;
                    mh.soluong -= i;
                    xh.soluong = i;
                }
                else
                {
                    MessageBox.Show("Nhập không đúng định dạng số!");
                    txtSoLuongXH.Focus();
                    return;
                }

                try
                {
                    if (bll.update(xh))
                    {
                        bll1.update(mh);
                        MessageBox.Show("Cập nhật thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void tpKM_Click(object sender, EventArgs e)
        {

        }

        private void btnLuuM_Click(object sender, EventArgs e)
        {

        }

        private void btnXoaLK_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtIdM.Text.ToString());
            KhuyenMaiBLL bll = new KhuyenMaiBLL();
            try
            {
                if(bll.delKM(id))
                {
                    MessageBox.Show("Xoá liên kết thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
