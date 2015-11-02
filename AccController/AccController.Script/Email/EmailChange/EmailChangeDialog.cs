
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("OldName")]
    [FormKey("Email.EmailChange"), LocalTextPrefix("Email.EmailChange"), Service("Email/EmailChange")]
    public class EmailChangeDialog : EntityDialog<EmailChangeRow>
    {
    }
}