using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace quanlysanpham
{
    public partial class Formchuongtrinh: Form
    {

        public bool Isthoat = true;
        public Formchuongtrinh()
        {
            InitializeComponent();
        }
        //Kết nối sql
        SqlConnection conn = new SqlConnection("Data Source=KHANHNGUYEN;Initial Catalog=quanly;User ID=sa;Password=123;Encrypt=False");

        public event EventHandler Dangxuat;

        private void Formchuongtrinh_Load(object sender, EventArgs e)
        {
            var dap = new SqlDataAdapter("SELECT * FROM PhanLoai", conn);
            var table = new DataTable();
            dap.Fill(table);
            cbPhanLoai.DisplayMember = "TenLoai";
            cbPhanLoai.ValueMember = "ID";
            cbPhanLoai.DataSource = table;
            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("Text",cbPhanLoai.DataSource,"ID");
            txtTenLoai.DataBindings.Clear();
            txtTenLoai.DataBindings.Add("Text", cbPhanLoai.DataSource, "TenLoai");
            btnTim.Click += btnTim_Click;
        }
        //sự kiện đăng xuất
        private void tbnDangxuat_Click(object sender, EventArgs e)
        {
            Dangxuat(this, new EventArgs());
        }

        private void Formchuongtrinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Isthoat)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void tbnThoat_Click(object sender, EventArgs e)
        {
            if (Isthoat)
                Application.Exit();
        }

        private void Formchuongtrinh_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Isthoat)
                Application.Exit();
        }
        //các hiển thị trong datagridview
        private void cbPhanLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbPhanLoai.SelectedValue);
            var dap = new SqlDataAdapter("SELECT SanPham.MaSP, SanPham.TenSP, SanPham.SoLuong, SanPham.Gia, PhanLoai.TenLoai, SanPham.ID " +
    "FROM SanPham INNER JOIN PhanLoai ON SanPham.ID = PhanLoai.ID " +
    "WHERE SanPham.ID = " + id+"", conn);
            var table = new DataTable();
            dap.Fill(table);
            dgvSanPham.DataSource = table;
            txtMaSP.DataBindings.Clear();
            txtMaSP.DataBindings.Add("Text", dgvSanPham.DataSource, "MaSP");
            txtTenSP.DataBindings.Clear();
            txtTenSP.DataBindings.Add("Text", dgvSanPham.DataSource, "TenSP");
            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("Text", dgvSanPham.DataSource, "SoLuong");
            txtGia.DataBindings.Clear();
            txtGia.DataBindings.Add("Text", dgvSanPham.DataSource, "Gia");
        }

        Boolean addLoai = false;
        //khi ấn nút thêm loại sản phẩm xóa các ô text để thêm loại sản phẩm
        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtTenLoai.Text = "";
            txtTenLoai.Focus();
            addLoai = true;
        }
        //khi ấn nút thêm thì sẽ thêm còn k ấn nút thêm thì sẽ sửa
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(addLoai==true)
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("INSERT INTO PhanLoai(TenLoai) VALUES(N'" + txtTenLoai.Text + "')", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Formchuongtrinh_Load(sender, e);
                    MessageBox.Show("Thêm loại sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Thêm loại sản phẩm thất bại!!", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                addLoai = false;
            }
            else
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("UPDATE PhanLoai SET TenLoai = N'" + txtTenLoai.Text + "'WHERE ID =" + Convert.ToInt32(cbPhanLoai.SelectedValue) + "", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Formchuongtrinh_Load(sender, e);
                    MessageBox.Show("Sửa loại sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Sửa loại sản phẩm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Xóa loại sản phẩm
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn muốn xóa loại "+cbPhanLoai.Text+"?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if(lenh==DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM PhanLoai WHERE ID =" + Convert.ToInt32(cbPhanLoai.SelectedValue) + "", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Formchuongtrinh_Load(sender, e);
                    MessageBox.Show("Xóa loại sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa loại sản phẩm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        Boolean addSP = false;
        //khi ấn nút thêm sản phẩm xóa các ô text để thêm sản phẩm
        private void btnAddSP_Click(object sender, EventArgs e)
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtSoLuong.Text = "";
            txtGia.Text = "";
            txtTenSP.Focus();
            addSP = true;
        }
        //khi ấn nút thêm thì sẽ thêm còn k ấn nút thêm thì sẽ sửa
        private void btnUpdateSP_Click(object sender, EventArgs e)
        {
            if (addSP == true)
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("INSERT INTO SanPham(TenSP,SoLuong,Gia,ID) VALUES(N'" + txtTenSP.Text + "',N'" + txtSoLuong.Text + "',N'" + txtGia.Text + "', " + Convert.ToInt32(cbPhanLoai.SelectedValue) + ")", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cbPhanLoai_SelectedIndexChanged(sender, e);
                    MessageBox.Show("Thêm sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                addSP = false;
            }
            else
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("UPDATE SanPham SET TenSP = N'" + txtTenSP.Text + "', SoLuong = N'" + txtSoLuong.Text + "', Gia = N'" + txtGia.Text + "' WHERE MaSP =" + Convert.ToInt32(txtMaSP.Text) + "", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cbPhanLoai_SelectedIndexChanged(sender, e);
                    MessageBox.Show("Sửa sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Sửa sản phẩm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Xóa sản phẩm
        private void btnDeleteSP_Click(object sender, EventArgs e)
        {
            DialogResult lenh = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm " + txtTenSP.Text + "?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (lenh == DialogResult.Yes)
            {
                try
                {
                    conn.Open();
                    var cmd = new SqlCommand("DELETE FROM SanPham WHERE MaSP =" + Convert.ToInt32(txtMaSP.Text) + "", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    cbPhanLoai_SelectedIndexChanged(sender, e);
                    MessageBox.Show("Xóa loại sản phẩm thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa loại sản phẩm thất bại!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Tìm sản phẩm
        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();

            string sql = "SELECT SanPham.MaSP, SanPham.TenSP, SanPham.SoLuong, SanPham.Gia, PhanLoai.TenLoai, SanPham.ID " +
                         "FROM SanPham INNER JOIN PhanLoai ON SanPham.ID = PhanLoai.ID " +
                         "WHERE SanPham.TenSP LIKE @Keyword";

            var dap = new SqlDataAdapter(sql, conn);
            dap.SelectCommand.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");

            var table = new DataTable();
            dap.Fill(table);
            dgvSanPham.DataSource = table;


            // Cập nhật lại các bindings
            if (table.Rows.Count > 0)
            {
                txtMaSP.DataBindings.Clear();
                txtMaSP.DataBindings.Add("Text", dgvSanPham.DataSource, "MaSP");
                txtTenSP.DataBindings.Clear();
                txtTenSP.DataBindings.Add("Text", dgvSanPham.DataSource, "TenSP");
                txtSoLuong.DataBindings.Clear();
                txtSoLuong.DataBindings.Add("Text", dgvSanPham.DataSource, "SoLuong");
                txtGia.DataBindings.Clear();
                txtGia.DataBindings.Add("Text", dgvSanPham.DataSource, "Gia");
            }
        }
        //Chuyển hướng đến trang thống kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            Formthongke frmThongKe = new Formthongke();
            frmThongKe.Owner = this;     // Thiết lập chủ sở hữu
            this.Hide();                 // Ẩn form hiện tại
            frmThongKe.Show();          // Hiển thị form thống kê
        }
    }
}
