
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailGroupAccount"), IdProperty("Id"), NameProperty("Account")]
    [DialogType(typeof(EmailGroupAccountDialog)), LocalTextPrefix("Email.EmailGroupAccount"), Service("Email/EmailGroupAccount")]
    public class EmailGroupAccountGrid : EntityGrid<EmailGroupAccountRow>
    {
        public EmailGroupAccountGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}