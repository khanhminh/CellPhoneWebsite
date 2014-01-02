using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellPhoneShop.ViewModel
{
    public class ShoppingCartRemove
    {
        public string Message { get; set; }
        public double CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public double ItemTotal { get; set; }
        public int DeleteId { get; set; }
    }
}
