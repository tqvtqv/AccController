
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
    public partial class EmailGroupAccountRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "Account";
        [InlineConstant] public const string LocalTextPrefix = "Email.EmailGroupAccount";
    
        public Int32? Id { get; set; }
        public String Alias { get; set; }
        public String Account { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String GroupAlias { get; set; }
        public String GroupDisplayname { get; set; }
        public String GroupOu { get; set; }
        public Int16? GroupStatus { get; set; }
        public Int16? GroupResult { get; set; }
        public String GroupLastUpdated { get; set; }
        public String GroupLastUpdatedby { get; set; }
        public String GroupDescription { get; set; }
        public String By_User { get; set; }
        public String Submit { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string Alias = "Alias";
            [InlineConstant] public const string Account = "Account";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
            [InlineConstant] public const string GroupAlias = "GroupAlias";
            [InlineConstant] public const string GroupDisplayname = "GroupDisplayname";
            [InlineConstant] public const string GroupOu = "GroupOu";
            [InlineConstant] public const string GroupStatus = "GroupStatus";
            [InlineConstant] public const string GroupResult = "GroupResult";
            [InlineConstant] public const string GroupLastUpdated = "GroupLastUpdated";
            [InlineConstant] public const string GroupLastUpdatedby = "GroupLastUpdatedby";
            [InlineConstant] public const string GroupDescription = "GroupDescription";
            [InlineConstant] public const string By_User = "By_User";
            [InlineConstant] public const string Submit = "Submit";
        }
    }
    
}

