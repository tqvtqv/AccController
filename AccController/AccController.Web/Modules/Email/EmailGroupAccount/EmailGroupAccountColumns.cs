
namespace AccController.Email.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Email.EmailGroupAccount")]
    [BasedOnRow(typeof(Entities.EmailGroupAccountRow))]
    public class EmailGroupAccountColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }
        [EditLink]
        public String Alias { get; set; }
        public String Account { get; set; }
        //public Int16 Status { get; set; }
        //public Int16 Result { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public String LastUpdatedby { get; set; }
        //public String Description { get; set; }
    }
}