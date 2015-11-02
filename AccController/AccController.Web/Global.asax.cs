
namespace AccController
{
    using Administration;
    using Serenity;
    using Serenity.Abstractions;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Web.Mvc;
    using System.Web.Routing;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ValueProviderFactories.Factories.Remove(
                ValueProviderFactories.Factories.OfType<JsonValueProviderFactory>().First());

            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            SiteInitialization.ApplicationStart();
        }

        protected void Application_End(object sender, EventArgs e)
        {
            SiteInitialization.ApplicationEnd();
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["LanguagePreference"];
            if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
            {
                try
                {
                    var culture = CultureInfo.GetCultureInfo(cookie.Value);
                    Thread.CurrentThread.CurrentUICulture = culture;
                }
                catch (CultureNotFoundException)
                {
                    // ignore
                }
            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            //var user = Thread.CurrentPrincipal.Identity;
            //if (user != null)
            //{
            //    string username = user.Name;
            //}
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = new UserRetrieveService().ByUsername(User.Identity.Name);
            //    var requestRouteValues = Request.
            //    if (user == null && !Request.AppRelativeCurrentExecutionFilePath.Contains("Account/Register"))
            //        Response.Redirect(System.Web.VirtualPathUtility.ToAbsolute("~/Account/Register"));
            //}
            //if (User.Identity.IsAuthenticated)
            //{
            //    var user = new UserRetrieveService().ByUsername(User.Identity.Name);
            //    if (user == null && !Request.AppRelativeCurrentExecutionFilePath.Contains("Account/Login"))
            //        Response.Redirect(System.Web.VirtualPathUtility.ToAbsolute("~/Account/Login"));
            //}
        }

        protected void Application_Error(object sender, EventArgs e)
        {
        }
    }
}