
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailChange"), IdProperty("Id"), NameProperty("OldName")]
    [DialogType(typeof(EmailChangeDialog)), LocalTextPrefix("Email.EmailChange"), Service("Email/EmailChange")]
    public class EmailChangeGrid : EntityGrid<EmailChangeRow>
    {
        public EmailChangeGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}