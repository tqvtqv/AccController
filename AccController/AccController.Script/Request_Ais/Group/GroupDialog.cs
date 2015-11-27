
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(GroupRow.IdProperty), NameProperty(GroupRow.NameProperty)]
    [FormKey("Request_Ais.Group"), LocalTextPrefix(GroupRow.LocalTextPrefix), Service(GroupService.BaseUrl)]
    public class GroupDialog : EntityDialog<GroupRow>
    {
        protected GroupForm form;

        public GroupDialog()
        {
            form = new GroupForm(this.IdPrefix);
        }
    }
}