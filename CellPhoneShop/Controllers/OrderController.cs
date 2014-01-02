using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        OrderService service = new OrderService();

        public ActionResult Index(int page = 1)
        {
            int offset = (page - 1) * Setting.OrderPerPage;
            ListOrderModel result = service.GetListOrder(User.Identity.Name, offset, Setting.OrderPerPage);
            int totalPage = result.count / Setting.OrderPerPage;
            if (totalPage * Setting.OrderPerPage < result.count)
            {
                totalPage++;
            }
            ViewBag.totalPage = totalPage;
            ViewBag.page = page;

            return View(result.orders);
        }

        //
        // GET: /Order/Details/5

        public ActionResult Details(int id)
        {
            DonDatHang dh = service.GetOrder(id);
            if (dh != null)
            {
                ProductService pService = new ProductService();
                foreach (ChiTietDonHang ctdh in dh.ChiTietDonHangs)
                {
                    ctdh.SanPham = pService.GetProduct(ctdh.MaSP);
                }
            }

            return View(dh);
        }

        //
        // GET: /Order/Delete/5

        public ActionResult Delete(int id)
        {
            bool result = service.DeleteOrder(id);
            if (result)
            {
                return RedirectToAction("Index");
            }

            return View("Error");
        }
   }
}
