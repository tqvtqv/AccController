
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

    [ConnectionKey("Default"), DisplayName("EmailNew"), InstanceName("EmailNew"), TwoLevelCached]
    [ReadPermission("EmailNew")]
    [ModifyPermission("EmailNew")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class EmailNewRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Name"), Size(150), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Alias"), Size(150), NotNull]
        public String Alias
        {
            get { return Fields.Alias[this]; }
            set { Fields.Alias[this] = value; }
        }

        [DisplayName("Password"), Size(150)]
        public String Password
        {
            get { return Fields.Password[this]; }
            set { Fields.Password[this] = value; }
        }

        [DisplayName("Displayname"), Size(150)]
        public String Displayname
        {
            get { return Fields.Displayname[this]; }
            set { Fields.Displayname[this] = value; }
        }

        [DisplayName("Firstname"), Size(90), NotNull]
        public String Firstname
        {
            get { return Fields.Firstname[this]; }
            set { Fields.Firstname[this] = value; }
        }

        [DisplayName("Lastname"), Size(60), NotNull]
        public String Lastname
        {
            get { return Fields.Lastname[this]; }
            set { Fields.Lastname[this] = value; }
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
        public DateTime? Birthday
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

        [DisplayName("User Principal"), Size(150), NotNull]
        public String UserPrincipal
        {
            get { return Fields.UserPrincipal[this]; }
            set { Fields.UserPrincipal[this] = value; }
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

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public EmailNewRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Name;
            public readonly StringField Alias;
            public readonly StringField Password;
            public readonly StringField Displayname;
            public readonly StringField Firstname;
            public readonly StringField Lastname;
            public readonly StringField JobTitle;
            public readonly StringField Department;
            public readonly StringField Company;
            public readonly StringField Phone;
            public readonly StringField Mobile;
            public readonly DateTimeField Birthday;
            public readonly StringField Ou;
            public readonly StringField UserPrincipal;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;

            public RowFields()
                : base("[Acc].EmailNew")
            {
                LocalTextPrefix = "Email.EmailNew";
            }
        }
    }
}