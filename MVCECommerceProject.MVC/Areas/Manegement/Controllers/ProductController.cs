using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
{
    [ManegementAuthFilter]
    public class ProductController : Controller
    {
        private ProductService db = new ProductService();
        private SubCategoryService subCategoryService = new SubCategoryService();
        private AppUserService appUserService = new AppUserService();
        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            var products = db.GetAll();
            return View(products);
        }

        public ActionResult Details(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            ViewBag.SellerID = new SelectList(appUserService.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer), "ID", "Email");
            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImagePath)
        {
            var userDetail = Session["MLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (ModelState.IsValid)
            {
                product.ID = Guid.NewGuid();

                if (product.UnitsInStock <= 0)
                {
                    product.Status = CORE.Enums.Status.Deleted;
                    product.UnitsInStock = 0;
                    TempData["Error"] = product.ProductName + " isimli ürün, stoktaki ürün miktrı 0 veya negatif sayı olduğundan dolayı otomatik olarak stok miktarı 0 ve ürünü satıştan kaldırıldı. ";
                }

                product.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                product.CreatedBy = userDetail.Email;
                db.Add(product);

                MailSender.SendEmail(appUserService.GetById(product.SellerID).Email, "''" + product.ProductName + "'' " + "isimli ürün" + " " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafında isteğiniz üzerine eklenmiştir.", "''" + product.ProductName + "'' isimli ürünün eklenmesi");
                return RedirectToAction("Index");
            }

            ViewBag.SellerID = new SelectList(appUserService.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer), "ID", "Email", product.SellerID);
            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        public ActionResult Edit(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.SellerID = new SelectList(appUserService.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer), "ID", "Email", product.SellerID);
            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase ImagePath)
        {
            var userDetail = Session["MLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            product.ModifiedBy = userDetail.Email;

            if (product.UnitsInStock <= 0)
            {
                product.Status = CORE.Enums.Status.Deleted;
                product.UnitsInStock = 0;
                TempData["Error"] = product.ProductName + " isimli ürün, stoktaki ürün miktrı 0 veya negatif sayı olduğundan dolayı otomatik olarak stok miktarı 0 ve ürünü satıştan kaldırıldı. ";
            }

            if (ImagePath != null)
            {
                product.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                db.Update(product);

                MailSender.SendEmail(appUserService.GetById(product.SellerID).Email, "''" + product.ProductName + "'' " + "isimli ürün," + " " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine değiştirilmiştir.", "''" + product.ProductName + "'' isimli ürünün düzenlenmesi");
                ViewBag.SellerID = new SelectList(appUserService.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer), "ID", "Email", product.SellerID);
                ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
                return RedirectToAction("Index");
            }
            else
            {
                product.ImagePath = db.GetById(product.ID).ImagePath;
                db.Update(product);

                MailSender.SendEmail(appUserService.GetById(product.SellerID).Email, "''" + product.ProductName + "'' " + "isimli ürün," + " " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine değiştirilmiştir.", "''" + product.ProductName + "'' isimli ürünün düzenlenmesi");
                ViewBag.SellerID = new SelectList(appUserService.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer), "ID", "Email", product.SellerID);
                ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
                return RedirectToAction("Index");
            }
        }

        public ActionResult FindCategoryProducts(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Product> products = db.FindCategoryActivedProducts(id).ToList();
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        public ActionResult FindSubCategoryProducts(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<Product> products = db.FindSubCategoryActivedProducts(id).ToList();
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        public ActionResult FindSellerProducts(Guid id)
        {
            var userDetail = Session["MLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {

                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            var products = db.FindSellerActivedProducts(id);
            return View(products);
        }

        public ActionResult Delete(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var userDetail = Session["MLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            Product product = db.GetById(id);
            product.ModifiedBy = userDetail.Email;
            db.Remove(product);

            MailSender.SendEmail(appUserService.GetById(product.SellerID).Email, "''" + product.ProductName + "'' " + "isimli ürün," + " " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine silinmiş/stoktan düşürülmüştür.", "''" + product.ProductName + "'' isimli ürünün silinmesi/stoktan düşürülmesi");
            return RedirectToAction("Index");
        }
    }
}