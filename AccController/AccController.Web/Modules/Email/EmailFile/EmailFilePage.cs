



namespace AccController.Email.Pages
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

    [RoutePrefix("Email/EmailFile"), Route("{action=index}")]
    public class EmailFileController : Controller
    {
        [PageAuthorize("EmailFile")]
        public ActionResult Index()
        {
            return View("~/Modules/Email/EmailFile/EmailFileIndex.cshtml");
        }

        [AcceptVerbs("POST")]
        public ActionResult CreateNewRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            var response = this.ExecuteMethod(() => HandleUploadRequest(file));
            EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;
            if (fileRow != null)
            {
                ListContainer<EmailNewRow> list = new ListContainer<EmailNewRow>();
                var fileRowResponse = this.InTransaction("Default", (uow) => new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                {
                    Entity = fileRow
                })).Data;
                if (fileRowResponse.EntityId.HasValue)
                {
                    try
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin);
                        list = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/TaoMoi.xlsx")).ReadFromFile(list, file.InputStream);
                        if (list != null)
                        {
                            foreach (var item in list.Entities)
                            {
                                this.InTransaction("Default", (uow) =>
                                {
                                    var saveresponse = new EmailNewRepository().Create(uow, new SaveRequest<EmailNewRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new FileResultRepository().Create(uow, new SaveRequest<FileResultRow>
                                        {
                                            Entity = new FileResultRow
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
                        throw ex;
                        //((UploadResponse)response.Data).UploadedFile = null;
                        //response = new Result<ServiceResponse>(new ServiceResponse
                        //{
                        //    Error = new ServiceError()
                        //    {
                        //        Code = "Exception",
                        //        Message = ex.Message
                        //    }
                        //});
                    }
                }

            }

            if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                response.ContentType = "text/plain";
            
            return response;
        }

        [AcceptVerbs("POST")]
        public ActionResult CreateUpdateInfoRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            var response = this.ExecuteMethod(() => HandleUploadRequest(file));
            EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;
            if (fileRow != null)
            {
                ListContainer<EmailUpdateInfoRow> list = new ListContainer<EmailUpdateInfoRow>();
                var fileRowResponse = this.InTransaction("Default", (uow) => new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                {
                    Entity = fileRow
                })).Data;
                if (fileRowResponse.EntityId.HasValue)
                {
                    try
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin);
                        list = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/CapNhatTT.xlsx")).ReadFromFile(list, file.InputStream);
                        if (list != null)
                        {
                            foreach (var item in list.Entities)
                            {
                                this.InTransaction("Default", (uow) =>
                                {
                                    var saveresponse = new EmailUpdateInfoRepository().Create(uow, new SaveRequest<EmailUpdateInfoRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new FileResultRepository().Create(uow, new SaveRequest<FileResultRow>
                                        {
                                            Entity = new FileResultRow
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
                        response = new Result<ServiceResponse>(new ServiceResponse {
                            Error = new ServiceError()
                            {
                                Code = "Exception",
                                Message = ex.Message
                            }
                        });
                    }
                }
                
            }

            if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                response.ContentType = "text/plain";
            ((UploadResponse)response.Data).UploadedFile = null;
            return response;
        }

        [AcceptVerbs("POST")]
        public ActionResult CreateEmailChangeRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            var response = this.ExecuteMethod(() => HandleUploadRequest(file));
            EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;
            if (fileRow != null)
            {
                ListContainer<EmailChangeRow> list = new ListContainer<EmailChangeRow>();
                var fileRowResponse = this.InTransaction("Default", (uow) => new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                {
                    Entity = fileRow
                })).Data;
                if (fileRowResponse.EntityId.HasValue)
                {
                    try
                    {
                        file.InputStream.Seek(0, SeekOrigin.Begin);
                        list = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/DoiTenTK.xlsx")).ReadFromFile(list, file.InputStream);
                        if (list != null)
                        {
                            foreach (var item in list.Entities)
                            {
                                this.InTransaction("Default", (uow) =>
                                {
                                    var saveresponse = new EmailChangeRepository().Create(uow, new SaveRequest<EmailChangeRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new FileResultRepository().Create(uow, new SaveRequest<FileResultRow>
                                        {
                                            Entity = new FileResultRow
                                            {
                                                FileId = Convert.ToInt32(fileRowResponse.EntityId),
                                                ReqId = Convert.ToInt32(saveresponse.EntityId),
                                                ReqType = 3
                                            }
                                        });
                                    return saveresponse;
                                });
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        response = new Result<ServiceResponse>(new ServiceResponse
                        {
                            Error = new ServiceError()
                            {
                                Code = "Exception",
                                Message = ex.Message
                            }
                        });
                    }
                }

            }

            if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                response.ContentType = "text/plain";
            ((UploadResponse)response.Data).UploadedFile = null;
            return response;
        }


        private ServiceResponse HandleUploadRequest(HttpPostedFileBase file)
        {
            EmailFileRow fileRow = new EmailFileRow
            {
                ContentType = file.ContentType,
                FileSize = file.ContentLength,
                FileName = file.FileName,
                UploadedBy = User.Identity.Name,
                Uploaded = DateTime.Now
            };
            var folderPath = HostingEnvironment.MapPath(UploadSettings.Current.Path + "Email");
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
            public EmailFileRow UploadedFile { get; set; }
        }
        private class ListContainer<T>
        {
            public List<T> Entities { get; set; }
        }
    }
}