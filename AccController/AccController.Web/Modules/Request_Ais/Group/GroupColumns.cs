
namespace AccController.Request_Ais.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Request_Ais.Group")]
    [BasedOnRow(typeof(Entities.GroupRow))]
    public class GroupColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }
        [EditLink]
        public String Name { get; set; }
        public String Parent { get; set; }
        public String Category { get; set; }
        public String Shortname { get; set; }
        public String Relate { get; set; }
        public Int16 Priority { get; set; }
        //public Int16 Status { get; set; }
        //public Int16 Result { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public String LastUpdatedby { get; set; }
        //public String Description { get; set; }
        //public Int32 IdRequest { get; set; }
        //public String ByUser { get; set; }
        //public String Submit { get; set; }
    }
}