using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysanpham
{
    class Danhsachtaikhoan
    {
        private static Danhsachtaikhoan instance;
        public static Danhsachtaikhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new Danhsachtaikhoan();
                return instance;
            }
            set => instance = value;
        }

        List<Taikhoan> listTaikhoan;

        public List<Taikhoan> ListTaikhoan
        {
            get => listTaikhoan;
            set => listTaikhoan = value;
        }

        Danhsachtaikhoan()
        {
            listTaikhoan = new List<Taikhoan>();
            listTaikhoan.Add(new Taikhoan("nguyenkhanh", "123"));
        }
    }
}
