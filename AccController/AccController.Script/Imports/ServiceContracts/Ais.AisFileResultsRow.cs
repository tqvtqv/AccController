

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
    public partial class AisFileResultsRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string LocalTextPrefix = "Ais.AisFileResults";
    
        public Int32? Id { get; set; }
        public Int32? FileId { get; set; }
        public Int32? ReqId { get; set; }
        public Int16? ReqType { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string FileId = "FileId";
            [InlineConstant] public const string ReqId = "ReqId";
            [InlineConstant] public const string ReqType = "ReqType";
        }
    }
    
}

