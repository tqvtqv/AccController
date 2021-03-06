﻿
namespace AccController.Request_Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Request_Ais.AisUserChangeOU")]
    [BasedOnRow(typeof(Entities.AisUserChangeOURow))]
    public class AisUserChangeOUForm
    {
        public String Email { get; set; }
        public String OldOu { get; set; }
        public String NewOu { get; set; }
        public String NewJobtitle { get; set; }
        public String NewRole { get; set; }
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