
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailGroupAccount")]
    [BasedOnRow(typeof(Entities.EmailGroupAccountRow))]
    public class EmailGroupAccountForm
    {
        public Int32 GroupId { get; set; }
        public String Account { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    }
}