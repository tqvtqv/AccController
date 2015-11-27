
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.Group")]
    [BasedOnRow(typeof(Entities.GroupRow))]
    public class GroupForm
    {
        public String Name { get; set; }
        public String Parent { get; set; }
        public String Category { get; set; }
        public String Shortname { get; set; }
        public String Relate { get; set; }
        public Int16 Priority { get; set; }
        [ReadOnly(true)]
        public Int16 Status { get; set; }
        [ReadOnly(true)]
        public Int16 Result { get; set; }
        [ReadOnly(true)]
        public DateTime LastUpdated { get; set; }
        [ReadOnly(true)]
        public String LastUpdatedby { get; set; }
        [ReadOnly(true)]
        public String Description { get; set; }
    }
}