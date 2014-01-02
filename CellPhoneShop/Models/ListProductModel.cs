using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class ListProductModel
    {
        public List<SanPham> data { get; set; }
        public int count { get; set; }
        public int page { get; set; }
    }
}