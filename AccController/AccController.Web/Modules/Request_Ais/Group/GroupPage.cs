

//[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/Group", typeof(AccController.Request_Ais.Pages.GroupController))]

namespace AccController.Request_Ais.Pages
{
    using Serenity;
    using Serenity.Web;
    using System.Web.Mvc;
    using Serenity.Services;
    using System.Collections.Generic;
    using MyController = AccController.Request_Ais.Endpoints.GroupController;
    using MyRow = Entities.GroupRow;
    using Serenity.Data;
    using Modules.Common.Helpers;

    [RoutePrefix("Request_Ais/Group"), Route("{action=index}")]
    public class GroupController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/Group/GroupIndex.cshtml");
        }

        public ActionResult GetRequestFile(string status)
        {
            var req = new ListRequest();
            req.EqualityFilter = new Dictionary<string, object>();
            req.EqualityFilter.Add("Submit", status);
            using (var connection = SqlConnections.NewByKey("Default"))
            {
                var stream = SpreedSheetHelper.ExportXls<MyRow>(
                    new MyController().List(connection, req).Entities, Server.MapPath("~/Content/templates/import/ais/TaoMoiDonVi.xlsx"));
                return ExcelContentResult.Create(stream.GetBuffer());
            }

        }
    }
}