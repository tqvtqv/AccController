namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class AisUserChangeOUService
    {
        [InlineConstant] public const string BaseUrl = "Ais/AisUserChangeOU";
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisUserChangeOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisUserChangeOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisUserChangeOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisUserChangeOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeOU/updateuserchangeOU', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updateuserchangeOU(SaveRequest<AisUserChangeOURow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisUserChangeOU/Create";
            [InlineConstant] public const string Update = "Ais/AisUserChangeOU/Update";
            [InlineConstant] public const string Delete = "Ais/AisUserChangeOU/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisUserChangeOU/Retrieve";
            [InlineConstant] public const string List = "Ais/AisUserChangeOU/List";
            [InlineConstant] public const string updateuserchangeOU = "Ais/AisUserChangeOU/updateuserchangeOU";
        }
    }
    
}

