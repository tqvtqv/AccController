﻿
namespace AccController.Email.Endpoints
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System.Data;
    using System.Web.Mvc;
    using MyRepository = Repositories.EmailUpdateInfoRepository;
    using MyRow = Entities.EmailUpdateInfoRow;

    [RoutePrefix("Services/Email/EmailUpdateInfo"), Route("{action}")]
    [ConnectionKey("Default"), ServiceAuthorize("EmailUpdateInfo")]
    public class EmailUpdateInfoController : ServiceEndpoint
    {
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }
 
        [HttpPost]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyRepository().List(connection, request);
        }

        [AcceptVerbs("POST"), JsonFilter]
        public Result<SaveResponse> updateSubmit(SaveRequest<MyRow> para1)
        {
            var str = para1;
            return this.InTransaction("Default", (uow) =>
            {

                var saveFileResponse = new MyRepository().Update(uow, new SaveRequest<MyRow>
                {
                    Entity = new MyRow
                    {
                        Id = str.Entity.Id,
                        Submit = "1"

                    }
                });

                return saveFileResponse;
            });
        }
    }
}
