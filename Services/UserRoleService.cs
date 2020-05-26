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
    public class UserRoleService : IUserRoleRepository
    {
        private readonly APIContext _context;
        public UserRoleService(APIContext context)
        {
            _context = context;
        }
        public Task<int> AddUserRole(UserRole userrole)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteUserRole(int? userroleID)
        {
            throw new NotImplementedException();
        }

        public async Task<UserRole> GetUserRoleById(int? userroleID)
        {
            if (_context != null)
            {
                return await _context.UserRole.Where(x => x.User_Role_ID == userroleID).FirstOrDefaultAsync();
            }
            return null;
        }

        public async Task<List<UserRole>> GetUserRoles()
        {
            if (_context != null)
            {
                return await _context.UserRole.ToListAsync();
            }
            return null;
        }

        public Task UpdateUserRole(UserRole userrole)
        {
            throw new NotImplementedException();
        }
    }
}
