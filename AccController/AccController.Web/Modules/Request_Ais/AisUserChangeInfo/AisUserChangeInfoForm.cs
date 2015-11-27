
namespace AccController.Request_Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Request_Ais.AisUserChangeInfo")]
    [BasedOnRow(typeof(Entities.AisUserChangeInfoRow))]
    public class AisUserChangeInfoForm
    {
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Jobtitle { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String ByUser { get; set; }
        public String Submit { get; set; }
    }
}