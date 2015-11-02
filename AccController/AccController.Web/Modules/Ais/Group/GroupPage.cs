



namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/Group"), Route("{action=index}")]
    public class GroupController : Controller
    {
        [PageAuthorize("Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/Group/GroupIndex.cshtml");
        }
    }
}