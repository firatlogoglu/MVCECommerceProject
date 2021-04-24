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
    public class CategoryController : Controller
    {
        private CategoryService db = new CategoryService();
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
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category, HttpPostedFileBase ImagePath)
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
                category.ID = Guid.NewGuid();
                category.CreatedBy = userDetail.Email;
                category.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Categories/", ImagePath);
                db.Add(category);

                return RedirectToAction("Index");
            }

            return View(category);
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
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
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
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase ImagePath)
        {
            TempData.Keep();
            var userDetail = Session["MLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            category.ModifiedBy = userDetail.Email;
            if (ImagePath != null)
            {
                category.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Categories/", ImagePath);
                db.Update(category);

                return RedirectToAction("Index");
            }
            else
            {
                category.ImagePath = db.GetById(category.ID).ImagePath;
                db.Update(category);

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
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
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

            Category category = db.GetById(id);
            category.ModifiedBy = userDetail.Email;
            db.Remove(category);

            return RedirectToAction("Index");
        }
    }
}