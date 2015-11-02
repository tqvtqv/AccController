
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Account")]
    [FormKey("Email.EmailUpdateInfo"), LocalTextPrefix("Email.EmailUpdateInfo"), Service("Email/EmailUpdateInfo")]
    public class EmailUpdateInfoDialog : EntityDialog<EmailUpdateInfoRow>
    {
    }
}