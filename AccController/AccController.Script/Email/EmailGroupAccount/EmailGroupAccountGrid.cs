
namespace AccController.Email
{
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

        public EmailGroupAccountGrid(jQueryObject container)
            : base(container)
        {
            rowSelection = new GridRowSelectionMixin(this);
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



            return buttons;
        }
    }

    
}