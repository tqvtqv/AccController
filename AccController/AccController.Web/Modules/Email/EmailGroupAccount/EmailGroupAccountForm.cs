
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
        public String Alias { get; set; }
        public String Account { get; set; }
        [ReadOnly(true)]
        public Int16 Status { get; set; }
        [ReadOnly(true)]
        public Int16 Result { get; set; }
        [ReadOnly(true)]
        public DateTime LastUpdated { get; set; }
        [ReadOnly(true)]
        public String LastUpdatedby { get; set; }
        [ReadOnly(true)]
        public String Description { get; set; }
    }
}