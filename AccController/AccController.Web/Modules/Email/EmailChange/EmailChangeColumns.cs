
namespace AccController.Email.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Email.EmailChange")]
    [BasedOnRow(typeof(Entities.EmailChangeRow))]
    public class EmailChangeColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
       // public Int32 Id { get; set; }
        [EditLink]
        public String OldName { get; set; }
        public String NewName { get; set; }
        //public Int16 Status { get; set; }
        //public Int16 Result { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public String LastUpdatedby { get; set; }
        //public String Description { get; set; }
    }
}