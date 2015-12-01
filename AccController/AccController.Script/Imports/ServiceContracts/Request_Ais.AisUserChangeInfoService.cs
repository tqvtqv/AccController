
namespace AccController.Request_Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class AisUserChangeInfoService
    {
        [InlineConstant] public const string BaseUrl = "Request_Ais/AisUserChangeInfo";
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisUserChangeInfo/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisUserChangeInfo/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisUserChangeInfo/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisUserChangeInfo/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Request_Ais/AisUserChangeInfo/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Request_Ais/AisUserChangeInfo/Create";
            [InlineConstant] public const string Update = "Request_Ais/AisUserChangeInfo/Update";
            [InlineConstant] public const string Delete = "Request_Ais/AisUserChangeInfo/Delete";
            [InlineConstant] public const string Retrieve = "Request_Ais/AisUserChangeInfo/Retrieve";
            [InlineConstant] public const string List = "Request_Ais/AisUserChangeInfo/List";
        }
    }
    
}

