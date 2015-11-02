using AccController.Administration;
using System.Web.Mvc;

namespace AccController.Modules.Common.ActionFilters
{
    public class UserFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = filterContext.RouteData.Values["username"];
                var user = new UserRetrieveService().ByUsername(filterContext.HttpContext.User.Identity.Name);
                if (user == null
                    && !"Account".Equals(filterContext.RouteData.Values["controller"])
                    && !"Register".Equals(filterContext.RouteData.Values["action"]))
                    filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Register" }));
            }

        }
    }
}
