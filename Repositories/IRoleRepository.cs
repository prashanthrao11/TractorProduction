using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;

namespace TractorProduction.Web.Repositories
{
   public interface IRoleRepository
    {
        Task<List<Role>> GetRoles();
        Task<Role> GetRoleById(int? roleId);
        
        Task<int> AddRole(Role role);
        Task<int> DeleteRole(int? roleId);
        Task UpdateRole(Role role);
    }
}
