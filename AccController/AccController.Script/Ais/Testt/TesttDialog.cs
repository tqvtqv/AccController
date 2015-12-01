
namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System.Collections.Generic;

    [IdProperty(TesttRow.IdProperty), NameProperty(TesttRow.NameProperty)]
    [FormKey("Ais.Testt"), LocalTextPrefix(TesttRow.LocalTextPrefix), Service(TesttService.BaseUrl)]
    public class TesttDialog : EntityDialog<TesttRow>
    {
        protected TesttForm form;

        public TesttDialog()
        {
            form = new TesttForm(this.IdPrefix);
        }
    }
}