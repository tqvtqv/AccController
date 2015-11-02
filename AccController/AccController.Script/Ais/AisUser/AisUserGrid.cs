
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
        private ImageUploadEditor uploader;
        public AisUserGrid(jQueryObject container)
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
                               data.url = Q.ResolveUrl("~/Ais/AisFile/CreateUserRequest");
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