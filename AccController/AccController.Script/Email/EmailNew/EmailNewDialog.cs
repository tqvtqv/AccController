
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Name")]
    [FormKey("Email.EmailNew"), LocalTextPrefix("Email.EmailNew"), Service("Email/EmailNew")]
    public class EmailNewDialog : EntityDialog<EmailNewRow>
    {
    }
}