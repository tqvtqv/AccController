﻿
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.AisUserChangeOU")]
    [BasedOnRow(typeof(Entities.AisUserChangeOURow))]
    public class AisUserChangeOUForm
    {
        public String Email { get; set; }
        public String OldOu { get; set; }
        public String OldJobtitle { get; set; }
        public String OldRole { get; set; }
        public String NewOu { get; set; }
        public String NewJobtitle { get; set; }
        public String NewRole { get; set; }
        public Int32 Priority { get; set; }
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