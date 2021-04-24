using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Seller.Controllers
{
    [SellerAuthFilter]
    public class HomeController : Controller
    {
        private ProductService productService = new ProductService();
        public ActionResult Index()
        {
            var userDetail = Session["SLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            ViewData["AllProduct"] = productService.GetAll().FindAll(x => x.SellerID == userDetail.ID);
            ViewData["ActiveProduct"] = productService.GetActive().FindAll(x => x.SellerID == userDetail.ID);
            ViewData["DeletedProduct"] = productService.GetDeleted().FindAll(x => x.SellerID == userDetail.ID);

            return View();
        }

        public ActionResult About()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View();
        }

        public ActionResult Contact()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View();
        }
    }
}