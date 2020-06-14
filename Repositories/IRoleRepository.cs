using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
   public interface IRoleRepository : IDisposable
    {
        Task<Response<List<Role>>> GetRoles();
        Task<Response<Role>> GetRoleById(int? roleId);
        
        Task<Response<int>> AddRole(Role role);
        Task<Response<int>> DeleteRole(int? roleId);
        Task<Response<bool>> UpdateRole(Role role);
    }
}
