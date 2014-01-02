using CellPhoneShop;
using CellPhoneShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ActionResult Index()
        {
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCart
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            if (viewModel.CartItems == null || viewModel.CartItems.Count() <= 0)
            {
                return View("EmptyCartPartial");
            }

            return View(viewModel);
        }
               

        public ActionResult AddToCart(int id)
        { 
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);

            cart.AddToCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);            

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemove
            {
                Message = "",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                ItemTotal = cart.GetItemTotal(id),
                DeleteId = id
            };

            return Json(results, JsonRequestBehavior.AllowGet);
        }
        
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);

            ViewBag.CartCount = cart.GetCount();

            return PartialView("CartSummary");
        }

    }
}
