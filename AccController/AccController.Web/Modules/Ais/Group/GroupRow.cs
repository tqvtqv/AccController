
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

    [ConnectionKey("Default"), DisplayName("AisGroup"), InstanceName("AisGroup"), TwoLevelCached]
    [ReadPermission("Ais")]
    [ModifyPermission("Ais")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class GroupRow : Row, IIdRow, INameRow
    {

        public bool Select { get; set; }
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("Tên phòng ban"), Size(150), NotNull, QuickSearch]
        public String Name
        {
            get { return Fields.Name[this]; }
            set { Fields.Name[this] = value; }
        }

        [DisplayName("Trực thuộc phòng ban"), Size(150), NotNull]
        public String Parent
        {
            get { return Fields.Parent[this]; }
            set { Fields.Parent[this] = value; }
        }

        [DisplayName("Nhóm cơ quan"), Size(150)]
        public String Category
        {
            get { return Fields.Category[this]; }
            set { Fields.Category[this] = value; }
        }

        [DisplayName("Tên viết tắt"), Size(50), NotNull]
        public String Shortname
        {
            get { return Fields.Shortname[this]; }
            set { Fields.Shortname[this] = value; }
        }

        [DisplayName("Đơn vị đồng nhận văn bản"), Size(150)]
        public String Relate
        {
            get { return Fields.Relate[this]; }
            set { Fields.Relate[this] = value; }
        }

        [DisplayName("Mức ưu tiên"),Size(150), NotNull]
        public Int16? Priority
        {
            get { return Fields.Priority[this]; }
            set { Fields.Priority[this] = value; }
        }

        [DisplayName("Status") ]
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

        [DisplayName("Last Updated")]
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
        [TextAreaEditor(Rows = 5)]
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

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.Name; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public GroupRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField Name;
            public readonly StringField Parent;
            public readonly StringField Category;
            public readonly StringField Shortname;
            public readonly StringField Relate;
            public readonly Int16Field Priority;
            public readonly Int16Field Status;
            public readonly Int16Field Result;
            public readonly DateTimeField LastUpdated;
            public readonly StringField LastUpdatedby;
            public readonly StringField Description;
            public readonly StringField By_User;
            public readonly StringField Submit;

            public RowFields()
                : base("[Acc].AisGroup")
            {
                LocalTextPrefix = "Ais.Group";
            }
        }
    }
}