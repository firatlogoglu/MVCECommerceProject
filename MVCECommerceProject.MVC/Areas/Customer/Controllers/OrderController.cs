using MVCECommerceProject.MODEL.Entities;
using MVCECommerceProject.MVC.Filters.AuthorizationFilters;
using MVCECommerceProject.SERVICE.Option;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Customer.Controllers
{
    [CustomerAuthFilter]
    public class OrderController : Controller
    {
        private OrderService ors = new OrderService();
        private OrderDetailService ords = new OrderDetailService();

        public ActionResult Index()
        {
            var userDetail = Session["CLogin"] as AppUser;
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {

                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            return View(ords.GetActive().Where(x => x.Order.CustomerID == userDetail.ID));
        }

        public ActionResult OrderDetails(Guid id)
        {
            TempData.Keep();
            if (TempData["User"] == null || TempData["UserImg"] == null)
            {
                var userDetail = Session["CLogin"] as AppUser;
                TempData["User"] = userDetail.Name + " " + userDetail.SurName;
                TempData["UserImg"] = userDetail.ImagePath;
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = ors.GetById(id);

            //TODO: Yeni eklene siparişte ürün adı null geliyor.
            //TODO: Sipariş detay sayfası düzenlenecek.
            if (order == null)
            {
                return HttpNotFound();
            }

            return View(order);
        }
    }
}