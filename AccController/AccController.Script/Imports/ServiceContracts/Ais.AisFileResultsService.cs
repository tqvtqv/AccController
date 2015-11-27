namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class AisFileResultsService
    {
        [InlineConstant] public const string BaseUrl = "Ais/AisFileResults";
    
        [InlineCode("Q.serviceRequest('Ais/AisFileResults/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisFileResultsRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisFileResults/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisFileResultsRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisFileResults/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisFileResults/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisFileResultsRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisFileResults/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisFileResultsRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisFileResults/Create";
            [InlineConstant] public const string Update = "Ais/AisFileResults/Update";
            [InlineConstant] public const string Delete = "Ais/AisFileResults/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisFileResults/Retrieve";
            [InlineConstant] public const string List = "Ais/AisFileResults/List";
        }
    }
    
}

