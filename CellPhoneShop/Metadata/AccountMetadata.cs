using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CellPhoneShop
{
    //[MetadataType(typeof(AccountMetadata))]
    //public partial class TaiKhoan
    //{
    //    public string MatKhau { get; set; }
    //    public string NhapLaiMatKhau { get; set; }
    //}

    public class TaiKhoan
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [RegularExpression("^.{6,20}$", ErrorMessage = "Tên đăng nhập phải từ 6-20 kí tự")]
        [Display(Name = "Tên đăng nhập")]
        [System.Web.Mvc.Remote("IsUsernameNotExist", "Account", ErrorMessage = "Tên đăng nhập đã tồn tại")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression("^.{6,20}$", ErrorMessage = "Mật khẩu phải từ 6-20 kí tự")]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận lại mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu không khớp")]
        public string NhapLaiMatKhau { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        [System.Web.Mvc.Remote("CheckEmail", "Account", ErrorMessage = "Email đã tồn tại")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        [DataType(DataType.DateTime, ErrorMessage = "Ngày sinh không hợp lệ")]
        public System.DateTime? NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập điện thoại liên lạc")]
        [RegularExpression(@"^\d{6,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Điện thoại liên lạc")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }

    public class LoginModel
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [Display(Name = "Tên đăng nhập")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Nhớ mật khẩu")]
        public bool NhoMatKhau { get; set; }
    }

    public class PasswordModel
    {
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        [RegularExpression("^.{6,20}$", ErrorMessage = "Mật khẩu phải từ 6-20 kí tự")]
        [Display(Name = "Mật khẩu hiện tại")]
        public string MatKhauHienTai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
        [DataType(DataType.Password)]
        [RegularExpression("^.{6,20}$", ErrorMessage = "Mật khẩu phải từ 6-20 kí tự")]
        [Display(Name = "Mật khẩu mới")]
        public string MatKhauMoi { get; set; }

        [Required(ErrorMessage = "Vui lòng xác nhận lại mật khẩu")]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập lại mật khẩu mới")]
        [Compare("MatKhauMoi", ErrorMessage = "Mật khẩu không khớp")]
        public string NhapLaiMatKhau { get; set; }
    }

    public class InfoUserModel
    {
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh")]
        [Display(Name = "Ngày sinh")]
        public System.DateTime NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính")]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập điện thoại liên lạc")]
        [RegularExpression(@"^\d{6,11}$", ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Điện thoại liên lạc")]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }
    }

    public class UserMembershipModel
    {
        public string username {get;set;}
        public string currentPassword {get;set;}
        public string newPassword {get;set;}
    }

    public class FacebookUserConfirm
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        [RegularExpression("^.{6,20}$", ErrorMessage = "Tên đăng nhập phải từ 6-20 kí tự")]
        [Display(Name = "Tên đăng nhập")]
        [System.Web.Mvc.Remote("IsUsernameNotExist", "Account", ErrorMessage = "Tên đăng nhập đã tồn tại")]
        public string TenDangNhap { get; set; }
    }
}