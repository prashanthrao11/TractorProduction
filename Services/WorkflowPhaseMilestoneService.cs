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
    public class WorkflowPhaseMilestoneService : BaseService, IWorkflowPhaseMilestoneRepository
    {
       
        public WorkflowPhaseMilestoneService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<int>> AddWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone)
        {
            try
            {
                if (workflowphasemilestone.Milestone_ID != 0)
                {
                    var item = _context.WorkflowPhaseMilestone.Find(workflowphasemilestone.Milestone_ID);
                    item.Milestone_Name = workflowphasemilestone.Milestone_Name;
                    item.Milestone_ID = workflowphasemilestone.Milestone_ID;
                    item.Phase_ID = workflowphasemilestone.Phase_ID;
                    item.SLA = workflowphasemilestone.SLA;
                    item.Workflow_ID = workflowphasemilestone.Workflow_ID;
                    item.Is_Active = workflowphasemilestone.Is_Active;
                    var existingList = _context.MilestoneDepartment.Where(x => x.Milestone_ID == workflowphasemilestone.Milestone_ID).ToList();
                    foreach (var eItem in existingList)
                    {
                        if (workflowphasemilestone.DepartmentIds.IndexOf(eItem.Department_ID.ToString()) == 0)
                        {
                            eItem.Is_Active = false;
                        }
                    }
                    await _context.SaveChangesAsync();
                    foreach (var deptIdStr in workflowphasemilestone.DepartmentIds.Split(','))
                    {
                        int deptId = Convert.ToInt32(deptIdStr);
                        var deptItem = _context.MilestoneDepartment.Where(x => x.Department_ID == deptId && x.Milestone_ID == item.Milestone_ID).FirstOrDefault();

                        if (deptItem == null)
                        {
                            MilestoneDepartment department = new MilestoneDepartment();
                            department.Department_ID = deptId;
                            department.Milestone_ID = item.Milestone_ID;
                            department.Is_Active = true;
                            _context.MilestoneDepartment.Add(department);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            deptItem.Is_Active = true;
                            await _context.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    WorkflowPhaseMilestone obj = new WorkflowPhaseMilestone();
                    obj.Milestone_ID = workflowphasemilestone.Milestone_ID;
                    obj.Milestone_Name = workflowphasemilestone.Milestone_Name;
                    obj.Phase_ID = workflowphasemilestone.Phase_ID;
                    obj.SLA = workflowphasemilestone.SLA;
                    obj.Workflow_ID = workflowphasemilestone.Workflow_ID;
                    obj.Is_Active = workflowphasemilestone.Is_Active;
                    await _context.WorkflowPhaseMilestone.AddAsync(obj);
                    List<MilestoneDepartment> deptList = new List<MilestoneDepartment>();
                    foreach (var deptItem in workflowphasemilestone.DepartmentIds.Split(','))
                    {
                        int deptId = Convert.ToInt32(deptItem);
                        MilestoneDepartment department = new MilestoneDepartment();
                        department.Department_ID = deptId;
                        department.Milestone_ID = workflowphasemilestone.Milestone_ID;
                        department.Is_Active = true;
                        deptList.Add(department);
                    }
                    _context.MilestoneDepartment.AddRange(deptList);
                    await _context.SaveChangesAsync();
                }
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = workflowphasemilestone.Milestone_ID
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

        public Task<Response<int>> DeleteWorkflowPhaseMilestone(int? workflowphasemilestoneID)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<MilestoneManageVM>> GetWorkflowPhaseMilestoneById(int? workflowphasemilestoneID)
        {
            try
            {
                var model= await _context.ManageMilestone.FromSqlRaw("USP_Get_MilestoneDeptDetails {0}", workflowphasemilestoneID).FirstOrDefaultAsync();
                return new Response<MilestoneManageVM>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<MilestoneManageVM>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public Task<Response<bool>> UpdateWorkflowPhaseMilestone(MilestoneManageVM workflowphasemilestone)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<MilestoneManageVM>>> GetWorkflowPhaseMilestones()
        {
            try
            {
                var model= await _context.ManageMilestone.FromSqlRaw("USP_Get_MilestoneDeptDetails").ToListAsync();
                return new Response<List<MilestoneManageVM>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<MilestoneManageVM>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
}
