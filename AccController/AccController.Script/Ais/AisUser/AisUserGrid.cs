
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisUser"), IdProperty("Id"), NameProperty("Ou")]
    [DialogType(typeof(AisUserDialog)), LocalTextPrefix("Ais.AisUser"), Service("Ais/AisUser")]
    public class AisUserGrid : EntityGrid<AisUserRow>
    {
        public AisUserGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}