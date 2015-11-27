
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(AisUserRow.IdProperty), NameProperty(AisUserRow.NameProperty)]
    [FormKey("Request_Ais.AisUser"), LocalTextPrefix(AisUserRow.LocalTextPrefix), Service(AisUserService.BaseUrl)]
    public class AisUserDialog : EntityDialog<AisUserRow>
    {
        protected AisUserForm form;

        public AisUserDialog()
        {
            form = new AisUserForm(this.IdPrefix);
        }
    }
}