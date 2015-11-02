
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

    [ConnectionKey("Default"), DisplayName("AisFiles"), InstanceName("AisFiles"), TwoLevelCached]
    [ReadPermission("AisFile")]
    [ModifyPermission("AisFile")]
    [JsonConverter(typeof(JsonRowConverter))]
    public sealed class AisFileRow : Row, IIdRow, INameRow
    {
        [DisplayName("Id"), Identity]
        public Int32? Id
        {
            get { return Fields.Id[this]; }
            set { Fields.Id[this] = value; }
        }

        [DisplayName("File Name"), Size(150), NotNull, QuickSearch]
        public String FileName
        {
            get { return Fields.FileName[this]; }
            set { Fields.FileName[this] = value; }
        }

        [DisplayName("File Size"), NotNull]
        public Int32? FileSize
        {
            get { return Fields.FileSize[this]; }
            set { Fields.FileSize[this] = value; }
        }

        [DisplayName("Content Type"), Size(150), NotNull]
        public String ContentType
        {
            get { return Fields.ContentType[this]; }
            set { Fields.ContentType[this] = value; }
        }

        [DisplayName("File Path"), Size(255)]
        public String FilePath
        {
            get { return Fields.FilePath[this]; }
            set { Fields.FilePath[this] = value; }
        }

        [DisplayName("Uploaded")]
        public DateTime? Uploaded
        {
            get { return Fields.Uploaded[this]; }
            set { Fields.Uploaded[this] = value; }
        }

        [DisplayName("Uploaded By"), Size(50)]
        public String UploadedBy
        {
            get { return Fields.UploadedBy[this]; }
            set { Fields.UploadedBy[this] = value; }
        }

        IIdField IIdRow.IdField
        {
            get { return Fields.Id; }
        }

        StringField INameRow.NameField
        {
            get { return Fields.FileName; }
        }

        public static readonly RowFields Fields = new RowFields().Init();

        public AisFileRow()
            : base(Fields)
        {
        }

        public class RowFields : RowFieldsBase
        {
            public readonly Int32Field Id;
            public readonly StringField FileName;
            public readonly Int32Field FileSize;
            public readonly StringField ContentType;
            public readonly StringField FilePath;
            public readonly DateTimeField Uploaded;
            public readonly StringField UploadedBy;

            public RowFields()
                : base("[Acc].AisFiles")
            {
                LocalTextPrefix = "Ais.AisFile";
            }
        }
    }
}