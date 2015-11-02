
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisUserChangeOU"), IdProperty("Id"), NameProperty("Email")]
    [DialogType(typeof(AisUserChangeOUDialog)), LocalTextPrefix("Ais.AisUserChangeOU"), Service("Ais/AisUserChangeOU")]
    public class AisUserChangeOUGrid : EntityGrid<AisUserChangeOURow>
    {
        public AisUserChangeOUGrid(jQueryObject container)
            : base(container)
        {
        }
    }
    
}