
namespace AccController.Request_Email.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("EmailGroupAccounts"), InstanceName("EmailGroupAccounts"), TwoLevelCached]
    [ReadPermission("Request_GroupAccount")]
    [ModifyPermission("Request_GroupAccount")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailGroupAccountRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Account"), Size(50), NotNull, QuickSearch]
        public String Account
        {
            get { return Fields.Account[this]; }
            set { Fields.Account[this] = value; }
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

        [DisplayName("Alias"), Size(100), NotNull]
        public String Alias
        {
            get { return Fields.Alias[this]; }
            set { Fields.Alias[this] = value; }
        }

        [DisplayName("By User"), Column("By_User"), Size(100), NotNull]
        public String ByUser
        {
            get { return Fields.ByUser[this]; }
            set { Fields.ByUser[this] = value; }
        }

        [DisplayName("Submit"), Size(10)]
        public String Submit
        {
            get { return Fields.Submit[this]; }
            set { Fields.Submit[this] = value; }
        }

        [DisplayName("By Sub Admin"), Column("By_SubAdmin")]
        public Int32? BySubAdmin
        {
            get { return Fields.BySubAdmin[this]; }
            set { Fields.BySubAdmin[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Account; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmailGroupAccountRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Account;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField Alias;
            public readonly StringField ByUser;
            public readonly StringField Submit;
            public readonly Int32Field BySubAdmin;

            public RowFields()
                : base("[Acc].EmailGroupAccounts")
            {
                LocalTextPrefix = "Request_Email.EmailGroupAccount";
            }
        }
    }
}