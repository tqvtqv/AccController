

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/AisUser", typeof(AccController.Request_Ais.Pages.AisUserController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Ais/AisUser"), Route("{action=index}")]
    public class AisUserController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/AisUser/AisUserIndex.cshtml");
        }
    }
}