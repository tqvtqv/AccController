
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

    [ConnectionKey("Default"), DisplayName("EmailGroup"), InstanceName("EmailGroup"), TwoLevelCached]
    [ReadPermission("EmailGroup")]
    [ModifyPermission("EmailGroup")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailGroupRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Alias"), Size(50), NotNull, QuickSearch]
        public String Alias
        {
            get { return Fields.Alias[this]; }
            set { Fields.Alias[this] = value; }
        }

        [DisplayName("Displayname"), Size(150), NotNull]
        public String Displayname
        {
            get { return Fields.Displayname[this]; }
            set { Fields.Displayname[this] = value; }
        }

        [DisplayName("Ou"), Column("OU"), Size(255), NotNull]
        public String Ou
        {
            get { return Fields.Ou[this]; }
            set { Fields.Ou[this] = value; }
        }

        [DisplayName("Status"), NotNull]
        public Int16? Status
        {
            get { return Fields.Status[this]; }
            set { Fields.Status[this] = value; }
        }

        [DisplayName("Result"), NotNull]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Alias; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmailGroupRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Alias;
            public readonly StringField Displayname;
            public readonly StringField Ou;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;

            public RowFields()
                : base("[Acc].EmailGroup")
            {
                LocalTextPrefix = "Email.EmailGroup";
            }
        }
    }
}