using Serenity;
using Serenity.Navigation;
using Administration = AccController.Administration.Pages;
using Common = AccController.Common.Pages;

[assembly: NavigationLink(1000, "Dashboard", url: "~/", permission: "", icon: "icon-speedometer")]

[assembly: NavigationMenu(2000, "Ais", icon: "icon-anchor")]
[assembly: NavigationLink(2001, "Ais/Group", typeof(AccController.Ais.Pages.GroupController))]
[assembly: NavigationLink(2002, "Ais/AisAddOU", typeof(AccController.Ais.Pages.AisAddOUController))]
[assembly: NavigationLink(2003, "Ais/AisUser", typeof(AccController.Ais.Pages.AisUserController))]
[assembly: NavigationLink(2004, "Ais/AisUserChangeInfo", typeof(AccController.Ais.Pages.AisUserChangeInfoController))]
[assembly: NavigationLink(2005, "Ais/AisUserChangeOU", typeof(AccController.Ais.Pages.AisUserChangeOUController))]
[assembly: NavigationLink(2006, "Ais/AisFile", typeof(AccController.Ais.Pages.AisFileController))]
[assembly: NavigationLink(2007, "Ais/AisFileResults", typeof(AccController.Ais.Pages.AisFileResultsController))]
[assembly: NavigationLink(2008, "Ais/AisLog", typeof(AccController.Ais.Pages.AisLogController))]
[assembly: NavigationMenu(3000, "Email", icon: "icon-anchor")]
[assembly: NavigationLink(3001, "Email/EmailNew", typeof(AccController.Email.Pages.EmailNewController))]
[assembly: NavigationLink(3002, "Email/EmailChange", typeof(AccController.Email.Pages.EmailChangeController))]
[assembly: NavigationLink(3003, "Email/EmailGroup", typeof(AccController.Email.Pages.EmailGroupController))]
[assembly: NavigationLink(3004, "Email/EmailUpdateInfo", typeof(AccController.Email.Pages.EmailUpdateInfoController))]
[assembly: NavigationLink(3005, "Email/EmailFile", typeof(AccController.Email.Pages.EmailFileController))]
[assembly: NavigationLink(3006, "Email/FileResult", typeof(AccController.Email.Pages.FileResultController))]
[assembly: NavigationLink(3007, "Email/EmailLog", typeof(AccController.Email.Pages.EmailLogController))]
//[assembly: NavigationMenu(8000, "Northwind", icon: "icon-anchor")]
//[assembly: NavigationLink(8200, "Northwind/Customers", typeof(Northwind.CustomerController), icon: "icon-wallet")]
//[assembly: NavigationLink(8200, "Northwind/Orders", typeof(Northwind.OrderController), icon: "icon-basket-loaded")]
//[assembly: NavigationLink(8300, "Northwind/Products", typeof(Northwind.ProductController), icon: "icon-present")]
//[assembly: NavigationLink(8400, "Northwind/Suppliers", typeof(Northwind.SupplierController), icon: "icon-magic-wand")]
//[assembly: NavigationLink(8500, "Northwind/Shippers", typeof(Northwind.ShipperController), icon: "icon-plane")]
//[assembly: NavigationLink(8600, "Northwind/Categories", typeof(Northwind.CategoryController), icon: "icon-folder-alt")]
//[assembly: NavigationLink(8700, "Northwind/Regions", typeof(Northwind.RegionController), icon: "icon-map")]
//[assembly: NavigationLink(8800, "Northwind/Territories", typeof(Northwind.TerritoryController), icon: "icon-puzzle")]

[assembly: NavigationMenu(9000, "Administration", icon: "icon-screen-desktop")]
[assembly: NavigationLink(9100, "Administration/Languages", typeof(Administration.LanguageController), icon: "icon-bubbles")]
[assembly: NavigationLink(9200, "Administration/Translations", typeof(Administration.TranslationController), icon: "icon-speech")]
[assembly: NavigationLink(9300, "Administration/Roles", typeof(Administration.RoleController), icon: "icon-lock")]
[assembly: NavigationLink(9400, "Administration/User Management", typeof(Administration.UserController), icon: "icon-users")]
