
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("LastUpdatedby")]
    [FormKey("Ais.AisLog"), LocalTextPrefix("Ais.AisLog"), Service("Ais/AisLog")]
    public class AisLogDialog : EntityDialog<AisLogRow>
    {
    }
}