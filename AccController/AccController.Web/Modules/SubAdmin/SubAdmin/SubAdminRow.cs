
namespace AccController.SubAdmin.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("SubAdmin"), InstanceName("SubAdmin"), TwoLevelCached]
    [ReadPermission("SubAdministration")]
    [ModifyPermission("SubAdministration")]
    [JsonConverter(typeof(JsonRowConverter))]
    [LookupScript("SubAdmin.SubAdmin")]
    public sealed class SubAdminRow : Row, IIdRow, INameRow
    {
        [DisplayName("Admin Lv"), Column("Admin_lv"), Identity]
        public Int32? AdminLv
        {
            get { return Fields.AdminLv[this]; }
            set { Fields.AdminLv[this] = value; }
        }

        [DisplayName("Name"), Size(150), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.AdminLv; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public SubAdminRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field AdminLv;
            public readonly StringField Name;

            public RowFields()
                : base("[Acc].SubAdmin")
            {
                LocalTextPrefix = "SubAdmin.SubAdmin";
            }
        }
    }
}