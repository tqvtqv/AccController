
namespace AccController.Ais
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
        [InlineConstant] public const string BaseUrl = "Ais/AisAddOU";
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisAddOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisAddOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisAddOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisAddOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisAddOU/updategroup', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updategroup(SaveRequest<AisAddOURow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisAddOU/Create";
            [InlineConstant] public const string Update = "Ais/AisAddOU/Update";
            [InlineConstant] public const string Delete = "Ais/AisAddOU/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisAddOU/Retrieve";
            [InlineConstant] public const string List = "Ais/AisAddOU/List";
            [InlineConstant] public const string updategroup = "Ais/AisAddOU/updategroup";
        }
    }
    
}

