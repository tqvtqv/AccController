

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Email/EmailGroupAccount", typeof(AccController.Email.Pages.EmailGroupAccountController))]

namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;

    [RoutePrefix("Email/EmailGroupAccount"), Route("{action=index}")]
    public class EmailGroupAccountController : Controller
    {
        [PageAuthorize("GroupAccount")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailGroupAccount/EmailGroupAccountIndex.cshtml");
        }
    }
}