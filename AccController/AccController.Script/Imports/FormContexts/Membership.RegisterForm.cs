
namespace AccController.Membership
{
    using Serenity;
    using Serenity.ComponentModel;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public partial class RegisterForm : PrefixedContext
    {
        [InlineConstant] public const string FormKey = "Membership.Register";
    
        public RegisterForm(string idPrefix) : base(idPrefix) {}
    
        public StringEditor Username { get { return ById<StringEditor>("Username"); } }
        public PasswordEditor Password { get { return ById<PasswordEditor>("Password"); } }
        public EmailEditor Email { get { return ById<EmailEditor>("Email"); } }
    }
}

