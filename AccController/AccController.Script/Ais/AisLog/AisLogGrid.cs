
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisLog"), IdProperty("Id"), NameProperty("LastUpdatedby")]
    [DialogType(typeof(AisLogDialog)), LocalTextPrefix("Ais.AisLog"), Service("Ais/AisLog")]
    public class AisLogGrid : EntityGrid<AisLogRow>
    {
        public AisLogGrid(jQueryObject container)
            : base(container)
        {
        }
    }
    
}