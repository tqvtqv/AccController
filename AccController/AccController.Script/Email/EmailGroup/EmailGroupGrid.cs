
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailGroup"), IdProperty("Id"), NameProperty("Alias")]
    [DialogType(typeof(EmailGroupDialog)), LocalTextPrefix("Email.EmailGroup"), Service("Email/EmailGroup")]
    public class EmailGroupGrid : EntityGrid<EmailGroupRow>
    {
        public EmailGroupGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}