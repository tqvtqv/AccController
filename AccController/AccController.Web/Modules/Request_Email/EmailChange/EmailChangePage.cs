

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Email/EmailChange", typeof(AccController.Request_Email.Pages.EmailChangeController))]

namespace AccController.Request_Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Email/EmailChange"), Route("{action=index}")]
    public class EmailChangeController : Controller
    {
        [PageAuthorize("Request_Email")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Email/EmailChange/EmailChangeIndex.cshtml");
        }
    }
}