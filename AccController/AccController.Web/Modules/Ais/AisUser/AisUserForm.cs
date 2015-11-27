
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.AisUser")]
    [BasedOnRow(typeof(Entities.AisUserRow))]
    public class AisUserForm
    {
        public String Name { get; set; }
        public String Ou { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Jobtitle { get; set; }
        public String Role { get; set; }
        public Int32 Priority { get; set; }
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