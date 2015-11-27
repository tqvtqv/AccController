
namespace AccController.Email.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Email.EmailUpdateInfo")]
    [BasedOnRow(typeof(Entities.EmailUpdateInfoRow))]
    public class EmailUpdateInfoColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }
        [EditLink]
        public String Account { get; set; }
        public String Name { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public Stream Birthday { get; set; }
        public String Ou { get; set; }
        //public Int16 Status { get; set; }
        //public Int16 Result { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public String LastUpdatedby { get; set; }
        //public String Description { get; set; }
    }
}