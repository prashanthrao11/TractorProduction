using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TractorProduction.Web.Models
{
    [Table("VW_MilestoneDeptDetails")]
    public class MilestoneManageVM
    {
        [Key]
        public int Milestone_ID { get; set; }
        public int Workflow_ID { get; set; }
        public int Phase_ID { get; set; }
        public string Milestone_Name { get; set; }
        public string Milestone_Desc { get; set; }


        public string WorkflowName { get; set; }

        public int SLA { get; set; }
        public string PhaseName { get; set; }

        public string DepartmentNames { get; set; }

        public string DepartmentIds { get; set; }

        public bool Is_Active { get; set; }
    }
}
