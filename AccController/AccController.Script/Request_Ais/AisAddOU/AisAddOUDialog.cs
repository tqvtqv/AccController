
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(AisAddOURow.IdProperty), NameProperty(AisAddOURow.NameProperty)]
    [FormKey("Request_Ais.AisAddOU"), LocalTextPrefix(AisAddOURow.LocalTextPrefix), Service(AisAddOUService.BaseUrl)]
    public class AisAddOUDialog : EntityDialog<AisAddOURow>
    {
        protected AisAddOUForm form;

        public AisAddOUDialog()
        {
            form = new AisAddOUForm(this.IdPrefix);
        }
    }
}