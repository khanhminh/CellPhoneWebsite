using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class SanPham
    {
        public int MaSP { get; set; }
        public int MaLSP { get; set; }
        public int MaNSX { get; set; }
        public string TenSP { get; set; }
        public double GiaBanHienHanh { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnhDaiDien { get; set; }
        public int MaCTSP { get; set; }
        public System.DateTime NgayNhap { get; set; }
        public double DiemDanhGia { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public string GiaToString
        {
            get
            {
                return string.Format("{0:0,0}", GiaBanHienHanh);
            }
        }
    }
}