

namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class AisFileResultsForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Ais.AisFileResults";
    
        public AisFileResultsForm(string idPrefix) : base(idPrefix) {}
    
        public IntegerEditor FileId { get { return ById<IntegerEditor>("FileId"); } }
        public IntegerEditor ReqId { get { return ById<IntegerEditor>("ReqId"); } }
        public StringEditor ReqType { get { return ById<StringEditor>("ReqType"); } }
    }
}

