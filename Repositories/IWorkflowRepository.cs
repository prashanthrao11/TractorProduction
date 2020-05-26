using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
   public interface IWorkflowRepository
    {
        Task<List<Workflow>> GetWorkflows();
        Task<Workflow> GetWorkflowById(int? workflowId);
        Task<int> AddWorkflow(Workflow workflow);
        Task<int> DeleteWorkflow(int? workflowId);
        Task UpdateWorkflow(Workflow workflow);
    }
}
