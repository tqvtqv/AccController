
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisAddOU"), IdProperty("Id"), NameProperty("Email")]
    [DialogType(typeof(AisAddOUDialog)), LocalTextPrefix("Ais.AisAddOU"), Service("Ais/AisAddOU")]
    public class AisAddOUGrid : EntityGrid<AisAddOURow>
    {
        public AisAddOUGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    
}