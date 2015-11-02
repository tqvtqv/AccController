
namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailChangeForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailChange";
    
        public EmailChangeForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor OldName { get { return ById<StringEditor>("OldName"); } }
        public StringEditor NewName { get { return ById<StringEditor>("NewName"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

