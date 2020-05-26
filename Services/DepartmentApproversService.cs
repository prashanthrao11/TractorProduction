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
    public class DepartmentApproversService : IDepartmentApproverRepository
    {
        private readonly APIContext _context;
        public DepartmentApproversService(APIContext context)
        {
            _context = context;
        }
        public async Task<List<DepartmentApprover>> GetDepartmentApprovers(int workflowId)
        {
            if (_context != null)
            {
                return await _context.DepartmentApprover.Where(x=>x.Workflow_ID==workflowId && x.Is_Active==true).ToListAsync();
            }
            return null;
        }
        public async Task<int> UpdateDepartmentApprovers(DepartmentApproversVM model)
        {
            int success = 0;
            List<DepartmentApprover> newList = new List<DepartmentApprover>();
            if (_context != null)
            {
                var list = await _context.DepartmentApprover.Where(x => x.Workflow_ID == model.Workflow_ID && x.Is_Active==true).ToListAsync();
                foreach(var item in list)
                {
                    if(!model.DepartmentApproverItems.Any(x=>x.Department_ID==item.Department_ID && x.Role_ID==item.Role_ID && item.Is_Active == true))
                    {
                        item.Is_Active = false;
                    }
                }
                await _context.SaveChangesAsync();
                foreach(var item in model.DepartmentApproverItems)
                {
                    var _tempItem = list.Where(x => x.Department_ID == item.Department_ID && x.Role_ID == item.Role_ID && x.Workflow_ID == item.Workflow_ID).FirstOrDefault();
                    if (_tempItem==null)
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
            }
            return success;
        }
    }
}
