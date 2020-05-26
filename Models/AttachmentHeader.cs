using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_AttachmentHeader")]
    public class AttachmentHeader
    {
        [Key]
        public int Attachment_Header_ID { get; set; }
        public int Attachment_Ref_ID { get; set; }
        public string Attachment_Group { get; set; }
        public string Attachment_Name { get; set; }
        public string Attachment_Type { get; set; }
        public int Attachment_Size { get; set; }
        public bool Is_Active { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }
    }

    public class AttachmentDoc
    {
        public AttachmentHeader AttachmentHeaderItem { get; set; }
        public AttachmentDetails AttachmentDetailsItem { get; set; }
    }
}
