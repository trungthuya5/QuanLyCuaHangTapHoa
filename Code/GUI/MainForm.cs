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
    public partial class MainForm : Form
    {
        public Function Fn = Function.DASH_BOARD;
        public Function Ex;
        Function UI = Function.UI_DEFAULT;
        public int idNV;
        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(int idNV)
        {
            InitializeComponent();
            this.idNV = idNV;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            loadData();
            loadColor();
            //btnH.Click += click_btn;
            btnHome.Click += click_btn;
            btnSP.Click += click_btn;
            btnNV.Click += click_btn;
            btnTK.Click += click_btn;
            btnThoat.Click += click_btn;
            btnMH.Click += click_btn;
            btnDM.Click += click_btn;
            btnKM.Click += click_btn;
            btnNhap.Click += click_btn;
            btnXuat.Click += click_btn;
            btnTT.Click += click_btn;
            btnNCC.Click += click_btn;

        }

        #region btn_Click
        private void btnMH_Click(object sender, EventArgs e)
        {
            Fn = Function.MAT_HANG;
            Ex = Function.MAT_HANG;
            loadData();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Add add = new Add(Fn, idNV);
            add.ShowDialog();
            loadData();
        }

        private void btnS_Click(object sender, EventArgs e)
        {
            pnS.Show();
            hideGB();
            if (Fn == Function.MAT_HANG)
            {
                gbSMH.Show();
                gbSDM.Show();
            }
            else if (Fn == Function.DANH_MUC)
            {
                gbSDM.Show();
            }
            else if (Fn == Function.NHAN_VIEN)
            {
                gbSNV.Show();
            }
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                gbSNCC.Show();
            }
            else if (Fn == Function.NHAP)
            {
                gbSNCC.Show();
                gbSMH.Show();
                gbSNV.Show();
            }
            else if (Fn == Function.XUAT)
            {
                gbSNV.Show();
                gbSMH.Show();
            }
            else if (Fn == Function.KHUYEN_MAI)
            {
                gbSKM.Show();
            }

        }

        private void btnH_Click(object sender, EventArgs e)
        {
            if (pnLeft.Width == 223)
            {
                pnLeft.Width = 0;
            }
            else
            {
                pnLeft.Width = 223;
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Fn = Function.DASH_BOARD;
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát không?", "Đăng xuất", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Close();
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version: 1.0\nGiáo viên hướng dẫn: \n\tcô Trần Thị Phương\n Sinh viên thực hiện: \n\tNguyễn Trung Thuỳ\n\tNguyễn Thị Huyền Trang","About");
        }

        private void btnDM_Click(object sender, EventArgs e)
        {
            Fn = Function.DANH_MUC;
            Ex = Function.DANH_MUC;
            loadData();
        }

        private void btnKM_Click(object sender, EventArgs e)
        {
            Fn = Function.KHUYEN_MAI;
            Ex = Function.KHUYEN_MAI;
            loadData();
        }

        private void btnNCC_Click(object sender, EventArgs e)
        {
            Fn = Function.NHA_CUNG_CAP;
            Ex = Function.NHA_CUNG_CAP;
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Fn = Function.NHA_CUNG_CAP;
            loadData();
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            Fn = Function.NHAP;
            Ex = Function.NHAP;
            loadData();
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            Fn = Function.XUAT;
            Ex = Function.XUAT;
            loadData();
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            Fn = Function.NHAN_VIEN;
            Ex = Function.NHAN_VIEN;
            loadData();
        }

        private void btnSP_Click(object sender, EventArgs e)
        {
            Fn = Function.SAN_PHAM;
            Ex = Function.TK_SAN_PHAM;
            loadData();
        }
        #endregion

        #region Datagridview
        private void dgvContent_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (0 <= index && Fn != Function.THONG_KE && Fn != Function.SAN_PHAM)
            {
                int id = int.Parse(dgvContent.Rows[index].Cells[0].Value.ToString());
                Details dls = new Details(Fn, id);
                dls.ShowDialog();
                loadData();
            }

        }
        public void loadData()
        {
            dgvContent.Dock = DockStyle.Fill;
            pnS.Hide();
            pnMenu.Show();
            pnContent.Controls.Clear();
            pnContent.Controls.Add(dgvContent);
            if (idNV != 1)
            {
                btnNV.Visible = false;
            }

            //btnS.Visible = false;
            dgvContent.AllowUserToAddRows = false;
            // Mặt hàng
            if (Fn == Function.MAT_HANG)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                MatHangBLL mhb = new MatHangBLL();
                DanhMucBLL bll = new DanhMucBLL();

                List<MatHang> MH = new List<MatHang>();

                MH = mhb.getList();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                dgvContent.Columns[3].Name = "GIÁ MUA";
                dgvContent.Columns[4].Name = "GIÁ BÁN";
                dgvContent.Columns[5].Name = "DANH MỤC";

                List<string> str = new List<string>();
                foreach (MatHang mh in MH)
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    str.Add(mh.gianhap.ToString());
                    str.Add(mh.giaban.ToString());
                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }


            }
            // Danh mục
            else if (Fn == Function.DANH_MUC)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                DanhMucBLL bll = new DanhMucBLL();

                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 3;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÊN DANH MỤC";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";


                foreach (DanhMuc item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);


                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }




            }
            //Khuyến mãi
            else if (Fn == Function.KHUYEN_MAI)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MÔ TẢ";
                dgvContent.Columns[2].HeaderText = "GIÁ";
                dgvContent.Columns[3].HeaderText = "LOẠI GIÁ";
                dgvContent.Columns[4].HeaderText = "BẮT ĐẦU";
                dgvContent.Columns[5].HeaderText = "KẾT THÚC";

                foreach (KhuyenMai item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.content);
                    str.Add(item.gia.ToString());
                    if (item.typegia == 0)
                        str.Add("%");
                    else
                        str.Add("nghìn đồng");

                    str.Add(item.starttime);
                    str.Add(item.endtime);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }

            }
            // Nhà cung cấp
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                NhaCungCapBLL bll = new NhaCungCapBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 5;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";
                dgvContent.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
                dgvContent.Columns[4].HeaderText = "ĐỊA CHỈ";


                foreach (NhaCungCap item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);
                    str.Add(item.sdt);
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            // Nhập hàng
            else if (Fn == Function.NHAP)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                NhapHangBLL bll = new NhapHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 7;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[3].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[4].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[5].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[6].HeaderText = "NGÀY NHẬP";


                foreach (NhapHang item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhaCungCapBLL ncc = new NhaCungCapBLL();
                    str.Add(ncc.getNameById(item.idNCC));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngaynhap);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }

            }
            // Xuất hàng
            else if (Fn == Function.XUAT)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                XuatHangBLL bll = new XuatHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[4].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[5].HeaderText = "NGÀY BÁN";


                foreach (XuatHang item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngayxuat);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            // Nhân viên
            else if (Fn == Function.NHAN_VIEN)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);
                pnMenu.Controls.Add(btnLoad);

                NhanVienBLL bll = new NhanVienBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÀI KHOẢN";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "CHỨC VỤ";
                dgvContent.Columns[4].HeaderText = "GIỚI TÍNH";
                dgvContent.Columns[5].HeaderText = "ĐỊA CHỈ";


                foreach (NhanVien item in bll.getList())
                {
                    List<string> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.username);
                    str.Add(item.name);
                    str.Add(item.chucvu);
                    if (item.gioitinh == 0)
                        str.Add("Nữ");
                    else
                        str.Add("Nam");
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            // DashBoard
            else if (Fn == Function.DASH_BOARD)
            {
                pnMenu.Controls.Clear();
                pnContent.Controls.Clear();
                pnMenu.Hide();
                Dashboard db = new Dashboard();
                db.UIParent = this;
                db.Dock = DockStyle.Fill;
                pnContent.Controls.Add(db);
            }
            // Thống kê
            else if (Fn == Function.THONG_KE)
            {

                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                pnMenu.Controls.Add(btnTKMax);
                pnMenu.Controls.Add(btnTKMin);
                pnMenu.Controls.Add(btnBanMax);

                MatHangBLL mhb = new MatHangBLL();
                DanhMucBLL bll = new DanhMucBLL();

                List<MatHang> MH = new List<MatHang>();

                MH = mhb.getListTKMax();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 4;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                //dgvContent.Columns[3].Name = "GIÁ MUA";
                //dgvContent.Columns[4].Name = "GIÁ BÁN";
                dgvContent.Columns[3].Name = "DANH MỤC";

                List<string> str = new List<string>();
                foreach (MatHang mh in MH)
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    // str.Add(mh.gianhap.ToString());
                    //str.Add(mh.giaban.ToString());
                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);

                }
                dgvContent.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(96, 125, 139);

            }
            // Sản phẩm
            else if (Fn == Function.SAN_PHAM)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnExcel);
                MatHangBLL mhb = new MatHangBLL();
                DanhMucBLL bll = new DanhMucBLL();
                KhuyenMaiBLL kmb = new KhuyenMaiBLL();
                List<MatHang> MH = new List<MatHang>();

                MH = mhb.getList();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 8;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                dgvContent.Columns[3].Name = "GIÁ MUA";
                dgvContent.Columns[4].Name = "GIÁ GỐC";
                dgvContent.Columns[5].Name = "KHUYẾN MÃI";
                dgvContent.Columns[6].Name = "GIÁ BÁN";
                dgvContent.Columns[7].Name = "DANH MỤC";

                List<string> str = new List<string>();
                foreach (MatHang mh in MH)
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    str.Add(mh.gianhap.ToString());
                    str.Add(mh.giaban.ToString());
                    KhuyenMai km = kmb.getDetailsByIdMH(mh.id);
                    if (km != null)
                    {
                        if (km.typegia == 0)
                        {
                            str.Add(km.gia + " %");
                            str.Add((mh.giaban - mh.giaban / 100 * km.gia).ToString());
                        }

                        else
                        {
                            str.Add(km.gia + ". 000đ");
                            str.Add((mh.giaban - km.gia).ToString());
                        }

                    }
                    else
                    {
                        str.Add("Không có khuyến mãi");
                        str.Add(mh.giaban.ToString());
                    }


                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }

            //pnMenu.Controls.Add(btnExcel);
            // Khác DashBoard
            if (Fn != Function.DASH_BOARD && Fn != Function.SAN_PHAM && Fn != Function.THONG_KE)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dgvContent.Columns.Add(btn);
                btn.HeaderText = "DELETE";
                btn.Text = "Xóa";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                btn.CellTemplate.Style.BackColor = Color.Honeydew;

            }


        }
        private void dgvContent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1) return;
            if (dgvContent.Columns[e.ColumnIndex].HeaderText == "DELETE" && e.RowIndex >= 0)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu sẽ được chuyển vào thùng rác. Chọn Yes để xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    if (Fn == Function.MAT_HANG)
                    {
                        MatHangBLL bll = new MatHangBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.DANH_MUC)
                    {
                        DanhMucBLL bll = new DanhMucBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.KHUYEN_MAI)
                    {
                        KhuyenMaiBLL bll = new KhuyenMaiBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAN_VIEN)
                    {
                        NhanVienBLL bll = new NhanVienBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHA_CUNG_CAP)
                    {
                        NhaCungCapBLL bll = new NhaCungCapBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAP)
                    {
                        NhapHangBLL bll = new NhapHangBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.XUAT)
                    {
                        XuatHangBLL bll = new XuatHangBLL();
                        try
                        {
                            if (bll.hide(1, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    return;
                }

            }
            else if (dgvContent.Columns[e.ColumnIndex].HeaderText == "RESTORE" && e.RowIndex >= 0)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu đang được khôi phục. Chọn Yes để hoàn tất!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    if (Fn == Function.MAT_HANG)
                    {
                        MatHangBLL bll = new MatHangBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.DANH_MUC)
                    {
                        DanhMucBLL bll = new DanhMucBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.KHUYEN_MAI)
                    {
                        KhuyenMaiBLL bll = new KhuyenMaiBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAN_VIEN)
                    {
                        NhanVienBLL bll = new NhanVienBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHA_CUNG_CAP)
                    {
                        NhaCungCapBLL bll = new NhaCungCapBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAP)
                    {
                        NhapHangBLL bll = new NhapHangBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.XUAT)
                    {
                        XuatHangBLL bll = new XuatHangBLL();
                        try
                        {
                            if (bll.hide(0, Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    return;
                }

            }
            else if (dgvContent.Columns[e.ColumnIndex].HeaderText == "XOÁ HẲN" && e.RowIndex >= 0)
            {
                DialogResult dlr = MessageBox.Show("Dữ liệu sẽ bị xoá và không thể khôi phục. Chọn Yes để xóa!", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dlr == DialogResult.Yes)
                {
                    if (Fn == Function.MAT_HANG)
                    {
                        MatHangBLL bll = new MatHangBLL();
                        NhapHangBLL nhb = new NhapHangBLL();
                        List<NhapHang> nh = nhb.getListByNameMH(bll.getNameById(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())));
                        if(nh.Count !=0)
                        {
                            DialogResult dlr1 =  MessageBox.Show("Mặt hàng bạn xoá có liên kết đến nhập hàng. Bạn có muốn xoá tất cả nhập hàng?","Thông báo",MessageBoxButtons.OKCancel);

                            if(dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        XuatHangBLL xhb = new XuatHangBLL();
                        List<XuatHang> xh = xhb.getListByNameMH(bll.getNameById(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())));

                        if (xh.Count != 0)
                        {
                            DialogResult dlr1 = MessageBox.Show("Mặt hàng bạn xoá có liên kết đến xuất hàng. Bạn có muốn xoá tất cả xuất hàng?", "Thông báo", MessageBoxButtons.OKCancel);

                            if (dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.DANH_MUC)
                    {
                        DanhMucBLL bll = new DanhMucBLL();
                        MatHangBLL mhb = new MatHangBLL();
                        List<MatHang> mh = mhb.getListByIdDM(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString()));

                        if(mh.Count != 0)
                        {
                            DialogResult dlr1 = MessageBox.Show("Danh mục bạn xoá có liên kết đến mặt hàng. Bạn có muốn xoá tất cả mặt hàng?", "Thông báo", MessageBoxButtons.OKCancel);

                            if (dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.KHUYEN_MAI)
                    {
                        KhuyenMaiBLL bll = new KhuyenMaiBLL();
                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAN_VIEN)
                    {
                        NhanVienBLL bll = new NhanVienBLL();
                        NhapHangBLL nhb = new NhapHangBLL();
                        XuatHangBLL xhb = new XuatHangBLL();

                        List<XuatHang> xh = xhb.getListByNameNV(bll.getNameById(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())));

                        if(xh.Count != 0)
                        {
                            DialogResult dlr1 = MessageBox.Show("Nhân viên bạn xoá có liên kết đến xuất hàng. Bạn có muốn xoá tất cả xuất hàng có liên quan?", "Thông báo", MessageBoxButtons.OKCancel);

                            if (dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        List<NhapHang> nh = nhb.getListByNameNV(bll.getNameById(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())));

                        if (nh.Count != 0)
                        {
                            DialogResult dlr1 = MessageBox.Show("Nhân viên bạn xoá có liên kết đến nhập hàng. Bạn có muốn xoá tất cả nhập hàng có liên quan?", "Thông báo", MessageBoxButtons.OKCancel);

                            if (dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHA_CUNG_CAP)
                    {
                        NhaCungCapBLL bll = new NhaCungCapBLL();
                        NhapHangBLL nhb = new NhapHangBLL();
                        List<NhapHang> nh = nhb.getListByNameNCC(bll.getNameById(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())));

                        if(nh.Count != 0)
                        {
                            DialogResult dlr1 = MessageBox.Show("Nhà cung cấp bạn xoá có liên kết đến nhậpt hàng. Bạn có muốn xoá tất cả nhập hàng có liên quan?", "Thông báo", MessageBoxButtons.OKCancel);

                            if (dlr1 == DialogResult.Cancel)
                            {
                                return;
                            }
                        }

                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.NHAP)
                    {
                        NhapHangBLL bll = new NhapHangBLL();
                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (Fn == Function.XUAT)
                    {
                        XuatHangBLL bll = new XuatHangBLL();
                        try
                        {
                            if (bll.del(Convert.ToInt32(dgvContent.Rows[e.RowIndex].Cells[0].Value.ToString())))
                                loadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                }
                else
                {
                    return;
                }

            }
        }

        #endregion

        #region Tim_kiem
        void hideGB()
        {
            gbSDM.Hide();
            gbSMH.Hide();
            gbSNV.Hide();
            gbSNCC.Hide();
            gbSKM.Hide();
        }

        void resetText(TextBox s)
        {
            if (s != txtSMH)
                txtSMH.ResetText();
            if (s != txtSDM)
                txtSDM.ResetText();
            if (s != txtSNCC)
                txtSNCC.ResetText();
            if (s != txtSNV)
                txtSNV.ResetText();
            if (s != txtSKM)
                txtSKM.ResetText();
        }

        private void txtSName_TextChanged(object sender, EventArgs e)
        {
            resetText(txtSMH);
            if (Fn == Function.MAT_HANG)
            {
                MatHangBLL bll = new MatHangBLL();

                List<MatHang> MH = new List<MatHang>();

                MH = bll.getListByString(txtSMH.Text);
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                dgvContent.Columns[3].Name = "GIÁ MUA";
                dgvContent.Columns[4].Name = "GIÁ BÁN";
                dgvContent.Columns[5].Name = "DANH MỤC";

                List<String> str = new List<string>();
                foreach (MatHang mh in MH)
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    str.Add(mh.gianhap.ToString());
                    str.Add(mh.giaban.ToString());
                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.NHAP)
            {
                NhapHangBLL bll = new NhapHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 7;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[3].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[4].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[5].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[6].HeaderText = "NGÀY NHẬP";


                foreach (NhapHang item in bll.getListByStringMH(txtSMH.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhaCungCapBLL ncc = new NhaCungCapBLL();
                    str.Add(ncc.getNameById(item.idNCC));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngaynhap);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.XUAT)
            {

                XuatHangBLL bll = new XuatHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[4].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[5].HeaderText = "NGÀY BÁN";


                foreach (XuatHang item in bll.getListByStringMH(txtSMH.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngayxuat);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }


        }

        private void txtSDM_TextChanged(object sender, EventArgs e)
        {
            resetText(txtSDM);
            if (Fn == Function.DANH_MUC)
            {
                DanhMucBLL bll = new DanhMucBLL();

                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 3;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÊN DANH MỤC";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";


                foreach (DanhMuc item in bll.getListByString(txtSDM.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);


                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.MAT_HANG)
            {
                MatHangBLL bll = new MatHangBLL();

                List<MatHang> MH = new List<MatHang>();

                MH = bll.getListByStringDM(txtSDM.Text);
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                dgvContent.Columns[3].Name = "GIÁ MUA";
                dgvContent.Columns[4].Name = "GIÁ BÁN";
                dgvContent.Columns[5].Name = "DANH MỤC";

                List<String> str = new List<string>();
                foreach (MatHang mh in MH)
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    str.Add(mh.gianhap.ToString());
                    str.Add(mh.giaban.ToString());
                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
        }

        private void txtSNV_TextChanged(object sender, EventArgs e)
        {
            resetText(txtSNV);
            if (Fn == Function.NHAN_VIEN)
            {
                NhanVienBLL bll = new NhanVienBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÀI KHOẢN";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "CHỨC VỤ";
                dgvContent.Columns[4].HeaderText = "GIỚI TÍNH";
                dgvContent.Columns[5].HeaderText = "ĐỊA CHỈ";


                foreach (NhanVien item in bll.getListByString(txtSNV.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.username);
                    str.Add(item.name);
                    str.Add(item.chucvu);
                    if (item.gioitinh == 0)
                        str.Add("Nữ");
                    else
                        str.Add("Nam");
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.NHAP)
            {
                NhapHangBLL bll = new NhapHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 7;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[3].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[4].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[5].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[6].HeaderText = "NGÀY NHẬP";


                foreach (NhapHang item in bll.getListByStringNV(txtSNV.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhaCungCapBLL ncc = new NhaCungCapBLL();
                    str.Add(ncc.getNameById(item.idNCC));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngaynhap);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.XUAT)
            {
                XuatHangBLL bll = new XuatHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[4].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[5].HeaderText = "NGÀY BÁN";


                foreach (XuatHang item in bll.getListByStringNV(txtSNV.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngayxuat);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
        }

        private void txtSNCC_TextChanged(object sender, EventArgs e)
        {
            resetText(txtSNCC);
            if (Fn == Function.NHA_CUNG_CAP)
            {
                NhaCungCapBLL bll = new NhaCungCapBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 5;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";
                dgvContent.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
                dgvContent.Columns[4].HeaderText = "ĐỊA CHỈ";


                foreach (NhaCungCap item in bll.getListByString(txtSNCC.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);
                    str.Add(item.sdt);
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.NHAP)
            {
                NhapHangBLL bll = new NhapHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 7;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[3].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[4].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[5].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[6].HeaderText = "NGÀY NHẬP";


                foreach (NhapHang item in bll.getListByStringNCC(txtSNCC.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhaCungCapBLL ncc = new NhaCungCapBLL();
                    str.Add(ncc.getNameById(item.idNCC));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngaynhap);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }

        }

        private void txtSKM_TextChanged(object sender, EventArgs e)
        {
            resetText(txtSKM);
            if (Fn == Function.KHUYEN_MAI)
            {
                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MÔ TẢ";
                dgvContent.Columns[2].HeaderText = "GIÁ";
                dgvContent.Columns[3].HeaderText = "LOẠI GIÁ";
                dgvContent.Columns[4].HeaderText = "BẮT ĐẦU";
                dgvContent.Columns[5].HeaderText = "KẾT THÚC";



                foreach (KhuyenMai item in bll.getListByString(txtSKM.Text))
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.content);
                    str.Add(item.gia.ToString());
                    if (item.typegia == 0)
                        str.Add("%");
                    else
                        str.Add("nghìn đồng");

                    str.Add(item.starttime);
                    str.Add(item.endtime);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
        }
        #endregion

        #region Thong_ke

        private void btnTK_Click(object sender, EventArgs e)
        {
            Fn = Function.THONG_KE;
            Ex = Function.TK_MAX;
            loadData();
        }

        private void btnTKMax_Click(object sender, EventArgs e)
        {
            Ex = Function.TK_MAX;
            pnMenu.Controls.Clear();
            pnMenu.Controls.Add(btnExcel);
            pnMenu.Controls.Add(btnTKMax);
            pnMenu.Controls.Add(btnTKMin);
            pnMenu.Controls.Add(btnBanMax);
            MatHangBLL mhb = new MatHangBLL();
            DanhMucBLL bll = new DanhMucBLL();

            List<MatHang> MH = new List<MatHang>();

            MH = mhb.getListTKMax();
            dgvContent.Columns.Clear();
            dgvContent.ColumnCount = 4;
            dgvContent.Columns[0].Name = "ID";
            dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
            dgvContent.Columns[2].Name = "SỐ LƯỢNG";
            //dgvContent.Columns[3].Name = "GIÁ MUA";
            //dgvContent.Columns[4].Name = "GIÁ BÁN";
            dgvContent.Columns[3].Name = "DANH MỤC";

            List<string> str = new List<string>();
            foreach (MatHang mh in MH)
            {
                str.Clear();
                str.Add(mh.id.ToString());
                str.Add(mh.name);
                str.Add(mh.soluong.ToString());
                //str.Add(mh.gianhap.ToString());
                //str.Add(mh.giaban.ToString());
                DanhMucBLL dm = new DanhMucBLL();
                str.Add(dm.getNameById(mh.idDM));
                string[] abc = str.ToArray();
                dgvContent.Rows.Add(abc);

            }
            dgvContent.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(96, 125, 139);
        }

        private void btnTKMin_Click(object sender, EventArgs e)
        {
            Ex = Function.TK_MIN;
            pnMenu.Controls.Clear();
            pnMenu.Controls.Add(btnExcel);
            pnMenu.Controls.Add(btnTKMax);
            pnMenu.Controls.Add(btnTKMin);
            pnMenu.Controls.Add(btnBanMax);
            MatHangBLL mhb = new MatHangBLL();
            DanhMucBLL bll = new DanhMucBLL();

            List<MatHang> MH = new List<MatHang>();

            MH = mhb.getListTK0();
            dgvContent.Columns.Clear();
            dgvContent.ColumnCount = 4;
            dgvContent.Columns[0].Name = "ID";
            dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
            dgvContent.Columns[2].Name = "SỐ LƯỢNG";
            //dgvContent.Columns[3].Name = "GIÁ MUA";
            //dgvContent.Columns[4].Name = "GIÁ BÁN";
            dgvContent.Columns[3].Name = "DANH MỤC";

            List<string> str = new List<string>();
            foreach (MatHang mh in MH)
            {
                str.Clear();
                str.Add(mh.id.ToString());
                str.Add(mh.name);
                str.Add(mh.soluong.ToString());
                //str.Add(mh.gianhap.ToString());
                // str.Add(mh.giaban.ToString());
                DanhMucBLL dm = new DanhMucBLL();
                str.Add(dm.getNameById(mh.idDM));
                string[] abc = str.ToArray();
                dgvContent.Rows.Add(abc);

            }
            dgvContent.Columns[2].DefaultCellStyle.BackColor = Color.FromArgb(96, 125, 139);
        }

        private void btnBanMax_Click(object sender, EventArgs e)
        {
            Ex = Function.BAN_MAX;
            pnMenu.Controls.Clear();
            pnMenu.Controls.Add(btnExcel);
            pnMenu.Controls.Add(btnTKMax);
            pnMenu.Controls.Add(btnTKMin);
            pnMenu.Controls.Add(btnBanMax);
            MatHangBLL mhb = new MatHangBLL();
            DanhMucBLL bll = new DanhMucBLL();

            DataTable table = mhb.getListBanMax();


            dgvContent.Columns.Clear();
            dgvContent.ColumnCount = 6;
            dgvContent.Columns[0].Name = "ID";
            dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
            dgvContent.Columns[2].Name = "SỐ LƯỢNG";
            //dgvContent.Columns[3].Name = "GIÁ MUA";
            //dgvContent.Columns[4].Name = "GIÁ BÁN";
            dgvContent.Columns[3].Name = "DANH MỤC";
            dgvContent.Columns[4].Name = "SỐ LƯỢNG BÁN";
            dgvContent.Columns[5].Name = "THÀNH TIỀN";

            List<string> str = new List<string>();
            foreach (DataRow item in table.Rows)
            {
                str.Clear();
                str.Add(item["id"].ToString());
                str.Add(item["name"].ToString());
                str.Add(item["soluong"].ToString());
                //str.Add(mh.gianhap.ToString());
                // str.Add(mh.giaban.ToString());
                DanhMucBLL dm = new DanhMucBLL();
                str.Add(dm.getNameById(int.Parse(item["idDM"].ToString())));

                str.Add(item["soluongXH"].ToString());
                str.Add(item["tienXH"].ToString());

                string[] abc = str.ToArray();
                dgvContent.Rows.Add(abc);

            }
            dgvContent.Columns[4].DefaultCellStyle.BackColor = Color.FromArgb(96, 125, 139);
        }
        #endregion

        #region Thung_rac
        private void btnTR_Click(object sender, EventArgs e)
        {
            dgvContent.AllowUserToAddRows = false;
            if (Fn == Function.MAT_HANG)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                MatHangBLL bll = new MatHangBLL();


                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].Name = "ID";
                dgvContent.Columns[1].Name = "TÊN MẶT HÀNG";
                dgvContent.Columns[2].Name = "SỐ LƯỢNG";
                dgvContent.Columns[3].Name = "GIÁ MUA";
                dgvContent.Columns[4].Name = "GIÁ BÁN";
                dgvContent.Columns[5].Name = "DANH MỤC";

                List<String> str = new List<string>();
                foreach (MatHang mh in bll.getListHide())
                {
                    str.Clear();
                    str.Add(mh.id.ToString());
                    str.Add(mh.name);
                    str.Add(mh.soluong.ToString());
                    str.Add(mh.gianhap.ToString());
                    str.Add(mh.giaban.ToString());
                    DanhMucBLL dm = new DanhMucBLL();
                    str.Add(dm.getNameById(mh.idDM));
                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }


            }
            else if (Fn == Function.DANH_MUC)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                DanhMucBLL bll = new DanhMucBLL();

                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 3;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÊN DANH MỤC";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";


                foreach (DanhMuc item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);


                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }




            }
            else if (Fn == Function.KHUYEN_MAI)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MÔ TẢ";
                dgvContent.Columns[2].HeaderText = "GIÁ";
                dgvContent.Columns[3].HeaderText = "LOẠI GIÁ";
                dgvContent.Columns[4].HeaderText = "BẮT ĐẦU";
                dgvContent.Columns[5].HeaderText = "KẾT THÚC";



                foreach (KhuyenMai item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.content);
                    str.Add(item.gia.ToString());
                    if (item.typegia == 0)
                        str.Add("%");
                    else
                        str.Add("nghìn đồng");

                    str.Add(item.starttime);
                    str.Add(item.endtime);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }

            }
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                NhaCungCapBLL bll = new NhaCungCapBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 5;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÊN NHÀ CUNG CẤP";
                dgvContent.Columns[2].HeaderText = "MÔ TẢ";
                dgvContent.Columns[3].HeaderText = "SỐ ĐIỆN THOẠI";
                dgvContent.Columns[4].HeaderText = "ĐỊA CHỈ";


                foreach (NhaCungCap item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.name);
                    str.Add(item.content);
                    str.Add(item.sdt);
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.NHAP)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                NhapHangBLL bll = new NhapHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 7;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÀ CUNG CẤP";
                dgvContent.Columns[3].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[4].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[5].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[6].HeaderText = "NGÀY NHẬP";


                foreach (NhapHang item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhaCungCapBLL ncc = new NhaCungCapBLL();
                    str.Add(ncc.getNameById(item.idNCC));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngaynhap);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }

            }
            else if (Fn == Function.XUAT)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                XuatHangBLL bll = new XuatHangBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "MẶT HÀNG";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "SỐ LƯỢNG";
                dgvContent.Columns[4].HeaderText = "THÀNH TIỀN";
                dgvContent.Columns[5].HeaderText = "NGÀY BÁN";


                foreach (XuatHang item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    MatHangBLL mh = new MatHangBLL();
                    str.Add(mh.getNameById(item.idMH));
                    NhanVienBLL nv = new NhanVienBLL();
                    str.Add(nv.getNameById(item.idNV));
                    str.Add(item.soluong.ToString());
                    str.Add(item.thanhtien.ToString());
                    str.Add(item.ngayxuat);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.NHAN_VIEN)
            {
                pnMenu.Controls.Clear();
                pnMenu.Controls.Add(btnAdd);
                pnMenu.Controls.Add(btnS);
                pnMenu.Controls.Add(btnTR);

                NhanVienBLL bll = new NhanVienBLL();
                dgvContent.Columns.Clear();
                dgvContent.ColumnCount = 6;
                dgvContent.Columns[0].HeaderText = "ID";
                dgvContent.Columns[1].HeaderText = "TÀI KHOẢN";
                dgvContent.Columns[2].HeaderText = "NHÂN VIÊN";
                dgvContent.Columns[3].HeaderText = "CHỨC VỤ";
                dgvContent.Columns[4].HeaderText = "GIỚI TÍNH";
                dgvContent.Columns[5].HeaderText = "ĐỊA CHỈ";


                foreach (NhanVien item in bll.getListHide())
                {
                    List<String> str = new List<string>();
                    str.Add(item.id.ToString());
                    str.Add(item.username);
                    str.Add(item.name);
                    str.Add(item.chucvu);
                    if (item.gioitinh == 0)
                        str.Add("Nữ");
                    else
                        str.Add("Nam");
                    str.Add(item.diachi);

                    string[] abc = str.ToArray();
                    dgvContent.Rows.Add(abc);
                }
            }
            else if (Fn == Function.DASH_BOARD)
            {
                pnMenu.Controls.Clear();
            }

            if (Fn != Function.DASH_BOARD)
            {
                DataGridViewButtonColumn btn0 = new DataGridViewButtonColumn();
                dgvContent.Columns.Add(btn0);
                btn0.HeaderText = "RESTORE";
                btn0.Text = "Khôi Phục";
                //btn0.Name = "btn";
                btn0.UseColumnTextForButtonValue = true;

                //btn0.CellTemplate.Style.BackColor = Color.Honeydew;

                DataGridViewButtonColumn btn1 = new DataGridViewButtonColumn();
                dgvContent.Columns.Add(btn1);
                btn1.HeaderText = "XOÁ HẲN";
                btn1.Text = "Xóa";
                //btn1.Name = "btn";
                btn1.UseColumnTextForButtonValue = true;

                //btn1.CellTemplate.Style.BackColor = Color.Honeydew;

            }


        }
        #endregion

        #region Excel
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel excel = new ExportToExcel();

            DataTable dt = new DataTable();

            while (dt.Rows.Count < dgvContent.Rows.Count)
            {
                dt.Rows.Add(); // đếm số Rows để khởi tạo.
            }


            for (int i = 0; i < dgvContent.Columns.Count; i++)
            {
                if (dgvContent.Rows.Count != -1)
                    if (dgvContent[i, (dgvContent.Rows.Count - 1)].Value.ToString() != "Xóa")
                        dt.Columns.Add(dgvContent.Columns[i].Name.ToString());

                for (int j = 0; j < dgvContent.Rows.Count; j++)
                {
                    if (dgvContent[i, j].Value.ToString() != "Xóa")
                        dt.Rows[j][i] = dgvContent[i, j].Value.ToString();
                }
            }

            try
            {
                if (Ex == Function.TK_SAN_PHAM)
                    excel.ExportSanPham(dt, "Danh Sach", "DANH SÁCH CÁC SẢN PHẨM");
                else if (Ex == Function.TK_MAX || Ex == Function.TK_MIN)
                    excel.ExportSoLuong(dt, "Danh Sach", "DANH SÁCH CÁC SẢN PHẨM TỒN KHO");
                else if (Ex == Function.BAN_MAX)
                    excel.ExportBanMax(dt, "Danh Sach", "DANH SÁCH SẢN PHẨM BÁN NHIỀU NHẤT");
                else if (Ex == Function.MAT_HANG)
                    excel.ExportMatHang(dt, "Danh Sach", "DANH SÁCH CÁC MẶT HÀNG");
                else if (Ex == Function.DANH_MUC)
                    excel.ExportDanhMuc(dt, "Danh Sach", "DANH SÁCH CÁC DANH MỤC");
                else if (Ex == Function.KHUYEN_MAI)
                    excel.ExportKhuyenMai(dt, "Danh Sach", "DANH SÁCH KHUYẾN MÃI");
                else if (Ex == Function.NHA_CUNG_CAP)
                    excel.ExportNhaCungCap(dt, "Danh Sach", "DANH SÁCH NHÀ CUNG CẤP");
                else if (Ex == Function.NHAN_VIEN)
                    excel.ExportNhanVien(dt, "Danh Sach", "DANH SÁCH NHÂN VIÊN");
                else if (Ex == Function.NHAP)
                    excel.ExportNhapHang(dt, "Danh Sach", "DANH SÁCH NHẬP HÀNG");
                else if (Ex == Function.XUAT)
                    excel.ExportXuatHang(dt, "Danh Sach", "DANH SÁCH BÁN HÀNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không được tắt khi đang tạo file Excel. Lỗi: " + ex.Message);
            }
        }
        #endregion

        #region show_time
        private void timer1_Tick(object sender, EventArgs e)
        {

            lbTime.Text = DateTime.Now.ToString();
        }
        #endregion

        #region click_color
        private void btnCyan_Click(object sender, EventArgs e)
        {
            UI = Function.UI_CYAN;
            loadColor();
        }

        private void btnDEFAULT_Click(object sender, EventArgs e)
        {
            UI = Function.UI_DEFAULT;
            loadColor();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            UI = Function.UI_BLUE;
            loadColor();
        }

        private void btnPink_Click(object sender, EventArgs e)
        {
            UI = Function.UI_PINK;
            loadColor();
        }

        private void btnTeal_Click(object sender, EventArgs e)
        {
            UI = Function.UI_TEAL;
            loadColor();
        }

        void click_btn(object sender, EventArgs e)
        {
            loadColor();
            Button btn = sender as Button;
            if (UI == Function.UI_TEAL)
                btn.BackColor = Color.FromArgb(0, 77, 64);
            if (UI == Function.UI_PINK)
                btn.BackColor = Color.FromArgb(136, 14, 79);
            else if (UI == Function.UI_BLUE)
                btn.BackColor = Color.FromArgb(13, 71, 161);
            else if (UI == Function.UI_CYAN)
                btn.BackColor = Color.FromArgb(0, 96, 100);
            else if (UI == Function.UI_DEFAULT)
                btn.BackColor = Color.FromArgb(29, 39, 43);
        }

        void loadColor()
        {
            if (UI == Function.UI_TEAL)
            {
                BackColor = Color.FromArgb(224, 247, 250);
                pnTop.BackColor = Color.FromArgb(0, 137, 123);
                pnLeft.BackColor = Color.FromArgb(0, 121, 107);
                pn2.BackColor = pnMenu.BackColor = Color.FromArgb(245, 245, 245);

                pnQL.BackColor = pnCN.BackColor = Color.FromArgb(0, 77, 64);
                pnQL.ForeColor = pnCN.ForeColor = Color.FromArgb(255, 255, 255);
                btnH.BackColor = btnHome.BackColor = btnSP.BackColor = btnNV.BackColor = btnTK.BackColor = btnThoat.BackColor = Color.FromArgb(0, 137, 123);
                btnH.ForeColor = btnHome.ForeColor = btnSP.ForeColor = btnNV.ForeColor = btnTK.ForeColor = btnThoat.ForeColor = Color.FromArgb(236, 239, 241);
                btnH.FlatAppearance.MouseOverBackColor = btnHome.FlatAppearance.MouseOverBackColor = btnSP.FlatAppearance.MouseOverBackColor = btnNV.FlatAppearance.MouseOverBackColor = btnTK.FlatAppearance.MouseOverBackColor = btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 64);
                btnH.FlatAppearance.MouseDownBackColor = btnHome.FlatAppearance.MouseDownBackColor = btnSP.FlatAppearance.MouseDownBackColor = btnNV.FlatAppearance.MouseDownBackColor = btnTK.FlatAppearance.MouseDownBackColor = btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 77, 64);
                btnTT.BackColor = btnMH.BackColor = btnDM.BackColor = btnKM.BackColor = btnNCC.BackColor = btnNhap.BackColor = btnXuat.BackColor = Color.FromArgb(0, 121, 107);
                btnTT.ForeColor = btnMH.ForeColor = btnDM.ForeColor = btnKM.ForeColor = btnNCC.ForeColor = btnNhap.ForeColor = btnXuat.ForeColor = Color.FromArgb(236, 239, 241);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 64);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 77, 64);
            }
            else if (UI == Function.UI_PINK)
            {
                BackColor = Color.FromArgb(224, 247, 250);
                pnTop.BackColor = Color.FromArgb(197, 17, 98);
                pnLeft.BackColor = Color.FromArgb(233, 30, 99);
                pn2.BackColor = pnMenu.BackColor = Color.FromArgb(245, 245, 245);

                pnQL.BackColor = pnCN.BackColor = Color.FromArgb(136, 14, 79);
                pnQL.ForeColor = pnCN.ForeColor = Color.FromArgb(255, 255, 255);
                btnH.BackColor = btnHome.BackColor = btnSP.BackColor = btnNV.BackColor = btnTK.BackColor = btnThoat.BackColor = Color.FromArgb(197, 17, 98);
                btnH.ForeColor = btnHome.ForeColor = btnSP.ForeColor = btnNV.ForeColor = btnTK.ForeColor = btnThoat.ForeColor = Color.FromArgb(236, 239, 241);
                btnH.FlatAppearance.MouseOverBackColor = btnHome.FlatAppearance.MouseOverBackColor = btnSP.FlatAppearance.MouseOverBackColor = btnNV.FlatAppearance.MouseOverBackColor = btnTK.FlatAppearance.MouseOverBackColor = btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(136, 14, 79);
                btnH.FlatAppearance.MouseDownBackColor = btnHome.FlatAppearance.MouseDownBackColor = btnSP.FlatAppearance.MouseDownBackColor = btnNV.FlatAppearance.MouseDownBackColor = btnTK.FlatAppearance.MouseDownBackColor = btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(136, 14, 79);
                btnTT.BackColor = btnMH.BackColor = btnDM.BackColor = btnKM.BackColor = btnNCC.BackColor = btnNhap.BackColor = btnXuat.BackColor = Color.FromArgb(233, 30, 99);
                btnTT.ForeColor = btnMH.ForeColor = btnDM.ForeColor = btnKM.ForeColor = btnNCC.ForeColor = btnNhap.ForeColor = btnXuat.ForeColor = Color.FromArgb(236, 239, 241);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(136, 14, 79);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(136, 14, 79);
            }
            else if (UI == Function.UI_BLUE)
            {
                BackColor = Color.FromArgb(224, 247, 250);
                pnTop.BackColor = Color.FromArgb(25, 118, 210);
                pnLeft.BackColor = Color.FromArgb(41, 121, 255);
                pn2.BackColor = pnMenu.BackColor = Color.FromArgb(245, 245, 245);

                pnQL.BackColor = pnCN.BackColor = Color.FromArgb(13, 71, 161);
                pnQL.ForeColor = pnCN.ForeColor = Color.FromArgb(255, 255, 255);
                btnH.BackColor = btnHome.BackColor = btnSP.BackColor = btnNV.BackColor = btnTK.BackColor = btnThoat.BackColor = Color.FromArgb(25, 118, 210);
                btnH.ForeColor = btnHome.ForeColor = btnSP.ForeColor = btnNV.ForeColor = btnTK.ForeColor = btnThoat.ForeColor = Color.FromArgb(236, 239, 241);
                btnH.FlatAppearance.MouseOverBackColor = btnHome.FlatAppearance.MouseOverBackColor = btnSP.FlatAppearance.MouseOverBackColor = btnNV.FlatAppearance.MouseOverBackColor = btnTK.FlatAppearance.MouseOverBackColor = btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(13, 71, 161);
                btnH.FlatAppearance.MouseDownBackColor = btnHome.FlatAppearance.MouseDownBackColor = btnSP.FlatAppearance.MouseDownBackColor = btnNV.FlatAppearance.MouseDownBackColor = btnTK.FlatAppearance.MouseDownBackColor = btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(13, 71, 161);
                btnTT.BackColor = btnMH.BackColor = btnDM.BackColor = btnKM.BackColor = btnNCC.BackColor = btnNhap.BackColor = btnXuat.BackColor = Color.FromArgb(41, 121, 255);
                btnTT.ForeColor = btnMH.ForeColor = btnDM.ForeColor = btnKM.ForeColor = btnNCC.ForeColor = btnNhap.ForeColor = btnXuat.ForeColor = Color.FromArgb(236, 239, 241);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(13, 71, 161);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(13, 71, 161);
            }
            else if (UI == Function.UI_CYAN)
            {
                BackColor = Color.FromArgb(224, 247, 250);
                pnTop.BackColor = Color.FromArgb(0, 131, 143);
                pnLeft.BackColor = Color.FromArgb(0, 131, 143);
                pn2.BackColor = pnMenu.BackColor = Color.FromArgb(245, 245, 245);

                pnQL.BackColor = pnCN.BackColor = Color.FromArgb(0, 96, 100);
                pnQL.ForeColor = pnCN.ForeColor = Color.FromArgb(255, 255, 255);
                btnH.BackColor = btnHome.BackColor = btnSP.BackColor = btnNV.BackColor = btnTK.BackColor = btnThoat.BackColor = Color.FromArgb(0, 131, 143);
                btnH.ForeColor = btnHome.ForeColor = btnSP.ForeColor = btnNV.ForeColor = btnTK.ForeColor = btnThoat.ForeColor = Color.FromArgb(236, 239, 241);
                btnH.FlatAppearance.MouseOverBackColor = btnHome.FlatAppearance.MouseOverBackColor = btnSP.FlatAppearance.MouseOverBackColor = btnNV.FlatAppearance.MouseOverBackColor = btnTK.FlatAppearance.MouseOverBackColor = btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 172, 193);
                btnH.FlatAppearance.MouseDownBackColor = btnHome.FlatAppearance.MouseDownBackColor = btnSP.FlatAppearance.MouseDownBackColor = btnNV.FlatAppearance.MouseDownBackColor = btnTK.FlatAppearance.MouseDownBackColor = btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 172, 193);
                btnTT.BackColor = btnMH.BackColor = btnDM.BackColor = btnKM.BackColor = btnNCC.BackColor = btnNhap.BackColor = btnXuat.BackColor = Color.FromArgb(0, 131, 143);
                btnTT.ForeColor = btnMH.ForeColor = btnDM.ForeColor = btnKM.ForeColor = btnNCC.ForeColor = btnNhap.ForeColor = btnXuat.ForeColor = Color.FromArgb(236, 239, 241);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 172, 193);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 172, 193);
            }
            else if (UI == Function.UI_DEFAULT)
            {
                BackColor = Color.FromArgb(245, 245, 245);
                pnTop.BackColor = Color.FromArgb(55, 71, 79);
                pnLeft.BackColor = Color.FromArgb(38, 50, 56);
                pn2.BackColor = pnMenu.BackColor = Color.FromArgb(245, 245, 245);

                pnQL.BackColor = pnCN.BackColor = Color.FromArgb(29, 39, 43);
                pnQL.ForeColor = pnCN.ForeColor = Color.FromArgb(255, 255, 255);
                btnH.BackColor = btnHome.BackColor = btnSP.BackColor = btnNV.BackColor = btnTK.BackColor = btnThoat.BackColor = Color.FromArgb(55, 71, 79);
                btnH.ForeColor = btnHome.ForeColor = btnSP.ForeColor = btnNV.ForeColor = btnTK.ForeColor = btnThoat.ForeColor = Color.FromArgb(236, 239, 241);
                btnH.FlatAppearance.MouseOverBackColor = btnHome.FlatAppearance.MouseOverBackColor = btnSP.FlatAppearance.MouseOverBackColor = btnNV.FlatAppearance.MouseOverBackColor = btnTK.FlatAppearance.MouseOverBackColor = btnThoat.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 39, 43);
                btnH.FlatAppearance.MouseDownBackColor = btnHome.FlatAppearance.MouseDownBackColor = btnSP.FlatAppearance.MouseDownBackColor = btnNV.FlatAppearance.MouseDownBackColor = btnTK.FlatAppearance.MouseDownBackColor = btnThoat.FlatAppearance.MouseDownBackColor = Color.FromArgb(29, 39, 43);
                btnTT.BackColor = btnMH.BackColor = btnDM.BackColor = btnKM.BackColor = btnNCC.BackColor = btnNhap.BackColor = btnXuat.BackColor = Color.FromArgb(38, 50, 56);
                btnTT.ForeColor = btnMH.ForeColor = btnDM.ForeColor = btnKM.ForeColor = btnNCC.ForeColor = btnNhap.ForeColor = btnXuat.ForeColor = Color.FromArgb(236, 239, 241);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 39, 43);
                btnTT.FlatAppearance.MouseOverBackColor = btnMH.FlatAppearance.MouseOverBackColor = btnDM.FlatAppearance.MouseOverBackColor = btnKM.FlatAppearance.MouseOverBackColor = btnNCC.FlatAppearance.MouseOverBackColor = btnNhap.FlatAppearance.MouseOverBackColor = btnXuat.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 39, 43);
            }
        }
        #endregion
    }
}
