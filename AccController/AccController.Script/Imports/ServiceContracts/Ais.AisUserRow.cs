

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
    public partial class AisUserRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "Ou";
        [InlineConstant] public const string LocalTextPrefix = "Ais.AisUser";
    
        public Int32? Id { get; set; }
        public String Ou { get; set; }
        public String Email { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Jobtitle { get; set; }
        public String Role { get; set; }
        public Int32? Priority { get; set; }
        public Int16? Status { get; set; }
        public Int16? Result { get; set; }
        public String LastUpdated { get; set; }
        public String LastUpdatedby { get; set; }
        public String Description { get; set; }
        public String Name { get; set; }
        public String By_User { get; set; }
        public String Submit { get; set; }
    
        [Imported, PreserveMemberCase]
        public static class Fields
        {
            [InlineConstant] public const string Id = "Id";
            [InlineConstant] public const string Ou = "Ou";
            [InlineConstant] public const string Email = "Email";
            [InlineConstant] public const string Phone = "Phone";
            [InlineConstant] public const string Mobile = "Mobile";
            [InlineConstant] public const string Jobtitle = "Jobtitle";
            [InlineConstant] public const string Role = "Role";
            [InlineConstant] public const string Priority = "Priority";
            [InlineConstant] public const string Status = "Status";
            [InlineConstant] public const string Result = "Result";
            [InlineConstant] public const string LastUpdated = "LastUpdated";
            [InlineConstant] public const string LastUpdatedby = "LastUpdatedby";
            [InlineConstant] public const string Description = "Description";
            [InlineConstant] public const string Name = "Name";
            [InlineConstant] public const string By_User = "By_User";
            [InlineConstant] public const string Submit = "Submit";
        }
    }
    
}

