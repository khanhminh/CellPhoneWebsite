using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPhoneShop.ViewModel
{
    public class ShoppingCart
    {
        public List<GioHang> CartItems { get; set; }
        public double CartTotal { get; set; }
    }
}
