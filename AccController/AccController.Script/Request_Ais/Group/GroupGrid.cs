
namespace AccController.Request_Ais
{
    using AccController.Administration;
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Html;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Request_Ais.Group"), IdProperty(GroupRow.IdProperty), NameProperty(GroupRow.NameProperty)]
    [DialogType(typeof(GroupDialog)), LocalTextPrefix(GroupRow.LocalTextPrefix), Service(GroupService.BaseUrl)]
    public class GroupGrid : EntityGrid<GroupRow>
    {
        static string user_name = "";
        static int i_refresh = 1;
        static string admin_lv = "-1";
        private ImageUploadEditor resultUploader;
        public GroupGrid(jQueryObject container)
            : base(container)
        {
        }

        protected override bool OnViewSubmit()
        {
            var request = new ServiceRequest();
            Q.ServiceCall(new ServiceCallOptions
            {
                Url = Q.ResolveUrl("~/Administration/User/getUser"),

                Request = request.As<ServiceRequest>(),
                OnSuccess = response =>
                {
                    dynamic obj = response;
                    UserRow t = (UserRow)obj;
                    user_name = t.Username;
                    admin_lv = obj.adminlv;
                    if (i_refresh == 1)
                    {
                        i_refresh = 0;
                        Refresh();
                    }
                }
            });

            var req = (ListRequest)view.Params;
            req.EqualityFilter = req.EqualityFilter ?? new JsDictionary<string, object>();
            //if (admin_lv == "1")
            //    req.EqualityFilter["By_User"] = "";
            //else
            //    req.EqualityFilter["By_User"] = user_name;
            req.EqualityFilter["Submit"] = "1";
            return true;
        }

        protected override void CreateToolbarExtensions()
        {
            base.CreateToolbarExtensions();

            resultUploader = Widget.Create<ImageUploadEditor>(
                   element: e => e.AppendTo(toolbar.Element),
                   options: new ImageUploadEditorOptions { AllowNonImage = true, MaxSize = 2048 },
                   init: e =>
                   {
                       J("ul", e.Element).Hide();
                       J(".delete-button", e.Element).Hide();
                       J("input:file", resultUploader.Element).Bind2("fileuploadadd",
                           new Action<jQueryEvent, dynamic>((ev, data) =>
                           {
                               data.url = Q.ResolveUrl("~/Request_Ais/Group/GetResultFromFile");
                           }));
                       J("input:file", resultUploader.Element).Bind2("fileuploaddone",
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

        protected override List<ToolButton> GetButtons()
        {
            var buttons = base.GetButtons();
            buttons.RemoveAt(0);
            buttons.Add(new ToolButton
            {
                Title = "Download",
                CssClass = "export-xlsx-button",
                OnClick = delegate
                {
                    Window.Open(Q.ResolveUrl("~/Request_Ais/Group/GetRequestFile?status=1"), "_blank");
                }
            });
            return buttons;
        }
    }
}