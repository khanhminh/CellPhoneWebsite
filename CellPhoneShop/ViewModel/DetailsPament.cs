using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CellPhoneShop.ViewModel
{
    public class DetailsPayment
    {
        public NguoiNhan Receiver { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức giao hàng")]
        public int MaPTGH { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phương thức thanh toán")]
        public int MaPTTT { get; set; }
    }
}