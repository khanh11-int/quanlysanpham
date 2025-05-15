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
using System.Windows.Forms.DataVisualization.Charting;


namespace quanlysanpham
{
    public partial class Formthongke : Form
    {
        bool Isthoat = true;
        public Formthongke()
        {
            InitializeComponent();
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
        //chuyển hướng đến trang chương trình
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            Isthoat = false;
            this.Hide(); // hoặc this.Close(); 

            if (this.Owner != null)
            {
                this.Owner.Show(); // Hiện lại form chương trình
            }
        }

        private void Formthongke_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Isthoat)
                Application.Exit();
        }
        //hiển thị trang thống kê
        private void Formthongke_Load(object sender, EventArgs e)
        {
            LoadChart();
        }
        private void LoadChart()
        {
            //clear biểu đồ cũ
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Titles.Clear();
            //chọn bảng màu sáng cho biểu đồ
            chart1.Palette = ChartColorPalette.Bright;

            //tạo biểu đồ mói cho chart1
            ChartArea area = new ChartArea();
            chart1.ChartAreas.Add(area);


            //tạo series mới với kiểu cột
            Series series = new Series("Số lượng sản phẩm");
            series.ChartType = SeriesChartType.Column;
            chart1.Series.Add(series);
            //tạo tiêu đè mới
            chart1.Titles.Add("Thống kê số lượng theo loại sản phẩm");

            // kết nối và lấy đữ liệu từ CSDL
            using (SqlConnection conn = new SqlConnection("Data Source=KHANHNGUYEN;Initial Catalog=quanly;User ID=sa;Password=123;Encrypt=False"))
            {
                conn.Open();
                string sql = "SELECT TenLoai, SUM(SoLuong) AS TongSoLuong FROM SanPham INNER JOIN PhanLoai ON SanPham.ID = PhanLoai.ID GROUP BY TenLoai";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                //vẽ biểu đồ 
                string[] colors = { "Red", "Green", "Blue", "Orange", "Purple", "Cyan", "Magenta", "Brown" };
                int i = 0;

                //di chuyển con trỏ đén từng bản ghi r kiểm tra xem có bản ghi nào để đọc không
                //nếu có =>true chạy while ,nếu k =>false ngừng while
                while (reader.Read())
                {
                    string tenLoai = reader["TenLoai"].ToString();// Lấy tên loại
                    int soLuong = Convert.ToInt32(reader["TongSoLuong"]);// Lấy số lượng


                    //tạo cột
                    DataPoint point = new DataPoint();
                    point.AxisLabel = tenLoai;//nhãn trục x
                    point.YValues = new double[] { soLuong };//giá trị trục y

                    // Gán màu khác nhau cho từng cột
                    point.Color = Color.FromName(colors[i % colors.Length]);
                    series.Points.Add(point);
                    i++;
                }
            }

        }

        private void Formthongke_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Isthoat)
            {
                if (MessageBox.Show("Bạn có muốn thoát chương trình", "Cảnh báo", MessageBoxButtons.YesNo) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
