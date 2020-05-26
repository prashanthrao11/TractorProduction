using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Email_Templates")]
    public class EmailTemplate
    {
        [Key]
        public int Email_Template_ID { get; set; }
        public string Email_Template_Text { get; set; }
        public string StageKey { get; set; }

    }
}
