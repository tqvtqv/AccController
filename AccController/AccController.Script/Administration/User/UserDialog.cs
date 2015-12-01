
namespace AccController.Administration
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("UserId"), NameProperty("Username"), IsActiveProperty("IsActive")]
    [FormKey("Administration.User"), LocalTextPrefix("Administration.User"), Service("Administration/User")]
    public class UserDialog : EntityDialog<UserRow>
    {
        static string user_name = "";
        static int i_refresh = 1;
        static string admin_lv = "1";
        private UserForm form;

        public UserDialog()
        {

            var request = new ServiceRequest();

            Q.ServiceCall(new ServiceCallOptions
            {
                Url = Q.ResolveUrl("~/Administration/User/getUser"),

                Request = request.As<ServiceRequest>(),
                OnSuccess = response =>
                {
                    dynamic obj = response;
                    UserRow t = (UserRow)obj;
                    user_name = t.Username;
                    admin_lv = obj.adminlv;
                    //Q.Log("user_name:  " + user_name + "  admin_lv:" + admin_lv);
                    if (i_refresh == 1)
                    {
                        
                        i_refresh = 0;
                        this.ReloadById();
                    }
                }
            });

            form = new UserForm(this.IdPrefix);

            form.Password.AddValidationRule(this.uniqueName, e =>
            {
                if (form.Password.Value.Length < 7)
                    return "Password must be at least 7 characters!";

                return null;
            });

            form.PasswordConfirm.AddValidationRule(this.uniqueName, e =>
            {
                if (form.Password.Value != form.PasswordConfirm.Value)
                    return "The passwords entered doesn't match!";

                return null;
            });
        }

        protected override List<ToolButton> GetToolbarButtons()
        {
            var buttons = base.GetToolbarButtons();

            buttons.Add(new ToolButton
            {
                Title = Q.Text("Site.UserDialog.EditRolesButton"),
                CssClass = "users-button",
                OnClick = delegate
                {
                    new UserRoleDialog(new UserRoleDialogOptions
                    {
                        UserID = this.Entity.UserId.Value,
                        Username = this.Entity.Username,
                    }).DialogOpen();
                }
            });

            buttons.Add(new ToolButton
            {
                Title = Q.Text("Site.UserDialog.EditPermissionsButton"),
                CssClass = "lock-button",
                OnClick = delegate
                {
                    new UserPermissionDialog(new UserPermissionDialogOptions
                    {
                        UserID = this.Entity.UserId.Value,
                        Username = this.Entity.Username,
                    }).DialogOpen();
                }
            });

            if (admin_lv == "1")
                buttons.Add(new ToolButton
                {
                    Title = "Super Admin",
                    CssClass = "users-button",
                    OnClick = delegate
                    {
                        Q.Confirm("Cấp quyền Super Admin?", () =>
                            {
                                var request = new SaveRequest<UserRow>();
                                request.Entity = this.Entity;
                                UserService.updateuser(request, s =>
                                {

                                    this.ReloadById();

                                    this.DialogClose();
                                    //Q.NotifyInfo("ok");
                                });
                            });
                 
                    }
                });

          


            return buttons;
        }

        protected override void UpdateInterface()
        {
            base.UpdateInterface();

            toolbar.FindButton("users-button").ToggleClass("disabled", this.IsNewOrDeleted);
            toolbar.FindButton("lock-button").ToggleClass("disabled", this.IsNewOrDeleted);
        }
    }
}