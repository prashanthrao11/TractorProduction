using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Department_Approvers")]
    public class DepartmentApprover
    {
        [Key]
        public int Department_Approver_ID { get; set; }
        public int Workflow_ID { get; set; }
        public int Department_ID { get; set; }
        public int Role_ID { get; set; }
        public bool Is_Active { get; set; }
    }

    public class DepartmentApproversVM
    {
        public int Workflow_ID { get; set; }
        public List<DepartmentApprover> DepartmentApproverItems { get; set; }
    }
}
