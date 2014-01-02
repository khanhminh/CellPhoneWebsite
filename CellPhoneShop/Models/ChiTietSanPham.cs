using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class ChiTietSanPham
    {
        public int MaChiTiet { get; set; }
        public string MaCTHDH { get; set; }
        public string LoaiManHinh { get; set; }
        public string DoPhanGiai { get; set; }
        public Nullable<double> KichThuocMH { get; set; }
        public string CamUng { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public int DungluongRAM { get; set; }
        public string DonViRAM { get; set; }
        public Nullable<int> ROM { get; set; }
        public int BoNhoTrong { get; set; }
        public Nullable<bool> HoTroTheNho { get; set; }
        public string Camera { get; set; }
        public string C_2G { get; set; }
        public string C_3G { get; set; }
        public string Wifi { get; set; }
        public string Bluetooth { get; set; }
        public string GPS { get; set; }
        public string KetNoiKhac { get; set; }
        public string BanPhim { get; set; }
        public string NgonNgu { get; set; }
        public int SoSIM { get; set; }
        public Nullable<bool> GhiAm { get; set; }
        public Nullable<bool> FMRadio { get; set; }
        public Nullable<double> JackTaiNghe { get; set; }
        public string CamBien { get; set; }
        public string ChucNangKhac { get; set; }
        public string LoaiPin { get; set; }
        public Nullable<int> DungLuongPin { get; set; }
        public Nullable<double> TrongLuong { get; set; }
        public string KichThuoc { get; set; }
        public Nullable<int> BaoHanh { get; set; }

        public HeDieuHanh HeDieuHanh { get; set; }
        public List<HinhAnh> HinhAnhs { get; set; }
    }
}