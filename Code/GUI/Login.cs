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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnDN_Click(object sender, EventArgs e)
        {
            NhanVienBLL bll = new NhanVienBLL();

            string mk = MD5.md5(txtPassword.Text);
            NhanVien nv = bll.getAccountbyUsername(txtUsername.Text,mk);

            if(nv != null)
            {
                this.ShowInTaskbar = false;
                this.Visible = false;

                MainForm main = new MainForm(nv.id);
                main.Activate();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nhập sai tài khoản hoặc mật khẩu.");
            }


        }
    }
}
