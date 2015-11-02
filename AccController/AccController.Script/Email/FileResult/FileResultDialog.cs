
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id")]
    [FormKey("Email.FileResult"), LocalTextPrefix("Email.FileResult"), Service("Email/FileResult")]
    public class FileResultDialog : EntityDialog<FileResultRow>
    {
    }
}