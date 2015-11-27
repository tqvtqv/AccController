

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/Group", typeof(AccController.Request_Ais.Pages.GroupController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Request_Ais/Group"), Route("{action=index}")]
    public class GroupController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/Group/GroupIndex.cshtml");
        }
    }
}