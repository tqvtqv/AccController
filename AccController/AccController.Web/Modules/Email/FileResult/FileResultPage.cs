



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/FileResult"), Route("{action=index}")]
    public class FileResultController : Controller
    {
        [PageAuthorize("FileResult")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/FileResult/FileResultIndex.cshtml");
        }
    }
}