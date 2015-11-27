

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/AisUserChangeInfo", typeof(AccController.Request_Ais.Pages.AisUserChangeInfoController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Ais/AisUserChangeInfo"), Route("{action=index}")]
    public class AisUserChangeInfoController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/AisUserChangeInfo/AisUserChangeInfoIndex.cshtml");
        }
    }
}