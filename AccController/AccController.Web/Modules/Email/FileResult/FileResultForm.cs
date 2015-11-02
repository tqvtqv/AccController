
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.FileResult")]
    [BasedOnRow(typeof(Entities.FileResultRow))]
    public class FileResultForm
    {
        public Int32 FileId { get; set; }
        public Int32 ReqId { get; set; }
        public Int16 ReqType { get; set; }
    }
}