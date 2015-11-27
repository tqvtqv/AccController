namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class EmailChangeService
    {
        [InlineConstant] public const string BaseUrl = "Email/EmailChange";
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<EmailChangeRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<EmailChangeRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<EmailChangeRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<EmailChangeRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailChange/updateSubmit', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updateSubmit(SaveRequest<EmailChangeRow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Email/EmailChange/Create";
            [InlineConstant] public const string Update = "Email/EmailChange/Update";
            [InlineConstant] public const string Delete = "Email/EmailChange/Delete";
            [InlineConstant] public const string Retrieve = "Email/EmailChange/Retrieve";
            [InlineConstant] public const string List = "Email/EmailChange/List";
            [InlineConstant] public const string updateSubmit = "Email/EmailChange/updateSubmit";
        }
    }
    
}

