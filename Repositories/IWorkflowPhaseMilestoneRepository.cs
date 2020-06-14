using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
   public interface IWorkflowPhaseMilestoneRepository : IDisposable
    {
        Task<Response<List<MilestoneManageVM>>> GetWorkflowPhaseMilestones();
        Task<Response<MilestoneManageVM>> GetWorkflowPhaseMilestoneById(int? workflowphasemilestoneID);
        Task<Response<int>> AddWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone);
        Task<Response<int>> DeleteWorkflowPhaseMilestone(int? workflowphasemilestoneID);
        Task<Response<bool>> UpdateWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone);
    }
}
