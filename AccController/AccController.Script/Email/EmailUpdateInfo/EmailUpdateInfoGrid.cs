
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailUpdateInfo"), IdProperty("Id"), NameProperty("Account")]
    [DialogType(typeof(EmailUpdateInfoDialog)), LocalTextPrefix("Email.EmailUpdateInfo"), Service("Email/EmailUpdateInfo")]
    public class EmailUpdateInfoGrid : EntityGrid<EmailUpdateInfoRow>
    {
        public EmailUpdateInfoGrid(jQueryObject container)
            : base(container)
        {
        }
    }
    
}