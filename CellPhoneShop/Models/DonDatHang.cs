using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class DonDatHang
    {
        public int MaDDH { get; set; }
        public string MaTK { get; set; }
        public int MaNguoiNhan { get; set; }
        public System.DateTime NgayLap { get; set; }
        public int MaPTGH { get; set; }
        public int MaPTTT { get; set; }
        public string MaTrangThai { get; set; }
        public double DonGia { get; set; }

        public NguoiNhan NguoiNhan { get; set; }
        public List<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public TrangThaiDonDatHang TrangThaiDonDatHang { get; set; }
        public PhuongThucGiaoHang PhuongThucGiaoHang { get; set; }
        public PhuongThucThanhToan PhuongThucThanhToan { get; set; }
    }
}