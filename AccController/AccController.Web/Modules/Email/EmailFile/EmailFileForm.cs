
namespace AccController.Email.Forms
{
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.IO;

    [FormScript("Email.EmailFile")]
    [BasedOnRow(typeof(Entities.EmailFileRow))]
    public class EmailFileForm
    {
        public String FileName { get; set; }
        public Int32 FileSize { get; set; }
        public String ContentType { get; set; }
        public String FilePath { get; set; }
        public DateTime Uploaded { get; set; }
        public String UploadedBy { get; set; }
    }
}