
namespace AccController.Administration.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Serenity.Services;
    using System.Threading;
    [RoutePrefix("Administration/User"), Route("{action=index}")]
    public class UserController : Controller
    {
        [PageAuthorize(Administration.PermissionKeys.Security)]
        public ActionResult Index()
        {
            return View("~/Modules/Administration/User/UserIndex.cshtml");
        }


        [AcceptVerbs("POST")]
        public ActionResult getUser()
        {

            UserRetrieveService request = new UserRetrieveService();

            UserDefinition test =(UserDefinition) request.ByUsername(Thread.CurrentPrincipal.Identity.Name);

            return Json(test, JsonRequestBehavior.AllowGet);
        }
    }
}