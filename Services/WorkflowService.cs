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
    public class WorkflowService : BaseService, IWorkflowRepository
    {
        public WorkflowService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddWorkflow(Workflow workflow)
        {
            try
            {
                workflow.Workflow_Key = workflow.Workflow_Name.Replace(" ", "_");
                if (workflow.Workflow_ID != 0)
                {
                    var item = _context.Workflow.Find(workflow.Workflow_ID);
                    item.Workflow_Name = workflow.Workflow_Name;
                    item.Is_Active = workflow.Is_Active;
                }
                else
                {

                    await _context.Workflow.AddAsync(workflow);
                }
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = workflow.Workflow_ID
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<int>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<int>> DeleteWorkflow(int? workflowId)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<Workflow>> GetWorkflowById(int? workflowId)
        {
            try
            {
                var model= await _context.Workflow.Where(x => x.Workflow_ID == workflowId).FirstOrDefaultAsync();
                return new Response<Workflow>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<Workflow>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response<List<Workflow>>> GetWorkflows()
        {
            try
            {
                var model= await _context.Workflow.ToListAsync();
                return new Response<List<Workflow>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<Workflow>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateWorkflow(Workflow workflow)
        {
            throw new NotImplementedException();
        }
    }
}
