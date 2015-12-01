
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
    public partial class EmailGroupRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "Alias";
        [InlineConstant] public const string LocalTextPrefix = "Email.EmailGroup";
        [InlineConstant] public const string LookupKey = "Email.EmailGroup";
    
        public static Lookup<EmailGroupRow> Lookup { [InlineCode("Q.getLookup('Email.EmailGroup')")] get { return null; } }
    
        public Int32? Id { get; set; }
        public String Alias { get; set; }
        public String Displayname { get; set; }
        public String Ou { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String By_User { get; set; }
        public String Submit { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string Alias = "Alias";
            [InlineConstant] public const string Displayname = "Displayname";
            [InlineConstant] public const string Ou = "Ou";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
            [InlineConstant] public const string By_User = "By_User";
            [InlineConstant] public const string Submit = "Submit";
        }
    }
    
}

