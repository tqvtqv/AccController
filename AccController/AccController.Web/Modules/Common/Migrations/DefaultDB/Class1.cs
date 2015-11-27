using FluentMigrator;

namespace AccController.Migrations.DefaultDB
{
    [Migration(6)]
    public class Class1 : Migration
    {
        public override void Up()
        {
            Alter.Table("AisUserChangeOU").InSchema("Acc")
                .AddColumn("By_User").AsString(100).Nullable();
            Alter.Table("AisUserChangeOU").InSchema("Acc")
              .AddColumn("Submit").AsString(10).Nullable();
                
        }

        public override void Down()
        {
            //Delete.Table("EmailUpdateInfo").InSchema("Acc");
            Delete.Column("By_User").FromTable("AisUserChangeOU").InSchema("Acc");
            Delete.Column("Submit").FromTable("AisUserChangeOU").InSchema("Acc");
        }

    }
}