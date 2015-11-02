
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisFileResults"), IdProperty("Id")]
    [DialogType(typeof(AisFileResultsDialog)), LocalTextPrefix("Ais.AisFileResults"), Service("Ais/AisFileResults")]
    public class AisFileResultsGrid : EntityGrid<AisFileResultsRow>
    {
        public AisFileResultsGrid(jQueryObject container)
            : base(container)
        {
        }
    }

}