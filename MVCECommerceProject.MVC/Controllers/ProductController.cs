using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ProductService productService = new ProductService();

        public ActionResult Index()
        {
            var products = productService.GetActive();
            return View(products);
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult FindCategoryProducts(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Product> products = productService.FindCategoryActivedProducts(id).ToList();
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        public ActionResult FindSubCategoryProducts(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Product> products = productService.FindSubCategoryActivedProducts(id).ToList();
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        public ActionResult FindSellerProducts(Guid id)
        {
            var products = productService.FindSellerActivedProducts(id);
            return View(products);
        }
    }
}