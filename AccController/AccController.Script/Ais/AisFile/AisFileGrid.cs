
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.AisFile"), IdProperty("Id"), NameProperty("FileName")]
    [DialogType(typeof(AisFileDialog)), LocalTextPrefix("Ais.AisFile"), Service("Ais/AisFile")]
    public class AisFileGrid : EntityGrid<AisFileRow>
    {
        public AisFileGrid(jQueryObject container)
            : base(container)
        {
        }
    }

    //// Please remove this partial class or the first line below, after you run ScriptContexts.tt
    //[Imported, Serializable, PreserveMemberCase] 
    //public partial class AisFileRow
    //{
    //}
}