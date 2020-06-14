using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
    public interface IDepartmentApproverRepository : IDisposable
    {
        Task<Response<List<DepartmentApprover>>> GetDepartmentApprovers(int workflowId);
        Task<Response<int>> UpdateDepartmentApprovers(DepartmentApproversVM model);
    }
}

