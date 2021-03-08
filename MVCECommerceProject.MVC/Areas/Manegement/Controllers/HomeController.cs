using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
{
    [ManegementAuthFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                TempData.Keep();
            }

            return View();
        }

        public ActionResult About()
        {
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                TempData.Keep();
            }

            return View();
        }

        public ActionResult Contact()
        {
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["MLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
                TempData.Keep();
            }

            return View();
        }
    }
}