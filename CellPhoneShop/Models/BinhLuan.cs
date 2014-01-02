using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class BinhLuan
    {
        public int MaBL { get; set; }
        public int MaSP { get; set; }
        public string HoTen { get; set; }
        public System.DateTime Ngay { get; set; }
        public string NoiDung { get; set; }

        public string NgayToString
        {
            get
            {
                return string.Format("{0:dd/MM/yyyy HH:mm}", Ngay);
            }
        }
    }
}