using FluentMigrator;

namespace AccController.Migrations.DefaultDB
{
    [Migration(33)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            //Alter.Table("AisUserChangeOU").InSchema("Acc")
            //    .AddColumn("OldJobtitle").AsString(100).Nullable();
            Alter.Table("AisUser").InSchema("Acc")
              .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("AisUserChangeOU").InSchema("Acc")
                 .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("AisUserChangeInfo").InSchema("Acc")
          .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("AisUserAddOU").InSchema("Acc")
          .AddColumn("By_SubAdmin").AsInt32().Nullable();

            Alter.Table("EmailNew").InSchema("Acc")
        .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("EmailChange").InSchema("Acc")
        .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("EmailUpdateInfo").InSchema("Acc")
        .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("EmailGroup").InSchema("Acc")
        .AddColumn("By_SubAdmin").AsInt32().Nullable();
            Alter.Table("EmailGroupAccounts").InSchema("Acc")
     .AddColumn("By_SubAdmin").AsInt32().Nullable();
        }

        public override void Down()
        {
            //Delete.Table("EmailUpdateInfo").InSchema("Acc");
            //Delete.Column("OldJobtitle").FromTable("AisUserChangeOU").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("AisUser").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("AisUserChangeOU").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("AisUserChangeInfo").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("AisUserAddOU").InSchema("Acc");

            Delete.Column("By_SubAdmin").FromTable("EmailNew").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("EmailChange").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("EmailUpdateInfo").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("EmailGroup").InSchema("Acc");
            Delete.Column("By_SubAdmin").FromTable("EmailGroupAccounts").InSchema("Acc");
        }

    }
}