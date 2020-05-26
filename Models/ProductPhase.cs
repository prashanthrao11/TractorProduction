using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Product_Phases")]
    public class ProductPhase
    {
        [Key]
        public int Product_Phase_ID { get; set; }
        public string Phase_Key { get; set; }
        public string Phase_Name { get; set; }

        public bool Is_Active { get; set; }
    }
}
