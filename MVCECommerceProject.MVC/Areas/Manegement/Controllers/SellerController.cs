using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
{
    [ManegementAuthFilter]
    public class SellerController : Controller
    {
        private AppUserService db = new AppUserService();
        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View(db.GetAll().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer));
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
            AppUser appUser = db.GetById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
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

            AppUser appUser = new AppUser();
            appUser.Password = appUser.ConfirmPassword = "NULL";
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AppUser appUser, HttpPostedFileBase ImagePath)
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
                appUser.ID = Guid.NewGuid();
                appUser.Role = MODEL.Enums.Role.Seller_Customer;
                appUser.CreatedBy = userDetail.Email;
                appUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                appUser.Password = appUser.ConfirmPassword = Guid.NewGuid().ToString();

                if (db.CheckEmail(appUser.Email))
                {
                    TempData["Error"] = appUser.Email + " e-posta adresi, kayıtlarımızda mevcut.";
                    return View(appUser);
                }
                if (db.CheckTCNO(appUser.TCNO))
                {
                    TempData["Error"] = appUser.TCNO + " TCKNO, kayıtlarımızda mevcut.";
                    return View(appUser);
                }
                db.Add(appUser);

                MailSender.SendEmail(appUser.Email, "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine satıcı hesabınız açılmıştır." + "\n" + "Şifreniz: " + appUser.Password + "\n" + "Bu hesap açma işlemi: " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine yapılmıştır." + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!", "Sitemize Hoşgeldiniz");
                return RedirectToAction("Index");
            }

            return View(appUser);
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
            AppUser appUser = db.GetById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AppUser appUser, HttpPostedFileBase ImagePath)
        {
            var userDetail = Session["MLogin"] as AppUser;
            string cEmailMsg = null;

            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            appUser.ModifiedBy = userDetail.Email;

            if (db.CheckAgainEmailAddres(appUser, out string msgMail, out AppUser appMailUserout, out cEmailMsg))
            {
                TempData["Error"] = msgMail;
                return View(appMailUserout);
            }

            if (db.CheckAgainUserChangeTCNO(appUser, out string msgTCNO, out AppUser appTCNOUserout))
            {
                TempData["Error"] = msgTCNO;
                return View(appTCNOUserout);
            }

            db.CheckImageFullEmpty(appUser, userDetail, ImagePath, cEmailMsg);
            return RedirectToAction("Index");
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
            AppUser appUser = db.GetById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
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

            AppUser appUser = db.GetById(id);
            appUser.ModifiedBy = userDetail.Email;
            db.Remove(appUser);

            MailSender.SendEmail(appUser.Email, "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "Bu hesap silme işlemi: " + userDetail.Name + " " + userDetail.SurName + " (" + userDetail.Email + ") " + "tarafından isteğiniz üzerine yapılmıştır.", "Çok Üzgünüz");
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(Guid id)
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
            AppUser appUser = db.GetById(id);
            if (appUser == null)
            {
                return HttpNotFound();
            }
            return View(appUser);
        }

        [HttpPost, ActionName("ResetPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordConfirmed(Guid id)
        {
            var userDetail = Session["MLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            db.ResetPassword(id, userDetail);
            return RedirectToAction("Index");
        }
    }
}