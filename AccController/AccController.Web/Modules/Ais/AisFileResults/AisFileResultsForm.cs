
namespace AccController.Ais.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Ais.AisFileResults")]
    [BasedOnRow(typeof(Entities.AisFileResultsRow))]
    public class AisFileResultsForm
    {
        public Int32 FileId { get; set; }
        public Int32 ReqId { get; set; }
        public Int16 ReqType { get; set; }
    }
}