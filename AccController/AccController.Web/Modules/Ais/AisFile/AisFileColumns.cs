
namespace AccController.Ais.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Ais.AisFile")]
    [BasedOnRow(typeof(Entities.AisFileRow))]
    public class AisFileColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        [EditLink]
        public String FileName { get; set; }
        public Int32 FileSize { get; set; }
        public String ContentType { get; set; }
        public String FilePath { get; set; }
        public DateTime Uploaded { get; set; }
        public String UploadedBy { get; set; }
    }
}