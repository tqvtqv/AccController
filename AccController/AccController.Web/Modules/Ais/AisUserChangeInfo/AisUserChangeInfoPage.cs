



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/AisUserChangeInfo"), Route("{action=index}")]
    public class AisUserChangeInfoController : Controller
    {
        [PageAuthorize("AisUser")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisUserChangeInfo/AisUserChangeInfoIndex.cshtml");
        }
    }
}