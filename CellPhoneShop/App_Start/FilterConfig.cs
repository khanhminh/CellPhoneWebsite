using CellPhoneShop.Filters;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PageFilter());
        }
    }
}