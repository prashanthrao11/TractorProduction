using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Log_Details")]
    public class LogDetails
    {
        [Key]
        public int Log_ID { get; set; }
        public string Log_Type { get; set; }
        public string Log_Area { get; set; }
        public string Log_Message { get; set; }
    }
}
