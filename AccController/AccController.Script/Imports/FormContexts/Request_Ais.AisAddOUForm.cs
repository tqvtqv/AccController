

namespace AccController.Request_Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class AisAddOUForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Request_Ais.AisAddOU";
    
        public AisAddOUForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Email { get { return ById<StringEditor>("Email"); } }
        public StringEditor NewOu { get { return ById<StringEditor>("NewOu"); } }
        public StringEditor NewJobtitle { get { return ById<StringEditor>("NewJobtitle"); } }
        public StringEditor NewRole { get { return ById<StringEditor>("NewRole"); } }
        public IntegerEditor Priority { get { return ById<IntegerEditor>("Priority"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
        public StringEditor ByUser { get { return ById<StringEditor>("ByUser"); } }
        public StringEditor Submit { get { return ById<StringEditor>("Submit"); } }
    }
}

