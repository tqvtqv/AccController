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

[assembly: NavigationMenu(4000, "Request_Ais", icon: "icon-screen-desktop")]
[assembly: NavigationLink(4001, "Request_Ais/Group", typeof(AccController.Request_Ais.Pages.GroupController))]


[assembly: NavigationMenu(9000, "Administration", icon: "icon-screen-desktop")]
[assembly: NavigationLink(9300, "Administration/Roles", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9400, "Administration/User Management", typeof(Administration.UserController), icon: "icon-users")]
