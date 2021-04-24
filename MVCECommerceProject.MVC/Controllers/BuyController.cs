using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.CartModel;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Controllers
{
    public class BuyController : Controller
    {
        private ProductService productService = new ProductService();
        private OrderService orderService = new OrderService();
        private AppUserService userService = new AppUserService();
        public ActionResult SepeteEkle(Guid id)
        {
            //if (id == null)
            //{
            //    TempData["Error"] = "Lütfen, ürünü seçin!";
            //    return RedirectToAction("Index", "Home");
            //}

            var pro = productService.GetById(id);
            ViewBag.Stock = pro.UnitsInStock.ToString();

            return View(pro);
        }

        [HttpPost]
        public ActionResult SepeteEkle(Product product)
        {
            Cart c = Session["scart"] == null ? new Cart() : Session["scart"] as Cart;
            CartItem ci = new CartItem();
            ci.Quantity = product.UnitsInStock;  /*Convert.ToInt16(product.UnitPrice);*/

            var UnitsInStock = productService.GetById(product.ID).UnitsInStock;
            var ii = UnitsInStock - ci.Quantity;

            if (ci.Quantity < 0 || product.UnitsInStock <= 0)
            {
                TempData["Error"] = "Lütfen, (0) sıfırdan büyük bir sayı giriniz!";
                return View(product);
            }

            if (ii <= 0)
            {
                ci.Quantity = UnitsInStock;
                product.UnitsInStock = 0;
                product.Status = CORE.Enums.Status.Deleted;
                MailSender.SendEmail(userService.GetById(product.SellerID).Email, product.ProductName + " " + "ürünü stokta olmadığından satıştan kaldırılmıştır!!!", "Stokta Ürün Kalmadı!!!");
                if (ii < 0)
                {
                    TempData["Error"] = ii.ToString().Replace('-', ' ') + " adet satın almak istediğiniz ürün, stok miktarımızıdan fazla olduğu için sepetinize eksik olarak eklenmiştir.";
                }
            }
            else
            {
                product.UnitsInStock = Convert.ToInt16(ii);
            }

            ci.ID = product.ID;
            ci.Name = product.ProductName;
            ci.Price = product.UnitPrice;
            ci.ImagePath = product.ImagePath;
            ci.SellerID = product.SellerID;
            ci.SellerName = userService.GetById(ci.SellerID).Name + " " + userService.GetById(ci.SellerID).SurName;
            productService.Update(product);
            c.AddItem(ci);
            Session["scart"] = c;

            return RedirectToAction("Index");
        }

        public ActionResult Index()
        {
            Cart c = Session["scart"] as Cart;

            if (c == null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //TODO: Satıcı adı listelenecek
                return View(c.MyCart);
            }
        }
    }
}