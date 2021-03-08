using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Areas.Seller
{
    public class SellerAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Seller";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Seller_default",
                "Seller/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}