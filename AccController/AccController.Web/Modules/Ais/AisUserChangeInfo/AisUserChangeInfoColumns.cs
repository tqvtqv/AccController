
namespace AccController.Ais.Columns
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [ColumnsScript("Ais.AisUserChangeInfo")]
    [BasedOnRow(typeof(Entities.AisUserChangeInfoRow))]
    public class AisUserChangeInfoColumns
    {
        //[EditLink, DisplayName("Db.Shared.RecordId"), AlignRight]
        //public Int32 Id { get; set; }
        [EditLink]
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Jobtitle { get; set; }
        //public Int16 Status { get; set; }
        //public Int16 Result { get; set; }
        //public DateTime LastUpdated { get; set; }
        //public String LastUpdatedby { get; set; }
        //public String Description { get; set; }
    }
}