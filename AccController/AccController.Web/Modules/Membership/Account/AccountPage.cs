
namespace AccController.Membership.Pages
{
    using Administration.Endpoints;
    using Administration.Entities;
    using Serenity;
    using Serenity.Services;
    using System;
    using System.Web.Mvc;
    using System.Web.Security;

    [RoutePrefix("Account"), Route("{action=index}")]
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.HideLeftNavigation = true;
            return View("~/Modules/Membership/Account/AccountRegister.cshtml");
        }
        [HttpPost, JsonFilter]
        public Result<SaveResponse> Register(RegisterRequest request)
        {
            request.CheckNotNull();
            return new UserController().Create(new SaveRequest<UserRow>
            {
                Entity = new UserRow
                {
                    Username = request.Username,
                    Password = request.Password,
                    Email = request.Email
                }
            });
        }
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.HideLeftNavigation = true;
            return View("~/Modules/Membership/Account/AccountLogin.cshtml");
        }

        [HttpPost, JsonFilter]
        public Result<ServiceResponse> Login(LoginRequest request)
        {
            return this.ExecuteMethod(() =>
            {
                request.CheckNotNull();

                if (request.Username == null)
                    throw new ArgumentNullException("username");

                var username = request.Username;

                if (WebSecurityHelper.Authenticate(ref username, request.Password, false))
                    return new ServiceResponse();

                throw new ValidationError("AuthenticationError", null, "Invalid username or password!");
            });
        }

        public ActionResult Signout()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            DotNetCasClient.CasAuthentication.SingleSignOut();
            return new RedirectResult("~/");
        }
    }
}