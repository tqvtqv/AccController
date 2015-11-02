﻿
namespace AccController.Ais
{
    using Administration;
    using jQueryApi;
    using jQueryApi.UI.Widgets;
    using Serenity;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    [IdProperty("Id"), NameProperty("FileName")]
    [FormKey("Ais.AisFile"), LocalTextPrefix("Ais.AisFile"), Service("Ais/AisFile")]
    public class AisFileDialog : EntityDialog<AisFileRow>
    {
        //private RoleCheckEditor permissions;
        ////public AisFileDialog(AisFileRow opt) : base(opt)
        ////{
        ////    //permissions = new RoleCheckEditor(this.ById("Roles"));
        ////    //UserRoleService.List(new UserRoleListRequest
        ////    //{
        ////    //    UserID = options.UserID,
        ////    //}, response =>
        ////    //{
        ////    //    permissions.Value = response.Entities.Select(x => x.ToString()).ToList();
        ////    //});
        ////}
        //protected override DialogOptions GetDialogOptions()
        //{
        //    var opt = base.GetDialogOptions();
        //    opt.Buttons = new List<DialogButton>
        //    {
        //        new DialogButton {
        //            Text = Q.Text("Dialogs.OkButton"),
        //            Click = delegate
        //            {
        //                //UserRoleService.Update(new UserRoleUpdateRequest
        //                //{
        //                //    UserID = options.UserID,
        //                //    Roles = permissions.Value.Select(x => Int32.Parse(x, 10)).ToList(),
        //                //}, response => {
        //                //    DialogClose();
        //                //    Window.SetTimeout(delegate()
        //                //    {
        //                //        Q.NotifySuccess(Q.Text("Site.UserRoleDialog.SaveSuccess"));
        //                //    }, 0);
        //                //});
        //            },
        //        },
        //        new DialogButton {
        //            Text = Q.Text("Dialogs.CancelButton"),
        //            Click = DialogClose
        //        }
        //    };
        //    //opt.Title = String.Format(Q.Text("Site.UserRoleDialog.DialogTitle"), options.Username);
        //    return opt;
        //}

        //protected override string GetTemplate()
        //{
        //    return "<div id='~_Roles'></div>";
        //}
    }

    
}