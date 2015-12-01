



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
    using System.Data;
    using AccController.Administration.Entities;
    using System.Threading;
    using AccController.Administration.Repositories;
    using AccController.Administration;
    using Modules.Common.File;

    [RoutePrefix("Ais/AisFile"), Route("{action=index}")]
    public class AisFileController : Controller
    {
        public int user_id;
        [PageAuthorize("AisFile")]
        public ActionResult Index()
        {
            return View("~/Modules/Ais/AisFile/AisFileIndex.cshtml");
        }
       
        [AcceptVerbs("POST")]
        public ActionResult CreateGroupRequest()
        {

            var excep = 0;

            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");

            try
            {
                ListContainer<GroupRow> list = new ListContainer<GroupRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/Ta oMoiDonVi.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);

                if (list.Entities.Count == 0)
                {
                    return new Result<ServiceResponse>(new ServiceResponse
                    {
                        Error = new ServiceError()
                        {
                            Code = "Exception",
                            Message = "Kiểm tra lại file"
                        }
                    });
                }

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
                        var saveFileResponse = new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
                            {
                                try
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
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    excep = 1;
                                }
                                
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;

                if (excep == 1)
                    response.Data.Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = "Kiểm tra lại file"
                    };

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
        public ActionResult CreateUserRequest()
        {

            var excep = 0;

            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");

            try
            {
                ListContainer<AisUserRow> list = new ListContainer<AisUserRow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/TaoMoiNguoiDung.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);

                if (list.Entities.Count == 0)
                {
                    return new Result<ServiceResponse>(new ServiceResponse
                    {
                        Error = new ServiceError()
                        {
                            Code = "Exception",
                            Message = "Kiểm tra lại file"
                        }
                    });
                }

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
                        var saveFileResponse = new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
                            {
                                try
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
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    excep = 1;
                                }
                                
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;

                if (excep == 1)
                    response.Data.Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = "Kiểm tra lại file"
                    };

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
        public ActionResult CreateUserChangeOURequest()
        {

            var excep = 0;

            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");

            try
            {
                ListContainer<AisUserChangeOURow> list = new ListContainer<AisUserChangeOURow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/CapNhatPhongBanUser.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);

                if (list.Entities.Count == 0)
                {
                    return new Result<ServiceResponse>(new ServiceResponse
                    {
                        Error = new ServiceError()
                        {
                            Code = "Exception",
                            Message = "Kiểm tra lại file"
                        }
                    });
                }

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
                        var saveFileResponse = new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
                            {
                                try
                                {
                                var saveresponse = new AisUserChangeOURepository().Create(uow, new SaveRequest<AisUserChangeOURow>
                                {
                                    Entity = item
                                });
                                if (saveresponse.EntityId.HasValue)
                                    new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                    {
                                        Entity = new AisFileResultsRow
                                        {
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    excep = 1;
                                }
                               
                               
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;

                if (excep == 1)
                    response.Data.Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = "Kiểm tra lại file"
                    };

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
        public ActionResult CreateUserChangeInfoRequest()
        {

            var excep = 0;

            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");
            try
            {
                ListContainer<AisUserChangeInfoRow> list = new ListContainer<AisUserChangeInfoRow>();

                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/CapNhatTTUser.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);

                if (list.Entities.Count == 0)
                {
                    return new Result<ServiceResponse>(new ServiceResponse
                    {
                        Error = new ServiceError()
                        {
                            Code = "Exception",
                            Message = "Kiểm tra lại file"
                        }
                    });
                }

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
                    if (list != null)
                    {
                        var fileRowResponse = this.InTransaction("Default", (uow) =>
                        {
                            var saveFileResponse = new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                            {
                                Entity = fileRow
                            });
                            if (saveFileResponse.EntityId.HasValue)
                            {
                                foreach (var item in list.Entities)
                                {
                                    try
                                    {
                                    var saveresponse = new AisUserChangeInfoRepository().Create(uow, new SaveRequest<AisUserChangeInfoRow>
                                    {
                                        Entity = item
                                    });
                                    if (saveresponse.EntityId.HasValue)
                                        new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                        {
                                            Entity = new AisFileResultsRow
                                            {
                                                FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                                ReqId = Convert.ToInt32(saveresponse.EntityId),
                                                ReqType = 3
                                            }
                                        });
                                    }
                                    catch (Exception ex)
                                    {
                                        excep = 1;
                                    }
                                }
                            }

                            return saveFileResponse;
                        }
                    ).Data;


                    }
                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;

                if (excep == 1)
                    response.Data.Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = "Kiểm tra lại file"
                    };

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
        public ActionResult CreateAddUserOURequest()
        {

            var excep = 0;

            HttpPostedFileBase file = this.HttpContext.Request.Files[0];
            if (file == null)
                throw new ArgumentNullException("file");

            if (file.FileName.IsEmptyOrNull())
                throw new ArgumentNullException("filename");

            try
            {
                ListContainer<AisAddOURow> list = new ListContainer<AisAddOURow>();
                var spsHelper = new SpreedSheetHelper(Server.MapPath("~/Content/templates/import/ais/ThemDonViUser.xlsx"));
                var stream = new MemoryStream();
                file.InputStream.CopyTo(stream);
                list = spsHelper.ReadFromFile(list, stream);

                if (list.Entities.Count == 0)
                {
                    return new Result<ServiceResponse>(new ServiceResponse
                    {
                        Error = new ServiceError()
                        {
                            Code = "Exception",
                            Message = "Kiểm tra lại file"
                        }
                    });
                }

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
                        var saveFileResponse = new AisFileRepository().Create(uow, new SaveRequest<AisFileRow>
                        {
                            Entity = fileRow
                        });
                        if (saveFileResponse.EntityId.HasValue)
                        {
                            foreach (var item in list.Entities)
                            {
                                try
                                {
                                var saveresponse = new AisAddOURepository().Create(uow, new SaveRequest<AisAddOURow>
                                {
                                    Entity = item
                                });
                                if (saveresponse.EntityId.HasValue)
                                    new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                                    {
                                        Entity = new AisFileResultsRow
                                        {
                                            FileId = Convert.ToInt32(saveFileResponse.EntityId),
                                            ReqId = Convert.ToInt32(saveresponse.EntityId),
                                            ReqType = 3
                                        }
                                    });
                                }
                                catch (Exception ex)
                                {
                                    excep = 1;
                                }
                            }
                        }
                        return saveFileResponse;
                    }).Data;


                }
                if (!(Request.Headers["Accept"] ?? "").Contains("json"))
                    response.ContentType = "text/plain";
                ((UploadResponse)response.Data).UploadedFile = null;

                if (excep == 1)
                    response.Data.Error = new ServiceError()
                    {
                        Code = "Exception",
                        Message = "Kiểm tra lại file"
                    };

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
        public ActionResult MyAction()
        {
            var fileRowResponse = this.InTransaction("Default", (uow) =>
            {
                var saveFileResponse = new AisFileResultsRepository().Create(uow, new SaveRequest<AisFileResultsRow>
                {
                    Entity = new AisFileResultsRow
                    {
                        FileId = 1,
                        ReqId = 1,
                        ReqType = 0
                    }
                });
                var res1 = new GroupRepository().Create(uow, new SaveRequest<GroupRow>
                {
                    Entity = new GroupRow
                    {

                        Name = "tanhn",
                        Parent = "tanhn",
                        Shortname = "tanhn",
                        Priority = 1,
                        Status =  1
                
                    }
                });

               

                return saveFileResponse;
            });

            Result<ActionResult> res;
            res = new Result<ActionResult>(fileRowResponse);
            return res;
        }

        
    

        [AcceptVerbs("POST")]
        public ActionResult username()
        {

             return Json(Thread.CurrentPrincipal.Identity.Name, JsonRequestBehavior.AllowGet);
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
            var folderPath = HostingEnvironment.MapPath(UploadSettings.Current.Path + ((hasErr) ? "AisError" : "Ais"));
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