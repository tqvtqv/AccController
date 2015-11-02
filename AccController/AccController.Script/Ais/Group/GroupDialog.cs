
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty("Id"), NameProperty("Name")]
    [FormKey("Ais.Group"), LocalTextPrefix("Ais.Group"), Service("Ais/Group")]
    public class GroupDialog : EntityDialog<GroupRow>
    {
    }
}