using MVCECommerceProject.SERVICE.Option;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ProductService db = new ProductService();
            return View(db.GetActive());
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}