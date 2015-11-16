
namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailNewForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailNew";
    
        public EmailNewForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Name { get { return ById<StringEditor>("Name"); } }
        public StringEditor Alias { get { return ById<StringEditor>("Alias"); } }
        public StringEditor Password { get { return ById<StringEditor>("Password"); } }
        public StringEditor Displayname { get { return ById<StringEditor>("Displayname"); } }
        public StringEditor Firstname { get { return ById<StringEditor>("Firstname"); } }
        public StringEditor Lastname { get { return ById<StringEditor>("Lastname"); } }
        public StringEditor JobTitle { get { return ById<StringEditor>("JobTitle"); } }
        public StringEditor Department { get { return ById<StringEditor>("Department"); } }
        public StringEditor Company { get { return ById<StringEditor>("Company"); } }
        public StringEditor Phone { get { return ById<StringEditor>("Phone"); } }
        public StringEditor Mobile { get { return ById<StringEditor>("Mobile"); } }
        public DateEditor Birthday { get { return ById<DateEditor>("Birthday"); } }
        public StringEditor Ou { get { return ById<StringEditor>("Ou"); } }
        public StringEditor UserPrincipal { get { return ById<StringEditor>("UserPrincipal"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

