



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisFileResults"), Route("{action=index}")]
    public class AisFileResultsController : Controller
    {
        [PageAuthorize("AisFileResults")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisFileResults/AisFileResultsIndex.cshtml");
        }
    }
}