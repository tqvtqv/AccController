

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Ais/Testt", typeof(AccController.Ais.Pages.TesttController))]

namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/Testt"), Route("{action=index}")]
    public class TesttController : Controller
    {
        [PageAuthorize("Administration")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/Testt/TesttIndex.cshtml");
        }
    }
}