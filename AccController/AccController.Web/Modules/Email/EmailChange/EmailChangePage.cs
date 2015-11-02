



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailChange"), Route("{action=index}")]
    public class EmailChangeController : Controller
    {
        [PageAuthorize("Email")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailChange/EmailChangeIndex.cshtml");
        }
    }
}