
namespace AccController.Request_Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    [Imported, Serializable, PreserveMemberCase]
    public partial class AisUserChangeOURow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "Email";
        [InlineConstant] public const string LocalTextPrefix = "Request_Ais.AisUserChangeOU";
    
        public Int32? Id { get; set; }
        public String Email { get; set; }
        public String OldOu { get; set; }
        public String NewOu { get; set; }
        public String NewJobtitle { get; set; }
        public String NewRole { get; set; }
        public Int32? Priority { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String ByUser { get; set; }
        public String Submit { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string Email = "Email";
            [InlineConstant] public const string OldOu = "OldOu";
            [InlineConstant] public const string NewOu = "NewOu";
            [InlineConstant] public const string NewJobtitle = "NewJobtitle";
            [InlineConstant] public const string NewRole = "NewRole";
            [InlineConstant] public const string Priority = "Priority";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
            [InlineConstant] public const string ByUser = "ByUser";
            [InlineConstant] public const string Submit = "Submit";
        }
    }
    
}

