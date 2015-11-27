
namespace AccController.Request_Ais
{
    using AccController.Administration;
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Request_Ais.AisAddOU"), IdProperty(AisAddOURow.IdProperty), NameProperty(AisAddOURow.NameProperty)]
    [DialogType(typeof(AisAddOUDialog)), LocalTextPrefix(AisAddOURow.LocalTextPrefix), Service(AisAddOUService.BaseUrl)]
    public class AisAddOUGrid : EntityGrid<AisAddOURow>
    {
        static string user_name = "";
        static int i_refresh = 1;
        static string admin_lv = "-1";

        public AisAddOUGrid(jQueryObject container)
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


         protected override List<ToolButton> GetButtons()
         {
             var buttons = base.GetButtons();
             buttons.RemoveAt(0);
             return buttons;
         }
    
    }
}