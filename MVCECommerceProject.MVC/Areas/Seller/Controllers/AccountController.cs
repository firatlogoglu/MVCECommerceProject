using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Seller.Controllers
{
    public class AccountController : Controller
    {
        private AppUserService db = new AppUserService();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(AppUser model)
        {
            try
            {
                if (model.Password != null && model.Email != string.Empty)
                {
                    if (db.CheckEmpoyeeUsers(model.Email, model.Password, MODEL.Enums.Role.Seller_Customer))
                    {
                        var user = db.GetByDefault(x => x.Email == model.Email);
                        Session["SLogin"] = user;

                        var userDetail = Session["SLogin"] as AppUser;
                        TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                        TempData["UserImg"] = userDetail.ImagePath;
                        TempData.Keep();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Error"] = "Lüften E-Posta Adresiniz ve/veya Şifrenizi Kontrol Ediniz ve/veya Yekiniz Yok";
                    }
                }
                else
                {
                    TempData["Error"] = "Lütfen alanları boş bırakmayın";
                }
            }
            catch (Exception exp)
            {
                TempData["Error"] = exp.Message;
            }
            return RedirectToAction("Login");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForgotPassword(string mail)
        {
            if (!db.ForgotPassword(mail, out string errorMsg))
            {
                TempData["Error"] = errorMsg;
                return RedirectToAction("ForgotPassword");
            }

            return View();
        }

        [SellerAuthFilter]
        public ActionResult Index()
        {
            Guid id = Guid.Empty;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                id = userDetail.ID;
                TempData.Keep();
            }
            else
            {
                var userDetail = Session["SLogin"] as AppUser;
                id = userDetail.ID;
            }

            return View(db.GetById(id));
        }

        [SellerAuthFilter]
        public ActionResult Edit(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id != null)
            {
                AppUser appUser = db.GetById(id);
                return View(appUser);
            }
            else
            {
                TempData["Error"] = "Bir hata meydana geldi.";
                return RedirectToAction("Index");
            }
        }

        [SellerAuthFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase ImagePath, AppUser appUser)
        {
            TempData.Keep();
            var userDetail = Session["SLogin"] as AppUser;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            appUser.ModifiedBy = userDetail.Email;

            if (db.CheckAgainEmailAddres(appUser, out string msgMail, out AppUser appMailUserout))
            {
                TempData["Error"] = msgMail;
                return View(appMailUserout);
            }

            if (db.CheckAgainUserChangeTCNO(appUser, out string msgTCNO, out AppUser appTCNOUserout))
            {
                TempData["Error"] = msgTCNO;
                return View(appTCNOUserout);
            }

            db.CheckImageFullEmpty(appUser, userDetail.ImagePath, ImagePath);
            return RedirectToAction("Index");
        }

        [SellerAuthFilter]
        public ActionResult Logout()
        {
            Session.Remove("SLogin");
            TempData.Clear();

            return RedirectToAction("Login");
        }

        [SellerAuthFilter]
        public ActionResult LogChange()
        {
            var userDetail = Session["SLogin"] as AppUser;
            if (userDetail.Role == MODEL.Enums.Role.Seller_Customer)
            {
                Session["CLogin"] = Session["SLogin"] as AppUser;
                Session.Remove("SLogin");
                TempData.Clear();

                return RedirectToAction("Index", "Home", new { area = "Customer" });
            }
            return RedirectToAction("Index", "Home");
        }
    }
}