
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.FileResult"), IdProperty("Id")]
    [DialogType(typeof(FileResultDialog)), LocalTextPrefix("Email.FileResult"), Service("Email/FileResult")]
    public class FileResultGrid : EntityGrid<FileResultRow>
    {
        public FileResultGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}