



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisAddOU"), Route("{action=index}")]
    public class AisAddOUController : Controller
    {
        [PageAuthorize("AisAddOU")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisAddOU/AisAddOUIndex.cshtml");
        }
    }
}