
namespace AccController.SubAdmin.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("SubAdmin.SubAdmin")]
    [BasedOnRow(typeof(Entities.SubAdminRow))]
    public class SubAdminColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 AdminLv { get; set; }
        [EditLink]
        public String Name { get; set; }
    }
}