
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailFile"), IdProperty("Id"), NameProperty("FileName")]
    [DialogType(typeof(EmailFileDialog)), LocalTextPrefix("Email.EmailFile"), Service("Email/EmailFile")]
    public class EmailFileGrid : EntityGrid<EmailFileRow>
    {
        public EmailFileGrid(jQueryObject container)
            : base(container)
        {
        }
    }
    
}