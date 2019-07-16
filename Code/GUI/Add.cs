using BLL;
using DTO;
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
    public partial class Add : Form
    {
        Function Fn;
        int idNV;
        int id;
        public Add(Function Fn, int idNV)
        {
            InitializeComponent();
            this.Fn = Fn;
            this.idNV = idNV;
            this.btnDongMH.Click += btnAdd_OK_Click;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        void Dong(object sender, EventArgs e)
        {
            Close();
        }
        private void Add_Load(object sender, EventArgs e)
        {
            StartPosition = FormStartPosition.CenterScreen;
            btnAdd_OK.Click += Them_Click;
            btnAddDM.Click += Them_Click;
            btnAddKM.Click += Them_Click;
            btnAddNCC.Click += Them_Click;
            btnAddN.Click += Them_Click;
            btnAddNV.Click += Them_Click;
            btnAddX.Click += Them_Click;

            btnDongDM.Click += Dong;
            btnDongKM.Click += Dong;
            btnDongNCC.Click += Dong;
            btnDongNV.Click += Dong;
            btnDongX.Click += Dong;
            btnDongN.Click += Dong;
            btnDongMH.Click += Dong;

            tcAdd.TabPages.Clear();
            // Mặt hàng
            if (Fn == Function.MAT_HANG)
            {
                tcAdd.TabPages.Add(tabMH);
                DanhMucBLL dmb = new DanhMucBLL();
                cboDM.DataSource = dmb.getList();
                cboDM.DisplayMember = "name";
                cboDM.ValueMember = "id";
                Width = 502;
                Height = 480;
            }
            // Danh mục
            else if (Fn == Function.DANH_MUC)
            {
                tcAdd.TabPages.Add(tabDM);
                Width = 390;
                Height = 438;
            }
            //Khuyến mãi
            else if (Fn == Function.KHUYEN_MAI)
            {
                tcAdd.TabPages.Add(tabKM);
                rdpKM.Checked = true;
                Width = 585;
                Height = 503;
            }
            // Nhà cung cấp
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                tcAdd.TabPages.Add(tabNCC);
                rdpKM.Checked = true;
                Width = 563;
                Height = 497;
            }
            // Nhập hàng
            else if (Fn == Function.NHAP)
            {
                tcAdd.TabPages.Add(tabNhap);
                DanhMucBLL dbll = new DanhMucBLL();
                cboDMN.DataSource = dbll.getList();
                cboDMN.DisplayMember = "name";
                cboDMN.ValueMember = "id";

                NhaCungCapBLL nbll = new NhaCungCapBLL();
                cboNCCN.DataSource = nbll.getList();
                cboNCCN.DisplayMember = "name";
                cboNCCN.ValueMember = "id";

                MatHangBLL mbll = new MatHangBLL();
                if (cboDMN.SelectedValue != null)
                {
                    lisMHN.DataSource = mbll.getListByIdDM(int.Parse(cboDMN.SelectedValue.ToString()));
                    lisMHN.DisplayMember = "name";
                    lisMHN.ValueMember = "id";
                }

                //lvMHN.Columns.Add("id", 50);
                lvMHN.Columns.Add("idMH", 50);
                lvMHN.Columns.Add("idNCC", 50);
                lvMHN.Columns.Add("idNV", 50);
                lvMHN.Columns.Add("Soluong", 50);
                lvMHN.Columns.Add("Thanhtien", 50);

                Width = 928;
                Height = 614;
            }
            // Xuất hàng
            else if (Fn == Function.XUAT)
            {
                tcAdd.TabPages.Add(tabXuat);

                DanhMucBLL dbll = new DanhMucBLL();
                cboDMX.DataSource = dbll.getList();
                cboDMX.DisplayMember = "name";
                cboDMX.ValueMember = "id";

                MatHangBLL mbll = new MatHangBLL();
                if (cboDMN.SelectedValue != null)
                {
                    lisMHX.DataSource = mbll.getListByIdDM(int.Parse(cboDMN.SelectedValue.ToString()));
                    lisMHX.DisplayMember = "name";
                    lisMHX.ValueMember = "id";
                }

                //lvMHX.Columns.Add("id", 50);
                lvMHX.Columns.Add("idMH", 50);
                lvMHX.Columns.Add("idNV", 50);
                lvMHX.Columns.Add("Số lượng", 50);
                lvMHX.Columns.Add("Thành tiền", 50);

                Width = 928;
                Height = 614;
            }
            // Nhân viên
            else if (Fn == Function.NHAN_VIEN)
            {
                tcAdd.TabPages.Add(tabNV);
                rdNamNV.Checked = true;
                Width = 698;
                Height = 486;
            }


            StartPosition = FormStartPosition.CenterScreen;
        }

        void loadReport(int report)
        {
            if (report == 1)
            {
                SqlConnection conn = new SqlConnection
             ("Server=DESKTOP-454D525\\DUONG;Database=CHTapHoa;User Id=sa;pwd=25251325");
                string query = string.Format("SELECT MH.name as TenMH,NCC.name as TenNCC,nv.name as TenNV,nh.soluong,NH.thanhtien FROM dbo.NhapHang NH INNER JOIN dbo.NhanVien NV ON(NH.idNV = NV.id)INNER JOIN dbo.MatHang MH ON(NH.idMH = MH.id)INNER JOIN dbo.NhaCungCap NCC ON(NH.idNCC = NCC.id)WHERE NH.id >= {0}", id);
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
            else if (report == 2)
            {
                SqlConnection conn = new SqlConnection
             ("Server=DESKTOP-454D525\\DUONG;Database=CHTapHoa;User Id=sa;pwd=25251325");
                string query = string.Format("SELECT MH.name as MatHang, NV.name as NhanVien , XH.soluong, XH.thanhtien FROM dbo.XuatHang XH INNER JOIN dbo.MatHang MH ON(XH.idMH = MH.id) INNER JOIN dbo.NhanVien NV ON(XH.idNV = NV.id) WHERE XH.id >= {0}", id);
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "DataTable1");
                this.reportViewer2.LocalReport.ReportEmbeddedResource = "GUI.ReportHDB.rdlc";
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];

                this.reportViewer2.LocalReport.DataSources.Add(rds);
                this.reportViewer2.RefreshReport();
            }

        }
        private void cboDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboDM.SelectedValue.ToString());
        }

        void Them_Click(object sender, EventArgs e)
        {
            // Mặt hàng
            if (Fn == Function.MAT_HANG)
            {
                MatHang mh = new MatHang();
                if (cboDM.SelectedValue == null)
                {
                    MessageBox.Show("Danh mục trống.");
                    return;
                }
                else
                    mh.idDM = int.Parse(cboDM.SelectedValue.ToString());

                mh.name = txtName.Text;
                mh.soluong = 0;

                if (mh.name == "")
                {
                    MessageBox.Show("Tên mặt hàng không được bỏ trống.");
                    txtName.Focus();
                    return;
                }

                float i;
                bool isNum = float.TryParse(txtGiaNhap.Text, out i);

                if (isNum)
                {
                    mh.gianhap = i;
                }
                else
                {
                    MessageBox.Show("Nhập sai giá nhập!");
                    txtGiaNhap.Focus();
                    return;
                }

                isNum = float.TryParse(txtGiaBan.Text, out i);

                if (isNum)
                {
                    mh.giaban = i;
                }
                else
                {
                    MessageBox.Show("Nhập sai giá bán!");
                    txtGiaBan.Focus();
                    return;
                }

                if (mh.giaban < mh.gianhap)
                {
                    MessageBox.Show("Giá bán không được nhỏ hơn giá nhập!");
                    txtGiaBan.Focus();
                    return;
                }


                MatHangBLL bll = new MatHangBLL();

                try
                {
                    if (bll.add(mh))
                    {
                        MessageBox.Show("Thêm thành công.");
                        //load lại datagridview
                        this.Close();
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
                DanhMuc dm = new DanhMuc();
                dm.name = txtNameDM.Text;
                dm.content = txtContentDM.Text;

                if (dm.name == "")
                {
                    MessageBox.Show("Tên danh mục không được để trống.");
                    txtNameDM.Focus();
                    return;
                }

                if (dm.content == "")
                {
                    MessageBox.Show("Mô tả không được để trống");
                    txtContentDM.Focus();
                    return;
                }
                try
                {
                    if (bll.add(dm))
                    {
                        MessageBox.Show("Thêm danh mục thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Khuyến mãi
            else if (Fn == Function.KHUYEN_MAI)
            {
                KhuyenMai km = new KhuyenMai();

                // Kiểm tra mô tả
                km.content = txtContentKM.Text;
                if (km.content == "")
                {
                    MessageBox.Show("Mô tả không được bỏ trống");
                    txtContentKM.Focus();
                    return;
                }

                // Kiểm tra giá
                float i;
                bool isNum = float.TryParse(txtGiaKM.Text, out i);
                if (isNum)
                {
                    km.gia = i;
                    if (km.gia < 0)
                    {
                        MessageBox.Show(" Giá không được nhỏ hơn 0");
                        txtGiaKM.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Nhập giá không đúng");
                    txtGiaKM.Focus();
                    return;
                }

                // Thiết lập loại giá
                if (rdpKM.Checked == true)
                    km.typegia = 0;
                else
                    km.typegia = 1;

                if (km.typegia == 0)
                {
                    if (100 < km.gia)
                    {
                        MessageBox.Show("Giá không được lớn hơn 100%");
                    }
                }




                //if (DateTime.Now > dtpStartKM.Value)
                //{
                //    MessageBox.Show("Thời gian bắt đầu nhỏ hơn hiện tại");
                //    return;
                //}

                if (DateTime.Now > dtpEndKM.Value)
                {
                    MessageBox.Show("Thời gian kết thúc nhỏ hơn hiện tại");
                    return;
                }

                if (dtpStartKM.Value > dtpEndKM.Value)
                {
                    MessageBox.Show("Thời gian bắt đầu lớn hơn thời gian kết thúc");
                    return;
                }

                km.starttime = dtpStartKM.Value.ToString("MM/dd/yyyy");
                km.endtime = dtpEndKM.Value.ToString("MM/dd/yyyy");


                KhuyenMaiBLL bll = new KhuyenMaiBLL();
                try
                {
                    if (bll.add(km))
                    {
                        MessageBox.Show("Thêm Khuyến Mại thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


                // Tạo liên kết


            }
            // Nhà cung cấp
            else if (Fn == Function.NHA_CUNG_CAP)
            {
                NhaCungCap ncc = new NhaCungCap();

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

                float i;
                bool isNum = float.TryParse(txtSdtNCC.Text, out i);
                if (isNum)
                    ncc.sdt = txtSdtNCC.Text;
                else
                {
                    MessageBox.Show("Không nhập đúng số điện thoại!");
                    txtSdtNCC.Focus();
                    return;
                }

                ncc.diachi = txtDiaChiNCC.Text;
                if (ncc.diachi == "")
                {
                    MessageBox.Show("Địa chỉ không được bỏ trống");
                    txtDiaChiNCC.Focus();
                    return;
                }


                NhaCungCapBLL bll = new NhaCungCapBLL();

                try
                {
                    if (bll.add(ncc))
                    {
                        MessageBox.Show("Thêm nhà cung cấp thành công.");
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
                int i = 0;
                NhapHang nh = new NhapHang();
                bool isNum = false;

                if (lisMHN.SelectedValue != null)
                    isNum = int.TryParse(lisMHN.SelectedValue.ToString(), out i);
                else
                {
                    MessageBox.Show("Mặt hàng không tồn tại");
                    return;
                }

                if (isNum)
                    nh.idMH = i;

                if (cboNCCN.SelectedValue != null)
                    isNum = int.TryParse(cboNCCN.SelectedValue.ToString(), out i);
                else
                {
                    MessageBox.Show("Nhà cung cấp không tồn tại");
                    return;
                }
                if (isNum)
                    nh.idNCC = i;

                isNum = int.TryParse(txtSoLuongN.Text, out i);
                if (isNum)
                {
                    nh.soluong = i;
                    if (nh.soluong <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0");
                        txtSoLuongN.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai định dạng số lượng");
                    txtSoLuongN.Focus();
                    return;
                }

                if (txtThanhTienN.Text != "")
                    nh.thanhtien = float.Parse(txtThanhTienN.Text);
                nh.idNV = idNV;



                string[] arr = new string[5];
                //arr[0] = nh.id.ToString();
                arr[0] = nh.idMH.ToString();
                arr[1] = nh.idNCC.ToString();
                arr[2] = nh.idNV.ToString();
                arr[3] = nh.soluong.ToString();
                arr[4] = nh.thanhtien.ToString();

                ListViewItem item = new ListViewItem(arr);
                lvMHN.Items.Add(item);
                //try
                //{
                //    if (bll1.add(nh))
                //    {
                //        bll.update(mh);
                //        MessageBox.Show("Thêm mặt hàng thành công.");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            // Xuất hàng
            else if (Fn == Function.XUAT)
            {
                XuatHang xh = new XuatHang();
                int i = 0;
                bool isNum = false;
                if (lisMHX.SelectedValue != null)
                    isNum = int.TryParse(lisMHX.SelectedValue.ToString(), out i);
                else
                {
                    MessageBox.Show("Mặt hàng không tồn tại");
                    return;
                }
                if (isNum)
                    xh.idMH = i;

                xh.idNV = idNV;

                isNum = int.TryParse(txtSoLuongX.Text, out i);

                if (isNum)
                {
                    xh.soluong = i;
                    if (xh.soluong <= 0)
                    {
                        MessageBox.Show("Số lượng phải lớn hơn 0");
                        txtSoLuongX.Focus();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nhập sai định dạng số");
                    txtSoLuongX.Focus();
                    return;
                }
                MatHangBLL mhb = new MatHangBLL();
                KhuyenMaiBLL kmb = new KhuyenMaiBLL();

                MatHang mh = mhb.getDetailsById(xh.idMH);

                if (xh.soluong > mh.soluong)
                {
                    MessageBox.Show("Số lượng xuất lớn hơn tồn kho");
                    txtSoLuongX.Focus();
                    return;
                }

                xh.thanhtien = float.Parse(txtThanhTienX.Text);


                KhuyenMai km = kmb.getDetailsByIdMH(xh.idMH);
                float gia;
                if (km != null)
                {
                    if (km.typegia == 0)
                    {
                        gia = mh.giaban - mh.giaban / 100 * km.gia;
                    }

                    else
                    {
                        gia = mh.giaban - km.gia;
                    }

                }
                else
                {
                    gia = mh.giaban;
                }


                mh.soluong -= xh.soluong;

                xh.thanhtien = xh.soluong * gia;


                XuatHangBLL bll = new XuatHangBLL();

                string[] arr = new string[4];
                //arr[0] = nh.id.ToString();
                arr[0] = xh.idMH.ToString();
                arr[1] = xh.idNV.ToString();
                arr[2] = xh.soluong.ToString();
                arr[3] = xh.thanhtien.ToString();

                ListViewItem item = new ListViewItem(arr);
                lvMHX.Items.Add(item);

                //try
                //{
                //    if (bll.add(xh))
                //    {
                //        mhl.update(mh);
                //        MessageBox.Show("Xuất Mặt Hàng thành công.");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }
            // Nhân viên
            else if (Fn == Function.NHAN_VIEN)
            {
                NhanVien nv = new NhanVien();

                nv.username = txtUsernameNV.Text;
                if (nv.username == "")
                {
                    MessageBox.Show("Tài khoản không được bỏ trống");
                    txtUsernameNV.Focus();
                    return;
                }

                nv.password = txtPasswordNV.Text;
                nv.password = MD5.md5(nv.password);
                if (nv.password == "")
                {
                    MessageBox.Show("Mật khẩu không được bỏ trống");
                    txtPasswordNV.Focus();
                    return;
                }

                nv.name = txtNameNV.Text;
                if (nv.name == "")
                {
                    MessageBox.Show("Tên nhân viên không được bỏ trống");
                    txtNameNV.Focus();
                    return;
                }

                if (rdNamNV.Checked == true)
                    nv.gioitinh = 1;
                else
                    nv.gioitinh = 0;

                nv.diachi = txtDiaChiNV.Text;
                if (nv.diachi == "")
                {
                    MessageBox.Show("Địa chỉ không được bỏ trống");
                    txtDiaChiNV.Focus();
                    return;
                }
                float i;
                bool isNum = float.TryParse(txtSdtNV.Text, out i);
                if (!isNum)
                {
                    MessageBox.Show("Nhập sai định dạng số điện thoại");
                    txtSdtNV.Focus();
                    return;
                }
                nv.sdt = txtSdtNV.Text;

                nv.chucvu = txtChucVuNV.Text;
                if (nv.chucvu == "")
                {
                    MessageBox.Show("Chức vụ không được để trống");
                    txtChucVuNV.Focus();
                    return;
                }

                NhanVienBLL bll = new NhanVienBLL();

                try
                {
                    if (bll.add(nv))
                    {
                        MessageBox.Show("Thêm nhân viên thành công.");
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void cboDMN_SelectedValueChanged(object sender, EventArgs e)
        {
            MatHangBLL mbll = new MatHangBLL();
            int i = 0;
            bool isNum = false;
            if (cboDMN.SelectedValue != null)
                isNum = int.TryParse(cboDMN.SelectedValue.ToString(), out i);
            else
            {
                MessageBox.Show("Danh mục không tồn tại");
                return;
            }
            //int i = (int)cboDMN.SelectedValue;
            if (isNum)
            {
                lisMHN.DataSource = mbll.getListByIdDM(i);
                lisMHN.DisplayMember = "name";
                lisMHN.ValueMember = "id";
            }

        }

        private void cboDMX_SelectedValueChanged(object sender, EventArgs e)
        {
            MatHangBLL mbll = new MatHangBLL();
            int i = 0;
            bool isNum = false;
            if (cboDMX.SelectedValue != null)
                isNum = int.TryParse(cboDMX.SelectedValue.ToString(), out i);
            else
            {
                MessageBox.Show("Danh mục không tồn tại");
                return;
            }
            if (isNum)
            {
                lisMHX.DataSource = mbll.getListByIdDM(i);
                lisMHX.DisplayMember = "name";
                lisMHX.ValueMember = "id";
            }
        }

        private void txtSoLuongN_TextChanged(object sender, EventArgs e)
        {
            int test;
            bool isNum = int.TryParse(txtSoLuongN.Text, out test);
            if (isNum)
            {
                MatHangBLL bll = new MatHangBLL();
                txtThanhTienN.Text = (test * bll.getGiaNhapById(int.Parse(lisMHN.SelectedValue.ToString()))).ToString();
            }
        }

        private void txtSoLuongX_TextChanged(object sender, EventArgs e)
        {
            int test;
            bool isNum = int.TryParse(txtSoLuongX.Text, out test);
            if (isNum)
            {
                MatHangBLL bll = new MatHangBLL();
                if (lisMHX.SelectedValue != null)
                    txtThanhTienX.Text = (test * bll.getGiaBanById(int.Parse(lisMHX.SelectedValue.ToString()))).ToString();
                else
                {
                    MessageBox.Show("Mặt hàng không tồn tại");
                    return;
                }
            }
        }

        private void btnLK_Click(object sender, EventArgs e)
        {
            tcAdd.TabPages.Clear();
            tcAdd.TabPages.Add(tabLK);
            // Tạo liên kết
            DanhMucBLL dmb = new DanhMucBLL();
            cboDanhMucLK.DataSource = dmb.getList();
            cboDanhMucLK.DisplayMember = "name";
            cboDanhMucLK.ValueMember = "id";

            KhuyenMaiBLL kmb = new KhuyenMaiBLL();
            cboKhuyenMaiLK.DataSource = kmb.getList();
            cboKhuyenMaiLK.DisplayMember = "content";
            cboKhuyenMaiLK.ValueMember = "id";

            MatHangBLL mhb = new MatHangBLL();
            if (cboDanhMucLK.SelectedValue != null)
            {
                lisMHLK.DataSource = mhb.getListByIdDM(int.Parse(cboDanhMucLK.SelectedValue.ToString()));
                lisMHLK.DisplayMember = "name";
                lisMHLK.ValueMember = "id";
            }
        }

        private void btnBackLK_Click(object sender, EventArgs e)
        {
            tcAdd.TabPages.Clear();
            tcAdd.TabPages.Add(tabKM);
        }

        private void cboDanhMucLK_SelectedValueChanged(object sender, EventArgs e)
        {
            MatHangBLL mhb = new MatHangBLL();
            int i;
            bool isNum = int.TryParse(cboDanhMucLK.SelectedValue.ToString(), out i);
            if (i > 0)
            {

                lisMHLK.DataSource = mhb.getListByIdDM(int.Parse(cboDanhMucLK.SelectedValue.ToString()));
                lisMHLK.DisplayMember = "name";
                lisMHLK.ValueMember = "id";
            }
        }

        private void btnTaoLK_Click(object sender, EventArgs e)
        {
            KhuyenMaiBLL bll = new KhuyenMaiBLL();
            MatHangBLL mhb = new MatHangBLL();

            String str;
            foreach (var item in lisMHLK.SelectedItems)
            {
                str = lisMHLK.GetItemText(item);
                KMInfo kmi = new KMInfo();
                kmi.idKM = int.Parse(cboKhuyenMaiLK.SelectedValue.ToString());
                kmi.idMH = mhb.getIdByName(str);

                try
                {
                    bll.addKM(kmi);
                    MessageBox.Show(kmi.idKM + "-" + kmi.idMH.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            MessageBox.Show("Tạo liên kết thành công");
        }

        private void btnLuuN_Click(object sender, EventArgs e)
        {
            id = 0; int dem = -1;

            NhapHangBLL bll = new NhapHangBLL();
            MatHangBLL mhb = new MatHangBLL();

            for (int i = 0; i < lvMHN.Items.Count; i++)
            {
                NhapHang nh = new NhapHang();
                // nh.id = int.Parse(lvMHN.Items[i].SubItems[0].Text);
                nh.idMH = int.Parse(lvMHN.Items[i].SubItems[0].Text);
                nh.idNCC = int.Parse(lvMHN.Items[i].SubItems[1].Text);
                nh.idNV = int.Parse(lvMHN.Items[i].SubItems[2].Text);
                nh.soluong = int.Parse(lvMHN.Items[i].SubItems[3].Text);
                nh.thanhtien = float.Parse(lvMHN.Items[i].SubItems[4].Text);

                MatHang mh = mhb.getDetailsById(nh.idMH);
                mh.soluong += nh.soluong;
                nh.thanhtien = nh.soluong * mhb.getGiaNhapById(nh.idMH);



                try
                {

                    if ((id = bll.getIdAndInsert(nh)) != 0)
                    {
                        dem++;
                        mhb.update(mh);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (ckReportN.Checked == true)
            {
                id = id - dem;
                tcAdd.Controls.Clear();
                tcAdd.Controls.Add(HoaDonNhap);
                loadReport(1);
            }
            else
            {
                if (lvMHN.Items.Count != 0)
                {
                    MessageBox.Show("Lưu thành công");
                    Close();
                }
                    
                else
                    MessageBox.Show("Chưa có dữ liệu");
            }

            
        }

        private void btnLuuX_Click(object sender, EventArgs e)
        {
            id = 0; int dem = -1;
            XuatHangBLL bll = new XuatHangBLL();
            MatHangBLL mhb = new MatHangBLL();
            KhuyenMaiBLL kmb = new KhuyenMaiBLL();

            for (int i = 0; i < lvMHX.Items.Count; i++)
            {
                XuatHang xh = new XuatHang();
                xh.idMH = int.Parse(lvMHX.Items[i].SubItems[0].Text);
                xh.idNV = int.Parse(lvMHX.Items[i].SubItems[1].Text);
                xh.soluong = int.Parse(lvMHX.Items[i].SubItems[2].Text);
                xh.thanhtien = float.Parse(lvMHX.Items[i].SubItems[3].Text);

                MatHang mh = mhb.getDetailsById(xh.idMH);

                KhuyenMai km = kmb.getDetailsByIdMH(xh.idMH);
                float gia;
                if (km != null)
                {
                    if (km.typegia == 0)
                    {
                        gia = mh.giaban - mh.giaban / 100 * km.gia;
                    }

                    else
                    {
                        gia = mh.giaban - km.gia;
                    }

                }
                else
                {
                    gia = mh.giaban;
                }

                mh.soluong -= xh.soluong;

                xh.thanhtien = xh.soluong * gia;
                try
                {
                    if ((id = bll.getIdAndInsert(xh)) != 0)
                    {
                        mhb.update(mh);
                        dem++;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (ckReportX.Checked == true)
            {
                id = id - dem;
                tcAdd.Controls.Clear();
                tcAdd.Controls.Add(HoaDonBan);
                loadReport(2);
            }
            else
            {
                if (lvMHX.Items.Count != 0)
                {
                    MessageBox.Show("Xuất Mặt Hàng thành công.");
                    Close();
                }
                    
                else
                {
                    MessageBox.Show("Chưa có dữ liệu");
                }
            }

        }

        private void btnAdd_OK_Click(object sender, EventArgs e)
        {

        }

        private void txtSoLuongN_TextChanged_1(object sender, EventArgs e)
        {
            txtSoLuongN_TextChanged(sender, e);
        }

        private void txtSoLuongX_TextChanged_1(object sender, EventArgs e)
        {
            txtSoLuongX_TextChanged(sender, e);
        }

        private void cboDMX_SelectedValueChanged_1(object sender, EventArgs e)
        {
            cboDMX_SelectedValueChanged(sender, e);
        }

        private void btnLuuX_Click_1(object sender, EventArgs e)
        {
            btnLuuX_Click(sender, e);
        }

        private void btnLuuN_Click_1(object sender, EventArgs e)
        {
            btnLuuN_Click(sender, e);
        }

        private void btnLK_Click_1(object sender, EventArgs e)
        {
            btnLK_Click(sender, e);
        }
    }
}
