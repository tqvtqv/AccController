
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Email")]
    [FormKey("Ais.AisUserChangeOU"), LocalTextPrefix("Ais.AisUserChangeOU"), Service("Ais/AisUserChangeOU")]
    public class AisUserChangeOUDialog : EntityDialog<AisUserChangeOURow>
    {
    }
}