using CellPhoneShop.Filters;
using CellPhoneShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop.Controllers
{
    [Authorize]
    [CheckoutFilter]
    public class CheckoutController : Controller
    {
        //
        // GET: /Checkout/AddressAndPayment

        public ActionResult DetailsPayment()
        {
            var cart = ShoppingCartBLL.GetCart(this.HttpContext);
            var shoppingCart = new ShoppingCart
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            if (shoppingCart.CartItems == null || shoppingCart.CartItems.Count() <= 0)
            {
                return View("EmptyCartPartial");
            }

            ViewBag.Cart = shoppingCart;

            return View();
        }

        [HttpPost]
        public ActionResult DetailsPayment(DetailsPayment model)
        {
            if (ModelState.IsValid)
            {
                ShoppingCartBLL shoppingBLL = ShoppingCartBLL.GetCart(this.HttpContext);
                DonDatHang order = shoppingBLL.CreateOrder(model, this.User.Identity.Name);
                OrderService service = new OrderService();
                int id = service.CreateOrder(order);
                if (id > 0)
                {
                    shoppingBLL.EmptyCart();
                    return RedirectToAction("Complete", new { id = id });
                }
                ModelState.AddModelError("", "Tạo đơn hàng thất bại, vui lòng thử lại!");               
            }

            var cart = ShoppingCartBLL.GetCart(this.HttpContext);
            var shoppingCart = new ShoppingCart
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };

            ViewBag.Cart = shoppingCart;

            return View(model);
        }

        //
        // GET: /Checkout/Complete

        public ActionResult Complete(int id)
        {
            return View(id);
        }

    }
}
