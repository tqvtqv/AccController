
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisUserChangeInfo"), IdProperty("Id"), NameProperty("Email")]
    [DialogType(typeof(AisUserChangeInfoDialog)), LocalTextPrefix("Ais.AisUserChangeInfo"), Service("Ais/AisUserChangeInfo")]
    public class AisUserChangeInfoGrid : EntityGrid<AisUserChangeInfoRow>
    {
        public AisUserChangeInfoGrid(jQueryObject container)
            : base(container)
        {
        }
    }

}