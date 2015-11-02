
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("FileName")]
    [FormKey("Email.EmailFile"), LocalTextPrefix("Email.EmailFile"), Service("Email/EmailFile")]
    public class EmailFileDialog : EntityDialog<EmailFileRow>
    {
    }
}