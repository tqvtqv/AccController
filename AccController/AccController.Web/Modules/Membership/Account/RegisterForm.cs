
namespace AccController.Membership.Forms
{
    using System;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using System.Collections.Generic;
    using System.ComponentModel;

    [FormScript("Membership.Register")]
    [BasedOnRow(typeof(Administration.Entities.UserRow))]
    public class RegisterForm
    {
        [Placeholder("default username is 'admin'")]
        public String Username { get; set; }
        [PasswordEditor, Placeholder("default password for admin user is 'serenity'"), Required(true)]
        public String Password { get; set; }
        [EmailEditor(Domain = "vnpt.vn"), Placeholder("Enter your email here!"), Required(true)]
        public String Email { get; set; }
    }
}