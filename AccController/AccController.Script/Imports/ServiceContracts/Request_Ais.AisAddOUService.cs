
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class AisAddOUService
    {
        [InlineConstant] public const string BaseUrl = "Request_Ais/AisAddOU";
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisAddOU/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisAddOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisAddOU/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisAddOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisAddOU/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisAddOU/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisAddOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisAddOU/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisAddOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Request_Ais/AisAddOU/Create";
            [InlineConstant] public const string Update = "Request_Ais/AisAddOU/Update";
            [InlineConstant] public const string Delete = "Request_Ais/AisAddOU/Delete";
            [InlineConstant] public const string Retrieve = "Request_Ais/AisAddOU/Retrieve";
            [InlineConstant] public const string List = "Request_Ais/AisAddOU/List";
        }
    }
    
}

