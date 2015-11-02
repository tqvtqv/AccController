
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.AisLog")]
    [BasedOnRow(typeof(Entities.AisLogRow))]
    public class AisLogForm
    {
        public Int16 LogType { get; set; }
        public Int32 ItemId { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    }
}