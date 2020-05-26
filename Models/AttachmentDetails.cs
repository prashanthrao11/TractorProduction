using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Attachment_Details")]
    public class AttachmentDetails
    {
        [Key]
        public int Attachment_Obj_ID { get; set; }
        public int Attachment_Header_ID { get; set; }
        public byte[] Attachment_Obj { get; set; }
        public bool Is_Active { get; set; }
        public string Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Modified_By { get; set; }
        public DateTime? Modified_Date { get; set; }

    }
}
