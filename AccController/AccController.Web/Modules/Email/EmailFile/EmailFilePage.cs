



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
            try
            {
                ListContainer<EmailNewRow> list = new ListContainer<EmailNewRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/TaoMoi.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);
                stream.Seek(0, SeekOrigin.Begin);

                var response = this.ExecuteMethod(() => HandleUploadRequest(file, stream, spsHelper.HasError));
                EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;

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
                        var saveFileResponse = new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
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
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                return saveresponse;
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;
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

        [AcceptVerbs("POST")]
        public ActionResult CreateUpdateInfoRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            try
            {
                ListContainer<EmailUpdateInfoRow> list = new ListContainer<EmailUpdateInfoRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/CapNhatTT.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);
                stream.Seek(0, SeekOrigin.Begin);

                var response = this.ExecuteMethod(() => HandleUploadRequest(file, stream, spsHelper.HasError));
                EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;

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
                        var saveFileResponse = new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
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
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                return saveresponse;
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;
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

        [AcceptVerbs("POST")]
        public ActionResult CreateEmailChangeRequest()
        {
            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            try
            {
                ListContainer<EmailChangeRow> list = new ListContainer<EmailChangeRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/email/DoiTenTK.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);
                stream.Seek(0, SeekOrigin.Begin);

                var response = this.ExecuteMethod(() => HandleUploadRequest(file, stream, spsHelper.HasError));
                EmailFileRow fileRow = ((UploadResponse)response.Data).UploadedFile;

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
                        var saveFileResponse = new EmailFileRepository().Create(uow, new SaveRequest<EmailFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
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
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                return saveresponse;
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;
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
            EmailFileRow fileRow = new EmailFileRow
            {
                ContentType = file.ContentType,
                FileSize = file.ContentLength,
                FileName = file.FileName,
                UploadedBy = User.Identity.Name,
                Uploaded = DateTime.Now
            };
            var folderPath = HostingEnvironment.MapPath(UploadSettings.Current.Path + ((hasErr) ? "EmailError" : "Email"));
            bool exists = Directory.Exists(folderPath);
            if (!exists)
                Directory.CreateDirectory(folderPath);

            fileRow.FilePath = Path.Combine(folderPath, Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName));
            using (FileStream fs = new FileStream(fileRow.FilePath, FileMode.Create, FileAccess.Write))
            {
                stream.WriteTo(fs);
            }
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