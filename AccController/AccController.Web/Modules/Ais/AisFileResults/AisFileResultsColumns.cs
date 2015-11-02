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

    [ColumnsScript("Ais.AisFileResults")]
    [BasedOnRow(typeof(Entities.AisFileResultsRow))]
    public class AisFileResultsColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int32 FileId { get; set; }
        public Int32 ReqId { get; set; }
        public Int16 ReqType { get; set; }
    }
}