using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    public class FileUpload
    {
        public string FileName { get; set; }
        public double FileSize { get; set; }
        public string FileType { get; set; }
        public byte[] FileAsByteArray { get; set; }
    }
}
