
namespace AccController.Email
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class EmailUpdateInfoForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Email.EmailUpdateInfo";
    
        public EmailUpdateInfoForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Account { get { return ById<StringEditor>("Account"); } }
        public StringEditor Name { get { return ById<StringEditor>("Name"); } }
        public StringEditor JobTitle { get { return ById<StringEditor>("JobTitle"); } }
        public StringEditor Department { get { return ById<StringEditor>("Department"); } }
        public StringEditor Company { get { return ById<StringEditor>("Company"); } }
        public StringEditor Phone { get { return ById<StringEditor>("Phone"); } }
        public StringEditor Mobile { get { return ById<StringEditor>("Mobile"); } }
        public StringEditor Birthday { get { return ById<StringEditor>("Birthday"); } }
        public StringEditor Ou { get { return ById<StringEditor>("Ou"); } }
        public StringEditor Status { get { return ById<StringEditor>("Status"); } }
        public StringEditor Result { get { return ById<StringEditor>("Result"); } }
        public DateEditor LastUpdated { get { return ById<DateEditor>("LastUpdated"); } }
        public StringEditor LastUpdatedby { get { return ById<StringEditor>("LastUpdatedby"); } }
        public StringEditor Description { get { return ById<StringEditor>("Description"); } }
    }
}

