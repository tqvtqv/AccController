
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Ou")]
    [FormKey("Ais.AisUser"), LocalTextPrefix("Ais.AisUser"), Service("Ais/AisUser")]
    public class AisUserDialog : EntityDialog<AisUserRow>
    {
    }
}