



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailNew"), Route("{action=index}")]
    public class EmailNewController : Controller
    {
        [PageAuthorize("EmailNew")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailNew/EmailNewIndex.cshtml");
        }
    }
}