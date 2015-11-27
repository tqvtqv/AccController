
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(AisUserChangeInfoRow.IdProperty), NameProperty(AisUserChangeInfoRow.NameProperty)]
    [FormKey("Request_Ais.AisUserChangeInfo"), LocalTextPrefix(AisUserChangeInfoRow.LocalTextPrefix), Service(AisUserChangeInfoService.BaseUrl)]
    public class AisUserChangeInfoDialog : EntityDialog<AisUserChangeInfoRow>
    {
        protected AisUserChangeInfoForm form;

        public AisUserChangeInfoDialog()
        {
            form = new AisUserChangeInfoForm(this.IdPrefix);
        }
    }
}