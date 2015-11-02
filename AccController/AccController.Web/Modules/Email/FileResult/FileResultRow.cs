
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

    [ConnectionKey("Default"), DisplayName("EmailFileResults"), InstanceName("EmailFileResults"), TwoLevelCached]
    [ReadPermission("FileResult")]
    [ModifyPermission("FileResult")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class FileResultRow : Row, IIdRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("File Id"), NotNull]
        public Int32? FileId
        {
            get { return Fields.FileId[this]; }
            set { Fields.FileId[this] = value; }
        }

        [DisplayName("Req Id"), NotNull]
        public Int32? ReqId
        {
            get { return Fields.ReqId[this]; }
            set { Fields.ReqId[this] = value; }
        }

        [DisplayName("Req Type"), NotNull]
        public Int16? ReqType
        {
            get { return Fields.ReqType[this]; }
            set { Fields.ReqType[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public FileResultRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly Int32Field FileId;
            public readonly Int32Field ReqId;
            public readonly Int16Field ReqType;

            public RowFields()
                : base("[Acc].EmailFileResults")
            {
                LocalTextPrefix = "Email.FileResult";
            }
        }
    }
}