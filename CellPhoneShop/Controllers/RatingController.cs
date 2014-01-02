using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    public class RatingController : Controller
    {
        RatingService service = new RatingService();

        public JsonResult Rating(int id, int score)
        {
            int result = RatingState.NotLogin;
            if (Request.IsAuthenticated)
            {
                DanhGia dg = new DanhGia();
                dg.NguoiDung = User.Identity.Name;
                dg.MaSP = id;
                dg.Diem = score;
                result = service.Rating(dg) ? RatingState.Success : RatingState.Error;
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(int id)
        {
            return Json(service.GetRating(id), JsonRequestBehavior.AllowGet);
        }

    }
}
