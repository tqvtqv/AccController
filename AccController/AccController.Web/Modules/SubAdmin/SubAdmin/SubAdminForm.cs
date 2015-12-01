
namespace AccController.SubAdmin.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("SubAdmin.SubAdmin")]
    [BasedOnRow(typeof(Entities.SubAdminRow))]
    public class SubAdminForm
    {
        public String Name { get; set; }
    }
}