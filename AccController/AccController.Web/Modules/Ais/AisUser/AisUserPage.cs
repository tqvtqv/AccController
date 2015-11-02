


namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisUser"), Route("{action=index}")]
    public class AisUserController : Controller
    {
        [PageAuthorize("AisUser")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisUser/AisUserIndex.cshtml");
        }
    }
}