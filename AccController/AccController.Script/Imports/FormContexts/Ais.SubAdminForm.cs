
namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class SubAdminForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Ais.SubAdmin";

        public SubAdminForm(string idPrefix) : base(idPrefix) {}


        public StringEditor Name { get { return ById<StringEditor>("Name"); } }
    }
}