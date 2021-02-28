using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Manegement.Controllers
{
    [ManegementAuthFilter]
    public class HomeController : Controller
    {
        // GET: Manegement/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}