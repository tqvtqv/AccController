

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/AisAddOU", typeof(AccController.Request_Ais.Pages.AisAddOUController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Ais/AisAddOU"), Route("{action=index}")]
    public class AisAddOUController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/AisAddOU/AisAddOUIndex.cshtml");
        }
    }
}