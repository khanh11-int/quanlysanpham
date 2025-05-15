using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quanlysanpham
{
    class Taikhoan
    {
        private string tentaikhoan;

        public string Tentaikhoan
        {
            get => tentaikhoan;
            set => tentaikhoan = value;
        }
        private string matkhau;
        public string Matkhau
        {
            get => matkhau;
            set => matkhau = value;
        }
        public Taikhoan(string tentaikhoan, string matkhau)
        {
            this.tentaikhoan = tentaikhoan;
            this.matkhau = matkhau;
        }
    }
}
