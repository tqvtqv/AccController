

namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailGroupAccountForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailGroupAccount";
    
        public EmailGroupAccountForm(string idPrefix) : base(idPrefix) {}
    
        public LookupEditor GroupId { get { return ById<LookupEditor>("GroupId"); } }
        public StringEditor Account { get { return ById<StringEditor>("Account"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

