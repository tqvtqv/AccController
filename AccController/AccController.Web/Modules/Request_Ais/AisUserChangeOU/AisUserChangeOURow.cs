﻿
namespace AccController.Request_Ais.Entities
{
    using Newtonsoft.Json;
    using Serenity;
    using Serenity.ComponentModel;
    using Serenity.Data;
    using Serenity.Data.Mapping;
    using System;
    using System.ComponentModel;
    using System.IO;

    [ConnectionKey("Default"), DisplayName("AisUserChangeOU"), InstanceName("AisUserChangeOU"), TwoLevelCached]
    [ReadPermission("Request_Ais")]
    [ModifyPermission("Request_Ais")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class AisUserChangeOURow : Row, IIdRow, INameRow
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

        [DisplayName("Old Ou"), Column("OldOU"), Size(255)]
        public String OldOu
        {
            get { return Fields.OldOu[this]; }
            set { Fields.OldOu[this] = value; }
        }

        [DisplayName("New Ou"), Column("NewOU"), Size(255)]
        public String NewOu
        {
            get { return Fields.NewOu[this]; }
            set { Fields.NewOu[this] = value; }
        }

        [DisplayName("New Jobtitle"), Size(150)]
        public String NewJobtitle
        {
            get { return Fields.NewJobtitle[this]; }
            set { Fields.NewJobtitle[this] = value; }
        }

        [DisplayName("New Role"), Size(150)]
        public String NewRole
        {
            get { return Fields.NewRole[this]; }
            set { Fields.NewRole[this] = value; }
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

        [DisplayName("By User"), Column("By_User"), Size(100)]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Email; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AisUserChangeOURow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Email;
            public readonly StringField OldOu;
            public readonly StringField NewOu;
            public readonly StringField NewJobtitle;
            public readonly StringField NewRole;
            public readonly Int32Field Priority;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField ByUser;
            public readonly StringField Submit;

            public RowFields()
                : base("[Acc].AisUserChangeOU")
            {
                LocalTextPrefix = "Request_Ais.AisUserChangeOU";
            }
        }
    }
}