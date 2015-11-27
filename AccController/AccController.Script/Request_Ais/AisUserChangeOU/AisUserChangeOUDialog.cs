
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(AisUserChangeOURow.IdProperty), NameProperty(AisUserChangeOURow.NameProperty)]
    [FormKey("Request_Ais.AisUserChangeOU"), LocalTextPrefix(AisUserChangeOURow.LocalTextPrefix), Service(AisUserChangeOUService.BaseUrl)]
    public class AisUserChangeOUDialog : EntityDialog<AisUserChangeOURow>
    {
        protected AisUserChangeOUForm form;

        public AisUserChangeOUDialog()
        {
            form = new AisUserChangeOUForm(this.IdPrefix);
        }
    }
}