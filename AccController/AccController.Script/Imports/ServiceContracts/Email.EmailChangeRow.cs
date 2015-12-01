

namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Imported, Serializable, PreserveMemberCase]
    public partial class EmailChangeRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "OldName";
        [InlineConstant] public const string LocalTextPrefix = "Email.EmailChange";
    
        public Int32? Id { get; set; }
        public String OldName { get; set; }
        public String NewName { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String By_User { get; set; }
        public String Submit { get; set; }
        public Int32? By_SubAdmin { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string OldName = "OldName";
            [InlineConstant] public const string NewName = "NewName";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
            [InlineConstant] public const string By_User = "By_User";
            [InlineConstant] public const string Submit = "Submit";
            [InlineConstant] public const string By_SubAdmin = "By_SubAdmin";
        }
    }
    
}

