
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Alias")]
    [FormKey("Email.EmailGroup"), LocalTextPrefix("Email.EmailGroup"), Service("Email/EmailGroup")]
    public class EmailGroupDialog : EntityDialog<EmailGroupRow>
    {
    }
}