
namespace AccController.Membership
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Html;

    [Panel, FormKey("Membership.Register")]
    public class RegisterPanel : PropertyDialog<object>
    {
        public RegisterPanel()
        {
            this.ById("RegisterButton").Click((s, e) =>
            {
                e.PreventDefault();

                if (!ValidateForm())
                    return;

                var request = GetSaveEntity();
                Q.ServiceCall(new ServiceCallOptions
                {
                    Url = Q.ResolveUrl("~/Account/Register"),
                    Request = request.As<ServiceRequest>(),
                    OnSuccess = response =>
                    {
                        Window.Location.Href = Q.ResolveUrl("~/");
                    }
                });

            });

        }
    }
}