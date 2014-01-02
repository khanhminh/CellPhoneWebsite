using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    public class NguoiNhan
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập điện thoại liên lạc")]
        [RegularExpression(@"^\d{6,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Điện thoại liên lạc")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }
}