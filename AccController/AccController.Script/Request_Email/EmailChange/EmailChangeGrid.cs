
namespace AccController.Request_Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Request_Email.EmailChange"), IdProperty(EmailChangeRow.IdProperty), NameProperty(EmailChangeRow.NameProperty)]
    [DialogType(typeof(EmailChangeDialog)), LocalTextPrefix(EmailChangeRow.LocalTextPrefix), Service(EmailChangeService.BaseUrl)]
    public class EmailChangeGrid : EntityGrid<EmailChangeRow>
    {
        public EmailChangeGrid(jQueryObject container)
            : base(container)
        {
        }
    }
}