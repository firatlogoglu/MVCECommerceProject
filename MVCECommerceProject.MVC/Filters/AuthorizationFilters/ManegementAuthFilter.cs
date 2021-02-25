using System.Web.Mvc;

namespace MVCECommerceProject.MVC.Filters.AuthorizationFilters
{
    public class ManegementAuthFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.Session["MLogin"] == null)
            {
                filterContext.Result = new RedirectResult("~/Manegement/Account/Login");
            }
        }
    }
}