
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Account")]
    [FormKey("Email.EmailGroupAccount"), LocalTextPrefix("Email.EmailGroupAccount"), Service("Email/EmailGroupAccount")]
    public class EmailGroupAccountDialog : EntityDialog<EmailGroupAccountRow>
    {
    }
}