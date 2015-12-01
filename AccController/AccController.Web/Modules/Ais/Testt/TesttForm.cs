
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.Testt")]
    [BasedOnRow(typeof(Entities.TesttRow))]
    public class TesttForm
    {
        public String Name { get; set; }
    }
}