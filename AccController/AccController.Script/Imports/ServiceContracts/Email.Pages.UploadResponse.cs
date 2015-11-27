
namespace AccController.Email.Pages
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Imported, Serializable, PreserveMemberCase]
    public partial class UploadResponse : ServiceResponse
    {
        public String TemporaryFile { get; set; }
        public Int64 Size { get; set; }
        public Boolean IsImage { get; set; }
        public Int32 Width { get; set; }
        public Int32 Height { get; set; }
        public String ContenType { get; set; }
        public EmailFileRow UploadedFile { get; set; }
    }
    
}

