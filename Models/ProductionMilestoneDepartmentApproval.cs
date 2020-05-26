using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Production_Milestone_Department_Approvals")]
    public class ProductionMilestoneDepartmentApproval
    {
        [Key]
        public int P_D_ID { get; set; }
        public int Production_ID { get; set; }
        public int Department_ID { get; set; }
        public int Submitted_By_ID { get; set; }
    }
}
