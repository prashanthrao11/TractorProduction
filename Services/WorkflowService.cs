using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Data;
using TractorProduction.Web.Models;
using TractorProduction.Web.Repositories;

namespace TractorProduction.Web.Services
{
    public class WorkflowService : IWorkflowRepository
    {
        private readonly APIContext _context;
        public WorkflowService(APIContext context)
        {
            _context = context;
        }
        public async Task<int> AddWorkflow(Workflow workflow)
        {
            if (_context != null)
            {
                workflow.Workflow_Key = workflow.Workflow_Name.Replace(" ", "_");
                if (workflow.Workflow_ID!=0){
                    var item = _context.Workflow.Find(workflow.Workflow_ID);
                    item.Workflow_Name = workflow.Workflow_Name;
                    item.Is_Active = workflow.Is_Active;
                }
                else
                {

                    await _context.Workflow.AddAsync(workflow);
                }
                await _context.SaveChangesAsync();
                return workflow.Workflow_ID;
            }
            return 0;
        }

        public Task<int> DeleteWorkflow(int? workflowId)
        {
            throw new NotImplementedException();
        }

        public async Task<Workflow> GetWorkflowById(int? workflowId)
        {
            if (_context != null)
            {
                return await _context.Workflow.Where(x => x.Workflow_ID == workflowId).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<Workflow>> GetWorkflows()
        {
            if (_context != null)
            {
                return await _context.Workflow.ToListAsync();
            }
            return null;
        }

        public Task UpdateWorkflow(Workflow workflow)
        {
            throw new NotImplementedException();
        }
    }
}
