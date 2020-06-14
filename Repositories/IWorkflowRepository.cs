using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
   public interface IWorkflowRepository : IDisposable
    {
        Task<Response<List<Workflow>>> GetWorkflows();
        Task<Response<Workflow>> GetWorkflowById(int? workflowId);
        Task<Response<int>> AddWorkflow(Workflow workflow);
        Task<Response<int>> DeleteWorkflow(int? workflowId);
        Task<Response<bool>> UpdateWorkflow(Workflow workflow);
    }
}
