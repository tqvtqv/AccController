

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
    public partial class AisLogRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "LastUpdatedby";
        [InlineConstant] public const string LocalTextPrefix = "Ais.AisLog";
    
        public Int32? Id { get; set; }
        public Int16? LogType { get; set; }
        public Int32? ItemId { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string LogType = "LogType";
            [InlineConstant] public const string ItemId = "ItemId";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
        }
    }
    
}

