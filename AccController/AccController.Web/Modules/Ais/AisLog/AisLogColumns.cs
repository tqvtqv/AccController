﻿
namespace AccController.Ais.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Ais.AisLog")]
    [BasedOnRow(typeof(Entities.AisLogRow))]
    public class AisLogColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int16 LogType { get; set; }
        public Int32 ItemId { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        [EditLink]
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    }
}