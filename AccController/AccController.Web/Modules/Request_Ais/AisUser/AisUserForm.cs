
namespace AccController.Request_Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Request_Ais.AisUser")]
    [BasedOnRow(typeof(Entities.AisUserRow))]
    public class AisUserForm
    {
        public String Name { get; set; }
        public String Ou { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Jobtitle { get; set; }
        public String Role { get; set; }
        public Int32 Priority { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String ByUser { get; set; }
        public String Submit { get; set; }
    }
}