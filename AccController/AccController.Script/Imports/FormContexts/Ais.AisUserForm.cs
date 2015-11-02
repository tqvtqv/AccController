
namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class AisUserForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Ais.AisUser";
    
        public AisUserForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Ou { get { return ById<StringEditor>("Ou"); } }
        public StringEditor Email { get { return ById<StringEditor>("Email"); } }
        public StringEditor Phone { get { return ById<StringEditor>("Phone"); } }
        public StringEditor Mobile { get { return ById<StringEditor>("Mobile"); } }
        public StringEditor Jobtitle { get { return ById<StringEditor>("Jobtitle"); } }
        public StringEditor Role { get { return ById<StringEditor>("Role"); } }
        public IntegerEditor Priority { get { return ById<IntegerEditor>("Priority"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

