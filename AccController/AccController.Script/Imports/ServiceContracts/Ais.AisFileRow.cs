
namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Imported, Serializable, PreserveMemberCase]
    public partial class AisFileRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "FileName";
        [InlineConstant] public const string LocalTextPrefix = "Ais.AisFile";
    
        public Int32? Id { get; set; }
        public String FileName { get; set; }
        public Int32? FileSize { get; set; }
        public String ContentType { get; set; }
        public String FilePath { get; set; }
        public String Uploaded { get; set; }
        public String UploadedBy { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string FileName = "FileName";
            [InlineConstant] public const string FileSize = "FileSize";
            [InlineConstant] public const string ContentType = "ContentType";
            [InlineConstant] public const string FilePath = "FilePath";
            [InlineConstant] public const string Uploaded = "Uploaded";
            [InlineConstant] public const string UploadedBy = "UploadedBy";
        }
    }
    
}

