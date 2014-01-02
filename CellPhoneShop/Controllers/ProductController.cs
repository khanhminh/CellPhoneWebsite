using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CellPhoneShop.Filters;

namespace CellPhoneShop.Controllers
{
    public class ProductController : Controller
    {
        ProductService service = new ProductService();

        [ProductFilter]
        public ActionResult Index(int? brand)
        {
            if (brand.HasValue)
            {
                ViewBag.brand = brand.Value;
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            SanPham sp = service.GetDetailProduct(id);
            return View(sp);
        }

        public JsonResult Filter(FilterModel filter)
        {
            ListProductModel result = service.GetProducts(filter);
            if (result != null)
            {
                result.page = filter.page;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult NewProduct(int? page)
        {
            page = (!page.HasValue || page < 1) ? 1 : page;
            NewProductModel model = 
                service.GetNewProduct((page.Value - 1) * Setting.ProductPerPage, Setting.ProductPerPage);

            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [ProductFilter]
        public ActionResult Search(string query)
        {
            ViewBag.query = query;

            return View("Index");
        }

        public ActionResult Compare(int[] product)
        {
            List<SanPham> model = new List<SanPham>();
            if (product != null)
            {
                foreach (int id in product)
                {
                    model.Add(service.GetDetailProduct(id));
                }
            }

            return View(model);
        }

        public JsonResult RelativeProduct(int id, int count = 20)
        {
            return Json(service.GetRelativeProduct(id, count), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPriceCompare(int id)
        {
            return Json(service.GetPriceCompare(id), JsonRequestBehavior.AllowGet);
        }
    }
}
