using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using MVCECommerceProject.COMMON.MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
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
                    if (db.CheckEmpoyeeUsers(model.Email, model.Password, MODEL.Enums.Role.Admin))
                    {
                        var user = db.GetByDefault(x => x.Email == model.Email);
                        Session["MLogin"] = user;

                        var userDetail = Session["MLogin"] as AppUser;
                        TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                        TempData["UserImg"] = userDetail.ImagePath;
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

        [ManegementAuthFilter]
        public ActionResult Logout()
        {
            Session.Remove("MLogin");
            return RedirectToAction("Login");
        }
    }
}