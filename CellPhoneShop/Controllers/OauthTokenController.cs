using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    public class OauthTokenController : Controller
    {
        public ActionResult Index()
        {
            AccessTokenService service = new AccessTokenService();
            service.UpdateToken();

            return View();
        }

    }
}
