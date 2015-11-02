
namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class FileResultForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.FileResult";
    
        public FileResultForm(string idPrefix) : base(idPrefix) {}
    
        public IntegerEditor FileId { get { return ById<IntegerEditor>("FileId"); } }
        public IntegerEditor ReqId { get { return ById<IntegerEditor>("ReqId"); } }
        public StringEditor ReqType { get { return ById<StringEditor>("ReqType"); } }
    }
}

