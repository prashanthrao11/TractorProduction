using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Production_User_Approvals")]
    public class ProductionUserApproval
    {
        [Key]
        public int P_U_Approval_ID { get; set; }
        public int Production_ID { get; set; }
        public int Role_ID { get; set; }
        public int? Submitted_By_ID { get; set; }

        public int? Status_ID { get; set; }
        public string Comments { get; set; }
    }
}
