using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace CellPhoneShop.Filters
{
    public class PageFilter : ActionFilterAttribute, IActionFilter
    {
        private List<NhaSanXuat> Brands = null;
        private string LinkService = ConfigurationManager.AppSettings["LinkService"].ToString();

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (Brands == null)
            {
                BrandService service = new BrandService();
                Brands = service.GetListBrand();
            }
            filterContext.Controller.ViewBag.Brands = Brands;
            filterContext.Controller.ViewBag.LinkService = LinkService;

            this.OnActionExecuting(filterContext);
        }
    }
}