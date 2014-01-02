using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using WebMatrix.WebData;
using CellPhoneShop.Filters;
using CellPhoneShop.Models;
using Facebook;

namespace CellPhoneShop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private AccountService service = new AccountService();

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid && service.CheckLogin(model))
            {
                MigrateShoppingCart(model.TenDangNhap);
                FormsAuthentication.SetAuthCookie(model.TenDangNhap, model.NhoMatKhau);

                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không chính xác");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            if (Session["Token"] != null)
            {
                return Redirect("https://www.facebook.com/logout.php?"
                  + "next=" + Request.Url.AbsoluteUri
                  + "&access_token=" + Session["Token"]);
            }
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult LogOff(string url)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(TaiKhoan tk)
        {
            if (ModelState.IsValid)
            {
                int result = service.CreateAccount(tk);
                if (result == RegisterState.Success)
                {
                    MigrateShoppingCart(tk.TenDangNhap);
                    FormsAuthentication.SetAuthCookie(tk.TenDangNhap, true);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == RegisterState.UsernameExist)
                {
                    ModelState.AddModelError("", "Tên đăng nhập đã tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "Đã có lỗi xảy ra, vui lòng thử lại");
                }
            }
            return View(tk);
        }

        [AllowAnonymous]
        public JsonResult IsUsernameNotExist(string tendangnhap)
        {
            bool result = service.GetAccount(tendangnhap) == null;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult CheckEmail(string email)
        {
            string username = service.GetUsername(email);
            bool result = string.IsNullOrEmpty(username) ? true : false;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ChangePassword(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "Mật khẩu của bạn đã được cập nhật thành công" : "";

            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(PasswordModel model)
        {
            ViewBag.ReturnUrl = Url.Action("ChangePassword");
            if (ModelState.IsValid)
            {
                UserMembershipModel user = new UserMembershipModel();
                user.username = User.Identity.Name;
                user.currentPassword = model.MatKhauHienTai;
                user.newPassword = model.MatKhauMoi;
                if (service.ChangePassword(user))
                {
                    return RedirectToAction("ChangePassword", new { Message = ManageMessageId.ChangePasswordSuccess });
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật thất bại!");
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Manage(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangeInfoSuccess ? "Cập nhật thành công" : "";
            TaiKhoan tk = service.GetAccount(User.Identity.Name);
            InfoUserModel info = new InfoUserModel();
            info.HoTen = tk.HoTen;
            info.Email = tk.Email;
            info.DiaChi = tk.DiaChi;
            info.DienThoai = tk.DienThoai;
            info.GioiTinh = tk.GioiTinh;
            info.NgaySinh = tk.NgaySinh.Value;

            return View(info);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Manage(InfoUserModel info)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.HoTen = info.HoTen;
                    tk.Email = info.Email;
                    tk.DiaChi = info.DiaChi;
                    tk.DienThoai = info.DienThoai;
                    tk.GioiTinh = info.GioiTinh;
                    tk.NgaySinh = info.NgaySinh;
                    tk.TenDangNhap = User.Identity.Name;

                    if (service.UpdateAccount(tk))
                    {
                        return RedirectToAction("Manage", new { message = ManageMessageId.ChangeInfoSuccess });
                    }
                    ModelState.AddModelError("", "Có lỗi xảy ra vui lòng thử lại!");
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }
            return View(info);
        }

        private string app_id = "188837597989902";
        private string app_secret = "106b9fc51568d2c3344fc044d744c9fe";

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = app_id,
                client_secret = app_secret,
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "user_about_me,user_birthday,email"
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        [AllowAnonymous]
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = app_id,
                client_secret = app_secret,
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            if (result.access_token != null)
            {
                Session["Token"] = result.access_token;
                var accessToken = result.access_token;
                fb.AccessToken = accessToken;
                FacebookUserModel user = fb.Get<FacebookUserModel>("me?fields=name,first_name,birthday,email,address,gender");
                string username = service.GetUsername(user.email);
                if (!string.IsNullOrEmpty(username))
                {
                    FormsAuthentication.SetAuthCookie(username, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Session["FacebookUser"] = user;
                    return RedirectToAction("ConfirmLoginFacebook");
                }
            }

            return RedirectToAction("ExternalLoginFailure");
        }

        [AllowAnonymous]
        public ActionResult ConfirmLoginFacebook()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmLoginFacebook(FacebookUserConfirm model)
        {
            if (ModelState.IsValid)
            {
                FacebookUserModel user = (FacebookUserModel)Session["FacebookUser"];
                if (user != null)
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.HoTen = string.Format("{0} {1}", user.first_name, user.name);
                    DateTime date;
                    if (user.birthday != null && DateTime.TryParse(user.birthday, out date))
                    {
                        tk.NgaySinh = date;
                    }
                    tk.NgaySinh = tk.NgaySinh == null ? DateTime.Now : tk.NgaySinh;
                    tk.DiaChi = user.address == null ? "unknow" : user.address;
                    tk.GioiTinh = (user.gender != null && user.gender == "male") ? "Nam" : "Nữ";
                    tk.DienThoai = "unknow";
                    tk.TenDangNhap = model.TenDangNhap;
                    tk.Email = user.email;
                    tk.MatKhau = "123456";

                    if (service.CreateAccount(tk) == RegisterState.Success)
                    {
                        FormsAuthentication.SetAuthCookie(model.TenDangNhap, true);
                        Session.Remove("FacebookUser");
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Có lỗi xảy ra!");
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
                

        private void MigrateShoppingCart(string UserName)
        {
            // Associate shopping cart items with logged-in user
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);

            cart.MigrateCart(UserName);
            Session[ShoppingCartBLL.CartSessionKey] = UserName;
        }

        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Tên đăng nhập đã tồn tại";

                case MembershipCreateStatus.InvalidPassword:
                    return "Mật khẩu không hợp lệ.";

                case MembershipCreateStatus.InvalidEmail:
                    return "Địa chỉ email không hợp lệ.";

                case MembershipCreateStatus.InvalidUserName:
                    return "Tên đăng nhập không hợp lệ.";

                case MembershipCreateStatus.ProviderError:
                    return "Đã có lỗi xảy ra, vui lòng thử lại!";

                case MembershipCreateStatus.UserRejected:
                    return "Đã có lỗi xảy ra, vui lòng thử lại!";

                default:
                    return "Đã có lỗi xảy ra, vui lòng thử lại!";
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public enum ManageMessageId
        {
            ChangePasswordSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            ChangeInfoSuccess,
        }
    }
}
