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
    public class DepartmentApproversService : BaseService, IDepartmentApproverRepository
    {
        public DepartmentApproversService(APIContext context, ILogDetailsRepository log, IUserRepository user) : base(context, log, user)
        {

        }
        public async Task<Response<List<DepartmentApprover>>> GetDepartmentApprovers(int workflowId)
        {
            try
            {
                var model = await _context.DepartmentApprover.Where(x => x.Workflow_ID == workflowId && x.Is_Active == true).ToListAsync();
                return new Response<List<DepartmentApprover>>()
                {
                    IsSuccess = true,
                    Model = model
                };
            }
            catch (Exception ex)
            {
                _log.Error(ex, _user.GetCurrentUser().User_Name);
                return new Response<List<DepartmentApprover>>()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
        public async Task<Response<int>> UpdateDepartmentApprovers(DepartmentApproversVM model)
        {
            try
            {
                int success = 0;
                List<DepartmentApprover> newList = new List<DepartmentApprover>();

                var list = await _context.DepartmentApprover.Where(x => x.Workflow_ID == model.Workflow_ID && x.Is_Active == true).ToListAsync();
                foreach (var item in list)
                {
                    if (!model.DepartmentApproverItems.Any(x => x.Department_ID == item.Department_ID && x.Role_ID == item.Role_ID && item.Is_Active == true))
                    {
                        item.Is_Active = false;
                    }
                }
                await _context.SaveChangesAsync();
                foreach (var item in model.DepartmentApproverItems)
                {
                    var _tempItem = list.Where(x => x.Department_ID == item.Department_ID && x.Role_ID == item.Role_ID && x.Workflow_ID == item.Workflow_ID).FirstOrDefault();
                    if (_tempItem == null)
                    {
                        item.Is_Active = true;
                        newList.Add(item);
                    }
                    else
                    {
                        if (_tempItem.Is_Active == false)
                        {
                            _tempItem.Is_Active = true;
                        }
                    }
                }
                _context.DepartmentApprover.AddRange(newList);
                await _context.SaveChangesAsync();
                return new Response<int>()
                {
                    IsSuccess = true,
                    Model = success
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
    }
}
