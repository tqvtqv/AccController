
namespace AccController.Ais.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("AisUserAddOU"), InstanceName("AisUserAddOU"), TwoLevelCached]
    [ReadPermission("AisAddOU")]
    [ModifyPermission("AisAddOU")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class AisAddOURow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Email"), Size(150), NotNull, QuickSearch]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Đơn vị mới"), Column("NewOU"), Size(255), NotNull]
        public String NewOu
        {
            get { return Fields.NewOu[this]; }
            set { Fields.NewOu[this] = value; }
        }

        [DisplayName("Chức vụ mới"), Size(150)]
        public String NewJobtitle
        {
            get { return Fields.NewJobtitle[this]; }
            set { Fields.NewJobtitle[this] = value; }
        }

        [DisplayName("Quyền mới"), Size(150)]
        public String NewRole
        {
            get { return Fields.NewRole[this]; }
            set { Fields.NewRole[this] = value; }
        }

        [DisplayName("Mức ưu tiên")]
        public Int32? Priority
        {
            get { return Fields.Priority[this]; }
            set { Fields.Priority[this] = value; }
        }

        [DisplayName("Status"), NotNull]
        public Int16? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        [DisplayName("Result")]
        public Int16? Result
        {
            get { return Fields.Result[this]; }
            set { Fields.Result[this] = value; }
        }

        [DisplayName("Last Updated"), NotNull]
        public DateTime? LastUpdated
        {
            get { return Fields.LastUpdated[this]; }
            set { Fields.LastUpdated[this] = value; }
        }

        [DisplayName("Last Updatedby"), Size(50), NotNull]
        public String LastUpdatedby
        {
            get { return Fields.LastUpdatedby[this]; }
            set { Fields.LastUpdatedby[this] = value; }
        }

        [DisplayName("Description"), Size(255)]
        public String Description
        {
            get { return Fields.Description[this]; }
            set { Fields.Description[this] = value; }
        }

        [DisplayName("By_User"), Size(50), NotNull]
        public String By_User
        {
            get { return Fields.By_User[this]; }
            set { Fields.By_User[this] = value; }
        }

        [DisplayName("Submit"), Size(50), NotNull]
        public String Submit
        {
            get { return Fields.Submit[this]; }
            set { Fields.Submit[this] = value; }
        }
        [DisplayName("By_SubAdmin"), Size(50), NotNull]
        public Int32? By_SubAdmin
        {
            get { return Fields.By_SubAdmin[this]; }
            set { Fields.By_SubAdmin[this] = value; }
        }
        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Email; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AisAddOURow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Email;
            public readonly StringField NewOu;
            public readonly StringField NewJobtitle;
            public readonly StringField NewRole;
            public readonly Int32Field Priority;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField By_User;
            public readonly StringField Submit;
            public readonly Int32Field By_SubAdmin;
            public RowFields()
                : base("[Acc].AisUserAddOU")
            {
                LocalTextPrefix = "Ais.AisAddOU";
            }
        }
    }
}