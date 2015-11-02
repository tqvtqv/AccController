



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisUserChangeOU"), Route("{action=index}")]
    public class AisUserChangeOUController : Controller
    {
        [PageAuthorize("AisUser")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisUserChangeOU/AisUserChangeOUIndex.cshtml");
        }
    }
}