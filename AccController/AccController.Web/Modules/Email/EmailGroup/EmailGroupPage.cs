



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailGroup"), Route("{action=index}")]
    public class EmailGroupController : Controller
    {
        [PageAuthorize("EmailGroup")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailGroup/EmailGroupIndex.cshtml");
        }
    }
}