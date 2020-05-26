using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IWorkflowPhaseMilestoneRepository
    {
        Task<List<MilestoneManageVM>> GetWorkflowPhaseMilestones();
        Task<MilestoneManageVM> GetWorkflowPhaseMilestoneById(int? workflowphasemilestoneID);
        Task<int> AddWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone);
        Task<int> DeleteWorkflowPhaseMilestone(int? workflowphasemilestoneID);
        Task UpdateWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone);
    }
}
