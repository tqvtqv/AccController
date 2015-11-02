
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

    [ConnectionKey("Default"), DisplayName("AisUser"), InstanceName("AisUser"), TwoLevelCached]
    [ReadPermission("AisUser")]
    [ModifyPermission("AisUser")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class AisUserRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Ou"), Column("OU"), Size(255), NotNull, QuickSearch]
        public String Ou
        {
            get { return Fields.Ou[this]; }
            set { Fields.Ou[this] = value; }
        }

        [DisplayName("Email"), Size(150), NotNull]
        public String Email
        {
            get { return Fields.Email[this]; }
            set { Fields.Email[this] = value; }
        }

        [DisplayName("Phone"), Size(50)]
        public String Phone
        {
            get { return Fields.Phone[this]; }
            set { Fields.Phone[this] = value; }
        }

        [DisplayName("Mobile"), Size(50)]
        public String Mobile
        {
            get { return Fields.Mobile[this]; }
            set { Fields.Mobile[this] = value; }
        }

        [DisplayName("Jobtitle"), Size(150)]
        public String Jobtitle
        {
            get { return Fields.Jobtitle[this]; }
            set { Fields.Jobtitle[this] = value; }
        }

        [DisplayName("Role"), Size(150)]
        public String Role
        {
            get { return Fields.Role[this]; }
            set { Fields.Role[this] = value; }
        }

        [DisplayName("Priority"), NotNull]
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

        [DisplayName("Name"), Size(150), NotNull]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Ou; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AisUserRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Ou;
            public readonly StringField Email;
            public readonly StringField Phone;
            public readonly StringField Mobile;
            public readonly StringField Jobtitle;
            public readonly StringField Role;
            public readonly Int32Field Priority;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField Name;

            public RowFields()
                : base("[Acc].AisUser")
            {
                LocalTextPrefix = "Ais.AisUser";
            }
        }
    }
}