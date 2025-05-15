using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlysanpham
{
    public partial class Fromdangnhap: Form
    {
        public Fromdangnhap()
        {
            InitializeComponent();
        }

        List<Taikhoan> listTaikhoan = Danhsachtaikhoan.Instance.ListTaikhoan;

        //ủy thác đăng xuất
        private void F_Dangxuat(object sender, EventArgs e)
        {
            (sender as Formchuongtrinh).Isthoat = false;
            (sender as Formchuongtrinh).Close();
            this.Show();
        }
        //kiểm tra đăng nhập
        bool Kiemtradangnhap(string tentaikhoan, string matkhau)
        {
            for (int i = 0; i < listTaikhoan.Count; i++)
            {
                if (tentaikhoan == listTaikhoan[i].Tentaikhoan && matkhau == listTaikhoan[i].Matkhau)
                    return true;
            }
            return false;
        }
        //chuyển hướng đến trang chương trình
        private void tbnDangnhap_Click(object sender, EventArgs e)
        {
            if (Kiemtradangnhap(txtTaikhoan.Text, txtMatkhau.Text))
            {
                Formchuongtrinh f = new Formchuongtrinh();
                f.Show();
                this.Hide();
                f.Dangxuat += F_Dangxuat;
                txtTaikhoan.Clear();
                txtMatkhau.Clear();
            }
            else
            {
                MessageBox.Show("sai tên tài khoản hoặc mật khẩu!!", "Lỗi");
                txtTaikhoan.Clear();
                txtMatkhau.Clear();
                txtTaikhoan.Focus();
            }
        }

        private void tbnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Fromdangnhap_Load(object sender, EventArgs e)
        {

        }
    }
}
