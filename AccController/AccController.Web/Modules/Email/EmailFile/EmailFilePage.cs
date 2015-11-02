



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailFile"), Route("{action=index}")]
    public class EmailFileController : Controller
    {
        [PageAuthorize("EmailFile")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailFile/EmailFileIndex.cshtml");
        }
    }
}