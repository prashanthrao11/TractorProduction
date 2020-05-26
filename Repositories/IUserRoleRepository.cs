using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetUserRoles();
        Task<UserRole> GetUserRoleById(int? userroleID);
        Task<int> AddUserRole(UserRole userrole);
        Task<int> DeleteUserRole(int? userroleID);
        Task UpdateUserRole(UserRole userrole);
    }
}
