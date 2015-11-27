

namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailGroupForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailGroup";
    
        public EmailGroupForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Alias { get { return ById<StringEditor>("Alias"); } }
        public StringEditor Displayname { get { return ById<StringEditor>("Displayname"); } }
        public StringEditor Ou { get { return ById<StringEditor>("Ou"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

