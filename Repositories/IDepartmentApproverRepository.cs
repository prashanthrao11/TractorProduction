using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IDepartmentApproverRepository
    {
        Task<List<DepartmentApprover>> GetDepartmentApprovers(int workflowId);
        Task<int> UpdateDepartmentApprovers(DepartmentApproversVM model);
    }
}

