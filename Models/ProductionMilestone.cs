using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("Tb_Production_Milestones")]
    public class ProductionMilestone
    {
        [Key]
        public int P_Approval_ID { get; set; }
        public int Production_ID { get; set; }
        public int Milestone_Department_ID { get; set; }
        public int Status_ID { get; set; }
        public DateTime? TargetDate { get; set; }
        public DateTime? ActualDate { get; set; }
        public string Comments { get; set; }

        public bool Is_Active{get;set;}
    }

    public class ProductionMilestoneVM
    {
        public ProductionMilestone ProdMilestoneItem { get; set; }
        public WorkflowPhaseMilestone MilestoneItem { get; set; }
        public ProductPhase PhaseItem { get; set; }
        public Department DeptItem { get; set; }
        public bool IsDepartmentUser { get; set; }
    }

    public class ProductionMilestonesVM
    {
        public int Production_ID { get; set; }
        public List<ProductionMilestoneVM> ProductionMilestones { get; set; }
    }
}
