using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Seller.Controllers
{
    [SellerAuthFilter]
    public class ProductController : Controller
    {
        private ProductService productService = new ProductService();
        private SubCategoryService subCategoryService = new SubCategoryService();
        private AppUserService appUserService = new AppUserService();
        public ActionResult Index()
        {
            var userDetail = Session["SLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            return View(productService.FindSellerProducts(userDetail.ID));
        }

        public ActionResult Create()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase ImagePath)
        {
            var userDetail = Session["SLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            if (ModelState.IsValid)
            {
                product.ID = Guid.NewGuid();
                product.SellerID = userDetail.ID;

                if (product.UnitsInStock <= 0)
                {
                    product.Status = CORE.Enums.Status.Deleted;
                    product.UnitsInStock = 0;
                    TempData["Error"] = product.ProductName + " isimli ürün, stoktaki ürün miktrı 0 veya negatif sayı olduğundan dolayı otomatik olarak stok miktarı 0 ve ürünü satıştan kaldırıldı. ";
                }

                //TODO: Yol ayarlanacak
                product.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                product.CreatedBy = userDetail.Email;
                productService.Add(product);

                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        public ActionResult Edit(Guid id)
        {
            var userDetail = Session["SLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.SubCategoryID = new SelectList(subCategoryService.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product, HttpPostedFileBase ImagePath)
        {
            var userDetail = Session["SLogin"] as AppUser;
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
                productService.Update(product);

                return RedirectToAction("Index");
            }
            else
            {
                product.ImagePath = productService.GetById(product.ID).ImagePath;
                productService.Update(product);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TempData.Keep();
            var userDetail = Session["SLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            Product product = productService.GetById(id);
            product.ModifiedBy = userDetail.Email;
            productService.Remove(product);

            return RedirectToAction("Index");
        }
    }
}