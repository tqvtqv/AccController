
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailLog"), IdProperty("Id"), NameProperty("LastUpdatedby")]
    [DialogType(typeof(EmailLogDialog)), LocalTextPrefix("Email.EmailLog"), Service("Email/EmailLog")]
    public class EmailLogGrid : EntityGrid<EmailLogRow>
    {
        public EmailLogGrid(jQueryObject container)
            : base(container)
        {
        }
    }
    
}