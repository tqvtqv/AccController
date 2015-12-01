
namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class EmailUpdateInfoService
    {
        [InlineConstant] public const string BaseUrl = "Email/EmailUpdateInfo";
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<EmailUpdateInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<EmailUpdateInfoRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<EmailUpdateInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<EmailUpdateInfoRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailUpdateInfo/updateSubmit', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updateSubmit(SaveRequest<EmailUpdateInfoRow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Email/EmailUpdateInfo/Create";
            [InlineConstant] public const string Update = "Email/EmailUpdateInfo/Update";
            [InlineConstant] public const string Delete = "Email/EmailUpdateInfo/Delete";
            [InlineConstant] public const string Retrieve = "Email/EmailUpdateInfo/Retrieve";
            [InlineConstant] public const string List = "Email/EmailUpdateInfo/List";
            [InlineConstant] public const string updateSubmit = "Email/EmailUpdateInfo/updateSubmit";
        }
    }
    
}

