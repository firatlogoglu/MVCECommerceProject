using MVCECommerceProject.COMMON.MyTools;
using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Customer.Controllers
{
    public class AccountController : Controller
    {
        AppUserService db;

        public AccountController()
        {
            if (db == null)
            {
                db = new AppUserService();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser model)
        {
            try
            {
                if (model.Password != null && model.Email != string.Empty)
                {
                    if (db.CheckEmpoyeeUsers(model.Email, model.Password, MODEL.Enums.Role.Customer))
                    {
                        var user = db.GetByDefault(x => x.Email == model.Email);
                        Session["CLogin"] = user;

                        var userDetail = Session["CLogin"] as AppUser;
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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser user, HttpPostedFileBase ImagePath)
        {
            try
            {
                user.ID = Guid.NewGuid();
                user.Role = MODEL.Enums.Role.Customer;
                user.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                db.Add(user);
                TempData["Success"] = "Kayıt işlemi başarılı.";
                return RedirectToAction("Login");
            }
            catch (Exception exp)
            {
                TempData["Error"] = exp.Message;
                return View();
            }
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string mail)
        {
            if (mail == string.Empty)
            {
                TempData["Error"] = "Lütfen alanları boş bırakmayın";
                return RedirectToAction("ForgotPassword");
            }
            else
            {
                var a = MailSender.SendEmail(mail, "Şifre Sıfırlama", "Şifre Sıfırlama") as string;

                if (a != string.Empty)
                {
                    TempData["Error"] = a;
                }
            }
            return View();
        }

        [CustomerAuthFilter]
        public ActionResult Index()
        {
            Guid id = Guid.Empty;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                id = userDetail.ID;
                TempData.Keep();
            }
            else
            {
                var userDetail = Session["CLogin"] as AppUser;
                id = userDetail.ID;
            }

            return View(db.GetById(id));
        }

        [CustomerAuthFilter]
        public ActionResult Edit(Guid id)
        {
            Guid guidid = Guid.Empty;
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                guidid = userDetail.ID;
                TempData.Keep();
            }
            else
            {
                var userDetail = Session["CLogin"] as AppUser;
                id = userDetail.ID;
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

        [CustomerAuthFilter]
        [HttpPost]
        public ActionResult Edit(HttpPostedFileBase ImagePath, AppUser appUser)
        {
            if (ImagePath != null)
            {
                appUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
                db.Update(appUser);
                return RedirectToAction("Index");
            }
            else
            {
                var userDetail = Session["CLogin"] as AppUser;
                appUser.ImagePath = userDetail.ImagePath;

                db.Update(appUser);
                return RedirectToAction("Index");
            }
        }


        [CustomerAuthFilter]
        public ActionResult Logout()
        {
            Session.Remove("CLogin");
            TempData.Clear();
            return RedirectToAction("Login");
        }

        [CustomerAuthFilter]
        public ActionResult LogChange()
        {
            Session["SLogin"] = Session["CLogin"] as AppUser;
            Session.Remove("CLogin");
            TempData.Clear();

            return RedirectToAction("Index", "Home", new { area = "Seller" });
        }
    }
}