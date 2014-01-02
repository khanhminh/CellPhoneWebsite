using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Filters
{
    public class ProductFilter : ActionFilterAttribute, IActionFilter
    {
        private List<HeDieuHanh> ListOS = null;

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ListOS == null)
            {
                OSService service = new OSService();
                ListOS = service.GetOS();
            }
            filterContext.Controller.ViewBag.OSs= ListOS;

            this.OnActionExecuting(filterContext);
        }

    }
}