using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Production_Approvals")]
    public class ProductionApproval
    {
        [Key]
        public int P_D_Approval_ID { get; set; }
        public int Production_ID { get; set; }
        public int Department_ID { get; set; }
        public int Role_ID { get; set; }
        public string Action_By { get; set; }
        public DateTime? Action_Date { get; set; }
        public int Action_Status_ID { get; set; }
        public string Action_Status { get; set; }
        public string Action_Comments { get; set; }
        public bool Is_Active { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
        [NotMapped]
        public string RoleName { get; set; }
        public string Modified_By { get; set; }

    }

    public class ProductionApprovalVM
    {
        public int Production_ID { get; set; }
        public List<ProductionApproval> Items { get; set; }
    }
}
