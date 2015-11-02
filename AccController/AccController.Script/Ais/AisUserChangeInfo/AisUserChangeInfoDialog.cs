
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Email")]
    [FormKey("Ais.AisUserChangeInfo"), LocalTextPrefix("Ais.AisUserChangeInfo"), Service("Ais/AisUserChangeInfo")]
    public class AisUserChangeInfoDialog : EntityDialog<AisUserChangeInfoRow>
    {
    }
}