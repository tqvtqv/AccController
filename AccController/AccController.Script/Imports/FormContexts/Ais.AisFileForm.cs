

namespace AccController.Ais
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class AisFileForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Ais.AisFile";
    
        public AisFileForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor FileName { get { return ById<StringEditor>("FileName"); } }
        public IntegerEditor FileSize { get { return ById<IntegerEditor>("FileSize"); } }
        public StringEditor ContentType { get { return ById<StringEditor>("ContentType"); } }
        public StringEditor FilePath { get { return ById<StringEditor>("FilePath"); } }
        public DateEditor Uploaded { get { return ById<DateEditor>("Uploaded"); } }
        public StringEditor UploadedBy { get { return ById<StringEditor>("UploadedBy"); } }
    }
}

