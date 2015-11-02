namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public partial class AisUserChangeInfoService
    {
        [InlineConstant] public const string BaseUrl = "Ais/AisUserChangeInfo";
    
        public static jQueryXmlHttpRequest Create(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Create, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Update(SaveRequest<AisUserChangeInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Update, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Delete, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Retrieve, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisUserChangeInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.List, request, onSuccess, options);
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisUserChangeInfo/Create";
            [InlineConstant] public const string Update = "Ais/AisUserChangeInfo/Update";
            [InlineConstant] public const string Delete = "Ais/AisUserChangeInfo/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisUserChangeInfo/Retrieve";
            [InlineConstant] public const string List = "Ais/AisUserChangeInfo/List";
        }
    }
    
}

