

[assembly:Serenity.Navigation.NavigationLink(int.MaxValue, "Request_Ais/AisUserChangeInfo", typeof(AccController.Request_Ais.Pages.AisUserChangeInfoController))]

namespace AccController.Request_Ais.Pages
{
    using Modules.Common.File;
    using Ais.Entities;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using MyController = AccController.Request_Ais.Endpoints.AisUserChangeInfoController;
    using MyRow = Entities.AisUserChangeInfoRow;
    using Modules.Common.Helpers;
    using Serenity.Data;
    using System.IO;
    using Repositories;

    [RoutePrefix("Request_Ais/AisUserChangeInfo"), Route("{action=index}")]
    public class AisUserChangeInfoController : Controller
    {
        [PageAuthorize("Request_Ais")]
        public ActionResult Index()
        {
            return View("~/Modules/Request_Ais/AisUserChangeInfo/AisUserChangeInfoIndex.cshtml");
        }

        public ActionResult GetRequestFile(string status)
        {
            var req = new ListRequest();
            req.EqualityFilter = new Dictionary<string, object>();
            req.EqualityFilter.Add("Submit", status);
            using (var connection = SqlConnections.NewByKey("Default"))
            {
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/export/result/ais/CapNhatTTUser.xlsx"));
                var stream = spsHelper.ExportXls<MyRow>(new MyController().List(connection, req).Entities);
                return ExcelContentResult.Create(stream.GetBuffer());
            }

        }
        [AcceptVerbs("POST")]
        public ActionResult GetResultFromFile(string status)
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");
            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            try
            {
                ListContainer<MyRow> list = new ListContainer<MyRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/result/ais/CapNhatTTUser.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);
                stream.Seek(0, SeekOrigin.Begin);

                var response = this.ExecuteMethod(() => HandleUploadRequest(file, stream, spsHelper.HasError));
                AisFileRow fileRow = ((UploadResponse<AisFileRow>)response.Data).UploadedFile;

                if (fileRow != null)
                {
                    if (spsHelper.HasError)
                    {
                        return new Result<ServiceResponse>(new ServiceResponse
                        {
                            Error = new ServiceError()
                            {
                                Code = "FileErr",
                                Message = fileRow.FilePath
                            }
                        });
                    }
                    var fileRowResponse = this.InTransaction("Default", (uow) =>
                    {
                        var saveFileResponse = new Ais.Repositories.AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
                            {

                                var saveresponse = new AisUserChangeInfoRepository().UpdateResult(uow, new SaveRequest<MyRow>
                                {
                                    Entity = item
                                });
                                if (saveresponse.EntityId.HasValue)
                                    new Ais.Repositories.AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                    {
                                        Entity = new AisFileResultsRow
                                        {
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse<AisFileRow>)response.Data).UploadedFile = null;
                return response;
            }
            catch (Exception ex)
            {
                return new Result<ServiceResponse>(new ServiceResponse
                {
                    Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = ex.Message
                    }
                });
            }
        }


        private ServiceResponse HandleUploadRequest(HttpPostedFileBase file, MemoryStream stream, bool hasErr)
        {
            AisFileRow fileRow = new AisFileRow
            {
                ContentType = file.ContentType,
                FileSize = file.ContentLength,
                FileName = file.FileName,
                UploadedBy = User.Identity.Name,
                Uploaded = DateTime.Now
            };
            var folderPath = HostingEnvironment.MapPath(UploadSettings.Current.Path + ((hasErr) ? "AisResultError" : "AisResult"));
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);

            fileRow.FilePath = Path.Combine(folderPath, Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName));
            using (FileStream fs = new FileStream(fileRow.FilePath, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }
            return new UploadResponse<AisFileRow>()
            {
                TemporaryFile = fileRow.FilePath,
                IsImage = false,
                UploadedFile = fileRow
            };
        }
    }
}