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
    public class SellerController : Controller
    {
        private AppUserService seller = new AppUserService();
        private ProductService proser = new ProductService();

        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            var sellers = seller.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer);
            return View(sellers);
        }

        public ActionResult Find(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            var sel = seller.GetById(id);
            //TODO: Satıcı sayfası düzenlenecek
            return View(sel);
        }

        public ActionResult Products(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            var pro = proser.GetActive().Where(x => x.SellerID == id);

            return View(pro);
        }

        public ActionResult TableProducts(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }
            var pro = proser.GetActive().Where(x => x.SellerID == id);

            return View(pro);
        }
    }
}