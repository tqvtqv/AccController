
namespace AccController.Request_Email
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(EmailGroupRow.IdProperty), NameProperty(EmailGroupRow.NameProperty)]
    [FormKey("Request_Email.EmailGroup"), LocalTextPrefix(EmailGroupRow.LocalTextPrefix), Service(EmailGroupService.BaseUrl)]
    public class EmailGroupDialog : EntityDialog<EmailGroupRow>
    {
        protected EmailGroupForm form;

        public EmailGroupDialog()
        {
            form = new EmailGroupForm(this.IdPrefix);
        }
    }
}