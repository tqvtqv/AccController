



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailUpdateInfo"), Route("{action=index}")]
    public class EmailUpdateInfoController : Controller
    {
        [PageAuthorize("EmailUpdateInfo")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailUpdateInfo/EmailUpdateInfoIndex.cshtml");
        }
    }
}