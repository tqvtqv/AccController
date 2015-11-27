
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Ais.Testt"), IdProperty(TesttRow.IdProperty), NameProperty(TesttRow.NameProperty)]
    [DialogType(typeof(TesttDialog)), LocalTextPrefix(TesttRow.LocalTextPrefix), Service(TesttService.BaseUrl)]
    public class TesttGrid : EntityGrid<TesttRow>
    {
        public TesttGrid(jQueryObject container)
            : base(container)
        {
        }
    }
}