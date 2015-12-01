namespace AccController.Email
{
    using jQueryApi;
    using Serenity;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [Imported, PreserveMemberCase]
    public partial class EmailGroupAccountService
    {
        [InlineConstant] public const string BaseUrl = "Email/EmailGroupAccount";
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/Create', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Create(SaveRequest<EmailGroupAccountRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/Update', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Update(SaveRequest<EmailGroupAccountRow> request, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/Delete', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Delete(DeleteRequest request, Action<DeleteResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/Retrieve', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest Retrieve(RetrieveRequest request, Action<RetrieveResponse<EmailGroupAccountRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/List', {request}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest List(ListRequest request, Action<ListResponse<EmailGroupAccountRow>> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [InlineCode("Q.serviceRequest('Email/EmailGroupAccount/updateSubmit', {para1}, {onSuccess}, {options})")]
        public static jQueryXmlHttpRequest updateSubmit(SaveRequest<EmailGroupAccountRow> para1, Action<SaveResponse> onSuccess, ServiceCallOptions options = null)
        {
            return null;
        }
    
        [Imported, PreserveMemberCase]
        public static class Methods
        {
            [InlineConstant] public const string Create = "Email/EmailGroupAccount/Create";
            [InlineConstant] public const string Update = "Email/EmailGroupAccount/Update";
            [InlineConstant] public const string Delete = "Email/EmailGroupAccount/Delete";
            [InlineConstant] public const string Retrieve = "Email/EmailGroupAccount/Retrieve";
            [InlineConstant] public const string List = "Email/EmailGroupAccount/List";
            [InlineConstant] public const string updateSubmit = "Email/EmailGroupAccount/updateSubmit";
        }
    }
    
}

