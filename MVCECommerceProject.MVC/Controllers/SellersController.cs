using MVCECommerceProject.SERVICE.Option;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Controllers
{
    public class SellersController : Controller
    {
        private AppUserService seller = new AppUserService();
        private ProductService proser = new ProductService();
        public ActionResult Index()
        {
            var sellers = seller.GetActive().Where(x => x.Role == MODEL.Enums.Role.Seller_Customer);
            return View(sellers);
        }

        public ActionResult Find(Guid id)
        {
            var sel = seller.GetById(id);
            return View(sel);
        }

        public ActionResult Products(Guid id)
        {
            var pro = proser.GetActive().Where(x => x.SellerID == id);
            return View(pro);
        }

        public ActionResult TableProducts(Guid id)
        {
            var pro = proser.GetActive().Where(x => x.SellerID == id);
            return View(pro);
        }
    }
}