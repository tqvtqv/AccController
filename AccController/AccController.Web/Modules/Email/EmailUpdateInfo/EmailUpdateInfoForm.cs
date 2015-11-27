
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailUpdateInfo")]
    [BasedOnRow(typeof(Entities.EmailUpdateInfoRow))]
    public class EmailUpdateInfoForm
    {
        public String Account { get; set; }
        public String Name { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public String Ou { get; set; }
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