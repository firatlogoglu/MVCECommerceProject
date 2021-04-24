﻿using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.CartModel;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Customer.Controllers
{
    [CustomerAuthFilter]
    public class BuyController : Controller
    {
        private ProductService productService = new ProductService();
        private OrderService orderService = new OrderService();
        private AppUserService userService = new AppUserService();

        public ActionResult SepeteEkle(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            //if(id==null)
            //{
            //    TempData["Error"] = "Lütfen, ürünü seçin!";
            //    return RedirectToAction("Index", "Home");
            //}

            var product = productService.GetById(id);
            ViewBag.Stock = product.UnitsInStock.ToString();

            return View(product);
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
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
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

        public ActionResult Buy()
        {
            //TODO: Satış gerçekleştirelecek

            var userDetail = Session["CLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            Cart c = Session["scart"] as Cart;

            Order order = new Order();
            order.ID = Guid.NewGuid();
            order.CustomerID = userDetail.ID;
            Guid sellerid = new Guid();

            foreach (var item in c.MyCart)
            {
                Product product = new Product();
                product = productService.GetById(item.ID);
                product.ModifiedBy = userDetail.Email;
                sellerid = product.SellerID;

                //var ii = product.UnitsInStock - item.Quantity;
                //product.UnitsInStock = Convert.ToInt16(ii);



                OrderDetail orderDetail = new OrderDetail();
                orderDetail.ID = Guid.NewGuid();
                orderDetail.ProductID = product.ID;
                orderDetail.OrderID = order.ID;
                orderDetail.UnitPrice = product.UnitPrice;
                orderDetail.Quantity = item.Quantity;
                //orderDetail.Order.Selle = item.SubTotal;
                orderDetail.CreatedBy = userDetail.Email;
                order.OrderDetails.Add(orderDetail);

                //productService.Update(product);

            }
            order.SellerID = sellerid;
            order.CreatedBy = userDetail.Email;
            orderService.Add(order);
            Session.Remove("scart");
            return View();
        }

        public ActionResult FastBuy(Guid id)
        {
            //TODO: Satışı  gerçekleştirelecek
            //TODO: Giriş yapmadan eklenen ürün bilgisini taşınması yapılılacak
            var userDetail = Session["CLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            Order order = new Order();
            order.ID = Guid.NewGuid();
            order.CustomerID = userDetail.ID;
            Guid sellerid = new Guid();


            Product product = new Product();
            product = productService.GetById(id);
            product.ModifiedBy = userDetail.Email;
            sellerid = product.SellerID;

            //var ii = product.UnitsInStock - item.Quantity;
            //product.UnitsInStock = Convert.ToInt16(ii);



            OrderDetail orderDetail = new OrderDetail();
            orderDetail.ID = Guid.NewGuid();
            orderDetail.ProductID = product.ID;
            orderDetail.OrderID = order.ID;
            orderDetail.UnitPrice = product.UnitPrice;
            orderDetail.Quantity = 1;
            //orderDetail.Order.Selle = item.SubTotal;
            orderDetail.CreatedBy = userDetail.Email;
            order.OrderDetails.Add(orderDetail);

            //productService.Update(product);

            order.SellerID = sellerid;
            order.CreatedBy = userDetail.Email;
            orderService.Add(order); ;
            return View();
        }
    }
}