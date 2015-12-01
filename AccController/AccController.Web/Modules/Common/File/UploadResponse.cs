using Serenity.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccController.Modules.Common.File
{
    public class UploadResponse<T> : ServiceResponse
    {
        public string TemporaryFile { get; set; }
        public long Size { get; set; }
        public bool IsImage { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ContenType { get; set; }
        public T UploadedFile { get; set; }
    }
    public class ListContainer<T>
    {
        public List<T> Entities { get; set; }
    }
}
