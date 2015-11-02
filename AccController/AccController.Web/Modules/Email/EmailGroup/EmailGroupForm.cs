
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailGroup")]
    [BasedOnRow(typeof(Entities.EmailGroupRow))]
    public class EmailGroupForm
    {
        public String Alias { get; set; }
        public String Displayname { get; set; }
        public String Ou { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    }
}