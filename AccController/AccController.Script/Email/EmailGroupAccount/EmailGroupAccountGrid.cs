
namespace AccController.Email
{
    using AccController.Administration;
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [ColumnsKey("Email.EmailGroupAccount"), IdProperty("Id"), NameProperty("Account")]
    [DialogType(typeof(EmailGroupAccountDialog)), LocalTextPrefix("Email.EmailGroupAccount"), Service("Email/EmailGroupAccount")]
    public class EmailGroupAccountGrid : EntityGrid<EmailGroupAccountRow>
    {
        private GridRowSelectionMixin rowSelection;
        static string user_name = "";
        static int i_refresh = 1;
       // static string admin_lv = "-1";
        static int admin_lv = -1;
        static string sub_admin = "";

        public EmailGroupAccountGrid(jQueryObject container)
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

                    if (obj.adminlv != null)
                        admin_lv = (int)obj.adminlv;


                    sub_admin = t.by_admin;
                    if (i_refresh == 1)
                    {
                        i_refresh = 0;
                        Refresh();
                    }

                }

            });

            //Q.Log(admin_lv);
            var req = (ListRequest)view.Params;
            req.EqualityFilter = req.EqualityFilter ?? new JsDictionary<string, object>();

            req.EqualityFilter["By_User"] = "";
            req.EqualityFilter["By_SubAdmin"] = "";

            if (admin_lv == 1)
            {
                req.EqualityFilter["By_User"] = "";
                //  Q.Log("if");
            }
            else if (admin_lv > 1)
            {
                req.EqualityFilter["By_SubAdmin"] = admin_lv;
                //Q.Log("else");
            }
            else
                req.EqualityFilter["By_User"] = user_name;

            req.EqualityFilter["Submit"] = "0";
            return true;
        }

        protected override List<SlickColumn> GetColumns()
        {
            var columns = base.GetColumns();
            columns.Insert(0, GridRowSelectionMixin.CreateSelectColumn(() => rowSelection));
            return columns;
        }

        protected override List<ToolButton> GetButtons()
        {
            var buttons = base.GetButtons();
            // var self = this;
            buttons[0].Title = "New";
            buttons.Add(new ToolButton
            {

                Title = "Delete",
                CssClass = "delete-button",
                OnClick = delegate
                {
                    List<string> selectedIDs = rowSelection.GetSelectedKeys();

                    if (selectedIDs.Count == 0)
                        Q.NotifyError("Phải chọn bản ghi muốn xóa");
                    else
                    {
                        Q.Confirm("Bạn có muốn xóa những bản ghi đã chọn?", () =>
                        {
                            foreach (var item in selectedIDs)
                            {
                                //long id = (long)Convert.FromBase64String(item).ConvertToId();
                                int id = Int32.Parse(item);

                                var request = new DeleteRequest();
                                request.EntityId = id;

                                Q.ServiceCall(new ServiceCallOptions
                                {
                                    Url = Q.ResolveUrl("~/Services/Email/EmailGroupAccount/Delete"),
                                    Request = request.As<ServiceRequest>(),
                                    OnSuccess = response =>
                                    {

                                        rowSelection = new GridRowSelectionMixin(this);
                                        Refresh();
                                    }
                                });
                            }

                        });
                    }
                }
            });

            buttons.Add(new ToolButton
            {
                Title = "Submit",
                CssClass = "submit-button",
                OnClick = delegate
                {
                    List<string> selectedIDs = rowSelection.GetSelectedKeys();

                    if (admin_lv < 1)
                        Q.NotifyError("Không có quyền thực hiện chức năng này!");
                    else
                    {
                        if (selectedIDs.Count == 0)
                            Q.NotifyError("Phải chọn bản ghi muốn duyệt");

                        else
                        {
                            List<string> selectedID = rowSelection.GetSelectedKeys();
                            foreach (var item in selectedID)
                            {
                                var request = new SaveRequest<EmailGroupAccountRow>();
                                request.Entity = this.View.GetItemById(item);
                                EmailGroupAccountService.updateSubmit(request, s =>
                                {
                                    Refresh();
                                });
                            }
                           
                        }
                    }
                }
            });

            return buttons;
        }
    }

    
}