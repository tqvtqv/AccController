using FluentMigrator;

namespace AccController.Migrations.DefaultDB
{
    [Migration(11)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Alter.Table("AisUserChangeOU").InSchema("Acc")
                .AddColumn("OldJobtitle").AsString(100).Nullable();
            Alter.Table("AisUserChangeOU").InSchema("Acc")
              .AddColumn("OldRole").AsString(100).Nullable();

            //Alter.Table("EmailChange").InSchema("Acc")
            //   .AddColumn("By_User").AsString(100).NotNullable();
            //Alter.Table("EmailChange").InSchema("Acc")
            //  .AddColumn("Submit").AsString(10).Nullable();

            //Alter.Table("EmailUpdateInfo").InSchema("Acc")
            //   .AddColumn("By_User").AsString(100).NotNullable();
            //Alter.Table("EmailUpdateInfo").InSchema("Acc")
            //  .AddColumn("Submit").AsString(10).Nullable();

            //Alter.Table("EmailGroup").InSchema("Acc")
            //   .AddColumn("By_User").AsString(100).NotNullable();
            //Alter.Table("EmailGroup").InSchema("Acc")
            //  .AddColumn("Submit").AsString(10).Nullable();

            //Alter.Table("EmailGroupAccounts").InSchema("Acc")
            //   .AddColumn("By_User").AsString(100).NotNullable();
            //Alter.Table("EmailGroupAccounts").InSchema("Acc")
            //  .AddColumn("Submit").AsString(10).Nullable();
            //Delete.ForeignKey("FK_EmailGroupAccounts_GroupId").OnTable("EmailGroupAccounts").InSchema("Acc");
            //Delete.Column("GroupId").FromTable("EmailGroupAccounts").InSchema("Acc");
        }

        public override void Down()
        {
            //Delete.Table("EmailUpdateInfo").InSchema("Acc");
            Delete.Column("OldJobtitle").FromTable("AisUserChangeOU").InSchema("Acc");
            Delete.Column("OldRole").FromTable("AisUserChangeOU").InSchema("Acc");

            //Delete.Column("By_User").FromTable("EmailChange").InSchema("Acc");
            //Delete.Column("Submit").FromTable("EmailChange").InSchema("Acc");

            //Delete.Column("By_User").FromTable("EmailUpdateInfo").InSchema("Acc");
            //Delete.Column("Submit").FromTable("EmailUpdateInfo").InSchema("Acc");

            //Delete.Column("By_User").FromTable("EmailGroup").InSchema("Acc");
            //Delete.Column("Submit").FromTable("EmailGroup").InSchema("Acc");

            //Delete.Column("By_User").FromTable("EmailGroupAccounts").InSchema("Acc");
            //Delete.Column("Submit").FromTable("EmailGroupAccounts").InSchema("Acc");
        }

    }
}