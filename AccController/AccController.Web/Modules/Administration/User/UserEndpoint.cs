

namespace AccController.Administration.Endpoints
{
    using AccController.Administration.Entities;
    using AccController.Administration.Repositories;
    using Serenity.Services;
    using System.Web.Mvc;
    using MyRepository = Repositories.UserRepository;
    using MyRow = Entities.UserRow;

    [ServiceAuthorize]
    [RoutePrefix("Services/Administration/User"), Route("{action}")]
    public class UserController : Controller
    {
        [AcceptVerbs("POST"), JsonFilter]
        public Result<SaveResponse> Create(SaveRequest<MyRow> request)
        {
            return this.InTransaction("Default", (uow) => new MyRepository().Create(uow, request));
        }


        [AcceptVerbs("POST"), JsonFilter]
        public Result<SaveResponse> updateuser(SaveRequest<MyRow> para1)
        {
            var str = para1;
            return this.InTransaction("Default", (uow) =>
            {

                UserRetrieveService RequestUser = new UserRetrieveService();
                var thisUser = RequestUser.ByUsername(this.User.Identity.Name);

                var saveFileResponse = new UserRepository().Update(uow, new SaveRequest<MyRow>
                {
                    Entity = new MyRow
                    {
                        UserId = str.Entity.UserId,
                        AdminLv = 1
                        
                    }
                });

                return saveFileResponse;
            });

        }

        [AcceptVerbs("POST"), JsonFilter]
        public Result<SaveResponse> Update(SaveRequest<MyRow> request)
        {
            return this.InTransaction("Default", (uow) => new MyRepository().Update(uow, request));
        }

        [AcceptVerbs("POST"), JsonFilter]
        public Result<DeleteResponse> Delete(DeleteRequest request)
        {
            return this.InTransaction("Default", (uow) => new MyRepository().Delete(uow, request));
        }

        [AcceptVerbs("POST"), JsonFilter]
        public Result<UndeleteResponse> Undelete(UndeleteRequest request)
        {
            return this.InTransaction("Default", (uow) => new MyRepository().Undelete(uow, request));
        }

        [AcceptVerbs("GET", "POST"), JsonFilter]
        public Result<RetrieveResponse<MyRow>> Retrieve(RetrieveRequest request)
        {
            return this.UseConnection("Default", (cnn) => new MyRepository().Retrieve(cnn, request));
        }

        [AcceptVerbs("GET", "POST"), JsonFilter]
        public Result<ListResponse<MyRow>> List(ListRequest request)
        {
            return this.UseConnection("Default", (cnn) => new MyRepository().List(cnn, request));
        }
    }
}
