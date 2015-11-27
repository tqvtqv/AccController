
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailChange")]
    [BasedOnRow(typeof(Entities.EmailChangeRow))]
    public class EmailChangeForm
    {
        public String OldName { get; set; }
        public String NewName { get; set; }
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