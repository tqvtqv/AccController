using Serenity;
using Serenity.Navigation;
using Administration = AccController.Administration.Pages;
using Common = AccController.Common.Pages;

[assembly: NavigationLink(1000, "Trang chủ", url: "~/", permission: "", icon: "icon-speedometer")]

[assembly: NavigationMenu(2000, "Ais", icon: "icon-anchor")]
[assembly: NavigationLink(2001, "Ais/Tạo mới đơn vị", typeof(AccController.Ais.Pages.GroupController))]
[assembly: NavigationLink(2002, "Ais/Thêm đơn vị cho tài khoản", typeof(AccController.Ais.Pages.AisAddOUController))]
[assembly: NavigationLink(2003, "Ais/Tạo mới tài khoản", typeof(AccController.Ais.Pages.AisUserController))]
[assembly: NavigationLink(2004, "Ais/Cập nhật thông tin tài khoản", typeof(AccController.Ais.Pages.AisUserChangeInfoController))]
[assembly: NavigationLink(2005, "Ais/Cập nhật đơn vị tài khoản", typeof(AccController.Ais.Pages.AisUserChangeOUController))]
//[assembly: NavigationLink(2006, "Ais/AisFile", typeof(AccController.Ais.Pages.AisFileController))]
//[assembly: NavigationLink(2007, "Ais/AisFileResults", typeof(AccController.Ais.Pages.AisFileResultsController))]
//[assembly: NavigationLink(2008, "Ais/AisLog", typeof(AccController.Ais.Pages.AisLogController))]
[assembly: NavigationMenu(3000, "Email", icon: "icon-anchor")]
[assembly: NavigationLink(3001, "Email/Tạo mới tài khoản", typeof(AccController.Email.Pages.EmailNewController))]
[assembly: NavigationLink(3002, "Email/Thay đổi tài khoản", typeof(AccController.Email.Pages.EmailChangeController))]
[assembly: NavigationLink(3003, "Email/Tạo nhóm email", typeof(AccController.Email.Pages.EmailGroupController))]
[assembly: NavigationLink(3004, "Email/Phân nhóm tài khoản", typeof(AccController.Email.Pages.EmailGroupAccountController))]
//[assembly: NavigationLink(3005, "Email/Cập nhật thông tin", typeof(AccController.Email.Pages.EmailUpdateInfoController))]
//[assembly: NavigationLink(3005, "Email/EmailFile", typeof(AccController.Email.Pages.EmailFileController))]
//[assembly: NavigationLink(3006, "Email/FileResult", typeof(AccController.Email.Pages.FileResultController))]
//[assembly: NavigationLink(3007, "Email/EmailLog", typeof(AccController.Email.Pages.EmailLogController))]

[assembly: NavigationMenu(4000, "Request_Ais", icon: "icon-anchor")]
[assembly: NavigationLink(4001, "Request_Ais/Tạo mới đơn vị", typeof(AccController.Request_Ais.Pages.GroupController))]
[assembly: NavigationLink(4002, "Request_Ais/Thêm đơn vị cho tài khoản", typeof(AccController.Request_Ais.Pages.AisAddOUController))]
[assembly: NavigationLink(4003, "Request_Ais/Tạo mới tài khoản", typeof(AccController.Request_Ais.Pages.AisUserController))]
[assembly: NavigationLink(4004, "Request_Ais/Cập nhật thông tin tài khoản", typeof(AccController.Request_Ais.Pages.AisUserChangeInfoController))]
[assembly: NavigationLink(4005, "Request_Ais/Cập nhập đơn vị tài khoản", typeof(AccController.Request_Ais.Pages.AisUserChangeOUController))]

[assembly: NavigationMenu(5000, "Request_Email", icon: "icon-anchor")]
[assembly: NavigationLink(5001, "Request_Email/Tạo mới tài khoản", typeof(AccController.Request_Email.Pages.EmailNewController))]
[assembly: NavigationLink(5002, "Request_Email/Thay đổi tài khoản", typeof(AccController.Request_Email.Pages.EmailChangeController))]
[assembly: NavigationLink(5003, "Request_Email/Tạo nhóm email", typeof(AccController.Request_Email.Pages.EmailGroupController))]
[assembly: NavigationLink(5004, "Request_Email/Phân nhóm tài khoản", typeof(AccController.Request_Email.Pages.EmailGroupAccountController))]
[assembly: NavigationLink(5005, "Request_Email/Cập nhật thông tin", typeof(AccController.Request_Email.Pages.EmailUpdateInfoController))]

[assembly: NavigationMenu(9000, "Administration", icon: "icon-screen-desktop")]
[assembly: NavigationLink(9300, "Administration/Phân nhóm quyền", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9400, "Administration/Phân cấp admin", typeof(AccController.SubAdmin.Pages.SubAdminController),icon: "icon-lock")]
[assembly: NavigationLink(9500, "Administration/Người dùng", typeof(Administration.UserController), icon: "icon-users")]
[assembly: NavigationLink(9600, "Administration/Sub Admin", typeof(AccController.SubAdmin.Pages.UsersController),icon: "icon-users")]
