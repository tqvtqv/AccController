



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisLog"), Route("{action=index}")]
    public class AisLogController : Controller
    {
        [PageAuthorize("AisLog")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisLog/AisLogIndex.cshtml");
        }
    }
}