using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Filters.AuthorizationFilters
{
    public class SellerAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["SLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/Seller/Account/Login");
            }
        }
    }
}