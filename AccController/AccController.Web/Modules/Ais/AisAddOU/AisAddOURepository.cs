﻿

namespace AccController.Ais.Repositories
{
    using Serenity;
    using Serenity.Data;
    using Serenity.Services;
    using System;
    using System.Data;
    using System.Threading;
    using MyRow = Entities.AisAddOURow;

    public class AisAddOURepository
    {
        private static MyRow.RowFields fld { get { return MyRow.Fields; } }

        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            request.Entity.Submit = "0";
            request.Entity.By_User = Thread.CurrentPrincipal.Identity.Name;
            request.Entity.Result = 0;
            request.Entity.LastUpdatedby = Thread.CurrentPrincipal.Identity.Name;
            request.Entity.LastUpdated = DateTime.Now;
            request.Entity.Status = 0;
            return new MySaveHandler().Process(uow, request, SaveRequestType.Create);
        }

        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            request.Entity.LastUpdatedby = Thread.CurrentPrincipal.Identity.Name;
            request.Entity.LastUpdated = DateTime.Now;
            return new MySaveHandler().Process(uow, request, SaveRequestType.Update);
        }

        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyDeleteHandler().Process(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRetrieveHandler().Process(connection, request);
        }

        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            return new MyListHandler().Process(connection, request);
        }

        private class MySaveHandler : SaveRequestHandler<MyRow> { }
        private class MyDeleteHandler : DeleteRequestHandler<MyRow> { }
        private class MyRetrieveHandler : RetrieveRequestHandler<MyRow> { }
        private class MyListHandler : ListRequestHandler<MyRow> { }
    }
}