
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("LastUpdatedby")]
    [FormKey("Email.EmailLog"), LocalTextPrefix("Email.EmailLog"), Service("Email/EmailLog")]
    public class EmailLogDialog : EntityDialog<EmailLogRow>
    {
    }
}