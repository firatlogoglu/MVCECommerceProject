using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Filters.AuthorizationFilters
{
    public class CustomerAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["CLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/Customer/Account/Login");
            }
        }
    }
}