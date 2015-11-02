
namespace AccController.Email.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Email.FileResult")]
    [BasedOnRow(typeof(Entities.FileResultRow))]
    public class FileResultColumns
    {
        [EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        public Int32 Id { get; set; }
        public Int32 FileId { get; set; }
        public Int32 ReqId { get; set; }
        public Int16 ReqType { get; set; }
    }
}