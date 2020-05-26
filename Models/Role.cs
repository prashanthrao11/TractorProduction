using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Role")]
    public class Role
    {
        [Key]
        public int Role_ID { get; set; }
        public string Role_Key { get; set; }
        public string Role_Name { get; set; }
        
    }
}
