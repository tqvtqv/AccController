

namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailLogForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailLog";
    
        public EmailLogForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor LogType { get { return ById<StringEditor>("LogType"); } }
        public IntegerEditor ItemId { get { return ById<IntegerEditor>("ItemId"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

