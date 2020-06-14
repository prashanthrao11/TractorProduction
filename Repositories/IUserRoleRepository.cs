using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractorProduction.Web.Models;
namespace TractorProduction.Web.Repositories
{
    public interface IUserRoleRepository : IDisposable
    {
        Task<Response<List<UserRole>>> GetUserRoles();
        Task<Response<UserRole>> GetUserRoleById(int? userroleID);
        Task<Response<int>> AddUserRole(UserRole userrole);
        Task<Response<int>> DeleteUserRole(int? userroleID);
        Task<Response<bool>> UpdateUserRole(UserRole userrole);
    }
}
