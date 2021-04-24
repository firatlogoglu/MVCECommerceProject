using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Seller.Controllers
{
    [SellerAuthFilter]
    public class CategoryController : Controller
    {
        private CategoryService categoryService = new CategoryService();
        private SubCategoryService subCategoryService = new SubCategoryService();
        public ActionResult Index()
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["SLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            List<Category> kategoriler = new List<Category>();

            foreach (var item in categoryService.GetActive())
            {
                Category category = new Category();
                category = item;

                kategoriler.Add(category);
            }
            ViewData["CategoryList"] = kategoriler;

            return View(subCategoryService.GetAll());
        }
    }
}