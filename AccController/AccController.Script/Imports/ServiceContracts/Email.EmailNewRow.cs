
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
    public partial class EmailNewRow
    {
        [InlineConstant] public const string IdProperty = "Id";
        [InlineConstant] public const string NameProperty = "Name";
        [InlineConstant] public const string LocalTextPrefix = "Email.EmailNew";
    
        public Int32? Id { get; set; }
        public String Name { get; set; }
        public String Alias { get; set; }
        public String Password { get; set; }
        public String Displayname { get; set; }
        public String Firstname { get; set; }
        public String Lastname { get; set; }
        public String JobTitle { get; set; }
        public String Department { get; set; }
        public String Company { get; set; }
        public String Phone { get; set; }
        public String Mobile { get; set; }
        public String Birthday { get; set; }
        public String Ou { get; set; }
        public String UserPrincipal { get; set; }
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
            [InlineConstant] public const string Name = "Name";
            [InlineConstant] public const string Alias = "Alias";
            [InlineConstant] public const string Password = "Password";
            [InlineConstant] public const string Displayname = "Displayname";
            [InlineConstant] public const string Firstname = "Firstname";
            [InlineConstant] public const string Lastname = "Lastname";
            [InlineConstant] public const string JobTitle = "JobTitle";
            [InlineConstant] public const string Department = "Department";
            [InlineConstant] public const string Company = "Company";
            [InlineConstant] public const string Phone = "Phone";
            [InlineConstant] public const string Mobile = "Mobile";
            [InlineConstant] public const string Birthday = "Birthday";
            [InlineConstant] public const string Ou = "Ou";
            [InlineConstant] public const string UserPrincipal = "UserPrincipal";
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

