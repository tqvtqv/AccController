
namespace AccController.Administration
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Threading;

    [IdProperty("UserId"), NameProperty("Username"), IsActiveProperty("IsActive")]
    [DialogType(typeof(UserDialog)), LocalTextPrefix("Administration.User"), Service("Administration/User")]
    public class UserGrid : EntityGrid<UserRow>
    {
        private GridRowSelectionMixin rowSelection;
        static string user_name = "";
        static int i_refresh = 1;
        static string admin_lv = "1";
        public UserGrid(jQueryObject container)
            : base(container)
        {

            rowSelection = new GridRowSelectionMixin(this);
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
                    //Q.Log("user_name:  " + user_name + "  admin_lv:" + admin_lv);
                    if (i_refresh == 1)
                    {
                        i_refresh = 0;
                        Refresh();
                    }
                }
            });


            var req = (ListRequest)view.Params;
            req.EqualityFilter = req.EqualityFilter ?? new JsDictionary<string, object>();
            //req.EqualityFilter["by_admin"] = user_name;
          
            if (admin_lv == "1")

                req.EqualityFilter["by_admin"] = "";
            else
                req.EqualityFilter["by_admin"] = user_name;



            req.EqualityFilter["by_admin"] = "";
            return true;
        }

      
        protected override List<ToolButton> GetButtons()
        {
            var buttons = base.GetButtons();
          
            //buttons.Add(new ToolButton
            //{
            //    Hint = "this is hint",
                
            //    Title = "new btn",
            //    CssClass = "button",
            //    OnClick = delegate
            //    {
                 
            //        List<UserRow> lst =  this.View.GetItems();
            //        foreach(var item in lst)
            //        {
            //            if (item.Username != "tanhn")
            //            {
            //                item.DisplayName = "WWWWWWWWWW";
            //                this.View.UpdateItem(item.UserId,item);
            //            }
            //        }

            //    }
            //});

           
            return buttons;
        }
       
        protected override List<SlickColumn> GetColumns()
        {
            var columns = base.GetColumns();

            //columns.Insert(0, GridRowSelectionMixin.CreateSelectColumn(() => rowSelection));


            //columns.Add(new SlickColumn { Field = "UserId", Width = 55, CssClass = "align-right", Title = Q.Text("Db.Shared.RecordId") });
            columns.Add(new SlickColumn { Field = "Username", Width = 150, Format = ItemLink() });
            columns.Add(new SlickColumn { Field = "DisplayName", Width = 150 });
            columns.Add(new SlickColumn { Field = "Email", Width = 250 });
            columns.Add(new SlickColumn { Field = "Source", Width = 100 });
            columns.Add(new SlickColumn { Field = "by_admin", Width = 100 });
            return columns;
        }

        protected override List<string> GetDefaultSortBy()
        {
            return new List<string> { "Username" };
        }
    }
}