using AccController.Modules.Common.ActionFilters;
using System.Web;
using System.Web.Mvc;

namespace AccController
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new UserFilterAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}