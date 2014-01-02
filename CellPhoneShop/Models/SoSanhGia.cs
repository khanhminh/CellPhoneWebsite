using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class SoSanhGia
    {
        public int MaSo { get; set; }
        public int MaSP { get; set; }
        public string MaWebsite { get; set; }
        public string Gia { get; set; }

        public Website Website { get; set; }
    }
}