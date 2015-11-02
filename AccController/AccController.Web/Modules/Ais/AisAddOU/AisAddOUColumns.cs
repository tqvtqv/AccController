
namespace AccController.Ais.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Ais.AisAddOU")]
    [BasedOnRow(typeof(Entities.AisAddOURow))]
    public class AisAddOUColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String Email { get; set; }
        public String NewOu { get; set; }
        public String NewJobtitle { get; set; }
        public String NewRole { get; set; }
        public Int32 Priority { get; set; }
        public Int16 Status { get; set; }
        public Int16 Result { get; set; }
        public DateTime LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    }
}