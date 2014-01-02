using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    public class CommentController : Controller
    {
        private CommentService service = new CommentService();

        public JsonResult PostComment(BinhLuan bl)
        {
            return Json(service.PostComment(bl), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetComments(int id, int? page)
        {
            page = (!page.HasValue || page < 1) ? 1 : page;
            int offset = (page.Value - 1) * Setting.CommentPerPage;
            ListCommentModel data = service.GetComments(id, offset, Setting.CommentPerPage);
            data.page = page.Value;

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}
