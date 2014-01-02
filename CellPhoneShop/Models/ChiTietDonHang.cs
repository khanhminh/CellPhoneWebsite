using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class ChiTietDonHang
    {
        public int MaCTDH { get; set; }
        public int MaSP { get; set; }
        public int MaDDH { get; set; }
        public int SoLuong { get; set; }
        public double Gia { get; set; }

        public SanPham SanPham { get; set; }
    }
}