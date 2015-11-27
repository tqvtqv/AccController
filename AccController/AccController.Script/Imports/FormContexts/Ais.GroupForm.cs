

namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class GroupForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Ais.Group";
    
        public GroupForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Name { get { return ById<StringEditor>("Name"); } }
        public StringEditor Parent { get { return ById<StringEditor>("Parent"); } }
        public StringEditor Category { get { return ById<StringEditor>("Category"); } }
        public StringEditor Shortname { get { return ById<StringEditor>("Shortname"); } }
        public StringEditor Relate { get { return ById<StringEditor>("Relate"); } }
        public StringEditor Priority { get { return ById<StringEditor>("Priority"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public TextAreaEditor Description { get { return ById<TextAreaEditor>("Description"); } }
    }
}

