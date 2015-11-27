
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

    [ConnectionKey("Default"), DisplayName("EmailGroupAccounts"), InstanceName("EmailGroupAccounts"), TwoLevelCached]
    [ReadPermission("GroupAccount")]
    [ModifyPermission("GroupAccount")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailGroupAccountRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Alias"), NotNull, ForeignKey("[Acc].EmailGroup", "Id"), LeftJoin("jGroup")]
        //[LookupEditor("Email.EmailGroup")]
        public String Alias
        {
            get { return Fields.Alias[this]; }
            set { Fields.Alias[this] = value; }
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

        [DisplayName("Group Alias"), Expression("jGroup.Alias")]
        public String GroupAlias
        {
            get { return Fields.GroupAlias[this]; }
            set { Fields.GroupAlias[this] = value; }
        }

        [DisplayName("Group Displayname"), Expression("jGroup.Displayname")]
        public String GroupDisplayname
        {
            get { return Fields.GroupDisplayname[this]; }
            set { Fields.GroupDisplayname[this] = value; }
        }

        [DisplayName("Group Ou"), Expression("jGroup.OU")]
        public String GroupOu
        {
            get { return Fields.GroupOu[this]; }
            set { Fields.GroupOu[this] = value; }
        }

        [DisplayName("Group Status"), Expression("jGroup.Status")]
        public Int16? GroupStatus
        {
            get { return Fields.GroupStatus[this]; }
            set { Fields.GroupStatus[this] = value; }
        }

        [DisplayName("Group Result"), Expression("jGroup.Result")]
        public Int16? GroupResult
        {
            get { return Fields.GroupResult[this]; }
            set { Fields.GroupResult[this] = value; }
        }

        [DisplayName("Group Last Updated"), Expression("jGroup.LastUpdated")]
        public DateTime? GroupLastUpdated
        {
            get { return Fields.GroupLastUpdated[this]; }
            set { Fields.GroupLastUpdated[this] = value; }
        }

        [DisplayName("Group Last Updatedby"), Expression("jGroup.LastUpdatedby")]
        public String GroupLastUpdatedby
        {
            get { return Fields.GroupLastUpdatedby[this]; }
            set { Fields.GroupLastUpdatedby[this] = value; }
        }

        [DisplayName("Group Description"), Expression("jGroup.Description")]
        public String GroupDescription
        {
            get { return Fields.GroupDescription[this]; }
            set { Fields.GroupDescription[this] = value; }
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
            public readonly StringField Alias;
            public readonly StringField Account;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;

            public readonly StringField GroupAlias;
            public readonly StringField GroupDisplayname;
            public readonly StringField GroupOu;
            public readonly Int16Field GroupStatus;
            public readonly Int16Field GroupResult;
            public readonly DateTimeField GroupLastUpdated;
            public readonly StringField GroupLastUpdatedby;
            public readonly StringField GroupDescription;
            public readonly StringField By_User;
            public readonly StringField Submit;
            public RowFields()
                : base("[Acc].EmailGroupAccounts")
            {
                LocalTextPrefix = "Email.EmailGroupAccount";
            }
        }
    }
}