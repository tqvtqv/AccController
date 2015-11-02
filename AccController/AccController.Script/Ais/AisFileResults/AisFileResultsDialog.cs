
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id")]
    [FormKey("Ais.AisFileResults"), LocalTextPrefix("Ais.AisFileResults"), Service("Ais/AisFileResults")]
    public class AisFileResultsDialog : EntityDialog<AisFileResultsRow>
    {
    }
}