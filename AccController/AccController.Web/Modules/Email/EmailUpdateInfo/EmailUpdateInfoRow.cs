
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

    [ConnectionKey("Default"), DisplayName("EmailUpdateInfo"), InstanceName("EmailUpdateInfo"), TwoLevelCached]
    [ReadPermission("EmailUpdateInfo")]
    [ModifyPermission("EmailUpdateInfo")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailUpdateInfoRow : Row, IIdRow, INameRow
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

        [DisplayName("Name"), Size(150), NotNull]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Job Title"), Size(150), NotNull]
        public String JobTitle
        {
            get { return Fields.JobTitle[this]; }
            set { Fields.JobTitle[this] = value; }
        }

        [DisplayName("Department"), Size(255)]
        public String Department
        {
            get { return Fields.Department[this]; }
            set { Fields.Department[this] = value; }
        }

        [DisplayName("Company"), Size(255)]
        public String Company
        {
            get { return Fields.Company[this]; }
            set { Fields.Company[this] = value; }
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

        [DisplayName("Birthday")]
        public Stream Birthday
        {
            get { return Fields.Birthday[this]; }
            set { Fields.Birthday[this] = value; }
        }

        [DisplayName("Ou"), Column("OU"), Size(255)]
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
            get { return Fields.Account; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmailUpdateInfoRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Account;
            public readonly StringField Name;
            public readonly StringField JobTitle;
            public readonly StringField Department;
            public readonly StringField Company;
            public readonly StringField Phone;
            public readonly StringField Mobile;
            public readonly StreamField Birthday;
            public readonly StringField Ou;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;

            public RowFields()
                : base("[Acc].EmailUpdateInfo")
            {
                LocalTextPrefix = "Email.EmailUpdateInfo";
            }
        }
    }
}