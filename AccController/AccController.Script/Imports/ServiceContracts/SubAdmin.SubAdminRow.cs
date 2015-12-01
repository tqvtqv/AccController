

namespace AccController.SubAdmin
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Imported, Serializable, PreserveMemberCase]
    public partial class SubAdminRow
    {
        [InlineConstant] public const string IdProperty = "AdminLv";
        [InlineConstant] public const string NameProperty = "Name";
        [InlineConstant] public const string LocalTextPrefix = "SubAdmin.SubAdmin";
        [InlineConstant] public const string LookupKey = "SubAdmin.SubAdmin";
    
        public static Lookup<SubAdminRow> Lookup { [InlineCode("Q.getLookup('SubAdmin.SubAdmin')")] get { return null; } }
    
        public Int32? AdminLv { get; set; }
        public String Name { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string AdminLv = "AdminLv";
            [InlineConstant] public const string Name = "Name";
        }
    }
    
}

