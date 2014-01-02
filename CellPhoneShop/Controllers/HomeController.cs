using CellPhoneShop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    public class HomeController : Controller
    {
        private int RecordPerPage = 12;

        public ActionResult Index()
        {
            ProductService productService = new ProductService();
            NewProductModel model = productService.GetNewProduct(0, RecordPerPage);
            int totalPage = model.count / RecordPerPage;
            if (totalPage * RecordPerPage < model.count)
            {
                totalPage++;
            }
            ViewBag.TotalPage = totalPage;

            return View(model.data);
        }

        public ActionResult Contact(string message)
        {
            ViewBag.Message = !string.IsNullOrEmpty(message) ? message : "";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(LienHe contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ContactService ctService = new ContactService();
                    if (ctService.PostContact(contact))
                    {
                        return RedirectToAction("Contact", new { message = "Thông tin của bạn đã gửi thành công" });
                    }
                    ModelState.AddModelError("", "Đã có lỗi xảy ra, vui lòng thử lại");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Đã có lỗi xảy ra, vui lòng thử lại");
                }
            }

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public JsonResult News()
        {
            NewsService nservice = new NewsService();

            return Json(nservice.GetNews(0, Setting.OrderPerPage), JsonRequestBehavior.AllowGet);
        }
    }
}
