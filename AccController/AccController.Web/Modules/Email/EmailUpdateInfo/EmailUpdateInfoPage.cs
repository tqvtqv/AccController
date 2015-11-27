
[assembly: Serenity.Navigation.NavigationLink(3005, "Email/Cập nhật thông tin", typeof(AccController.Email.Pages.EmailUpdateInfoController))]



namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailUpdateInfo"), Route("{action=index}")]
    public class EmailUpdateInfoController : Controller
    {
        [PageAuthorize("EmailUpdateInfo")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailUpdateInfo/EmailUpdateInfoIndex.cshtml");
        }
    }
}