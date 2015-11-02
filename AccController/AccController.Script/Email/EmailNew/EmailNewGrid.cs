
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailNew"), IdProperty("Id"), NameProperty("Name")]
    [DialogType(typeof(EmailNewDialog)), LocalTextPrefix("Email.EmailNew"), Service("Email/EmailNew")]
    public class EmailNewGrid : EntityGrid<EmailNewRow>
    {
        public EmailNewGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}