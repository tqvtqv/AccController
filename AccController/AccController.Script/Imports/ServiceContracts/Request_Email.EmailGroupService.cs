
namespace AccController.Request_Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class EmailGroupService
    {
        [InlineConstant] public const string BaseUrl = "Request_Email/EmailGroup";
    
        [InlineCode("Q.serviceRequest('Request_Email/EmailGroup/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<EmailGroupRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Email/EmailGroup/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<EmailGroupRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Email/EmailGroup/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Email/EmailGroup/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<EmailGroupRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Email/EmailGroup/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<EmailGroupRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Request_Email/EmailGroup/Create";
            [InlineConstant] public const string Update = "Request_Email/EmailGroup/Update";
            [InlineConstant] public const string Delete = "Request_Email/EmailGroup/Delete";
            [InlineConstant] public const string Retrieve = "Request_Email/EmailGroup/Retrieve";
            [InlineConstant] public const string List = "Request_Email/EmailGroup/List";
        }
    }
    
}

