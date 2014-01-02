using CellPhoneShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CellPhoneShop
{
    public class ShoppingCartBLL
    {
        private CellPhoneShopDbEntities db = new CellPhoneShopDbEntities();
        private ProductService pService = new ProductService();

        string ShoppingCartId  { get; set; }

        public const string CartSessionKey = "MaGioHang";

        public static ShoppingCartBLL GetCart(HttpContextBase context)
        {
            var cart = new ShoppingCartBLL();
            cart.ShoppingCartId  = cart.GetMaGioHang(context);
            return cart;
        }

        // Helper method to simplify shopping cart calls
        public static ShoppingCartBLL GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }

        public void AddToCart(int id)
        {
            var sanpham = pService.GetProduct(id);

            GioHang cartItem = null;
            if (sanpham != null)
            {
                cartItem = db.GioHangs.SingleOrDefault(
                                            c => c.MaGioHang == ShoppingCartId
                                            && c.MaSP == sanpham.MaSP);
            }

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new GioHang
                {
                    MaSP = sanpham.MaSP,
                    MaGioHang = ShoppingCartId ,
                    SoLuong = 1,
                    NgayTao = DateTime.Now
                };

                db.GioHangs.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, then add one to the quantity
                cartItem.SoLuong++;
            }

            // Save changes
            db.SaveChanges();
        }

        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.GioHangs.Single(
                                cart => cart.MaGioHang == ShoppingCartId 
                                && cart.MaSo == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.SoLuong > 1)
                {
                    cartItem.SoLuong--;
                    itemCount = cartItem.SoLuong;
                }
                else
                {
                    db.GioHangs.Remove(cartItem);
                }

                // Save changes
                db.SaveChanges();
            }

            return itemCount;
        }

        public void EmptyCart()
        {
            var cartItems = db.GioHangs.Where(cart => cart.MaGioHang == ShoppingCartId );

            foreach (var cartItem in cartItems)
            {
                db.GioHangs.Remove(cartItem);
            }

            // Save changes
            db.SaveChanges();
        }

        public List<GioHang> GetCartItems()
        {
            List<GioHang> result = db.GioHangs.Where(cart => cart.MaGioHang == ShoppingCartId ).ToList();
            foreach (GioHang gh in result)
            {
                gh.SanPham = pService.GetProduct(gh.MaSP);
            }

            return result; 
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.GioHangs
                          where cartItems.MaGioHang == ShoppingCartId 
                          select (int?)cartItems.SoLuong).Sum();

            // Return 0 if all entries are null
            return count ?? 0;
        }

        public double GetTotal()
        {
            double total = 0;
            var query = from cartItems in db.GioHangs
                        where cartItems.MaGioHang == ShoppingCartId
                        select cartItems;
            List<GioHang> list = query.ToList();
            foreach (GioHang gh in list)
            {
                SanPham sp = pService.GetProduct(gh.MaSP);
                total += gh.SoLuong * sp.GiaBanHienHanh;
            }

            return total;
        }

        public double GetItemTotal(int id)
        {
            double total = 0;
            var query = from cartItems in db.GioHangs
                        where cartItems.MaGioHang == ShoppingCartId && cartItems.MaSo == id
                        select cartItems;
            List<GioHang> list = query.ToList();
            foreach (GioHang gh in list)
            {
                SanPham sp = pService.GetProduct(gh.MaSP);
                total += gh.SoLuong * sp.GiaBanHienHanh;
            }

            return total;
        }

        public DonDatHang CreateOrder(DetailsPayment details, string username)
        {
            NguoiNhan receiver = details.Receiver;

            DonDatHang order = new DonDatHang();
            order.NguoiNhan = receiver;
            order.MaPTGH = details.MaPTGH;
            order.MaPTTT = details.MaPTTT;
            order.MaTK = username;
            order.NgayLap = DateTime.Now;
            order.DonGia = 0;
            order.MaTrangThai = "CGTT";

            var cartItems = GetCartItems();
            order.ChiTietDonHangs = new List<ChiTietDonHang>();
            double total = 0;
            foreach (var item in cartItems)
            {
                var detailsOrder = new ChiTietDonHang
                {
                    MaDDH = order.MaDDH,
                    MaSP = item.MaSP,
                    SoLuong = item.SoLuong,
                    Gia = item.SanPham.GiaBanHienHanh
                };
                total += item.SanPham.GiaBanHienHanh;
                order.ChiTietDonHangs.Add(detailsOrder);
            }
            order.DonGia = total;

            return order;
        }


        // We're using HttpContextBase to allow access to cookies.
        public string GetMaGioHang(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] = context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempMaGioHang = Guid.NewGuid();

                    // Send tempMaGioHang back to client as a cookie
                    context.Session[CartSessionKey] = tempMaGioHang.ToString();
                }
            }

            return context.Session[CartSessionKey].ToString();
        }

        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.GioHangs.Where(c => c.MaGioHang == ShoppingCartId );

            foreach (GioHang item in shoppingCart)
            {
                item.MaGioHang = userName;
            }
            db.SaveChanges();
        }
    }
}
