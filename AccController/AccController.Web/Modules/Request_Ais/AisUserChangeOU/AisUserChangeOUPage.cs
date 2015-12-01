

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/AisUserChangeOU", typeof(AccController.Request_Ais.Pages.AisUserChangeOUController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Ais/AisUserChangeOU"), Route("{action=index}")]
    public class AisUserChangeOUController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/AisUserChangeOU/AisUserChangeOUIndex.cshtml");
        }
    }
}