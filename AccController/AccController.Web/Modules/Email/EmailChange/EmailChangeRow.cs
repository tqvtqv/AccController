
namespace AccController.Email.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("EmailChange"), InstanceName("EmailChange"), TwoLevelCached]
    [ReadPermission("Email")]
    [ModifyPermission("Email")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailChangeRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Old Name"), Size(50), NotNull, QuickSearch]
        public String OldName
        {
            get { return Fields.OldName[this]; }
            set { Fields.OldName[this] = value; }
        }

        [DisplayName("New Name"), Size(50), NotNull]
        public String NewName
        {
            get { return Fields.NewName[this]; }
            set { Fields.NewName[this] = value; }
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
        [DisplayName("By_SubAdmin"), Size(50), NotNull]
        public Int32? By_SubAdmin
        {
            get { return Fields.By_SubAdmin[this]; }
            set { Fields.By_SubAdmin[this] = value; }
        }
        [DisplayName("Submit"), Size(50), NotNull]
        public String Submit
        {
            get { return Fields.Submit[this]; }
            set { Fields.Submit[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.OldName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmailChangeRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField OldName;
            public readonly StringField NewName;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField By_User;
            public readonly StringField Submit;
            public readonly Int32Field By_SubAdmin;
            public RowFields()
                : base("[Acc].EmailChange")
            {
                LocalTextPrefix = "Email.EmailChange";
            }
        }
    }
}