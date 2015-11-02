



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailLog"), Route("{action=index}")]
    public class EmailLogController : Controller
    {
        [PageAuthorize("EmailLog")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailLog/EmailLogIndex.cshtml");
        }
    }
}