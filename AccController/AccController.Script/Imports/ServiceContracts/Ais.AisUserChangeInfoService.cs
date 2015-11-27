namespace AccController.Ais
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
        [InlineConstant] public const string BaseUrl = "Ais/AisUserChangeInfo";
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Ais/AisUserChangeInfo/updateuserchangeinfo', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updateuserchangeinfo(SaveRequest<AisUserChangeInfoRow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisUserChangeInfo/Create";
            [InlineConstant] public const string Update = "Ais/AisUserChangeInfo/Update";
            [InlineConstant] public const string Delete = "Ais/AisUserChangeInfo/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisUserChangeInfo/Retrieve";
            [InlineConstant] public const string List = "Ais/AisUserChangeInfo/List";
            [InlineConstant] public const string updateuserchangeinfo = "Ais/AisUserChangeInfo/updateuserchangeinfo";
        }
    }
    
}

