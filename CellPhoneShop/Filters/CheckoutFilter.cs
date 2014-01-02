using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Filters
{
    public class CheckoutFilter : ActionFilterAttribute, IActionFilter
    {
        private List<PhuongThucGiaoHang> ListPTGH = null;
        private List<PhuongThucThanhToan> ListPTTT = null;
        private OrderService service = new OrderService();

        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (ListPTGH == null)
            {
                ListPTGH = service.GetListPTGH();
            }
            if (ListPTTT == null)
            {
                ListPTTT = service.GetListPTTT();
            }
            filterContext.Controller.ViewBag.DsPTGH = ListPTGH;
            filterContext.Controller.ViewBag.DsPTTT = ListPTTT;

            this.OnActionExecuting(filterContext);
        }

    }
}