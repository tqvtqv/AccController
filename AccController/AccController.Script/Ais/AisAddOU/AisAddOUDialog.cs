
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Email")]
    [FormKey("Ais.AisAddOU"), LocalTextPrefix("Ais.AisAddOU"), Service("Ais/AisAddOU")]
    public class AisAddOUDialog : EntityDialog<AisAddOURow>
    {
    }
}