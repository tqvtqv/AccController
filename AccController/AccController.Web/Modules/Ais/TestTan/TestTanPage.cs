

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Ais/TestTan", typeof(AccController.Ais.Pages.TestTanController))]

namespace AccController.Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Ais/TestTan"), Route("{action=index}")]
    public class TestTanController : Controller
    {
        [PageAuthorize("AdminTan")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/TestTan/TestTanIndex.cshtml");
        }
    }
}