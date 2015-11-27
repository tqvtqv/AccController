using FluentMigrator;
using System;

namespace AccController.Migrations.DefaultDB
{
    [Migration(20151029095400)]
    public class DefaultDB_20151029_095400_AccControllers : Migration
    {
        protected string AccSchema = "Acc";
        public override void Up()
        {
            Create.Schema(AccSchema);
            #region AIS Requests
            Create.Table("AisGroup").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(150).NotNullable()//Ten phong ban
                .WithColumn("Parent").AsString(150).NotNullable()//Truc thuoc phong ban
                .WithColumn("Category").AsString(150).Nullable()//Nhom co quan
                .WithColumn("Shortname").AsString(50).NotNullable()//Ten viet tat
                .WithColumn("Relate").AsString(150).Nullable()//Don vi dong nhan van ban
                .WithColumn("Priority").AsInt16().NotNullable().WithDefaultValue(0)//Muc uu tien
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
               ;
            Create.Table("AisUser").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("OU").AsString(255).NotNullable()
                .WithColumn("Email").AsString(150).NotNullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Mobile").AsString(50).Nullable()
                .WithColumn("Jobtitle").AsString(150).Nullable()
                .WithColumn("Role").AsString(150).Nullable()
                .WithColumn("Priority").AsInt32().NotNullable().WithDefaultValue(0)
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;


            Create.Table("AisUserChangeOU").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Email").AsString(150).NotNullable()
                .WithColumn("OldOU").AsString(255).Nullable()
                .WithColumn("NewOU").AsString(255).Nullable()
                .WithColumn("NewJobtitle").AsString(150).Nullable()
                .WithColumn("NewRole").AsString(150).Nullable()
                .WithColumn("Priority").AsInt32()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;

            Create.Table("AisUserChangeInfo").InSchema(AccSchema)
               .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Email").AsString(150).NotNullable()
               .WithColumn("Phone").AsString(50).Nullable()
               .WithColumn("Mobile").AsString(50).Nullable()
               .WithColumn("Jobtitle").AsString(150).Nullable()
               //.WithColumn("Role").AsString(50).Nullable()
               //.WithColumn("Priority").AsInt32()
               .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("LastUpdated").AsDateTime().NotNullable()
               .WithColumn("LastUpdatedby").AsString(50).NotNullable()
               .WithColumn("Description").AsString(255).Nullable()
               ;

            Create.Table("AisUserAddOU").InSchema(AccSchema)
              .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
              .WithColumn("Email").AsString(150).NotNullable()
              .WithColumn("NewOU").AsString(255).Nullable()
              .WithColumn("NewJobtitle").AsString(150).Nullable()
              .WithColumn("NewRole").AsString(150).Nullable()
              //.WithColumn("Role").AsString(50).Nullable()
              .WithColumn("Priority").AsInt32().NotNullable().WithDefaultValue(0)
              .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
              .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
              .WithColumn("LastUpdated").AsDateTime().NotNullable()
              .WithColumn("LastUpdatedby").AsString(50).NotNullable()
              .WithColumn("Description").AsString(255).Nullable()
              ;

            Create.Table("AisFiles").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("FileName").AsString(150).NotNullable()
                .WithColumn("FileSize").AsInt32().NotNullable()
                .WithColumn("ContentType").AsString(150).NotNullable()
                .WithColumn("FilePath").AsString(255).Nullable()
                .WithColumn("Uploaded").AsDateTime().Nullable()
                .WithColumn("UploadedBy").AsString(50).Nullable()
                ;
            Create.Table("AisFileResults").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("FileId").AsInt32().NotNullable()
                .WithColumn("ReqId").AsInt32().NotNullable()
                .WithColumn("ReqType").AsInt16().NotNullable()
                ;
            Create.Table("AisLog").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("LogType").AsInt16().NotNullable()
                .WithColumn("ItemId").AsInt32().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
               ;
            #endregion
            #region Email Request
            Create.Table("EmailNew").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("Alias").AsString(150).NotNullable()
                .WithColumn("Password").AsString(150).Nullable()
                .WithColumn("Displayname").AsString(150).Nullable()
                .WithColumn("Firstname").AsString(90).NotNullable()
                .WithColumn("Lastname").AsString(60).NotNullable()
                .WithColumn("JobTitle").AsString(150).NotNullable()
                .WithColumn("Department").AsString(255).Nullable()
                .WithColumn("Company").AsString(255).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Mobile").AsString(50).Nullable()
                .WithColumn("Birthday").AsDateTime().Nullable()
                .WithColumn("OU").AsString(255).Nullable()
                .WithColumn("UserPrincipal").AsString(150).NotNullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;
            Create.Table("EmailChange").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("OldName").AsString(50).NotNullable()
                .WithColumn("NewName").AsString(50).NotNullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;
            Create.Table("EmailUpdateInfo").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Account").AsString(50).NotNullable()
                .WithColumn("Name").AsString(150).NotNullable()
                .WithColumn("JobTitle").AsString(150).NotNullable()
                .WithColumn("Department").AsString(255).Nullable()
                .WithColumn("Company").AsString(255).Nullable()
                .WithColumn("Phone").AsString(50).Nullable()
                .WithColumn("Mobile").AsString(50).Nullable()
                .WithColumn("Birthday").AsDateTime().Nullable()
                .WithColumn("OU").AsString(255).Nullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;
            Create.Table("EmailGroup").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Alias").AsString(50).NotNullable()
                .WithColumn("Displayname").AsString(150).NotNullable()
                .WithColumn("OU").AsString(255).NotNullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(1)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
                ;
            Create.Table("EmailGroupAccounts").InSchema(AccSchema)
               .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
               .WithColumn("Alias").AsString(100).NotNullable()
               .WithColumn("Account").AsString(50).NotNullable()
               .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
               .WithColumn("LastUpdated").AsDateTime().NotNullable()
               .WithColumn("LastUpdatedby").AsString(50).NotNullable()
               .WithColumn("Description").AsString(255).Nullable()
               ;
            //Create.ForeignKey("FK_EmailGroupAccounts_GroupId")
            //    .FromTable("EmailGroupAccounts").InSchema(AccSchema)
            //    .ForeignColumn("GroupId")
            //    .ToTable("EmailGroup").InSchema(AccSchema)
            //    .PrimaryColumn("Id");

            Create.Table("EmailFiles").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("FileName").AsString(150).NotNullable()
                .WithColumn("FileSize").AsInt32().NotNullable()
                .WithColumn("ContentType").AsString(150).NotNullable()
                .WithColumn("FilePath").AsString(255).NotNullable()
                .WithColumn("Uploaded").AsDateTime().NotNullable()
                .WithColumn("UploadedBy").AsString(50).NotNullable()
               ;
            Create.Table("EmailFileResults").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("FileId").AsInt32().NotNullable()
                .WithColumn("ReqId").AsInt32().NotNullable()
                .WithColumn("ReqType").AsInt16().NotNullable()
                ;
            Create.Table("EmailLog").InSchema(AccSchema)
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("LogType").AsInt16().NotNullable()
                .WithColumn("ItemId").AsInt32().NotNullable()
                .WithColumn("Status").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("Result").AsInt16().NotNullable().WithDefaultValue(0)
                .WithColumn("LastUpdated").AsDateTime().NotNullable()
                .WithColumn("LastUpdatedby").AsString(50).NotNullable()
                .WithColumn("Description").AsString(255).Nullable()
               ;
            #endregion

        }

        public override void Down()
        {
            Delete.ForeignKey("FK_EmailGroupAccounts_GroupId");
            Delete.Table("AisGroup").InSchema(AccSchema);
            Delete.Table("AisUser").InSchema(AccSchema);
            Delete.Table("AisUserChangeOU").InSchema(AccSchema);
            Delete.Table("AisUserChangeInfo").InSchema(AccSchema);
            Delete.Table("AisUserAddOU").InSchema(AccSchema);
            Delete.Table("AisFiles").InSchema(AccSchema);
            Delete.Table("AisFileResults").InSchema(AccSchema);
            Delete.Table("AisLog").InSchema(AccSchema);
            Delete.Table("EmailNew").InSchema(AccSchema);
            Delete.Table("EmailChange").InSchema(AccSchema);
            Delete.Table("EmailUpdateInfo").InSchema(AccSchema);
            Delete.Table("EmailGroup").InSchema(AccSchema);
            Delete.Table("EmailGroupAccounts").InSchema(AccSchema);
            Delete.Table("EmailFiles").InSchema(AccSchema);
            Delete.Table("EmailFileResults").InSchema(AccSchema);
            Delete.Table("EmailLog").InSchema(AccSchema);
            Delete.Schema(AccSchema);
        }
    }
}