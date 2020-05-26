using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Status")]
    public class Status
    {
        [Key]
        public int Status_ID { get; set; }
        public int Status_Type_ID { get; set; }
        public string Status_Key { get; set; }
        public string Status_Name { get; set; }
    }
}
