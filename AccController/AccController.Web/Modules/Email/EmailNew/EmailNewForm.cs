
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailNew")]
    [BasedOnRow(typeof(Entities.EmailNewRow))]
    public class EmailNewForm
    {
        public String Name { get; set; }
        public String Alias { get; set; }
        //public String Password { get; set; }
        public String Displayname { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public String Ou { get; set; }
        public String UserPrincipal { get; set; }
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