namespace AccController.Ais
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public partial class AisUserChangeOUService
    {
        [InlineConstant] public const string BaseUrl = "Ais/AisUserChangeOU";
    
        public static jQueryXmlHttpRequest Create(SaveRequest<AisUserChangeOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Create, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Update(SaveRequest<AisUserChangeOURow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Update, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Delete, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<AisUserChangeOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.Retrieve, request, onSuccess, options);
        }
    
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<AisUserChangeOURow>> onSuccess, ServiceCallOptions options = null)
        {
            return Q.ServiceRequest(Methods.List, request, onSuccess, options);
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Ais/AisUserChangeOU/Create";
            [InlineConstant] public const string Update = "Ais/AisUserChangeOU/Update";
            [InlineConstant] public const string Delete = "Ais/AisUserChangeOU/Delete";
            [InlineConstant] public const string Retrieve = "Ais/AisUserChangeOU/Retrieve";
            [InlineConstant] public const string List = "Ais/AisUserChangeOU/List";
        }
    }
    
}

