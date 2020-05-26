using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Department")]
    public class Department
    {
        [Key]
        public int Department_ID { get; set; }
        public string Department_Key { get; set; }
        public string Department_Name { get; set; }
    }
}
