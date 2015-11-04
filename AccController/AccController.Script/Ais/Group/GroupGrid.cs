
namespace AccController.Ais
{

    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using Fields = GroupRow.Fields;

    [ColumnsKey("Ais.Group"), IdProperty("Id"), NameProperty("Name")]
    [DialogType(typeof(GroupDialog)), LocalTextPrefix("Ais.Group"), Service("Ais/Group")]
    public class GroupGrid : EntityGrid<GroupRow>
    {
        private ImageUploadEditor uploader;
        public GroupGrid(jQueryObject container)
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
                               data.url = Q.ResolveUrl("~/Ais/AisFile/CreateGroupRequest");
                           }));
                       J("input:file", uploader.Element).Bind2("fileuploaddone",
                           new Action<jQueryEvent, dynamic>((ev, data) =>
                           {
                               if (data.Error != null)
                               {
                                   //Q.
                                   if (data.Error.Code == "FileErr")
                                       Q.NotifyError(data.Error.Message); //Q.Alert("sss", new AlertOptions { OnClose = { } });
                                   else
                                       Q.NotifyError(data.Error.Message);
                               }
                               else
                                   Refresh();
                           }));
                   }
                   );
        }
    }

    //// Please remove this partial class or the first line below, after you run ScriptContexts.tt
    //[Imported, Serializable, PreserveMemberCase] 
    //public partial class GroupRow
    //{
    //}
}