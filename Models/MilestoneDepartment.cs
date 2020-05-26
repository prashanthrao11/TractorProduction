using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Milestone_Department")]
    public class MilestoneDepartment
    {
        [Key]
        public int Milestone_Department_ID { get; set; }
        public int Milestone_ID { get; set; }
        public int Department_ID { get; set; }

        public bool Is_Active { get; set; }
    }
}
