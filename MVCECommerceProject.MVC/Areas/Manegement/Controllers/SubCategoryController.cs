using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
{
    [ManegementAuthFilter]
    public class SubCategoryController : Controller
    {
        private SubCategoryService db = new SubCategoryService();
        private CategoryService categoryService = new CategoryService();

        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View(db.GetAll());
        }

        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(categoryService.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategory subCategory, HttpPostedFileBase ImagePath)
        {
            TempData.Keep();
            var userDetail = Session["MLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (ModelState.IsValid)
            {
                subCategory.ID = Guid.NewGuid();
                subCategory.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Categories/", ImagePath);
                subCategory.CreatedBy = userDetail.Email;
                db.Add(subCategory);

                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(categoryService.GetActive(), "ID", "Name", subCategory.CategoryID);
            return View(subCategory);
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
            SubCategory subCategory = db.GetById(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(categoryService.GetActive(), "ID", "Name", subCategory.CategoryID);
            return View(subCategory);
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
            SubCategory subCategory = db.GetById(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(categoryService.GetActive(), "ID", "Name", subCategory.CategoryID);
            return View(subCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategory subCategory, HttpPostedFileBase ImagePath)
        {
            TempData.Keep();
            var userDetail = Session["MLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            subCategory.ModifiedBy = userDetail.Email;
            if (ImagePath != null)
            {
                subCategory.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Categories/", ImagePath);
                db.Update(subCategory);

                return RedirectToAction("Index");
            }
            else
            {
                subCategory.ImagePath = db.GetById(subCategory.ID).ImagePath;

                db.Update(subCategory);
                return RedirectToAction("Index");
            }
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
            SubCategory subCategory = db.GetById(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TempData.Keep();
            var userDetail = Session["MLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            SubCategory subCategory = db.GetById(id);
            subCategory.ModifiedBy = userDetail.Email;
            db.Remove(subCategory);

            return RedirectToAction("Index");
        }
    }
}