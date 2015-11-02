
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
        private ImageUploadEditor uploader;
        public AisAddOUGrid(jQueryObject container)
            : base(container)
        {
        }
        protected override void CreateToolbarExtensions()
        {
            base.CreateToolbarExtensions();

            uploader = Widget.Create<ImageUploadEditor>(
                   element: e => e.AppendTo(toolbar.Element),
                   options: new ImageUploadEditorOptions { AllowNonImage = true, MaxSize = 2048 },
                   init: e =>
                   {
                       J("ul", e.Element).Hide();
                       J(".delete-button", e.Element).Hide();
                       J("input:file", uploader.Element).Bind2("fileuploadadd",
                           new Action<jQueryEvent, dynamic>((ev, data) =>
                           {
                               data.url = Q.ResolveUrl("~/Ais/AisFile/CreateAddUserOURequest");
                           }));
                       J("input:file", uploader.Element).Bind2("fileuploaddone",
                           new Action<jQueryEvent, dynamic>((ev, data) =>
                           {
                               Refresh();
                           }));
                   }
                   );
        }
    }

    
}