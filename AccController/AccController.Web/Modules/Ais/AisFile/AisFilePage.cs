



namespace AccController.Ais.Pages
{
    using Modules.Common.Helpers;
    using Entities;
    using Serenity;
    using Serenity.Services;
    using Serenity.Web;
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Hosting;
    using System.Web.Mvc;
    using System.Collections.Generic;
    using Repositories;

    [RoutePrefix("Ais/AisFile"), Route("{action=index}")]
    public class AisFileController : Controller
    {
        [PageAuthorize("AisFile")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisFile/AisFileIndex.cshtml");
        }
       
        [AcceptVerbs("POST")]
        public ActionResult CreateGroupRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            var response = this.ExecuteMethod(() => HandleUploadRequest(file));
            AisFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;
            if (fileRow != null) {
                ListContainer<GroupRow> list = new ListContainer<GroupRow>();
                var fileRowResponse = this.InTransaction("Default", (uow) => new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                {
                    Entity = fileRow
                })).Data;
                if (fileRowResponse.EntityId.HasValue)
                {
                    try
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin);
                        list = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/TaoMoiDonVi.xlsx")).ReadFromFile(list, file.InputStream);
                        if (list != null)
                        {
                            foreach (var item in list.Entities)
                            {
                                this.InTransaction("Default", (uow) =>
                                {
                                    
                                    var saveresponse = new GroupRepository().Create(uow, new SaveRequest<GroupRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                        {
                                            Entity = new AisFileResultsRow
                                            {
                                                FileId = Convert.ToInt32(fileRowResponse.EntityId),
                                                ReqId = Convert.ToInt32(saveresponse.EntityId),
                                                ReqType = 1
                                            }
                                        });
                                    return saveresponse;
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                    }
                }
                //this.InTransaction("Default", (uow) => {
                //}
                //);
            }
            
            if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                response.ContentType = "text/plain";
            ((UploadResponse)response.Data).UploadedFile = null;
            return response;
        }

        [AcceptVerbs("POST")]
        public ActionResult CreateUserRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            var response = this.ExecuteMethod(() => HandleUploadRequest(file));
            AisFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;
            if (fileRow != null)
            {
                ListContainer<AisUserRow> list = new ListContainer<AisUserRow>();
                var fileRowResponse = this.InTransaction("Default", (uow) => new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                {
                    Entity = fileRow
                })).Data;
                if (fileRowResponse.EntityId.HasValue)
                {
                    try
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin);
                        list = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/TaoMoiNguoiDung.xlsx")).ReadFromFile(list, file.InputStream);
                        if (list != null)
                        {
                            foreach (var item in list.Entities)
                            {
                                this.InTransaction("Default", (uow) =>
                                {
                                    var saveresponse = new AisUserRepository().Create(uow, new SaveRequest<AisUserRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                        {
                                            Entity = new AisFileResultsRow
                                            {
                                                FileId = Convert.ToInt32(fileRowResponse.EntityId),
                                                ReqId = Convert.ToInt32(saveresponse.EntityId),
                                                ReqType = 2
                                            }
                                        });
                                    return saveresponse;
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string s = ex.Message;
                    }
                }
                //this.InTransaction("Default", (uow) => {
                //}
                //);
            }

            if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                response.ContentType = "text/plain";
            ((UploadResponse)response.Data).UploadedFile = null;
            return response;
        }


        private ServiceResponse HandleUploadRequest(HttpPostedFileBase file)
        {
            AisFileRow fileRow = new AisFileRow
            {
                ContentType = file.ContentType,
                FileSize = file.ContentLength,
                FileName = file.FileName,
                UploadedBy = User.Identity.Name,
                Uploaded = DateTime.Now
            };
            var folderPath = HostingEnvironment.MapPath(UploadSettings.Current.Path + "Ais");
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);

            fileRow.FilePath = Path.Combine(folderPath, Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName));
            file.SaveAs(fileRow.FilePath); // Save the file
            return new UploadResponse()
            {
                TemporaryFile = fileRow.FilePath,
                IsImage = false,
                UploadedFile = fileRow
            };
        }

        private class UploadResponse : ServiceResponse
        {
            public string TemporaryFile { get; set; }
            public long Size { get; set; }
            public bool IsImage { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
            public string ContenType { get; set; }
            public AisFileRow UploadedFile { get; set; }
        }
        private class ListContainer<T> {
            public List<T> Entities { get; set; }
        }
    }
}